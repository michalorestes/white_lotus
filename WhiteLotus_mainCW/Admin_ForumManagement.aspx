<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_ForumManagement.aspx.cs" Inherits="WhiteLotus_mainCW.Admin_ForumManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper"> 
        
         
        <h1>Forum Categories</h1>
        <div class="pageTopControls">
            <span>
                <asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>
               
                &nbsp;<asp:Button ID="btn_deleteCategory" runat="server" Text="Delete Category" OnClick="btn_deleteCategory_Click" /> 

            &nbsp;<asp:TextBox ID="txt_categoryTitle" runat="server">Type category title</asp:TextBox>
&nbsp;<asp:TextBox ID="txt_description" runat="server" Width="151px">Type your descirption</asp:TextBox>
&nbsp;<asp:Button ID="btn_addCategory" runat="server" Text="Add Category" OnClick="btn_addCategory_Click" />

            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

            </span>
        </div>
            <div id="listOfCategories">

                

                
                
               
                <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style1" Height="384px" Width="779px"></asp:ListBox>

                

                
                
               
            </div><!-- end of listOfCategories -->
          
        
            
            
    </div><!--Wrapper end -->
</asp:Content>
