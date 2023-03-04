using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ConsoleApp1
{
    class MyEventArgs : EventArgs
    {
        public int i;
        public MyEventArgs(int i) { this.i = i; }
    }
    class UserInput
    {
        public event EventHandler sukiennhapso;
        public void StartInputing()
        {
            while (true)
            {
                Console.Write("N = ");
                string s = Console.ReadLine();
                try
                {
                    int i = int.Parse(s);
                    sukiennhapso?.Invoke(this, new MyEventArgs(i));
                }
                catch (Exception) { }



            }
        }
    }
    class TinhToan
    {
        public void Subcribe(UserInput _input, string _phepTinh)
        {
            switch (_phepTinh)
            {
                case "tinhCan": _input.sukiennhapso += TinhCan; break;
                case "binhPhuong": _input.sukiennhapso += BinhPhuong; break;
            }
        }
        public void TinhCan(object sender, EventArgs e)
        {
            Console.WriteLine($"Can {((MyEventArgs)e).i} = {Math.Sqrt(((MyEventArgs)e).i)}");
        }
        public void BinhPhuong(object sender, EventArgs e)
        {
            Console.WriteLine($"Binh phuong {((MyEventArgs)e).i} = {((MyEventArgs)e).i}");
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {

            UserInput input = new UserInput();
            input.sukiennhapso += (a, b) => { Console.WriteLine($"Ban vua nhap so {((MyEventArgs)b).i}"); };
            TinhToan tinhToan = new TinhToan();
            tinhToan.Subcribe(input, "tinhCan");
            tinhToan.Subcribe(input, "binhPhuong");
            input.StartInputing();






            Console.ReadLine();
        }
    }
}
