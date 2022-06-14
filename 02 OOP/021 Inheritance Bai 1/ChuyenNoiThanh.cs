using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_Inheritance_Bai_1
{
    internal class ChuyenNoiThanh:Chuyen
    {
        int route;
        int km;
        public void setRoute(int _route) { route = _route; }
        public int getRoute() { return route; }
        public int getkm() { return km; }
        public void setkm(int _km) { km = _km; }
        public ChuyenNoiThanh(int _id, string _name, int _transportID, int _route, int _km, int _income) { 
            setID(_id);
            setDriverName(_name);
            setTransportID(_transportID);
            setRoute(_route);
            setkm(_km);
            setIncome(_income);
        }

    }
}
