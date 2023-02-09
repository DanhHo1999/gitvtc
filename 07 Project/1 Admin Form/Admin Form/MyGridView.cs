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
    public class MyGridView:DataGridView
    {
        //User Manual
        private Color defaultColor2=Color.Blue, defaultColor1=Color.Brown;


        private static List<DateAndColor> dateColorList = new List<DateAndColor>();
        private class DateAndColor {
            public DateTime date;
            public Color color;
            public DateAndColor(DateTime _date, Color _color) {
                date = _date;
                color = _color;
            }
        }

        AdminForm form;
        Panel panel;
        DataGridView ordersGrid;
        int total;
        int filteredQuantity;
        public MyGridView(AdminForm _form,Panel _panel, DataGridView _ordersGrid) { 
            form= _form;
            panel= _panel;
            ordersGrid= _ordersGrid;
            panel.Controls.Add(this);
            ColumnHeadersHeightSizeMode = ordersGrid.ColumnHeadersHeightSizeMode;
            AutoSizeColumnsMode = ordersGrid.AutoSizeColumnsMode;
            Location =ordersGrid.Location;
            RowTemplate = ordersGrid.RowTemplate;
            Size=ordersGrid.Size;
            Font=ordersGrid.Font;
            
            Hide();
        }
        private DateTime ToDate(string str) {
            int as1=0, as2=0;
            for (int i = 0; i < str.Length; i++) {
                if (str[i] == '/') if (as1 > 0) as2 = i; else as1 = i;
            }
            int day=Convert.ToInt32(str.Substring(0, as1));
            int month = Convert.ToInt32(str.Substring(as1+1,as2-as1-1));
            int year = Convert.ToInt32(str.Substring(as2 + 1));
            return new DateTime(year,month,day);
        }
        private string GetDateStringFromGrid(string str)
        {
            str = str.Substring("Ngày ".Length);
            int i;
            for (i = 0; i < str.Length; i++) {
                if (str[i] == ':') {
                    str = str.Substring(0, i);
                }
            }
            return str;
        }
        private void RefreshDateColorList() {
            dateColorList.Clear();
            int i = 0;

            
            Color color;
            foreach (DataRow row in DatabaseController.GetDistinctOrdersDates().Tables[0].Rows) {
                if (i == 0) {
                    color = defaultColor1;
                    i = 1;
                } else {
                    color = defaultColor2;
                    i = 0;
                }
                dateColorList.Add(new DateAndColor(ToDate(row[0].ToString()), color));
                
            }
        }
        private Color GetColor(string _dateFromGrid) {
            foreach (DateAndColor dateColor in dateColorList) {
                if (DateTime.Compare(dateColor.date, ToDate(GetDateStringFromGrid(_dateFromGrid))) == 0)
                    return dateColor.color;
            }
            return Color.Wheat;
        }
        public void Set() {

            DataSource = ordersGrid.DataSource;
            RefreshDateColorList();
            ChangeHeaderTexts();
            Show();
            ordersGrid.Hide();
            CountOrders();
            CalculatePrices();
        }
        private void CountOrders() {
            int count = 0;
            int lastID=0;
            foreach (DataRow row in ((DataTable)DataSource).Rows) {
                if (lastID != Convert.ToInt32(row["ID"]))
                {
                    lastID = Convert.ToInt32(row["ID"]);
                    count++;
                }
            }
            form.ordersCountLabel.Text="Số lượng HĐ: "+count.ToString();
        }
        private int VndToInt(string _vnd) {
            _vnd = _vnd.Substring(0, _vnd.Length - 4);
            string str2="";
            
            foreach (char c in _vnd) {
                if (c != ',') str2 += c;
            }
            return Convert.ToInt32(str2);
        }
        private void CalculatePrices()
        {
            total = 0; int lastIndex = 0;
            foreach (DataRow row in ((DataTable)DataSource).Rows)
                if (lastIndex != Convert.ToInt32(row["ID"].ToString()))
                {
                    total += VndToInt(row["TOTAL"].ToString());
                    lastIndex = Convert.ToInt32(row["ID"].ToString());
                }

            form.totalBillLabel.Text = "Tổng: " + form.ToVND(total.ToString());
        }
        public void ChangeHeaderTexts()
        {
            Columns[0].HeaderText = "Số hóa đơn";
            Columns[1].HeaderText = "Tên món ăn";
            Columns[2].HeaderText = "Số lượng";
            Columns[3].HeaderText = "Thời gian";
            Columns[4].HeaderText = "Tổng hóa đơn";
            Columns[0].Width = 60;
            Columns[2].Width = 60; 
            Columns[3].Width = 300;
        }
        
        public void Filter() {
            if(DataSource==null) return;
            try {
                ((DataTable)DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "MENU_ITEM", form.itemNameTextBox.Text);
            } catch (Exception) {
            }
            if (form.itemNameTextBox.Text.Length == 0) {
                form.totalBillLabel.Show();
                form.ordersCountLabel.Show();
            }
            else {
                form.totalBillLabel.Hide();
                form.ordersCountLabel.Hide();
            }
        }
        public void CaculateFilteredItems() {
            filteredQuantity = 0;
            foreach (DataGridViewRow row in Rows) {
                if(row.Cells[1].Value != null)
                filteredQuantity += Convert.ToInt32(row.Cells[2].Value);
             }
            if (filteredQuantity > 0)
            {
                form.filteredQuantityTextbox.Text = "Số lượng món: " + filteredQuantity;
                form.filteredQuantityTextbox.Show();
                
            }
            else {
                form.filteredQuantityTextbox.Hide();
                
            }
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs args)
        {
            base.OnCellPainting(args);
            args.AdvancedBorderStyle.Bottom =
              DataGridViewAdvancedCellBorderStyle.None;
            // Normal:

            

            if (args.RowIndex < 1 || args.ColumnIndex != 0 && args.ColumnIndex != 3 && args.ColumnIndex != 4)
            {
                args.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
                return;
            }
            if (args.RowIndex >=0 && args.ColumnIndex == 3)
            {
                //Column Time: Color Here
                if (args.Value!=null)
                try { args.CellStyle.ForeColor = GetColor(args.Value.ToString()); } catch(Exception) { }
            }
            if (IsRepeatedCellValue(args.RowIndex, 0))
            {
                //repeat: no border
                args.AdvancedBorderStyle.Top =
                  DataGridViewAdvancedCellBorderStyle.None;
                args.CellStyle.ForeColor = Color.White;
                
            }
            else
            {
                //no repeat: ignore
                args.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
            }
        }
        
        private DataGridViewCell PreviousCell(int rowIndex, int colIndex) { 
            return Rows[rowIndex - 1].Cells[colIndex];
        }
        private bool IsRepeatedCellValue(int rowIndex, int colIndex)
        {
            DataGridViewCell currCell =
               Rows[rowIndex].Cells[colIndex];
            DataGridViewCell prevCell =
               Rows[rowIndex - 1].Cells[colIndex];
            
            if ((currCell.Value == prevCell.Value) ||
               (currCell.Value != null && prevCell.Value != null &&
               currCell.Value.ToString() == prevCell.Value.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
