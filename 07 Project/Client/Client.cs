using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Project
{
    internal class Client
    {

        static List<MenuAction> menuList = new List<MenuAction>();
        static Socket server;
        static String tableName = "Default";
        static bool isClosed=false;
        static int action = 1;
        static List<Notification> notificationsList=new List<Notification>();

        static int notificationTimer = 10;

        static void Main(string[] args)
        {
            
            // Kết nối tới server
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(iep);

            if (args.Length > 0)
            {
                Send(args[0] + ":" + args[1]);tableName=args[1];
            }
            else {
                Send("Table:Default");
            }
            
            menuList.Add(new MenuAction("Send Something", SendSomething));
            menuList.Add(new MenuAction("Order Food", OrderFood));
            menuList.Add(new MenuAction("Close Table", CloseTable));
            menuList.Add(new MenuAction("Tinh Tong", TinhTong));



            PrintScreen(action);
            while (!isClosed) PrintScreen(GetActionByKeyInput());
        }
        internal class Notification {
            internal String message;
            internal int timer;
            public Notification(String _msg, int _timer) { 
                message = _msg;
                timer = _timer;
            }
        }
        
        static int GetActionByKeyInput() {
            int maxAction = menuList.Count;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key) {
                case ConsoleKey.DownArrow:
                    Console.WriteLine("Down");
                    if (action == maxAction) action = 1; else action++;
                    break;
                case ConsoleKey.UpArrow:
                    Console.WriteLine("Up");
                    if (action == 1) action = maxAction; else action--;
                    break;
                case ConsoleKey.Enter:
                    DoAction(action);break;
                default:break;
            }
            return action;
        }
        static void PrintNotify() {
            Notification toBeDeleted=null;
            foreach (Notification notification in notificationsList) {
                notification.timer--;
                Console.WriteLine(notification.message);
                if (notification.timer == 0)toBeDeleted = notification;
            }
            if(toBeDeleted != null) notificationsList.Remove(toBeDeleted);

        }
        static void PrintScreen(int _action) {
            SkipScreen(Console.WindowHeight);
            PrintNotify();
            Console.WriteLine("=========================");
            Console.WriteLine("Table: " + tableName);
            
            for (int i = 0; i < menuList.Count; i++) {
                if (_action-1 == i) Console.Write("--> ");
                Console.WriteLine(i + 1 + ". " + menuList[i].menuName);
            }
            
        }
        
        static void DoAction(int _action)
        {
            menuList[_action - 1].voidName.DynamicInvoke();
        }
        static void Send(String str)
        {
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(str);
            server.Send(bytes, bytes.Length, SocketFlags.None);
        }
        static String ReceivedString()
        {
            byte[] bytes = new byte[1024];
            server.Receive(bytes);
            return Encoding.UTF8.GetString(bytes);

        }
        static void PrintMenuList()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Table: " + tableName);
            foreach (MenuAction menu in menuList)
            {
                Console.WriteLine(menuList.IndexOf(menu) + 1 + ". " + menu.menuName);
            }
        }
        static void SetTableName()
        {
            Console.Write("New Table Name: ");
            tableName = Console.ReadLine();
            Send("SetTableName:" + tableName);

        }
        static void SetTableName(String _a)
        {
            String str="New Table Name: ";
            tableName = _a;
            str += _a;
            AddMessage(str);
            Send("SetTableName:" + tableName);

        }
        static void SendSomething()
        {
            Console.Write("Message: ");
            String str = Console.ReadLine();
            Send(str);
            if(str.Length!=0)AddMessage("Message \""+ str+"\" sent");

        }
        static void CloseTable() {
            Console.WriteLine("Close this table.");
            isClosed = true;
            Send("Close");
        }
        static void SkipScreen(int _rows) {
            for (int i = 0; i < _rows; i++) {
                Console.WriteLine();
            }
        }
        static void OrderFood() { 
            
        }
        static void TinhTong() {
            Console.Write("A=");int a = Convert.ToInt16(Console.ReadLine());
            Console.Write("B=");int b = Convert.ToInt16(Console.ReadLine());
            AddMessage("A+B=" + (a + b));

        }
        static void AddMessage(String _msg) {
            notificationsList.Add(new Notification(_msg, notificationTimer));
        }
        internal class MenuAction
        {
            internal String menuName;
            internal Delegate voidName;
            public MenuAction(String _menuName, Delegate _voidName)
            {
                menuName = _menuName;
                voidName = _voidName;
            }
        }
    }
}