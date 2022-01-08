using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestLib;
using Utilities;

namespace APITest
{
    public partial class Shopping : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        int count = 1;
        ArrayList productlist = new ArrayList();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/";
        //string url = "http://localhost:6762/api/service/Merchants/";

        string knoxApi = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug41822/TermProjectWS/api/service/Merchants/";
        string otherApi = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tuf83908/TermProjectWS/api/service/Merchants/";


        protected void Page_Load(object sender, EventArgs e)
        {
            //string a = Session["username"].ToString();
            //lblMessage.Text = a;
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else if (!IsPostBack)
            {
                WebRequest request = WebRequest.Create(url + "GetDepartments/");
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Department[] departments = js.Deserialize<Department[]>(data);

                ddlDepartment.DataSource = departments;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentNumber";
                ddlDepartment.DataBind();

                ViewState["cart"] = lbCart.Text;




                WebRequest request2 = WebRequest.Create(knoxApi + "GetDepartments/");
                WebResponse response2 = request2.GetResponse();

                Stream theDataStream2 = response2.GetResponseStream();
                StreamReader reader2 = new StreamReader(theDataStream2);
                String data2 = reader2.ReadToEnd();
                reader2.Close();
                response2.Close();

                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Department[] departments2 = js2.Deserialize<Department[]>(data2);

                ddlDepartment2.DataSource = departments2;
                ddlDepartment2.DataTextField = "DepartmentName";
                ddlDepartment2.DataValueField = "departmentID";
                ddlDepartment2.DataBind();

                ViewState["cart"] = lbCart.Text;





                WebRequest request3 = WebRequest.Create(otherApi + "GetDepartments/");
                WebResponse response3 = request3.GetResponse();

                Stream theDataStream3 = response3.GetResponseStream();
                StreamReader reader3 = new StreamReader(theDataStream3);
                String data3 = reader3.ReadToEnd();
                reader3.Close();
                response3.Close();

                JavaScriptSerializer js3= new JavaScriptSerializer();
                Department[] departments3 = js3.Deserialize<Department[]>(data3);

                ddlDepartment3.DataSource = departments3;
                ddlDepartment3.DataTextField = "DepartmentName";
                ddlDepartment3.DataValueField = "DepartmentID";
                ddlDepartment3.DataBind();

                ViewState["cart"] = lbCart.Text;











                DisplayProduct();
                ShowSandKDepartments();
                ShowOtherDepartments();
            }

        }

        //public void ShowOurDepartments()
        //{
        //    WebRequest request = WebRequest.Create(apiURL + "GetDepartments/");
        //    WebResponse response = request.GetResponse();

        //    Stream theDataStream = response.GetResponseStream();
        //    StreamReader sr = new StreamReader(theDataStream);

        //    string data = sr.ReadToEnd();

        //    sr.Close();
        //    response.Close();

        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    List<Departments> departments = js.Deserialize<List<Departments>>(data);

        //    reptDepartmentOurs.DataSource = departments;
        //    reptDepartmentOurs.DataBind();


        //}
        public void ShowSandKDepartments()
        {
            
            WebRequest request = WebRequest.Create(knoxApi + "GetDepartments/");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(theDataStream);

            string data = sr.ReadToEnd();
            JArray array = new JArray();
            Department dept = new Department();
            foreach (JObject jobj in array)
            {
                int count = 0;
                foreach (JProperty property in jobj.Properties())
                {
                    if (count == 0)
                    {

                        dept.DepartmentID = property.Value.ToString();
                        //the value = deptID
                    }
                    else if (count == 1)
                    {
                        dept.DepartmentName = property.Value.ToString();

                    }
                    else if (count == 2)
                    {

                        dept.DepartmentImageURL = property.Value.ToString();

                    }

                }
            }

            sr.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Department> departments = js.Deserialize<List<Department>>(data);

            gvDepartment2.DataSource = departments;
            gvDepartment2.DataBind();


        }


