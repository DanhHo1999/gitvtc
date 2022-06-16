using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bai_3
{
    internal class GiaoDichVang:GiaoDich
    {
        public GiaoDichVang(int _id,int _price, int _quantity,string _type) {
            id= _id;
            price= _price;
            quantity= _quantity;
            type= _type;
            date=DateOnly.FromDateTime(DateTime.Now);
        }
        
    }
}
