using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_review
{
    sealed class Student: Person
    {
        private string type;
        private string major;
    
    public Student(string id, string firstName, string lastName,
               string type, string major) :
               base(id, firstName, lastName)
    {
        this.type = type;
        this.major = major;
    }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Major
        {
            get
            {
                return major;
            }
            set
            {
                major = value;
            }
        }
        public override string ToString()
    {
        return base.ToString() + "\r\n" + "Type: " + type + "\r\n" + "major: " + major;
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

    public override string GetDisplayText(string sep)
    {
        return base.GetDisplayText(sep) + "sep" + type + "sep" + major;
    }
}
}
