using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table_Form
{
    public static class MenuItemOrderingControl
    {
        //Design
        public static int rowDistance = 20;
        public static int columnDistance = 20;
        public static float imageScale = .9f;
        public static int quantity = 1;
        
        
        public static MenuItem menuItem;
        public static Panel parent;
        public static Form1 form;
        public static PictureBox pictureBox;
        public static DesignedLabel quantityLabel;
        public static DesignedLabel nameLabel;
        public static DesignedLabel priceLabel;
        public static void Init(Table_Form.Form1 _form) { 
            form= _form;
            parent = form.menuItemOrderingPanel;
            

            //picture
            pictureBox = new PictureBox();
            pictureBox.Size = new Size(176, 150);
            pictureBox.Scale(new SizeF(MenuItemOrderingControl.imageScale, MenuItemOrderingControl.imageScale));
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(50, 50);
            parent.Controls.Add(pictureBox);

            //Số lượng
            quantityLabel=new DesignedLabel(parent);
            quantityLabel.Location = Point.Add(pictureBox.Location, new Size(0,pictureBox.Height+ rowDistance));
            quantityLabel.Width = 200;
            quantityLabel.Height += 10;
            quantityLabel.Font = new Font("Arial", 22F);
            quantityLabel.Text = "Số lượng: " + quantity;

            //Food Name
            nameLabel = new DesignedLabel(parent);
            nameLabel.Width = 300;
            nameLabel.Height += 10;
            nameLabel.Location = Point.Add(pictureBox.Location, new Size(pictureBox.Width + columnDistance, (pictureBox.Height / 2)-(nameLabel.Height/2)));
            nameLabel.Font= new Font("Arial", 22F);

            //Price Label
            priceLabel = new DesignedLabel(parent);
            priceLabel.Width = 250;
            priceLabel.Height += 10;
            priceLabel.Font = new Font("Arial", 22F);
            priceLabel.Location = Point.Add(quantityLabel.Location,new Size(quantityLabel.Width+columnDistance,0));

        }
        public static void SetMenuItem(MenuItem _menuItem)
        {
            menuItem = _menuItem;
            pictureBox.Image = _menuItem.image;
            nameLabel.Text=_menuItem.name;
            quantity = 1;
            priceLabel.Text = _menuItem.Price(quantity);
            quantityLabel.Text = "Số lượng: " + quantity;
        }
        public static void SetNewPrice(int _quantity) {
            quantityLabel.Text = "Số lượng: " + quantity;
            priceLabel.Text = menuItem.Price(_quantity);
        }
        public static void LeftArrow_Click() {
            if (quantity == 1) return;
            quantity--;
            SetNewPrice(quantity);
        }
        public static void RightArrow_Click() {
            quantity++;
            SetNewPrice(quantity);
        }
    }
}
