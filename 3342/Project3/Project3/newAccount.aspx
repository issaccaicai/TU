<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newAccount.aspx.cs" Inherits="Project3.newAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>    
    header  {
       text-align:center;
       font-size:40px;
       background-color:lavender;
    }

    #btn {
        background-color:antiquewhite;
        padding-left:20px;
        text-align: center;
    }
    body{
        background-color:aquamarine;
    }
</style>

</head>
<body>
    <header>Creating an account</header>
    <form id="form1" runat="server">
        <div id="btn">
            <br /><br />
            <br /><br />
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="257px"></asp:TextBox>
            <asp:Label ID="lblInvail" runat="server" Text=""></asp:Label>




            <br /><br />


            <asp:RadioButton ID="selectReviewer" runat="server" Text="Reviewer" GroupName="Creating" AutoPostBack="false" Checked="true" />
            <br />
            <asp:RadioButton ID="selectReresentative" runat="server" Text="Reresentative" GroupName="Creating" AutoPostBack="false" Checked="false" />

            <br /><br />
            <asp:Button ID="btnSignUp" runat="server" Text="Sign up" OnClick="btnSubmit_Click" />&nbsp;
            <br />




            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back to login page" OnClick="btnBack_Click" />




            <br />
            <br />
            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>




            <br />




            <br />
            <br />




        </div>
    </form>
</body>
</html>
