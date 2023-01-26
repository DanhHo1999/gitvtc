using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table_Form.Properties;

namespace Table_Form
{
    public static class MenuList
    {
        public static int init=0;
        public static List<MenuItem> list = new List<MenuItem>();
        public static void Init() {
            list.Add(new MenuItem("Há cảo hấp", 30000));
            list.Add(new MenuItem("Há cảo chiên", 30000));
            list.Add(new MenuItem("Chân gà", 28000));
            list.Add(new MenuItem("Bánh cuốn tôm", 40000));
            list.Add(new MenuItem("Bánh tàu hủ", 25000));
            list.Add(new MenuItem("Xíu mại", 30000));
            list.Add(new MenuItem("Sườn kho", 45000));
            list.Add(new MenuItem("Bánh tôm chiên", 50000));
            list.Add(new MenuItem("Bánh trứng", 20000));
            list.Add(new MenuItem("Bánh dừa", 42000));
        }
        public static void GetNewListFromServer(String _longMenuListString) {
            list.Clear();
            string[] strings = _longMenuListString.Split('|');
            foreach (string str in strings) { 
                string[] item=str.Split(':');
                list.Add(new MenuItem(item[0], Convert.ToInt32(item[1])));
            }
            if (init != 0) {
                MenuPanelControl.SetStack(0);
                MenuPanelControl.focusedIndex = 0;
            }
            
            init = 1;
            Form1.form.IsStarting();
        }
        public static MenuItem GetMenuItem(string _menuItemName) {
            
            foreach (MenuItem item in list) {
                Console.WriteLine(_menuItemName+" = "+item.name);
                if(item.name.Equals(_menuItemName))return item;
            }
            return null;
        }
        
    }
}
