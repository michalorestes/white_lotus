<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForumMessages.aspx.cs" Inherits="WhiteLotus_mainCW.ForumMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">

        <table runat="server" id="ForumTableMessages" class="forumTableMessages">
            <tr>
                <th class="userInfo"></th>
                <th class="messageInfo"></th>
            </tr>

            


        </table>

        <div id="replyContainer">

            <div class="reply">Reply</div>
            
            <div class="leftAlignContainer">
                <asp:TextBox ID="TextBox1" runat="server" Height="164px" TextMode="MultiLine" Width="971px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
             
            <div class="rightAlignContainer">
                <asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="auto-style1" OnClick="btn_clear_Click" />
            &nbsp;<asp:Button ID="btn_reply" runat="server" Text="Reply" Width="100px" OnClick="btn_reply_Click" />
            </div>
            
        </div>

    </div>


</asp:Content>
