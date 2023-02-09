using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Form
{
    public class Order
    {
        public MenuItem menuItem;
        public int quantity;
        public Order(MenuItem _menuItem, int _quantity) { 
            menuItem = _menuItem;
            quantity = _quantity;
        }
    }
}
