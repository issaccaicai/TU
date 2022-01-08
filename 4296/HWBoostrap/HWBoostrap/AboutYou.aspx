<%@ Page Title="" Language="C#" MasterPageFile="~/web.Master" AutoEventWireup="true" CodeBehind="AboutYou.aspx.cs" Inherits="HWBoostrap.AboutYou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <h1>About You</h1>

        <div class="column33">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" AssociatedControlID="txtFirstName"></asp:Label>
            <br />
            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="**Please Enter Your First Name**" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
        <br />
            <asp:Label ID="lblLastName" AssociatedControlID="txtLastName" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="**Please Enter Your Last Name**" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
       
        <br />
        <asp:Label ID="lblAddress" runat="server" Text="Address" AssociatedControlID="txtAddress"></asp:Label>
        <br />
        <asp:TextBox ID="txtAddress" runat="server" placeholder="Address"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="**Please Enter Your Address**" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
            <br />
    <br /><br /><br /><br /><br /><br />
            </div>
        <div class="column33">
            <asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="txtCity"></asp:Label>
            <br />
            <asp:TextBox ID="txtCity" runat="server" placeholder="City"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="**Please Enter Your City**" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
        
        <br />
        
            <asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="txtState"></asp:Label>
            <br />
            <asp:TextBox ID="txtState" runat="server" placeholder="State"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="**Please Enter Your State**" ControlToValidate="txtState"></asp:RequiredFieldValidator>
        <br />

                <asp:Label ID="lblZip" runat="server" Text="Zip Code" AssociatedControlID="txtZip"></asp:Label>
                <br />
                <asp:TextBox ID="txtZip" runat="server" placeholder="Zip Code"></asp:TextBox><br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="**Please Enter Your Zip Code**" ControlToValidate="txtZip"></asp:RequiredFieldValidator><br />
         <asp:RegularExpressionValidator ID="regexpcontactZipCode" runat="server" ControlToValidate="txtZip"
                                                        ValidationGroup="contactValidation" Display="Dynamic" ErrorMessage="**Should be 5 Digits**"
                                                        ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
        <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="**Please Enter Your Email Address**" ControlToValidate="txtEmail"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtEmail" ErrorMessage="Please enter corect email" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            </div>
        <div class="column33">
         <asp:Label ID="lblBirthdat" runat="server" Text="Birthday" AssociatedControlID="txtBirthday"></asp:Label>
        <br />
        <asp:TextBox ID="txtBirthday" runat="server" TextMode="DateTime" placeholder="Birthday"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="**Please Enter Your Birthday**" ControlToValidate="txtBirthday"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="birthdayValidator" ControlToValidate="txtBirthday" OnServerValidate="ValidateDate" runat="server" ErrorMessage="**Please Enter A Correct Format. dd/mm/yyyy**"></asp:CustomValidator>
            <br />
            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number" AssociatedControlID="txtPhoneNumber"></asp:Label>
            <br />
            <asp:TextBox ID="txtPhoneNumber" runat="server" TextMode="Phone" placeholder="Phone Number"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="**Please Enter Your Phone Number**" ControlToValidate="txtPhoneNumber" ></asp:RequiredFieldValidator><br />
       <asp:RegularExpressionValidator ID="regPhone" runat="server" ControlToValidate="txtPhoneNumber" ValidationExpression="^(\(?\s*\d{3}\s*[\)\-\.]?\s*)?[2-9]\d{2}\s*[\-\.]\s*\d{4}$"
           Text="Enter a valid phone number" /> 
   
        <br />
        <asp:Label ID="lblComments" runat="server" Text="Comments/Qs:"></asp:Label>
        <br />
        <asp:TextBox ID="txtComments" TextMode="MultiLine" runat="server" Height="107px" Width="279px"></asp:TextBox>
            <br />
            <br />
            <br />
    </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class ="container">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#FF6666" BorderColor="Black" Height="50px" Width="150px" OnClick="btnSubmit_Click" />

    <br />
    <asp:Label ID="lblValidation" runat="server"></asp:Label>
</div>


</asp:Content>
