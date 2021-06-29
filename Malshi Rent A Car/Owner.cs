using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshi_Rent_A_Car
{
    class Owner
    {
        string fName;
        string lName;
        string NIC;
        string homeAddress, offAddress;
        string email;
        int mobileContact, homeContact;
        string profession;

        public Owner(string fName, string lName, string NIC, string homeAddress, string offAddress, string email, int mobileContact, int homeContact, string profession)
        {
            this.fName = fName;
            this.lName = lName;
            this.NIC = NIC;
            this.homeAddress = homeAddress;
            this.offAddress = offAddress;
            this.email = email;
            this.mobileContact = mobileContact;
            this.homeContact = homeContact;
            this.profession = profession;
        }

        public void addOwner()
        {

        }
    }

}
