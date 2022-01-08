<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="Project3.reservation" %>

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
    <header>All Reservations</header>
    <form id="form1" runat="server">
        <div id="btn" style="margin-left:auto; margin-right:auto;">
            <fieldset>
            <asp:Label ID="lblVal" runat="server"></asp:Label>

                <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search Page" OnClick="btnSearch_Click" />
                &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Back to login page" OnClick="btnLogin_Click" />
            &nbsp;</fieldset>
            <br />
            <asp:GridView ID="gvDisplayReservation" runat="server" AutoGenerateColumns="false" align="center">
            <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="reservationId" HeaderText="Reservation Id" />
                    <asp:BoundField DataField="restaurantId" HeaderText="Restaurant Id" />
                    <asp:BoundField DataField="reservationName" HeaderText="Reservation Name" />
                    <asp:BoundField DataField="reservationTime" HeaderText="Reservation Time" />
                    <asp:BoundField DataField="reservationSize" HeaderText="Reservation Size" />
                    <asp:BoundField DataField="reservationDate" HeaderText="Reservation Date" />
                    <asp:BoundField DataField="restaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="representativeId" HeaderText="Representative ID" />
                    <asp:BoundField DataField="representativeName" HeaderText="Representative Name" />
                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>

        </asp:GridView>

            <br /><br />
            &nbsp;<asp:Button ID="btnModifyReservation" runat="server" Text="Modify Reservation" OnClick="btnModifyReservation_Click" />
            &nbsp;<asp:Button ID="btnDeleteReservation" runat="server" Text="Delete Reservation" OnClick="btnDeleteReservation_Click" />





             <asp:Panel id="modifyPanel" runat="server">
                 <asp:Label ID="lblName" runat="server" Text="Your Name: "></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="valName" runat="server"
            ControlToValidate="txtName" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
            <br />


            <asp:Label ID="lblDate" runat="server" Text="Reservation Date: "></asp:Label>

            <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="valDate" runat="server"
            ControlToValidate="txtDate" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
            <br />


            <asp:Label ID="lblTime" runat="server" Text="Reservation Time: "></asp:Label>
                

            <select name="ddlTime" id="ddlTime" style="color:deepskyblue;">
	            <option value="5:00 - 5:30 PM">5:00 - 5:30 PM</option>                <option value="5:30 - 6:00 PM">5:30 - 6:00 PM</option>                <option value="6:00 - 6:30 PM">6:00 - 6:30 PM</option>                <option value="6:30 - 7:00 PM">6:30 - 7:00 PM</option>                <option value="7:00 - 7:30 PM">7:00 - 7:30 PM</option>                <option value="7:30 - 8:00 PM">7:30 - 8:00 PM</option>                <option value="8:00 - 8:30 PM">8:00 - 8:30 PM</option>                <option value="8:30 - 9:00 PM">8:30 - 9:00 PM</option>                <option value="9:00 - 9:30 PM">9:00 - 9:30 PM</option>                <option value="9:30 - 10:00 PM">9:30 - 10:00 PM</option>            </select>
            <br />
            <asp:Label ID="lblSize" runat="server" Text="Number of People: "></asp:Label>
                <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="valSize" runat="server"
            ControlToValidate="txtSize" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
            <br /><br />
                 <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
                 &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </asp:Panel>

        </div>





    </form>
</body>
</html>
