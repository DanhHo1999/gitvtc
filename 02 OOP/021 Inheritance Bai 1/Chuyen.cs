using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_Inheritance_Bai_1
{
    internal class Chuyen
    {
        int id;
        int income;
        string driverName;
        int transportID;
        public void setID(int _id) {id= _id;}
        public int getID() {return id;}
        public string getDriverName() {return driverName;}
        public int getTransportID() {return transportID;}
        public void setDriverName(string _driverName) {driverName= _driverName;}
        public void setTransportID(int _transportID) {transportID= _transportID;}
        public void setIncome(int _income) {income= _income;}
        public int getIncome() { return income; }

    }
}
