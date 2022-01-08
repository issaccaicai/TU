<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="APITest.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    body {
     background-image: url('img/AmazonBackground.jpg');
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
    }
        </style>

<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" />    
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
</head>
<body>
    <div style="text-align: center;"">
    <img src="img/login.png" alt="amazon.com" style="width: 400px; height: 150px; ;"/>
        </div>    

    <div class="container">
    <div class="row">
        <div class="col-sm-6 col-md-4 col-md-offset-4">
            <div class="account-wall">
                            <h2 class="text-success" style="text-align:center;">Amazon User Login</h2>

                <img class="profile-img" src="https://cdn2.iconfinder.com/data/icons/flat-style-svg-icons-part-1/512/user_login_man-512.png"
                    alt="" />
    <form id="form1" runat="server" class="form-signin">
         <asp:Label ID="lblSignIn" class="float-right alert alert-success" runat="server" Text="Successfully" Visible="false"></asp:Label>
        <br /><br />
         <div class="dropdown">
             <label>User Account type:</label>
                            <asp:DropDownList ID="ddlAccountType" runat="server" class="btn btn-success dropdown-toggle">
                                <asp:ListItem Value="customer" Selected="True">Customer</asp:ListItem>
                                <asp:ListItem Value="merchant">Merchant</asp:ListItem>
                            </asp:DropDownList>
             </div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br /><br />
        <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
         <asp:TextBox id="txtUserName" runat="server" class="form-control" placeholder="Email" required="true" autofocus="true"></asp:TextBox>
        </div>

        <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                <asp:TextBox id="txtPassword" runat="server" class="form-control" placeholder="Password" required="true"></asp:TextBox>
            </div>
                <asp:Button id="btnSignIn" runat="server" class="btn btn-lg btn-success btn-block" text="Sign in" OnClick="btnSignIn_Click"></asp:Button>
                <label class="checkbox pull-left">
                    <asp:CheckBox ID="chkRemember" runat="server" Text="Remember me" />
                </label>
<%--                <a href="ForgotPassword.aspx" class="pull-right need-help">Forgot Password? </a><span class="clearfix"></span>--%>
                            <asp:LinkButton ID="lbForgotPassword" class="pull-right need-help" runat="server" OnClick="lbForgotPassword_Click">Forgot your password?</asp:LinkButton><span class="clearfix"></span>



        <br/>
            <h5 style="text-align:center">New to Amazon?</h5>
        <hr/>
                

         <a href="CustomerRegistration.aspx" class="text-center new-account">Create A Customer Account </a>
            <a href="MerchantRegistration.aspx" class="text-center new-account">Create A Merchant Account </a>
        <br/><br/>
          <center>
        <asp:Label ID="lblINfo" runat="server" Text="Test Customer Account: Login: c; Password: c;"></asp:Label>
    </center>
        <br/>
	<center>
        <asp:Label ID="lblInfo2" runat="server" Text="Test Merchant Account: Login: sadsa; Password: a;"></asp:Label>
    </center>
            
</form>

 </div>
           
        </div>
    </div>
</div>
	
  
</body>
</html>
