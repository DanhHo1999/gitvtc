using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Bai_4
{
    internal class GiaoDich
    {
        protected int id;
        protected DateOnly date;
        protected int price;
        protected double dienTich;
        protected string type;
        public GiaoDich() { date = DateOnly.FromDateTime(DateTime.Now); }
        public int getPrice() { return price; }
        public double GetDienTich() { return dienTich; }
    }
}
