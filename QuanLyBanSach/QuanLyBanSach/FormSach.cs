using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanSach.Model;

namespace QuanLyBanSach
{
    public partial class FormSach : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public FormSach()
        {
            InitializeComponent();
        }
    //
    //Hiện thị thông tin sách lên listView
    //
    private void HienThi(List<SACH> listSach)
        {
            listViewSach.Items.Clear();//xóa listView hiện tại
            //đổ dữ liệu vào listViewSach
            foreach(SACH sach in listSach)
            {
                ListViewItem newItem = new ListViewItem(sach.MaSach.ToString());
                newItem.SubItems.Add(sach.TenSach);
                newItem.SubItems.Add(sach.SoLuongTonKho.ToString());
                newItem.SubItems.Add(sach.GiaBan.Value.ToString("#,##"));
                listViewSach.Items.Add(newItem);
            }

            //cbSach.DataSource = db.SACHes.ToList();
            //cbSach.DisplayMember = "TenSach";

        }

        private void FormSach_Load(object sender, EventArgs e)
        {
            List<SACH> listSach = db.SACHes.ToList();
            HienThi(listSach);
        }

        private int maSach;
        private void listViewSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewSach.SelectedItems.Count>0)
            {
                ListViewItem selectedItem = listViewSach.SelectedItems[0];
                maSach = int.Parse(selectedItem.SubItems[0].Text);
                txtSach.Text = selectedItem.SubItems[1].Text;
                txtSLTonKho.Text = selectedItem.SubItems[2].Text;
                txtGiaBan.Text = selectedItem.SubItems[3].Text;

            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SACH newsach = new SACH();
            List<SACH> lstSach = db.SACHes.Where(x => x.TenSach == txtSach.Text).ToList();
            if(lstSach.Count() == 0)
            {
                newsach.TenSach = txtSach.Text;
                newsach.SoLuongTonKho = int.Parse(txtSLTonKho.Text);
                newsach.GiaBan = int.Parse(txtGiaBan.Text);
                db.SACHes.Add(newsach);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                FormSach_Load(sender, e);
            }   
            else
            {
                MessageBox.Show("Sách đã tồn tại");
            }
          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SACH selectedSach = db.SACHes.Single(x => x.MaSach== maSach);
            selectedSach.TenSach= txtSach.Text;
            selectedSach.SoLuongTonKho = int.Parse(txtSLTonKho.Text);
            selectedSach.GiaBan = decimal.Parse(txtGiaBan.Text);
            db.SaveChanges();
            MessageBox.Show("Sửa thành công!");
            FormSach_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SACH selectedSach = db.SACHes.Single(x => x.MaSach== maSach);
            db.SACHes.Remove(selectedSach);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công!");
            FormSach_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //

    }
}
