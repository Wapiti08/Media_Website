﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="keywordsModify.aspx.cs" Inherits="Admin_keywordsModify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <table width="99%" border="0" cellspacing="2" cellpadding="0" class="t2">
            <tr>
                <th colspan="2">
                    修改关键词
                </th>
            </tr>
            <tr>
                <td class="style1">
                   关键词分类：
                </td>
                <td class="tdleft">
                    <asp:DropDownList ID="ddlkeywordsCategoryName" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    关键词标题：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtkeywordsTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewsTitle"
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
                    关键词内容：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtkeywordsContent" runat="server" Height="209px" TextMode="MultiLine"
                        Width="663px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="center" colspan="2">
                    <asp:Button ID="btnOK" runat="server" Text="更新" CssClass="button" OnClick="btnOK_Click"
                        Width="66px" />
                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="不更新" CssClass="button" OnClick="btnReset_Click"
                        Width="66px" />
                </td>
            </tr>
            <tr>
                <td class="center" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="hiddenFieldID" runat="server" /><asp:HiddenField ID="hiddenFieldPicture" runat="server" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
