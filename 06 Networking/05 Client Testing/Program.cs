using System.Net.Sockets;
using System.Text;

namespace _05_Client_Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Create
            Console.WriteLine("TcpClient tcpClient = new TcpClient();");
            TcpClient tcpClient = new TcpClient();

            //2. Connect
            Console.WriteLine("tcpClient.Connect(\"127.0.0.1\", 8888);");
            tcpClient.Connect("127.0.0.1", 8888);

            //3. Get Stream
            Console.WriteLine("NetworkStream networkStream = tcpClient.GetStream();");
            NetworkStream networkStream = tcpClient.GetStream();
            Console.WriteLine("Your name: ");
            string name = Console.ReadLine();

            //4. Send data
            Console.WriteLine("byte[] data = Encoding.ASCII.GetBytes(name);");
            byte[] data = Encoding.ASCII.GetBytes(name);
            Console.WriteLine("networkStream.Write(data, 0, data.Length);");
            networkStream.Write(data, 0, data.Length);

            //5. Receive data
            Console.WriteLine("byte[] dataStorage = new byte[1024];");
            byte[] dataStorage = new byte[1024];
            Console.WriteLine("networkStream.Read(dataStorage, 0, 1024);");
            networkStream.Read(dataStorage, 0, 1024);
            Console.WriteLine("Server return: \"" + Encoding.ASCII.GetString(dataStorage) + "\"");

            //6. Close
            Console.WriteLine("networkStream.Close();");
            networkStream.Close();
            Console.WriteLine("tcpClient.Close();");
            tcpClient.Close();
        }
    }
}