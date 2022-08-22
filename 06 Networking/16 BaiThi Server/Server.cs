using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BaiThi
{
    internal class Server
    {
        public static int USCLN(int a, int b) {
            Console.WriteLine("USCLN ("+a+","+b+")");
            if (b == 0) { Console.WriteLine("=> "+a); ; return a; }
            return USCLN(b, a % b);
        }
        static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(iep);
            serverSocket.Listen(99);

            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Connected from " + clientSocket.RemoteEndPoint.ToString());
            byte[] bytes=new byte[1024];
            bytes = Encoding.UTF8.GetBytes("Connected");
            clientSocket.Send(bytes, bytes.Length, SocketFlags.None);
            
            while (true)
            {
                bytes = new byte[1024];
                int numberOfBytesReceived = clientSocket.Receive(bytes);
                string str="";
                try {
                    str = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine("Received: " + str);
                    if (Encoding.UTF8.GetString(bytes, 0, 4).ToUpper().Equals("QUIT"))break; 
                    int kq, a, b;
                    string[] arr = str.Split(',');
                    a = Convert.ToInt16(arr[0]);
                    b = Convert.ToInt16(arr[1]);
                    kq = USCLN(a, b);
                    str = "USCLN(" + a.ToString() + "," + b.ToString() + (") = ") + kq.ToString();
                    bytes = new byte[1024];
                    bytes = Encoding.UTF8.GetBytes(str);
                } catch (Exception e) { 
                    bytes = new byte[1024];
                    bytes=Encoding.UTF8.GetBytes("Error "+e.Message);
                }
                
                clientSocket.Send(bytes, bytes.Length, SocketFlags.None);
            }
            clientSocket.Send(Encoding.UTF8.GetBytes("Close connection"));
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            serverSocket.Close();
        }
    }
}