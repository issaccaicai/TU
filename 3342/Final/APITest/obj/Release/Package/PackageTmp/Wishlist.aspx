<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="APITest.Wishlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

        #centerDiv {
            padding-left: 33%;
            font-size: 30px;
        }

        #myNar {
            padding-left: 0%;
        }


        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
        }

        li {
            float: left;
        }

            li a {
                display: block;
                color: white;
                text-align: left;
                padding: 20px 70px;
                text-decoration: none;
            }

                li a:hover {
                    background-color: #111;
                }

        .navbar-right {
            float: right;
        }

        .navbar-left {
            float: left;
        }

        .badge {
            background-color: #6394F8;
            border-radius: 10px;
            color: white;
            display: inline-block;
            font-size: 12px;
            line-height: 1;
            padding: 3px 7px;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
        }
        body {
    font-family: 'Raleway', sans-serif;
    background: #E9F8DF;
    -webkit-font-smoothing: antialiased;
   
}
        </style>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
</head>
<body>

    <form id="form1" runat="server">
        

        <header>
            <img src="img/logo.jpg" style="width: 200px; height: 100px; float: left;" />Amazon Wishlist Site</header>
        <ul id="myNar" class="nav navbar-nav ml-auto">
            <li style="font-size: 20px" class="navbar-left"><a href="Shopping.aspx"><span style="color:white;" class="fa fa-home" aria-hidden="true" ></span>Shopping</a></li>
            <li style="font-size: 20px" class="navbar-left">
                <asp:LinkButton runat="server" ID="lbAccount" OnClick="lbAccount_Click"><span style="color:white;" class="fa fa-user" aria-hidden="true"></span>Customer Account</asp:LinkButton></li>
            <%--<li class="navbar-left"><a href="Wishlist.aspx">Wishlist Page</a></li>--%>

            <%--<li class="fa fa-shopping-cart cart-icon"><span class="badge">3</span></li>--%>
           <li style="font-size: 20px" class="navbar-right">
                <asp:LinkButton runat="server" ID="lbLogout" OnClick="lbLogout_Click"><span style="color:white;" class="fa fa-sign-out" aria-hidden="true"></span>Logout</asp:LinkButton></li>
            <li style="font-size: 20px" class="navbar-right">
                <asp:LinkButton ID="lbCart" runat="server" OnClick="lbCart_Click"> <span style="color:white;" class="fa fa-shopping-cart"></span>Shopping Cart</asp:LinkButton></li>

            <%--                 <li style="font-size:20px" class="navbar-right"><a href="Cart.aspx" class="fa fa-shopping-cart" style="color:white;"> Shopping Cart</a></li>--%>
            <li style="font-size: 20px" class="navbar-right"><asp:LinkButton ID="lbWishlist" runat="server" class="fa" style="color: white;" OnClick="lbWishlist_Click">&#xf08a; Wishlist</asp:LinkButton></li>

        </ul>
        <fieldset style="background-color: #E9F8DF">
            <legend>Wishlist</legend>
        <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" Width="90%" OnSelectedIndexChanged="gvCart_SelectedIndexChanged" OnRowDeleting="gvCart_RowDeleting" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />    
            <Columns>
                    <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" ReadOnly="True" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>

                    <%--<asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <img src='<%# Eval("ImageURL") %>' height="200" width="200" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>--%>
                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Product Image" ReadOnly="True" ControlStyle-Width="200px" ControlStyle-Height = "100px"></asp:ImageField>
                    
                    
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" type="number" Text="1" min="1" max="100" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                <asp:CommandField ButtonType="Button" HeaderText="Add to Cart" ShowSelectButton="true" SelectText="Add to cart">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" EditText="" ShowDeleteButton="True" DeleteText="Remove" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" Visible="False" />
               
                </Columns>
            <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>

<%--                    <asp:Button ID="btnAddtoCart" runat="server" Text="Add to Cart" Style="color: forestgreen;" OnClick="btnAddtoCart_Click"  />--%>
                    <asp:Label ID="lblVali" runat="server" ForeColor="red"></asp:Label><br />
            </fieldset>
    </form>
</body>
</html>
