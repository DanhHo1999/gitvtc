using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table_Form
{
    public class MenuItemLabel
    {
        public MenuItem menuItem;
        public PictureBox pictureBox;
        public DesignedLabel itemNameLabel;
        public DesignedLabel priceLabel;
        
        
        public MenuItemLabel(MenuItem _menuItem) {
            menuItem = _menuItem;
            pictureBox = new PictureBox();
            pictureBox.Size = new Size(176,150);
            pictureBox.Image = _menuItem.image;
            pictureBox.Scale(new SizeF(MenuPanelControl.imageScale, MenuPanelControl.imageScale));
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            itemNameLabel = new DesignedLabel();
            itemNameLabel.Text = (MenuList.list.IndexOf(_menuItem)+1)+". "+ _menuItem.name;
            itemNameLabel.Width = MenuPanelControl.itemNameLabelWidth;
            priceLabel = new DesignedLabel();
            priceLabel.Text = _menuItem.Price();
            priceLabel.Width = MenuPanelControl.itemPriceLabelWidth;
            MenuPanelControl.parent.Controls.Add(pictureBox);
            MenuPanelControl.parent.Controls.Add(itemNameLabel);
            MenuPanelControl.parent.Controls.Add(priceLabel);
            SetVisible(false);
            pictureBox.Click += new EventHandler(MenuItemLabel_OnClick);
            
        }
        protected void MenuItemLabel_OnClick(object sender, EventArgs e)
        {
            MenuItemOrderingControl.SetMenuItem(menuItem);
            MenuPanelControl.form.menuPanel.Hide();
            MenuPanelControl.form.menuItemOrderingPanel.Show();
        }

        public MenuItemLabel SetBorder(bool _visible)
        {

            if (_visible)
            {
                itemNameLabel.BorderStyle = BorderStyle.FixedSingle;
                priceLabel.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                itemNameLabel.BorderStyle = BorderStyle.None;
                priceLabel.BorderStyle = BorderStyle.None;
            }
            return this;
        }
        public MenuItemLabel SetLocation(Point _location) { 
            pictureBox.Location = _location;
            itemNameLabel.Location = new Point(_location.X+pictureBox.Width+5,_location.Y+((int)(pictureBox.Height * 0.4f)));
            priceLabel.Location = new Point(itemNameLabel.Location.X+ itemNameLabel.Width +5, _location.Y + ((int)(pictureBox.Height * 0.4f)));
            return this;
        }
        public MenuItemLabel SetVisible(bool _visible) {
            if (_visible) {
                pictureBox.Show();
                itemNameLabel.Show();
                priceLabel.Show();
            } else {
                pictureBox.Hide();
                itemNameLabel.Hide();
                priceLabel.Hide();
            }
            return this;
        }
        public MenuItemLabel SetFood(MenuItem menuItem) {
            this.menuItem = menuItem;
            pictureBox.Image= menuItem.image;
            itemNameLabel.Text= (MenuList.list.IndexOf(menuItem) + 1) + ". " + menuItem.name;
            priceLabel.Text= menuItem.Price();
            return this;
        }
    }
    
    public static class MenuPanelControl {
        //Manual Properties
        public static float imageScale = .7f;
        public static int itemNameLabelWidth = 170;
        public static int itemPriceLabelWidth = 130;


        //Default
        public static int focusedIndex = 0;
        public static System.Windows.Forms.Panel parent;
        public static MenuItemLabel itemLabel1;
        public static MenuItemLabel itemLabel2;
        public static MenuItemLabel itemLabel3;
        public static Form1 form;
        public static void Init(Form1 _form) {
            form = _form;
        }
        public static void Start() {
            MenuList.Init();
            itemLabel1 = new MenuItemLabel(MenuList.list[0]);
            itemLabel2 = new MenuItemLabel(MenuList.list[1]);
            itemLabel3 = new MenuItemLabel(MenuList.list[2]);
            //itemLabel1.SetBorder(true);
            itemLabel1.SetLocation(new Point(30, 30)).SetVisible(true);
            itemLabel2.SetLocation(new Point(itemLabel1.pictureBox.Location.X, itemLabel1.pictureBox.Location.Y + itemLabel1.pictureBox.Height + 10)).SetVisible(true);
            itemLabel3.SetLocation(new Point(itemLabel2.pictureBox.Location.X, itemLabel2.pictureBox.Location.Y + itemLabel2.pictureBox.Height + 10)).SetVisible(true);
        }
        public static void SetStack(int index) {
            itemLabel1.SetFood(MenuList.list[index]);
            itemLabel2.SetFood(MenuList.list[index+1]);
            itemLabel3.SetFood(MenuList.list[index+2]);
        }
        public static void ScrollDown() {
            if (focusedIndex < MenuList.list.Count-3) {
                focusedIndex++;
                SetStack(focusedIndex);
            }
        }
        public static void ScrollUp()
        {
            if (focusedIndex >0)
            {
                focusedIndex--;
                SetStack(focusedIndex);
            }
        }

    }

}
