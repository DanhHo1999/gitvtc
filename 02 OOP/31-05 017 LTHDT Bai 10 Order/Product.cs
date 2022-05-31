using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_05_017_LTHDT_Bai_10_Order
{
    internal class Product
    {
        string description;
        string id;
        double price;
        public Product() { 
        
        }
        public Product(string _description,string _id,double _price) {
            SetDescription(_description);
            SetID(_id);
            SetPrice(_price);
        }
        public string ToString() {
            return String.Format("{0,2} | {1,10} | {2,15:#,##0.00}",id,description,price);
        }
        public void SetID(string _id) {id = _id; }
        public void SetPrice(double _price) {price = _price; }  
        public void SetDescription(string _description) {description = _description;}
        public string GetDescription() {return description;}
        public double GetPrice() {return price;}
        public string GetID() { return id;}
    }
}
