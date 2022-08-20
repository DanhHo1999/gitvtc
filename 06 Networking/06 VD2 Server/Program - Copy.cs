using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _06_VD2_Server
{
    internal class program
    {
        static void main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(iep);
            serverSocket.Listen(1);
            Console.WriteLine("Cho` ket' noi' tu` client");
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Chap nhan. ket' noi' tu` {0}", clientSocket.RemoteEndPoint.ToString());
            string str = "Chao ban. den' voi' server";

            //Encoding
            byte[] bytes = new byte[1024];
            bytes = Encoding.ASCII.GetBytes(str);

            //Gửi nhận dữ liệu theo giao thức đã thiết kế
            clientSocket.Send(bytes, bytes.Length, SocketFlags.None);

            while (true)
            {
                bytes = new byte[1024];
                int numberOfBytesReceived = clientSocket.Receive(bytes);
                if (numberOfBytesReceived == 0) break;

                //Encoding
                str = Encoding.ASCII.GetString(bytes, 0, numberOfBytesReceived);
                Console.WriteLine("Client sent: {0}", str);

                //ReceivedString = Quit -> quit
                if (str.ToUpper().Equals("QUIT")) break;

                str = Console.ReadLine();
                bytes = new byte[1024];
                bytes = Encoding.ASCII.GetBytes(str);
                clientSocket.Send(bytes, bytes.Length, SocketFlags.None);
            }
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            serverSocket.Close();

        }
    }
}