<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReservationPage.aspx.cs" Inherits="WhiteLotus_mainCW.ReservationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 109px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="wrapper">
        <h1 id="BookingMessage" runat="server"></h1>
        <table>
            <colgroup>
                                        
                <col class="lables" />
                        
                <col class="controls" />

            </colgroup>
            <tbody>
                
                    <tr>
                    <td class="auto-style1">Session Title: </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                    </tr>

                <tr>
                    <td class="auto-style1">Date:</td>
                    <td><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                
                </tr>

                <tr>
                    <td class="auto-style1">Time: </td>
                    <td><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                
                </tr>

               

                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="Cancel" />

                        <asp:Button ID="btn_confirmBooking" runat="server" OnClick="btn_confirmBooking_Click" Text="Confirm Booking" />
                    </td>
                
                </tr>

               

            </tbody>
            
            
        </table>


    </div>
</asp:Content>
