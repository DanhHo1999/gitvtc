using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_05_013_LTHDT_Bai_8
{

    internal class CDList
    {
        int cdNum = 0; int max;
        public CD[] cd;
        public CDList(int _size)
        {
            cd = new CD[_size]; max = _size;

        }
        public bool checkExistedID(CD _cd)
        {

            for (int i = 0; i < cdNum; i++)
            {
                if (cd[i].getId() == _cd.getId()) return false;
            }
            return true;
        }
        public int GetCDNum() { return cdNum; }
        public bool IsMax()
        {
            return cdNum >= max;
        }
        public void AddCD(CD _cd)
        {
            if (checkExistedID(_cd) && !IsMax())
            {
                cd[cdNum] = _cd;
                cdNum++;
            }
        }
        public float TotalPrice()
        {
            float total = 0;
            for (int i = 0; i < cdNum; i++)
            {
                total += cd[i].getPrice();
            }
            return total;
        }
        public void toString()
        {
            Console.WriteLine(String.Format("{0,4} | {1,15} | {2,5} | {3,20:#,##0.00}", "ID", "Name", "Songs", "Price"));
            for (int i = 0; i < cdNum; i++) Console.WriteLine(cd[i].ToString());
            Console.WriteLine("\n\n");
        }
        private static void Switch_CD(ref CD cd1, ref CD cd2)
        {
            CD tam = cd1;
            cd1 = cd2;
            cd2 = tam;
        }
        public CDList PriceDescending()
        {

            for (int i = 0; i < cdNum - 1; i++)
            {
                for (int j = i + 1; j < cdNum; j++)
                {
                    if (cd[i].getPrice() < cd[j].getPrice()) { Switch_CD(ref cd[i], ref cd[j]); }
                }
            }

            return this;
        }
        public CDList NameAscending()
        {

            for (int i = 0; i < cdNum - 1; i++)
            {
                for (int j = i + 1; j < cdNum; j++)
                {
                    if (String.Compare(cd[i].getName(), cd[j].getName()) == 1) { Switch_CD(ref cd[i], ref cd[j]); }
                }
            }

            return this;
        }
        public CDList DefaultSort()
        {

            for (int i = 0; i < cdNum - 1; i++)
            {
                for (int j = i + 1; j < cdNum; j++)
                {
                    if (cd[i].getId() > cd[j].getId()) { Switch_CD(ref cd[i], ref cd[j]); }
                }
            }

            return this;
        }


    }
}
