<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shopping.aspx.cs" Inherits="APITest.Shopping" %>

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
            <img src="img/logo.jpg" style="width: 200px; height: 100px; float: left;" />Amazon Shopping Site</header>
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

            <legend>Products</legend>
            <asp:Button ID="btnDepartments" runat="server" Text="Get Our Departments" Style="color: forestgreen;" OnClick="btnDepartments_Click" />
<%--            <asp:Button ID="btnCustomerAccount" runat="server" Text="Customer Account" Style="color: forestgreen; float: right;" OnClick="btnCustomerAccount_Click"></asp:Button>--%>

            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <center><asp:Label ID="lblINfo" runat="server" Text="Inventory, sales report in merchant account page!"></asp:Label></center>
            <br />
            <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="DepartmentNumber" HeaderText="Department Number" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center" />
            </asp:GridView>
            <br />
            <h2>Below are other groups' departments</h2>
                        <asp:GridView ID="gvDepartment2" runat="server" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="departmentID" HeaderText="Department Number" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center" />
            </asp:GridView>
            <br />
                        <asp:GridView ID="gvDepartment3" runat="server" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="DepartmentID" HeaderText="Department Number" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center" />
            </asp:GridView>
            <br/ > <br/ >

            <div style="text-align:center">
            <asp:Button ID="btnDisplayAllProducts" runat="server" Text="Display All Products" Style="color: forestgreen;" OnClick="btnDisplayAllProducts_Click" Height="61px" Width="354px"></asp:Button>
            

                <br />
            

            <br />
            

            <br />

            <label>Select a department</label>

            <%--                                     <asp:LinkButton ID="lbCart" runat="server"><span style="color:white;" class="glyphicon glyphicon-shopping-cart"></span> Cart</asp:LinkButton></li>--%>

            <br />

            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" Height="52px" Width="190px"></asp:DropDownList>




            <asp:Button ID="btnShow" runat="server" Text="Display Products" Width="32%" Style="color: forestgreen;" OnClick="btnShow_Click" Height="54px"></asp:Button>
            


                <br />
                <br />
                <br />
                <br />
            


                <br />
            
                <asp:DropDownList ID="ddlDepartment2" runat="server" AutoPostBack="True" Width="5%"></asp:DropDownList>



            <asp:Button ID="btnShow2" runat="server" Text="Display Products" Width="10%" Style="color: forestgreen;" OnClick="btnShow2_Click"></asp:Button>

                <br />
            


                <asp:DropDownList ID="ddlDepartment3" runat="server" Width="5%" AutoPostBack="True"></asp:DropDownList>



            <asp:Button ID="btnShow3" runat="server" Text="Display Products" Width="10%" Style="color: forestgreen;" OnClick="btnShow3_Click"></asp:Button>
<br />
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
<%--                    <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" />--%>
                    <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <img src='<%# Eval("ImageURL") %>' height="200" width="300" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <%--                     <asp:BoundField DataField="ImageURL" HeaderText="Image URL" Visible="false";></asp:BoundField>--%>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" type="number" Text="1" min="1" max="100" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" HeaderText="Wishlist" ShowSelectButton="true" SelectText="Add to wishlist">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" HeaderText="Add to Cart" ShowSelectButton="true" SelectText="Add to cart">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center" />
            </asp:GridView>
                </div>
            <%--<asp:Label ID="lblV" runat="server"></asp:Label>--%>


            


        </fieldset>

        <br />
        <br />



    </form>
</body>
</html>
