using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Thi_OOP
{
    internal class XeTai : Xe, IComparable<XeTai>
    {
        float tripPrice;
        public float GetTripPrice() { return tripPrice; }
        public void SetTripPrice(float _tripPrice) { tripPrice = _tripPrice; }
        public XeTai(string _id, string _license, string _driverName, int _trips, float _tripPrice)
        {
            SetID(_id);
            SetLicense(_license);
            SetDriverName(_driverName);
            SetTrips(_trips);
            SetTripPrice(_tripPrice);
        }
        public override double ThanhTien()
        {
            return trips * tripPrice;
        }
        public static bool IsValid(List<XeTai> list, XeTai _xe)
        {
            if (_xe.trips <= 0)
            {
                Console.Write("Fail: So Chuyen <= 0");
                return false;
            }
            if (_xe.tripPrice <= 0)
            {
                Console.Write("Fail: Gia chuyen <= 0");
                return false;
            }
            if (list == null) return true;
            foreach (XeTai xe in list)
            {
                if (string.Equals(_xe.id, xe.id))
                {
                    Console.Write("Fail: Trung ID");
                    return false;
                }
                if (string.Equals(_xe.license, xe.license))
                {
                    Console.Write("Fail: Trung So Xe");
                    return false;
                }

            }
            return true;
        }
        public override string ToString()
        {
            return string.Format("ID: {0} , License: {1} , DriverName: {2} , Trips: {3} , Price: {4,6:#,##0.00}", id, license, driverName, trips, tripPrice);
        }

        public int CompareTo(XeTai xe2)
        {
            if (ThanhTien() < xe2.ThanhTien()) return 1;
            if (ThanhTien() > xe2.ThanhTien()) return -1;
            return 0;
        }
    }
}
