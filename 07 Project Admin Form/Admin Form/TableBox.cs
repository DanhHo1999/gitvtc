using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Form
{
    public class TableBox
    {

        private Panel panel;
        public Label tableNameLabel;
        private ComboBox tableOrdersComboBox;
        private Button deleteOrderButton;
        private List<Order> ordersList;
        private DataTable dataTable = new DataTable();
        private Label totalOrderPriceLabel;
        private Button closeTableButton;
        

        public TableBox() {
            ordersList = new List<Order>();
            panel = new Panel();
            panel.Height = 50;
            panel.Width = AdminForm.tablesFlowLayoutPanel.Width - 10;
            panel.BorderStyle = BorderStyle.FixedSingle;
            AdminForm.tablesFlowLayoutPanel.Controls.Add(panel);

            tableNameLabel = new Label();
            panel.Controls.Add(tableNameLabel);
            tableNameLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            tableNameLabel.Text = "Bàn số 0";
            tableNameLabel.Width = 120;
            tableNameLabel.Height = 50;
            tableNameLabel.Location = new Point(17, 17);

            tableOrdersComboBox = new ComboBox();
            panel.Controls.Add(tableOrdersComboBox);
            tableOrdersComboBox.Font = new Font("Arial", 10, FontStyle.Bold);
            tableOrdersComboBox.Width = 400;
            tableOrdersComboBox.Location = new Point(tableNameLabel.Width + 20, 12);
            tableOrdersComboBox.KeyPress += new KeyPressEventHandler((huhu, e) => { e.Handled = true; });
            tableOrdersComboBox.DisplayMember = "Label";

            deleteOrderButton = new Button();
            panel.Controls.Add(deleteOrderButton);
            deleteOrderButton.Font = new Font("Arial", 10, FontStyle.Bold);
            deleteOrderButton.Text = "Xóa món ăn";
            deleteOrderButton.AutoSize = true;
            deleteOrderButton.Location = new Point(550, 11);
            deleteOrderButton.Click += new EventHandler(deleteOrderButton_Click);

            totalOrderPriceLabel = new Label();
            panel.Controls.Add(totalOrderPriceLabel);
            totalOrderPriceLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            totalOrderPriceLabel.Text = "Tổng: ";
            totalOrderPriceLabel.Location = new Point(655, 17);
            totalOrderPriceLabel.AutoSize = true;
            CalculatePrice();


            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("Label", typeof(string));

            closeTableButton=new Button();
            panel.Controls.Add(closeTableButton);
            closeTableButton.Width = 1;
            closeTableButton.Height= 1;
            closeTableButton.Text = "x";
            closeTableButton.AutoSize = true;
            closeTableButton.Location = new Point(panel.Width - closeTableButton.Width - 3, 1);
            closeTableButton.Click += new EventHandler((s, e) => {
                if (MessageBox.Show("Đóng "+tableNameLabel.Text.ToLower()+" ?",
                                        "Thông báo",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                {
                    return;
                }
                AdminForm.form.Notify("Đã đóng " + tableNameLabel.Text.ToLower());
                Log.Write("Đóng " + tableNameLabel.Text.ToLower()); 
                Tables.CloseTable(this);
            });
            Tables.boxesList.Add(this);
        }
        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (ordersList.Count == 0) return;
            if (MessageBox.Show("Chắc chắn ?",
                                           "Xóa món ăn !!",
                                           MessageBoxButtons.OKCancel) != DialogResult.OK)
            {

                return;
            }
            DeleteOrder(tableOrdersComboBox.SelectedIndex);
            
        }
        private string MenuItemTotalPrice(string _menuItemName, int _quantity)
        {
            string str = _menuItemName + " | Số lượng: " + _quantity + " | Tổng: " + MenuList.GetItem(_menuItemName).ToPrice(_quantity);
            return str;
        }
        private void RefreshComboBox() {
            tableOrdersComboBox.DataSource = dataTable;
        }

        public void Dispose() {
            ordersList.Clear();
            dataTable.Clear();
            dataTable.Dispose();
            deleteOrderButton.Dispose();
            tableNameLabel.Text = "";
            tableNameLabel.Dispose();
            tableOrdersComboBox.Dispose();
            panel.Dispose();
        }
        public void AddOrder(String _menuItemName, int _quantity) {
            ordersList.Add(new Order(MenuList.GetItem(_menuItemName), _quantity));
            dataTable.Rows.Add(_menuItemName, _quantity, MenuItemTotalPrice(_menuItemName, _quantity));
            RefreshComboBox();
            CalculatePrice();
        }
        public void DeleteOrder(int _index) {
            if (_index < ordersList.Count) {
                string orderName = ((DataTable)tableOrdersComboBox.DataSource).Rows[tableOrdersComboBox.SelectedIndex]["Name"].ToString();
                int quantity = Convert.ToInt32(((DataTable)tableOrdersComboBox.DataSource).Rows[tableOrdersComboBox.SelectedIndex]["Quantity"].ToString());
                string tableName = tableNameLabel.Text;
                Log.Write("Hủy " + quantity + " món " + orderName + " ở " + tableName);
                ordersList.RemoveAt(_index);
                dataTable.Rows.RemoveAt(_index);
                RefreshComboBox();
                CalculatePrice();
                
                Tables.GetTable(tableNameLabel.Text).RemoveOrder(_index);
            }
        }
        public TableBox SetTableName(string _newTableName) {
            tableNameLabel.Text = _newTableName;
            return this;
        }
        private void CalculatePrice()
        {
            
            int total = 0;
            foreach (Order order in ordersList)
            {
                total += order.menuItem.price*order.quantity;
            }
            totalOrderPriceLabel.Text = String.Format("Tổng: {0:N0} VND", total);
            
        }
        public void FinishOrders() {
            EmployeeConnector.FinishOrders(tableNameLabel.Text);
            CreateOrder();
            ordersList.Clear();
            dataTable.Clear();
            CalculatePrice();
            RefreshComboBox();
        }
        public void CreateOrder() {
            int id = Tables.GetTable(tableNameLabel.Text).myOrderID;
            int orderTotal = 0;
            foreach (Order order in ordersList) {
                DatabaseController.AddOrderItem(id, order.menuItem.name, order.quantity);
                orderTotal+=order.menuItem.price*order.quantity;
            }
            DatabaseController.SetOrderTotal(id, orderTotal);
        }
        
    }
}
