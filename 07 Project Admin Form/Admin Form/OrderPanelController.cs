using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Form
{
    public static class OrderPanelController
    {
        public static AdminForm form;
        public static Panel panel;
        public static DataGridView ordersGrid;
        public static DataSet ds;
        public static MyGridView myGridView;
        public static void Init(Panel _panel, AdminForm _adminForm, DataGridView _ordersGrid) {
            panel = _panel;
            form = _adminForm;
            ordersGrid = _ordersGrid;
            form.Controls.Add(panel);
            panel.Visible = false;
            ordersGrid.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold);
            myGridView = new MyGridView(form, panel, ordersGrid);
        }
        public static void ShowAllOrders()
        {
            ds = DatabaseController.GetAllOrders();
            ordersGrid.DataSource = ds.Tables[0];
            myGridView.Set();
        }
        
        public static void ShowTodayOrders() {
            ds = DatabaseController.GetOrdersBetween(DateTime.Today, DateTime.Today.Add(TimeSpan.FromDays(1)));
            ordersGrid.DataSource = ds.Tables[0];
            myGridView.Set();
        }
        public static void ShowCustomOrders(params DateTime[] datetimes)
        {
            ds = DatabaseController.GetOrdersBetween(
                datetimes[0].Date.Add(datetimes[1].TimeOfDay).Add(TimeSpan.FromSeconds(-datetimes[1].Second)),
                datetimes[2].Date.Add(datetimes[3].TimeOfDay).Add(TimeSpan.FromSeconds(-datetimes[3].Second))
                );
            ordersGrid.DataSource = ds.Tables[0];
            myGridView.Set();
        }
        public static void ShowOrderByID() {
            ds = DatabaseController.GetOrderByID(Convert.ToInt32(form.itemIDTextBox.Text));
            ordersGrid.DataSource = ds.Tables[0];
            myGridView.Set();
        }
        public static void Filter() {
            myGridView.Filter();
            if (form.itemNameTextBox.Text == "")
            {
                form.filteredQuantityTextbox.Hide();
                
            }else myGridView.CaculateFilteredItems();

        }
        public static void Clear()
        {
            myGridView.DataSource= null;
        }

    }
}
