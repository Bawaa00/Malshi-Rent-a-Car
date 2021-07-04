using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class MaintenanceRepair : Repair
    {
        string nxtCheck;
        Database db = new Database();


        public MaintenanceRepair(string id,string date,string location,int cost,string details,string next)
        {
            RepairID = id;
            repairDate = date;
            repairLocation = location;
            repairCost = cost;
            repairDetails = details;
            nxtCheck = next;
        }
        public MaintenanceRepair()
        { }
        public override int addRepair(string vehicle)
        {
            string query = "insert into Maintenance_Repair values ('" + vehicle + "','" + RepairID + "','" + repairDate + "','" + repairLocation + "','" + repairDetails + "','" + repairCost + "','" + nxtCheck + "')";
            int i = db.save_update_delete(query);
            return i;
        }
        public override DataTable viewRepair()
        {
            string query = "exec view_maintenance";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
    }
}
