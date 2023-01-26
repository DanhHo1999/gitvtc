using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Form
{
    public static class Log
    {
        static string folderPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, @"Logs\");
        static FileStream fs;
        private static string FileName() {
            return Path.Combine(folderPath, DateTime.Now.ToString("dd'-'MM'-'yyyy") + ".txt");
        }
        
        static Log() { 
            Directory.CreateDirectory(folderPath);
        }

        public static void OpenLogsFolder() {
            System.Diagnostics.Process.Start(folderPath);
        }

        public static void Write(string message) {
            if (Account.name.ToLower().Length == 0) return;
            string role="";
            if (Account.type == 1) role = "Admin";
            if (Account.type == 2) role = "Quản lý";
            if (Account.type == 3) role = "Nhân viên";
            string text = "[ " + DateTime.Now.ToString("HH:mm:ss") + " ] - [ "+Account.name.ToLower()+" - "+role+" ]: "+message;
            StreamWriter sw= new StreamWriter(FileName(), true);
            sw.WriteLine(text);
            sw.Close();
        }
    }
}
