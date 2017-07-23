<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForumCategories.aspx.cs" Inherits="WhiteLotus_mainCW.ForumCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper">
        <table runat="server" id="ForumCategoriesTable" class="forumTableMain">

            <tr>
                <th class="icon"> </th>
                <th class="catName">Category Name</th>
                <th class="noPosts">Posts</th>
                <th class="noMessages">Messages</th>
            </tr>

            

        </table>
    </div>




</asp:Content>
