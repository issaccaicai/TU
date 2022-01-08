// Decompiled with JetBrains decompiler
// Type: DeliAndPizza.Properties.Resources
// Assembly: DeliAndPizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CF744D53-6C49-463D-B480-443B205721EC
// Assembly location: C:\Users\YING\Desktop\CIS+3309+Section+4+Comprehensive+Project\SampleExe\bin\Debug\DeliAndPizza.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DeliAndPizza.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (DeliAndPizza.Properties.Resources.resourceMan == null)
          DeliAndPizza.Properties.Resources.resourceMan = new ResourceManager("DeliAndPizza.Properties.Resources", typeof (DeliAndPizza.Properties.Resources).Assembly);
        return DeliAndPizza.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return DeliAndPizza.Properties.Resources.resourceCulture;
      }
      set
      {
        DeliAndPizza.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
