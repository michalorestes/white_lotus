<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_Contact.aspx.cs" Inherits="WhiteLotus_mainCW.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 568px;
            
        }
        .auto-style3 {
            width: 89px;
        }
        .auto-style4 {
            width: 130px;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <h1>Conctact Details</h1>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">Name:</td>
                <td class="auto-style4">
                    <asp:Label ID="lb_name" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">Phone:</td>
                <td class="auto-style4">
                    <asp:Label ID="lb_phone" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_phone" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">E-mail:</td>
                <td class="auto-style4">
                    <asp:Label ID="lb_email" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_email" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">Address:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox1" runat="server" Height="77px" ReadOnly="True" TextMode="MultiLine" Width="166px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_address" runat="server"  Height="77px" TextMode="MultiLine" Width="166px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">Map Postcode</td>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btn_update" runat="server" OnClick="btn_update_Click" Text="Update" />
                </td>
            </tr>

        </table>



    </div>
</asp:Content>
