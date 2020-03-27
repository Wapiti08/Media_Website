using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加


public partial class Admin_keywordsAddFckeditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则定向到后台登录页
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");  //定向到后台登录页
        }

        if (!IsPostBack)
        {
            ShowkeywordsCategory();
            btnReset.CausesValidation = false;//“重置”按钮不验证
        }
    }
    private void ShowkeywordsCategory()
    {

        
        string seleStr = "select keywordsCategoryID, keywordsCategoryName from keywordsCategory ORDER BY keywordsCategorySort";//显示全部记录
        DataSet ds = SqlHelper.GetDataSet(seleStr);
        ddlkeywordsCategory.DataSource = ds;
        ddlkeywordsCategory.DataTextField = "keywordsCategoryName";//显示字段
        ddlkeywordsCategory.DataValueField = "keywordsCategoryID";//值字段
        ddlkeywordsCategory.DataBind();
        ddlkeywordsCategory.SelectedIndex = 0;//默认选中第1个选项
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        int keywordsCategoryID = int.Parse(ddlkeywordsCategory.SelectedValue);
        string keywordsCategoryName = ddlkeywordsCategory.SelectedItem.Text;
        string keywordsTitle = txtkeywordsTitle.Text.Trim();
        string keywordsAuthor = txtkeywordsAuthor.Text.Trim();//作者、来源
        string keywordsPicture = "temp.jpg";//临时用图片名
        string keywordsContent = fckkeywordsContent.Value;
        int creatorID = (int)(Session["AdminID"]);//添加者
        DateTime createdDateTime = DateTime.Now;//系统时间
        int isPass = (int)(Session["AdminGradeID"]) > 2 ? 0 : 1;//如果管理员的权限ID大于2则是录入员，需要审核；否则不需要审核
        if (Addkeywords(keywordsCategoryID, keywordsCategoryName, keywordsTitle, keywordsAuthor, keywordsPicture, keywordsContent, creatorID, createdDateTime, isPass))
        {
            lblMsg.Text = "添加关键词成功！";
        }
        else
        {
            lblMsg.Text = "添加关键词失败！";
        }
        Resetkeywords();
    }

    private bool Addkeywords(int keywordsCategoryID, string keywordsCategoryName, string keywordsTitle,string keywordsAuthor, string keywordsPicture, string keywordsContent, int creatorID, DateTime createdDateTime, int isPass)
    {
        string sqlStr = "insert into keywords(keywordsCategoryID, keywordsCategoryName, keywordsTitle, keywordsAuthor, keywordsPicture, keywordsContent, CreatorID, CreatedDateTime, IsPass)";
        sqlStr += " values('"
            + keywordsCategoryID + "','"
            + keywordsCategoryName + "','"
            + keywordsTitle + "','"
            + keywordsAuthor + "','"
            + keywordsPicture + "','"
            + keywordsContent + "','"
            + creatorID + "','"
            + createdDateTime + "','"
            + isPass + "')";
        int result = SqlHelper.GetExecuteNonQuery(sqlStr);
        bool flag = false;
        if (result > 0)
        {
            flag = true;
        }
        return flag;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Resetkeywords();
    }
    private void Resetkeywords()
    {
        //初始化添加新闻框
        txtkeywordsTitle.Text = string.Empty;
        txtkeywordsAuthor.Text = string.Empty;
        fckkeywordsContent.Value = string.Empty;
        lblMsg.Text = string.Empty;
    }
}

