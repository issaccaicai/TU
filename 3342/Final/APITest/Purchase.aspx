<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="APITest.Purchase" %>

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
        
        text-align:center;
        height: 100px;
        background-color:beige;
        color:Black;
        font-size:70px;
        margin:auto;
        }
         body {
    font-family: 'Raleway', sans-serif;
    background: #E9F8DF;
    -webkit-font-smoothing: antialiased;
   
}
    </style>
</head>
<body>            <header><img src="img/logo.jpg" style="width:200px; height:100px; float:left;"/>Amazon Shopping Site</header>
    <center><h1>Receipt</h1></center>
    <form id="form1" runat="server">
        <hr>
       <br /><br />
        <center><asp:Label ID="lblCustomer" runat="server" Font-Size="Large" Font-Bold="true"></asp:Label><center>
                    <br />
                    <asp:Label ID="lblDisplay" runat="server" Font-Size="Large" Font-Bold="true"></asp:Label>
                    <br />
                    <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="90%" HorizontalAlign="Center">
                                        <AlternatingRowStyle BackColor="White" />

                        <Columns>
                     <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Product Image" ControlStyle-Width="200" ControlStyle-Height = "100"></asp:ImageField>
                            <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Product Description" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" DataFormatString="{0:C}">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:GridView>
        <div class="form-row">
                    <div class="col-md-6">
                        <br />
                        <br />
                        <center><asp:Button ID="btnPurchase" class="btn btn-primary" runat="server" Text="Record Receipt" OnClick="btnPurchase_Click" width="20%"/></center>
                    </div>
                    <div class="col-md-6">
                        <br />
                        <br />
                        <center><a href="Shopping.aspx" class="btn btn-success btn-block" style="width:20%">Go back to shopping page</a></center>
                    </div>
                </div>
    </form>
</body>
</html>
