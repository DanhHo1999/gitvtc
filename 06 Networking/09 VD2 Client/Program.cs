using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
class Client
{
    static void Main(string[] args)
    {
        IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2008);
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(iep);
        byte[] data = new byte[1024];
        int recv = client.Receive(data);
        string s = Encoding.ASCII.GetString(data, 0, recv);
        Console.WriteLine("Server gui:{0}", s);
        string input;
        while (true)
        {
            input = Console.ReadLine();
            //Chuyen input thanh mang byte gui len cho server
            data = new byte[1024];
            data = Encoding.ASCII.GetBytes(input);
            client.Send(data, data.Length, SocketFlags.None);
            if (input.ToUpper().Equals("QUIT"))
            {
                //client.Close();
                break;
            }
            data = new byte[1024];
            recv = client.Receive(data);
            s = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine("Server gui:{0}", s);
        }
        client.Disconnect(true);
        client.Close();
        
    }
}
