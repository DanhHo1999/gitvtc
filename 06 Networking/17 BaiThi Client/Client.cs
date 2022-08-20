using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BaiThi
{
    internal class Client
    {
        static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(iep);
            byte[] bytes = new byte[1024];
            client.Receive(bytes);
            string str = Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Server: {0}", str);
            string input;
            while (true)
            {
                Console.Write("Client: ");
                input = Console.ReadLine();
                bytes = new byte[1024];
                bytes = Encoding.UTF8.GetBytes(input);
                client.Send(bytes, bytes.Length, SocketFlags.None);
                if(bytes.Length == 0) client.Send(Encoding.UTF8.GetBytes(" "), 1, SocketFlags.None);
                bytes = new byte[1024];
                client.Receive(bytes);
                str = Encoding.UTF8.GetString(bytes);
                Console.WriteLine("Server: {0}", str);
                if (input.ToUpper().Equals("QUIT")) break;
            }
            client.Disconnect(true);
            client.Close();
        }
    }
}