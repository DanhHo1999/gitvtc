using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Thi_OOP
{
    internal class ListXeTai : List<XeTai>
    {
        public void AddXe(XeTai _xe)
        {
            if (XeTai.IsValid(this, _xe))
            {
                Add(_xe);
            }
            else
            {
                Console.WriteLine(", Add Xe Tai Failed");
            }
        }
        public void RemoveByID(string _id)
        {
            foreach (XeTai _xe in this)
            {
                if (string.Equals(_id, _xe.GetID()))
                {
                    Remove(_xe);
                    return;
                }
            }
        }
        public double GetTotalPrice()
        {
            double total = 0;
            foreach (XeTai _xe in this)
            {
                total += _xe.ThanhTien();
            }
            return total;
        }
        public void ShowTotalPrice()
        {
            Console.WriteLine(string.Format("Tong Thanh Tien: {0,15:#,##0.00} VND", GetTotalPrice()));

        }

        public void Traversal()
        {
            foreach (XeTai _xe in this)
            {
                Console.WriteLine(_xe.ToString());
            }
        }
    }
}
