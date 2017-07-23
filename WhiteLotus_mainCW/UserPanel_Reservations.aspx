<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserPanel_Reservations.aspx.cs" Inherits="WhiteLotus_mainCW.UerPanel_Reservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 925px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper">

        <div class="leftAlignContainer">
            <h1>My Bookings</h1>

            <table id="userReservationTable" class="auto-style1" runat="server" >
                <tr> 
                    <th>Reservation Date</th>
                    <th>Session Type</th>
                    <th>Resserved Session</th>
                    <th>Session On</th>
                    <th>Session Status</th>
                    <th>Action</th>

                </tr>
            </table>


            
        </div>




        <div class="rightAlignContainer">
            <h1>Waiting List</h1>
           <div id="listOfreservations" runat="server" class="reservationList">
                
                

              
                
           </div><!-- list of reservation end -->
            

              
                
                
        </div>  <!-- end of rightAlignent container --> 



        




    </div><!-- end of wrapper -->



    
</asp:Content>
