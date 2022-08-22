using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BaiThi
{
    internal class Server
    {
        // Hàm USCLN nhận string trả string
        // Input: String "a,b" --> Ouput: String "USCLN = ..."
        public static string USCLN(string str)
        {
            string[] strings_Array = str.Split(',');
            int a = Convert.ToInt32(strings_Array[0]);
            int b = Convert.ToInt32(strings_Array[1]);
            if (b == 0) return "USCLN = " + strings_Array[0];
            return USCLN(b.ToString() + "," + (b % a).ToString());
        }



        static void Main(string[] args)
        {
            //Tạo kết nối và kết nối với client
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(iep);
            serverSocket.Listen(99);

            Socket client = serverSocket.Accept();     // Lệnh chờ client kết nối
            Console.WriteLine("Client Connected");

            // Bắt đầu gửi nhận
            byte[] bytes;string str;
            while (true)
            {
                // Nhận byte từ client và encode sang string
                bytes = new byte[1024];                                             // Tạo byte mới
                client.Receive(bytes);                                              // Nhận dữ liệu từ client vào byte     (Chờ Client)
                str = Encoding.UTF8.GetString(bytes);                               // Encode từ Byte sang String

                // Chuyển string nhận được thành string USCLN
                str = USCLN(str);                                                   

                // Encode string sang byte và gửi
                bytes = new byte[1024];                                             //Tạo byte mới
                bytes = Encoding.UTF8.GetBytes(str);                                //Encode từ String sang Byte
                client.Send(bytes, bytes.Length, SocketFlags.None);                 //Gửi byte
            }
            
        }
    }
}