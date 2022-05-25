using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_05_008_LTHDT_Bai_5
{
    internal class HangThucPham
    {
        int id = -1;
        string name = "xxx";
        int price;
        public void SetID(int _id) {
            if (id == -1) id = _id;
        }
        public int getId() {
            return id;
            
        }
        public void setName(string _name) {
            if (_name == "") { name = "xxx"; return; }
            name = _name;
        }
        public string getName() { 
            return name;
        }
    }
}
