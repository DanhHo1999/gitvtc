using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_Inheritance_Rectangle_Zalo
{
    internal class Box:Rectangle
    {
        int height = 0;
        public Box() { }
        public Box(int _length, int _width, int _height) : base(_length, _width) {
            height = _height > 0 ? _height : 0;
        }
        public int getHeight() { return height; }
        public void SetHeight(int _height) { height = _height; }
        public override string toString() {
            return "[" + getLength() + "," + getWidth() + "," + getHeight() + "]";
        }
        public int area() {
            int length = getLength() ;
            int width = getWidth() ;
            return 2 * (length * width + width * height + height * length);
        }
        public int volume() {
            return getLength() * getWidth() * height;
        }
    }
}
