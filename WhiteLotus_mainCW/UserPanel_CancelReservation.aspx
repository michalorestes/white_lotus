<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserPanel_CancelReservation.aspx.cs" Inherits="WhiteLotus_mainCW.UserPanel_CancelReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper">
        
        <h1><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h1>
        <table>
        <colgroup>
                                        
                <col class="lables" />
                        
                <col class="controls" />

            </colgroup>
            <tbody>
                
                    <tr>
                    <td class="auto-style1">Session Title: </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

                        </td>
                    </tr>
                
                

                <tr>
                    <td class="auto-style1">Date:</td>
                    <td><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>&nbsp;

                    </td>
                
                </tr>

                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" /> &nbsp;<asp:Button ID="btn_confirm" runat="server" Text="Confirm" OnClick="btn_confirm_Click" /></td>
                
                </tr>

               

            </tbody>
            
            
        </table>

    </div>



</asp:Content>
