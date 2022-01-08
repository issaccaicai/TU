<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HWBoostrap.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 style="align-content:center">&nbsp;</h1>
        <h1 style="align-content:center">Login Page</h1>
    <div class="container">
        <asp:Label ID="lblFirstName" runat="server" Text="First Name: " AssociatedControlID="txtFirstName"></asp:Label>
        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="First Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" **Please Enter your FirstName** " ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
    </div>

     <div class="container">
        <asp:Label ID="lblLastName" runat="server" Text="Last Name: " AssociatedControlID="txtLastName"></asp:Label>
        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" **Please Enter your Lastname** " ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
    </div>

    <div class="container">
        <asp:Label ID="lblPassword" runat="server" Text="Password :" AssociatedControlID="txtPassword"></asp:Label>
        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" **Please enter password** " ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
    </div>
        <asp:CheckBox ID="chkRemember" checked="true" Text="Remember me" runat="server" style="float:left;" />
        </div>
        <div style="width:auto; text-align:center">
            
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#FF6666" BorderColor="Black" Height="50px" Width="150px" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
