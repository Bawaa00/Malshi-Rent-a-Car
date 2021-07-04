using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class Booking
    {
        string bookingID;
        string bookingDate;
        string lendDate;
        string returnDate;
        int advAmount;
        Database db = new Database();

        public Booking(string bookingID, string bookingDate, string lendDate,string returnDate,int advAmount)
        {
            this.bookingID = bookingID;
            this.bookingDate = bookingDate;
            this.lendDate = lendDate;
            this.returnDate = returnDate;
            this.advAmount = advAmount;
        }
        public Booking()
        {
        }
        public int addBooking(string cid,string vid)
        {
            string query1 = "insert into Booking values ('" + bookingID + "','" + bookingDate + "','" + lendDate + "','" + returnDate + "','" + advAmount + "')";
            string query2 = "insert into Customer_Booking values ('"+bookingID+"','"+cid+"','"+vid+"')";
            int i =db.save_update_delete(query1);
            int j = db.save_update_delete(query2);
            if (i == 1 && j == 1)
                return i;
            else
                return 0;
        }
    }
}
