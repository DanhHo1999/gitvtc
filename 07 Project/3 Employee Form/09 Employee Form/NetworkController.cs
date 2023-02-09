using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_Employee_Form
{
    public static class NetworkController
    {
        static Socket server;
        static EmployeeForm form;
        static Thread thread;
        public static void Init(EmployeeForm _form) {
            form = _form;
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!server.Connected)
            {
                form.Hide();
                form.Show();
                form.Update();
                try { server.Connect(iep); } catch (Exception) { Console.WriteLine("No Connection"); }
                
            }

                Send("employee");
                StartGettingData();
        }
        private static String GetStringData()
        {
            byte[] bytes = new byte[1024];
            int bytesNumber = server.Receive(bytes);
            string str = Encoding.UTF8.GetString(bytes).Substring(0, bytesNumber);
            if (bytesNumber == 0)
            {
                form.commands.Add("dispose");
                CloseConnection();
            }
            Console.WriteLine("Received(length " + bytesNumber + "): " + str);
            return str;
        }
        private static void StartGettingData()
        {
            thread = new Thread(new ThreadStart(GettingData));
            thread.Start();

        }
        private static void CloseConnection()
        {
            if (server != null) server.Close();
            if (thread != null) thread.Abort();
        }
        private static void GettingData()
        {
            while (server.Connected)
            {
                try
                {
                    String str = GetStringData();
                    String[] strings = str.Split('$');
                    switch (strings[0])
                    {
                        case "addFoodOrder":
                            EmployeeForm.Form.commands.Add(str);
                            break;
                        case "callService"://string str = "callService$" + _tableName + "$";
                            EmployeeForm.Form.commands.Add(str);
                            break;
                        case "finishOrders"://string str = "finishOrders$" + _tableName + "$";
                            EmployeeForm.Form.commands.Add(str);
                            break;
                        
                        default: break;
                    }
                }
                catch (Exception) { }
            }
            form.commands.Add("dispose");
        }
        private static void Send(String str)
        {
            byte[] bytes = new byte[str.Length];
            Console.WriteLine("Sent: " + str);
            bytes = Encoding.UTF8.GetBytes(str);
            server.Send(bytes, bytes.Length, SocketFlags.None);
        }
    }
}
