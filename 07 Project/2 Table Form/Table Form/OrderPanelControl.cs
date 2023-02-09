using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Table_Form
{
    public class OrderItem {
        public MenuItem menuItem;
        public int quantity;
        public bool isConfirmed = false;
        public OrderItem(MenuItem _menuItem, int _quantity) { 
            menuItem= _menuItem;
            quantity= _quantity;
        }
    }
    public static class OrderList{ 
        public static List<OrderItem> list = new List<OrderItem>();
        public static void Add(OrderItem _orderItem) {
            list.Add(_orderItem);
        }
        public static int TotalNotConfirmedPrice() {
            int total = 0;
            foreach (OrderItem _orderItem in list) {
                total += _orderItem.menuItem.price * _orderItem.quantity; 
            }
            return total;
        }
        public static int TotalConfirmedPrice() {
            int total = 0;
            foreach (OrderItem _orderItem in list) {
                if(_orderItem.isConfirmed)
                total += _orderItem.menuItem.price * _orderItem.quantity; 
            }
            return total;
        }

    }








    public class OrderLabel { 
        public DesignedLabel orderNameLabel;
        public DesignedLabel quantityLabel;
        public DesignedLabel itemsPriceLabel;
        public DesignedLabel cancelLabel;
        public int position;
        public OrderLabel()
        {
            cancelLabel= new DesignedLabel();
            cancelLabel.AutoSize = true;
            cancelLabel.Text = "[x]";
            cancelLabel.Hide();
            orderNameLabel = new DesignedLabel();
            orderNameLabel.Width = OrderPanelControl.firstLabelWidth;
            quantityLabel = new DesignedLabel();
            quantityLabel.Width = OrderPanelControl.secondLabelWidth;
            itemsPriceLabel = new DesignedLabel();
            itemsPriceLabel.Width = OrderPanelControl.thirdLabelWidth;
            OrderPanelControl.parent.Controls.Add(orderNameLabel);
            OrderPanelControl.parent.Controls.Add(quantityLabel);
            OrderPanelControl.parent.Controls.Add(itemsPriceLabel);
            OrderPanelControl.parent.Controls.Add(cancelLabel);
            SetVisible(false);
            

        }
        public OrderLabel SetCancelVoid(int _index) {
            cancelLabel.Click += new EventHandler((s, e) => {
                Console.WriteLine("index "+_index +" focused index: "+ OrderPanelControl.focusedIndex);
                OrderPanelControl.RemoveOrder(_index + OrderPanelControl.focusedIndex);
            });
            return this;
        }
        public OrderLabel SetLocation(Point _location) {
            orderNameLabel.Location = _location;
            cancelLabel.Location=new Point(5, _location.Y);
            quantityLabel.Location = new Point(_location.X + orderNameLabel.Width + OrderPanelControl.secondColumnDistance, _location.Y);
            itemsPriceLabel.Location = new Point(quantityLabel.Width + quantityLabel.Location.X + OrderPanelControl.thirdColumnDistance, _location.Y);
            return this;
        }
        public OrderLabel SetContext(OrderItem _orderItem) {
            if (_orderItem != null)
            {
                orderNameLabel.Text = _orderItem.menuItem.name;
                quantityLabel.Text = _orderItem.quantity.ToString();
                itemsPriceLabel.Text = OrderPanelControl.ToVND(_orderItem.quantity * _orderItem.menuItem.price);
                ValidateStyle(_orderItem);
            }
            else {
                orderNameLabel.Text = "";
                quantityLabel.Text = "";
                itemsPriceLabel.Text = "";
            }
            return this;
        }
        private void ValidateStyle(OrderItem _orderItem) {
            if (_orderItem.isConfirmed)
            {
                orderNameLabel.ForeColor = Form1.labelColor;
                quantityLabel.ForeColor = Form1.labelColor;
                itemsPriceLabel.ForeColor = Form1.labelColor;
            }
            else 
            {
                orderNameLabel.ForeColor = Form1.notConfirmedColor;
                quantityLabel.ForeColor = Form1.notConfirmedColor;
                itemsPriceLabel.ForeColor = Form1.notConfirmedColor;
            }
        }
        public OrderLabel SetVisible(bool visible) {
            if (visible)
            {
                orderNameLabel.Show();
                quantityLabel.Show();
                itemsPriceLabel.Show();
            }
            else {
                orderNameLabel.Hide();
                quantityLabel.Hide();
                itemsPriceLabel.Hide();
            }
                return this;
        }
    }

    public class OrderPanelControl
    {
        public static int firstLabelWidth = 150;
        public static int secondLabelWidth = 60;
        public static int thirdLabelWidth = 200;
        public static int secondColumnDistance = 5;
        public static int thirdColumnDistance = 5;
        

        public static int rowsDistance = 45;
        public static int firstRowsDistance = 120;

        public static int totalPrice = 0;
        public static int focusedIndex = 0;
        public static Form1 form;
        public static System.Windows.Forms.Panel parent;
        public OrderLabel header = new OrderLabel();
        public DesignedLabel notConfirmedTotalPriceLabel = new DesignedLabel();
        public DesignedLabel confirmedTotalPriceLabel = new DesignedLabel();
        public List<OrderLabel> orderLabels = new List<OrderLabel>();
        private void InitLabels()
        {
            orderLabels.Add(new OrderLabel().SetLocation(new Point(50, firstRowsDistance)).SetVisible(true).SetCancelVoid(orderLabels.Count));
            for (int i = 1; i < 6; i++)
            {
                orderLabels.Add((new OrderLabel())
                    .SetLocation(Point.Add(orderLabels[i - 1].orderNameLabel.Location, new Size(0, rowsDistance)))
                    .SetVisible(true)
                    .SetCancelVoid(orderLabels.Count)
                    );
            }
        }
        public OrderPanelControl(System.Windows.Forms.Panel _parent,Form1 _form) {
            form= _form;
            parent = _parent;
            parent.Controls.Add(header.orderNameLabel);
            parent.Controls.Add(header.quantityLabel);
            parent.Controls.Add(header.itemsPriceLabel);


            //Header
            header.quantityLabel.Text = "S.Lg";
            header.itemsPriceLabel.Text = "Tổng";
            header.SetLocation(new Point(50, 20));
            header.quantityLabel.Width += 100;
            header.orderNameLabel.Width -= 90;
            header.quantityLabel.Location = new Point(header.quantityLabel.Location.X - 90, header.quantityLabel.Location.Y);
            header.SetVisible(true);
            header.itemsPriceLabel.Width -= 30;

            parent.Controls.Add(notConfirmedTotalPriceLabel);
            notConfirmedTotalPriceLabel.Location = new Point(
                header.itemsPriceLabel.Location.X,
                header.itemsPriceLabel.Location.Y + 55);
            notConfirmedTotalPriceLabel.Width = 250;
            notConfirmedTotalPriceLabel.ForeColor = Form1.notConfirmedColor;
            notConfirmedTotalPriceLabel.Text = "0 VNĐ";
            notConfirmedTotalPriceLabel.Hide();
            
            parent.Controls.Add(confirmedTotalPriceLabel);
            confirmedTotalPriceLabel.Location = new Point(
                header.itemsPriceLabel.Location.X,
                header.itemsPriceLabel.Location.Y + 30);
            confirmedTotalPriceLabel.Width = 250;
            confirmedTotalPriceLabel.Text = "0 VNĐ";
            

            InitLabels();

        }


        public void PrintLabels(int _focusedIndex)
        {
            int count = OrderList.list.Count;
            if (count == 0) {
                notConfirmedTotalPriceLabel.Hide();
                confirmedTotalPriceLabel.Text = ToVND(0);
                return;
            }

            if (_focusedIndex > (count - 6)) _focusedIndex = 0;
            if (_focusedIndex == 0)
            {
                int lastIndex;
                if (count > 6) lastIndex = 6; else lastIndex = count;
                for (int i = 0; i < lastIndex; i++)
                {
                    orderLabels[i].SetContext(OrderList.list[i]);
                    if(OrderList.list[i].isConfirmed)
                        orderLabels[i].cancelLabel.Hide();
                    else
                        orderLabels[i].cancelLabel.Show();
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    orderLabels[i].SetContext(OrderList.list[i + _focusedIndex]);
                    if (OrderList.list[i + _focusedIndex].isConfirmed)
                        orderLabels[i].cancelLabel.Hide();
                    else
                        orderLabels[i].cancelLabel.Show();
                }
            }
            notConfirmedTotalPriceLabel.Text = ToVND(OrderList.TotalNotConfirmedPrice());
            confirmedTotalPriceLabel.Text = ToVND(OrderList.TotalConfirmedPrice());
            if (IsAllConfirmed())
            {
                notConfirmedTotalPriceLabel.Hide();
                form.orderingPanelConfirmButton.Hide();
            }
            else
            {
                notConfirmedTotalPriceLabel.Show();
                form.orderingPanelConfirmButton.Show();
            }
        }
        private bool IsAllConfirmed() {
            
            foreach (OrderItem item in OrderList.list) {
                if (!item.isConfirmed)
                {
                    return false;
                }
                   
            }
            return true;
        }
        public OrderPanelControl ScrollDown()
        {
            if (OrderList.list.Count <= 6) return this;
            if (focusedIndex < (OrderList.list.Count - 6)) focusedIndex++; else return this;
            PrintLabels(focusedIndex);
            return this;
        }
        public OrderPanelControl ScrollUp()
        {
            if (OrderList.list.Count <= 6) return this;
            if (focusedIndex > 0) focusedIndex--; else return this;

            PrintLabels(focusedIndex);
            return this;
        }

        public static String ToVND(int price) {
            return String.Format("{0:N0} VNĐ", price);
        }
        public void ClearLabels() {
            foreach (OrderLabel orderLabel in orderLabels) {
                orderLabel.quantityLabel.Text = "";
                orderLabel.orderNameLabel.Text = "";
                orderLabel.itemsPriceLabel.Text = "";
                orderLabel.cancelLabel.Hide();
            }
            notConfirmedTotalPriceLabel.Text = ToVND(OrderList.TotalNotConfirmedPrice());
        }
        public static void RemoveOrder(int index) {
            if (index >= OrderList.list.Count) return;
            OrderList.list.Remove(OrderList.list[index]);
            if (focusedIndex > (OrderList.list.Count - 6)) if(focusedIndex!=0) focusedIndex--;
            Form1._orderPanelControl.ClearLabels();
            Form1._orderPanelControl.PrintLabels(focusedIndex);
        }
        public void DisableAllButtons() { 
            form.menuButton.Enabled = false;
            form.orderingPanelConfirmButton.Enabled = false;
            form.upArrow.Enabled = false;
            form.downArrow.Enabled = false;
            form.ringButton.Enabled = false;
            form.payButton.Enabled = false;
        }
        public void EnableAllButtons()
        {
            form.menuButton.Enabled = true;
            form.orderingPanelConfirmButton.Enabled = true;
            form.upArrow.Enabled = true;
            form.downArrow.Enabled = true;
            form.ringButton.Enabled = true;
            form.payButton.Enabled = true;
        }
        public void ConfirmAllMenuItems() {
            foreach (OrderItem item in OrderList.list) {
                if (!item.isConfirmed)
                {
                    NetworkControl.AddOrder(item.menuItem.name, item.quantity);
                    item.isConfirmed = true;
                    Thread.Sleep(100);

                }
            }
            PrintLabels(focusedIndex);
        }

    }
}
