using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Malshi_Rent_A_Car
{
    class Database
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public void opencon()
        {
            con.Open();
        }
        public void closecon()
        {
            con.Close();
        }
        public Database()
        {
            con = new SqlConnection("Data Source=LAPTOP-MQN2RJ5N;Initial Catalog=Malshi_Rent_a_Car;Integrated Security=True");
        }
        public int save_update_delete(string q)
        {

            opencon();
            cmd = new SqlCommand(q, con);
            int i = cmd.ExecuteNonQuery();
            closecon();
            return i;
        }
        public DataTable getData(string a)
        {
            opencon();
            SqlDataAdapter da = new SqlDataAdapter(a, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closecon();
            return dt;
        }
    }
}
