using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_05_011_LTHDT_Bai_7
{
    internal class HinhTron
    {
        ToaDo tam;
        double banKinh;
        public HinhTron(ToaDo _tam, double _banKinh) { 
            tam=_tam;
            banKinh=_banKinh;
        }
        public ToaDo getTam() { 
            return tam;
        }
        public double getBanKinh() { 
            return banKinh;
        }
        public HinhTron SetTam(ToaDo _tam) { 
            tam= _tam;
            return this;
        }
        public HinhTron SetBanKinh(double _banKinh) { 
            banKinh= _banKinh;
            return this;
        }
        public double DienTich() {
            return banKinh*banKinh*3.14;
        }
        public double ChuVi() {
            return (banKinh*2)*3.14;
        }
        public String ToString() {
            return String.Format("Hinh tron  co tam {0} voi ban kinh {1} co chu vi va dien tich la {2} va {3}",tam.ToString(),banKinh,ChuVi(),DienTich());
        }

    }
}
