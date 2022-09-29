using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BaiThi
{
    internal class Client
    {
        
        static List<Menu> menuList = new List<Menu>();
        static Socket client;
        static String tableName="NoName";
        static void Main(string[] args)
        {
            // Kết nối tới server
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(iep);

            menuList.Add(new Menu("Set Table Name", SetTableName));

            while (true)
            {
                GetAndDoAction();
            }
        }
        static void GetAndDoAction() {
            
            int action = 0;
            do
            {
                try
                {
                    PrintMenuList();
                    Console.WriteLine("Choose: ");
                    action = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("failed");
                }
            } while (action < 1 || action > menuList.Count);
            menuList[action-1].voidName.DynamicInvoke();
        }
        static void Send(String str) {
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(str);
            client.Send(bytes, bytes.Length, SocketFlags.None);
        }
        static String ReceivedString() {
            byte[] bytes = new byte[1024];
            client.Receive(bytes);
            return Encoding.UTF8.GetString(bytes);
            
        }
        static void PrintMenuList() {
            Console.WriteLine("=========================");
            Console.WriteLine("Table: "+tableName);
            foreach (Menu menu in menuList) {
                Console.WriteLine(menuList.IndexOf(menu) + 1+". "+menu.menuName);
            }
        }
        static void SetTableName() {
            Console.Write("New Table Name: ");
            tableName = Console.ReadLine();
            Send("SetTableName:" + tableName);
            
        }
        internal class Menu
        {
            internal String menuName;
            internal Delegate voidName;
            public Menu(String _menuName, Delegate _voidName)
            {
                menuName = _menuName;
                voidName = _voidName;
            }
        }
    }
}