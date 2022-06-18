using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Thi_OOP
{
    internal abstract class Xe
    {
        protected string id;
        protected string license;
        protected string driverName;
        protected int trips;
        public string GetID() { return id; }
        public string GetLicense() { return license; }
        public string GetDriverName() { return driverName; }
        public int GetTrips() { return trips; }
        public void SetID(string _id)
        {
            id = _id;
        }
        public void SetLicense(string _license) { license = _license; }
        public void SetDriverName(string _driverName) { driverName = _driverName; }
        public void SetTrips(int _trips) { trips = _trips; }
        public abstract double ThanhTien();
    }
}
