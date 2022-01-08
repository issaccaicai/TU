using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestLib;
using Utilities;

namespace APITest
{
    public partial class Wishlist : System.Web.UI.Page
    {
        int count = 1;

        ArrayList productlist = new ArrayList();
        DBConnect objDB = new DBConnect();
        //string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/RecordPurchase/";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                ViewState["cart"] = lbCart.Text;
                showCart();
            }

        }
        public void showCart() { 
            productlist = (ArrayList)Session["Productlist"];
            gvCart.DataSource = productlist;

            String[] productid = new string[1];
            productid[0] = "ProductNumber";
            gvCart.DataKeyNames = productid;
            gvCart.DataBind();
        }
        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            productlist = (ArrayList)Session["Productlist"];

            productlist.RemoveAt(row);

            Session["ProductList"] = productlist;

            showCart();
        }

        protected void gvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewState["count"] != null)
            {
                count = (int)ViewState["count"] + 1;
            }

            lbCart.Text = ViewState["cart"].ToString() + "(" + count.ToString() + ")";
            ViewState["count"] = count;

            int rowIndex = gvCart.SelectedIndex;

            Product product = new Product();
            product.productTitle = gvCart.SelectedRow.Cells[0].Text;
            product.description = gvCart.SelectedRow.Cells[1].Text;

            product.price = Convert.ToDouble(gvCart.SelectedRow.Cells[2].Text);
            product.imageURL = (gvCart.SelectedRow.Cells[3].Text.ToString());

            TextBox tb = (TextBox)gvCart.SelectedRow.FindControl("txtQuantity");
            product.productNumber = (gvCart.DataKeys[rowIndex].Value.ToString()).ToString();

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

        //protected void btnAddtoCart_Click(object sender, EventArgs e)
        //{

            
        //}

        protected void lbCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void lbAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAccountPage.aspx");
        }

        protected void lbWishlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wishlist.aspx");
        }
    }
}