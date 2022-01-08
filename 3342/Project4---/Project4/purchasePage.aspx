<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchasePage.aspx.cs" Inherits="Project4.WebForm1" %>

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
            text-align: center;
            height: 100px;
            background-color: black;
            color: white;
            font-size: 60px;
            margin: auto;
            padding-top: 2%;
        }

        #infoDiv {
            padding-left: 33%;
            font-size: 28px;
        }

        #myNar {
            padding-left: 33%;
        }

        #gvDiv {
            padding-left: 33%;
            text-align: center;
        }
        p {
        padding-left: 30%;
        }
    </style>
</head>
<body>
    <header>Purchase Center</header>
    <ul id="myNar">
        <li><a class="active" href="index.aspx">Home</a></li>
        <li><a href="purchasePage.aspx">Purchase Page</a></li>
        <li><a href="transaction_record.aspx">Transaction Record Page</a></li>
    </ul>
    <br />
    <form id="form1" runat="server">
         <p>*If purchase amount over 700 dallors and the card is deactivated, then the card will be declined</p>
        <div id="infoDiv">
            <asp:Label ID="lblAccount" runat="server" Text="Account ID: "></asp:Label>
            <asp:TextBox ID="txtAcount" runat="server"></asp:TextBox><br />
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
            <asp:Label ID="lblAmount" runat="server" Text="Amount: "></asp:Label>
            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
            <br />
            <asp:Label ID="lblInva" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <div id="gvDiv">
            <asp:GridView ID="gvTran" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="AccountId" HeaderText="Account Id" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                    <asp:BoundField DataField="Amount" DataFormatString="{0:c}" HeaderText="Amount" />
                    <asp:BoundField DataField="Error" HeaderText="Message" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
