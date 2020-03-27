<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="keywordsAdd.aspx.cs" Inherits="keywordsAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <table width="100%" border="0" cellspacing="2" cellpadding="0" class="t2">
            <tr>
                <th colspan="2">
                    添加关键词
                </th>
            </tr>
            <tr>
                <td class="style2">
                    关键词分类：
                </td>
                <td class="style3">
                    <asp:DropDownList ID="ddlkeywordsCategory" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    关键词标题：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtkeywordsTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtkeywordsTitle"
                        ErrorMessage="必须有标题" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    作者来源：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtkeywordsAuthor" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtkeywordsAuthor"
                        ErrorMessage="必须有来源" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    新闻图片：
                </td>
                <td class="tdleft">
                    <asp:FileUpload ID="fileUploadPicture" runat="server" Width="250px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    新闻内容：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtkeywordsContent" runat="server" Height="229px" TextMode="MultiLine"
                        Width="680px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="center" colspan="2">
                    <asp:Button ID="btnOK" runat="server" Text="添加" CssClass="button" 
                        OnClick="btnOK_Click" Width="66px" />
                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" CssClass="button" 
                        OnClick="btnReset_Click" Width="66px" />
                </td>
            </tr>
            <tr>
                <td class="center" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
