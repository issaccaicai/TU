<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addReviews.aspx.cs" Inherits="Project3.addReviews" %>

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
    .auto-style1 {
        margin-top: 0px;
    }
</style>
</head>
<body>
    <header>Adding/Modifying reviews</header>
    <form id="form1" runat="server">
        <div id="btn">
            <fieldset>
            <asp:Label ID="lblTest" runat="server"></asp:Label><br />
                <asp:Button ID="btnSearch" runat="server" Text="Search Page" OnClick="btnSearch_Click" />
                &nbsp;<asp:Button ID="AddRestaurant" runat="server" Text="Add a restaurant" OnClick="AddRestaurant_Click" />
                &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Back to login page" OnClick="btnLogin_Click" /></fieldset>
            <%--<asp:Label ID="lblReviewer" runat="server" Text="Enter Reviewer ID: "></asp:Label>
            <asp:TextBox ID="txtReviewerId" runat="server"></asp:TextBox>
            <asp:Label ID="lblVal" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />--%>
            <br />

            <asp:Label ID="lblInfo" runat="server"></asp:Label>
            <br />

            <asp:GridView ID="gvReview" runat="server" AutoGenerateColumns="false" CssClass="auto-style1" align="center">



                
            <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="reviewerId" HeaderText="Reviewer ID" />
                    <asp:BoundField DataField="reviewId" HeaderText="Review ID" />
                    <asp:BoundField DataField="restaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="categoriesName" HeaderText="Categories" />
                    <asp:BoundField DataField="restaurantDesc" HeaderText="Restaurant Description" />
                    <asp:BoundField DataField="comments" HeaderText="Comments" />
                    <asp:BoundField DataField="quality" HeaderText="Quality" />
                    <asp:BoundField DataField="service" HeaderText="Service" />
                    <asp:BoundField DataField="atmosphere" HeaderText="Atmosphere" />
                    <asp:BoundField DataField="price" HeaderText="Price" />

                    <asp:TemplateField HeaderText="Average">
                <ItemTemplate>
                    <%# (Convert.ToInt32(Eval("quality")) + Convert.ToInt32(Eval("service")) 
                            + Convert.ToInt32(Eval("atmosphere")) + Convert.ToInt32(Eval("price")))/4 %>
                </ItemTemplate>
            </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="#71bf23" />
                <FooterStyle BackColor="#c7d2e8" Font-Bold="True" ForeColor="Red" />
                <HeaderStyle BackColor="#71bf23" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#c9d6f2" HorizontalAlign="Center"/>




            </asp:GridView>
            <br />
            <asp:Label ID="lblVa" runat="server"></asp:Label>
            <br />

            <asp:Button ID="btnAddReview" runat="server" Text="Add a review" OnClick="btnAddReview_Click" />
            &nbsp;<asp:Button ID="btnModify" runat="server" Text="Modify review" OnClick="btnModify_Click" />
            &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete a review" OnClick="btnDelete_Click" /><br /><br />
            &nbsp;
            <br /><br />

            <asp:Panel id="myPanel" runat="server">


                <br />
                <asp:Label ID="lblAddName" runat="server" Text="Restaurant Name: "></asp:Label>
                <asp:DropDownList ID="ddlAddName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAddName_SelectedIndexChanged">
                    </asp:DropDownList>
                <br />
                <asp:Label ID="lblComm" runat="server" Text="Restaurant Comments: "></asp:Label>
                <asp:TextBox ID="txtComm" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valComments" runat="server"
            ControlToValidate="txtComm" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblQuality" runat="server" Text="Quality: "></asp:Label>
                <asp:TextBox ID="txtQuality" runat="server"></asp:TextBox>

            <asp:RangeValidator ID="valQuality" runat="server"
            ControlToValidate="txtQuality" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1"></asp:RangeValidator>

                <br />
                <asp:Label ID="lblService" runat="server" Text="Service: "></asp:Label>
                <asp:TextBox ID="txtService" runat="server"></asp:TextBox>

                  <asp:RangeValidator ID="valService" runat="server"
            ControlToValidate="txtService" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1" ></asp:RangeValidator>


                <br />
                <asp:Label ID="lblAtmosphere" runat="server" Text="Atmosphere: "></asp:Label>
                <asp:TextBox ID="txtAtmosphere" runat="server"></asp:TextBox>

                <asp:RangeValidator ID="valAtmo" runat="server"
            ControlToValidate="txtAtmosphere" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1" ></asp:RangeValidator>


                <br />
                <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="valPrice" runat="server"
            ControlToValidate="txtPrice" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1" ></asp:RangeValidator>
                <br />
                <asp:Label ID="lblV" runat="server"></asp:Label>
                <br />
            <asp:Button ID="btnAdd" runat="server" Text="Confirm" OnClick="btnAdd_Click" />


                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                <br /><br />
                <asp:Button ID="btnAddR" runat="server" Text="No Such Restaurant listed? ADD HERE!" OnClick="btnAddR_Click" />
                </asp:Panel>

                <br />

                        <asp:Panel id="modifyPanel" runat="server">
                             <asp:Label ID="lblComments" runat="server" Text="Restaurant Comments: "></asp:Label>
                <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="val1" runat="server"
            ControlToValidate="txtComments" ErrorMessage="* Required" Font-Bold="False"
            ForeColor="#CC0000" ></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblQual" runat="server" Text="Quality: "></asp:Label>
                <asp:TextBox ID="txtQual" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="val2" runat="server"
            ControlToValidate="txtQual" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1" ></asp:RangeValidator>
                <br />
                <asp:Label ID="lblServ" runat="server" Text="Service: "></asp:Label>
                <asp:TextBox ID="txtServ" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="val3" runat="server"
            ControlToValidate="txtServ" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1" ></asp:RangeValidator>
                <br />
                <asp:Label ID="lblAtmo" runat="server" Text="Atmosphere: "></asp:Label>
                <asp:TextBox ID="txtAtmo" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="val4" runat="server"
            ControlToValidate="txtAtmo" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1" ></asp:RangeValidator>
                <br />
                <asp:Label ID="lblPri" runat="server" Text="Price: "></asp:Label>
                <asp:TextBox ID="txtPri" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="val5" runat="server"
            ControlToValidate="txtPri" ErrorMessage="* Invalid Must be 1-5" Font-Bold="False"
            ForeColor="#CC0000"  MaximumValue="5" MinimumValue="1" ></asp:RangeValidator>
                <br />
                <asp:Label ID="lblValid" runat="server"></asp:Label>
                <br />
            <asp:Button ID="btnMod" runat="server" Text="Modify" OnClick="btnMod_Click" />


                &nbsp;<asp:Button ID="btnCanc" runat="server" Text="Cancel" OnClick="btnCanc_Click" />
                <br /><br />
                </asp:Panel>

        </div>



       


    </form>
</body>
</html>
