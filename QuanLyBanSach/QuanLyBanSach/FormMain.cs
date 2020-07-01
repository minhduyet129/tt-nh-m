using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            this.Hide();
            hdb.ShowDialog();
           
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PhieuNhap hdb = new PhieuNhap();
            this.Hide();
            hdb.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormNhanVien hdb = new FormNhanVien();
            this.Hide();
            hdb.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSach hdb = new FormSach();
            this.Hide();
            hdb.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNCC hdb = new FormNCC();
            this.Hide();
            hdb.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormThongKe hdb = new FormThongKe();
            this.Hide();
            hdb.ShowDialog();
            this.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
