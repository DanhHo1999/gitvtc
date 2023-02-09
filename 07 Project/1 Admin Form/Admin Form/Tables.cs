using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Form
{
    public static class Tables
    {
        public static List<TableConnector> list = new List<TableConnector>();
        public static List<TableBox> boxesList = new List<TableBox>();

        public static void CloseAllTables()
        {
            foreach (TableConnector table in list)
            {
                table.CloseTable();
            }
            list.Clear();
        }
        public static void Add(Socket _socket, int _number)
        {
            list.Add(new TableConnector(_socket, _number));
        }
        public static int GetNumber()
        {
            List<int> numbers = new List<int>();
            foreach (TableConnector table in list)
            {
                numbers.Add(table.GetNumber());
            }
            int i = 1;
            while (true)
            {
                bool existed = false;
                foreach (int number in numbers)
                {
                    if (i == number) existed = true;
                }
                if (!existed) return i;
                i++;
            }
        }
        public static void CloseTable(TableBox _tableBox) {
            TableConnector table =  GetTable(_tableBox.tableNameLabel.Text);
            if (table != null) {
                table.CloseTable();
                list.Remove(table);
            }
            _tableBox.Dispose();
            boxesList.Remove(_tableBox);
            
        }
        public static void SendNewMenuList()
        {
            foreach (TableConnector table in list)
            {
                table.SendNewMenuList();
            }
        }
        public static TableBox GetController(String _tableName)
        {
            
            foreach (TableBox tableBox in boxesList)
            {
                if (tableBox.tableNameLabel.Text.Equals(_tableName)) return tableBox;
            }
            
            return null;
        }
        public static TableConnector GetTable(String _tableName)
        {
            int _tableNumber = Convert.ToInt32(_tableName.Substring("Bàn số ".Length));
            foreach (TableConnector table in list) { 
                if(table.number==_tableNumber) return table;
            }
            return null;
        }
        public static void CloseAllControllers() {
            foreach (TableBox controller in boxesList) {
                controller.Dispose();
            }
            boxesList.Clear();
        }
        public static void AddPicture(string _menuItemName) {
            foreach (TableConnector table in list) { 
                table.AddPicture(_menuItemName);
            }
        }

    }
}
