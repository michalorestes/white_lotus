<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForumPosts.aspx.cs" Inherits="WhiteLotus_mainCW.ForumPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        

        <div style="float:right">
            <asp:Button ID="btn_newPost" runat="server" Text="New Post" OnClick="btn_newPost_Click" /> <br />
            <br />
        </div>
        <table runat="server" id="ForumCategoriesTable" class="forumTableMain">

            <tr>
                <th class="icon"> </th>
                <th class="catName">Post Name</th>
                <th class="noMessages">Messages</th>
            </tr>

            

        </table>
        <div style="float:right"> <br />
            <asp:Button ID="btn_newPost2" runat="server" Text="New Post" OnClick="btn_newPost_Click" /></div>
    </div>
</asp:Content>
