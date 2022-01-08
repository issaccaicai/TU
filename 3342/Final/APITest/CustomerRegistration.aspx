<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="APITest.CustomerRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <style>
        .center {
            margin: auto;
            width: 70%;
            height: auto;
            border: 3px solid #73AD21;
            padding: 10px;
        }
        body {
    font-family: 'Raleway', sans-serif;
    background: #E9F8DF;
    -webkit-font-smoothing: antialiased;
   
}
    </style>

</head>


<body>
    <form id="form1" runat="server">
        
        <h1 style="text-align: center;">Customer Registration</h1>
        <br />
        <br />
        <div class="center">
            <div class="container register">
                <div class="row">

                    <div class="col-md-3 register-left">
                        <img src="img/logo.jpg" alt="" />
                        <div class="text-success">
                            <h3>Welcome to Customer Registration Page!</h3>

                        </div>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" style="color:forestgreen;" OnClick="btnLogin_Click"></asp:Button>
                        <br />
                    </div>

                    <div class="col-md-9 register-right">

                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                <h3 class="register-heading">Apply as a Customer</h3>
                                <div class="row register-form">
                                    <div class="col-md-6" style="text-align: left;">
                                        <div class="form-group">
                                            <br />
                                            <label>Full Name:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtFullName" class="form-control" placeholder="Full Name *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <br />
                                            <label>User Name:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtUserName" class="form-control" placeholder="User Name *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <br />
                                            <label>Password:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtPassword" class="form-control" placeholder="Password *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <br />
                                            <label>Confirm Password:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtConfirmPassword" class="form-control" placeholder="Confirm Password *" value="" />
                                        </div>

                                        <div class="form-group">
                                            <br />
                                            <label>Email:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Your Email *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <br />
                                            <label>Phone Number:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtPhone" minlength="10" MaxLength="10" class="form-control" placeholder="Your Phone *" value="" />
                                        </div>

                                        <div class="form-group">
                                            <br />
                                            <label>Address:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtAddress" class="form-control" placeholder="Address *" value="" />
                                        </div>

                                       

                                        <%-- <div class="form-group">
                                            <div class="maxl">
                                                <label class="radio inline"> 
                                                    <input type="radio" name="gender" value="male" checked />
                                                    <span> Male </span> 
                                                </label>
                                                <label class="radio inline"> 
                                                    <input type="radio" name="gender" value="female" />
                                                    <span>Female </span> 
                                                </label>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <br />
                                            <label>City:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtCity" class="form-control" placeholder="City *" value="" />
                                        </div>

                                        <div class="form-group"  style="text-align:left;">
                                            <br />
                                            <label>State:</label>
                                            <br />
                                            <asp:DropDownList ID="ddlState" runat="server" ForeColor="#e2be6f" Height="37px" Width="100%">
                                                <asp:ListItem>AK</asp:ListItem>
                                                <asp:ListItem>AL</asp:ListItem>
                                                <asp:ListItem>AR</asp:ListItem>
                                                <asp:ListItem>AZ</asp:ListItem>
                                                <asp:ListItem>CA</asp:ListItem>
                                                <asp:ListItem>CO</asp:ListItem>
                                                <asp:ListItem>CT</asp:ListItem>
                                                <asp:ListItem>DE</asp:ListItem>
                                                <asp:ListItem>FL</asp:ListItem>
                                                <asp:ListItem>GA</asp:ListItem>
                                                <asp:ListItem>HI</asp:ListItem>
                                                <asp:ListItem>IA</asp:ListItem>
                                                <asp:ListItem>ID</asp:ListItem>
                                                <asp:ListItem>IL</asp:ListItem>
                                                <asp:ListItem>IN</asp:ListItem>
                                                <asp:ListItem>KS</asp:ListItem>
                                                <asp:ListItem>KY</asp:ListItem>
                                                <asp:ListItem>LA</asp:ListItem>
                                                <asp:ListItem>MA</asp:ListItem>
                                                <asp:ListItem>MD</asp:ListItem>
                                                <asp:ListItem>ME</asp:ListItem>
                                                <asp:ListItem>MI</asp:ListItem>
                                                <asp:ListItem>MN</asp:ListItem>
                                                <asp:ListItem>MO</asp:ListItem>
                                                <asp:ListItem>MS</asp:ListItem>
                                                <asp:ListItem>MT</asp:ListItem>
                                                <asp:ListItem>NC</asp:ListItem>
                                                <asp:ListItem>ND</asp:ListItem>
                                                <asp:ListItem>NE</asp:ListItem>
                                                <asp:ListItem>NH</asp:ListItem>
                                                <asp:ListItem>NJ</asp:ListItem>
                                                <asp:ListItem>NM</asp:ListItem>
                                                <asp:ListItem>NV</asp:ListItem>
                                                <asp:ListItem>NY</asp:ListItem>
                                                <asp:ListItem>OH</asp:ListItem>
                                                <asp:ListItem>OK</asp:ListItem>
                                                <asp:ListItem>OR</asp:ListItem>
                                                <asp:ListItem>PA</asp:ListItem>
                                                <asp:ListItem>RI</asp:ListItem>
                                                <asp:ListItem>SC</asp:ListItem>
                                                <asp:ListItem>SD</asp:ListItem>
                                                <asp:ListItem>TN</asp:ListItem>
                                                <asp:ListItem>TX</asp:ListItem>
                                                <asp:ListItem>UT</asp:ListItem>
                                                <asp:ListItem>VA</asp:ListItem>
                                                <asp:ListItem>VT</asp:ListItem>
                                                <asp:ListItem>WA</asp:ListItem>
                                                <asp:ListItem>WI</asp:ListItem>
                                                <asp:ListItem>WV</asp:ListItem>
                                                <asp:ListItem>WY</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group"  style="text-align:left;">
                                            <br />
                                            <label>Zip Code:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtZipCode" class="form-control" placeholder="Zip Code *" value="" />
                                        </div>


                                        <div class="form-group"  style="text-align:left;">
                                            <br />
                                            <label>Security Question 1:</label>
                                            <br />
                                            <asp:TableCell runat="server" >

                                                <asp:DropDownList runat="server" id="ddlQ1" class="hidden" Height="37px" Width="100%">
                                                <asp:ListItem>What is your Birthdate?</asp:ListItem>
                                                <asp:ListItem>What is Your old Phone Number</asp:ListItem>
                                                <asp:ListItem>What is your Pet Name?</asp:ListItem>
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtQ1" class="form-control" placeholder="Enter Your Answer *" value="" />
                                        </div>

                                        <div class="form-group"  style="text-align:left;">
                                            <br />
                                            <label>Security Question 2:</label>
                                            <br />
                                            <asp:TableCell runat="server">

                                                <asp:DropDownList runat="server" id="ddlQ2" class="hidden" Height="37px" Width="100%">
                                                <asp:ListItem>What is the name of your best friend?</asp:ListItem>
                                                <asp:ListItem>What was the name of your first class?</asp:ListItem>
                                                <asp:ListItem>What is your favorite vacation spot?</asp:ListItem>
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtQ2" class="form-control" placeholder="Enter Your Answer *" value="" />
                                        </div>



                                        <div class="form-group" style="text-align:left;">
                                            <br />
                                            <label>Security Question 3:</label>
                                            <br />
                                            
                                            <asp:TableCell runat="server">
                                                <asp:DropDownList runat="server" id="ddlQ3" class="hidden" Height="37px" Width="100%">
                                                <asp:ListItem>What was your high school name?</asp:ListItem>
                                                <asp:ListItem>What is your mom's name?</asp:ListItem>
                                                <asp:ListItem>What is your favorite color?</asp:ListItem>
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                                
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtQ3" class="form-control" placeholder="Enter Your Answer *" value="" />
                                        </div>

                                       <asp:Button class="btnRegister" ID="btnRegister" runat="server" Text="Register" style="float:right;" OnClick="btnRegister_Click"></asp:Button>
                                    </div>
                                    <asp:Label ID="lblVal" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="tab-pane fade show" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                <h3 class="register-heading">Apply as a Hirer</h3>
                                <div class="row register-form">
                                   <%-- <div class="col-md-6">
                                        <div class="form-group">
                                            <input type="text" class="form-control" placeholder="First Name *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <input type="text" class="form-control" placeholder="Last Name *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <input type="email" class="form-control" placeholder="Email *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <input type="text" maxlength="10" minlength="10" class="form-control" placeholder="Phone *" value="" />
                                        </div>--%>


                                    </div>
                                    <div class="col-md-6">
                                        <br />
                                        
                                    </div>
                                <%--</div>--%>
                            </div>
                            
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </form>

</body>
</html>
