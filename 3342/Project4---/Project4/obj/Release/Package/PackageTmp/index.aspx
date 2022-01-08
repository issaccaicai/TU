<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project4.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
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
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover {
    background-color: #111;
}


        header {
        
        text-align:center;
        height: 100px;
        background-color:black;
        color:white;
        font-size:60px;
        margin:auto;
        padding-top:2%;
        }

        #infoDiv {
        padding-left:33%;
        font-size:28px;
        }

        #myNar {
        padding-left:33%;
        }

        #gvDiv {
            padding-left:15%;
            text-align:center;
        }

</style>
</head>
<body>
   <header>Credit Card Center</header>
<ul id="myNar">
  <li><a class="active" href="index.aspx">Home</a></li>
  <li><a href="purchasePage.aspx">Purchase Page</a></li>
     <li><a href="transaction_record.aspx">Transaction Record Page</a></li>
</ul>
    <br />
    <form id="form1" runat="server">
        <div id="infoDiv">
             <asp:Label ID="lblInva" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblCardNumber" runat="server" Text="Card Number:"></asp:Label>
            <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblST" runat="server" Text="Street: "></asp:Label>
            <asp:TextBox ID="txtST" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblZipCode" runat="server" Text="Zip Code: "></asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblExpDate" runat="server" Text="Exp Date: "></asp:Label>
            <asp:TextBox ID="txtExpMonth" runat="server" Width="40px"></asp:TextBox>MM &nbsp/&nbsp<asp:TextBox ID="txtExpYear" runat="server" Width="40px"></asp:TextBox>YYYY
            <br />
            <asp:Label ID="lblCVV" runat="server" Text="CVV: "></asp:Label>
            <asp:TextBox ID="txtCvv" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCreateNewCard" runat="server" Text="Create A New Card" OnClick="btnCreateNewCard_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Show All Cards" OnClick="btnShow_Click" /> 
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Width="200px" /> 
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCanncel" runat="server" Text="Canncel" OnClick="btnCanncel_Click" Width="200px" />
            <br />
        </div>
         <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
        <div id="gvDiv">
        <asp:GridView ID="gvCard" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCard_SelectedIndexChanged">
         <Columns>
             <asp:BoundField DataField="AccountID" HeaderText="Account ID" />
             <asp:BoundField DataField="CardNumber" HeaderText="Card Number" />
             <asp:BoundField DataField="CardHolderName" HeaderText="Name" />
             <asp:BoundField DataField="CardAddr" HeaderText="Street" />
             <asp:BoundField DataField="CardCity" HeaderText="City" />
             <asp:BoundField DataField="CardState" HeaderText="State" />
             <asp:BoundField DataField="CardZipCode" HeaderText="Zip Code" />
             <asp:BoundField DataField="CardExpDate" DataFormatString="{0:MM/yyyy}" HeaderText="Exp Date" />
             <asp:BoundField DataField="CardCvv" HeaderText="CVV" />
             <asp:BoundField DataField="Val" HeaderText="Val" />
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="btnEdit" runat="server" commandArgument="<%# Container.DataItemIndex %>" OnClick ="btnEdit_Click" Text="Edit" />
                 </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="btnAction" runat="server" commandArgument="<%# Container.DataItemIndex %>" OnClick ="btnAction_Click" Text="Deactivate" />
                 </ItemTemplate>
             </asp:TemplateField>
             </Columns>
            </asp:GridView>
            </div>
    </form>
</body>
</html>

