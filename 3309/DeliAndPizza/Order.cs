// Decompiled with JetBrains decompiler
// Type: DeliAndPizza.Order
// Assembly: DeliAndPizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CF744D53-6C49-463D-B480-443B205721EC
// Assembly location: C:\Users\YING\Desktop\CIS+3309+Section+4+Comprehensive+Project\SampleExe\bin\Debug\DeliAndPizza.exe

using System;
using System.Collections.Generic;

namespace DeliAndPizza
{
  internal class Order : List<Product>
  {
    public DateTime date;

    public int OrderNumber { get; set; }

    public void SetDate()
    {
      this.date = DateTime.Now;
    }

    public double SubTotal()
    {
      double num = 0.0;
      foreach (Product product in (List<Product>) this)
        num += product.Price();
      return num;
    }

    public double SalesTax()
    {
      return this.SubTotal() * 0.08;
    }

    public double Total()
    {
      return this.SubTotal() + this.SalesTax();
    }

    public override string ToString()
    {
      string str = "Ying Deli&Pizza\r\n" + "Receipt No.: " + (object) this.OrderNumber + "\r\n" + "Date/time: " + this.date.ToShortDateString() + " " + this.date.ToShortTimeString() + "\r\n\r\n";
      foreach (Product product in (List<Product>) this)
        str = str + product.ToString() + "\r\n\r\n";
      return str + "\r\nSubtotal: " + this.SubTotal().ToString("C") + "\r\n" + "Sales Tax: " + this.SalesTax().ToString("C") + "\r\n" + "Totalotal: " + this.Total().ToString("C") + "\r\n";
    }
  }
}
