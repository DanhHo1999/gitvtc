using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BaiThi
{
    internal class Client
    {
        static void Main(string[] args)
        {
            // Kết nối tới server
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(iep);

            //Bắt đầu gửi nhận
            byte[] bytes; string str;
            while (true)
            {
                // Nhập String, encode String sang Byte và gửi
                str = Console.ReadLine();                               //Nhập string
                bytes = new byte[1024];                                 //Tạo byte mới
                bytes = Encoding.UTF8.GetBytes(str);                    //Encode String vừa nhập sang Byte
                client.Send(bytes, bytes.Length, SocketFlags.None);     //Gửi byte


                // Nhận byte từ Server và Encode sang String
                bytes = new byte[1024];                                 //Tạo byte mới
                client.Receive(bytes);                                  //Nhận dữ liệu từ server vào byte     (Chờ server)
                str = Encoding.UTF8.GetString(bytes);                   //Encode Byte sang String
                Console.WriteLine("Server: {0}", str);                  //Print
            }
        }
    }
}