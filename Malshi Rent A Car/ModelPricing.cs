using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class ModelPricing
    {
        string pID;
        int vYear;
        string vMake;
        string vModel;
        int longRent;
        int shortRent;
        float extraMilageCost;
        Database db = new Database();

        public ModelPricing()
        {
        }

        public DataTable viewPricing()
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_pricing");
            return dt;
        }

        public DataTable viewPricing(string modelID)
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_pricing_id '"+modelID+"'");
            return dt;
        }

    }

   
}
