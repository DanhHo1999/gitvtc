using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table_Form
{
    public static class NetworkControl {
        private static Socket server;
        private static Thread thread;
        private static Form1 form;
        private static Panel panel;
        static Label label;
        private static int timerTick = 70;
        private static int pictureSize = 0;
        private static int taskDone = 0;
        private static string _downloadPictureMenuItemName = "";
        public static void Init(Form1 _form)
        {
            form = _form;
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.BeginConnect(iep, null, null).AsyncWaitHandle.WaitOne(1000, true);
            int a = 0;
            form.Show();
            form.Focus();
            PrepareConnectForm();
            while (!server.Connected)
            {
                server.Dispose();
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.BeginConnect(iep, null, null).AsyncWaitHandle.WaitOne(timerTick, true);
                ConnectingFailed();
            }
            label.Location=new Point(label.Location.X-50, label.Location.Y);
            label.Text = "Kết nối thành công !!";
            form.Update();
            Thread.Sleep(1500);
            for (int i=0;i<=100;i++) {
                int currentRed = middleNumber(255, 190, i);
                int currentGreen = middleNumber(255, 119, i);
                int currentBlue = middleNumber(255, 82, i);
                label.ForeColor = Color.FromArgb(currentRed,currentGreen,currentBlue);
                Thread.Sleep(5);
                form.Update();
            }


            Start();
        }
        private static int middleNumber(int start, int end, int percent) {
            float delta = ((float)end - (float)start)/100;
            delta *= percent;
            return start+(int)delta;
        }
        private static void ConnectingFailed()
        {
            if (label.Text.Length >= 20)
            {
                label.Text = "Đang kết nối";
                return;
            }
            label.Text += ".";
            form.Update();
            

        }
        private static void PrepareConnectForm() {
            panel = new Panel();
            form.Controls.Add(panel);
            panel.BringToFront();
            panel.Location = new Point(0, 0);
            panel.Show();
            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = Color.Transparent;
            panel.Size = new Size(600, 400);
            label = new Label();
            panel.Controls.Add(label);
            label.Location = new Point(170, 230);
            label.Text = "Đang kết nối";
            label.Width = 600;
            label.Height = 300;
            label.ForeColor = Color.White;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Arial", 24,FontStyle.Bold);
            label.Show();
            PictureBox pictureBox1=new PictureBox();
            panel.Controls.Add(pictureBox1);
            pictureBox1.Image = global::Table_Form.Properties.Resources.logo;
            pictureBox1.Location = new System.Drawing.Point(93, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(411, 138);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
        }
        public static void Start() {
            System.Windows.Forms.Timer timer= new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler((s, e) => {
                panel.Dispose();
                timer.Dispose();
            });
            timer.Start();
            form.Focus();
            Send("table");
            StartGettingData();
        }
        private static void GettingData() {
            
            while (server.Connected)
            {
                try
                {
                    String str = GetStringData();
                    String[] strings=str.Split('$');
                    switch (strings[0]) {
                        case "checkCode":
                            if (Convert.ToBoolean(strings[1])) form.commands.Add("pinCorrect");
                            else form.commands.Add("pinIncorrect");
                            break;
                        case "menuList":
                            form.commands.Add(str);
                            break;
                        case "removeOrder":
                            form.commands.Add(str);
                            break;
                        case "addPicture":
                            form.commands.Add(str);
                            break;
                        case "orderNumber":
                            Form1.orderNumber = Convert.ToInt32(strings[1]);
                            break;
                        case "pictureSize":
                            pictureSize = Convert.ToInt32(strings[1]);
                            break;
                        case "downloadPicture":
                            pictureSize = Convert.ToInt32(strings[1]);
                            if (pictureSize == 0)
                            {
                                Console.WriteLine("No Picture");
                                taskDone = 1;break;
                            }
                            DeleteFile(Form1.ToImageFilePath(_downloadPictureMenuItemName));
                            byte[] bytes = new byte[pictureSize];
                            server.Receive(bytes);
                            File.WriteAllBytes(Form1.ToImageFilePath(_downloadPictureMenuItemName), bytes);
                            Console.WriteLine("Picture Downloaded");
                            break;
                        default:break;
                    }
                }
                catch (Exception) { }
            }
            form.commands.Add("dispose");
        }
        public static void CloseConnection() {
            if(server != null) server.Close();
            if(thread != null) thread.Abort();
            Console.WriteLine("Done");
            
        }
        private static void StartGettingData() { 
            thread=new Thread(new ThreadStart(GettingData));
            thread.Start();
            
        }
        public static String GetTableName() {
            return GetStringData();
        }
        private static void Send(String str)
        {
            byte[] bytes = new byte[str.Length];
            Console.WriteLine("Sent: "+str);
            bytes = Encoding.UTF8.GetBytes(str);
            server.Send(bytes, bytes.Length, SocketFlags.None);

        }
        private static String GetStringData()
        {
            byte[] bytes = new byte[1024];
            int bytesNumber=server.Receive(bytes);
            string str = Encoding.UTF8.GetString(bytes).Substring(0, bytesNumber);
            if (bytesNumber == 0) {
                form.commands.Add("dispose");
                CloseConnection();
            }
            Console.WriteLine("Received(length "+bytesNumber+"): "+str);
            return str;
        }
        public static void SendCode(String _code) {
            Send("checkCode$"+_code);
        }
        public static void GetMenuList() {
            
            Send("menuList");
        }
        public static void DownloadPicture(String _menuItemName) {
            taskDone = 0;
            _downloadPictureMenuItemName = _menuItemName;
            Send("downloadPicture$"+_menuItemName+"$");
            while (taskDone == 0) Thread.Sleep(50);
            _downloadPictureMenuItemName = "";
            return;
        }
        public static int GetPictureSize(String _menuItemName) {
            pictureSize = -1;
            Send("pictureSize$" + _menuItemName + "$");
            while (pictureSize == -1) Thread.Sleep(50);
            return pictureSize;
        }
        public static void DeleteFile(String _path) {
            if(File.Exists(_path)) File.Delete(_path);
        }
        public static void AddOrder(String _menuItemName,int _quantity) {
            Send("addOrder$"+_menuItemName+"$"+_quantity+"$");
        }
        public static void GetNextOrderID() {
            Send("getNextOrderID$");
        }
        public static void Finish() {
            Send("finish$");
        }
        public static void CallService() {
            Send("callService$");
        }
    }
    
}
