using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Table_Form
{
    public static class PayPanelControl
    {
        public static PictureBox inputCardButton;
        public static PictureBox cancelButton;
        public static Form1 form;
        public static Panel panel;
        public static DesignedLabel totalPriceLabel;
        public static bool IsFocused = false;
        public static DesignedLabel loadingLabel;
        public static int percent = 0;
        public static System.Windows.Forms.Timer myTimer;
        public static BillForm billForm;
        public static void Init(Form1 _form) { 
            form=_form;
            panel = form.payPanel;
            form.payPanel.Location = new Point(0, 0);
            panel.Hide();
            form.inputCardPanel.Hide();

            totalPriceLabel = new DesignedLabel(panel);
            totalPriceLabel.Width = 600;
            totalPriceLabel.Height+=25;
            totalPriceLabel.Location = new Point(100, 200-(totalPriceLabel.Height/2));
            totalPriceLabel.Font = new Font("Arial", 24F);

        }
        public static void ActivatePayPanel() {
            IsFocused = true;
            totalPriceLabel.Text ="Tổng cộng: "+ OrderPanelControl.ToVND(OrderList.TotalConfirmedPrice());
        }
        public static void DeactivatePayPanel() { 
            IsFocused=false;
        }
        public static void OpenInputCardPanel() { 
            DeactivatePayPanel();
            form.inputCardPanel.Show();
        }
        public static void CloseInputCardPanel() { 
            ActivatePayPanel();
            form.inputCardPanel.Hide();
        }
        public static void Pay() {
            inputCardButton.Hide();
            cancelButton.Hide();
            loadingLabel = new DesignedLabel(form.inputCardPanel);
            loadingLabel.Width = 200;
            loadingLabel.Height += 50;
            loadingLabel.Location = new Point(165,110);
            loadingLabel.Text = "0%";
            loadingLabel.Font = new Font("Arial", 20F);
            
            myTimer=new System.Windows.Forms.Timer();
            myTimer.Interval=150;
            myTimer.Tick += new EventHandler(MyTimer_Tick);
            myTimer.Start();
            


            //Timer
            //serviceTimer = new System.Windows.Forms.Timer();
            //serviceTimer.Interval = 1000;
            //serviceTimer.Tick += new EventHandler(MyTimer_Tick);
            //serviceTimer.Start();


        }
        private static void MyTimer_Tick(object sender, EventArgs e) {
            if (percent == 13) { myTimer.Dispose();  }
            percent++;
            if(percent<=10) loadingLabel.Text = percent.ToString() + "0 %";
            if (percent > 13) End();
        }
        private static void End() {
            //Close inputCardPanel
            percent = 0;
            loadingLabel.Dispose();
            form.inputCardPanel.Hide();
            inputCardButton.Show();
            cancelButton.Show();
            panel.Hide();

            //Create Bill
            if (billForm != null) { billForm.Dispose(); }
            
            NetworkControl.GetNextOrderID();
            while (Form1.orderNumber == 0) {
                Thread.Sleep(100);
            }
            billForm = new BillForm();
            NetworkControl.Finish();
            Form1.CallService = 3;

            //Clear orders and open orderPanel
            OrderList.list.Clear();
            Form1.orderNumber = 0;
            Form1._orderPanelControl.ClearLabels();
            OrderPanelControl.focusedIndex = 0;
            form.startPanel.Show();
            form.startButton.Show();
            form.orderPanelControl.notConfirmedTotalPriceLabel.Hide();
        }
    }
}
