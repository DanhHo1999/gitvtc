using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_05_011_LTHDT_Bai_7
{
    internal class ToaDo
    {
        float x, y;
        string name;
        public ToaDo(float x, float y,string name) { 
            this.x = x;
            this.y = y;
            this.name = name;
        }
        public String ToString()
        {
            return String.Format("{0}({1},{2})",name,x,y);

        }
        public ToaDo SetX(float x) { 
            this.x=x;
            return this;
        }
        public ToaDo SetY(float y) { 
            this.y=y;
            return this;
        }
        public float GetX() {return this.x;}
        public float GetY() {return this.y;}
    }
}
