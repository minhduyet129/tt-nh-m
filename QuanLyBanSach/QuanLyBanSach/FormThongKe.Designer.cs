namespace QuanLyBanSach
{
    partial class FormThongKe
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSLNV = new System.Windows.Forms.TextBox();
            this.txtSLNCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTienNhap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bntKiemTra = new System.Windows.Forms.Button();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayBD = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayKT = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 57);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(822, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lượng nhân viên:";
            // 
            // txtSLNV
            // 
            this.txtSLNV.Location = new System.Drawing.Point(64, 127);
            this.txtSLNV.Name = "txtSLNV";
            this.txtSLNV.Size = new System.Drawing.Size(227, 36);
            this.txtSLNV.TabIndex = 5;
            // 
            // txtSLNCC
            // 
            this.txtSLNCC.Location = new System.Drawing.Point(468, 127);
            this.txtSLNCC.Name = "txtSLNCC";
            this.txtSLNCC.Size = new System.Drawing.Size(278, 36);
            this.txtSLNCC.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng nhà cung cấp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "đến ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerNgayKT);
            this.groupBox1.Controls.Add(this.dateTimePickerNgayBD);
            this.groupBox1.Controls.Add(this.txtTienNhap);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bntKiemTra);
            this.groupBox1.Controls.Add(this.txtDoanhThu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(44, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 289);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh thu";
            // 
            // txtTienNhap
            // 
            this.txtTienNhap.Location = new System.Drawing.Point(358, 166);
            this.txtTienNhap.Name = "txtTienNhap";
            this.txtTienNhap.Size = new System.Drawing.Size(276, 36);
            this.txtTienNhap.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tổng tiền nhập sách";
            // 
            // bntKiemTra
            // 
            this.bntKiemTra.Location = new System.Drawing.Point(550, 230);
            this.bntKiemTra.Name = "bntKiemTra";
            this.bntKiemTra.Size = new System.Drawing.Size(134, 43);
            this.bntKiemTra.TabIndex = 14;
            this.bntKiemTra.Text = "Kiểm tra";
            this.bntKiemTra.UseVisualStyleBackColor = true;
            this.bntKiemTra.Click += new System.EventHandler(this.bntKiemTra_Click);
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(358, 104);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(276, 36);
            this.txtDoanhThu.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 28);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tổng tiền bán sách";
            // 
            // dateTimePickerNgayBD
            // 
            this.dateTimePickerNgayBD.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNgayBD.Location = new System.Drawing.Point(137, 48);
            this.dateTimePickerNgayBD.Name = "dateTimePickerNgayBD";
            this.dateTimePickerNgayBD.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerNgayBD.TabIndex = 17;
            // 
            // dateTimePickerNgayKT
            // 
            this.dateTimePickerNgayKT.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNgayKT.Location = new System.Drawing.Point(522, 48);
            this.dateTimePickerNgayKT.Name = "dateTimePickerNgayKT";
            this.dateTimePickerNgayKT.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerNgayKT.TabIndex = 18;
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(822, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSLNCC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSLNV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormThongKe";
            this.Text = "FormThongKe";
            this.Load += new System.EventHandler(this.FormThongKe_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSLNV;
        private System.Windows.Forms.TextBox txtSLNCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bntKiemTra;
        private System.Windows.Forms.TextBox txtTienNhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayKT;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayBD;
    }
}