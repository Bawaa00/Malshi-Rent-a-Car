﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshi_Rent_A_Car
{
    class Bill
    {
        string billID;
        string billDate;
        int extraCost;
        string payMethod;
        Database db = new Database();

        public Bill(string id,string date,int cost,string method)
        {
            billID = id;
            billDate = date;
            extraCost = cost;
            payMethod = method;
        }
        public Bill()
        {

        }
        public int addBill(string bookID)
        {
            string query = "insert into billing values ('"+bookID+"','"+billID+"','"+billDate+"','"+extraCost+"','"+payMethod+"',)";
            int i =db.save_update_delete(query);
            return i;

        }
    }
}
