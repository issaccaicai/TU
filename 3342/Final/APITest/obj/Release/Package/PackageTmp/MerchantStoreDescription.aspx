<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantStoreDescription.aspx.cs" Inherits="APITest.MerchantStoreDescription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>Description</legend>

            <h3>Department Class</h3>
            <h5>Fields</h5>
            <p>- DepartmentNumber </p>
            <p>- DepartmentName </p>

            <br />

                        <h3>Product Class</h3>
            <h5>Fields</h5>
            <p>- ProductNumber </p>
            <p>- Description </p>
            <p>- Price </p>
            <p>- ImageURL </p>
            <p>- DepartmentNumber </p>

            <br />

                        <h3>Customer Class</h3>
            <h5>Fields</h5>
            <p>- CustomerId </p>
            <p>- CustomerName </p>
            <p>- CustomerPhone </p>
            <p>- CustomerEmail </p>
            <p>- TotalDollarSales </p>

            <br />

            <h3>RecordPurchase Class</h3>
            <h5>Fields</h5>
            <p>- ProductNumber </p>
            <p>- Quantity </p>
            <p>- SiteID </p>
            <p>- APIKey </p>
            <p>- CustomerId </p>
            <p>- CustomerName </p>
            <p>- CustomerPhone </p>
            <p>- CustomerEmail </p>


                        <h3>RegisterSite Class</h3>
            <h5>Fields</h5>

            <p>- SiteID </p>
            <p>- Description </p>
            <p>- APIKey </p>
            <p>- Email </p>
            <p>- ContactInformation </p>


            <br /><br /><br />
            <h1>Documentation</h1>
            <h4>GetDepartments Mehthod</h4>
            <p>This method will get all departmetns by clicking the button.</p>
            <p> http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/GetDepartments/ </p>
            

            <br />
            

            <h4>Get All Products by Department Number Mehthod</h4>
            <p>This method will get all products by entering department number the button.</p>
            <p> http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/GetProductCatalog/{departmentNumber} </p>
            
            <br />

            <h4>RegisterSite Method will add merchant to the database by adding SiteID, Description, APIkey, Email, and Contact Information.</h4>
            <p>This method will get all products by entering department number the button.</p>
            <p> http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/RegisterSite/ </p>


                <br /><br />

            <h4>RecordPurchase Method will add record the purchase made by customer to the database by entering ProductName, Quantity, SiteID, APIkey, and Customer ID From database.</h4>
            <p>This method will get all products by entering department number the button.</p>
                <p> http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/RecordPurchase/ </p>
                <br />
        </fieldset>

    </form>
</body>
</html>
