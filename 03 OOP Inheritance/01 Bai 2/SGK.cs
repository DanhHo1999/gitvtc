using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Bai_2
{
    internal class SGK:Sach
    {
        bool isNew;
        public bool IsNew() { return isNew; }
        public void IsNew(bool _isNew) { isNew = _isNew; }
        public SGK(int _id, DateOnly _importedDate, int _price, int _quantity,string _nxb,bool _isNew) {
            setId(_id);
            setImportedDate(_importedDate);
            setPrice(_price);
            setQuantity(_quantity);
            setNxb(_nxb);
            IsNew(_isNew);
        }
        public override double ThanhTien() {
            return quantity*price*(isNew ? 1 : 0.5);
        }

    }
}
