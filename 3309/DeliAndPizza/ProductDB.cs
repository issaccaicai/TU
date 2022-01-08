// Decompiled with JetBrains decompiler
// Type: DeliAndPizza.ProductDB
// Assembly: DeliAndPizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CF744D53-6C49-463D-B480-443B205721EC
// Assembly location: C:\Users\YING\Desktop\CIS+3309+Section+4+Comprehensive+Project\SampleExe\bin\Debug\DeliAndPizza.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DeliAndPizza
{
  internal static class ProductDB
  {
    public static string GetConnectionString()
    {
      return File.ReadAllText("..\\..\\DeliAndPizzaConStr.txt");
    }

    public static OleDbConnection GetConnection()
    {
      return new OleDbConnection(ProductDB.GetConnectionString());
    }

    public static Toppings GetToppings(string ProductType)
    {
      int index = 0;
      Toppings toppings = (Toppings) null;
      OleDbConnection connection = ProductDB.GetConnection();
      OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM Toppings WHERE ProductType = @ProductType ORDER BY ToppingName", connection);
      oleDbCommand.Parameters.AddWithValue("@ProductType", (object) ProductType);
      try
      {
        toppings = new Toppings(6);
        connection.Open();
        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.SingleResult);
        while (oleDbDataReader.Read())
        {
          toppings.ToppingList[index] = false;
          toppings.ToppingNames[index] = (string) oleDbDataReader["ToppingName"];
          toppings.ToppingPrices[index] = (double) oleDbDataReader["ToppingPrice"];
          ++index;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        toppings = (Toppings) null;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      return toppings;
    }

    public static double GetProductPrice(string ProductName)
    {
      double num1 = -1.0;
      OleDbConnection connection = ProductDB.GetConnection();
      OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM Products WHERE ProductName = @ProductName", connection);
      oleDbCommand.Parameters.AddWithValue("@ProductName", (object) ProductName);
      try
      {
        connection.Open();
        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.SingleRow);
        if (oleDbDataReader.Read())
          num1 = (double) oleDbDataReader["ProductBasePrice"];
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.ToString());
        num1 = -1.0;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      return num1;
    }

    public static int GetMaxOrderID()
    {
      int num1 = -1;
      OleDbConnection connection = ProductDB.GetConnection();
      OleDbCommand oleDbCommand = new OleDbCommand("SELECT MAX(OrderID) FROM Orders", connection);
      try
      {
        connection.Open();
        num1 = Convert.ToInt32(oleDbCommand.ExecuteScalar());
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.ToString());
        num1 = -1;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      return num1;
    }

    public static int InsertOrder(Order order)
    {
      return ProductDB.InsertOrder(order.date, order.SubTotal(), order.SalesTax(), order.Total(), (List<Product>) order);
    }

    public static int InsertOrder(DateTime OrderDate, double OrderSubTotal, double OrderSalesTax, double OrderTotal, List<Product> pl)
    {
      int num1 = -1;
      string s = OrderDate.ToString();
      OleDbConnection connection = ProductDB.GetConnection();
      OleDbCommand oleDbCommand = new OleDbCommand("INSERT INTO Orders (OrderDate, OrderSubTotal, OrderSalesTax, OrderTotal) VALUES (@OrderDate, @OrderSubTotal, @OrderSalesTax, @OrderTotal)", connection);
      oleDbCommand.Parameters.AddWithValue("@OrderDate", (object) OleDbType.DBTimeStamp).Value = (object) DateTime.Parse(s);
      oleDbCommand.Parameters.AddWithValue("@OrderSubTotal", (object) OrderSubTotal);
      oleDbCommand.Parameters.AddWithValue("@OrderSalesTax", (object) OrderSalesTax);
      oleDbCommand.Parameters.AddWithValue("@OrderTotal", (object) OrderTotal);
      try
      {
        connection.Open();
        num1 = oleDbCommand.ExecuteNonQuery();
        connection.Close();
        connection.Open();
        int maxOrderId = ProductDB.GetMaxOrderID();
        foreach (Product product in pl)
          ProductDB.InsertLineItem(maxOrderId, product);
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.ToString());
        num1 = -1;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      return num1;
    }

    public static int GetMaxLineItemID()
    {
      int num1 = -1;
      OleDbConnection connection = ProductDB.GetConnection();
      OleDbCommand oleDbCommand = new OleDbCommand("SELECT MAX(LineItemID) FROM LineItems", connection);
      try
      {
        connection.Open();
        num1 = Convert.ToInt32(oleDbCommand.ExecuteScalar());
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.ToString());
        num1 = -1;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      return num1;
    }

    public static int InsertLineItem(int OrderID, Product product)
    {
      return ProductDB.InsertLineItem(OrderID, product.Name, product.Size, product.BasePrice, product.Price(), product.tops);
    }

    public static int InsertLineItem(int OrderID, string ProductName, string ProductSize, double ProductBasePrice, double ProductTotalPrice, Toppings tops)
    {
      int num1 = -1;
      OleDbConnection connection = ProductDB.GetConnection();
      OleDbCommand oleDbCommand = new OleDbCommand("INSERT INTO LineItems (OrderID, ProductName, ProductSize, ProductBasePrice, ProductTotalPrice) VALUES (@OrderID, @ProductName, @ProductSize, @ProductBasePrice, @ProductTotalPrice)", connection);
      oleDbCommand.Parameters.AddWithValue("@OrderID", (object) OrderID);
      oleDbCommand.Parameters.AddWithValue("@ProductName", (object) ProductName);
      oleDbCommand.Parameters.AddWithValue("@ProductSize", (object) ProductSize);
      oleDbCommand.Parameters.AddWithValue("@ProductBasePrice", (object) ProductBasePrice);
      oleDbCommand.Parameters.AddWithValue("@ProductTotalPrice", (object) ProductTotalPrice);
      try
      {
        connection.Open();
        num1 = oleDbCommand.ExecuteNonQuery();
        connection.Close();
        connection.Open();
        int maxLineItemId = ProductDB.GetMaxLineItemID();
        if (tops != null)
        {
          for (int index = 0; index < tops.ToppingList.Length; ++index)
          {
            if (tops.ToppingList[index])
              ProductDB.InsertLineItemTopping(maxLineItemId, tops.ToppingNames[index], tops.ToppingPrices[index]);
          }
        }
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.ToString());
        num1 = -1;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      return num1;
    }

    public static int InsertLineItemTopping(int LineItemID, string ToppingName, double ToppingPrice)
    {
      int num1 = -1;
      OleDbConnection connection = ProductDB.GetConnection();
      OleDbCommand oleDbCommand = new OleDbCommand("INSERT INTO LineItemToppings (LineItemID, ToppingName, ToppingPrice) VALUES (@LineItemID, @ToppingName, @ToppingPrice)", connection);
      oleDbCommand.Parameters.AddWithValue("@LineItemID", (object) LineItemID);
      oleDbCommand.Parameters.AddWithValue("@ToppingName", (object) ToppingName);
      oleDbCommand.Parameters.AddWithValue("@ToppingPrice", (object) ToppingPrice);
      try
      {
        connection.Open();
        num1 = oleDbCommand.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.ToString());
        num1 = -1;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
      return num1;
    }
  }
}
