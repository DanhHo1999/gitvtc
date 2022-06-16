using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bai_3
{
    internal class GiaoDich
    {
        protected int id;
        protected DateOnly date;
        protected int price;
        protected int quantity;
        protected string type;
        public int GetPrice() { return price; }
        public int GetQuantity() { return quantity; }
        public virtual double ThanhTien() { return quantity * price; }
    }
}
