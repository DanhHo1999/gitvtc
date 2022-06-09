using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_05_018_LTHDT_Bai_11_HocVien
{
    internal class HocVien
    {
        string name;
        int namSinh;
        float diemVan=0, diemToan=0, diemLy=0, diemHoa=0, diemSinh=0;
        public HocVien(string _name, int _namSinh)
        {
            name = _name;
            namSinh = _namSinh;
        }
        public HocVien(string _name, int _namSinh,float[] diem)
        {
            name = _name;
            namSinh = _namSinh;
            diemVan = diem[0];
            diemToan = diem[1];
            diemLy = diem[2];
            diemHoa = diem[3];
            diemSinh = diem[4];
        }
        public void SetDiemVan(float _diemVan) { diemVan = _diemVan; }
        public void SetDiemToan(float _diemToan) { diemToan = _diemToan; }
        public void SetDiemLy(float _diemLy) { diemLy = _diemLy; }
        public void SetDiemHoa(float _diemHoa) { diemHoa = _diemHoa; }
        public void SetDiemSinh(float _diemSinh) { diemSinh = _diemSinh; }
        public float GetDiemVan() { return diemVan; }
        public float GetDiemToan() { return diemToan; }
        public float GetDiemLy() { return diemLy; }
        public float GetDiemHoa() { return diemHoa; }
        public float GetDiemSinh() { return diemSinh; }
        public String GetResult() {
            string str = "Thi lai mon: ";bool Thilai=false;
            if (diemToan < 5) { str += "Toan, "; Thilai = true; }
            if (diemLy < 5) { str += "Ly, "; Thilai = true; }
            if (diemHoa < 5) { str += "Hoa, "; Thilai = true; }
            if (diemSinh < 5) { str += "Sinh, "; Thilai = true; }
            if (diemVan < 5) { str += "Van, "; Thilai = true; }
            if (Thilai)return str;

            double result = (diemVan + diemToan + diemLy + diemHoa + diemSinh) / 5;
            if (result >= 7) return "Lam Luan Van";
            if (result >= 5) return "Thi Tot Nghiep";
            return "";
        }
        public String ToString() {
            return String.Format("{0}, Sinh Nam: {1}, Ket Qua: {2}",name,namSinh,GetResult());
        }
    }
}
