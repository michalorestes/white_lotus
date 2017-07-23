<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_addInstructor.aspx.cs" Inherits="WhiteLotus_mainCW.Admin_addInstructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="wrapper">  
    
 <h1>Register an Instructor</h1>
            <div class="pageTopControls">
            <span>
                <asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>              
            </span>
            </div>
            <div id="regMainCont">
               

                <table>
                    <colgroup>
                        <col class="lables" />
                        <col class="controls" />
                
                     </colgroup>  
            
                    <tbody>
                        <tr>
                            <td>Name:*</td>
                            <td><asp:TextBox ID="txt_name" runat="server" Width="200px"></asp:TextBox>&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="White" ControlToValidate="txt_name" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                
                
                        <tr>
                            <td>Date of Birth (DD/MM/YYYY):* </td>
                            <td><asp:TextBox ID="txt_dobDay" runat="server" Width="60px" MaxLength="2" TextMode="Number" ToolTip="Day"></asp:TextBox>
                                <asp:TextBox ID="txt_dobMonth" runat="server" Width="60px" MaxLength="2" TextMode="Number" ToolTip="Month"></asp:TextBox>
                                <asp:TextBox ID="txt_dobYear" runat="server" Width="60px" MaxLength="4" TextMode="Number" ToolTip="Year"></asp:TextBox>
&nbsp;
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dobYear" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                
                        <tr>
                            <td class="auto-style2">Yoga styles:* </td>
                            <td class="auto-style2">
                                <asp:CheckBox ID="chb_Anusara" runat="server" Text="Anusara" />
                                <asp:CheckBox ID="chb_Bikram" runat="server" Text="Bikram" />
                                <asp:CheckBox ID="chb_Hatha" runat="server" Text="Hatha" />
&nbsp;
                                </td>
                        </tr>

                        <tr>
                            <td>Health issues:*</td>
                            <td>
                                <asp:TextBox ID="txt_healthIssues" runat="server" Width="200px"></asp:TextBox>
                            &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_healthIssues"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>E-mail:* </td>
                            <td>
                                <asp:TextBox ID="txt_email" runat="server" Width="200px" TextMode="Email"></asp:TextBox>
                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_email"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Password:* </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_password" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_password"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Re-type password:*</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_passwordConfirm" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
                            &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_password"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_password" ControlToValidate="txt_passwordConfirm" ErrorMessage="Passwords don't match" ForeColor="Red"></asp:CompareValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>Telephone No.*</td>
                            <td>
                                <asp:TextBox ID="txt_telNo" runat="server" Width="200px" TextMode="Number"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_telNo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                         <tr class="formCheckbox">
                            <td>&nbsp;</td>
                            <td>
                                <!-- empty  check box-->
                                <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td><!-- empty buttons --></td>
                            <td class="formControls">
                               
                            </td>
                        </tr>


                    </tbody>
                </table>
        
    <center><asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click" CausesValidation="False" />
                                &nbsp;<asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" /></center>
                
        
    
            </div><!-- end of regMainCont -->
          
        <div id="regSideCont">
            &nbsp;</div><!-- end of side container --> 
            
            
    </div><!--Wrapper end -->













</asp:Content>
