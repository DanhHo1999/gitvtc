using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin_Form
{
    public class EmployeeConnector
    {
        private Socket client;
        private Thread thread;
        public static List<EmployeeConnector> connectors = new List<EmployeeConnector>();
        public EmployeeConnector(Socket _client)
        {
            client = _client;
            StartGettingData();
        }
        private void StartGettingData()
        {
            thread = new Thread(() => {
                while (client.Connected)
                {
                    try
                    {
                        Listening();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("GetDataError: Employee");
                        Thread.Sleep(1000);
                    }
                }
                AdminForm.AddAction("disposeEmployee");
            });
            thread.Start();
        }
        
        public static void CallService(string _tableName)
        {
            string str = "callService$" + _tableName + "$";
            foreach (EmployeeConnector connector in connectors) {
                connector.SendStringData(str);
            }
        }
        public static void FinishOrders(string _tableName)
        {
            string str = "finishOrders$" + _tableName + "$";
            foreach (EmployeeConnector connector in connectors)
            {
                connector.SendStringData(str);
            }
        }
        private void Listening()
        {
            String str = GetStringData();
            String[] strings = str.Split('$');
            Console.WriteLine("Received: " + str);
            switch (strings[0])
            {
                case "checkCode":
                    
                    break;
                default:
                    SendStringData(strings[0]);
                    break;
            }
        }
        private String GetStringData()
        {
            byte[] bytes = new byte[1024];
            int bytesNumber = client.Receive(bytes);
            if (bytesNumber == 0)
            {
                Console.WriteLine("0 byte received");
                client.Close();
            }
            return Encoding.UTF8.GetString(bytes).Substring(0, bytesNumber);
        }
        private void SendStringData(String str)
        {
            byte[] bytes = new byte[str.Length];
            Console.WriteLine("Sent: " + str);
            bytes = Encoding.UTF8.GetBytes(str);
            client.Send(bytes, bytes.Length, SocketFlags.None);
        }
        public static void Close() {
            foreach (EmployeeConnector connector in connectors) { 
                connector.client.Close();
                connector.thread.Abort();
            }
            connectors.Clear();
        }
        
        public static void AddFoodOrder(int _tableNumber,string _menuItemName, int _quantity) {
            string str = "addFoodOrder$"+_tableNumber+"$"+_menuItemName+"$"+_quantity+"$";

            foreach (EmployeeConnector connector in connectors)
            {
                
                try { connector.SendStringData(str); } catch (Exception) {
                    connector.client.Close();
                    connector.thread.Abort();
                }
            }
            
        }
    }
}
