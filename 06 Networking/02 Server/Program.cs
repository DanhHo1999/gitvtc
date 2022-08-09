using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _02_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Create
            IPAddress adr = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(adr, 8888);
            Console.WriteLine("server is listening...");
            listener.Start();
            Socket socket = listener.AcceptSocket();
            

            //2.Recieve 
            byte[] data_storage = new byte[1024];
            socket.Receive(data_storage);
            string str = Encoding.ASCII.GetString(data_storage);
            Console.WriteLine("Client name: \"" + str + "\"");

            //3. Send
            socket.Send(Encoding.ASCII.GetBytes("Hello, " + str));

            //4. Close
            Console.WriteLine("Server is closing...");
            socket.Close();
            listener.Stop();

        }
    }
}