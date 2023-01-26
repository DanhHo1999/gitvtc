using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Admin_Form
{
    public partial class AdminForm : Form
    {
        Timer myTimer;

        public static FlowLayoutPanel tablesFlowLayoutPanel;
        private static Thread serverThread;
        private static Socket server;
        public static string SqlDateTimeFormatString = "yyyy-MM-dd HH:mm:ss";
        public static string SqlDateFormatString = "yyyy-MM-dd";
        public static string vnDateTimeFormatString = "HH:mm:ss dd/MM/yyyy";
        public static string vnDateFormatString = "dd/MM/yyyy";
        public static string vnFullDateFormatString = "'Ngày 'd' tháng 'M' năm 'yyyy";
        private static bool _isOnline = false;

        public static AdminForm form;
        private static bool menuNotOpened = true;
        private static String menuItemAction = "none";
        private static Image myImage = null;
        public static string picturesFolderPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Pictures");
        public Boolean isOnline {
            get { return _isOnline; }
            set { _isOnline = value;
                if (_isOnline == true) {
                    serverStatusLabel.Text = "Server Online";
                    serverStatusLabel.ForeColor = Color.Green;
                    tablesControlsButton.Enabled = true;
                }
                else {
                    serverStatusLabel.Text = "Server Offline";
                    serverStatusLabel.ForeColor = Color.Red;
                    tablesControlsButton.Enabled = false;
                }

            }
        }
        public static string ToImageFilePath(String _menuItemName)
        {
            return picturesFolderPath + @"\" + _menuItemName + @".png";
        }
        public static bool IsNotUnicode(string str){

            for (int i = 0; i < str.Length; i++) {
                int charCode = Char.ConvertToUtf32(str, i);
                if (!(48 <= charCode && charCode <= 57 || 65 <= charCode && charCode <= 90 || 97 <= charCode && charCode <= 122)) return false;
            }
            return true;
        }
        public AdminForm()
        {
            InitializeComponent();
            Init();
            MenuList.RefreshNewMenuList();
            StartUpdateActions();
           
        }
        private void Init()
        {
            form = this;
            tablesFlowLayoutPanel = _tablesFlowLayoutPanel;

            idTextBox.MaxLength = 14;
            pwTextBox.PasswordChar = '*';
            pwTextBox.MaxLength = 14;

            _tablesFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            _tablesFlowLayoutPanel.WrapContents = false;
            _tablesFlowLayoutPanel.AutoScroll = true;

            datePicker1.Format = DateTimePickerFormat.Custom;
            datePicker1.CustomFormat = "'    từ ngày' dd 'tháng' MM 'năm' yyyy";

            datePicker2.Format = DateTimePickerFormat.Custom;
            datePicker2.CustomFormat = "'đến ngày' dd 'tháng' MM 'năm' yyyy";
            timePicker1.Format = DateTimePickerFormat.Custom;
            timePicker1.CustomFormat = "HH 'giờ' mm 'phút'";
            timePicker1.ShowUpDown = true;
            timePicker2.Format = DateTimePickerFormat.Custom;
            timePicker2.CustomFormat = "HH 'giờ' mm 'phút'";
            timePicker2.ShowUpDown = true;
            timePicker1.Value -= TimeSpan.FromHours(1);

            StartPosition = FormStartPosition.Manual; Left = 10; Top = 10;
            Size = new Size(911, 723);
            AutoSize = false;
            ordersPanel.Location = new Point(10, 10);
            tablesFlowLayoutPanel.Location = new Point(10, 10);
            Icon = new Icon(picturesFolderPath + @"\icon.ico");

            OrderPanelController.Init(ordersPanel, this, orderGridView);
            ManagingAccountController.Init(this,
                managingAccountPanel,
                changeInfoPanel,
                changePWpanel,
                addAccountPanel,
                accountsInfoPanel,
                changeAdminPanel);

            changeInfoDateOfBirthDatePicker.Format = DateTimePickerFormat.Custom;
            changeInfoDateOfBirthDatePicker.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";

            accountsInfoAccountNameComboBox.ValueMember = "NAME";
            accountsInfoAccountNameComboBox.DisplayMember = "NAME";

            DataTable dt = new DataTable();
            dt.Columns.Add("TYPE",typeof(int));
            dt.Columns.Add("ROLE",typeof(string));
            dt.Rows.Add(2, "Quản lý");
            dt.Rows.Add(3, "Nhân viên");
            dt.AcceptChanges();
            accountsInfoRoleComboBox.DataSource = dt;
            accountsInfoRoleComboBox.DisplayMember = "ROLE";
            accountsInfoRoleComboBox.ValueMember = "TYPE";

            ManagingAccountController.SetButtonLocations(
                changeInfoButton,
                changePwButton,
                addAccountButton,
                accountsInfoButton,
                changeAdminButton,
                managingAccountBackButton
                );

            changeAdminAccountNameComboBox.ValueMember = "NAME";
            changeAdminAccountNameComboBox.DisplayMember = "NAME";
        }
        private void RefreshPIN() {
            pinLabel.Text="Mã PIN: "+DatabaseController.GetTablePinCode();
        }
        private void InitServer()
        {

            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (true) {
                try { server.Bind(iep); break; }
                catch (SocketException)
                {
                    MessageBox.Show("That bai");
                    Thread.Sleep(5000);
                }
            }
            server.Listen(99);
            Socket client;
            serverThread = new Thread(() =>
             {
                 while (true)
                 {
                     try
                     {
                         client = server.Accept();
                         String str = GetStringData(client);
                         if (str.Equals("table"))
                         {
                             Tables.Add(client, Tables.GetNumber());
                         }
                         if (str.Equals("employee"))
                         {
                             EmployeeConnector.connectors.Add(new EmployeeConnector(client));
                         }
                     }
                     catch (Exception) { }
                 }
             });
            serverThread.Start();
            isOnline = true;
        }

        private String GetStringData(Socket _client)
        {
            byte[] bytes = new byte[1024];
            int bytesNumber = _client.Receive(bytes);
            if (bytesNumber == 0)
            {
                Console.WriteLine("0 byte received");
                _client.Close();
            }
            return Encoding.UTF8.GetString(bytes).Substring(0, bytesNumber);
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Account.type != 0) { e.Cancel = true; return; }
            if (!isOnline)
            {
                if (MessageBox.Show("Xác nhận đóng chương trình !!",
                                        "Đóng chương trình !!",
                                        MessageBoxButtons.OKCancel) != DialogResult.OK) {
                    e.Cancel = true;
                    return;
                }
                
                Tables.CloseAllTables();
                Tables.list.Clear();
                if (server != null) server.Dispose();
                if (serverThread != null) serverThread.Abort();
            }
            else { e.Cancel = true; }

        }

        private void startServerButton_Click(object sender, EventArgs e)
        {

            if (!isOnline)
            {
                if (MessageBox.Show("Khởi động server ?",
                                        "Khởi động",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                {
                    return;
                }
                
                InitServer();
                Log.Write("Khởi động Server");
                isOnline = true;
                startServerButton.Text = "Close Server";
                tablesFlowLayoutPanel.Show();
                tablesFlowLayoutPanel.BringToFront();
            }
            else {
                if (MessageBox.Show("Xác nhận ngừng hoạt động !!",
                                        "Ngừng hoạt động !!",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
                
                EmployeeConnector.Close();
                Tables.CloseAllTables();
                Tables.CloseAllControllers();
                Thread.Sleep(300);
                server.Dispose();
                serverThread.Abort();
                Log.Write("Ngừng hoạt động Server");
                isOnline = false;
                startServerButton.Text = "Start Server";
            }
            if (!menuNotOpened) ChangeImportPictureButtonLabel();
        }
        public void Authorization() {

            ManagingAccountController.Authorization();
            if (Account.type == 3)
            {
                openOrdersPanelButton.Enabled = false;
                menuManageButton.Enabled = false;
                startServerButton.Enabled = false;
                changePinCodeButton.Enabled = false;
            }
            else {
                openOrdersPanelButton.Enabled = true;
                changePinCodeButton.Enabled = true;
                menuManageButton.Enabled = true;
                startServerButton.Enabled = true;
            }
            if (Account.type < 3) openLogsButton.Enabled = true; else openLogsButton.Enabled = false;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!IsNotUnicode(idTextBox.Text) || !IsNotUnicode(pwTextBox.Text)) {
                Notify("Đăng nhập thất bại");
                return;
            }
            DatabaseController.Login(idTextBox.Text.ToLower(), pwTextBox.Text);
            if (Account.type > 0) {
                Login();
                Authorization();
                accountNameLabel.Text = "Tên: "+DatabaseController.GetAccountInfo(Account.name)["FULLNAME"].ToString();
                if (Account.type == 1) accountRoleLabel.Text = "Chức vụ: Quản lý";
                if (Account.type == 2) accountRoleLabel.Text = "Chức vụ: Quản lý";
                if (Account.type == 3) accountRoleLabel.Text = "Chức vụ: Nhân viên";
                exitButton.Enabled = false;
            }
            else
            {
                Notify("Đăng nhập thất bại");
            }
        }
        private void Login() {
            Notify("Đăng nhập thành công"); Log.Write("Đăng nhập");
            pinLabel.Show(); RefreshPIN();
            accountNameLabel.Show();
            accountRoleLabel.Show();
            idLabel.Hide();
            openLogsButton.Show();
            idTextBox.Hide();
            pwTextBox.Hide();
            pwLabel.Hide();
            loginButton.Hide();
            logoutButton.Show();
            startServerButton.Show();
            changePinCodeButton.Show();
            managingAccountButton.Show();
            menuManageButton.Show();
            tablesControlsButton.Show();
            openOrdersPanelButton.Show();
            serverStatusLabel.Show();
        }
        private void HideAll()
        {
            pinLabel.Hide();
            accountNameLabel.Hide();
            accountRoleLabel.Hide();
            openLogsButton.Hide();
            managingAccountButton.Hide();
            serverStatusLabel.Hide();
            openOrdersPanelButton.Hide();
            changePriceMenuItemButton.Hide();
            deleteMenuItemButton.Hide();
            menuItemComboBox.Hide();
            menuItemPictureBox.Hide();
            addMenuItemButton.Hide();
            changePinCodeButton.Hide();
            logoutButton.Hide();
            startServerButton.Hide();
            pinCodeTextBox.Hide();
            pinCodeConfirmButton.Hide();
            pinCodeCancelButton.Hide();
            importImageButton.Hide();
            menuManageButton.Hide();
            newNameLabel.Hide();
            newPriceLabel.Hide();
            newMenuItemNameTextBox.Hide();
            newMenuItemPriceTextBox.Hide();
            addMenuItemCancelButton.Hide();
            addMenuItemConfirmButton.Hide();
            changeNameMenuItemButton.Hide();
            menuNotOpened = true;
            tablesControlsButton.Hide();
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            Log.Write("Đăng xuất");
            idLabel.Show();
            idTextBox.Show();
            pwTextBox.Show();
            pwLabel.Show();
            loginButton.Show();
            Account.Clear();
            idTextBox.Text = "";
            pwTextBox.Text = "";
            if(!isOnline)exitButton.Enabled = true;
            HideAll();
        }

        private void changePinCodeButton_Click(object sender, EventArgs e)
        {
            pinCodeConfirmButton.Show();
            pinCodeTextBox.Show();
            pinCodeCancelButton.Show();
        }

        private void onlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) pinCodeConfirmButton_Click(sender, e);
            e.Handled = !(char.IsNumber(e.KeyChar)|| e.KeyChar.Equals(''));
        }

        private void pinCodeConfirmButton_Click(object sender, EventArgs e)
        {
            if (pinCodeTextBox.TextLength < 4) {
                Notify("Đổi PIN code thất bại");
                return;
            }
            DatabaseController.ChangeTablePinCode(pinCodeTextBox.Text);
            Log.Write("Đổi mã PIN thành "+ pinCodeTextBox.Text);
            pinCodeTextBox.Text = "";
            pinCodeTextBox.Hide();
            pinCodeCancelButton.Hide();
            pinCodeConfirmButton.Hide();
            Notify("Đổi PIN code thành công");
            RefreshPIN();
        }

        private void pinCodeCancelButton_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text = "";
            pinCodeTextBox.Hide();
            pinCodeCancelButton.Hide();
            pinCodeConfirmButton.Hide();

        }

        private void importImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.InitialDirectory = @"D:\Data\Desktop\Hình";
            openFileDialog.Filter = "Image|*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                AddImage(openFileDialog.FileName, menuItemComboBox.SelectedValue.ToString());

                if (importImageButton.Text.Equals("Thêm Hình"))
                {
                    Notify("Thêm hình thành công !!", 3000);
                    importImageButton.Text = "Sửa hình";
                    Tables.AddPicture(menuItemComboBox.SelectedValue.ToString());

                }
                else {
                    Notify("Sửa hình thành công !!");
                }

                SetPicture(menuItemComboBox.SelectedValue.ToString());
                RefreshComboBox();
            }
            else Console.WriteLine("No File");
            openFileDialog.Dispose();
        }
        private String HasPictureString(String _menuItemName) {
            try { (Image.FromFile(picturesFolderPath + @"\" + _menuItemName + @".png")).Dispose();
                return "";
            }
            catch (Exception) { }
            return " | Không có hình";
        }
        private bool HasPicture(String _menuItemName)
        {
            try {
                (Image.FromFile(picturesFolderPath + @"\" + _menuItemName + @".png")).Dispose();
                return true; }
            catch (Exception) { return false; }
        }
        private DataTable AddMenuItemLabel(DataSet dataSet) {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Label");
            foreach (DataRow row in dataSet.Tables[0].Rows) {
                DataRow dataRow = dt.NewRow();
                dataRow["Name"] = row["Name"];
                dataRow["Price"] = row["Price"];
                dataRow["Label"] = row["Name"] + " | " + ToVND(row["Price"].ToString()) + HasPictureString(row["Name"].ToString());
                dt.Rows.Add(dataRow);
            }
            dt.AcceptChanges();
            return dt;
        }
        public String ToVND(String _price) {
            try { return String.Format("{0:N0} VNĐ", Convert.ToInt32(_price)); } catch (Exception) { return _price; }
        }

        private void menuManageButton_Click(object sender, EventArgs e)
        {
            if (menuNotOpened)
            {
                menuNotOpened = false;
                menuItemComboBox.Show();
                changePriceMenuItemButton.Show();
                menuItemPictureBox.Image = null;
                menuItemPictureBox.Show();
                importImageButton.Show();
                addMenuItemButton.Show();
                changeNameMenuItemButton.Show();
                deleteMenuItemButton.Show();

                menuItemComboBox.DataSource = AddMenuItemLabel(DatabaseController.GetMenuItems());
                menuItemComboBox.DisplayMember = "Label";
                menuItemComboBox.ValueMember = "Name";
                ChangeImportPictureButtonLabel();
                SetPicture(menuItemComboBox.SelectedValue.ToString());
                menuItemComboBox.SelectedIndexChanged += new EventHandler((a, b) =>
                {

                    SetPicture(menuItemComboBox.SelectedValue.ToString());
                    addMenuItemCancelButton.Hide();
                    changePriceMenuItemButton.Show();
                    newMenuItemNameTextBox.Hide();
                    newMenuItemPriceTextBox.Hide();
                    addMenuItemConfirmButton.Hide();
                    changeNameMenuItemButton.Show();
                    addMenuItemButton.Show();
                    deleteMenuItemButton.Show();
                    newNameLabel.Hide();
                    newPriceLabel.Hide();
                    ChangeImportPictureButtonLabel();
                });
            }
            else {
                menuNotOpened = true;
                changePriceMenuItemButton.Hide();
                deleteMenuItemButton.Hide();
                importImageButton.Hide();
                menuItemComboBox.Hide();
                menuItemPictureBox.Hide();
                addMenuItemButton.Hide();
                addMenuItemCancelButton.Hide();
                addMenuItemConfirmButton.Hide();
                newMenuItemNameTextBox.Hide();
                newMenuItemPriceTextBox.Hide();
                newNameLabel.Hide();
                newPriceLabel.Hide();
                changeNameMenuItemButton.Hide();
            }

        }
        private void ChangeImportPictureButtonLabel() {
            if (HasPicture(menuItemComboBox.SelectedValue.ToString()))
            {
                importImageButton.Text = "Sửa Hình";
                if(isOnline)importImageButton.Enabled = false;else importImageButton.Enabled = true;
            }
            else
            {
                importImageButton.Text = "Thêm Hình";
                importImageButton.Enabled = true;
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "taikhoan1";
            pwTextBox.Text = "123";
        }

        private void addMenuItemCancelButton_Click(object sender, EventArgs e)
        {
            addMenuItemCancelButton.Hide();
            newMenuItemNameTextBox.Hide();
            newMenuItemPriceTextBox.Hide();
            addMenuItemConfirmButton.Hide();
            changeNameMenuItemButton.Show();
            addMenuItemButton.Show();
            newNameLabel.Hide();
            newPriceLabel.Hide();
            deleteMenuItemButton.Show();
            changePriceMenuItemButton.Show();
        }
        private void Notify(String _message, int _miliseconds) {
            Timer myTimer = new Timer();
            myTimer.Interval = _miliseconds;
            notifyLabel.Text = _message;
            notifyLabel.Show();
            myTimer.Tick += new EventHandler((a, b) => {
                notifyLabel.Hide();
                myTimer.Dispose();
            });
            myTimer.Start();
        }
        public void Notify(String _message)
        {
            if(myTimer!=null)myTimer.Dispose();
            myTimer = new Timer();
            myTimer.Interval = 1500;
            notifyLabel.Text = _message;
            notifyLabel.Show();
            myTimer.Tick += new EventHandler((a, b) => {
                notifyLabel.Hide();
                myTimer.Dispose();
            });
            myTimer.Start();
        }

        private void addMenuItemButton_Click(object sender, EventArgs e)
        {
            menuItemAction = "add";
            changePriceMenuItemButton.Hide();
            addMenuItemCancelButton.Show();
            addMenuItemConfirmButton.Show();
            newMenuItemNameTextBox.Show();
            newMenuItemPriceTextBox.Show();
            newNameLabel.Show(); newMenuItemNameTextBox.Text = "";
            newPriceLabel.Show(); newMenuItemPriceTextBox.Text = "";

            changeNameMenuItemButton.Hide();
            deleteMenuItemButton.Hide();

        }

        private void changeMenuItemButton_Click(object sender, EventArgs e)
        {
            menuItemAction = "changeName";
            changePriceMenuItemButton.Hide();
            addMenuItemCancelButton.Show();
            addMenuItemConfirmButton.Show();
            newNameLabel.Show();
            newMenuItemNameTextBox.Show();
            addMenuItemButton.Hide();
            deleteMenuItemButton.Hide();
            newMenuItemNameTextBox.Text = menuItemComboBox.SelectedValue.ToString();
        }

        private void ChangeMenuItemName() {
            if (newMenuItemNameTextBox.Text.Length == 0|| newMenuItemNameTextBox.Text.Contains("  ") || newMenuItemNameTextBox.Text.Contains("'")|| newMenuItemNameTextBox.Text.Equals(menuItemComboBox.SelectedValue.ToString()))
            {
                Notify("Đổi tên món thất bại!");
                return;
            }
            try {

                DatabaseController.ChangeMenuItemName(newMenuItemNameTextBox.Text, menuItemComboBox.SelectedValue.ToString());
                Log.Write(
                        "Đổi tên món từ " +
                        menuItemComboBox.SelectedValue.ToString()
                        + " thành " +
                        newMenuItemNameTextBox.Text
                        );
                Notify("Đổi tên món thành công!");
                ChangePictureName();
                RefreshComboBox();
                Tables.SendNewMenuList();
                MenuList.RefreshNewMenuList();
            }
            catch (Exception) {
                Notify("Đổi tên món thất bại");
            }
        }


        private void AddMenuItem() {
            if (newMenuItemNameTextBox.Text.Length == 0 || newMenuItemPriceTextBox.Text.Length == 0)
            {
                
                Notify("Thêm món thất bại!");
                return;
            }
            try
            {
                if (newMenuItemNameTextBox.Text.Contains("'")) throw new Exception();
                if (newMenuItemNameTextBox.Text.Contains("  ")) throw new Exception();
                if (newMenuItemPriceTextBox.Text.Substring(newMenuItemPriceTextBox.Text.Length - 3).Equals("000") &&
                      Convert.ToInt32(newMenuItemPriceTextBox.Text) > 1000)
                {
                    DatabaseController.AddMenuItem(newMenuItemNameTextBox.Text, Convert.ToInt32(newMenuItemPriceTextBox.Text));
                    Log.Write(
                        "Thêm món " +
                        newMenuItemNameTextBox.Text
                        + " với giá " +
                        form.ToVND(newMenuItemPriceTextBox.Text)
                        );
                    Notify("Thêm món thành công!");
                    RefreshComboBox();
                    menuItemComboBox.SelectedValue = newMenuItemNameTextBox.Text;
                    Tables.SendNewMenuList();
                    MenuList.RefreshNewMenuList();
                    return;
                }
            }
            catch (Exception) { }
            Notify("Thêm món thất bại!");
        }
        private void ChangeMenuItemPrice() {
            if (newMenuItemPriceTextBox.Text.Length == 0) { Notify("Sửa giá thất bại!"); return; }
            
            if (newMenuItemPriceTextBox.Text.Equals(MenuList.GetItem(menuItemComboBox.SelectedValue.ToString()).price.ToString())) { Notify("Sửa giá thất bại!"); return; }
            try {
                if (newMenuItemPriceTextBox.Text.Substring(newMenuItemPriceTextBox.Text.Length - 3).Equals("000") &&
                          Convert.ToInt32(newMenuItemPriceTextBox.Text) > 1000) {
                    DatabaseController.ChangeMenuItemPrice(newMenuItemPriceTextBox.Text, menuItemComboBox.SelectedValue.ToString());
                    
                    
                    Log.Write(
                        "Sửa giá món " +
                        menuItemComboBox.SelectedValue.ToString()
                        + " từ " +
                        MenuList.GetItem(menuItemComboBox.SelectedValue.ToString()).ToPrice()
                        + " thành " +
                        form.ToVND(newMenuItemPriceTextBox.Text)
                        );
                    Notify("Sửa giá thành công!");
                    RefreshComboBox();
                    Tables.SendNewMenuList();
                    MenuList.RefreshNewMenuList();
                    return;
                }
            }
            catch (Exception) { }
            Notify("Sửa giá thất bại!");
        }
        private void addMenuItemConfirmButton_Click(object sender, EventArgs e)
        {

            if (menuItemAction.Equals("changeName")) { ChangeMenuItemName();  return; }
            if (menuItemAction.Equals("add")) { AddMenuItem();  return; }
            if (menuItemAction.Equals("changePrice")) { ChangeMenuItemPrice();  return; }
        }
        private void SetPicture(String _menuItemName) {
            try {
                if (myImage != null) myImage.Dispose();
                myImage = Image.FromFile(picturesFolderPath + @"\" + _menuItemName + @".png");
                menuItemPictureBox.Image = myImage;
            }
            catch (Exception) { menuItemPictureBox.Image = null; }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AddImage(String _imagePath, String _menuItemName) {
            if (menuItemPictureBox.Image != null) { menuItemPictureBox.Image.Dispose(); }
            if (File.Exists(ToImageFilePath(_menuItemName))) File.Delete(ToImageFilePath(_menuItemName));
            Image image = Image.FromFile(_imagePath);
            image.Save(picturesFolderPath + @"\" + _menuItemName + @".png");
            image.Dispose();
        }
        private void ChangePictureName()
        {
            if (menuItemPictureBox.Image != null) { menuItemPictureBox.Image.Dispose(); }
            if (File.Exists(ToImageFilePath(newMenuItemNameTextBox.Text))) File.Delete(ToImageFilePath(newMenuItemNameTextBox.Text));
            try { File.Move(ToImageFilePath(menuItemComboBox.SelectedValue.ToString()), ToImageFilePath(newMenuItemNameTextBox.Text)); } catch (Exception) { Console.WriteLine("Failed"); }
        }
        private void RefreshComboBox() {
            int index = menuItemComboBox.SelectedIndex;
            menuItemComboBox.DataSource = AddMenuItemLabel(DatabaseController.GetMenuItems());
            menuItemComboBox.SelectedIndex = index;
        }
        private void RefreshComboBox(int i)
        {

            menuItemComboBox.DataSource = AddMenuItemLabel(DatabaseController.GetMenuItems());
            menuItemComboBox.SelectedIndex = i;
        }

        private void BlockKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void deleteMenuItemButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn chắc chắn xóa "+ menuItemComboBox.SelectedValue.ToString().ToUpper() + " ?",
                                        "Xóa món ăn !!",
                                        MessageBoxButtons.OKCancel) != DialogResult.OK)
            {

                return;
            }
            if (DatabaseController.GetMenuItemCount() < 5) { Notify("Xóa món ăn thất bại !! Không đủ món."); return; }
            if (menuItemPictureBox.Image != null) { menuItemPictureBox.Image.Dispose(); }
            DatabaseController.DeleteMenuItem(menuItemComboBox.SelectedValue.ToString());
            Notify("Xóa món ăn thành công !!"); MenuList.RefreshNewMenuList();
            RefreshComboBox(0);
            Tables.SendNewMenuList();
        }

        private void changePriceMenuItemButton_Click(object sender, EventArgs e)
        {
            menuItemAction = "changePrice";
            newMenuItemPriceTextBox.Text = "";
            addMenuItemButton.Hide();
            changeNameMenuItemButton.Hide();
            deleteMenuItemButton.Hide();
            newNameLabel.Hide();
            newMenuItemNameTextBox.Hide();
            newMenuItemPriceTextBox.Show();
            newPriceLabel.Show();
            addMenuItemCancelButton.Show();
            addMenuItemConfirmButton.Show();
        }
        private static void StartUpdateActions(){
            Timer timer =new Timer();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler((sender, e) => {
            lock (commands)
            {
                foreach (string cmd in commands)
                    {
                        Console.WriteLine(cmd);
                        String[] stringArray = cmd.Split('$');
                        switch (stringArray[0])
                        {
                            case "createTable":
                                (new TableBox()).SetTableName("Bàn số " + stringArray[1]);
                                break;
                            case "disposeTable":
                                Tables.GetController(stringArray[1]).Dispose();
                                break;

                        }

                        if (stringArray.Length > 1) switch (stringArray[1])//strings[0]:table name, strings[1] switch
                            {
                                case "getNextOrderID":
                                    DatabaseController.CreateOrder(DateTime.Now);
                                    Tables.GetTable(stringArray[0]).myOrderID= DatabaseController.GetNextOrderID();
                                    Tables.GetTable(stringArray[0]).SendOrderNumber();
                                    break;
                                case "callService":
                                    //EmployeeConnector.connectors
                                    EmployeeConnector.CallService(stringArray[0]);
                                    break;
                                case "finish":
                                    Tables.GetController(stringArray[0]).FinishOrders();
                                    break;
                                case "addOrder"://0:tableName,1:addOrder,2:menuItemName,3:quantity
                                    Tables.GetController(stringArray[0]).AddOrder(stringArray[2], Convert.ToInt32(stringArray[3]));
                                    EmployeeConnector.AddFoodOrder(Convert.ToInt32(stringArray[0].Substring("Bàn số ".Length)), stringArray[2], Convert.ToInt32(stringArray[3]));
                                    break;
                            }
                    }
                    commands.Clear();
                }

            });
            timer.Start();
        }
        
        private static List<String> commands = new List<string>();
        public static void AddAction(string _string) {
            lock (commands) {
                commands.Add(_string);
            }
            
        }

        private void tablesControlsButton_Click(object sender, EventArgs e)
        {
            tablesFlowLayoutPanel.Show();
            tablesFlowLayoutPanel.BringToFront();
        }

        private void closeTablesFlowPanelButton_Click(object sender, EventArgs e)
        {
            tablesFlowLayoutPanel.Hide();
        }

        private void dayOrdersButton_Click(object sender, EventArgs e)
        {
            OrderPanelController.ShowTodayOrders();
            ResetFilterOrdersHistoryPanel();
            TemporarilyHideOrdersPanelButtons();
        }

        private void allOrdersButton_Click(object sender, EventArgs e)
        {
            OrderPanelController.ShowAllOrders();
            ResetFilterOrdersHistoryPanel();
            TemporarilyHideOrdersPanelButtons();
        }
        private void closeOrdersPanelButton_Click(object sender, EventArgs e)
        {
            ordersPanel.Hide();
        }

        private void fromTimeToTimeOrderButton_Click(object sender, EventArgs e)
        {
            OrderPanelController.ShowCustomOrders(datePicker1.Value, timePicker1.Value,datePicker2.Value,timePicker2.Value);
            TemporarilyHideOrdersPanelButtons();
            ResetFilterOrdersHistoryPanel();
        }
        public void ResetFilterOrdersHistoryPanel() {
            itemIDTextBox.Text = "";
            itemNameTextBox.Text = "";
        }
        private void OpenOrdersPanelButton_Click(object sender, EventArgs e)
        {
            OrderPanelController.Clear();
            ResetFilterOrdersHistoryPanel();
            totalBillLabel.Text = "Tổng: 0 VNĐ";
            ordersCountLabel.Text = "Số lượng HĐ: 0";
            timePicker1.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            timePicker2.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            datePicker1.Value = DateTime.Now.AddDays(-1);
            datePicker2.Value = DateTime.Now;
            ordersPanel.Show();
            ordersPanel.BringToFront();
        }

        private void itemNameTextBox_TextChanged(object sender, EventArgs e)
        {
            OrderPanelController.Filter();
        }
        private void DisableOrdersButtons() { 
            dayOrdersButton.Enabled = false;
            fromTimeToTimeOrderButton.Enabled = false;
            allOrdersButton.Enabled = false;
            findIdOrderButton.Enabled = false;
        }
        private void ActivateOrdersButtons() { 
            dayOrdersButton.Enabled = true;
            fromTimeToTimeOrderButton.Enabled = true;
            allOrdersButton.Enabled = true;
            findIdOrderButton.Enabled=true;
        }
        private void TemporarilyHideOrdersPanelButtons() {
            DisableOrdersButtons();
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler((s, e) => {
                ActivateOrdersButtons();
                timer.Dispose();
            });
            timer.Start();
        }

        private void findIdOrderButton_Click(object sender, EventArgs e)
        {
            if (itemIDTextBox.Text.Length == 0) return;
            OrderPanelController.ShowOrderByID();
            TemporarilyHideOrdersPanelButtons();
            ResetFilterOrdersHistoryPanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { printDocument1.Print(); }catch(Exception) { MessageBox.Show((IWin32Window)sender, "Không thể in", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridView gridView = OrderPanelController.myGridView;
            int height=gridView.Height;
            gridView.Height = height * 4;
            Bitmap bm = new Bitmap(gridView.Width, gridView.Height + totalBillLabel.Height);
            totalBillLabel.DrawToBitmap(bm, new Rectangle(0, 0, totalBillLabel.Width, totalBillLabel.Height));
            ordersCountLabel.DrawToBitmap(bm, new Rectangle(totalBillLabel.Width+5, 0, ordersCountLabel.Width, ordersCountLabel.Height));
            gridView.DrawToBitmap(bm, new Rectangle(0, totalBillLabel.Height, gridView.Width, gridView.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            gridView.Height = height;
            
        }

        private void managingAccountBackButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.HidePanels();
            managingAccountPanel.Hide();
        }

        private void changeInfoButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ShowPanel(changeInfoPanel);
        }

        private void changePwConfirmButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ChangePassword();
        }

        private void changePwButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ShowPanel(changePWpanel);
        }

        private void changePwCancelButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.HidePanels();
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ShowPanel(addAccountPanel);
        }

        private void accountsInfoButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ShowPanel(accountsInfoPanel);
        }

        private void managingAccountButton_Click(object sender, EventArgs e)
        {
            managingAccountPanel.Show();
            managingAccountPanel.BringToFront();
            
        }

        private void testButton2_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "taikhoan2";
            pwTextBox.Text = "123";
        }

        private void testButton3_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "taikhoan3";
            pwTextBox.Text = "123"; 
        }

        private void changeInfoConfirmButton_Click(object sender, EventArgs e)
        {
            
            try {
                ManagingAccountController.ChangeInfo();
                Log.Write("Sửa thông tin cá nhân");
                ManagingAccountController.Notify("Đổi thông tin thành công");
                ManagingAccountController.HidePanels();
            } catch (Exception) { ManagingAccountController.Notify("Đổi thông tin thất bại"); }
        }

        private void changeInfoMaleRadioButton_Click(object sender, EventArgs e)
        {
            changeInfoMaleRadioButton.Checked = true;
            changeInfoFemaleRadioButton.Checked = false;
        }

        private void changeInfoFemaleRadioButton_Click(object sender, EventArgs e)
        {
            changeInfoMaleRadioButton.Checked = false;
            changeInfoFemaleRadioButton.Checked = true;
        }

        private void addAccountConfirmButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.AddAccount();
            
        }

        private void addAccountCancelButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.HidePanels();
        }

        private void accountsInfoAccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagingAccountController.ShowAccountInfo();
        }

        

        private void accountsInfoStatusToogleButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận !!","Xác nhận !!",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            ManagingAccountController.ChangeStatus();
            
            
        }

        private void accountsInfoRoleChangingButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.changingRole = true;
            accountsInfoRoleChangingButton.Hide();
            accountsInfoRoleComboBox.Show();
        }

        private void accountsInfoRoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagingAccountController.SetRole();
        }

        private void changeAdminButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ShowPanel(changeAdminPanel);
        }

        private void changeAdminConfirmButton_Click(object sender, EventArgs e)
        {
            changeAdminPasswordTextBox.Text = "";
            changeAdminPasswordPanel.Show();
        }

        private void changeAdminPasswordInputConfirmButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ChangeAdmin();
        }

        private void openLogsButton_Click(object sender, EventArgs e)
        {
            Log.OpenLogsFolder();
        }

        private void resetPwButton_Click(object sender, EventArgs e)
        {
            ManagingAccountController.ResetPassword();
        }

        private void pwTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) loginButton_Click(sender,e);
        }
    }
}
