using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Bai_6
{
    internal class HoaDonTheoNgay:HoaDon
    {
        int days;
        public HoaDonTheoNgay(int _id, string _name, int _roomID, int _price, int _days) : base(_id, _name, _roomID, _price) { 
            days = _days;
           
        }
        public double ThanhTien() {
            if (days > 7) return 7 * price + (days - 7) * price * 0.8;
            else return price * days;
        }
    }
}
