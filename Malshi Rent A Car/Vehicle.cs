using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Malshi_Rent_A_Car
{
    class Vehicle
    {
        string plateNumber;
        string vColor;
        string vType;
        string transmission;
        int engineCapacity;
        string fuelType;
        int noOfPassengers;
       // int bookingStatus;
        string vPhoto;
        string licenseStartDate;
        string licenseExpiryDate;
        string insExpiryDate;
        string insStartDate;   
        string lendingDate;
        int monthlyPay;
        string wName;
        string wAddress;
        int wContact;

        Database db = new Database();
        DataTable dt = new DataTable();

        public Vehicle()
        {
        }
        public Vehicle(string plateNumber,string vType, string vColor, string vPhoto, string transmission, int engineCapacity, int noOfPassengers, string licenseStartDate, string licenseExpiryDate, string insExpiryDate, string insStartDate,string fuelType,string lendingDate,int monthlyPay,string wName, string wAddress,int wContact)
        {
            this.plateNumber = plateNumber;
            this.vType = vType;
            this.vColor = vColor;
            this.vPhoto = vPhoto;
            this.transmission = transmission;
            this.engineCapacity = engineCapacity;
            this.noOfPassengers = noOfPassengers;
            this.licenseStartDate= licenseStartDate;
            this.licenseExpiryDate= licenseExpiryDate;
            this.insExpiryDate= insExpiryDate;
            this.insStartDate= insStartDate;
            this.fuelType= fuelType;
            //this.bookingStatus = false;
            this.lendingDate = lendingDate;
            this.monthlyPay = monthlyPay;
            this.wName = wName;
            this.wAddress = wAddress;
            this.wContact = wContact;
        }

        public int addVehicle(string modelID,string insID,string ownerID)
        {
            string query = "insert into Vehicle ( plateNumber,modelID,vColor,vType,transmission,engineCapacity,fuelType,noOfPassengers,vPhoto,licenseStartDate,licenseExpiryDate,I_ID,InsStartDate,InsExpiryDate,O_ID,lendingDate,monthlyPay,wName,wAddress,wContact) values ('" + plateNumber + "','" + modelID + "','" + vColor + "','" + vType + "','" + transmission + "','" + engineCapacity + "','" + fuelType + "','" + noOfPassengers + "','" + vPhoto + "','" + licenseStartDate + "','" + licenseExpiryDate + "','" + insID + "','" + insStartDate + "','" + insExpiryDate + "','" + ownerID + "','" + lendingDate + "','" + monthlyPay + "','" + wName + "','" + wAddress + "','" + wContact + "')";
             int i = db.save_update_delete(query);
             return i;
        }
        public DataTable viewVehicle()
        {
            dt = db.getData("select * from Vehicle");
            return dt;
        }
        public DataTable viewVehicleCategory(string category)
        {
            dt = db.getData("select * from Vehicle where vType='"+category+"'");
            return dt;
        }
        public DataTable viewVehicleMake(string make)
        {
            dt = db.getData("select * from Vehicle");
            return dt;
        }
        public DataTable viewVehicleFuel(string fuel)
        {
            dt = db.getData("select * from Vehicle where fuelType='"+fuel+"'");
            return dt;
        }
        public DataTable viewVehicleTrans(string trans)
        {
            dt = db.getData("select * from Vehicle where transmssion='"+trans+"'");
            return dt;
        }
    }

}
