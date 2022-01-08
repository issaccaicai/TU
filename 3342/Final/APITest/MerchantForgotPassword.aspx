<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantForgotPassword.aspx.cs" Inherits="APITest.MerchantForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <style type="text/css">
        .auto-style1 {
            position: relative;
            display: table;
            border-collapse: separate;
            left: 0px;
            top: 1px;
        }

        header {
            text-align: center;
            height: 100px;
            background-color: beige;
            color: Black;
            font-size: 70px;
            margin: auto;
        }

        body {
            font-family: 'Raleway', sans-serif;
            background: #E9F8DF;
            -webkit-font-smoothing: antialiased;
        }
    </style>
</head>
<body>
    <header>
        <img src="img/logo.jpg" style="width: 200px; height: 100px; float: left;" />Merchant Forget Password</header>
    <form id="form1" runat="server" class="form-signin">
        <center><asp:Button runat="server" ID="btnLogin" class="btn btn-success" Text="Login" style="width:100%; text-align:center;" OnClick="btnLogin_Click"></asp:Button></center>

        <br />
        <br />
        <br />
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <fieldset>
                <label>Enter your email: </label>
                <br />
                <br />
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                    <asp:TextBox ID="txtEmailAddress" runat="server" class="form-control" placeholder="Email *" autofocus="true"></asp:TextBox>
                </div>
            </fieldset>
            <br />
            <br />
            <div id="tblForgotPasswordDiv">
                &nbsp;<asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                <br />
                <hr>
                <br />

                <fieldset>
                    <label>Security Questions: </label>
                    <br />
                    <br />
                    <asp:Label ID="lblQues1" runat="server" Text="Question:1 "></asp:Label>
                    <asp:Label ID="lblQuestion1" runat="server"></asp:Label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign"></i></span>
                        <asp:TextBox ID="txtAnswer1" runat="server" class="form-control" placeholder="Answer 1 *" autofocus="true"></asp:TextBox>
                    </div>

                    <br />

                    <asp:Label ID="lblQues2" runat="server" Text="Question:2 "></asp:Label>

                    <asp:Label ID="lblQuestion2" runat="server"></asp:Label>
                    <div class="auto-style1">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign"></i></span>
                        <asp:TextBox ID="txtAnswer2" runat="server" class="form-control" placeholder="Answer 2 *" autofocus="true"></asp:TextBox>
                    </div>

                    <br />

                    <asp:Label ID="lblQues3" runat="server" Text="Question:3 "></asp:Label>

                    <asp:Label ID="lblQuestion3" runat="server"></asp:Label>

                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign"></i></span>
                        <asp:TextBox ID="txtAnswer3" runat="server" class="form-control" placeholder="Answer 3 *" autofocus="true"></asp:TextBox>
                    </div>

                    <br />

                    <asp:Label ID="lblMessage" runat="server" Style="text-align: center;" ForeColor="red"></asp:Label>
                    <br />
                    <asp:Button ID="btnSubmitAnswers" class="btn btn-success" runat="server" Text="Get Password" OnClick="btnSubmitAnswers_Click" />

                </fieldset>
                <br />
                <hr>
            </div>

            <br />
            <br />


        </div>
    </form>
</body>
</html>
