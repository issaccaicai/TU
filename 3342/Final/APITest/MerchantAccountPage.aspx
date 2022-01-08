<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantAccountPage.aspx.cs" Inherits="APITest.MerchantAccountPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" />    
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="bootstrap-style.css" />
    <title></title>
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
        .auto-style1 {
            margin-bottom: 0px;
        }
        </style>
       
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <img src="img/logo.jpg" style="width: 200px; height: 100px; float: left;" />Amazon Merchant Account</header>
                                     <center><asp:Button runat="server" ID="btnLogout" class="btn btn-success" Text="Logout" style="width:20%; text-align:center;" OnClick="btnLogout_Click"></asp:Button>
                                         <br />
        </center>
        <h2>Merchant Account Information</h2>
         
            <br />
        <div style="text-align:center">
            <hr />
            <br />
            <h2>Inventory Report</h2>
            <p>&nbsp;</p>
            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False"  Width="90%" HorizontalAlign="Center" CssClass="auto-style1">
                <AlternatingRowStyle BackColor="White" />  
                <Columns>
                    <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" />
                    <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Product Image" ControlStyle-Width="200px" ControlStyle-Height = "100px"/>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity Sold" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="DepartmentNumber" HeaderText="Department Number" />
                </Columns>
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
            <br/ ><br/ >

            <h2>&nbsp;</h2>
            <h2>All Sales</h2>
            <br />
            <br />
            <asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False"  Width="90%" HorizontalAlign="Center" CssClass="auto-style1">
                <AlternatingRowStyle BackColor="White" />  
                <Columns>
                    <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" />
                    <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Product Image" ControlStyle-Width="200px" ControlStyle-Height = "100px"/>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity Sold" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Total" HeaderText="Total Amount" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                    <asp:BoundField DataField="CustomerAddress" HeaderText="Customer Address" />
                    <asp:BoundField DataField="CustomerCity" HeaderText="Customer City"  />
                    <asp:BoundField DataField="CustomerState" HeaderText="Customer State" />
                    <asp:BoundField DataField="CustomerZip" HeaderText="Customer Zip" />
                    <asp:BoundField DataField="CustomerPhone" HeaderText="Customer Phone" />
                    <asp:BoundField DataField="CustomerEmail" HeaderText="Customer Email" /> 
                    <asp:BoundField DataField="Time" HeaderText="Time Purchase" /> 
                </Columns>
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>




            <br />
            <br />
            <fieldset>
            <legend>
                <br />
                Merchant Account Information<br />
                                </legend>
            <br />
            <asp:GridView ID="gvAccountInfo" runat="server" AutoGenerateColumns="False" Width="90%" OnRowCancelingEdit="gvAccountInfo_RowCancelingEdit" OnRowEditing="gvAccountInfo_RowEditing" OnRowUpdating="gvAccountInfo_RowUpdating" HorizontalAlign="Center" >
                <AlternatingRowStyle BackColor="White" />  
                <Columns>
                    <asp:BoundField DataField="Address" HeaderText="Merchant Address" />
                    <asp:BoundField DataField="City" HeaderText="Merchant City" />
                    <asp:BoundField DataField="State" HeaderText="Merchant State" />
                    <asp:BoundField DataField="Zip" HeaderText="Merchant Zipcode" />
                    <asp:BoundField DataField="Phone" HeaderText="Merchant Phone" />
                    <asp:BoundField DataField="Email" HeaderText="Merchant Email" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" />

                </Columns>
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
                <br />
             <br />
             </fieldset>



            <asp:TextBox ID="txtAPIKey" runat="server" Width="30%" style="text-align:center" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnGetApikey" style="text-align:center" class="btn btn-success" runat="server" Text="Get APIKey" OnClick="btnGetApikey_Click" width="30%"/>
            
            
            <br />
            <br />

            <div class="form-group">
                <hr />
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
                    </div>

            </div>
            <br />
            <div class="form-group">
                    <label><b>Reset password</b></label>
                    <div class="form-group">
                        <label>Enter current password:</label>
                        <br />
                        <asp:TextBox ID="txtPassword" runat="server" type="password" />
                    </div>
                    <div class="form-group">
                        <label>Enter new password:</label>
                        <br />
                        <asp:TextBox ID="txtNewPassword" runat="server" type="password" />
                    </div>
                    <div class="form-group">
                        <label>Confirm new password:</label>
                        <br />
                        <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" />
                    </div>
                    <div class="form-group">
                        <br />
                        <asp:Label ID="lblDisplay" runat="server" Text="" ForeColor="red"></asp:Label>
                        <asp:Label ID="lblSuccess" class="alert alert-success" runat="server" Text="Reset successfully!" Visible="false" ></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btnResePassword" class="btn btn-success" runat="server" Text="Reset Password" OnClick="btnResePassword_Click" Width="10%" />
                     </div>
                </div>
            
            <hr >
            
            <br />
            <br />
            </div>
    </form>
</body>
</html>
