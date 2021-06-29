using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class User
    {
        string utype;
        string uname;
        string pass;
        string que;
        string answer;
        Database db = new Database();

        public User(string utype, string uname, string pass, string que, string answer)
        {
            this.utype = utype;
            this.uname = uname;
            this.pass = pass;
            this.que = que;
            this.answer = answer;
        }
        public User(string utype, string uname, string pass)
        {
            this.utype = utype;
            this.uname = uname;
            this.pass = pass;
        }

        public int addAccount()
        {
            string query = "insert into UserAcc values ('" + uname + "','" + pass + "','" + utype + "','" + que + "','" + answer + "')";
            int i = db.save_update_delete(query);
            return i;
        }

        public int authorizeAccount()
        {
            DataTable dt = new DataTable();
            string query = "select * from UserAcc where Uname='"+uname+"' and Utype='"+utype+"' and Upass='"+pass+"'";
            dt = db.getData(query);
            return dt.Rows.Count;
        }
    }
}
