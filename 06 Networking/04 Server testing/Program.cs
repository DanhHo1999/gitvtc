using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _04_Server_testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Create
            Console.WriteLine("IPAddress adr = IPAddress.Parse(\"127.0.0.1\");");
            IPAddress adr = IPAddress.Parse("127.0.0.1");
            Console.WriteLine("TcpListener listener = new TcpListener(adr, 8888);");
            TcpListener listener = new TcpListener(adr, 8888);
            Console.WriteLine("listener.Start();");
            listener.Start();
            Console.WriteLine("Socket socket = listener.AcceptSocket();");
            Socket socket = listener.AcceptSocket();


            //2.Recieve 
            Console.WriteLine("byte[] data_storage = new byte[1024];");
            byte[] data_storage = new byte[1024];
            Console.WriteLine("socket.Receive(data_storage);");
            socket.Receive(data_storage);
            Console.WriteLine("string str = Encoding.ASCII.GetString(data_storage);"); 
            string str = Encoding.ASCII.GetString(data_storage);
            Console.WriteLine("Client name: \"" + str + "\"");

            //3. Send
            Console.WriteLine("socket.Send(Encoding.ASCII.GetBytes(\"Hello, \" + str));"); 
            socket.Send(Encoding.ASCII.GetBytes("Hello, " + str));

            //4. Close
            Console.WriteLine("socket.Close();");
            socket.Close();
            Console.WriteLine("listener.Stop()");
            listener.Stop();

        }
    }
}