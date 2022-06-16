using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Bai_4
{
    internal class GiaoDichNha:GiaoDich
    {
        string adr;
        public GiaoDichNha(int _id,int _price,string _type, string _adr, double _dienTich) : base() {
            id = _id;
            price = _price;
            type = _type;
            adr = _adr;
            dienTich = _dienTich;
        }
        public double ThanhTien() {
            return price * dienTich * (String.Equals(type,"thuong")?0.9:1);
        }
    }
}
