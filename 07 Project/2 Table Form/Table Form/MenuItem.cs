using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table_Form
{
    public class MenuItem
    {
        public string name;
        public int price;
        public Image image;

        public MenuItem(string name, int price)
        {
            this.name = name;
            this.price = price;
            int size = this.size();
            int newSize = this.newSize();
            if (newSize != 0 && newSize != size) DownloadPicture();
            AddPicture();
        }
        public void DownloadPicture() {
            NetworkControl.DownloadPicture(name);
            AddPicture();
        }
        private int size() {
            try { FileInfo fi = new FileInfo(Form1.ToImageFilePath(name));return (int)fi.Length; } catch(Exception) { return 0; }            
        }
        private int newSize() {
            try {return NetworkControl.GetPictureSize(name); } catch(Exception) { return 0; }
        }
        public String Price() {
            return String.Format("{0:N0} VNĐ", price);
        }
        public String Price(int quantity)
        {
            return String.Format("{0:N0} VNĐ", price * quantity);
        }
        public void AddPicture()
        {
            try { image = Image.FromFile(Form1.ToImageFilePath(name)); } catch(Exception) { }
        }
    }
}
