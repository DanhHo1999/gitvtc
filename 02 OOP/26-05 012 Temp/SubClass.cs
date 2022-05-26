using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_05_012_Temp
{
    internal class SubClass:BaseClass
    {
        public int publicInt;
        public void AAA() {
            protectedInt = 5;
            publicInt = 5;
        }
        
    }
}
