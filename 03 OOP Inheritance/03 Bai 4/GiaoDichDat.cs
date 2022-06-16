using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Bai_4
{
    internal class GiaoDichDat:GiaoDich
    {
        
        
        public GiaoDichDat(int _id, int _price, string _type,double _dienTich) : base() { 
            id= _id;
            price= _price;
            type= _type;
            dienTich= _dienTich;
        }
        public double ThanhTien() {
            return price * dienTich*(String.Equals(type, "A") ? 1.5:1);
        }

    }
}
