<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAccountPage.aspx.cs" Inherits="APITest.CustomerAccountPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" />    
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
        <style>
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
    <form id="form1" runat="server">
        <header>
            <img src="img/logo.jpg" style="width: 200px; height: 100px; float: left;" />Amazon Customer Account</header>
                        <div class="form-group">
                            <br />
                             <center><a href="Shopping.aspx" class="btn btn-success" style="width:20%; text-align:center;">Go back to shopping page</a></center>
                            
                                <br />
                            <h3>Customer Account</h3>
                            <hr >
                            <br />
                                            <div class="form-group">
                    <center><h2>Order History</h2></center>
                    <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" Width="90%" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />  
                        <Columns>
                            <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Product Image" ControlStyle-Width="200px" ControlStyle-Height = "100px"></asp:ImageField>

                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}"/>
                            <asp:BoundField DataField="Total" HeaderText="Total Cost" />
                            <asp:BoundField DataField="Time" HeaderText="Time Purchase" />

                        </Columns>
                        <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
                <HeaderStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
                            <br />
                            <br />
                            <fieldset style="background-color: #E9F8DF">
           <legend>Customer Account Information</legend>
                                <hr >
                    <asp:GridView ID="gvAccountInfo" runat="server" AutoGenerateColumns="False" Width="90%" OnRowEditing="gvAccountInfo_RowEditing" OnRowCancelingEdit="gvAccountInfo_RowCancelingEdit" OnRowUpdating="gvAccountInfo_RowUpdating" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />  
                        <Columns>
                            <asp:BoundField DataField="CustomerUserName" HeaderText="Customer UserName" />
                            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                            <asp:BoundField DataField="CustomerAddress" HeaderText="Customer Address" />
                            <asp:BoundField DataField="CustomerCity" HeaderText="Customer City" />
                            <asp:BoundField DataField="CustomerState" HeaderText="Customer State" />
                            <asp:BoundField DataField="CustomerZip" HeaderText="Customer ZipCode" />
                            <asp:BoundField DataField="CustomerPhone" HeaderText="Customer Phone" />
                            <asp:BoundField DataField="CustomerEmail" HeaderText="Customer Email" />
                            <asp:CommandField  ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
                <HeaderStyle HorizontalAlign="Center" />
                    </asp:GridView>
                                </fieldset>
                </div>
                <!--Account security questions-->
                <div class="form-group">
                    <hr >
                    <br />
                    
                    <asp:Table ID="tblForgotPassword" runat="server" HorizontalAlign="Center">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Edit security question</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Question 1:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblQuestion1" runat="server"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAnswer1" runat="server" ReadOnly="true"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Question 2:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblQuestion2" runat="server"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAnswer2" runat="server" ReadOnly="true"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Question 3:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblQuestion3" runat="server"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAnswer3" runat="server" ReadOnly="true"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <div style="text-align:center">
                        <br />
                    <asp:Label ID="lblSecurity" runat="server" Text="" ForeColor="red"></asp:Label>
                   <asp:Label ID="lblResetSuccess" class="alert alert-success" runat="server" Text="Reset successfully!" Visible="false" ></asp:Label>

                    <br />
                        <br />
                    <asp:Button ID="btnEdit" runat="server" class="btn btn-success" Text="Edit Security Questions" OnClick="btnEdit_Click" /> 
                    &nbsp;<asp:Button ID="btnEditAnwsers" runat="server" class="btn btn-success" Text="Save answers" Visible="false" OnClick="btnEditAnwsers_Click" /> 
                    &nbsp;<asp:Button ID="btnCancel" runat="server" class="btn btn-success" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />
                        
                    <br />
                        <hr >
                <br />
                <!--Reset password-->
                <div class="form-group">
                    <label><b>Reset your password</b></label>
                    <%--<div class="form-group">
                        <label>Enter your current password</label>
                        <asp:TextBox ID="txtPassword" class="form-control" runat="server" type="password" />
                    </div>--%>
                     <br />
                            <asp:Label runat="server" Text="Current Password: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCurrentPassword" runat="server"></asp:TextBox><br />
                    <asp:Label runat="server" Text="New Password: "></asp:Label>
        <br />
        <asp:TextBox ID="txtReset" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Confirm Password: "></asp:Label>
        <br />
        <asp:TextBox ID="txtConfirmReset" runat="server"></asp:TextBox>
                        <br />

                    <br /><br />
                    <div class="form-group">
                        <asp:Label ID="lblDisplay" runat="server" Text="" ForeColor="red"></asp:Label>
                        <asp:Label ID="lblSuccess" class="alert alert-success" runat="server" Text="Password reset successful!" Visible="false" ></asp:Label>
                     </div>
                    <div class="form-group">
                        <asp:Button ID="btnResetPassword" class="btn btn-success" runat="server" Text="Reset Password" OnClick="btnResetPassword_Click" width="10%"/>
                    </div>
                </div>
                        <hr >


        </div>
                    </div>
    </form>
</body>
</html>
