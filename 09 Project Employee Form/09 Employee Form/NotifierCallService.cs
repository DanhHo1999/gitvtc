using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_Employee_Form
{
    public class NotifierCallService
    {
        private Panel panel = new Panel();
        private Label tableName = new Label();
        private Label contentLabel = new Label();
        private Label time = new Label();
        private Button finishButton = new Button();
        private Font font = new Font("Arial", 10, FontStyle.Bold);
        private DateTime dateTime = new DateTime();
        private Color panelColor = Color.FromArgb(255, 192, 192);


        public NotifierCallService(string _tableName)
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
            tableName.Text =_tableName;
            tableName.Font = font;
            tableName.Location = new Point(5, 5);

            panel.Controls.Add(contentLabel);
            contentLabel.Text = "Yêu cầu hỗ trợ";
            contentLabel.Font = font;
            contentLabel.AutoSize = true;
            contentLabel.Location = new Point(180, 5);

            panel.Controls.Add(time);
            time.Text = "Thời gian: 0 giây";
            time.Font = font;
            time.Location = new Point(200, 28);
            time.ForeColor = Color.Red;
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
            NotifyLabel.Add("Customer Service");
        }
    }
}
