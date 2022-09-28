using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _20_Server___Multiple_Clients
{
    internal class Server
    {
        static void Main(string[] args)
        {
            //Tạo kết nối và kết nối với client
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(99);

            
            while(true) StartClient(server.Accept());

        }
        static void StartClient(Socket client) {
            new Thread(() => {


                //Start

                while (true)
                {
                    Console.WriteLine("Client says: " + GetStringData(client));
                    SendStringData(client, "Hello");
                }

                //End


            }).Start();
        }





        static String GetStringData(Socket client) {
            byte[] bytes = new byte[1024];
            client.Receive(bytes);
            return Encoding.UTF8.GetString(bytes); ;
        }
        static void SendStringData(Socket client,String str) {
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(str);
            client.Send(bytes, bytes.Length, SocketFlags.None);
        }
    }
}