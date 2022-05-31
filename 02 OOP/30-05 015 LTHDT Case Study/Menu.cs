using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_05_015_LTHDT_Case_Study
{
    internal class Menu
    {
        int n = 0;
        string[] hints;
        public Menu(int _size) { 
            hints = new string[_size];
        }
        public void AddHints(string _hint) { 
            hints[n++] = _hint;
        }
        public int getChoice() {
            for (int i = 0; i < n; i++) {
                Console.WriteLine((i+1)+" - "+hints[i]);
            }

            bool failed;
            int result =0 ;
            do
            {
                try
                {
                    Console.Write("Please Choose: ");
                    result = Convert.ToInt32(Console.ReadLine()); failed = false;
                }
                catch
                {
                    failed = true; Console.WriteLine("Not a number");
                }
            } while (failed);
            return result;
        }
    }
}
