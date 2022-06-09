using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_05_017_LTHDT_Bai_10_Order
{
    internal class OrderDetail
    {
        int quatity;
        Product product;
        public OrderDetail(Product _product, int _quantity) { 
            product = _product;
            quatity = _quantity;
        }
        public void SetQuatity(int _quatity) {
            if (_quatity < 0) quatity = 0;
            else quatity = _quatity;
        }
        public int GetQuatity() {return quatity;}
        public double CalcTotalPrice() {
            return quatity * product.GetPrice();
        }
        public string ToString() {
            return String.Format("{0} | {1,3} | {2,15:#,##0.00} VND",product.ToString(),quatity,CalcTotalPrice());
        }
    }
}
