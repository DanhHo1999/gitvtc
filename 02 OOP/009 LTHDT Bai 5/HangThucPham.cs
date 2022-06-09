using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_05_009_LTHDT_Bai_5
{
    internal class HangThucPham
    {
        int id = -1;
        string name = "xxx";
        int price;
        DateOnly nsx;
        DateOnly hsd;
        public static DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        public static void SetToday(int _year,int _month,int _day) {
            HangThucPham.today = new DateOnly(_year, _month, _day);
        }

        public HangThucPham(int _id, string _name, int _price,DateOnly _nsx, DateOnly _hsd) { 
            SetID(_id);
            SetName(_name);
            SetPrice(_price);
            SetNsx(_nsx);
            SetHsd(_hsd);
        }
        public HangThucPham(int _id, string _name, int _price)
        {
            SetID(_id);
            SetName(_name);
            SetPrice(_price);
        }

        public void SetID(int _id) {
            if (id == -1) id = _id;
        }
        public int GetId() {
            return id;
            
        }
        public void SetName(string _name) {
            if (_name == "") { name = "xxx"; return; }
            name = _name;
        }
        public string GetName() { 
            return name;
        }
        public void SetPrice(int _price) { 
            price= _price;
        }
        public int GetPrice() { return price; }
        public void SetNsx(int _year,int _month, int _day)
        {
            DateOnly _nsx = new DateOnly(_year, _month, _day);
            if (_nsx.CompareTo(HangThucPham.today) < 0)
            {
                nsx = _nsx;
            }
            else
            {
                nsx = HangThucPham.today;
            }
        }

        public void SetNsx(DateOnly _nsx)
        {
            if (_nsx.CompareTo(HangThucPham.today) < 0)
            {
                nsx = _nsx;
            }
            else
            {
                nsx = HangThucPham.today;
            }
        }
        public DateOnly GetNsx() {
            return nsx;
        }
        public void SetHsd(int _year, int _month, int _day)
        {
            DateOnly _hsd = new DateOnly(_year, _month, _day);
            if (_hsd.CompareTo(nsx) > 0)
            {
                hsd = _hsd;
            }
            else
            {
                hsd = nsx;
            }
        }

        public void SetHsd(DateOnly _hsd)
        {
            if (_hsd.CompareTo(nsx) > 0)
            {
                hsd = _hsd;
            }
            else
            {
                hsd = nsx;
            }
        }
        public bool checkHsd()
        {
            
            if (hsd.CompareTo(HangThucPham.today) >= 0) 
                return true;
            else 
                return false;
        }

        public string ToString()
        {
            String str = String.Format("{0,4:000} | {1,8} | {2,20:#,###00.00 VND} | {3,10:d/M/yyyy} | {4,10:d/M/yyyy} | {5}",
                id, name, price, nsx, hsd, checkHsd() ? "Chua het han" : "Da het han");
            return str;
            
        }
    }
}
