<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="WhiteLotus_mainCW.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 1170px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="wrapper">
        <div id="AdminPanel_OptionsList">
            <table class="auto-style1"> 
                <tr>
                    <td><img src="images/manageSession.jpg" /></td>
                    <td><img src="images/addSession.jpg" /></td>
                    <td><img src="images/forumPosts.png" /></td>
                    <td><img src="images/instructors.jpg" /></td>
                    <td><img src="images/contact.jpg" /></td>
                    
                </tr>

                <tr>
                    <td><a href="Admin_manageSession.aspx">Manage Sessions</a></td>
                    <td><a href="Admin_AddSession.aspx">Add Session</a></td>
                    <td><a href="Admin_ForumManagement.aspx">Forum</a></td>
                    <td><a href="Admin_Instructors.aspx">Instructors</a></td>
                    <td><a href="Admin_Contact.aspx">Contact</a></td>
                    
                </tr>

            </table>
        </div><!-- end of admin panel options -->
    </div><!-- end of wrapper -->






</asp:Content>
