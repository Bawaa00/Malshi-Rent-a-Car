using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class Insurance
    {
        string insID;
        string insName;
        Database db = new Database();

        public Insurance()
        {
        }

        public DataTable viewInsurance()
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Insurance");
            return dt;
        }
    }
}
