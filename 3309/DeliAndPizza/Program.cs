// Decompiled with JetBrains decompiler
// Type: DeliAndPizza.Program
// Assembly: DeliAndPizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CF744D53-6C49-463D-B480-443B205721EC
// Assembly location: C:\Users\YING\Desktop\CIS+3309+Section+4+Comprehensive+Project\SampleExe\bin\Debug\DeliAndPizza.exe

using System;
using System.Windows.Forms;

namespace DeliAndPizza
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new frmMain());
    }
  }
}
