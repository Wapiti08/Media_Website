using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加引用


public partial class Admin_keywordsCategory : System.Web.UI.Page
{
    static string selectString = "";
    //查询字符串，静态，用于在本页面共用。select语句的字符串要与其他删除、修改作用的字符串采用不同的变量

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则打开登录页
        {
            Response.Redirect("AdminLogin.aspx");  //去登录页面
        }
        if (!IsPostBack)
        {
            selectString = "select * from keywordsCategory ORDER BY keywordsCategorySort";//显示全部记录
            ShowkeywordsCategory(selectString);
        }
    }
    private void ShowkeywordsCategory(string seleStr)
    {
        DataSet ds = SqlHelper.GetDataSet(seleStr);

        gridkeywordsCategory.DataKeyNames = new string[] { "keywordsCategoryID" };//GridView控件的主键名
        gridkeywordsCategory.AllowPaging = true;//启用分页
        gridkeywordsCategory.AutoGenerateColumns = false;//不自己绑定字段
        gridkeywordsCategory.PageSize = 5;//每页显示的记录数
        gridkeywordsCategory.DataSource = ds;
        gridkeywordsCategory.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string sqlString = "insert into keywordsCategory(keywordsCategoryName, keywordsCategorySort)";
        sqlString += "values ('" + txtkeywordsCategoryName.Text.Trim() + "','" + txtkeywordsCategorySort.Text + "')";
        int i = SqlHelper.GetExecuteNonQuery(sqlString);
        if (i > 0)
        {
            lblMsg.Text = "关键词类别添加成功!";
            txtkeywordsCategoryName.Text = "";
            txtkeywordsCategorySort.Text = "";
            selectString = "select * from keywordsCategory ORDER BY keywordsCategorySort";//显示全部记录
            ShowkeywordsCategory(selectString);
        }
    }
    protected void gridkeywordsCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridkeywordsCategory.PageIndex = e.NewPageIndex;
        ShowkeywordsCategory(selectString);//显示给定条件的记录
    }
    protected void gridkeywordsCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlString = "delete from keywordsCategory  where keywordsCategoryID='" + Convert.ToInt32(gridkeywordsCategory.DataKeys[e.RowIndex].Value) + "'";//=' "  Value) + " ' "
        int i = SqlHelper.GetExecuteNonQuery(sqlString);
        ShowkeywordsCategory(selectString);//显示给定条件的记录
    }
    protected void gridkeywordsCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int keywordsCategoryID = Convert.ToInt32(gridkeywordsCategory.DataKeys[e.RowIndex].Value);
        string keywordsCategoryName = ((TextBox)gridkeywordsCategory.Rows[e.RowIndex].Cells[0].Controls[0]).Text;//第1列
        int keywordsCategorySort = Convert.ToInt32((((TextBox)gridkeywordsCategory.Rows[e.RowIndex].Cells[1].Controls[0]).Text));//第2列

        string sqlString = "update keywordsCategory set keywordsCategoryName='" + keywordsCategoryName;
        sqlString += "',keywordsCategorySort='" + keywordsCategorySort + "' where keywordsCategoryID=" + keywordsCategoryID;
        int i = SqlHelper.GetExecuteNonQuery(sqlString);

        gridkeywordsCategory.EditIndex = -1;//执行更新
        ShowkeywordsCategory(selectString);//显示给定条件的记录;

    }
    protected void gridkeywordsCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridkeywordsCategory.EditIndex = e.NewEditIndex; //编辑按钮的事件
        ShowkeywordsCategory(selectString);//显示给定条件的记录
    }
    protected void gridkeywordsCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridkeywordsCategory.EditIndex = -1; //取消编辑
        ShowkeywordsCategory(selectString);//显示给定条件的记录
    }
}
