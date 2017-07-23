<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_AddSession.aspx.cs" Inherits="WhiteLotus_mainCW.Admin_AddSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-left: 0px;
            margin-top: 0px;
        }
        .auto-style3 {
            margin-right: 0px;
        }
        .auto-style4 {
            margin-left: 25px;
        }
        .auto-style5 {
            height: 36px;
        }
        .auto-style6 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="wrapper">  
    
<h1>Add a session</h1>

            <div class="pageTopControls">
            <span>
                <asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CausesValidation="False"></asp:button>              
            </span>
            </div>

            <div id="regMainCont">
               

                <table>
                    <colgroup>
                        <col class="lablesSession" />
                        <col class="controlsSession" />
                    </colgroup>

                    <tbody>

                        <tr>
                            <td>Type:</td>
                            <td>
                                <asp:DropDownList ID="ddl_type" runat="server" Height="18px" Width="150px" CssClass="auto-style3" AutoPostBack="True" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged">
                                    <asp:ListItem>Class</asp:ListItem>
                                    <asp:ListItem>Workshop</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Title: 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_title" ErrorMessage="**" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_title" runat="server" TextMode="Time" Width="300px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="toppedItem">Description:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_description" ErrorMessage="**" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_description" runat="server" Height="63px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style6">Style:</td>
                            <td class="auto-style6">
                                <asp:DropDownList ID="ddl_style" runat="server" Width="150px" AutoPostBack="True" Height="18px" OnSelectedIndexChanged="ddl_instructor_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Anusara</asp:ListItem>
                                    <asp:ListItem>Bikram</asp:ListItem>
                                    <asp:ListItem>Hatha</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>Level:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdb_level" ErrorMessage="**" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdb_level" runat="server" CssClass="auto-style2" RepeatDirection="Horizontal">
                                    <asp:ListItem>Beginner</asp:ListItem>
                                    <asp:ListItem>Intermidiate</asp:ListItem>
                                    <asp:ListItem>Advanced</asp:ListItem>
                                </asp:RadioButtonList>

                            </td>
                        </tr>

                        <tr>
                            <td>Instructor:</td>
                            <td>
                                <asp:DropDownList ID="ddl_instructor" runat="server" Height="18px" Width="150px">
                                    <asp:ListItem>Select instructor first</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>Capacity:</td>
                            <td>
                                <asp:DropDownList ID="ddl_capacity" runat="server" Height="18px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>Room:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_room" ErrorMessage="**" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_room" runat="server" Width="145px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                    </tbody>



                </table>
                
        
    
            </div><!-- end of regMainCont -->
          
        <div id="sessionSideCont">
            <table class="sideTable">
                    <colgroup>
                        <col class="lablesSession" />
                        <col class="controlsSession" />
                    </colgroup>

                    <tbody>

                        <tr>
                            <td class="toppedItem">Date:</td>
                            <td id="calendar">
                                <asp:Calendar ID="myCalendar" runat="server" CssClass="auto-style2" BackColor="White" BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" CellPadding="4" DayNameFormat="Shortest">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr id="classSession" runat="server">
                            <td>Repeat for (wks):</td>
                            <td>
                                <asp:DropDownList ID="ddl_repeatWks" runat="server" Height="18px">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>

                        <tr>
                            <td>Time (HH:MM):</td>
                            <td>
                                <asp:DropDownList ID="ddl_timeH" runat="server">
                                </asp:DropDownList>
                                    &nbsp;<b>:</b>&nbsp;
                                <asp:DropDownList ID="ddl_timeM" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>




                        <tr>
                            <td class="auto-style5">Duration(min):</td>
                            <td class="auto-style5">
                                <asp:DropDownList ID="ddl_duration" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>




                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="lb_exceptionCatch" runat="server" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>




                    </tbody>



                </table>



        </div><!-- end of side container --> 
            <div>
                <asp:Button ID="Button1" runat="server" Text="Add Session" CssClass="auto-style4" OnClick="addSession" /></div>
            
    </div><!--Wrapper end -->






</asp:Content>
