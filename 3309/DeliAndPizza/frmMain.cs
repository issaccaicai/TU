using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace DeliAndPizza
{
  public class frmMain : Form
  {
    private string dir = "..\\..\\";
    private Point[] btnLocation = new Point[9];
    private int level = 0;
    private IContainer components = (IContainer) null;
    private int sizeX;
    private int sizeY;
    private Product product;
    private Order order;
    private Toppings HoagieToppings;
    private Toppings PizzaToppings;
    private TextBox txtReceipt;
    private Size btnSize;
    private Size totalSize;
    private Point totalPosition;


    
    public frmMain()
    {
      InitializeComponent();
    }


    private void frmMain_Load(object sender, EventArgs e)
    {
      this.level = 0;
      this.WindowState = FormWindowState.Maximized;
      this.ControlBox = false;
      this.FormBorderStyle = FormBorderStyle.None;
      this.BackgroundImage = Image.FromFile(this.dir + "Images/deli1.jpg", true);
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.sizeX = this.Size.Width;
      this.sizeY = this.Size.Height;
      this.btnSize = new Size((int) ((double) this.sizeX / 6.5), (int) ((double) this.sizeY / 6.5));
      this.btnLocation[0] = new Point((int) ((double) this.sizeX / 6.5 * 0.25), (int) ((double) this.sizeY / 6.5));
      this.btnLocation[1] = new Point((int) ((double) this.sizeX / 6.5 * 1.5), (int) ((double) this.sizeY / 6.5));
      this.btnLocation[2] = new Point((int) ((double) this.sizeX / 6.5 * 2.75), (int) ((double) this.sizeY / 6.5));
      this.btnLocation[3] = new Point((int) ((double) this.sizeX / 6.5 * 0.25), (int) ((double) this.sizeY / 6.5 * 2.5));
      this.btnLocation[4] = new Point((int) ((double) this.sizeX / 6.5 * 1.5), (int) ((double) this.sizeY / 6.5 * 2.5));
      this.btnLocation[5] = new Point((int) ((double) this.sizeX / 6.5 * 2.75), (int) ((double) this.sizeY / 6.5 * 2.5));
      this.btnLocation[6] = new Point((int) ((double) this.sizeX / 6.5 * 0.25), (int) ((double) this.sizeY / 6.5 * 5.0));
      this.btnLocation[7] = new Point((int) ((double) this.sizeX / 6.5 * 1.5), (int) ((double) this.sizeY / 6.5 * 5.0));
      this.btnLocation[8] = new Point((int) ((double) this.sizeX / 6.5 * 2.75), (int) ((double) this.sizeY / 6.5 * 5.0));
      this.totalSize = new Size((int) (2.5 * (double) this.sizeX / 6.5 - 25.0), this.sizeY - 50);
      this.totalPosition = new Point((int) ((double) this.sizeX / 6.5 * 4.0), 25);
      this.order = new Order();
      this.txtReceipt = new TextBox();
      this.txtReceipt.Font = new Font(this.txtReceipt.Font.FontFamily, 12f);
      this.HoagieToppings = ProductDB.GetToppings("Hoagie");
      this.PizzaToppings = ProductDB.GetToppings("Pizza");
      this.DrawInitialForm();
    }

    public void DrawInitialForm()
    {
      this.level = 0;
      this.Controls.Clear();
      Button button1 = new Button();
      button1.Text = "Hoagie";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[0];
      Image image1 = Image.FromFile(this.dir + "Images/hoagie.jpg", true);
      button1.BackgroundImage = image1;
      button1.BackgroundImageLayout = ImageLayout.Stretch;
      button1.Click += new EventHandler(this.btnHoagie_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Pizza";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[1];
      Image image2 = Image.FromFile(this.dir + "Images/pizza.jpg", true);
      button2.BackgroundImage = image2;
      button2.BackgroundImageLayout = ImageLayout.Stretch;
      button2.Click += new EventHandler(this.btnPizza_Click);
      this.Controls.Add((Control) button2);
      Button button3 = new Button();
      button3.Text = "Fries";
      button3.Size = this.btnSize;
      button3.Location = this.btnLocation[2];
      Image image3 = Image.FromFile(this.dir + "Images/fries.jpg", true);
      button3.BackgroundImage = image3;
      button3.BackgroundImageLayout = ImageLayout.Stretch;
      button3.Click += new EventHandler(this.btnFries_Click);
      this.Controls.Add((Control) button3);
      Button button4 = new Button();
      button4.Text = "Fries";
      button4.Size = this.btnSize;
      button4.Location = this.btnLocation[4];
      Image image4 = Image.FromFile(this.dir + "Images/soda.jpg", true);
      button4.BackgroundImage = image4;
      button4.BackgroundImageLayout = ImageLayout.Stretch;
      button4.Click += new EventHandler(this.btnSoda_Click);
      this.Controls.Add((Control) button4);
      this.DrawReceipt();
      if (this.order.Count <= 0)
        return;
      this.DrawPlaceOrder();
    }

    public void DrawHoagie()
    {
      this.level = 1;
      this.Controls.Clear();
      Button button1 = new Button();
      button1.Text = "American Hoagie";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[0];
      button1.Click += new EventHandler(this.btnAmericanHoagie_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Italian Hoagie";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[1];
      button2.Click += new EventHandler(this.btnItalianHoagie_Click);
      this.Controls.Add((Control) button2);
      Button button3 = new Button();
      button3.Text = "Tuna Hoagie";
      button3.Size = this.btnSize;
      button3.Location = this.btnLocation[2];
      button3.Click += new EventHandler(this.btnTunaHoagie_Click);
      this.Controls.Add((Control) button3);
      this.DrawReceipt();
      this.DrawBottom(0);
    }

    public void DrawPizza()
    {
      this.level = 1;
      this.Controls.Clear();
      Button button1 = new Button();
      button1.Text = "Cheese Pizza";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[0];
      button1.Click += new EventHandler(this.btnCheesePizza_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Pepperoni Pizza";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[1];
      button2.Click += new EventHandler(this.btnPepperoniPizza_Click);
      this.Controls.Add((Control) button2);
      Button button3 = new Button();
      button3.Text = "Deluxe Pizza";
      button3.Size = this.btnSize;
      button3.Location = this.btnLocation[2];
      button3.Click += new EventHandler(this.btnDeluxePizza_Click);
      this.Controls.Add((Control) button3);
      this.DrawReceipt();
      this.DrawBottom(0);
    }

    public void DrawFries()
    {
      this.level = 1;
      this.Controls.Clear();
      Button button1 = new Button();
      button1.Text = "Plain Fries";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[0];
      button1.Click += new EventHandler(this.btnPlainFries_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Cheese Fries";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[1];
      button2.Click += new EventHandler(this.btnCheeseFries_Click);
      this.Controls.Add((Control) button2);
      Button button3 = new Button();
      button3.Text = "Pizza Fries";
      button3.Size = this.btnSize;
      button3.Location = this.btnLocation[2];
      button3.Click += new EventHandler(this.btnPizzaFries_Click);
      this.Controls.Add((Control) button3);
      this.DrawReceipt();
      this.DrawBottom(0);
    }

    public void DrawSoda()
    {
      this.level = 1;
      this.Controls.Clear();
      Button button1 = new Button();
      button1.Text = "Cola";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[0];
      button1.Click += new EventHandler(this.btnCola_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Diet Cola";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[1];
      button2.Click += new EventHandler(this.btnDietCola_Click);
      this.Controls.Add((Control) button2);
      Button button3 = new Button();
      button3.Text = "Limon";
      button3.Size = this.btnSize;
      button3.Location = this.btnLocation[2];
      button3.Click += new EventHandler(this.btnLimon_Click);
      this.Controls.Add((Control) button3);
      this.DrawReceipt();
      this.DrawBottom(0);
    }

    public void DrawSizes()
    {
      this.level = 2;
      this.Controls.Clear();
      Button button1 = new Button();
      button1.Text = "Small";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[0];
      button1.Click += new EventHandler(this.btnSmall_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Medium";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[1];
      button2.Click += new EventHandler(this.btnMedium_Click);
      this.Controls.Add((Control) button2);
      Button button3 = new Button();
      button3.Text = "Large";
      button3.Size = this.btnSize;
      button3.Location = this.btnLocation[2];
      button3.Click += new EventHandler(this.btnLarge_Click);
      this.Controls.Add((Control) button3);
      this.DrawReceipt();
      this.DrawBottom(0);
    }

    public void DrawToppings()
    {
      this.level = 3;
      this.Controls.Clear();
      if (this.product.Type == "Hoagie")
      {
        Button button1 = new Button();
        button1.Text = "Mayo";
        button1.Size = this.btnSize;
        button1.Location = this.btnLocation[0];
        button1.Click += new EventHandler(this.btnMayo_Click);
        this.Controls.Add((Control) button1);
        Button button2 = new Button();
        button2.Text = "Oil";
        button2.Size = this.btnSize;
        button2.Location = this.btnLocation[1];
        button2.Click += new EventHandler(this.btnOil_Click);
        this.Controls.Add((Control) button2);
        Button button3 = new Button();
        button3.Text = "Onion";
        button3.Size = this.btnSize;
        button3.Location = this.btnLocation[2];
        button3.Click += new EventHandler(this.btnOnion_Click);
        this.Controls.Add((Control) button3);
        Button button4 = new Button();
        button4.Text = "Hot Peppers";
        button4.Size = this.btnSize;
        button4.Location = this.btnLocation[3];
        button4.Click += new EventHandler(this.btnHotPeppers_Click);
        this.Controls.Add((Control) button4);
        Button button5 = new Button();
        button5.Text = "Sweet Peppers";
        button5.Size = this.btnSize;
        button5.Location = this.btnLocation[4];
        button5.Click += new EventHandler(this.btnSweetPeppers_Click);
        this.Controls.Add((Control) button5);
        Button button6 = new Button();
        button6.Text = "Oregano";
        button6.Size = this.btnSize;
        button6.Location = this.btnLocation[5];
        button6.Click += new EventHandler(this.btnOregano_Click);
        this.Controls.Add((Control) button6);
      }
      else if (this.product.Type == "Pizza")
      {
        Button button1 = new Button();
        button1.Text = "Sausage";
        button1.Size = this.btnSize;
        button1.Location = this.btnLocation[0];
        button1.Click += new EventHandler(this.btnSausage_Click);
        this.Controls.Add((Control) button1);
        Button button2 = new Button();
        button2.Text = "Bacon";
        button2.Size = this.btnSize;
        button2.Location = this.btnLocation[1];
        button2.Click += new EventHandler(this.btnBacon_Click);
        this.Controls.Add((Control) button2);
        Button button3 = new Button();
        button3.Text = "Mushrooms";
        button3.Size = this.btnSize;
        button3.Location = this.btnLocation[2];
        button3.Click += new EventHandler(this.btnMushrooms_Click);
        this.Controls.Add((Control) button3);
        Button button4 = new Button();
        button4.Text = "Onion";
        button4.Size = this.btnSize;
        button4.Location = this.btnLocation[3];
        button4.Click += new EventHandler(this.btnOnion_Click);
        this.Controls.Add((Control) button4);
        Button button5 = new Button();
        button5.Text = "Peppers";
        button5.Size = this.btnSize;
        button5.Location = this.btnLocation[4];
        button5.Click += new EventHandler(this.btnPeppers_Click);
        this.Controls.Add((Control) button5);
        Button button6 = new Button();
        button6.Text = "Extra Cheese";
        button6.Size = this.btnSize;
        button6.Location = this.btnLocation[5];
        button6.Click += new EventHandler(this.btnExtraCheese_Click);
        this.Controls.Add((Control) button6);
      }
      this.DrawReceipt();
      this.DrawBottom(1);
    }

    public void DrawBottom(int mode)
    {
      Button button1 = new Button();
      button1.Text = "Back";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[6];
      button1.Click += new EventHandler(this.btnBack_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Cancel";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[7];
      button2.Click += new EventHandler(this.btnCancel_Click);
      this.Controls.Add((Control) button2);
      if (mode != 1)
        return;
      Button button3 = new Button();
      button3.Text = "Add to Order";
      button3.Size = this.btnSize;
      button3.Location = this.btnLocation[8];
      button3.Click += new EventHandler(this.btnAddToOrder_Click);
      this.Controls.Add((Control) button3);
    }

    public void DrawPlaceOrder()
    {
      Button button1 = new Button();
      button1.Text = "Cancel Order";
      button1.Size = this.btnSize;
      button1.Location = this.btnLocation[7];
      button1.Click += new EventHandler(this.btnCancelOrder_Click);
      this.Controls.Add((Control) button1);
      Button button2 = new Button();
      button2.Text = "Place Order";
      button2.Size = this.btnSize;
      button2.Location = this.btnLocation[8];
      button2.Click += new EventHandler(this.btnPlaceOrder_Click);
      this.Controls.Add((Control) button2);
    }

    public void DrawReceipt()
    {
      this.txtReceipt.Multiline = true;
      this.txtReceipt.Size = this.totalSize;
      this.txtReceipt.Location = this.totalPosition;
      this.Controls.Add((Control) this.txtReceipt);
    }

    public void btnHoagie_Click(object sender, EventArgs e)
    {
      this.product = new Product(this.HoagieToppings);
      this.product.Type = "Hoagie";
      this.Controls.Clear();
      this.DrawHoagie();
    }

    public void btnPizza_Click(object sender, EventArgs e)
    {
      this.product = new Product(this.PizzaToppings);
      this.product.Type = "Pizza";
      this.Controls.Clear();
      this.DrawPizza();
    }

    public void btnFries_Click(object sender, EventArgs e)
    {
      this.product = new Product();
      this.product.Type = "Fries";
      this.Controls.Clear();
      this.DrawFries();
    }

    public void btnSoda_Click(object sender, EventArgs e)
    {
      this.product = new Product();
      this.product.Type = "Soda";
      this.Controls.Clear();
      this.DrawSoda();
    }

    public void btnAmericanHoagie_Click(object sender, EventArgs e)
    {
      this.product.Name = "American Hoagie";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnItalianHoagie_Click(object sender, EventArgs e)
    {
      this.product.Name = "Italian Hoagie";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnTunaHoagie_Click(object sender, EventArgs e)
    {
      this.product.Name = "Tuna Hoagie";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnCheesePizza_Click(object sender, EventArgs e)
    {
      this.product.Name = "Cheese Pizza";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnPepperoniPizza_Click(object sender, EventArgs e)
    {
      this.product.Name = "Pepperoni Pizza";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnDeluxePizza_Click(object sender, EventArgs e)
    {
      this.product.Name = "Deluxe Pizza";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnPlainFries_Click(object sender, EventArgs e)
    {
      this.product.Name = "Plain Fries";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnCheeseFries_Click(object sender, EventArgs e)
    {
      this.product.Name = "Cheese Fries";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnPizzaFries_Click(object sender, EventArgs e)
    {
      this.product.Name = "Pizza Fries";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnCola_Click(object sender, EventArgs e)
    {
      this.product.Name = "Cola";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnDietCola_Click(object sender, EventArgs e)
    {
      this.product.Name = "Diet Cola";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnLimon_Click(object sender, EventArgs e)
    {
      this.product.Name = "Limon";
      this.Controls.Clear();
      this.DrawSizes();
    }

    public void btnSmall_Click(object sender, EventArgs e)
    {
      this.product.Size = "Small";
      if (this.product.Type != "Fries" && this.product.Type != "Soda")
      {
        this.DrawToppings();
      }
      else
      {
        this.Controls.Clear();
        this.DrawBottom(1);
        this.DrawReceipt();
      }
    }

    public void btnMedium_Click(object sender, EventArgs e)
    {
      this.product.Size = "Medium";
      if (this.product.Type != "Fries" && this.product.Type != "Soda")
      {
        this.DrawToppings();
      }
      else
      {
        this.Controls.Clear();
        this.DrawBottom(1);
        this.DrawReceipt();
      }
    }

    public void btnLarge_Click(object sender, EventArgs e)
    {
      this.product.Size = "Large";
      if (this.product.Type != "Fries" && this.product.Type != "Soda")
      {
        this.DrawToppings();
      }
      else
      {
        this.Controls.Clear();
        this.DrawBottom(1);
        this.DrawReceipt();
      }
    }

    public void btnMayo_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[1])
      {
        this.product.tops.ToppingList[1] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[1] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnOil_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[2])
      {
        this.product.tops.ToppingList[2] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[2] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnOnion_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.Type == "Hoagie")
      {
        if (this.product.tops.ToppingList[3])
        {
          this.product.tops.ToppingList[3] = false;
          button.BackColor = Color.LightGray;
        }
        else
        {
          this.product.tops.ToppingList[3] = true;
          button.BackColor = Color.Red;
        }
      }
      else
      {
        if (!(this.product.Type == "Pizza"))
          return;
        if (this.product.tops.ToppingList[3])
        {
          this.product.tops.ToppingList[3] = false;
          button.BackColor = Color.LightGray;
        }
        else
        {
          this.product.tops.ToppingList[3] = true;
          button.BackColor = Color.Red;
        }
      }
    }

    public void btnHotPeppers_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[0])
      {
        this.product.tops.ToppingList[0] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[0] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnSweetPeppers_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[5])
      {
        this.product.tops.ToppingList[5] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[5] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnOregano_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[4])
      {
        this.product.tops.ToppingList[4] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[4] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnSausage_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[5])
      {
        this.product.tops.ToppingList[5] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[5] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnBacon_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[0])
      {
        this.product.tops.ToppingList[0] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[0] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnMushrooms_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[2])
      {
        this.product.tops.ToppingList[2] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[2] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnPeppers_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[4])
      {
        this.product.tops.ToppingList[4] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[4] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnExtraCheese_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      if (this.product.tops.ToppingList[1])
      {
        this.product.tops.ToppingList[1] = false;
        button.BackColor = Color.LightGray;
      }
      else
      {
        this.product.tops.ToppingList[1] = true;
        button.BackColor = Color.Red;
      }
    }

    public void btnBack_Click(object sender, EventArgs e)
    {
      if (this.level == 1)
      {
        this.Controls.Clear();
        this.DrawInitialForm();
      }
      else if (this.level == 2)
      {
        this.Controls.Clear();
        if (this.product.Type == "Hoagie")
          this.DrawHoagie();
        else if (this.product.Type == "Pizza")
          this.DrawPizza();
        else if (this.product.Type == "Fries")
        {
          this.DrawFries();
        }
        else
        {
          if (!(this.product.Type == "Soda"))
            return;
          this.DrawSoda();
        }
      }
      else
      {
        if (this.level != 3)
          return;
        for (int index = 0; index < this.order.Count; ++index)
          this.product.tops.ToppingList[index] = false;
        this.DrawSizes();
      }
    }

    public void btnCancel_Click(object sender, EventArgs e)
    {
      this.product = (Product) null;
      this.DrawInitialForm();
    }

    public void btnAddToOrder_Click(object sender, EventArgs e)
    {
      this.order.SetDate();
      this.product.BasePrice = ProductDB.GetProductPrice(this.product.Name);
      this.order.Add(this.product);
      this.txtReceipt.Text = this.order.ToString();
      this.DrawInitialForm();
    }

    public void btnCancelOrder_Click(object sender, EventArgs e)
    {
      this.product = (Product) null;
      this.order.Clear();
      this.txtReceipt.Text = "";
      this.DrawInitialForm();
    }

    public void btnPlaceOrder_Click(object sender, EventArgs e)
    {
      this.order.SetDate();
      ProductDB.InsertOrder(this.order);
      this.product = (Product) null;
      this.order.Clear();
      this.txtReceipt.Text = "";
      this.DrawInitialForm();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 261);
      this.Name = nameof (frmMain);
      this.Text = "Deli and Pizza";
      this.Load += new EventHandler(this.frmMain_Load);
      this.ResumeLayout(false);
    }
  }
}
