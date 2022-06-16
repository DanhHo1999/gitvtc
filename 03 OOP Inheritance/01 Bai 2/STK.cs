using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Bai_2
{
    internal class STK:Sach
    {
        double tax;
        public double getTax() { return tax; }
        public void setTax(double tax) { this.tax = tax; }

        

        public STK(int _id, DateOnly _importedDate, int _price, int _quantity, string _nxb, double _tax) {
            setId(_id);
            setImportedDate(_importedDate);
            setPrice(_price);
            setQuantity(_quantity);
            setNxb(_nxb);
            setTax(_tax);
        }

        public override double ThanhTien()
        {
            return quantity * price * tax;
        }
    }
}
