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
        int cusMobileTel;
        string cusProfession;
        string cusWorkingAd;
        int cusWorkiTel;
        string cusKinName;
        string cusKinAd;
        int cusKinTel;
        string cusPhoto;

        Database db = new Database();

        public Customer(string fName,string lName,string NIC,string cusEmail,string cusHomeAd,int cusHomeTel,int cusMobileTel, string cusProfession,string cusWorkingAd,int cusWorkiTel,string cusPhoto,string cusKinName, string cusKinAd,int cusKinTel)
        {
            this. fName = fName;
            this. lName = lName;
            this. NIC = NIC;
            this. cusEmail = cusEmail;
            this. cusHomeAd= cusHomeAd;
            this. cusHomeTel= cusHomeTel;
            this.cusMobileTel = cusMobileTel;
            this. cusProfession= cusProfession;
            this. cusWorkingAd= cusWorkingAd;
            this. cusWorkiTel= cusWorkiTel;
            this.cusPhoto = cusPhoto;
            this. cusKinName= cusKinName;
            this. cusKinAd= cusKinAd;
            this. cusKinTel= cusKinTel;
        }

        public Customer()
        { }

        public int addCustomer()
        {
            string query1 = "insert into Customer values ('" + NIC + "','" + fName + "','" + lName + "','" + cusHomeAd + "','" + cusWorkingAd + "','" + cusMobileTel + "','" + cusHomeTel + "','" + cusWorkiTel + "','"+cusEmail+"','" + cusProfession + "','"+cusPhoto+"')";
            string query2 = "insert into Customer_Kin values ('"+NIC+ "','" + cusKinName + "','" + cusKinAd + "','" + cusKinTel + "')";
            int i = db.save_update_delete(query1);
            int j = db.save_update_delete(query2);
            if (i == 1 & j == 1)
                return i;
            else
                return 0;
        }

       



    }
}