        public void ShowOtherDepartments()
        {
            WebRequest request = WebRequest.Create(otherApi + "GetDepartments/");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(theDataStream);

            string data = sr.ReadToEnd();

            JArray array = new JArray();

            Department dept = new Department();

            foreach (JObject jobj in array)
            {
                int count = 0;

                foreach (JProperty property in jobj.Properties())
                {
                    if (count == 0)
                    {

                        dept.DepartmentID = property.Value.ToString();
                        //the value = deptID
                    }
                    else if (count == 1)
                    {
                        dept.DepartmentName = property.Value.ToString();

                    }
                    else if (count == 2)
                    {

                        dept.DepartmentImageURL = property.Value.ToString();

                    }

                }
            }

            sr.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Department> departments = js.Deserialize<List<Department>>(data);

            gvDepartment3.DataSource = departments;
            gvDepartment3.DataBind();


        }






        public void DisplayProduct()
        {
            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_GetProducts";
            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);
            gvProducts.DataSource = ds;

            String[] productNumber = new string[1];
            productNumber[0] = "ProductNumber";
            gvProducts.DataKeyNames = productNumber;
            gvProducts.DataBind();
        }

        protected void btnDepartments_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create(url + "GetDepartments/");
            //WebRequest request = WebRequest.Create("http://localhost:6762/api/service/Merchants/GetDepartments/");
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            //InsertCreditCardClass CreditInfo = js.Deserialize<InsertCreditCardClass>(data);

            Department[] departmentInfo = js.Deserialize<Department[]>(data);
            gvDepartments.DataSource = departmentInfo;
            gvDepartments.DataBind();
            gvDepartments.Visible = true;
        }
        protected void btnDisplayAllProducts_Click(object sender, EventArgs e)
        {
            DisplayProduct();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            string departmentNumber = ddlDepartment.SelectedValue;
            url = url + "GetProductCatalog/" + departmentNumber;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Product> products = js.Deserialize<List<Product>>(data);


            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewState["count"] != null)
            {
                count = (int)ViewState["count"] + 1;
            }

            
            lbCart.Text = ViewState["cart"].ToString() + "(" + count.ToString() + ")";
            ViewState["count"] = count;

            int rowIndex = gvProducts.SelectedIndex;

            Product product = new Product();
            product.productTitle = gvProducts.SelectedRow.Cells[0].Text;
            product.description = gvProducts.SelectedRow.Cells[1].Text;
            
            product.price = Convert.ToDouble(gvProducts.SelectedRow.Cells[2].Text);
            product.imageURL = (gvProducts.SelectedRow.Cells[3].Text.ToString());

            TextBox tb = (TextBox)gvProducts.SelectedRow.FindControl("txtQuantity");
            product.productNumber = gvProducts.DataKeys[rowIndex].Value.ToString();
            //product.productId = Convert.ToInt32(gvProducts.DataKeys[rowIndex].Value.ToString());
            product.quantity = Convert.ToInt32(tb.Text);

            if (ViewState["Productlist"] != null)
            {
                productlist = (ArrayList)ViewState["Productlist"];
                productlist.Add(product);
            }
            else
            {
                productlist.Add(product);
            }
            ViewState["Productlist"] = productlist;
            Session["Productlist"] = productlist;

        }

        protected void lbCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
            
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        //protected void btnCustomerAccount_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("CustomerAccountPage.aspx");

        //}

        protected void lbAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAccountPage.aspx");
        }

        protected void lbWishlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wishlist.aspx");
        }

        protected void btnShow2_Click(object sender, EventArgs e)
        {
            int departmentNumber = Int32.Parse(ddlDepartment2.SelectedValue);
            knoxApi = knoxApi + "GetProductCatalog/" + departmentNumber;

            WebRequest request = WebRequest.Create(knoxApi);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Product> products = js.Deserialize<List<Product>>(data);


            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        protected void btnShow3_Click(object sender, EventArgs e)
        {
            int departmentNumber = Int32.Parse(ddlDepartment3.SelectedValue);
            otherApi = otherApi + "GetProductCatalog/" + departmentNumber;

            WebRequest request = WebRequest.Create(otherApi);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Product> products = js.Deserialize<List<Product>>(data);


            gvProducts.DataSource = products;
            gvProducts.DataBind();

        }
    }
}