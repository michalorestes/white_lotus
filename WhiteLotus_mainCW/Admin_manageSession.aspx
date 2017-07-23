<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_manageSession.aspx.cs" Inherits="WhiteLotus_mainCW.Admin_manageSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="wrapper"> 
        
         
        <h1>Manage Sessions</h1>
        <div class="pageTopControls">
            <span>
                <asp:button id="back_Button" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>
                &nbsp;<asp:Button ID="btn_addSession" runat="server" OnClick="btn_addSession_Click" Text="Add Session" />
                &nbsp;<asp:Button ID="btn_deleteRecord" runat="server" OnClick="btn_deleteRecord_Click" Text="Delete Session" />
                &nbsp;<asp:Button ID="btn_status" runat="server" OnClick="btn_status_Click" Text="Change status" />
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Class</asp:ListItem>
                <asp:ListItem>Workshop</asp:ListItem>
            </asp:DropDownList>
               
            </span>
        </div>
            <div id="instructorsView">

                                
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" GridLines="Horizontal" CssClass="auto-style1" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    
                    <AlternatingRowStyle BackColor="#E8E8E8" />
                    <Columns>
                        
                        <asp:BoundField DataField="SessionID" HeaderText="Session ID" ItemStyle-Width="30" >                    
                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <%--<asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="150" >
                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>

                        <%-- Description column containing a scrollbar!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! --%>
                        <asp:TemplateField HeaderText="Body">
                        <ItemTemplate>
                            <div style="overflow:auto; height: 150px; width: 200px">
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description")%>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:BoundField DataField="Style" HeaderText="Style" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Level" HeaderText="Level" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Session Date" HeaderText="Session Date" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Duration" HeaderText="Duration (min)" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Capacity" HeaderText="Capacity" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Reservations" HeaderText="Reservations" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Room" HeaderText="Room" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Instructors" HeaderText="Instructor" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                    </Columns>
                                        <EditRowStyle HorizontalAlign="Center" />
                 
                    <HeaderStyle BackColor="#FFC939" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" />
                 
                    <SelectedRowStyle BackColor="#66CCFF" />
                 
                </asp:GridView>

                
                <br />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div><!-- end of regMainCont -->
          
        
            
            
    </div><!--Wrapper end -->










</asp:Content>
