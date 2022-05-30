using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_05_014_LTHDT_Bai_9
{
    internal class DanhSachCongNhan
    {
        int currentSize = 0;
        CongNhan[] list;
        public DanhSachCongNhan(int _size) { 
            list = new CongNhan[_size];
        }
        public void Add(CongNhan _congNhan)
        {
            if (currentSize <= list.Length && checkExistedID(_congNhan.getMaCN()))
            {
                list[currentSize] = _congNhan;
                currentSize++;
            }
        }
        public bool checkExistedID(int _id) {
            for (int i = 0; i < currentSize; i++) {
                if (_id == list[i].getMaCN()) return false;
            }
            return true;
        }
        public void ShowAll() {
            for (int i = 0; i < currentSize; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }
        public int SoLuongNhanVien() {
            return currentSize;
        }
        public void SwitchCongNhan(ref CongNhan cn1, ref CongNhan cn2) {
            CongNhan tam = cn1;
            cn1 = cn2;
            cn2 = tam;
        }
        public DanhSachCongNhan SortQuantityDescending() {
            for (int i = 0; i < currentSize - 1; i++) {
                for (int j = i + 1; j < currentSize; j++)
                {
                    if (list[i].getSoSP() < list[j].getSoSP()) SwitchCongNhan(ref list[i], ref list[j]);
                }
            }
            return this;
        }
    }
}
