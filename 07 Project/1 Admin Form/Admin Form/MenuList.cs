using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Form
{
    public static class MenuList
    {
        public static List<MenuItem> list = new List<MenuItem>();
        public static MenuItem GetItem(int _index) {
            if (_index < list.Count)
                return list[_index];
            return null;
        }
        public static MenuItem GetItem(string _name){
            foreach (MenuItem item in list) {
                if (item.name.Equals(_name)) return item;
            }
            return null;
        }
        public static MenuItem GetDisabledItem(string _name){
            foreach (DataRow row in DatabaseController.GetDisabledMenuItems().Tables[0].Rows) {
                if (row["Name"].Equals(_name)) return new MenuItem(row["Name"].ToString(),Convert.ToInt32(row["Price"].ToString()));
            }
            return null;
        }
        public static void ChangeName(string _oldName, string _newName) {
            try { GetItem(_oldName).name = _newName; }catch(Exception) {
                Console.WriteLine("ChangeName("+ _oldName+","+_newName+") Failed");
            }
        }
        public static void ChangePrice(string _menuItemName, int _newPrice) {
            try { GetItem(_menuItemName).price = _newPrice; }
            catch (Exception)
            {
                Console.WriteLine("ChangePrice(" + _menuItemName + "," + _newPrice + ") Failed");
            }
        }
        public static void AddMenuItem(string _newMenuItemName, int _newPrice) {
            list.Add(new MenuItem(_newMenuItemName, _newPrice));
        }
        public static void DeleteMenuItem(string _menuItemName) {
            try { list.Remove(GetItem(_menuItemName)); } 
            catch(Exception){
                Console.WriteLine("DeleteMenuItem(" + _menuItemName + ") Failed");
            }
        }
        public static void RefreshNewMenuList() {
            DataTable dt = DatabaseController.GetMenuItems().Tables[0];
            foreach (DataRow dr in dt.Rows) {
                AddMenuItem(dr[0].ToString(), Convert.ToInt32(dr[1].ToString()));
            }
            dt.Dispose();
        }
    }
}
