using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加引用
using System.Configuration;//添加引用
using System.Data.SqlClient;//添加引用


public partial class Admin_Default2 : System.Web.UI.Page
{
    

    public string connString = ConfigurationManager.ConnectionStrings["connStr"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则定向到后台登录页
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");  //定向到后台登录页
        }
        
        if (!IsPostBack)
        {
            Session["userFromHomeNews"] = 1;
            this.labPage.Text = "1"; //初始从第1页开始显示
            this.keywordsRepeater();  //调用分页程序
        }
    }

    public void keywordsRepeater()
    {  //分页程序
        SqlConnection conn = new SqlConnection(connString);
        string sqlString = "select * from keywords order by keywordsID desc"; 
        conn.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(sqlString, conn);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "TempkeywordsView");

        //分页
        PagedDataSource pds = new PagedDataSource();  //创建分页对象pds
        pds.DataSource = ds.Tables["TempNewsView"].DefaultView;
        pds.AllowPaging = true;
        pds.PageSize = 15;  //每页显示15条
        pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;  //当前页
        Repeater1.DataSource = pds;
        LabCountPage.Text = pds.PageCount.ToString();  // 共LabCountPage.Text页
        labPage.Text = (pds.CurrentPageIndex + 1).ToString();  //当前是 第labPage.Text页
        this.lbtnFirstPage.Enabled = true;  //首页LinkButton ID="lbtnFirstPage"
        this.lbtnpritPage.Enabled = true;  //上一页LinkButton ID="lbtnpritPage"
        this.lbtnNextPage.Enabled = true;  //下一页LinkButton ID="lbtnNextPage"
        this.lbtnDownPage.Enabled = true;  //尾页LinkButton ID="lbtnDownPage"
        if (pds.CurrentPageIndex < 1)  //如果当前位于第1页
        {
            this.lbtnpritPage.Enabled = false;  //第1页LinkButton 不可用
            this.lbtnFirstPage.Enabled = false;  //首页不可用
        }
        if (pds.CurrentPageIndex == pds.PageCount - 1)  //如果当前位于最后一页
        {
            this.lbtnNextPage.Enabled = false;  //下一页不可用
            this.lbtnDownPage.Enabled = false;  //尾页不可用
        }
        Repeater1.DataBind();
        conn.Close();
    }

    protected void lbtnpritPage_Click(object sender, EventArgs e)
    {  //上一页按钮
        this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) - 1);
        this.keywordsRepeater();
    }
    protected void lbtnFirstPage_Click(object sender, EventArgs e)
    {  //首页
        this.labPage.Text = "1";
        this.keywordsRepeater();
    }
    protected void lbtnDownPage_Click(object sender, EventArgs e)
    {  //尾页
        this.labPage.Text = this.LabCountPage.Text;
        this.keywordsRepeater();
    }

    protected void lbtnNextPage_Click(object sender, EventArgs e)
    {  //下一页
        this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) + 1);
        this.keywordsRepeater();
    }

    protected void lbtnkeywordsDelete_Click(object sender, CommandEventArgs e)
    {  //删除
        int ID = Convert.ToInt32(e.CommandName);  //CommandName='<%#Eval("keywordsID") %>'
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string sqlString = "delete from keywords where keywordsID=" + ID;
        SqlCommand cmd = new SqlCommand(sqlString, conn);
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect("~/Admin/keywordsEdit.aspx");
    }
}
