using System.Net;

namespace _06_Networking
{
    internal class Program
    {
        public static void Main(string[] args)
        {


            Console.WriteLine("PEPSI - " + Dns.Resolve("PEPSI").AddressList[0]);
            Console.WriteLine(Dns.Resolve("PEPSI").HostName + " - " + Dns.Resolve("PEPSI").AddressList[1]);
        }
    }
}