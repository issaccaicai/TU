<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APITest.aspx.cs" Inherits="APITest.APITest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
            
            
            <br />
            <br />

        <fieldset style="background-color:antiquewhite">

            <legend>All Departments</legend>
            <br />
            <asp:Button ID="btnDepartments" runat="server" Text="Get All Departments" OnClick="btnDepartments_Click" />
            <br />
            <br />
            <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="False">
                <Columns>
                <asp:BoundField DataField="DepartmentNumber" HeaderText="Department Number" />
                <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                    </Columns>
                </asp:GridView>
        
            </fieldset>
        
        <br />
        <br />


        <br />
        <fieldset style="background-color:antiquewhite">
            <legend>Find Products By Departmet Number</legend>
            <br />
            <asp:Label ID="lblShow" runat="server" Text="Type Department Name to find all products: "></asp:Label>
            <br />
            <asp:TextBox ID="txtFindDepartment" runat="server"></asp:TextBox>
            <asp:Button ID="btnProducts" runat="server" Text="Get All Products" OnClick="btnProducts_Click" />
            <br />
            <br />

        <asp:GridView ID="gvProducts" runat="server" AutWoGenerateColumns="False" AutoGenerateColumns="False">
                <Columns>
                <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" />
                    <asp:BoundField DataField="ProductTitle" HeaderText="Product Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                     <asp:BoundField DataField="Price" HeaderText="Price" />

                    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Image URL" ControlStyle-Width="300" ControlStyle-Height = "200"></asp:ImageField>
                <%--<asp:BoundField DataField="ImageURL" HeaderText="Image URL" />--%>
                     <asp:BoundField DataField="DepartmentNumber" HeaderText="Department Number" />
                    </Columns>
                </asp:GridView>
            </fieldset>
        <br />

        <fieldset style="background-color:antiquewhite">
            <legend>Register Site:</legend>
        <asp:Label ID="lblSiteId" runat="server" Text="SiteID: "></asp:Label>
        <asp:TextBox ID="txtSiteId" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblAPIkey" runat="server" Text="APIkey: "></asp:Label>
            <asp:TextBox ID="txtAPIkey" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblContactInformation" runat="server" Text="Contact Information: "></asp:Label>
            <asp:TextBox ID="txtContactInformation" runat="server"></asp:TextBox>
            
        </p>
        <p>
            <asp:Button ID="btnRegisterSite" runat="server" Text="Register Site" OnClick="btnRegisterSite_Click" />
            <asp:Label ID="lblVal" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>
            </fieldset>
        <br /><br /><br />

        <fieldset style="background-color:antiquewhite">
            <legend>Record Purchase:</legend>
            <asp:Label ID="lblProductNumber" runat="server" Text="ProductNumber: "></asp:Label>
        <asp:TextBox ID="txtProductNumber" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblSiteIDrp" runat="server" Text="SiteID: "></asp:Label>
        <asp:TextBox ID="txtSiteIDrp" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblAPIKeyrp" runat="server" Text="APIKey: "></asp:Label>
        <asp:TextBox ID="txtAPIKeyrp" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCustomerId" runat="server" Text="Customer ID: "></asp:Label>
        <asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox>
            <br />
            <br />
<%--            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name: "></asp:Label>
        <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
             <br />
             <br />
             <asp:Label ID="lblCustomerEmail" runat="server" Text="Customer Email: "></asp:Label>
        <asp:TextBox ID="txtCustomerEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCustomerPhone" runat="server" Text="Customer Phone: "></asp:Label>
        <asp:TextBox ID="txtCustomerPhone" runat="server"></asp:TextBox>--%>
            <br />
            <br />
            <br />
            <asp:Button ID="btnRecordPurchase" runat="server" Text="Record Purchase" OnClick="btnRecordPurchase_Click" />
            <asp:Label ID="lblValidation" runat="server" Text="Label"></asp:Label>
        </fieldset>
        <br />
            <br />
            <br />
    </form>
</body>
</html>
