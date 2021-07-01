using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshi_Rent_A_Car
{
    class Vehicle
    {
        string plateNumber;
        //string modelID;
        string vColor;
        string vType;
        string transmission;
        int engineCapacity;
        string fuelType;
        int noOfPassengers;
        bool bookingStatus;
        string vPhoto;
        string licenseStartDate;
        string licenseExpiryDate;
       // string insID;
        string insExpiryDate;
        string insStartDate;   
        string lendingDate;
        int monthlyPay;
        string wName;
        string wAddress;
        int wContact;

        Database db = new Database();

        public Vehicle()
        {
        }
        public Vehicle(string plateNumber,string vType, string vColor, string vPhoto, string transmission, int engineCapacity, int noOfPassengers, string licenseStartDate, string licenseExpiryDate, string insExpiryDate, string insStartDate,string fuelType,string lendingDate,int monthlyPay,string wName, string wAddress,int wContact)
        {
            this.plateNumber = plateNumber;
            //this.modelID = modelID;
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
            this.bookingStatus = false;
            this.lendingDate = lendingDate;
            this.monthlyPay = monthlyPay;
            this.wName = wName;
            this.wAddress = wAddress;
            this.wContact = wContact;
        }

        public int addVehicle(string modelID,string insID,string ownerID)
        {
            string query = "insert into Vehicle values ('" + plateNumber + "','" + modelID + "','" + vColor + "','" + vType + "','" + transmission + "','" + engineCapacity + "','" + fuelType + "','" + noOfPassengers + "','" + bookingStatus + "','" + vPhoto + "','" + licenseStartDate + "','" + licenseExpiryDate + "','" + insID + "','" + insStartDate + "','" + insExpiryDate + "','" + ownerID + "','" + lendingDate + "','" + monthlyPay + "','" + wName + "','" + wAddress + "','" + wContact + "')";
            int i = db.save_update_delete(query);
            return i;
        }
    }

}
