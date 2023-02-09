using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Table_Form.Properties;

namespace Table_Form
{
    public partial class Form1 : Form
    {

        //Manual
        private static bool isStarting = false;
        public static int callServiceTime = 60;
        public static Color labelColor = Color.Yellow;
        public static Color notConfirmedColor = Color.Red;
        public static Font labelFont = new Font("Arial", 13F);


        public static Form1 form;
        public static int orderNumber = 0;
        public OrderPanelControl orderPanelControl;
        public static int CallService = callServiceTime;
        public static DesignedLabel serviceTimeLabel = new DesignedLabel();
        public static System.Windows.Forms.Timer serviceTimer;
        public static OrderPanelControl _orderPanelControl;
        public static List<Panel> panels = new List<Panel>();
        public static string picturesFolderPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, @"Pictures");
        public static string ToImageFilePath(String _menuItemName) {

            return picturesFolderPath + @"\" + _menuItemName + @".png";
        }
        private void TestingVoid() {
            Console.WriteLine(picturesFolderPath);

        }
        
        public Form1()
        {
            form = this;
            Icon = new Icon(picturesFolderPath + @"\icon.ico");
            InitializeComponent();
            panels.Add(orderPanel);
            panels.Add(startPanel);
            panels.Add(menuPanel);
            panels.Add(menuItemOrderingPanel);
            panels.Add(payPanel);
            panels.Add(pinPanel);
            StartPosition = FormStartPosition.Manual;Left = 1315;Top = 635;
            FormBorderStyle = FormBorderStyle.None;
            Width = 600;
            Height = 400;
            orderPanel.Location = new Point(0, 0);
            BackgroundImage = Table_Form.Properties.Resources.Background;
            AllPanelsLabel tableNumberLabel = new AllPanelsLabel();
            tableNumberLabel.SetLocation(new Point(500, 35)).SetText(" ");
            AllPanelsLabel restaurantName = new AllPanelsLabel();
            restaurantName.SetLocation(new Point(450, 10)).SetText("DANH DIMSUM").Width(150);
            menuPanel.Hide();
            menuPanel.Location = orderPanel.Location;
            MenuPanelControl.parent = menuPanel;
            MenuPanelControl.Init(this);
            menuItemOrderingPanel.Hide();
            menuItemOrderingPanel.Location = orderPanel.Location;
            MenuItemOrderingControl.parent = menuItemOrderingPanel;
            MenuItemOrderingControl.Init(this);
            PayPanelControl.Init(this);
            PayPanelControl.inputCardButton = inputCardBtn;
            PayPanelControl.cancelButton = cancelInputCardBtn;
            payButton.Hide();
            orderPanel.Hide();
            startPanel.Location = orderPanel.Location;
            serviceTimeLabel.Location = new Point(ringButton.Location.X + 30, ringButton.Location.Y);
            serviceTimeLabel.Hide();
            orderPanel.Controls.Add(serviceTimeLabel);
            PinPanelControl.Init(pinPanel, this);
            OrderPanelControl.parent = orderPanel;
            orderPanelControl = new OrderPanelControl(orderPanel,this);
            _orderPanelControl = orderPanelControl;
            //orderPanelControl.PrintLabels(OrderPanelControl.focusedIndex);

            NetworkControl.Init(this);
            int table_number = Convert.ToInt32(NetworkControl.GetTableName());
            Left -= (table_number - 1) * 100;
            if (Left < 0) Left = 0;
            tableNumberLabel.SetText("Bàn số " + table_number);
            Text = "Table " + table_number.ToString();
            MenuPanelControl.Start();
            StartUpdatingStatus();

        }
        public class AllPanelsLabel {
            private List<Label> labels = new List<Label>();
            public AllPanelsLabel() {
                foreach (Panel panel in panels) { 
                    labels.Add(new DesignedLabel(panel));
                }
            }
            public AllPanelsLabel SetText(string _text) {
                foreach (Label label in labels) { 
                    label.Text = _text;
                }
                return this;
            }
            public AllPanelsLabel SetLocation(Point _point) {
                foreach (Label label in labels)
                {
                    label.Location = _point;
                }
                return this;
            }
            public AllPanelsLabel Width(int _width)
            {
                foreach (Label label in labels)
                {
                    label.Width = _width;
                }
                return this;
            }
        }

