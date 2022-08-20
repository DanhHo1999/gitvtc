using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using ClassLibrary1;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
        OpenFileDialog open;
        SaveFileDialog save;
        private void bt_chon_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog x = new FolderBrowserDialog();
            open = new OpenFileDialog();
            open.Filter = "|*.txt";
           if (open.ShowDialog() == DialogResult.OK )
            {
                textBox_duonglink.Text = open.FileName; 
                StreamReader read = new StreamReader(open.FileName);
                textBox_text.Text = read.ReadToEnd();
                read.Close();
            }
           
        }

        private void bt_luu_Click(object sender, EventArgs e)
        {
            save = new SaveFileDialog();
            save.Filter = "|*.txt";
            save.RestoreDirectory = true;
            if (save.ShowDialog() == DialogResult.OK )
            {
                StreamWriter write = new StreamWriter(save.FileName);
                write.WriteLine(textBox_chuki.Text);
                write.Close();
            }
        }
        Class1 xxx = new Class1();
        private void button_taokhoa_Click(object sender, EventArgs e)
        {
            try
            {
                long x = Convert.ToInt64(textBox_soP.Text);
                long y = Convert.ToInt64(textBox_soQ.Text);
             
                 if (xxx.CHECK_SNT(x) == true && xxx.CHECK_SNT(y) == true)
                {
                    if (x <= 13 || y <= 13) MessageBox.Show("Bạn cần nhập vào 2 số nguyên tố lớn Để khóa được an toàn ");
                    else
                    {
                        List<long> khoa = xxx.TaoKhoa(Convert.ToInt64(textBox_soP.Text), Convert.ToInt64(textBox_soQ.Text));
                        textBox_soN.Text = khoa[1].ToString();
                        textBox_soE.Text = khoa[2].ToString();
                        textBox_khoabimat.Text = khoa[0].ToString();
                    } 
 
                }
                 else
                 {
                     MessageBox.Show("P,Q phải là số nguyên tố !!!");
                 }
            }
            catch
            {
                MessageBox.Show("Mời bạn nhập 2 số nguyên tố P,Q (P # Q)");
            }
        }
        byte[] arrayhash;
        byte[] arrayhash2;
        
        private void bt_taohambam_Click(object sender, EventArgs e)
        {
          
            Class1 bam = new Class1();
            arrayhash = bam.hash(textBox_text.Text);
            foreach (byte a in arrayhash)
            {
                textBox_hambam.Text += a.ToString() + " ";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Random r = new Random();
                long x = r.Next(1, 1000);
                long y = r.Next(1, 1000);
                while (xxx.CHECK_SNT(x) == false || xxx.CHECK_SNT(y) == false)
                {
                    Random rr = new Random();
                    x = rr.Next(1, 1000);
                    y = rr.Next(1, 1000);
                }
                {
                    textBox_soP.Text = Convert.ToString(x);
                    textBox_soQ.Text = Convert.ToString(y);
                    List<long> khoa = xxx.TaoKhoa(x, y);
                    textBox_soN.Text = khoa[1].ToString();
                    textBox_soE.Text = khoa[2].ToString();
                    textBox_khoabimat.Text = khoa[0].ToString();
                }
            }
            else
            {
                textBox_soP.Text = "";
                textBox_soQ.Text = "";
                textBox_soE.Text = "";
                textBox_soN.Text = "";
                textBox_khoabimat.Text = "";
            }
        }

        private void bt_taochuki_Click(object sender, EventArgs e)
        {
            List<long> mang1 = new List<long>();
            try
            {
                foreach (byte k in arrayhash)
                {
                    long i = Convert.ToInt64(k);
                    long j = xxx.TINHA(i, Convert.ToInt64(textBox_khoabimat.Text), Convert.ToInt64(textBox_soN.Text));
                    mang1.Add(j);
                }
                foreach (long k in mang1)
                {
                    textBox_chuki.Text += k.ToString() + " ";
                }
               
            }
            catch
            {
                MessageBox.Show("Bạn chưa nhập Khóa hoặc nội dung tin để tạo hàm băm !!!");
            }
            
        }

        private void button_mahoa_Click(object sender, EventArgs e)
        {
            
            if (textBox_text.Text == "")
            {
               MessageBox.Show("Bạn cần nhập vào nội dung tin !!!");
                return;
            }
            Convert.ToString(textBox_text.Text);
            Class1 xxx = new Class1();
            textBox_mahoa.Text = xxx.getMD5(textBox_text.Text);
           
        }






        private void bt_xoa_Click(object sender, EventArgs e)
        {
            textBox_text.Text = "";
            textBox_mahoa.Text = "";
            textBox_hambam.Text = "";
            textBox_chuki.Text = "";
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_chon1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog x = new FolderBrowserDialog();
            open = new OpenFileDialog();
            open.Filter = "|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_duongdan1.Text = open.FileName;
                StreamReader read = new StreamReader(open.FileName);
                textBox_noidungtin.Text = read.ReadToEnd();
                read.Close();
            }
        }

        private void button_chon2_Click(object sender, EventArgs e)
        {
             
            FolderBrowserDialog x = new FolderBrowserDialog();
            open = new OpenFileDialog();
            open.Filter = "|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_duongdan2.Text = open.FileName;
                StreamReader read = new StreamReader(open.FileName);
               textBox_vanbandaki.Text = read.ReadToEnd();
                read.Close();
            }
        }

        private void button_ketluan_Click(object sender, EventArgs e)
        {
            try
            {
                List<long> Mang1 = new List<long>();
                List<long> Mang2 = new List<long>();
                List<long> Mang3 = new List<long>();
                Class1 bam2 = new Class1();
                arrayhash2 = bam2.hash(textBox_noidungtin.Text);
                foreach (byte i in arrayhash2)
                {
                    long j = Convert.ToInt64(i);
                    Mang1.Add(j);
                    
                }
             
                string chuoi = textBox_vanbandaki.Text.Trim();
                string[] chuoi2 = chuoi.Split(' ');
                foreach (string i in chuoi2)
                {
                    Mang2.Add(Convert.ToInt64(i));
                    
                }
                foreach (long i in Mang2)
                {
                    long tam;
                    tam = xxx.TINHA(i, Convert.ToInt64(textBox_khoaE.Text), Convert.ToInt64(textBox_khoaN.Text));
                    Mang3.Add(tam);
                }
              
                int k = 0;
                for (int i = 0; i <= 15; i++)
                {
                    if (Mang1[i] != Mang3[i])
                    {
                        MessageBox.Show(" VĂN BẢN ĐÃ BỊ THAY ĐỔI HOẶC KHÓA KHÔNG CHÍNH XÁC !!!");
                        k++;
                        break;

                    }

                }
                if (k == 0) MessageBox.Show(" VĂN BẢN ĐƯỢC BẢO TOÀN !!!");
                
            }
            catch
            {
                MessageBox.Show(" BẠN CẦN NHẬP KHÓA !!!");
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox_noidungtin.Text = ""; 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox_vanbandaki.Text = "";
        }

        private void button_thoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

    
   }
}
