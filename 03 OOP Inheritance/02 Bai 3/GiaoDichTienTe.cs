using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bai_3
{
    internal class GiaoDichTienTe:GiaoDich
    {
        int tiGia;
        public override double ThanhTien() {
            return price * quantity * tiGia;
        }
        public GiaoDichTienTe(int _id, int _price, int _quantity, int _tiGia,string _type) { 
            id= _id;
            price= _price;
            quantity= _quantity;
            tiGia= _tiGia;
            _type= _type;
            date = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
