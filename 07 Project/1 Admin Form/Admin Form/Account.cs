using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Form
{
    public static class Account
    {
        public static string name="";
        public static int type=0;
        public static void Init(string _name,int _type) { 
            name = _name.ToLower();
            type = _type;
        }

        public static void Clear()
        {
            name = "";
            type = 0;
        }
    }
}
