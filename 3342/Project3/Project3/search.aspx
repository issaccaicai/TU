<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Project3.search" %>

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
    tr:only-child {
        display: none;
    }
    </style>
</head>
<body>
    <header>Search for a restaurant</header>
    <form id="form1" runat="server">
        <div id="btn">

            <fieldset>
            
                <asp:Label ID="lblTest" runat="server"></asp:Label>
</fieldset>

            <fieldset>
            <asp:Label ID="lblSelect" runat="server" Text="Select categories(After slecting categories *Please press enter for details* ): "></asp:Label>
            &nbsp;<br />
                <asp:ListBox ID="lbSelect" runat="server" OnSelectedIndexChanged="lbSelect_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>

                <br />

           <asp:GridView ID="gvDisplayRes" runat="server" AutoGenerateColumns="false" align="center">
            <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="restaurantId" HeaderText="Restaurant Id" />
                    <asp:BoundField DataField="restaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="restaurantDesc" HeaderText="Restaurant Description" />
                    <asp:BoundField DataField="comments" HeaderText="Review Comments" />
                    <asp:BoundField DataField="categoriesId" HeaderText="Categories Id" />
                    <asp:BoundField DataField="categoriesName" HeaderText="Categories" />
                    <asp:BoundField DataField="representativeId" HeaderText="Representative ID" />
                    <asp:BoundField DataField="representativeName" HeaderText="Representative Name" />
                    <asp:BoundField DataField="quality" HeaderText="Quality" />
                    <asp:BoundField DataField="service" HeaderText="Service" />
                    <asp:BoundField DataField="atmosphere" HeaderText="Atmosphere" />
                    <asp:BoundField DataField="price" HeaderText="Price" />

                 

                    
                            <asp:ImageField DataImageUrlField="url" HeaderText="Image" ControlStyle-Width="100" ControlStyle-Height = "100" >

                    <ItemStyle Height="30px" HorizontalAlign="Center" Width="30px" />

                </asp:ImageField>
                    

                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>

        </asp:GridView>




                </fieldset>
            <fieldset>

            <asp:Label ID="lblVali" runat="server"></asp:Label><br />

            </fieldset>
            <%--<asp:Button ID="Button1" runat="server" Text="Back to login page" OnClick="btnLogin_Click" />--%>
            &nbsp;<br />
            <br />


            <fieldset>
            <asp:Label ID="lblName" runat="server" Text="Your Name: "></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />


            <asp:Label ID="lblDate" runat="server" Text="Reservation Date: "></asp:Label>

            <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />


            <asp:Label ID="lblTime" runat="server" Text="Reservation Time: "></asp:Label>
                

            <select name="ddlTime" id="ddlTime" style="color:deepskyblue;">
	            <option value="5:00 - 5:30 PM">5:00 - 5:30 PM</option>                <option value="5:30 - 6:00 PM">5:30 - 6:00 PM</option>                <option value="6:00 - 6:30 PM">6:00 - 6:30 PM</option>                <option value="6:30 - 7:00 PM">6:30 - 7:00 PM</option>                <option value="7:00 - 7:30 PM">7:00 - 7:30 PM</option>                <option value="7:30 - 8:00 PM">7:30 - 8:00 PM</option>                <option value="8:00 - 8:30 PM">8:00 - 8:30 PM</option>                <option value="8:30 - 9:00 PM">8:30 - 9:00 PM</option>                <option value="9:00 - 9:30 PM">9:00 - 9:30 PM</option>                <option value="9:30 - 10:00 PM">9:30 - 10:00 PM</option>            </select>
            <br />
            <asp:Label ID="lblSize" runat="server" Text="Number of People: "></asp:Label>
                <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
                <br />
            <br />

            




                
           &nbsp;<asp:Button ID="btnAddReservation" runat="server" Text="Make Reservation" OnClick="btnAddReservation_Click" />
            
            </fieldset>


            <fieldset>
                            <br />
                <asp:Label ID="lblPage" runat="server" Text="Go to other page"></asp:Label>
                            <br /><br />
                            <asp:Button ID="btnReview" runat="server" Text="Review Page" OnClick="btnReview_Click" />
                &nbsp;<asp:Button ID="btnManageReservation" runat="server" Text="Reservation Page" OnClick="btnManageReservation_Click" />
                &nbsp;<asp:Button ID="btnAddRes" runat="server" Text="Add Restaurant" OnClick="btnAddRes_Click" />
            &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Back to login page" OnClick="btnLogin_Click" />

            </fieldset>
            </div>
        


    </form>
</body>
</html>
