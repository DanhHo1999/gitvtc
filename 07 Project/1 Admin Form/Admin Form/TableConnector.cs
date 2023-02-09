using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin_Form
{
    public class TableConnector
    {
        private Socket socket;
        public int number;
        private Thread thread;
        public int myOrderID;
        public TableConnector(Socket _tableSocket, int _number)
        {
            socket = _tableSocket;
            number = _number;
            SendStringData(_number.ToString());
            AdminForm.AddAction("createTable$" + _number + "$");

            StartGettingData();
            Console.WriteLine("Thread Started");
        }
        public void SendNewMenuList() {
            string str = "menuList$";
            DataSet dataSet = DatabaseController.GetMenuItems();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                str += row[0] + ":" + row[1] + "|";
            }
            str = str.Substring(0, str.Length - 1);
            SendStringData(str);
        }
        private void Listening() {
            String str = GetStringData();
            String[] strings = str.Split('$');
            Console.WriteLine("Received: "+str);
            switch (strings[0]) {
                case "checkCode":
                    Console.WriteLine(strings[1]);
                    if (strings[1].Equals(DatabaseController.GetTablePinCode())) SendStringData("checkCode$true");else SendStringData("checkCode$false");
                    break;
                case "menuList":
                    SendNewMenuList();
                    break;
                case "downloadPicture":
                    SendMenuItemPicture(strings[1]);
                    break;
                case "pictureSize":
                    SendMenuItemPictureSize(strings[1]);
                    break;
                case "addOrder":
                    string command = "Bàn số " + number + "$" + str;
                    AdminForm.AddAction(command);
                    break;
                case "finish":
                    command = "Bàn số " + number + "$" + str;
                    AdminForm.AddAction(command);
                    break;
                case "getNextOrderID":
                    command = "Bàn số " + number + "$" + str;
                    AdminForm.AddAction(command);
                    break;
                case "callService":
                    command = "Bàn số " + number + "$" + str;
                    AdminForm.AddAction(command);
                    break;
                default:
                    SendStringData(strings[0]);
                    break;
            }
        }
        private void SendMenuItemPicture(String _menuItemName) {
            string imagePath= AdminForm.ToImageFilePath(_menuItemName);
            if (File.Exists(imagePath)) {
                byte[] imageData = File.ReadAllBytes(imagePath);
                SendStringData("downloadPicture$" + imageData.Length.ToString()+"$");
                socket.Send(imageData, imageData.Length, SocketFlags.None);
            }
            else { 
                SendStringData("downloadPicture$0$");
            }
            
        }
        private void SendMenuItemPictureSize(String _menuItemName)
        {
            string imagePath = AdminForm.ToImageFilePath(_menuItemName);
            if (File.Exists(imagePath))
            {
                byte[] imageData = File.ReadAllBytes(imagePath);
                SendStringData("pictureSize$"+imageData.Length.ToString()+"$");
            }
            else
            {
                SendStringData("pictureSize$0$");
            }

        }
        private void StartGettingData() {
            thread = new Thread(() => {
                while (socket.Connected)
                {
                    try
                    {
                        Listening();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("GetDataError: Table number: " + number);
                        Thread.Sleep(1000);
                    }
                }
                AdminForm.AddAction("disposeTable$Bàn số " + number);
                Tables.list.Remove(this);
            });
            thread.Start();
        }
        private String GetStringData()
        {
            byte[] bytes = new byte[1024];
            int bytesNumber = socket.Receive(bytes);
            if (bytesNumber == 0)
            {
                Console.WriteLine("0 byte received");
                socket.Close();
            }
            return Encoding.UTF8.GetString(bytes).Substring(0, bytesNumber);
        }
        private void SendStringData(String str)
        {
            byte[] bytes = new byte[str.Length];
            Console.WriteLine("Sent: " + str);
            bytes = Encoding.UTF8.GetBytes(str);
            socket.Send(bytes, bytes.Length, SocketFlags.None);
        }
        public int GetNumber()
        {
            return number;
        }
        public void CloseTable()
        {
            SendStringData("dispose");
            socket.Close();
            thread.Abort();
        }
        public void RemoveOrder(int _orderIndex) {
            SendStringData("removeOrder$" + _orderIndex+"$");
        }
        public void AddPicture(string _menuItemName) {
            SendStringData("addPicture$" + _menuItemName+"$");
        }
        public void SendOrderNumber() { 
            SendStringData("orderNumber$"+myOrderID+"$");
        }
    }
}
