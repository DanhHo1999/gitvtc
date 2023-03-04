using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ConsoleApp1
{
    
    public class MyStuff {
        public int id;

        public MyStuff(int id)
        {
            this.id = id;
        }
        public void ToString() {
            Console.WriteLine($"Stuff ID: {id}");
        }
    }

    public class MyComparer : IComparer<MyStuff>
    {
        public int Compare(MyStuff x, MyStuff y)
        {
            return 0;// 1,0,-1
        }
    }


    internal class Program
    {
        public static int ConvertThis(string i)
        {
            int a;
            if (int.TryParse(i, out a)) {
                if (a == 1) return 9; else return 8;
            }
            return 0;
        }
        public static Converter<string, int> MyConverter = ConvertThis;
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("mot", 1);
            dic.Add("hai", 2);
            dic.Add("ba", 3);
            dic.Add("bon", 4);

            
            Console.WriteLine("\nDONE"); Console.ReadLine();
        }
    }
}
