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
        int mobileContact, homeContact ,offContact;
        string profession;
        Database db = new Database();

        public Owner(string fName, string lName, string NIC, string homeAddress, string offAddress, string email, int mobileContact, int homeContact,int offContact, string profession)
        {
            this.fName = fName;
            this.lName = lName;
            this.NIC = NIC;
            this.homeAddress = homeAddress;
            this.offAddress = offAddress;
            this.email = email;
            this.mobileContact = mobileContact;
            this.homeContact = homeContact;
            this.offContact = offContact;
            this.profession = profession;
        }

        public int addOwner()
        {
            string query = "insert into Owner values ('" + NIC + "','" + fName + "','" + lName + "','" + homeAddress + "','" + homeContact + "','" + mobileContact + "','" + profession + "','" + offAddress + "','"+offContact+"','" + email + "')";
            int i = db.save_update_delete(query);
            return i;
        }
    }

}
