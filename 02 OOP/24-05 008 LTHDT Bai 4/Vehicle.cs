using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_05_008_LTHDT_Bai_4
{
    internal class Vehicle
    {
        string owner;
        string type;
        int price;
        int capaciy;
        double tax;
        public Vehicle(string _owner, string _type, int _price, int _capacity)
        {
            owner = _owner;
            type = _type;
            price = _price;
            capaciy = _capacity;
            if (capaciy < 100) tax = 0.01 * _price;
            else if (capaciy > 200) tax = 0.05 * _price;
            else tax = 0.03 * _price;
        }
        
        public string toString()
        {
            return String.Format("{0,20} {1,20} {2,20} {3,20:N} {4,15:N1}", owner, type, capaciy, price, tax);
        }
    }
}
