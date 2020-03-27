<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="keywordsEdit.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <div class="center-title">
            关键字：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="Button6" runat="server" Text="搜索" Width="83px" />
            &nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" Text="按发布日期" />
            &nbsp;<asp:Button ID="Button8" runat="server" Text="按发布者" />
            &nbsp;<asp:Button ID="Button9" runat="server" Text="按关键词类别" />
            &nbsp;<asp:Button ID="Button10" runat="server" Text="显示全部" Width="98px" />
        </div>
        <table border="1" class="t1">
            <tr>
                <th >
                    关键词标题（单击查看）
                </th>
                <th>
                    关键词类别
                </th>
                <th>
                    发布者
                </th>
                <th>
                    发布时间
                </th>
                <th>
                    编辑
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr class="line1">
                        <td>
                            <a href="..\keywordsShow.aspx?id=<%#Eval("NewsID") %>" target="_blank">
                                <%#Eval("keywordsTitle").ToString().Trim().Length > 24 ? Eval("keywordsTitle").ToString().Trim().Substring(0, 24) : Eval("keywordsTitle").ToString().Trim()%></a>
                        </td>
                        <td class="center">
                            <%#Eval("keywordsCategoryName") %>
                        </td>
                        <td class="center">
                            <%#Eval("keywordsAuthor") %>
                        </td>
                        <td class="center">
                            <%#Eval("CreatedDateTime") %>
                        </td>
                        <td class="center">
                            <a href='keywordsModify.aspx?id=<%#Eval("keywordsID") %>'>修改</a>&nbsp;
                            <asp:LinkButton ID="lbtnkeywordsDelete" CommandName='<%#Eval("keywordsID") %>' OnCommand="lbtnkeywordsDelete_Click"
                                OnClientClick="return confirm('确定要删除吗?');" runat="server">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="line2">
                        <td>
                            <a href="..\keywordsShow.aspx?id=<%#Eval("keywordsID") %>" target="_blank">
                                <%#Eval("keywordsTitle").ToString().Trim().Length > 24 ? Eval("keywordsTitle").ToString().Trim().Substring(0, 24) : Eval("keywordsTitle").ToString().Trim()%></a>
                        </td>
                        <td class="center">
                            <%#Eval("keywordsCategoryName") %>
                        </td>
                        <td class="center">
                            <%#Eval("keywordsAuthor") %>
                        </td>
                        <td class="center">
                            <%#Eval("CreatedDateTime") %>
                        </td>
                        <td class="center">
                            <a href='keywordsModify.aspx?id=<%#Eval("NewsID") %>'>修改</a>&nbsp;
                            <asp:LinkButton ID="lbnkeywordsDelete" CommandName='<%#Eval("keywordsID") %>' OnCommand="lbtnkeywordsDelete_Click"
                                OnClientClick="return confirm('确定要删除吗?');" runat="server">删除</asp:LinkButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
        <table border="0" cellspacing="0">
            <tr>
                <td class="style1">
                    <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">首页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">尾页</asp:LinkButton>&nbsp;
                    第 <asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
                    页 (共 <asp:Label ID="LabCountPage" runat="server" Text="Label"></asp:Label> 页)
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
