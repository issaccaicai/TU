using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ch21Files
{
    public partial class frmMain : Form
    {
        PersonList pl = new PersonList();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /*Person p = new Person("Homer", "Simpson", 50);
            pl.Add(p);
            p = new Person("Marge", "Simpson", 47);
            pl.Add(p);
            p = new Person("Bart", "Simpson", 12);
            pl.Add(p);*/

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string path = @"C:\myDir\";
            string filename = "myFile.txt";


            //

            /*if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            else
                MessageBox.Show("Exists");*/

            /*if (Directory.Exists(path))
                Directory.Delete(path, true);
            else
                MessageBox.Show("NOT Exists");*/

            //Directory.Delete(path, true);

            /*if (File.Exists(path + filename))
            {
                MessageBox.Show("Exists");
                File.Copy(path+filename, path + "another" + filename);
            }*/

            /*FileStream fs = null;

            try
            {
                fs = new FileStream(path + "a" +  filename, FileMode.Open, FileAccess.Read);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if(fs != null)
                    fs.Close();
            }*/



            /*StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(new FileStream(path + "a" + filename, FileMode.Append, FileAccess.Write));
                sw.WriteLine("Hello World!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }*/

            /*string s = "";

            StreamReader sr = null;
            try
            {
                sr = new StreamReader(new FileStream(path + "a" + filename, FileMode.Open, FileAccess.Read));
                while (sr.Peek() != -1)
                {
                    s = sr.ReadLine();
                    MessageBox.Show(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }*/


            pl.Read(path+filename);
            pl.WriteBin(path + "myBinFile.bin");
            pl.Clear();
            pl.ReadBin(path + "myBinFile.bin");
            pl.Write(path + "another.txt");

            txtOutput.Text = pl.ToString();
        }
    }
}
