using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _06_VD2_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(iep);
            serverSocket.Listen(10);
            Console.WriteLine("Cho` ket' noi' tu` client");
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Chap nhan. ket' noi' tu` {0}", clientSocket.RemoteEndPoint.ToString());
            string str = "Chao ban. den' voi' server";

            //Encoding
            byte[] dataStorage = new byte[1024];
            dataStorage = Encoding.ASCII.GetBytes(str);

            //Gửi nhận dữ liệu theo giao thức đã thiết kế
            clientSocket.Send(dataStorage, dataStorage.Length, SocketFlags.None);

            while (true)
            {
                dataStorage = new byte[1024];
                int receivedDataAsInterger = clientSocket.Receive(dataStorage);
                if (receivedDataAsInterger == 0) break;

                //Encoding
                str = Encoding.ASCII.GetString(dataStorage, 0, receivedDataAsInterger);
                Console.WriteLine("Client sent: {0}", str);

                //ReceivedString = Quit -> quit
                if (str.ToUpper().Equals("QUIT")) break;

                str = Console.ReadLine();
                dataStorage = new byte[1024];
                dataStorage = Encoding.ASCII.GetBytes(str);
                clientSocket.Send(dataStorage, dataStorage.Length, SocketFlags.None);
            }
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            serverSocket.Close();

        }
    }
}