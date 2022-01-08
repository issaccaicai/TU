using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Globalization;
using System.Drawing;
using BookLibrary;

using Utilities;
using System.Data;

namespace Project2
{
    public partial class bookStore : System.Web.UI.Page
    {
        ArrayList arrBooks = new ArrayList();
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                String strSQL = "SELECT * FROM Books";
                gvBooks.DataSource = objDB.GetDataSet(strSQL);
                gvBooks.DataBind();

            }

            lblPerson.Visible = false;

        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            string name = this.txtName.Text;
            string address = this.txtAddress.Text;
            string phone = this.txtPhone.Text;

            if (id == "")
            {
                txtId.Text = "Please enter your ID.";
                lblPerson.Visible = false;
            }
            else if (name == "")
            {
                txtName.Text = "Please enter your name.";
                lblPerson.Visible = true;
            }
            else if (address == "")
            {
                txtAddress.Text = "Please enter your address.";
                lblPerson.Visible = true;
            }
            else if (phone == "")
            {
                txtPhone.Text = "Please enter your phone number.";
                lblPerson.Visible = true;
            }
            else
            {
                lblPerson.Text = "Student ID: " + id + "<br>" +
                                "Student Name: " + name + "<br>" +
                                    "Address: " + address + "<br>" +
                                        "Phone Number: " + phone + "<br>" +
                                            "Campus: " + Request["Campuses"];
                lblPerson.Visible = true;
            }
            
            int sumChkBox = 0;
            double sum = 0;
            for (int row = 0; row < gvBooks.Rows.Count; row++)
            {
                double oldSales = 0;
                double totalSales = 0;
                CheckBox Cbox = (CheckBox)gvBooks.Rows[row].FindControl("chkSelect");

                if (Cbox.Checked)
                {
                    sumChkBox = sumChkBox + 1;
                    TextBox quantity = (TextBox)gvBooks.Rows[row].FindControl("txtQty");
                    if (quantity.Text == "")
                    {
                        Response.Write ("Please enter a quantity for the book.");
                        return;
                    }
                    else if (Int32.Parse(quantity.Text) < 0)
                    {
                        Response.Write("Quantity needs to be greater than 0.");
                        return;
                    }
                    var book = new BookInfo();

                    // String Authors = gvBooks.DataKeys[row].Value.ToString();
                    book.Title = gvBooks.Rows[row].Cells[1].Text;
                    book.ISBN = gvBooks.Rows[row].Cells[3].Text;
                    book.Type = ((DropDownList)gvBooks.Rows[row].FindControl("DDType")).SelectedValue;
                    book.RB = ((DropDownList)gvBooks.Rows[row].FindControl("DDRB")).SelectedValue;
                    //double Price = priceCal.Calculation(book.ISBN, book.Type, book.RB);
                    //book.Price = priceCal.Calculation(book.Title,book.Type,book.RB);

                    book.Quantity = Convert.ToInt32(((TextBox)gvBooks.Rows[row].FindControl("txtQty")).Text);
                    string sqlPrice = "SELECT * FROM Books WHERE ISBN = '" + book.ISBN + "'";
                    objDB.GetDataSet(sqlPrice);
                    book.Price = Convert.ToDouble(objDB.GetField("BasePrice", 0));

                    if(book.RB == "Rent")
                    {
                        string sqlRented = "SELECT * FROM Books WHERE ISBN = '" + book.ISBN + "'";
                        objDB.GetDataSet(sqlRented);
                        int rented = Convert.ToInt16(objDB.GetField("TotalQuantityRented", 0));
                        rented = rented + book.Quantity;
                        string sqlUpdate = "UPDATE Books SET TotalQuantityRented = " + rented + "WHERE ISBN = '" + book.ISBN + "'";
                        objDB.DoUpdate(sqlUpdate);

                        book.Price = book.Price * 0.85;
                        if(book.Type == "Hardcover")
                        {
                            book.Price = book.Price * 1.5;
                        }
                        else if(book.Type == "Paper-Back")
                        {
                            book.Price = book.Price * 1;
                        }
                        else if (book.Type == "E-Book")
                        {
                            book.Price = book.Price * 0.9;
                        }
                    }
                    else if(book.RB == "Buy")
                    {
                        book.Price = book.Price * 1;

                        string sqlRented = "SELECT * FROM Books WHERE ISBN = '" + book.ISBN + "'";
                        objDB.GetDataSet(sqlRented);
                        int sold = Convert.ToInt16(objDB.GetField("TotalQuantitySold", 0));
                        sold = sold + book.Quantity;
                        string sqlUpdate = "UPDATE Books SET TotalQuantitySold = " + sold + "WHERE ISBN = '" + book.ISBN + "'";
                        objDB.DoUpdate(sqlUpdate);

                        if (book.Type == "Hardcover")
                        {
                            book.Price = book.Price * 1.5;
                        }
                        else if (book.Type == "Paper-Back")
                        {
                            book.Price = book.Price * 1;
                        }
                        else if (book.Type == "E-Book")
                        {
                            book.Price = book.Price * 0.9;
                        }

                    }

                    
                    book.TotalCost = book.Quantity * book.Price;
                    arrBooks.Add(book);
                    sum = sum + book.TotalCost;
                    string sqlSales= "SELECT * FROM Books WHERE ISBN = '" + book.ISBN + "'";
                    objDB.GetDataSet(sqlSales);
                    oldSales = Convert.ToDouble(objDB.GetField("TotalSales", 0));
                    totalSales = oldSales + book.TotalCost;
                    string sqlUpdateSales = "UPDATE Books SET TotalSales = " + totalSales + "WHERE ISBN = '" + book.ISBN + "'";
                    objDB.DoUpdate(sqlUpdateSales);
                    gvBooks.Visible = false;
                }
                
                gvOutput.DataSource = arrBooks;
                gvOutput.Columns[0].FooterText = "Totals";
                gvOutput.Columns[6].FooterText = sum.ToString("C");

                gvOutput.Visible = true;
                gvOutput.DataBind();

                string sql = "SELECT * FROM Books ORDER BY Title";
                gvSummary.DataSource = objDB.GetDataSet(sql);
                gvSummary.DataBind();
                gvSummary.Visible = true;

            }
            
            if (sumChkBox == 0)
            {
                Response.Write("Please check off one book at least.");
            }


        }
        
    }
}