        public void MenuItemLabel_OnClick(object sender, EventArgs e)
        {
            menuPanel.Hide();
            menuItemOrderingPanel.Show();
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (CallService == 0)
            {
                CallService = callServiceTime;
                serviceTimeLabel.Text = CallService.ToString();
                return;
            }
            if (CallService > 1)
            {
                CallService -= 1;
                serviceTimeLabel.Text = CallService.ToString();
                return;
            }
            if (CallService == 1)
            {
                CallService = 0;
                //Stop Timer Process
                try
                {
                    CallService = callServiceTime;
                    ringButton.Show();
                    serviceTimeLabel.Hide();
                    ((System.Windows.Forms.Timer)sender).Stop();
                }
                catch (Exception) {
                    Console.WriteLine("failed");
                }
            }
        }

        

        private void ringButton_Click(object sender, EventArgs e)
        {
            serviceTimeLabel.Show();
            ringButton.Hide();
            serviceTimeLabel.Text = callServiceTime.ToString();
            serviceTimer = new System.Windows.Forms.Timer();
            serviceTimer.Interval = 1000;
            serviceTimer.Tick += new EventHandler(MyTimer_Tick);
            serviceTimer.Start();
            NetworkControl.CallService();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            orderPanel.Hide();
            menuPanel.Show();
            MenuPanelControl.focusedIndex = 0;
            MenuPanelControl.SetStack(0);
            
        }
        

        private void menuBackButton_Click(object sender, EventArgs e)
        {
            orderPanel.Show();
            menuPanel.Hide();
            
        }

        

        

        private void menuOrderingBackBtn_Click(object sender, EventArgs e)
        {
            menuPanel.Show();
            menuItemOrderingPanel.Hide();
        }

        private void menuOrderingConfirmButton_Click(object sender, EventArgs e)
        {
            OrderList.list.Add(new OrderItem(MenuItemOrderingControl.menuItem, MenuItemOrderingControl.quantity));
            menuItemOrderingPanel.Hide();
            orderPanel.Show();
            orderPanelControl.PrintLabels(OrderPanelControl.focusedIndex);
            
            

        }

        private void payButton_Click(object sender, EventArgs e)
        {
            
            orderPanel.Hide();
            payPanel.Show();
            PayPanelControl.ActivatePayPanel();
        }

        private void payPanelBackBtn_Click(object sender, EventArgs e)
        {
            if (!PayPanelControl.IsFocused) return;
            orderPanel.Show();
            payPanel.Hide();
        }

        private void payPanelPayBtn_Click(object sender, EventArgs e)
        {
            if (!PayPanelControl.IsFocused) return;
            PayPanelControl.OpenInputCardPanel();
        }

        private void cancelInputCardBtn_Click(object sender, EventArgs e)
        {
            PayPanelControl.CloseInputCardPanel();
        }

        private void inputCardBtn_Click(object sender, EventArgs e)
        {
            PayPanelControl.Pay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BillForm();


            //Generate Random Order
            //MenuItem example_item = MenuList.list[(new Random()).Next(MenuList.list.Count - 1)];
            //int example_quantity = (new Random()).Next(1, 7);
            //OrderList.list.Add(new OrderItem(example_item, example_quantity));
            //NetworkControl.AddOrder(example_item.name, example_quantity);
            //payButton.Show();
            //orderPanelControl.PrintLabels(OrderPanelControl.focusedIndex);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            Update();
            NetworkControl.GetMenuList();
            TestingVoid();
            isStarting = true;
            
        }
        public void IsStarting() {
            if (!isStarting) return;
            payButton.Hide();
            pinPanel.Show();
            startPanel.Hide();
            isStarting = false;
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        private void PINCorrect() {
            PinPanelControl.infoLabel.Text = "PIN Đúng";
            PinPanelControl.infoLabel.Show();
            System.Windows.Forms.Timer myTimer =new System.Windows.Forms.Timer();
            myTimer.Interval = 1000;
            myTimer.Tick+= new EventHandler((a, b) => {
                pinPanel.Hide();
                orderPanel.Show();
                orderPanelControl.confirmedTotalPriceLabel.Text = "0 VNĐ";
                PinPanelControl.infoLabel.Text = "PIN Sai";
                PinPanelControl.infoLabel.Hide();
                myTimer.Dispose();
            });
            myTimer.Start();
        }
        private void PINIncorrect() {
            PinPanelControl.infoLabel.Show();
        }

        public List<String> commands = new List<String>();
        private static System.Windows.Forms.Timer timer;
        public void StartUpdatingStatus()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }
        private void Update(object sender, EventArgs e)
        {
            try {
                foreach (String cmd in commands)
                {
                    String[] strings = cmd.Split('$');
                    switch (strings[0])
                    {
                        case "dispose": Dispose(); break;
                        case "pinCorrect": PINCorrect(); break;
                        case "pinIncorrect": PINIncorrect(); break;
                        case "menuList": MenuList.GetNewListFromServer(strings[1]); break;
                        case "removeOrder": OrderPanelControl.RemoveOrder(Convert.ToInt32(strings[1])); break;
                        case "addPicture":
                            try
                            {
                                MenuItem item = MenuList.GetMenuItem(strings[1]);
                                item.DownloadPicture();
                                MenuPanelControl.SetStack(MenuPanelControl.focusedIndex);
                            }
                            catch (Exception ex) { }
                            break;
                    }
                }
                commands.Clear();
            }
            catch (Exception) { Console.WriteLine("Update() Error"); }
        }

