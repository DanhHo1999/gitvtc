using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Form
{
    public class MenuItem
    {
        public string name;
        public int price;
        public MenuItem(string _name,int _price)
        {
            name= _name;
            price= _price;
        }
        public String ToPrice()
        {
            return String.Format("{0:N0} VNĐ", price);
        }
        public String ToPrice(int quantity)
        {
            return String.Format("{0:N0} VNĐ", price * quantity);
        }
    }
    
}
