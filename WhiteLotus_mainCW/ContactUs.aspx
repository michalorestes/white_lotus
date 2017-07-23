<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="WhiteLotus_mainCW.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 241px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <h1>Contact Us</h1>
        <div class="right" id="map" runat="server">
            
        </div>

        <div class="left">
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">Name:</td>
                <td class="auto-style1">
                    <asp:Label ID="lb_name" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>

            <tr>
                <td class="auto-style3">Phone:</td>
                <td class="auto-style1">
                    <asp:Label ID="lb_phone" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>

            <tr>
                <td class="auto-style3">E-mail:</td>
                <td class="auto-style1">
                    <asp:Label ID="lb_email" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>

            <tr>
                <td class="auto-style3">Address:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox1" runat="server" Height="77px" ReadOnly="True" TextMode="MultiLine" Width="166px"></asp:TextBox>
                </td>
                
            </tr>

            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                
            </tr>

        </table>



        </div>

    </div>
</asp:Content>
