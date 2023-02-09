using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_Employee_Form
{
    public partial class EmployeeForm : Form
    {
        public static EmployeeForm Form;
        public static FlowLayoutPanel flowLayoutPanel;
        public List<String> commands = new List<String>();
        private System.Windows.Forms.Timer timer;
        public EmployeeForm()
        {
            InitializeComponent(); 
            Init();
            Show();
            Update();
            NetworkController.Init(this);
            StartUpdatingStatus();
            noConnectionLabel.Hide();
            NotifyLabel.Add("Đã kết nối !!!");

        }
        private void Init() {
            Form = this;
            flowLayoutPanel = _flowLayoutPanel1;
            flowLayoutPanel.MouseDown += new MouseEventHandler(Form1_MouseDown);
            flowLayoutPanel.MouseMove += new MouseEventHandler(Form1_MouseMove);
            flowLayoutPanel.MouseUp += new MouseEventHandler(Form1_MouseUp);
            flowLayoutPanel.Width = Width - 10;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.AutoScroll = true;
            StartPosition = FormStartPosition.Manual; Left = 904; Top =10;
            Icon = new Icon(@"icon.ico");
            NotifyLabel.Init(flowLayoutPanel);
            flowLayoutPanel.Controls.Add(label1);
        }
        private void StartUpdatingStatus()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }
        private void Update(object sender, EventArgs e)
        {
            try
            {
                foreach (String cmd in commands)
                {
                    String[] stringArray = cmd.Split('$');
                    switch (stringArray[0])
                    {
                        case "dispose": Dispose(); break;
                        case "addFoodOrder"://str = 0"addFoodOrder$"+1_tableNumber+"$"+2_menuItemName+"$"+3_quantity+"$";
                            new NotifierFoodOrder(Convert.ToInt32(stringArray[1]), stringArray[2], Convert.ToInt32(stringArray[3]));
                            break;
                        case "callService"://string str = "callService$" + _tableName + "$";
                            new NotifierCallService(stringArray[1]);
                            break;
                        case "finishOrders"://string str = "callService$" + _tableName + "$";
                            new NotifierFinishOrders(stringArray[1]);
                            break;
                    }
                }
                commands.Clear();
            }
            catch (Exception) { Console.WriteLine("Update() Error"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new NotifierFoodOrder(1,"Bánh tôm chiên",10);
            //new NotifierCallService("Bàn số 33");
            new NotifierFinishOrders("Bàn số 33");
        }
        private static bool mouseDown;
        private static Point lastLocation;

        public static void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        

        public static void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Form.Location = new Point(
                    (Form.Location.X - lastLocation.X) + e.X, (Form.Location.Y - lastLocation.Y) + e.Y);

                Form.Update();
            }
        }

        public static void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
