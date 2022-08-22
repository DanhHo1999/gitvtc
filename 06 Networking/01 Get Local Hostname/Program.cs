using System.Net;

namespace _06_Networking
{
    
    internal class Program
    {
        public static void DeleteConsole(int aa) {
            for (int i = 0; i < aa; i++) Console.Write("\b");
            for (int i = 0; i < aa; i++) Console.Write(" ");
            for (int i = 0; i < aa; i++) Console.Write("\b");

        }
        public static void Main(string[] args)
        {
            //Console.WriteLine("PEPSI - " + Dns.Resolve("PEPSI").AddressList[0]);
            //Console.WriteLine(Dns.Resolve("PEPSI").HostName + " - " + Dns.Resolve("PEPSI").AddressList[1]);
            (new Thread(() => {
                int i = 0;
                while (true) {
                    Thread.Sleep(1000);
                    DeleteConsole(100);
                    Console.Write(i++);

                }

            })).Start();
            string a;
            while (true)
            {
                try {
                    a = Console.ReadLine();
                    Console.WriteLine(a);
                } catch { }
                
            }
            
        }
    }
}