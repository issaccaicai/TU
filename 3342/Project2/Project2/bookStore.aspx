<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookStore.aspx.cs" Inherits="Project2.bookStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>College Book Store</title>
<style>
    
body {
    background-image: url("img/bs.jpg");
}
h1  {
    text-align:center;
    color: lightblue;
}
h2  {
    text-align:center;
    color: red;
}
div {
    width: 98%;
    border: 20px solid lightgreen;
    background-color:lightyellow;
    padding-left: 20px;
}
#btnPurchase {
    border:10px double green;
}
#lblDisplay {
    background-color: antiquewhite;
}


</style>
</head>


<body>
    <form id="form1" runat="server">

        <div>
            
    <h1>College Book Store</h1> 
            <asp:Label id="lblId" runat="server" Text="Student ID: "></asp:Label>
            <asp:TextBox id="txtId" runat="server"></asp:TextBox><br /><br />

            <asp:Label id="lblName" runat="server" Text="Student Name: "></asp:Label>
            <asp:TextBox id="txtName" runat="server"></asp:TextBox><br /><br />

            <asp:Label id="lblAddress" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox id="txtAddress" runat="server"></asp:TextBox><br /><br />

            <asp:Label id="lblPhone" runat="server" Text="Phone Number: "></asp:Label>
            <asp:TextBox id="txtPhone" runat="server"></asp:TextBox><br /><br />

            <select name="Campuses" id="Campuses">
	        <option selected="selected" value="Main"> Main Campus </option>
	        <option value="Ambler"> Ambler </option>
            <option value="CC"> CenterCity </option>
            <option value="Harrisburg"> Harrisburg </option>
            <option value="PM"> Podiatric Medicine </option>
            <option value="HSC"> Health Sciences Center </option>
	        <option value="Japan"> Japan </option>
	        <option value="Rome"> Rome </option>
            </select><br /><br />
            </div>

            <div>
                <h2>Select your books</h2>
            <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Select Books">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>

                <asp:BoundField DataField="Title" HeaderText="Title" />

                <asp:BoundField DataField="Authors" HeaderText="Authors" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />

                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>

                    <asp:DropDownList ID="DDType" runat="server">
                    <asp:ListItem Enabled="true" Text="Hardcover" Value="Hardcover"></asp:ListItem>
                    <asp:ListItem Text="Paper-Back" Value="Paper-Back"></asp:ListItem>
                    <asp:ListItem Text="E-Book" Value="E-Book"></asp:ListItem>

                </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="Rent/Buy">
                    <ItemTemplate>
                    <asp:DropDownList ID="DDRB" runat="server">
                    <asp:ListItem Enabled="true" Text="Rent" Value="Rent"></asp:ListItem>
                    <asp:ListItem Text="Buy" Value="Buy"></asp:ListItem>
                </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQty" runat="Server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>


                </Columns>
             </asp:GridView>
                <br /><br />
             <asp:Button ID="btnPurchase" runat="server" Text="Purchase" Height="59px" Width="267px" OnClick="btnPurchase_Click" />
             <br /><br /><br />

 
            </div>

        <div>
            <h2>Your receipt summary</h2>
            <asp:Label ID="lblPerson" runat="server" Text="Personal Information" Height="93px" Width="326px" BackColor="LightGreen"></asp:Label>
            <br /><br />

            <asp:GridView ID="gvOutput" runat="server" Height="227px" Width="554px" AutoGenerateColumns="False" ShowFooter="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                 <AlternatingRowStyle BackColor="PaleGoldenrod" />
                 <Columns>

                     <asp:BoundField DataField="Title" HeaderText="Title"/>
                     <asp:BoundField DataField="ISBN" HeaderText="ISBN"/>
                     <asp:BoundField DataField="Type" HeaderText="Type"/>
                     <asp:BoundField DataField="RB" HeaderText="Rent/Buy"/>
                     <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}"/>
                     <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                     <asp:BoundField DataField="TotalCost" HeaderText="TotalCost" DataFormatString="{0:C}"/>

                 </Columns>
                 <FooterStyle BackColor="Tan" />
                 <HeaderStyle BackColor="Tan" Font-Bold="True" />
                 <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                 <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                 <SortedAscendingCellStyle BackColor="#FAFAE7" />
                 <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                 <SortedDescendingCellStyle BackColor="#E1DB9C" />
                 <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            

            
            <br /><br />
            </div>

        <div>
            <h2>Book Store Summary</h2>
                    <asp:GridView ID="gvSummary" runat="server" AutoGenerateColumns="False" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Book Title" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                <asp:BoundField DataField="TotalSales" DataFormatString="{0:c}" HeaderText="TotalSales" />
                <asp:BoundField DataField="TotalQuantityRented" HeaderText="Total Quantity Rented" />
                <asp:BoundField DataField="TotalQuantitySold" HeaderText="Total Quantity Sold" />
            </Columns>
            <FooterStyle Font-Bold="true" />

        </asp:GridView>
            <br /><br /><br /><br /><br />

            </div>
        
    </form>
</body>
</html>
