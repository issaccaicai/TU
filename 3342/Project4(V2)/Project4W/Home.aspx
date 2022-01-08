<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project4W.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        header {
        
        text-align:center;
        height: 100px;
        background-color:beige;
        color:Black;
        font-size:70px;
        margin:auto;
        padding-top:2%;
        }
        #centerDiv {
        padding-left:33%;
        font-size:30px;
        }
                #myNar {
        padding-left:33%;
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
    text-align: center;
    padding: 20px 70px;
    text-decoration: none;
}

li a:hover {
    background-color: #111;
}

        </style>
    <title></title>
</head>
<body>
    <header>City View</header>
    <form id="form1" runat="server">
        <ul id="myNar">
  <li><a class="active" href="Home.aspx">Home Page</a></li>
  <li><a href="Search.aspx">Search Page</a></li>
</ul>
        <div id="centerDiv">
        <asp:Label ID="lblVal" runat="server" Text="" Visible="false"></asp:Label>
            <br />
            <%--<asp:Label ID="lblCityID" runat="server" Text="City ID:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox><br />--%>
            <asp:Label ID="lblCityName" runat="server" Text="City Name: "></asp:Label>
            <asp:TextBox ID="txtCityName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblPopulation" runat="server" Text="Population: "></asp:Label>
            <asp:TextBox ID="txtPopulation" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblMedianHouseholdIncome" runat="server" Text="Median Household Income: "></asp:Label>
            <asp:TextBox ID="txtMedianHouseholdIncome" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblPercentageOfOwners" runat="server" Text="Percentage Of Owners: "></asp:Label>
            <asp:TextBox ID="txtPercentageOfOwners" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblPercentageOfRenters" runat="server" Text="Percentage Of Renters: "></asp:Label>
            <asp:TextBox ID="txtPercentageOfRenters" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblMedianHomeValue" runat="server" Text="Median Home Value: "></asp:Label>
            <asp:TextBox ID="txtMedianHomeValue" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblMedianAgeForMale" runat="server" Text="Median Age For Male: "></asp:Label>
            <asp:TextBox ID="txtMedianAgeForMale" runat="server"></asp:TextBox>

            <br />
            <asp:Label ID="lblMedianAgeForFemale" runat="server" Text="Median Age For Female: "></asp:Label>
            <asp:TextBox ID="txtMedianAgeForFemale" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblUnemploymentRate" runat="server" Text="Unemployment Rate: "></asp:Label>
            <asp:TextBox ID="txtUnemploymentRate" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblCrimeIndex" runat="server" Text="Crime Index: "></asp:Label>
            <asp:TextBox ID="txtCrimeIndex" runat="server"></asp:TextBox>
        <br /><br />


        

            <br />
            <asp:Button ID="btnAddCity" runat="server" Text="Add A New City" OnClick="btnAddCity_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDisplay" runat="server" Text="Display All Cities" OnClick="btnDisplay_Click" /> 
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="200px" OnClick="btnUpdate_Click" /> 
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCanncel" runat="server" Text="Canncel" Width="200px" OnClick="btnCanncel_Click" />
            <br />


        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        <fieldset>
        <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCity_SelectedIndexChanged">
         <Columns>
             <asp:BoundField DataField="CityId" HeaderText="City ID" />
             <asp:BoundField DataField="CityName" HeaderText="City Name" />
             <asp:BoundField DataField="State" HeaderText="State" />
             <asp:BoundField DataField="Population" HeaderText="Population" />
             <asp:BoundField DataField="MedianHouseholdIncome" HeaderText="Median Household Income" />
             <asp:BoundField DataField="PercentageOfOwners" DataFormatString="{0:0.00}%" HeaderText="Percentage Of Owners" />
             <asp:BoundField DataField="PercentageOfRenters" DataFormatString="{0:0.00}%" HeaderText="Percentage Of Renters" />
             <asp:BoundField DataField="MedianHomeValue" HeaderText="Median Home Value" />
             <asp:BoundField DataField="MedianAgeForMale" HeaderText="Median Age for Male" />
             <asp:BoundField DataField="MedianAgeForFemale" HeaderText="Median Age for Female" />
             <asp:BoundField DataField="UnemploymentRate" DataFormatString="{0:0.00}%" HeaderText="Unemployment Rate" />
             <asp:BoundField DataField="CrimeIndex" HeaderText="Crime Index" />

             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="btnUpdateChange" runat="server" commandArgument="<%# Container.DataItemIndex %>" OnClick ="btnUpdateChange_Click" Text="Update" />
                 </ItemTemplate>
             </asp:TemplateField>
             </Columns>
            </asp:GridView>
        </fieldset>
            
    </form>
</body>
</html>
