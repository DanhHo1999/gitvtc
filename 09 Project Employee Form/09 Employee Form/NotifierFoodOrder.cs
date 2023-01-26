using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_Employee_Form
{
    public class NotifierFoodOrder
    {
        private Panel panel = new Panel();
        private Label tableName=new Label();
        private Label menuItemName = new Label();
        private Label quantity = new Label();
        private Label time = new Label();
        private Button finishButton = new Button();
        private Font font = new Font("Arial", 10, FontStyle.Bold);
        private DateTime dateTime =new DateTime();
        

        public NotifierFoodOrder(int _tableNumber,string _menuItemName,int _quantity)
        {
            panel.Height = 50;
            panel.Width = EmployeeForm.flowLayoutPanel.Width - 30;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10, 10, 10, 10);
            panel.BackColor = Color.LightYellow;
            EmployeeForm.flowLayoutPanel.Controls.Add(panel);
            panel.MouseDown += new MouseEventHandler(EmployeeForm.Form1_MouseDown);
            panel.MouseMove += new MouseEventHandler(EmployeeForm.Form1_MouseMove);
            panel.MouseUp += new MouseEventHandler(EmployeeForm.Form1_MouseUp);

            panel.Controls.Add(tableName);
            tableName.Text = "Bàn số "+ _tableNumber;
            tableName.Font = font;
            tableName.Location = new Point(5, 5);

            panel.Controls.Add(menuItemName);
            menuItemName.Text = _menuItemName;
            menuItemName.Font = font;
            menuItemName.AutoSize = true;
            menuItemName.Location = new Point(180, 5);

            panel.Controls.Add(quantity);
            quantity.Text = "Số lượng : "+ _quantity;
            quantity.Font = font;
            quantity.Location = new Point(420, 5);

            panel.Controls.Add(time);
            time.Text = "Thời gian: 0 giây";
            time.Font = font;
            time.Location = new Point(200, 28);
            time.ForeColor= Color.Red;
            time.Width = 200;

            panel.Controls.Add(finishButton);
            finishButton.Text = "Hoàn tất";
            finishButton.Font = font;
            finishButton.ForeColor = Color.Red;
            finishButton.BackColor = EmployeeForm.flowLayoutPanel.BackColor;
            finishButton.AutoSize = true;
            finishButton.BringToFront();
            finishButton.Location = new Point(550, 12);


            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler((s, e) =>
            {
                dateTime = dateTime.Add(TimeSpan.FromSeconds(1));
                if (dateTime.Hour == 0)
                {
                    if (dateTime.Minute == 0)
                    {
                        time.Text = dateTime.ToString("'Thời gian: 's' giây'");
                    }
                    else
                    {
                        time.Text = dateTime.ToString("'Thời gian: 'm' phút 's' giây'");
                    }
                }
                else
                {
                    time.Text = dateTime.ToString("'Thời gian: 'H' giờ 'm' phút 's' giây'");
                }
            });
            timer.Start();

            finishButton.Click += new EventHandler((s, e) => { 
                panel.Dispose();
            });
            NotifyLabel.Add("New Order");
        }
    }
}
