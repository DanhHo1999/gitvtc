using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_MultiThread2
{
    internal class Program
    { 
        public static async void void1() {
            Task<int> t1 = new Task<int>(() => {
                int i = 0;
                Console.WriteLine($"void1 {++i}");
                Console.WriteLine($"void1 {++i}");
                Console.WriteLine($"void1 {++i}");
                Console.WriteLine($"void1 {++i}");Thread.Sleep(1000);
                return i;
            });
            t1.Start();
            int a = await t1;
            
            Console.WriteLine("void1 Done");
        }
        static void Main(string[] args)
        {
            void1();
            void1();
            

            Console.WriteLine("Done"); Console.Read();
        }
    }
}
