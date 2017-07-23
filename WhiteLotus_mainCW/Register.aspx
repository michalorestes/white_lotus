<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WhiteLotus_mainCW.Reegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    .auto-style2 {
        height: 30px;
    }
    .auto-style3 {
        height: 35px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="wrapper">  
    
            <h1>Register</h1>
            <div id="regMainCont">
                

                <table>
                    <colgroup>
                        <col class="lables" />
                        <col class="controls" />
                
                     </colgroup>  
            
                    <tbody>
                        <tr>
                            <td>Name:*</td>
                            <td><asp:TextBox ID="txt_name" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="White" ControlToValidate="txt_name" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                
                
                        <tr>
                            <td>Date of Birth (DD/MM/YYYY):* </td>
                            <td><asp:TextBox ID="txt_dobDay" runat="server" Width="60px" MaxLength="2" TextMode="Number" ToolTip="Day"></asp:TextBox>
                                <asp:TextBox ID="txt_dobMonth" runat="server" Width="60px" MaxLength="2" TextMode="Number" ToolTip="Month"></asp:TextBox>
                                <asp:TextBox ID="txt_dobYear" runat="server" Width="60px" MaxLength="4" TextMode="Number" ToolTip="Year"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dobYear" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                
                        <tr>
                            <td class="auto-style2">Yoga Experience:* </td>
                            <td class="auto-style2"><asp:DropDownList ID="ddl_yogaExperience" runat="server" Width="200px">
                                <asp:ListItem>Beginner</asp:ListItem>
                                <asp:ListItem>Intermediate</asp:ListItem>
                                <asp:ListItem>Advanced</asp:ListItem>
                                </asp:DropDownList>&nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="ddl_yogaExperience"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>Health issues:*</td>
                            <td>
                                <asp:TextBox ID="txt_healthIssues" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_healthIssues"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>E-mail:* </td>
                            <td>
                                <asp:TextBox ID="txt_email" runat="server" Width="200px" TextMode="Email"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_email"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Password:* </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_password" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_password"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Re-type password:*</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_passwordConfirm" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required Field" ForeColor="Red" ControlToValidate="txt_password"></asp:RequiredFieldValidator>
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
                            <td><asp:CheckBox ID="chb_terms" runat="server" Text=" Accept Terms and Conditions" /></td>
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
        
    <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click" CausesValidation="False" />
                                &nbsp;<asp:Button ID="btn_register" runat="server" Text="Register" OnClick="Button2_Click" />
                
        
    
            </div><!-- end of regMainCont -->
          
        <div id="regSideCont">
            <img src="images/poses.png" />
        </div><!-- end of side container --> 
            
            
    </div><!--Wrapper end -->
        


    



</asp:Content>
