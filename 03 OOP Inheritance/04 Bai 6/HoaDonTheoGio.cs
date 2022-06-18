using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Bai_6
{
    internal class HoaDonTheoGio:HoaDon
    {
        int hours;
        public int GetHours() { return hours; }
        public HoaDonTheoGio(int _id, string _name, int _roomID, int _price,int _hours):base(_id ,_name,_roomID,_price) {
            hours = _hours >= 24 ? 24 : _hours;

        }
        public double ThanhTien() {
            return price * hours;
        }
    }
}
