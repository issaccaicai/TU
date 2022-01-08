<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Project3.login" %>

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
    <header>Temple Restaurant Review System</header>
    <form id="form1" runat="server">
        
        <div id="btn">


        <br />
            <asp:Label ID="lblTest" runat="server"></asp:Label>

            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Back to login page" />

         <br /><br />
        <asp:Button ID="btnReviewer" runat="server" Text="Reviewer" OnClick="btnReviewer_Click" />
        &nbsp;<asp:Button ID="btnRepresentative" runat="server" Text="Representative" OnClick="btnRepresentative_Click" />
        

        
        &nbsp;<asp:Button ID="btnCreate" runat="server" Text="Create an account" OnClick="btnCreate_Click" />

            
        &nbsp;<asp:Button ID="btnVisitor" runat="server" Text="Visitor" OnClick="btnVisitor_Click" />





        <br /><br />

        <asp:Label ID="lblId" runat="server" Text="Your ID: "></asp:Label>

        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <asp:Label ID="lblVal" runat="server" Text="Label"></asp:Label>
            <asp:RequiredFieldValidator ID="valId" runat="server"
            ControlToValidate="txtId" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
            <%--<asp:Label ID="lblDes" runat="server" Text="Labe2"></asp:Label>--%>
        <br /><br />

        <asp:Button ID="btnSubmitId" runat="server" Text="Submit" OnClick="btnSubmitId_Click" />
        &nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <br />
        <br />




        <asp:Button ID="btnSearch" runat="server" Text="Search Page" OnClick="btnSearch_Click" />

        &nbsp;<br /><br />



        <asp:Button ID="btnMyReviews" runat="server" Text="All the reviews" OnClick="btnMyReviews_Click" />
        &nbsp;<asp:Button ID="AddRestaurant" runat="server" Text="Add a restaurant" OnClick="AddRestaurant_Click" />
        &nbsp;<asp:Button ID="btnReservation" runat="server" Text="Reservation Page" OnClick="btnReservation_Click" />
            <br />
            <br />
            <br />
        <br /><br />

                  <asp:GridView ID="gvReview" runat="server" AutoGenerateColumns="false" CssClass="auto-style1" align="center">



                
            <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="reviewerId" HeaderText="Reviewer ID" />
                    

                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>
            </asp:GridView>

            &nbsp;
                              <asp:GridView ID="gvRP" runat="server" AutoGenerateColumns="false" CssClass="auto-style1" align="center">



                
            <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="representativeId" HeaderText="Representative ID" />
                    

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
