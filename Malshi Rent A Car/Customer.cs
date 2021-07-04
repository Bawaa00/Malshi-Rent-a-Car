using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class Customer
    {
        string fName;
        string lName;
        string NIC;
        string cusEmail;
        string cusHomeAd;
        int cusHomeTel;
        int cudMobileTel;
        string cusProfession;
        string cusWorkingAd;
        int cusWorkiTel;
        string cusKinName;
        string cusKinAd;
        int cusKinTel;
        string cusPhoto;

        Database db = new Database();
        DataTable dt = new DataTable();

        public Customer(string fName,string lName,string NIC,string cusEmail,string cusHomeAd,int cusHomeTel,int cudMobileTel,string cusProfession,string cusWorkingAd,int cusWorkiTel,string cusKinName, string cusKinAd,int cusKinTel,string cusPhoto)
        {


            this. fName = fName;
            this. lName = lName;
            this. NIC = NIC;
            this. cusEmail = cusEmail;
            this. cusHomeAd= cusHomeAd;
            this. cusHomeTel= cusHomeTel;
            this. cudMobileTel= cudMobileTel;
            this. cusProfession= cusProfession;
            this. cusWorkingAd= cusWorkingAd;
            this. cusWorkiTel= cusWorkiTel;
            this. cusKinName= cusKinName;
            this. cusKinAd= cusKinAd;
            this. cusKinTel= cusKinTel;
            this.cusPhoto = cusPhoto;
        }

        public Customer()
        { }

        public int addCustomer()
        {
            string query1 = "insert into Customer values ('" + NIC + "','" + fName + "','" + lName + "','" + cusHomeAd + "','" + cusWorkingAd + "','" + cudMobileTel + "','" + cusHomeTel + "','" + cusWorkiTel + "','" + cusEmail + "','" + cusProfession + "','"+cusPhoto+"')";
            string query2 = "insert into Customer_Kin values ('" + NIC + "','" + cusKinName + "','" + cusKinAd + "','" + cusKinTel + "')";
            int i = db.save_update_delete(query1);
            int j = db.save_update_delete(query2);
            if (i == 1 && j == 1)
                return i;
            else
                return 0;
        }
        public DataTable viewCustomer()
        {
            string query = "exec viewCustomer";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewCustomer(string id)
        {
            string query = "select * from Customer where cNIC= '"+id+"'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewCustomerNIC(string nic)
        {
            string query = "exec viewCustomerNIC '" + nic + "'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewCustomerName(string name)
        {
            string query = "exec viewCustomerName '" + name + "'";
            dt = db.getData(query);
            return dt;
        }

    }
}
