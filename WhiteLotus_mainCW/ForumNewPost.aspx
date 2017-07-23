<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForumNewPost.aspx.cs" Inherits="WhiteLotus_mainCW.ForumNewPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 770px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <h1>Add a new post</h1>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>Title: </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="800px"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>Message:</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Height="412px" TextMode="MultiLine" Width="800px"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Button ID="btn_add" runat="server" CssClass="auto-style1" Text="Add" OnClick="btn_add_Click" />
        </p>


    </div>
</asp:Content>
