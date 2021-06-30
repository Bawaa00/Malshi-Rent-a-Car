using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public Owner()
        {

        }

        public int addOwner()
        {
            string query = "insert into Owner values ('" + NIC + "','" + fName + "','" + lName + "','" + homeAddress + "','" + homeContact + "','" + mobileContact + "','" + profession + "','" + offAddress + "','"+offContact+"','" + email + "')";
            int i = db.save_update_delete(query);
            return i;
        }

        public DataTable viewOwner()
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_owners");
            return dt;
        }

        public DataTable viewOwner(string NIC)
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_owners_nic '"+NIC+"'");
            return dt;
        }

        public DataTable searchOwner(string name)
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_owners_name '"+name+"'");
            return dt;
        }
       

        public int updateOwner(string NIC,string fname,string lname,string haddress,int hcontact,int mobile,string prof,string offadd,int offtel,string email)
        {
            string query = "exec update_owner '"+NIC+"','"+fname+"','"+lname+"','"+haddress+"','"+hcontact+"','"+mobile+"','"+prof+"','"+offadd+"','"+offtel+"','"+email+"'";
            int i = db.save_update_delete(query);
            return i;
        }

        public int deleteOwner(string NIC)
        {
            string query = "delete from Owner where O_NIC = '"+NIC+"'";
            int i = db.save_update_delete(query);
            return i;
        }
    }

}
