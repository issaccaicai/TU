using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_review
{
    abstract class Person
    {
        private string id;
        private string firstName;
        private string lastName;

        public Person(string id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public override string ToString()
        {
            return "ID: " + id + "\r\n" + "First Name: " + firstName + "\r\n" + "Last Name: " + lastName;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            if (this.ToString() != obj.ToString())
                return false;
            return true;
        }

        public virtual string GetDisplayText(string sep)
        {
            return id + "sep" + firstName + "sep" + lastName;
        }
    }
}
