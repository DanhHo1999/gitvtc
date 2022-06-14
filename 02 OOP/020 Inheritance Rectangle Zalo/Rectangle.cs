using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_Inheritance_Rectangle_Zalo
{
    internal class Rectangle
    {
        int length = 0;
        int width = 0;
        public Rectangle() { }
        public Rectangle(int _length, int _width) {
            length = _length > 0 ? _length : 0;
            width = _width > 0 ? _width : 0;
        }
        
        public override string ToString() {
            return "["+getLength()+","+getWidth()+"]";
        }
        public int getLength() {return length;}
        public int getWidth() {return width;}
        public void setLength(int length) {this.length = length;}
        public void setWidth(int width) {this.width = width;}
        public int area() { return length * width; }
        
    }
}
