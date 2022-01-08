using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Ch21Files
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        // 
        public Person()
        {

        }

        //
        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        //
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        //
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        //
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        //
        public string getDisplayText(string sep)
        {
            return firstName + sep + lastName + sep + age;
        }

        //
        public override string ToString()
        {
            return getDisplayText("\r\n");
        }

        public string ToCSV()
        {
            return getDisplayText(",");
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(FirstName);
            bw.Write(LastName);
            bw.Write(Age);
        }

        public void Read(BinaryReader br)
        {
            firstName = br.ReadString();
            lastName = br.ReadString();
            age = br.ReadInt32();
        }
    }
}
