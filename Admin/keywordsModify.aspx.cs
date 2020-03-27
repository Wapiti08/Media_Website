using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加引用
using System.Configuration;//添加引用
using System.Data.SqlClient;//添加引用


public partial class Admin_keywordsModify : System.Web.UI.Page
{
    

    public string connString = ConfigurationManager.ConnectionStrings["connStr"].ToString();
    public string keywordsPictureName = "";
    public string pictureName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则定向到后台登录页
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");  //定向到后台登录页
        }

        if (!IsPostBack)
        {
            //Session["userFromHomeNews"] = 1;

            //第一次运行时操作
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from keywords where keywordsID =" + Request.QueryString["id"], conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ddlkeywordsCategoryName.Text = reader["keywordsCategoryName"].ToString();
                txtkeywordsTitle.Text = reader["keywordsTitle"].ToString();
                txtkeywordsAuthor.Text = reader["keywordsAuthor"].ToString(); 
                hiddenFieldPicture.Value = reader["NewsPicture"].ToString();
                txtkeywordsContent.Text = HtmlTo(reader["keywordsContent"].ToString());

                getkeywordsCategory(); 

                btnReset.CausesValidation = false;//“不更新”按钮不验证
            }
            conn.Close();
        }
        hiddenFieldID.Value = getkeywordsCategoryID();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {

        string keywordsPicture = UploadPicture();//图片名
        if (keywordsPicture == "temp.jpg" && hiddenFieldPicture.Value != "temp.jpg" || keywordsPicture == "" && hiddenFieldPicture.Value != "") //如果没有上传新的的图片，并且修改前没有保存图片，则保存以前的图片名
        {
            keywordsPicture = hiddenFieldPicture.Value;
        }
      
        int isPass = (int)(Session["AdminGradeID"]) > 2 ? 0 : 1;//如果管理员的权限ID大于2则是录入员，需要审核；否则不需要审核
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string sqlString = "update keywords set keywordsCategoryID='" + Convert.ToInt32(hiddenFieldID.Value) + "', keywordsCategoryName='" + ddlkeywordsCategoryName.Text + "', keywordsTitle='" + txtkeywordsTitle.Text
            + "', keywordsAuthor='" + txtkeywordsAuthor.Text + "', keywordsPicture='" + keywordsPicture + "',keywordsContent='" + ToHtml(txtkeywordsContent.Text) + "',  CreatorID='" + (int)(Session["AdminID"])
            + "', CreatedDateTime='" + DateTime.Now + "', IsPass='" + isPass
            + "' where keywordsID=" + Request.QueryString["id"];
        SqlCommand cmd = new SqlCommand(sqlString, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("~/Admin/keywordsEdit.aspx");
    }

    public string getkeywordsCategoryID()
    {
        string keywordsCategoryName = ddlkeywordsCategoryName.SelectedValue; 
        string keywordsCategoryID = "";

        SqlConnection connkeywordsCategory = new SqlConnection(connString);
        connkeywordsCategory.Open();
        SqlCommand cmdkeywordsCategory = new SqlCommand("select * from keywordsCategory where keywordsCategoryName ='" + keywordsCategoryName + "'", connkeywordsCategory);
        SqlDataReader readerkeywordsCategory = cmdkeywordsCategory.ExecuteReader();
        if (readerkeywordsCategory.Read())
        {
            keywordsCategoryID = readerkeywordsCategory["keywordsCategoryID"].ToString(); 
        }
        connkeywordsCategory.Close();
        return keywordsCategoryID;
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/keywordsEdit.aspx");
    }

    public void getkeywordsCategory()
    {
        
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlDataAdapter adapter = new SqlDataAdapter("Select * from NewsCategory", conn);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "tempNewsCategory");
        ddlkeywordsCategoryName.DataTextField = "NewsCategoryName"; 
        ddlkeywordsCategoryName.DataSource = ds.Tables[0].DefaultView;
        ddlkeywordsCategoryName.DataBind();
        conn.Close();
    }

    private string UploadPicture()
    {
        //上传新闻图片
        Boolean fileOK = false;  //文件类型符合要求标志，初始为不符合
        String path = Server.MapPath("~/Admin/UploadedImages/NewsPictures/");//服务器中保存新闻图片的路径
        if (fileUploadPicture.HasFile)   //检查FileUpload1控件中是否包含有文件
        {
            //获取客户端使用FileUpload控件上传的文件的扩展名，并改为小写
            String fileExtension = System.IO.Path.GetExtension(fileUploadPicture.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)   //根据文件扩展名检查文件类型
            {
                //检查要上传的文件是否为允许的图像文件类型
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }
        }
        string pictureName;//图片的名称
        if (fileOK)  //检查文件是否为允许上传的图像文件类型
        {
            //如果文件类型符合要求
            pictureName = fileUploadPicture.FileName;//图片文件名
            fileUploadPicture.PostedFile.SaveAs(path + fileUploadPicture.FileName);//上传文件
        }
        else
        {
            pictureName = "temp.jpg";//如果上传不成功，或者该新闻没有图片，则保存临时图片名
        }
        return pictureName;//返回上传的图片文件名
    }
    /// <summary>
    /// 把HTML标记替换掉。如果使用富文本框，则删掉
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string HtmlTo(string str)
    {
        str = str.Replace("&nbsp;", " ");
        str = str.Replace("<br />", "\n");
        str = str.Replace("<br />", "\r\n");
        str = str.Replace("&nbsp;&nbsp;", "\t");
        return str;
    }
    /// 将无格式的文本处理成带有html标记的文本。如果使用富文本框，则删掉
    /// </summary>
    /// <param name="mystr">要处理的文本</param>
    /// <returns>返回带换行等格式的文本</returns>
    public string ToHtml(string str)
    {
        str = str.Replace(" ", "&nbsp;");
        str = str.Replace("\n", "<br />");//录入时不需要键入\n
        str = str.Replace("\r\n", "<br />");
        str = str.Replace("\t", "&nbsp;&nbsp;");
        return str;
    }
}