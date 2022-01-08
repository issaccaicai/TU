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
    public partial class Cart : System.Web.UI.Page
    {
        StoredProcedures procedures = new StoredProcedures();
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/RecordPurchase/";
        //string url = "http://localhost:6762/api/service/Merchants/RecordPurchase/";
        ArrayList productlist = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCart(ShowTotalPrice());
            }
        }

        public void showCart(double totalcost)
        {
            gvCart.Columns[0].FooterText = "Total Amount";
            gvCart.Columns[4].FooterText = totalcost.ToString("C2");
            productlist = (ArrayList)Session["Productlist"];
            gvCart.DataSource = productlist;

            String[] productid = new string[1];
            productid[0] = "ProductNumber";
            gvCart.DataKeyNames = productid;
            gvCart.DataBind();
        }
        
        public double ShowTotalPrice()
        {
            productlist = (ArrayList)Session["Productlist"];
            double total = 0.0;
            foreach (Product p in productlist)
            {
                double price = p.price;
                int quantity = p.quantity;
                total += p.TotalCost(p.price, p.quantity);
                
            }
            lblTotal.Text = total.ToString();
            return total;
        }
        protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCart.EditIndex = e.NewEditIndex;

            showCart(ShowTotalPrice());
        }
        
        protected void gvCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCart.EditIndex = -1;

            showCart(ShowTotalPrice());
        }
        
        protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            productlist = (ArrayList)Session["Productlist"];

            Product product = (Product)productlist[rowIndex];

            TextBox TBox;
            TBox = (TextBox)gvCart.Rows[rowIndex].Cells[3].Controls[0];
            int quantity = Int32.Parse(TBox.Text);
            product.quantity = quantity;

            Session["ProductList"] = productlist;
            gvCart.EditIndex = -1;
            showCart(ShowTotalPrice());

        }
        protected void gvCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
           
            Product product = new Product();
            JavaScriptSerializer js = new JavaScriptSerializer();
            UpdateQuantity();

            if (product.quantity == 0)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = "NO Products in your cart!";
            }

            for (int row = 0; row < gvCart.Rows.Count; row++)
            {
                DateTime now = DateTime.Now;
                string time = (now.ToString("F"));
                product.quantity = Convert.ToInt32(gvCart.Rows[row].Cells[3].Text);
                product.customerId = Convert.ToInt32(Session["customerID"].ToString());
                product.productNumber = gvCart.DataKeys[row].Value.ToString();
                product.total = Convert.ToDouble(lblTotal.Text);
                product.time = time;
                String jsonCheckout = js.Serialize(product);
                
                
                    try
                    {
                        WebRequest request = WebRequest.Create(url);
                        request.Method = "POST";
                        request.ContentLength = jsonCheckout.Length;
                        request.ContentType = "application/json";
                    
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonCheckout);
                        writer.Flush();
                        writer.Close();
                    
                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();
                        reader.Close();
                        response.Close();

                        if (data == "true")
                        {
                            lblSuccess.Visible = true;
                        }
                        else
                        {
                            lblDisplay.Text = "A problem occurred.";
                        }
                        
                        Response.Redirect("Purchase.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblDisplay.Text = "Error: " + ex.Message;
                    }
                
            }

        }
        protected void UpdateQuantity()
        {
            productlist = (ArrayList)Session["Productlist"];
            foreach (Product p in productlist)
            {
                int qty = p.quantity;
                string number = p.productNumber;

                objCommand.Parameters.Clear();
                procedures.UpdateInventory(qty, number);

                objDB.DoUpdateUsingCmdObj(objCommand);
            }
        }
        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            productlist = (ArrayList)Session["Productlist"];

            productlist.RemoveAt(row);

            Session["ProductList"] = productlist;

            showCart(ShowTotalPrice());
        }

        protected void lbAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAccountPage.aspx");
        }

        protected void lbWishlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wishlist.aspx");
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

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shopping.aspx");
        }
    }
}