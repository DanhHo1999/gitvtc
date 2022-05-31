using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_05_017_LTHDT_Bai_10_Order
{
    internal class Order
    {
        int id;
        OrderDetail[] lineItems;
        DateOnly orderDate;
        int count=0;
        public Order(int _id,int _size, DateOnly _orderDate) { 
            id= _id;
            lineItems = new OrderDetail[_size];
            orderDate = _orderDate;
        }
        public void SetOrderDate(DateOnly _orderDate) { 
            orderDate = _orderDate;
        }
        public OrderDetail[] GetLineItems() { return lineItems; }
        public DateOnly GetOrderDate() { return orderDate; }
        public int GetID() { return id; }
        public void AddLineItem(Product _product, int _quatity) { 
            if (count == lineItems.Length) return;
            lineItems[count++] = new OrderDetail(_product, _quatity);
        }
        public double CalcTotalCharge() {
            double totalCharge = 0;
            for (int i = 0; i < count; i++) { 
                totalCharge+=lineItems[i].CalcTotalPrice();
            }
            return totalCharge;
        }
        public string ToString() {
            string str = "Ma HD " +id;
            str += "\nNgay lap hoa don: "+ orderDate+"\n";
            str += String.Format("{0,3} | {1,10}| {2,15:#,##0.00} | {3,3} | {4,19:#,##0.00}\n","ID","Description","Price","Qty","Total");
            for (int i = 0; i < count; i++) str += String.Format(lineItems[i].ToString()+"\n");
            str +=String.Format("Total Charge: {0,15:#,##0.00} VND",CalcTotalCharge());
            return str;
        }
    }
}
