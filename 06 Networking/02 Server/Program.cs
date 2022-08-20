using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _02_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"),8888);
            tcpListener.Start();
            Socket socket = tcpListener.Read

            socket.Receive(new byte[1]); 
            socket.Send(new byte[1] );
            

            socket.Close();
            tcpListener.Stop();


            // Create TCPlistener, accept socket, receive-send, close
        }
    }
}