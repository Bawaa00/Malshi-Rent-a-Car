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
        //string billProof

        Database db = new Database();

        public Customer(string fName,string lName,string NIC,string cusEmail,string cusHomeAd,int cusHomeTel,int cudMobileTel,string cusProfession,string cusWorkingAd,int cusWorkiTel,string cusKinName, string cusKinAd,int cusKinTel)
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
        }

        public Customer()
        { }

        public int addCustomer()
        {
            string query = "insert into Owner values ('" + NIC + "','" + fName + "','" + lName + "','" + cusEmail + "','" + cusHomeAd + "','" + cusHomeTel + "','" + cudMobileTel + "','" + cusProfession + "','" + cusWorkingAd + "','" + cusWorkiTel + "','" + cusKinName + "','" + cusKinAd + "','" + cusKinTel + "')";
            int i = db.save_update_delete(query);
            return i;
        }

       



    }
}
