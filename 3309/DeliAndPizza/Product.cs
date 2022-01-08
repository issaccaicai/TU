// Decompiled with JetBrains decompiler
// Type: DeliAndPizza.Product
// Assembly: DeliAndPizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CF744D53-6C49-463D-B480-443B205721EC
// Assembly location: C:\Users\YING\Desktop\CIS+3309+Section+4+Comprehensive+Project\SampleExe\bin\Debug\DeliAndPizza.exe

namespace DeliAndPizza
{
  internal class Product
  {
    public Toppings tops;

    public string Type { get; set; }

    public string Name { get; set; }

    public double BasePrice { get; set; }

    public string Size { get; set; }

    public Product()
    {
      this.tops = (Toppings) null;
    }

    public Product(Toppings tops)
    {
      this.tops = tops.Copy();
    }

    public Product(string type, string name, double basePrice, string size)
    {
      this.Type = type;
      this.Name = name;
      this.BasePrice = basePrice;
      this.Size = size;
      this.tops = (Toppings) null;
    }

    public Product(string type, string name, double basePrice, string size, Toppings tops)
    {
      this.Type = type;
      this.Name = name;
      this.BasePrice = basePrice;
      this.Size = size;
      this.tops = tops.Copy();
    }

    public override string ToString()
    {
      string str = this.Type + " " + this.Name + " " + this.Size + " " + this.BasePrice.ToString("C");
      if (this.tops != null)
      {
        for (int index = 0; index < 6; ++index)
        {
          if (this.tops.ToppingList[index])
            str = str + "\r\n\t" + this.tops.ToppingNames[index] + "  " + this.tops.ToppingPrices[index].ToString("C");
        }
        str = str + "\r\nProduct total price: " + this.Price().ToString("C");
      }
      return str;
    }

    public double Price()
    {
      double basePrice = this.BasePrice;
      if (this.tops != null)
      {
        for (int index = 0; index < this.tops.ToppingList.Length; ++index)
        {
          if (this.tops.ToppingList[index])
            basePrice += this.tops.ToppingPrices[index];
        }
      }
      return basePrice;
    }
  }
}
