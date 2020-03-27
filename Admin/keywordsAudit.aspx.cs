using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加引用
using System.Configuration;//添加引用
using System.Data.SqlClient;//添加引用


public partial class Admin_keywordsAudit : System.Web.UI.Page
{
    //新闻管理

    public string connString = ConfigurationManager.ConnectionStrings["connStr"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则定向到后台登录页
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");  //定向到后台登录页
        }

        if (!IsPostBack)
        {
            Session["userFromHomeNews"] = 1;//设置是从HomeNews.aspx执行来的
            //设置排序初始状态，因为下面的 showAllUsers()方法，需要用到状态值
            GridView1.Attributes.Add("SortExpression", "CreatedDateTime");//初始按发布日期后先顺序
            GridView1.Attributes.Add("SortDirection", "DESC"); //按从大(新)到小(以前)的倒序排序
            showAllkeywords();//调用绑定数据源到GridView的过程

        }
    }



    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression.ToString();//从事件参数获取排序数据列
        string sortDirection = "DESC";//设置排序方向为按从大到小的正序排列
        //默认排序ASC与事件参数获取到的排序方向比较，然后修改GridView排序方向参数
        if (sortExpression == this.GridView1.Attributes["SortExpression"])
        {
            sortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == sortDirection ? "ASC" : "DESC");//获得下一次的排序状态
        }
        //重新设定GridView排序数据列及排序方向
        GridView1.Attributes["SortExpression"] = sortExpression;
        GridView1.Attributes["SortDirection"] = sortDirection;
        showAllkeywords();//绑定GridView的过程

    }

    private void showAllkeywords()
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string sqlString = "select keywordsID, keywordsTitle, keywordsCategoryName, keywordsAuthor, CreatedDateTime, IsPass from keywords order by keywordsID desc"; 
        SqlDataAdapter adapter = new SqlDataAdapter(sqlString, conn);
        DataTable table = new DataTable();
        adapter.Fill(table);
        // 获取GridView排序数据列及排序方向
        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];
        // 根据GridView排序数据列及排序方向设置显示的默认数据视图
        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        {
            table.DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        }
        GridView1.DataKeyNames = new string[] { "NewsID" };//GridView控件的主键名，更新、删除事件必须设置
        // GridView绑定并显示数据
        GridView1.DataSource = table;
        GridView1.DataBind();
        conn.Close();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //分页,选择新行时触发
        GridView1.PageIndex = e.NewPageIndex; //当前页的索引
        showAllkeywords();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int keywordsID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);//
        bool isPass = bool.Parse(((CheckBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Checked.ToString().Trim());
        //bool isPass = Convert.ToBoolean(((CheckBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Checked.ToString().Trim());
        SqlConnection conn = new SqlConnection(connString);
        string sqlString = "update keywords set IsPass='" + isPass + "' where keywordsID=" + keywordsID;
        conn.Open();
        SqlCommand cmd = new SqlCommand(sqlString, conn);
        cmd.ExecuteNonQuery();
        GridView1.EditIndex = -1;//执行更新
        showAllkeywords();
        conn.Close();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; //编辑按钮的事件
        showAllkeywords();
    }


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1; //取消编辑
        showAllkeywords();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        conn.Open();
        string sqlString = "delete from keywords where keywordsID='" +
             Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value) + "'";//=' "  Value) + " ' "
        SqlCommand cmd = new SqlCommand(sqlString, conn);
        cmd.ExecuteNonQuery();
        showAllkeywords();
        conn.Close();
    }

}
