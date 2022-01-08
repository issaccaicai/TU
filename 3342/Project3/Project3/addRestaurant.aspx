<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addRestaurant.aspx.cs" Inherits="Project3.addRestaurant" %>

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
    <header>Adding a restaurant</header>
    <form id="form1" runat="server">
        <div id="btn">
        <fieldset>
            <asp:Label ID="lblUser" runat="server"></asp:Label>

            <br /><br />
            <asp:Button ID="btnSearch" runat="server" Text="Search Page" OnClick="btnSearch_Click" />
            &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Back to login page" OnClick="btnLogin_Click" />
            <br />
            
            </fieldset>


        <asp:Label ID="lblAdd" runat="server" Text="Category you want to add: "></asp:Label>

        <asp:DropDownList ID="ddlRestaurant" runat="server" AutoPostBack="true">
        </asp:DropDownList>

        <br /><br />
        <asp:Label ID="lblName" runat="server" Text="Restaurant Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valName" runat="server"
            ControlToValidate="txtName" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>

        <br /><br />
        <asp:Label ID="lblDesc" runat="server" Text="Restaurant Description: "></asp:Label>
        <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valDes" runat="server"
            ControlToValidate="txtDesc" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
        <br />
        <br /> <asp:Label ID="lblAddRep" runat="server" Text="Add Representative: "></asp:Label>
        <asp:DropDownList ID="ddlAddRep" runat="server" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblUrl" runat="server" Text="Add Image URL(*Ending with .jpg, .jpeg, .bmp,  .gif*): "></asp:Label>
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valUrl" runat="server"
            ControlToValidate="txtUrl" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
        <br /><br />


            <asp:Button ID="btnAddRestaurant" runat="server" Text="Add Restaurant" OnClick="btnAddRestaurant_Click" />

        <br />
        <asp:Label ID="lblAddInval" runat="server"></asp:Label>

        <br />
        <br />
        <asp:GridView ID="gvDisplayRestaurant" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvDisplayRestaurant_SelectedIndexChanged" CssClass="auto-style1" align="center">



            <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    

                    <asp:BoundField DataField="restaurantId" HeaderText="Restaurant Id" />
                    <asp:BoundField DataField="restaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="restaurantDesc" HeaderText="restaurant Description" />
                    <asp:BoundField DataField="categoriesId" HeaderText="Categories Id" />
                    <asp:BoundField DataField="categoriesName" HeaderText="Categories Name" />
                    <asp:BoundField DataField="representativeName" HeaderText="Representative Name" />
                    
                    <asp:ImageField DataImageUrlField="url" HeaderText="Image" ControlStyle-Width="100" ControlStyle-Height = "100" >

                    <ItemStyle Height="30px" HorizontalAlign="Center" Width="30px" />

                </asp:ImageField>
                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>

        </asp:GridView>
</div>
    </form>
</body>
</html>
