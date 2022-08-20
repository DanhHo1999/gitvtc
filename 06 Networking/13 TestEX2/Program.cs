using System.Net;

namespace _13_TestEX2
{
    class TestServer
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                string externalIpString = client.DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Trim();
                var externalIP = IPAddress.Parse(externalIpString);
                Console.WriteLine("Your IP: " + externalIP);
            }
            using (var client = new WebClient())
            {
                client.DownloadFile("https://cdn.24h.com.vn/upload/2-2022/images/2022-05-30/MU-chot-ronaldo-740-1653906930-382-width740height444.jpg", "../test138.jpg");

            }
            using (var client = new WebClient())
            {
                string htmlCode = client.DownloadString("http://icanhazip.com");
                Console.WriteLine(htmlCode);
            }
        }
    }
}