        private void testBtn2_Click(object sender, EventArgs e)
        { 
            
        }

        private void pinPanelConfirmBtn_Click(object sender, EventArgs e)
        {
            PinPanelControl.pinPanelConfirmBtn_Click();
        }

        private void orderingPanelConfirmButton_Click(object sender, EventArgs e)
        {

            Panel confirmFoodPanel = new Panel();
            confirmFoodPanel.Location = new Point(100, 75);
            confirmFoodPanel.Width = 400;
            confirmFoodPanel.Height = 250;
            confirmFoodPanel.BackColor = Color.Transparent;
            confirmFoodPanel.BorderStyle = BorderStyle.Fixed3D;
            orderPanel.Controls.Add(confirmFoodPanel);
            confirmFoodPanel.BringToFront();
            orderPanelControl.DisableAllButtons();

            PictureBox confirmBox = new PictureBox();
            confirmFoodPanel.Controls.Add(confirmBox);
            confirmBox.Location = new Point(150, 70);
            confirmBox.Image = Resources.Confirm;
            confirmBox.SizeMode = PictureBoxSizeMode.AutoSize;
            
            PictureBox cancelBox = new PictureBox();
            confirmFoodPanel.Controls.Add(cancelBox); 
            cancelBox.Location = new Point(150, 150);
            cancelBox.Image = Resources.Cancel;
            cancelBox.SizeMode = PictureBoxSizeMode.AutoSize;

            cancelBox.Click += new EventHandler((s,ee) => {
                orderPanelControl.EnableAllButtons();
                cancelBox.Dispose();
                confirmBox.Dispose();
                confirmFoodPanel.Dispose();
            });
            

            confirmBox.Click += new EventHandler((s, ee) => {
                orderPanelControl.EnableAllButtons();
                cancelBox.Dispose();
                confirmBox.Dispose();
                confirmFoodPanel.Dispose();
                orderPanelControl.ConfirmAllMenuItems();
                orderingPanelConfirmButton.Hide();
                payButton.Show();
            });
        }

        

        private void menuDownArrow_MouseDown(object sender, MouseEventArgs e)
        {
            MenuPanelControl.ScrollDown();
        }

        private void menuUpArrow_MouseDown(object sender, MouseEventArgs e)
        {
            MenuPanelControl.ScrollUp();
        }

        private void itemOrderingRightArrow_Click(object sender, MouseEventArgs e)
        {
            MenuItemOrderingControl.RightArrow_Click();
        }
        
        private void itemOrderingLeftArrow_Click(object sender, MouseEventArgs e)
        {
            MenuItemOrderingControl.LeftArrow_Click();
        }

        private void downArrow_Click(object sender, MouseEventArgs e)
        {
            orderPanelControl.ScrollDown();
        }

        private void upArrow_Click(object sender, MouseEventArgs e)
        {
            orderPanelControl.ScrollUp();
        }

        
    }
}
