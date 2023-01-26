using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Form
{
    public static class DatabaseController
    {
        private static SqlConnection dimsumDB;
        private static SqlDataReader reader;
        private static String connetionString =
            "server=.;database=DIMSUM;integrated security = SSPI";
        static DatabaseController()
        {
            dimsumDB = new SqlConnection(connetionString);
            dimsumDB.Open();
        }
        private static SqlDataReader Reader(string _sqlCommand)
        {
            List<String> data = new List<String>();
            reader = (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteReader();
            return reader;
        }
        public static String GetTablePinCode()
        {
            Reader(@"SELECT * FROM TABLE_CODE").Read();
            String _code = reader.GetString(0);
            reader.Close();
            return _code;
        }
        public static void ChangeTablePinCode(String _code)
        {
            String _sqlCommand =
                @"UPDATE TABLE_CODE SET CODE = '" + _code + @"' WHERE CODE=(SELECT * FROM TABLE_CODE)";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static void Login(String _name, String _password)
        {
            if (Reader(@"SELECT * FROM ACCOUNT WHERE NAME = '" + _name + @"' AND PASSWORD = '" + _password + @"' AND ENABLED = '1'").Read())
                Account.Init(reader.GetString(0), reader.GetInt32(1));
            reader.Close();
        }
        public static void ChangePassword(String _password)
        {
            String _sqlCommand =
                @"UPDATE ACCOUNT SET PASSWORD = '" + _password + @"' WHERE NAME='" + Account.name.ToLower() + @"'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static string GetPassword(string _accountName) {
            
            if (Reader("SELECT PASSWORD FROM ACCOUNT WHERE NAME = '" + _accountName + "'").Read() == true)
            {
                string str = reader.GetString(0);
                reader.Close();
                return str;
            }
            reader.Close();
            throw new Exception();
        }
        public static DataSet GetDisabledMenuItems()
        {
            String _sqlCommand = "SELECT * FROM MENU_ITEM WHERE ENABLED = '0'";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static DataSet GetMenuItems()
        {
            String _sqlCommand = "SELECT * FROM MENU_ITEM WHERE ENABLED = '1'";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static void ChangeMenuItemName(String _newName, String _oldName)
        {
            String _sqlCommand =
                "EXEC CHANGE_MENU_ITEM_NAME @OLD_NAME=N'" + _oldName + "',@NEW_NAME=N'" + _newName + "'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static void AddMenuItem(String _newName, int _newprice)
        {
            String _sqlCommand =
                @"EXEC ADD_MENU_ITEM @MENU_ITEM_NAME=N'" + _newName + @"',@PRICE= " + _newprice;
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static void DeleteMenuItem(String _name)
        {
            String _sqlCommand =
                @"EXEC DELETE_MENU_ITEM @MENU_ITEM_NAME = N'" + _name + @"'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static void ChangeMenuItemPrice(String _newPrice, String _name)
        {
            String _sqlCommand =
                @"UPDATE MENU_ITEM SET PRICE = N'" + _newPrice + @"' WHERE NAME=N'" + _name + @"'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static int GetAccountType(string _accountName)
        {
            Reader(@"SELECT TYPE FROM ACCOUNT WHERE NAME = '"+_accountName+"'").Read();
            int type = reader.GetInt32(0);
            reader.Close();
            return type;
        }
        public static int GetMenuItemCount()
        {
            Reader(@"SELECT COUNT(0) FROM MENU_ITEM WHERE ENABLED = '1'").Read();
            int count = reader.GetInt32(0);
            reader.Close();
            return count;
        }
        public static void AddOrderItem(int _id, string _menuItemName, int _quantity)
        {
            String _sqlCommand = @"EXEC ADD_ORDER_ITEM @ID=" + _id + @",@MENU_ITEM=N'" + _menuItemName + @"',@QUANTITY=" + _quantity;
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static DataSet GetAllOrders()
        {
            String _sqlCommand = "SELECT ID,MENU_ITEM,QUANTITY,[FORMATED-TIME],TOTAL FROM ORDERS_DETAIL ORDER BY ID";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static DataSet GetOrdersBetween(DateTime from, DateTime to)
        {
            String _sqlCommand = @"SELECT ID,MENU_ITEM,QUANTITY,[FORMATED-TIME],TOTAL FROM ORDERS_DETAIL WHERE TIME >='" + from.ToString(AdminForm.SqlDateTimeFormatString) + @"' AND TIME <='" + to.ToString(AdminForm.SqlDateTimeFormatString) + @"' ORDER BY ID";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static int GetNextOrderID()
        {
            Reader("EXEC GET_NEXT_ORDER_ID").Read();
            int count = reader.GetInt32(0);
            reader.Close();
            return count;
        }
        public static DataSet GetOrderByID(int _id)
        {
            String _sqlCommand = @"SELECT ID,MENU_ITEM,QUANTITY,[FORMATED-TIME],TOTAL FROM ORDERS_DETAIL WHERE ID=" + _id;
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static void SetOrderTotal(int _id, int _total)
        {
            String _sqlCommand =
                "UPDATE ORDERS SET TOTAL=" + _total + " WHERE ID=" + _id;
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static void CreateOrder(DateTime _datetime)
        {
            String _sqlCommand =
                @"EXEC CREATE_ORDER @TIME = '" + _datetime.ToString(AdminForm.SqlDateTimeFormatString) + "'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static DataSet GetDistinctOrdersDates()
        {
            String _sqlCommand = "EXEC GET_DISTINCT_ORDER_DATES";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static void ChangeInfo(string _fullName, DateTime _dateOfBirth, string _gender)
        {
            String _sqlCommand =
                "EXEC CHANGE_ACCOUNT_INFO " +
                "@ACCOUNT = '" + Account.name.ToLower() + "'," +
                "@FULLNAME = N'" + _fullName + "'," +
                "@DATEOFBIRTH = '" + _dateOfBirth.ToString(AdminForm.SqlDateFormatString) + "'," +
                "@GENDER = '" + _gender+"'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static bool AccountExisted(string _accountName) {
            Reader("SELECT COUNT(0) FROM ACCOUNT WHERE NAME = '" + _accountName + "'").Read();
            bool isExisted = reader.GetInt32(0) == 1;
            reader.Close();
            Console.WriteLine("AccountExisted() : _accountName="+ _accountName+" : "+isExisted);
            return isExisted;
        }
        public static void AddAcount(string _accountName,string _fullName,DateTime _dateOfBirth,string _gender) {
            String _sqlCommand =
                "EXEC ADD_ACCOUNT " +
                "@ACCOUNT = '" + _accountName + "'," +
                "@FULLNAME = N'" + _fullName + "'," +
                "@DATEOFBIRTH = '" + _dateOfBirth.ToString(AdminForm.SqlDateFormatString) + "'," +
                "@GENDER = '" + _gender+"'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static DataSet GetAccountsNames() {
            String _sqlCommand =
                "SELECT NAME FROM ACCOUNT ORDER BY CREATION_DATE";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static DataSet GetManagerAccounts() {
            String _sqlCommand =
                "SELECT NAME FROM ACCOUNT WHERE TYPE = 2";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            return dataSet;
        }
        public static DataRow GetAccountInfo(string _accountName) {            
            String _sqlCommand =
                "SELECT * FROM ACCOUNT_VIEW WHERE ACCOUNT = '"+_accountName+"'";
            DataSet dataSet = new DataSet();
            (new SqlDataAdapter(_sqlCommand, dimsumDB)).Fill(dataSet);
            DataRow row =dataSet.Tables[0].Rows[0];
            dataSet.Dispose();
            return row;
        }
        public static void SetStatus(string _accountName,bool _Enabled)
        {
            String _sqlCommand =
                "UPDATE ACCOUNT SET " +
                "ENABLED = '" + _Enabled.ToString() +
                "' WHERE NAME = '" + _accountName +
                "'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static void SetRole(string _accountName, int _type)
        {
            String _sqlCommand =
                "UPDATE ACCOUNT SET " +
                "TYPE = '" + _type.ToString() +
                "' WHERE NAME = '" + _accountName +
                "'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        public static void ChangePassword(string _accountName, string _password)
        {
            String _sqlCommand =
                @"UPDATE ACCOUNT SET PASSWORD = '" + _password + @"' WHERE NAME='" + _accountName + @"'";
            (new SqlCommand(_sqlCommand, dimsumDB)).ExecuteNonQuery();
        }
        
    }
}
