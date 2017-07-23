<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Workshops.aspx.cs" Inherits="WhiteLotus_mainCW.Workshops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div runat="server" class="wrapper" id="extraThing">
        

        <h1>List of workshops</h1>
        <!-- Classes view  -->
            <div class="leftAlignContainer">

                <table class="sessions" id="sessionsTable" runat="server">
                    <tr>
                        <th class="seImg"></th>
                        <th class="seCont"></th>
                        <th class="seInfo"></th>
                        <th class="seBtn"></th>
                    </tr>
                 
                </table>

            </div>
        
        <div class ="rightAlignContainer">

            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" CssClass="auto-style1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged" style="margin-left: 0px; margin-right: 0px;">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <asp:Button ID="btn_showAll" runat="server" Text="Show all" OnClick="btn_showAll_Click" Width="200px" />
        </div>

       
    </div><!-- end of wrapper --> 

</asp:Content>
