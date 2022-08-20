using System.Net.Sockets;
using System.Text;

namespace _03_Client
{
    internal class Program {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 8888);
            NetworkStream networkStream = tcpClient.GetStream();

            networkStream.Write(new byte[1]);
            networkStream.Read(new byte[1]);
            networkStream.Close();

            //Create tcpClient, connect listener, create stream from tcp, write-read stream
        }
    }
}