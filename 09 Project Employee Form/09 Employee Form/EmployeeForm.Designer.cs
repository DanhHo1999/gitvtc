namespace _09_Employee_Form
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.noConnectionLabel = new System.Windows.Forms.Label();
            this._flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _flowLayoutPanel1
            // 
            this._flowLayoutPanel1.Controls.Add(this.button1);
            this._flowLayoutPanel1.Controls.Add(this.noConnectionLabel);
            this._flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this._flowLayoutPanel1.Name = "_flowLayoutPanel1";
            this._flowLayoutPanel1.Size = new System.Drawing.Size(392, 664);
            this._flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(482, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(200, 20, 10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bảng thông báo";
            // 
            // noConnectionLabel
            // 
            this.noConnectionLabel.AutoSize = true;
            this.noConnectionLabel.Font = new System.Drawing.Font("Arial Unicode MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noConnectionLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.noConnectionLabel.Location = new System.Drawing.Point(200, 49);
            this.noConnectionLabel.Margin = new System.Windows.Forms.Padding(200, 20, 10, 25);
            this.noConnectionLabel.Name = "noConnectionLabel";
            this.noConnectionLabel.Size = new System.Drawing.Size(165, 138);
            this.noConnectionLabel.TabIndex = 1;
            this.noConnectionLabel.Text = "No Connection";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(699, 687);
            this.ControlBox = false;
            this.Controls.Add(this._flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeForm";
            this.Text = "Dashboard";
            this._flowLayoutPanel1.ResumeLayout(false);
            this._flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label noConnectionLabel;
    }
}

