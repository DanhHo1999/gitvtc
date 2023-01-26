using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Table_Form.Properties;

namespace Table_Form
{
    public static class PinPanelControl
    {
        public class NumberButton {
            public int number;
            public PictureBox pictureBox;
            public NumberButton(int _number) { 
                number=_number;
                pictureBox = new PictureBox();
                pictureBox.Size = new Size(40, 40);
                switch (number) { 
                    case 0: pictureBox.Image = Resources.Number_0;break;
                    case 1: pictureBox.Image = Resources.Number_1;break;
                    case 2: pictureBox.Image = Resources.Number_2;break;
                    case 3: pictureBox.Image = Resources.Number_3;break;
                    case 4: pictureBox.Image = Resources.Number_4;break;
                    case 5: pictureBox.Image = Resources.Number_5;break;
                    case 6: pictureBox.Image = Resources.Number_6;break;
                    case 7: pictureBox.Image = Resources.Number_7;break;
                    case 8: pictureBox.Image = Resources.Number_8;break;
                    case 9: pictureBox.Image = Resources.Number_9;break;
                }
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(pictureBox);
                pictureBox.Visible = true;
                pictureBox.MouseDown += new MouseEventHandler(PINNumber_OnClick);
            }
            public void SetLocation(Point _point) {
                pictureBox.Location = _point;
            }

            private void PINNumber_OnClick(object sender, EventArgs e)
            {
                PressNumber(number);
            }
        }
        private static Panel panel;
        private static Form1 form;
        private static int left = 225;
        private static int top = 140;
        private static int rowDistance=60;
        private static int columnDistance = 60;
        private static Label codeLabel1;
        private static Label codeLabel2;
        private static Label codeLabel3;
        private static Label codeLabel4;
        public static Label infoLabel;
        private static int numbers = 0;
        private static String pinCode = "";
        public static void Init(Panel _panel, Form1 _form)
        {
            form = _form;
            panel = _panel;
            panel.Location = new Point(0, 0);
            codeLabel1 = new DesignedLabel();
            panel.Controls.Add(codeLabel1);
            codeLabel1.Location = new Point(left, top - (int)(rowDistance * 1.2));
            codeLabel1.Font = new Font("Berlin Sans FB Demi", 25);
            codeLabel1.AutoSize = true;
            codeLabel1.Text = "_";
            codeLabel2 = new DesignedLabel();
            panel.Controls.Add(codeLabel2);
            codeLabel2.Location = new Point(left + (int)(columnDistance * 0.7), top - (int)(rowDistance * 1.2));
            codeLabel2.Font = new Font("Berlin Sans FB Demi", 25);
            codeLabel2.AutoSize = true;
            codeLabel2.Text = "_";
            codeLabel3 = new DesignedLabel();
            panel.Controls.Add(codeLabel3);
            codeLabel3.Location = new Point(left + (int)(columnDistance * 1.4), top - (int)(rowDistance * 1.2));
            codeLabel3.Font = new Font("Berlin Sans FB Demi", 25);
            codeLabel3.AutoSize = true;
            codeLabel3.Text = "_";
            codeLabel4 = new DesignedLabel();
            panel.Controls.Add(codeLabel4);
            codeLabel4.Location = new Point(left+(int)(columnDistance * 2.1), top - (int)(rowDistance * 1.2));
            codeLabel4.Font = new Font("Berlin Sans FB Demi", 25);
            codeLabel4.AutoSize = true;
            codeLabel4.Text = "_";
            infoLabel = new DesignedLabel();
            panel.Controls.Add(infoLabel);
            infoLabel.Location = new Point(left*2, top - (int)(rowDistance * 1.2));
            infoLabel.Font = new Font("Arial", 15);
            infoLabel.AutoSize = true;
            infoLabel.Text = "PIN Sai";
            infoLabel.Hide();
            panel.Hide();
            (new NumberButton(1)).SetLocation(new Point(left + rowDistance * 0, top + columnDistance * 0));
            (new NumberButton(2)).SetLocation(new Point(left + rowDistance * 1, top + columnDistance * 0));
            (new NumberButton(3)).SetLocation(new Point(left + rowDistance * 2, top + columnDistance * 0));
            (new NumberButton(4)).SetLocation(new Point(left + rowDistance * 0, top + columnDistance * 1));
            (new NumberButton(5)).SetLocation(new Point(left + rowDistance * 1, top + columnDistance * 1));
            (new NumberButton(6)).SetLocation(new Point(left + rowDistance * 2, top + columnDistance * 1));
            (new NumberButton(7)).SetLocation(new Point(left + rowDistance * 0, top + columnDistance * 2));
            (new NumberButton(8)).SetLocation(new Point(left + rowDistance * 1, top + columnDistance * 2));
            (new NumberButton(9)).SetLocation(new Point(left + rowDistance * 2, top + columnDistance * 2));
            (new NumberButton(0)).SetLocation(new Point(left + rowDistance * 1, top + columnDistance * 3));
        }
        private static void PressNumber(int _number) {
            AddCode(_number);
        }
        private static void AddCode(int _number)
        {
            if (numbers == 0) { codeLabel1.Text = "X"; numbers++; pinCode += _number.ToString(); infoLabel.Hide(); return; }
            if (numbers == 1) { codeLabel2.Text = "X"; numbers++; pinCode += _number.ToString(); infoLabel.Hide(); return; }
            if (numbers == 2) { codeLabel3.Text = "X"; numbers++; pinCode += _number.ToString(); infoLabel.Hide(); return; }
            if (numbers == 3) { codeLabel4.Text = "X"; numbers++; pinCode += _number.ToString(); infoLabel.Hide(); return; }
        }
        public static void pinPanelConfirmBtn_Click()
        {
            
            if (numbers == 4)
            {
                NetworkControl.SendCode(pinCode);
                pinCode = "";
                codeLabel1.Text = "_";
                codeLabel2.Text = "_";
                codeLabel3.Text = "_";
                codeLabel4.Text = "_";

                numbers = 0;
                return;
            }
        }
    }
}
