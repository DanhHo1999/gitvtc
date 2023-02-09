using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Form
{
    public static class ManagingAccountController
    {
        static AdminForm form;
        static Panel panel;
        static Timer timer;
        static Panel frontPanel;
        static List<Panel> panels = new List<Panel>();
        public static bool changingRole = false;
        public static void Init(AdminForm _form, Panel _mainPanel, params Panel[] _panels) {
            form = _form;
            panel = _mainPanel;
            panel.Location = new Point(5, 5);
            panel.Size = new Size(_form.Width - 30, _form.Height - 50);
            form.Controls.Add(panel);
            panel.BringToFront();
            panel.BorderStyle = BorderStyle.FixedSingle;

            foreach (Panel smallPanel in _panels) {
                panels.Add(smallPanel);
                smallPanel.Location = new Point(380, 40);
                smallPanel.Height = panel.Height - 80;
                smallPanel.Width = panel.Width - 430;
                smallPanel.BorderStyle = BorderStyle.FixedSingle;
                panel.Controls.Add(smallPanel);
                smallPanel.Hide();
            }


        }
        public static void SetButtonLocations(params Button[] buttons) {
            int min = buttons[0].Location.Y;
            int max = buttons[buttons.Length - 1].Location.Y;
            int distance = (max - min) / (buttons.Length - 1);
            int nextY = min;
            foreach (Button button in buttons) {
                button.Location = new Point(button.Location.X, nextY);
                nextY += distance;
            }
        }
        public static void Notify(string _msg) {
            if (timer != null) timer.Dispose();
            form.managingAccountInfoLabel.Text = _msg;
            form.managingAccountInfoLabel.Show();
            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler((s, e) => {
                timer.Dispose();
                form.managingAccountInfoLabel.Hide();
            });
            timer.Start();
        }
        public static void Notify(string _msg,string e_message)
        {
            if(e_message.Length>0) if (e_message[0] == '$') _msg = e_message.Substring(1);
            form.managingAccountInfoLabel.Text = _msg;
            form.managingAccountInfoLabel.Show();
            if (timer != null) timer.Dispose();
            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler((s, e) => {
                timer.Dispose();
                form.managingAccountInfoLabel.Hide();
            });
            timer.Start();
        }
        public static void HidePanels() {
            changingRole = false;
            foreach (Panel smallPanel in panels) {
                smallPanel.Hide();
            }
            frontPanel = null;
        }
        private static void EnableAllButtons() {
            foreach (Object _object in panel.Controls) {
                if (_object.GetType() == typeof(Button))
                {
                    ((Button)_object).Enabled = true;
                }
            }
        }
        public static void Authorization() {
            EnableAllButtons();
            form.resetPwButton.Enabled = true;
            if (Account.type > 1) {
                form.changeAdminButton.Enabled = false;
                form.resetPwButton.Enabled = false;
            }
            if (Account.type > 2) {
                form.accountsInfoButton.Enabled = false;
                form.addAccountButton.Enabled = false;
            }
        }
        public static void ChangePassword() {
            
            try {
                if (!AdminForm.IsNotUnicode(form.oldPwTextBox.Text)) throw new Exception();
                if (!AdminForm.IsNotUnicode(form.newPwTextBox.Text)) throw new Exception();
                if (!AdminForm.IsNotUnicode(form.newPwTextBox2.Text)) throw new Exception();
                if (!(
                form.oldPwTextBox.Text.Length < 3 ||
                form.newPwTextBox.Text.Length < 3 ||
                form.newPwTextBox2.Text.Length < 3 ||
                !form.newPwTextBox.Text.Equals(form.newPwTextBox2.Text) ||
                !form.oldPwTextBox.Text.Equals(DatabaseController.GetPassword(Account.name.ToLower()))
                ))
                {
                    DatabaseController.ChangePassword(form.newPwTextBox.Text);
                    Log.Write("Đổi mật khẩu");
                    Notify("Đổi mật khẩu thành công");
                    HidePanels();
                }
                else {
                    Notify("Đổi mật khẩu thất bại"); RefreshPwPanel();
                    return;
                }
            }
            catch (Exception) {
                Notify("Đổi mật khẩu thất bại"); RefreshPwPanel();
                return;
            }
        }
        public static void ChangeInfo()
        {
            if (form.changeInfoFullNameTextBox.Text.Length < 5) throw new Exception();
            if (DateTime.Compare(form.changeInfoDateOfBirthDatePicker.Value, DateTime.Now.AddYears(-18)) > 0) throw new Exception();
            string gender;
            if (form.changeInfoMaleRadioButton.Checked) gender = "MALE"; else gender = "FEMALE";
            DatabaseController.ChangeInfo(form.changeInfoFullNameTextBox.Text, form.changeInfoDateOfBirthDatePicker.Value, gender);
        }
        public static void ShowMyInfo() {
            System.Data.DataRow row = DatabaseController.GetAccountInfo(Account.name.ToLower());
            //FULLNAME DATEOFBIRTH GENDER
            form.changeInfoFullNameTextBox.Text = row["FULLNAME"].ToString();
            form.changeInfoDateOfBirthDatePicker.Value = DateTime.Parse(row["DATEOFBIRTH"].ToString());
            if (row["GENDER"].ToString().Equals("MALE")) form.changeInfoMaleRadioButton.Checked = true;
            else form.changeInfoFemaleRadioButton.Checked = true;
        }
        public static void AddAccount()
        {
            try {
                string accountName = form.addAccountAccountNameTextBox.Text.ToLower();
                if (!AdminForm.IsNotUnicode(accountName))throw new Exception("$Thất bại: Không được nhập ký tự đặc biệt");
                if (accountName.Length < 5) throw new Exception("$Thất bại: tên tài khoản quá ngắn");
                if (form.addAccountMaleRadioButton.Checked == false && form.addAccountFemaleRadioButton.Checked == false) throw new Exception("$Thất bại: Chưa chọn giới tính");
                if (form.addAccountFullNameTextBox.Text.Length < 5) throw new Exception("$Thất bại: Tên quá ngắn");
                if (DateTime.Compare(form.addAccountDateOfBirthDatePicker.Value, DateTime.Now.AddYears(-18)) > 0) throw new Exception("$Thất bại: Tuổi chưa đúng hoặc nhỏ hơn 18");
                if (DatabaseController.AccountExisted(accountName)) throw new Exception("accoutnExisted");
                string gender;
                if (form.addAccountMaleRadioButton.Checked) gender = "MALE"; else gender = "FEMALE";
                DatabaseController.AddAcount(accountName, form.addAccountFullNameTextBox.Text, form.addAccountDateOfBirthDatePicker.Value, gender);
                Notify("Thêm tài khoản thành công");
                Log.Write("Thêm tài khoản mới: "+ accountName);
            } catch (Exception e) {
                Notify("Thêm tài khoản thất bại",e.Message);
                Console.WriteLine(e.Message);
            }
        }
        private static void RefreshPwPanel() {
            form.oldPwTextBox.Text = "";
            form.newPwTextBox.Text = "";
            form.newPwTextBox2.Text = "";
        }
        private static void RefreshAddAcountPanel()
        {
            form.addAccountAccountNameTextBox.Text = "";
            form.addAccountDateOfBirthDatePicker.Value = DateTime.Now.AddYears(-18);
            form.addAccountFullNameTextBox.Text = "";
            form.addAccountMaleRadioButton.Checked = false;
            form.addAccountFemaleRadioButton.Checked = false;
        }
        private static void RefreshAccountsInfoPanel() {
            int i = form.accountsInfoAccountNameComboBox.SelectedIndex;
            form.accountsInfoAccountNameComboBox.DataSource = DatabaseController.GetAccountsNames().Tables[0];
            try { form.accountsInfoAccountNameComboBox.SelectedIndex = i; } catch (Exception) { }

        }
        public static void ShowAccountInfo() {
            try
            {
                form.accountsInfoRoleComboBox.Hide();
                System.Data.DataRow row = DatabaseController.GetAccountInfo(form.accountsInfoAccountNameComboBox.SelectedValue.ToString());
                form.accountsInfoFullNameLabel.Text = row["FULLNAME"].ToString();
                form.accountsInfoDateOfBirthLabel.Text = DateTime.Parse(row["DATEOFBIRTH"].ToString()).ToString(AdminForm.vnFullDateFormatString);
                string gender;
                if (row["GENDER"].ToString().Equals("MALE")) gender = "Nam"; else gender = "Nữ";
                form.accountsInfoGenderLabel.Text = gender;
                form.accountsInfoCreationDateLabel.Text = DateTime.Parse(row["CREATION_DATE"].ToString()).ToString(AdminForm.vnFullDateFormatString);
                string role = "";
                int type = Convert.ToInt32(row["TYPE"]);
                switch (type)
                {
                    case 1: role = "Chủ quán"; break;
                    case 2: role = "Quản lý"; form.accountsInfoRoleComboBox.SelectedIndex = 0; break;
                    case 3: role = "Nhân viên"; form.accountsInfoRoleComboBox.SelectedIndex = 1; break;
                    default: role = "?"; break;
                };
                form.accountsInfoRoleLabel.Text = role;
                if (type > Account.type &&
                    !form.accountsInfoAccountNameComboBox.SelectedValue.ToString().Equals(Account.name.ToLower())
                    ) form.accountsInfoStatusToogleButton.Visible = true;
                else form.accountsInfoStatusToogleButton.Visible = false;
                SetStatusInfo(Convert.ToBoolean(row["ENABLED"]));
                if (Account.type == 1 && !row["ACCOUNT"].ToString().Equals(Account.name.ToLower()))
                {
                    form.accountsInfoRoleChangingButton.Show();
                }
                else
                {
                    form.accountsInfoRoleChangingButton.Hide();
                }
            }
            catch (Exception) { }
        }
        public static void SetRole() {
            if (!changingRole) return;
            try
            {
                DatabaseController.SetRole(form.accountsInfoAccountNameComboBox.Text, Convert.ToInt32(form.accountsInfoRoleComboBox.SelectedValue.ToString()));
                Log.Write("Đổi chức vụ tài khoản " + form.accountsInfoAccountNameComboBox.Text + " thành " + (Convert.ToInt32(form.accountsInfoRoleComboBox.SelectedValue.ToString()) == 2 ? "quản lý" : "nhân viên"));
            }
            catch (Exception) { }
        }
        private static void SetStatusInfo(bool _enabled) {
            if (_enabled)
            {
                form.accountsInfoStatusLabel.Text = "Hoạt động";
                form.accountsInfoStatusToogleButton.Text = "Khóa tài khoản";
            }
            else
            {
                form.accountsInfoStatusLabel.Text = "Bị khóa";
                form.accountsInfoStatusToogleButton.Text = "Kích hoạt tài khoản";
            }
        }
        public static void ChangeStatus() {
            DatabaseController.SetStatus(form.accountsInfoAccountNameComboBox.SelectedValue.ToString(), !Convert.ToBoolean(DatabaseController.GetAccountInfo(form.accountsInfoAccountNameComboBox.SelectedValue.ToString())["ENABLED"]));
            string accountName = form.accountsInfoAccountNameComboBox.SelectedValue.ToString();
            bool enabled = Convert.ToBoolean(DatabaseController.GetAccountInfo(form.accountsInfoAccountNameComboBox.SelectedValue.ToString())["ENABLED"]);
            if (enabled)
            {
                Log.Write("Kích hoạt tài khoản " + accountName);
            }
            else {
                Log.Write("Khóa tài khoản " + accountName);
            }
            ShowAccountInfo();
            RefreshAccountsInfoPanel();
        }
        public static void ShowPanel(Panel _panel) {
            changingRole = false;
            if (frontPanel == _panel) {
                return;
            }
            frontPanel = _panel;
            frontPanel.Show();
            frontPanel.BringToFront();
            if (frontPanel == form.changePWpanel) RefreshPwPanel();
            if (frontPanel == form.changeInfoPanel) ShowMyInfo();
            if (frontPanel == form.addAccountPanel) RefreshAddAcountPanel();
            if (frontPanel == form.accountsInfoPanel) RefreshAccountsInfoPanel();
            if (frontPanel == form.changeAdminPanel) RefreshChangeAdminPanel();
            
        }
        public static void ResetPassword() {
            if (MessageBox.Show("Reset mật khẩu tài khoản " + form.accountsInfoAccountNameComboBox.SelectedValue.ToString() + " ?", "Xác nhận !!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            DatabaseController.ChangePassword(form.accountsInfoAccountNameComboBox.SelectedValue.ToString(), "123");
            Log.Write("Reset mật khẩu tài khoản " + form.accountsInfoAccountNameComboBox.SelectedValue.ToString());
            Notify("Reset mật khẩu thành công");
        }
        private static void RefreshChangeAdminPanel() {
            form.changeAdminPasswordPanel.Hide();
            form.changeAdminAccountNameComboBox.DataSource = DatabaseController.GetManagerAccounts().Tables[0];
        }
        public static void ChangeAdmin()
        {
            if(!AdminForm.IsNotUnicode(form.changeAdminPasswordTextBox.Text))
            {
                Notify("Sai mật khẩu");
                return;
            }
            if (!form.changeAdminPasswordTextBox.Text.Equals(DatabaseController.GetPassword(Account.name.ToLower())))
            {
                Notify("Sai mật khẩu");
                return;
            }
            DatabaseController.SetRole(form.changeAdminAccountNameComboBox.SelectedValue.ToString(), 1);
            DatabaseController.SetRole(Account.name.ToLower(), 2); Account.type = 2;
            Log.Write("Đổi tài khoản " + form.changeAdminAccountNameComboBox.SelectedValue.ToString() + " thành tài khoản admin");
            Notify("Chuyển tài khoản thành công");
            form.Authorization();
            HidePanels();
        }
    }
}
