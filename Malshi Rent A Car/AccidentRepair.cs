using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class AccidentRepair : Repair
    {
        int repairClaim;
        int reapirDuration;
        Database db = new Database();

        public AccidentRepair(string id, string date, string location, int cost, string details, int claim,int duration)
        {
            RepairID = id;
            repairDate = date;
            repairLocation = location;
            repairCost = cost;
            repairDetails = details;
            repairClaim = claim;
            reapirDuration = duration;
        }
        public AccidentRepair()
        { }

        public override int addRepair(string vehicle)
        {
            string query = "insert into Accident_Repair values ('" + vehicle+"','"+RepairID+"','"+repairDate+"','"+repairLocation+"','"+repairDetails+"','"+repairCost+"','"+repairClaim+"','"+reapirDuration+"')";
            int i = db.save_update_delete(query);
            return i;
        }
        public override DataTable viewRepair()
        {
            string query = "exec view_accidents";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
    }
}
