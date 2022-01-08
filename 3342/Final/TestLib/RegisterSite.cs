using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public class RegisterSite
    {
        public string SiteID { get; set; }
        public string Description { get; set; }
        public string APIKey { get; set; }
        public string Email { get; set; }
        public string ContactInformation { get; set; }


        public RegisterSite(string siteID, string description, string aPIKe, string email, string contactInformation)
        {
            this.SiteID = siteID;
            this.Description = description;
            this.APIKey = aPIKe;
            this.Email = email;
            this.ContactInformation = contactInformation;
        }

        public RegisterSite()
        {

        }


    }
}
