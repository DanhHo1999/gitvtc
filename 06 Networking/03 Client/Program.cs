using System.Net.Sockets;
using System.Text;

namespace _03_Client
{
    internal class Program {
        static void Main(string[] args)
        {
            //1. Create
            TcpClient tcpClient = new TcpClient();

            //2. Connect
            tcpClient.Connect("127.0.0.1", 8888);

            //3. Get Stream
            NetworkStream networkStream= tcpClient.GetStream();
            Console.WriteLine("Your name: ");
            string name = Console.ReadLine();
            
            //4. Send data
            byte[] data= Encoding.ASCII.GetBytes(name);
            networkStream.Write(data, 0, data.Length);

            //5. Receive data
            byte[] dataStorage = new byte[1024];
            networkStream.Read(dataStorage, 0, 1024);
            Console.WriteLine("Server return: \""+Encoding.ASCII.GetString(dataStorage)+"\"");

            //6. Close
            networkStream.Close();
            tcpClient.Close();
        }
    }
}