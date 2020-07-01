using QuanLyBanSach.Model;
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
    public partial class HoaDonBan : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public HoaDonBan()
        {
            InitializeComponent();
        }
        private int MaHD;
        public static decimal ThanhTien;
        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            List<HOADONBAN> lstHDB = db.HOADONBANs.ToList();
            HienThiHD(lstHDB);
        }
        public void HienThiHD(List<HOADONBAN> listHDB)
        {
            listViewHoaDonBan.Items.Clear();
            foreach (HOADONBAN hdb in listHDB)
            {
                ListViewItem newItem = new ListViewItem(hdb.MaHD.ToString());
                newItem.SubItems.Add(hdb.NgayBan.Value.ToString("yyyy/MM/dd"));
                newItem.SubItems.Add(hdb.NHANVIEN.TenNV);
                newItem.SubItems.Add(hdb.TongTien.Value.ToString("#,##"));
                listViewHoaDonBan.Items.Add(newItem);
            }
            cbMaHD.DataSource = db.HOADONBANs.ToList();//đổ dữ liệu ra comboBox
            cbMaHD.DisplayMember = "MaHD";//Tên được dùng

            cbNV.DataSource = db.NHANVIENs.ToList();
            cbNV.DisplayMember = "TenNV";
            cbNV.ValueMember = "MaNV";//Khi chọn tên mà dùng lại thì nó sẽ lấy là mã ncc 

            if (FormCTHDB.MaHDChon != 0)
            {
                MaHD = FormCTHDB.MaHDChon;
                HOADONBAN pn = db.HOADONBANs.Single(x => x.MaHD == MaHD);
                pn.TongTien = FormCTHDB.ThanhTienHoaDonBan;
                db.SaveChanges();
            }

        }

        private void listViewHoaDonBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewHoaDonBan.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewHoaDonBan.SelectedItems[0];
                MaHD = int.Parse(selectedItem.SubItems[0].Text);
                cbMaHD.Text = MaHD.ToString();
                dtNgayBan.Value = DateTime.Parse(selectedItem.SubItems[1].Text);
                cbNV.Text = selectedItem.SubItems[2].Text;
                txtBoxTongTien.Text = selectedItem.SubItems[3].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HOADONBAN newHD = new HOADONBAN();
            newHD.NgayBan = DateTime.Now;
            newHD.MaNV = int.Parse(cbNV.SelectedValue.ToString());
            newHD.TongTien = 0;
            db.HOADONBANs.Add(newHD);
            db.SaveChanges();
            MessageBox.Show("Thêm thành công!");
            HoaDonBan_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HOADONBAN selectedPN = db.HOADONBANs.Single(x => x.MaHD == MaHD);
            selectedPN.NgayBan = dtNgayBan.Value;
            selectedPN.MaNV = int.Parse(cbNV.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Sửa thành công!");
            HoaDonBan_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            HOADONBAN selectedPN = db.HOADONBANs.Single(x => x.MaHD == MaHD);
            db.HOADONBANs.Remove(selectedPN);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công!");
            HoaDonBan_Load(sender, e);
        }

        private void btnCTHDB_Click(object sender, EventArgs e)
        {
            if (MaHD != 0)
            {
                FormCTHDB.MaHDChon = MaHD;
                FormCTHDB ctpn = new FormCTHDB();
                this.Hide();
                ctpn.ShowDialog();
                HoaDonBan_Load(sender, e);
                this.Show();
            }
            else MessageBox.Show("bạn hãy chọn hóa đơn bán thì mới xem được chi tiết của nó!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            HoaDonBan_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
