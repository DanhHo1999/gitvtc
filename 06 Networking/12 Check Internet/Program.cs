using System.Net.NetworkInformation;

namespace _12_Check_Internet
{
    internal class TestServer
    {
        static bool IsConnectedToInternet()
        {
            try
            {
                Ping myPing=new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeOut = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply=myPing.Send(host,timeOut,buffer,pingOptions);
                return(reply.Status==IPStatus.Success);
            }
            catch (Exception) {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Internet Connected: {0}",IsConnectedToInternet());
        }
    }
}