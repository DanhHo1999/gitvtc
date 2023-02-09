using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_Employee_Form
{
    public class NotifierFinishOrders
    {
        private Panel panel = new Panel();
        private Label tableName = new Label();
        private Label contentLabel = new Label();
        private Label time = new Label();
        private Button finishButton = new Button();
        private Font font = new Font("Arial", 10, FontStyle.Bold);
        private DateTime dateTime = new DateTime();
        private Color panelColor = Color.FromArgb(220, 255, 220);


        public NotifierFinishOrders(string _tableName)
        {
            panel.Height = 50;
            panel.Width = EmployeeForm.flowLayoutPanel.Width - 30;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10, 10, 10, 10);
            panel.BackColor = panelColor;
            EmployeeForm.flowLayoutPanel.Controls.Add(panel);
            panel.MouseDown += new MouseEventHandler(EmployeeForm.Form1_MouseDown);
            panel.MouseMove += new MouseEventHandler(EmployeeForm.Form1_MouseMove);
            panel.MouseUp += new MouseEventHandler(EmployeeForm.Form1_MouseUp);

            panel.Controls.Add(tableName);
            tableName.Text = _tableName;
            tableName.Font = font;
            tableName.Location = new Point(5, 5);

            panel.Controls.Add(contentLabel);
            contentLabel.Text = "Khách đã thanh toán";
            contentLabel.Font = font;
            contentLabel.ForeColor = Color.FromArgb(0, 100, 0);
            contentLabel.AutoSize = true;
            contentLabel.Location = new Point(180, 5);

            

            panel.Controls.Add(finishButton);
            finishButton.Text = "Hoàn tất";
            finishButton.Font = font;
            finishButton.ForeColor = Color.Red;
            finishButton.BackColor = EmployeeForm.flowLayoutPanel.BackColor;
            finishButton.AutoSize = true;
            finishButton.BringToFront();
            finishButton.Location = new Point(550, 12);


            finishButton.Click += new EventHandler((s, e) => {
                panel.Dispose();
            });
            NotifyLabel.Add("Payment Completed !!!");
        }
    }
}
