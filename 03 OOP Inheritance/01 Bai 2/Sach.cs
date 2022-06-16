using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Bai_2
{
    internal abstract class Sach
    {
        protected int id;
        protected DateOnly importedDate;
        protected int price;
        protected int quantity;
        protected string nxb;

        public int getId() { return id; }
        public void setId(int id) { this.id = id; }
        public DateOnly getImportedDate() { return importedDate; }
        public void setImportedDate(DateOnly importedDate) { this.importedDate = importedDate;}
        public int getPrice() { return price; }
        public void setPrice(int price) { this.price = price; }
        public int getQuantity() { return quantity; }
        public void setQuantity(int quantity) { this.quantity = quantity; }
        public string getNxb() { return nxb; }
        public void setNxb(string nxb) { this.nxb = nxb; }
        public abstract double ThanhTien();
        public string ToString() {
            return String.Format("{0,5} , {1,10} , Price : {2,5}",id,importedDate,price);
        }
    }
}
