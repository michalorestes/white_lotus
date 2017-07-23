<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_Instructors.aspx.cs" Inherits="WhiteLotus_mainCW.Admin_Instructors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="wrapper"> 
        
         
        <h1>Instructors</h1>
        <div class="pageTopControls">
            <span>
                <asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>
               
                <asp:Button ID="btn_addInstructor" runat="server" Text="Add new instructor" OnClick="btn_addInstructor_Click" /> 

            </span>
        </div>
            <div id="instructorsView">

                

                <asp:GridView ID="GridView2" CssClass="Grid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BorderStyle="Solid" BorderWidth="1px" style="margin-left: 0px">
                    
                    <AlternatingRowStyle BackColor="#E8E8E8" />
                    <Columns>
                        
                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="30" >                    
                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="DOB" HeaderText="DOB" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Yoga Experience" HeaderText="Yoga Experience" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Health Issues" HeaderText="Health Issues" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="E-mail" HeaderText="E-mail" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Telephone" HeaderText="Telephone" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Password" HeaderText="Password" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Type" HeaderText="Type" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Anusara" HeaderText="Anusara" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Bikram" HeaderText="Bikram" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Hatha" HeaderText="Hatha" ItemStyle-Width="150" >
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                                        <EditRowStyle HorizontalAlign="Center" />
                 
                    <HeaderStyle BackColor="#FFC939" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" />
                 
                </asp:GridView>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div><!-- end of regMainCont -->
          
        
            
            
    </div><!--Wrapper end -->




</asp:Content>
