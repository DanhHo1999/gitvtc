using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _20_Server___Multiple_Clients
{
    internal class Server
    {
        internal class Table
        {
            public Socket socket;
            public String name;
            public Table(Socket _tableSocket, String _name) { 
                socket = _tableSocket;
                name = _name;
                Console.WriteLine("New Table Connecting");
                StartClient(socket);
            }
        }

        static List<Table> tables = new List<Table>();
        static void Main(string[] args)
        {
            //Tạo kết nối và kết nối với client
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(99);

            new Thread(() => {
                Console.WriteLine("Ready");
                while (true)
                    tables.Add(new Table(server.Accept(), " "));
            }).Start();
            

        }
        static void StartClient(Socket client) {
            new Thread(() => {
                //Start
                SetTableName(client, "NoName");
                while (true)
                {

                    String dataFromClient="";
                    try { dataFromClient = GetStringData(client); } catch (SocketException) {
                        Console.WriteLine("Table "+GetTable(client).name+" Closed");
                        return; }
                    Console.WriteLine("Table " + GetTable(client).name + " sent: \"" + dataFromClient+ "\"");
                    String command = (dataFromClient.Split(":"))[0];

                    switch (command) {

                        case "SetTableName":
                            SetTableName(client, (dataFromClient.Split(":"))[1]);
                            Console.WriteLine("Table new name: "+ (dataFromClient.Split(":"))[1]);
                            break;

                        default:
                            break;
                    }

                }


                //End
            }).Start();
        }





        static String GetStringData(Socket client) {
            byte[] bytes = new byte[1024];
            client.Receive(bytes);
            return Encoding.UTF8.GetString(bytes); ;
        }
        static void SendStringData(Socket client,String str) {
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(str);
            client.Send(bytes, bytes.Length, SocketFlags.None);
        }
        static void SetTableName(Socket _tableSocket,String _name) {
            foreach (Table table in tables) {
                if (table.socket == _tableSocket) { table.name = _name; break; }
            }
        }
        static Table GetTable(String _name) {
            foreach (Table table in tables) {
                if (table.name.Equals(_name)) return table;
            }
            return null;
        }
        static Table GetTable(Socket _socket)
        {
            foreach (Table table in tables)
            {
                if (table.socket==_socket) return table;
            }
            return null;
        }

    }
}