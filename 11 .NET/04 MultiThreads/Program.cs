using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_MultiThreads
{
    
    internal class Program
    {
        public async void Do() {
            Task a = new Task(() => { });

            await a;
        }
        public static void DoSomeThing(int _second, string _msg, ConsoleColor _color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine("Start");
                Console.ResetColor();
            }
            for (int i = 0; i < _second; i++) {
                lock (Console.Out) {
                    Console.ForegroundColor = _color;
                    Console.WriteLine($"{i} : {_msg}");
                    Console.ResetColor();
                    Thread.Sleep(100);
                }
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine("End");
                Console.ResetColor();
            }
        }
        public static async Task MyTask(int _second, string _msg, ConsoleColor _color) {
            Task task = new Task(() => { DoSomeThing(_second, _msg, _color); });
            task.Start();
            await task;
            Console.WriteLine("Completed");
        }
        public class MyStuff {
            public string id;
            public MyStuff(string id) { this.id = id; }
        }
        static void Main(string[] args)
        {
            Task<MyStuff> t4 = new Task<MyStuff>((str) => {
                DoSomeThing(10, (string)str, ConsoleColor.Magenta);
                return new MyStuff("Super " + (string)str);
            }, "T4");
            Task<MyStuff> t5 = new Task<MyStuff>((str) => {
                DoSomeThing(15, (string)str, ConsoleColor.Cyan);
                return new MyStuff("Super " + (string)str);
            }, "T5");
            t4.Start();
            t5.Start();
            //Task t2 = MyTask(10, "T2", ConsoleColor.Green);

            //Task t3 = MyTask(4, "T3", ConsoleColor.Blue); 

            Console.WriteLine(t4.Result.id);
            Console.WriteLine(t5.Result.id);
            Console.WriteLine("______________________");
            DoSomeThing(6,"T1",ConsoleColor.Red);


            Console.WriteLine("DONE"); Console.ReadLine();
        }
    }
}
