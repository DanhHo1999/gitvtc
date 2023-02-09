using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table_Form
{
    public partial class BillForm : Form
    {
        int nextPosition = 10;
        int column1, column2;
        int rowDistance = 5;
        int headersFontSize = 9;
        public BillForm()
        {

            this.Size = new Size(266, 475);
            InitializeComponent();
            Show();
            
            FormBorderStyle = FormBorderStyle.FixedSingle;
            column1 = 10;
            column2 = Width / 2-10;

            //Header
            Label header = new Label();
            panel1.Controls.Add(header);
            header.MaximumSize = new Size(Width - 30, 300);
            header.AutoSize = true;
            header.Location = new Point(10, nextPosition);
            header.TextAlign = ContentAlignment.TopCenter;
            header.Text = "DANH DIMSUM";
            header.Font = new Font("Arial", 18, FontStyle.Bold);
            nextPosition += (header.Height + rowDistance / 2);
            

            //headerAddress
            Label headerAddress =new Label();
            panel1.Controls.Add(headerAddress);
            headerAddress.MaximumSize = new Size(Width-50, 300);
            headerAddress.AutoSize= true;
            headerAddress.Location = new Point(10, nextPosition);
            headerAddress.TextAlign = ContentAlignment.TopCenter;
            headerAddress.Text = "184 Đ. Lê Đại Hành, Phường 15, Quận 11, TPHCM";
            headerAddress.Font = new Font("Arial", 15,FontStyle.Bold);
            nextPosition += headerAddress.Size.Height;

            //SDT
            Label headerPhone = new Label();
            panel1.Controls.Add(headerPhone);
            headerPhone.MaximumSize = new Size(Width - 50, 300);
            headerPhone.AutoSize = true;
            headerPhone.TextAlign = ContentAlignment.TopCenter;
            headerPhone.Font = new Font("Arial", 14,FontStyle.Bold);
            headerPhone.Text = "SĐT:\n0798.477.372";
            headerPhone.Location = new Point(Width/2-headerPhone.Width/2-25, nextPosition);
            nextPosition += headerAddress.Size.Height;

            //Hóa đơn thức ăn
            Label mainLabel = new Label();
            panel1.Controls.Add(mainLabel);
            mainLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            mainLabel.Width += 100;
            mainLabel.Text = "HÓA ĐƠN THỰC PHẨM";
            mainLabel.Location = new Point(13,nextPosition-15);
            nextPosition += mainLabel.Size.Height;

            //Số HĐ
            Label orderNumber = new Label();
            panel1.Controls.Add(orderNumber);
            orderNumber.Location = new Point(10, nextPosition);
            orderNumber.Font = new Font("Arial", 12, FontStyle.Bold);
            orderNumber.Text = "Số HĐ: "+Form1.orderNumber;
            orderNumber.AutoSize = true;
            nextPosition += orderNumber.Size.Height+5;

            //Ngày
            Label orderDate = new Label();
            panel1.Controls.Add(orderDate);
            orderDate.Location = new Point(10, nextPosition);
            orderDate.Font = new Font("Arial", 12, FontStyle.Bold);
            orderDate.Width = 300;
            orderDate.Text = "Ngày: "+DateTime.Today.ToString("dd' / 'MM' / 'yyyy");
            nextPosition += orderDate.Size.Height;

            //Thời gian
            Label orderTime = new Label();
            panel1.Controls.Add(orderTime);
            orderTime.Location = new Point(10, nextPosition);
            orderTime.Font = new Font("Arial", 12, FontStyle.Bold);
            orderTime.Width = 300;
            orderTime.Text = "Thời gian: \n"+DateTime.Now.ToString("HH' giờ 'mm ' phút'");
            orderTime.Height = orderTime.Height * 2;
            nextPosition += orderDate.Size.Height+20;

            

            //Line---------
            Label line1=new Label();
            panel1.Controls.Add(line1);
            line1.Location = new Point(10, nextPosition);
            line1.Width = Width-40;
            line1.Text = "________________________________";
            nextPosition += line1.Size.Height;

            //Tên Hàng SL Đơn Giá Thành Tiền
            Label itemNameHeader = new Label();
            panel1.Controls.Add(itemNameHeader);
            itemNameHeader.Location = new Point(column1, nextPosition);
            itemNameHeader.Font = new Font("Arial", headersFontSize, FontStyle.Bold);
            itemNameHeader.Text = "Tên Hàng";
            

            Label itemPriceHeader = new Label();
            panel1.Controls.Add(itemPriceHeader);
            itemPriceHeader.Location = new Point(column2, nextPosition);
            itemPriceHeader.Font = new Font("Arial", headersFontSize, FontStyle.Bold);
            itemPriceHeader.Text = "Đơn Giá";
            nextPosition += itemNameHeader.Size.Height;

            Label itemQuantityHeader = new Label();
            panel1.Controls.Add(itemQuantityHeader);
            itemQuantityHeader.Location = new Point(column1, nextPosition);
            itemQuantityHeader.Font = new Font("Arial", headersFontSize, FontStyle.Bold);
            itemQuantityHeader.Text = "S.Lg";


            Label itemTotalHeader = new Label();
            panel1.Controls.Add(itemTotalHeader);
            itemTotalHeader.Location = new Point(column2, nextPosition);
            itemTotalHeader.Font = new Font("Arial", headersFontSize, FontStyle.Bold);
            itemTotalHeader.Text = "Thành tiền";
            nextPosition += itemTotalHeader.Size.Height;

            //------------------------------------Danh sách confirmed orders--------------------------------
            foreach (OrderItem item in OrderList.list)
            {
                if (item.isConfirmed)
                {
                    Label itemName = new Label();
                    panel1.Controls.Add(itemName);
                    itemName.Location = new Point(column1, nextPosition);
                    itemName.Text = (OrderList.list.IndexOf(item) + 1) + ". " + item.menuItem.name;
                    itemName.AutoSize = true;

                    Label itemPrice = new Label();
                    panel1.Controls.Add(itemPrice);
                    itemPrice.Location = new Point(column2 - 5, nextPosition);
                    itemPrice.Text = item.menuItem.Price();
                    nextPosition += itemPrice.Height;

                    Label itemQuantity = new Label();
                    panel1.Controls.Add(itemQuantity);
                    itemQuantity.Location = new Point(column1 + 40, nextPosition);
                    itemQuantity.Text = item.quantity.ToString() + " cái";
                    itemQuantity.AutoSize = true;

                    Label itemTotal = new Label();
                    panel1.Controls.Add(itemTotal);
                    itemTotal.Location = new Point(column2, nextPosition);
                    itemTotal.Text = item.menuItem.Price(item.quantity);
                    itemTotal.Font= new Font("Arial", headersFontSize, FontStyle.Bold);
                    nextPosition += itemTotal.Height;
                }
            }
            //---------------------------------------------------------------------------------------------------
            //Line---------
            Label line2 = new Label();
            panel1.Controls.Add(line2);
            line2.Location = new Point(10, nextPosition);
            line2.Width = Width - 40;
            line2.Text = "________________________________";
            nextPosition += line2.Size.Height;

            //Total Price
            Label totalOrderPrice = new Label();
            panel1.Controls.Add(totalOrderPrice);
            totalOrderPrice.AutoSize = true;
            totalOrderPrice.TextAlign = ContentAlignment.TopRight;
            totalOrderPrice.Font=new Font("Arial",9,FontStyle.Bold);
            totalOrderPrice.Text = "Tổng: "+OrderPanelControl.ToVND(OrderList.TotalConfirmedPrice());
            totalOrderPrice.Location = new Point(Width-totalOrderPrice.Width-60, nextPosition);
            nextPosition += totalOrderPrice.Size.Height;

            
            //Total Price
            Label payedPrice = new Label();
            panel1.Controls.Add(payedPrice);
            payedPrice.AutoSize = true;
            payedPrice.MaximumSize = new Size(Width, Height);
            payedPrice.TextAlign = ContentAlignment.TopRight;
            payedPrice.Font = new Font("Arial", 9, FontStyle.Bold);
            payedPrice.Text = "Đã thanh toán: " + OrderPanelControl.ToVND(OrderList.TotalConfirmedPrice());
            payedPrice.Location = new Point(10, nextPosition+5);
            nextPosition += payedPrice.Size.Height+(payedPrice.AutoSize ? 15 : 0);

            //Cảm ơn quý khách
            Label thankLabel = new Label();
            panel1.Controls.Add(thankLabel);
            thankLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            thankLabel.Text = "Cảm ơn quý khách !!!";
            thankLabel.AutoSize = true;
            thankLabel.Location = new Point(Width/2-100, nextPosition);
            nextPosition += payedPrice.Size.Height + (payedPrice.AutoSize ? 10 : 0);

            //Hẹn Gặp lại
            Label thankLabel2 = new Label();
            panel1.Controls.Add(thankLabel2);
            thankLabel2.Font = new Font("Arial", 10, FontStyle.Bold);
            thankLabel2.Text = "Hẹn gặp lại !!!";
            thankLabel2.AutoSize = true;
            thankLabel2.Location = new Point(Width / 2 - 100, nextPosition);
            nextPosition += payedPrice.Size.Height + (payedPrice.AutoSize ? 10 : 0);


            panel1.Height = nextPosition + 15;
            flowLayoutPanel1.Height = panel1.Height;
            
            if (nextPosition < 600) Height = nextPosition + 80;
            else {
                flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                flowLayoutPanel1.WrapContents = false;
                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                flowLayoutPanel1.Width += 30;
            }
            Top = 10;Left = 1600;
        }
    }
}
