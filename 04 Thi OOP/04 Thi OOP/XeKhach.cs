using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Thi_OOP
{
    internal class XeKhach : Xe, IComparable<XeKhach>
    {
        float ticketPrice;
        int seats;
        public float GetPrice() { return ticketPrice; }
        public int GetSeats() { return seats; }
        public void SetPrice(float _price) { ticketPrice = _price; }
        public void SetSeats(int _seats) { seats = _seats; }
        public XeKhach(string _id, string _license, string _driverName, int _trips, float _ticketPrice, int _seat)
        {
            SetID(_id);
            SetLicense(_license);
            SetDriverName(_driverName);
            SetTrips(_trips);
            SetPrice(_ticketPrice);
            SetSeats(_seat);
        }
        public override double ThanhTien()
        {
            return trips * seats * ticketPrice;
        }
        public static bool IsValid(List<XeKhach> list, XeKhach _xe)
        {
            if (_xe.trips <= 0)
            {
                Console.Write("Fail: so chuyen <= 0");
                return false;
            }
            if (_xe.ticketPrice <= 0)
            {
                Console.Write("Fail: gia ve <= 0");
                return false;
            }
            if (_xe.seats != 12 && _xe.seats != 45 && _xe.seats != 30)
            {
                Console.Write("Fail: Seat khong dung: 12,30,45");
                return false;
            }
            if (list == null) return true;
            foreach (XeKhach xe in list)
            {
                if (string.Equals(_xe.id, xe.id))
                {
                    Console.Write("Fail: Trung ID");
                    return false;
                }
                if (string.Equals(_xe.license, xe.license))
                {
                    Console.Write("Fail: Trung so xe");
                    return false;
                }
            }
            return true;
        }
        public override string ToString()
        {
            return string.Format("ID: {0} , License: {1} , DriverName: {2} , Trips: {3} , Price: {4,6:#,##0.00} , Seats: {5}",
                id, license, driverName, trips, ticketPrice, seats);
        }

        public int CompareTo(XeKhach xe2)
        {
            if (ThanhTien() < xe2.ThanhTien()) return 1;
            if (ThanhTien() > xe2.ThanhTien()) return -1;
            return 0;
        }
    }
}
