<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QueuePage.aspx.cs" Inherits="WhiteLotus_mainCW.QueuePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
        <h1>Session is full</h1>
        <p>This session is currently full. <br /> 
            Would like to be added to a waiting list? <br />
            As soon as someone cancels his/her reservation you will be added to this session. 
        </p>
    </div>
</asp:Content>
