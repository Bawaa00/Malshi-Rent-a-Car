using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class Service 
    { 


        string vehicleID;
        string sID;
        string sDetails;
        string sLocation;
        string sDate;
        double milage;
        double nxtMilage;
        double sCost;
        


        Database db = new Database();

        public Service(string vehicleID, string sID, string sDetails, string sLocation,string sDate,double milage, double nxtMilage, double sCost)
        {
            this.sID = sID;
            this.vehicleID = vehicleID;
            this.sDetails = sDetails;
            this.sLocation = sLocation;
            this.sDate = sDate;
            this.milage = milage;
            this.nxtMilage = nxtMilage;
            this.sCost = sCost;
            

        }

        public Service()
        {

        }

        public int addService()
        {
            string query = "insert into Service  values('"+ vehicleID + "','"+ sID + "','"+ sDetails + "','"+ sLocation + "','"+ sDate + "','"+ milage + "','" + nxtMilage + "','"+sCost+"')";
            int i = db.save_update_delete(query);
            return i;
        }

        public DataTable viewService()
        {

            DataTable dt = new DataTable();
            dt = db.getData("Select * from Service");
            return dt;
        }

        public int upDateService()
        {
            string query = "Update Service set(vehicleID = '" + vehicleID + "',sID = '" + sID + "',sDetails = '" + sDetails + "',sLocation = '" + sLocation + "', sDate = '" + sDate + "',milage = '" + milage + "',nxtMilage = '" + nxtMilage + "',sCost = '" + sCost + "')";
            int i = db.save_update_delete(query);
            return i;
        }

    }
}
