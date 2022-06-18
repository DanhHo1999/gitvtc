using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Bai_6
{
    internal class HoaDon
    {
        protected int id;
        protected DateOnly date;
        protected string name;
        protected int roomID;
        protected int price;
        public HoaDon(int _id, string _name,int _roomID,int _price) {
            id = _id;
            name = _name;
            roomID = _roomID;
            price = _price;
            date = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
