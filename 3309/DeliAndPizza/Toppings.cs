

using System.Collections.Generic;
using System.Linq;

namespace DeliAndPizza
{
  internal class Toppings
  {
    public bool[] ToppingList;
    public string[] ToppingNames;
    public double[] ToppingPrices;

    public Toppings(int length)
    {
      this.ToppingList = new bool[length];
      this.ToppingNames = new string[length];
      this.ToppingPrices = new double[length];
    }

    public bool[] CopyToppingList()
    {
      bool[] flagArray = new bool[((IEnumerable<bool>) this.ToppingList).Count<bool>()];
      for (int index = 0; index < this.ToppingList.Length; ++index)
        flagArray[index] = this.ToppingList[index];
      return flagArray;
    }

    public string[] CopyToppingNames()
    {
      string[] strArray = new string[((IEnumerable<string>) this.ToppingNames).Count<string>()];
      for (int index = 0; index < this.ToppingNames.Length; ++index)
        strArray[index] = this.ToppingNames[index];
      return strArray;
    }

    public double[] CopyToppingPrices()
    {
      double[] numArray = new double[((IEnumerable<double>) this.ToppingPrices).Count<double>()];
      for (int index = 0; index < this.ToppingPrices.Length; ++index)
        numArray[index] = this.ToppingPrices[index];
      return numArray;
    }

    public Toppings Copy()
    {
      return new Toppings(this.ToppingList.Length)
      {
        ToppingList = this.CopyToppingList(),
        ToppingNames = this.CopyToppingNames(),
        ToppingPrices = this.CopyToppingPrices()
      };
    }

    public override string ToString()
    {
      string str = "";
      for (int index = 0; index < this.ToppingList.Length; ++index)
        str = str + this.ToppingList[index].ToString() + " " + this.ToppingNames[index] + " " + this.ToppingPrices[index].ToString("C") + "\r\n";
      return str;
    }
  }
}
