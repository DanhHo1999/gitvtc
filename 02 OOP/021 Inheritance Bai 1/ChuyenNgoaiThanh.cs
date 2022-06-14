using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_Inheritance_Bai_1
{
    internal class ChuyenNgoaiThanh:Chuyen
    {
        string destination;
        int days;
        public void setDestination(string _destination) { destination = _destination; }
        public string getDestination() { return destination; }
        public int getDays() { return days; }
        public void setDays(int _days) { days = _days; }
        public ChuyenNgoaiThanh(int _id, string _driverName, int _transportID, string _destination, int _days, int _income) {
            setID(_id);
            setDriverName(_driverName);
            setTransportID(_transportID);
            setDays(_days); 
            setIncome(_income);
            setDestination(_destination);
        }
    }
}
