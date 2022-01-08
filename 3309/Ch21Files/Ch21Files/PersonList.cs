using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Ch21Files
{
    class PersonList : List<Person>
    {

        public override string ToString()
        {
            string s = "";
            foreach (Person p in this)
            {
                s += p.ToString();
                s += "\r\n\r\n";
            }
            return s;
        }


        public void Read(string filePath)
        {
            string s = "";
            string[] sarr;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(new FileStream(filePath, FileMode.Open, 
                    FileAccess.Read));
                while (sr.Peek() != -1)
                {
                    s = sr.ReadLine();
                    sarr = s.Split(',');
                    Person p = new Person(sarr[0], sarr[1], Convert.ToInt32(sarr[2]));
                    this.Add(p);
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
            }
        }


        public void Write(string filePath)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
                foreach(Person p in this)
                {
                    sw.WriteLine(p.ToCSV());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }


        public void WriteBin(string filePath)
        {
            BinaryWriter bw = null;
            try
            {
                bw = new BinaryWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
                foreach (Person p in this)
                {
                    p.Write(bw);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }

        }


        public void ReadBin(string filePath)
        {
            BinaryReader br = null;
            try
            {
                br = new BinaryReader(new FileStream(filePath, FileMode.Open,
                    FileAccess.Read));
                while (br.PeekChar() != -1)
                {
                    Person p = new Person();
                    p.Read(br);
                    this.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }

    }
}
