<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="keywordsCategory.aspx.cs" Inherits="Admin_keywordsCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 500px;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <asp:GridView ID="gridkeywordsCategory" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gridkeywordsCategory_PageIndexChanging"
            HorizontalAlign="Center" Width="294px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" onrowcancelingedit="gridkeywordsCategory_RowCancelingEdit" 
            onrowdeleting="gridkeywordsCategory_RowDeleting" 
            onrowediting="gridkeywordsCategory_RowEditing" 
            onrowupdating="gridkeywordsCategory_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="keywordsCategoryName" HeaderText="关键词类别名称" />
                <asp:BoundField DataField="keywordsCategorySort" HeaderText="显示顺序" />
                <asp:CommandField HeaderText="编辑删除" ShowDeleteButton="True" ShowEditButton="True"
                    ShowHeader="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <br />
        <div style="margin-left: 0px">
            <table width="360px" border="0" cellspacing="2" cellpadding="0" class="t2">
                <tr>
                    <th colspan="2">
                        添加关键词类别
                    </th>
                </tr>
                <tr>
                    <td class="tdright" style="color: #000000">
                        关键词类别名称：
                    </td>
                    <td class="tdleft">
                        <asp:TextBox ID="txtkeywordsCategoryName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdright" style="color: #000000">
                        显示顺序：
                    </td>
                    <td class="tdleft">
                        <asp:TextBox ID="txtkeywordsCategorySort" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnOK" runat="server" Text="添加" OnClick="btnOK_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
