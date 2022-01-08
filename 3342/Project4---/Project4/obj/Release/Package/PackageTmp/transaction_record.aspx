<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transaction_record.aspx.cs" Inherits="Project4.transaction_record" %>

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
         .gvDiv {
            padding-left:33%;
            text-align:center;
        }

</style>
</head>
<body>
       <header>Transaction Record Center</header>
<ul id="myNar">
  <li><a class="active" href="index.aspx">Home</a></li>
  <li><a href="purchasePage.aspx">Purchase Page</a></li>
    <li><a href="transaction_record.aspx">Transaction Record Page</a></li>
</ul>
    <br />
    <form id="form1" runat="server">
         <div id="infoDiv">
             <asp:Label ID="lblInva" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblAccount" runat="server" Text="Account ID: "></asp:Label>
            <asp:TextBox ID="txtAcount" runat="server"></asp:TextBox><br />
             <asp:Button ID="btn" runat="server" Text="View All transaction By ID" OnClick="btn_Click" />
        </div>
        <div class="gvDiv">
        <asp:GridView ID="gvAllTran" runat="server" AutoGenerateColumns="false">
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
