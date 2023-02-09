using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_Employee_Form
{
    public static class NotifyLabel
    {
        private static Label label = new Label();
        private static List<String> list = new List<String>();  
        public static void Init(Panel _panel) { 
            _panel.Controls.Add(label);
            label.Text = " ";
            label.Font=new Font("Arial",20,FontStyle.Bold);
            label.ForeColor=Color.Red;
            label.Height = 50;
            label.Width = EmployeeForm.flowLayoutPanel.Width - 200;
            label.Margin = new Padding(50, 10, 10, 10);
            //label.BorderStyle = BorderStyle.FixedSingle;
        }
        public static void Add(string str) {
            if (list.Count < 5) list.Add(str);

            if (list.Count == 1)
            {
                Run(list[0]);
            }
        }
        private static void Run(string str) {
            
            string str2 = "                                                                     ";
            foreach (char c in str) {
                str2 += c + " ";
            }
            label.Text = str2;
            Timer timer =new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler((s, e) => {
                try { label.Text = label.Text.Substring(1);EmployeeForm.Form.Update(); } catch (Exception) {
                    timer.Dispose();
                    list.Remove(list[0]);
                    if (list.Count>0)
                    {
                        Run(list[0]);
                    }
                }
            });
            timer.Start();

        }
    }
}
