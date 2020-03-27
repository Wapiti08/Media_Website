<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"  CodeFile="keywordsAddFckeditor.aspx.cs" Inherits="Admin_keywordsAddFckeditor" validateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content
        {
            /* clear: both;*/
            height: 650px; /*在此设置高度*/
            overflow: hidden; /*超出宽度部分隐藏*/
        }
        .style2
        {
            width: 79px;
        }
        .style3
        {
            width: 679px;
            text-align: left;
        }
        
        .style4
        {
            font-size: 14px;
            font-weight: bolder;
            color: blue;
            text-align: center;
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <table>
            <tr>
                <td colspan="2" class="style4">
                    添加关键词
                </td>
            </tr>
            <tr>
                <td class="style2">
                    关键词分类：
                </td>
                <td class="style3">
                    <asp:DropDownList ID="ddlkeywordsCategory" runat="server" CssClass="button">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    关键词标题：
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtkeywordsTitle" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtkeywordsTitle"
                        ErrorMessage="请输入标题" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    作者来源：
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtkeywordsAuthor" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtkeywordsAuthor"
                        ErrorMessage="请输入来源" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    关键词内容：
                </td>
                <td class="style3">
                    <FCKeditorV2:FCKeditor ID="fckkeywordsContent" runat="server" BasePath="~/FCKeditor/"
                        Height="470px" Width="650px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td class="td_center" colspan="2">
                    <asp:Button ID="btnOK" runat="server" Text="添加" CssClass="button" OnClick="btnOK_Click" />
                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" CssClass="button" OnClick="btnReset_Click" />
                </td>
            </tr>
            <tr>
                <td class="td_center" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
