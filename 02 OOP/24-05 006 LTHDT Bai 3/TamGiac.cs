using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA
{
    internal class TamGiac
    {
        int a, b, c;
        public TamGiac() { }
        public TamGiac(int a, int b, int c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                this.a = 0;
                this.b = 0;
                this.c = 0;
            }
        }
        public int getA() { return a; }
        public int getB() { return b; }
        public int getC() { return c; }
        public void setA(int a) { if (a > 0) this.a = a; }
        public void setB(int a) { if (b > 0) this.b = a; }
        public void setC(int a) { if (c > 0) this.c = a; }
        private bool IsRectangle() {
            return a + b > c && a + c < b && b + c > a;
        }
        public string RectangleType() {
            if (a == b && b == c&&a>0) return "Deu";
            if (a == b) return "Can";
            if (b == c) return "Can";
            if (a == c) return "Can";
            if (IsRectangle()) return "Thuong";
            else return "Not Rectangle";
        }
        public float ChuVi() {
            
            return (a + b + c) /2;
        }
        public double DienTich()
        {
            if (IsRectangle())
                return Math.Sqrt(ChuVi() * (ChuVi() - a) * (ChuVi() - b) * (ChuVi() - c));
            else
                return 0;
        }

        public string toString() {
            return String.Format("a = {0}; b = {1}; c = {2}; Kieu : {3}; P = {4}; S = {5}", a, b, c, RectangleType(), ChuVi(), DienTich());
        }

    }
}
