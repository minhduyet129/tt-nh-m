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
    public partial class FormCTHDB : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public FormCTHDB()
        {
            InitializeComponent();
        }

        public static decimal ThanhTienHoaDonBan;
        public static int MaHDChon;
        private int MaSachChon;
        private void FormCTHDB_Load(object sender, EventArgs e)
        {
            labelTT.Text = "Chi tiết hóa đơn bán - " + MaHDChon.ToString();
            List<CTHOADONBAN> lstCTHDB = db.CTHOADONBANs.Where(x => x.MaHD == MaHDChon).ToList();
            HienThiBan(lstCTHDB);
        }

        private void HienThiBan(List<CTHOADONBAN> listCTHDB)
        {
            ThanhTienHoaDonBan = 0;
            listViewCTHDB.Items.Clear();
            foreach (CTHOADONBAN ctpn in listCTHDB)
            {
                ListViewItem newItem = new ListViewItem(ctpn.MaSach.ToString());
                newItem.SubItems.Add(ctpn.SACH.TenSach);
                newItem.SubItems.Add(ctpn.SoLuongBan.ToString());
                newItem.SubItems.Add(ctpn.SACH.GiaBan.Value.ToString("#,##"));
                newItem.SubItems.Add(ctpn.ThanhTien.Value.ToString("#,##"));
                listViewCTHDB.Items.Add(newItem);
                ThanhTienHoaDonBan += ctpn.ThanhTien.Value;
                
            }
            HOADONBAN hd = db.HOADONBANs.SingleOrDefault(x => x.MaHD == MaHDChon);
            hd.TongTien = ThanhTienHoaDonBan;
            db.SaveChanges();

            cbSach.DataSource = db.SACHes.ToList();//đổ dữ liệu ra comboBox
            cbSach.DisplayMember = "TenSach";//Tên được dùng
            cbSach.ValueMember = "MaSach";//Khi chọn tên mà dùng lại thì nó sẽ lấy là mã sách 

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            HOADONBAN hd = db.HOADONBANs.SingleOrDefault(x => x.MaHD == MaHDChon);
            hd.TongTien = ThanhTienHoaDonBan;
            db.SaveChanges();

            this.Close();
        }

        private void listViewCTHDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCTHDB.SelectedItems.Count > 0)
            {
                ListViewItem listCTPN = listViewCTHDB.SelectedItems[0];
                MaSachChon = int.Parse(listCTPN.SubItems[0].Text.ToString());
                cbSach.Text = listCTPN.SubItems[1].Text;
                txtSLban.Text = listCTPN.SubItems[2].Text;
                txtDonGia.Text = listCTPN.SubItems[3].Text;
                txtThanhTien.Text = listCTPN.SubItems[4].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CTHOADONBAN newCTPN = new CTHOADONBAN();
            newCTPN.MaHD = MaHDChon;
            newCTPN.MaSach = int.Parse(cbSach.SelectedValue.ToString());

            CTHOADONBAN ct1 = db.CTHOADONBANs.SingleOrDefault(x => x.MaHD == newCTPN.MaHD && x.MaSach == newCTPN.MaSach);
            if(ct1!=null)
            {
                ct1.SoLuongBan+= int.Parse(txtSLban.Text.ToString());
                SACH sach1 = db.SACHes.Single(x => x.MaSach == newCTPN.MaSach);
                ct1.ThanhTien = ct1.ThanhTien + int.Parse(txtSLban.Text.ToString()) * sach1.GiaBan.Value;
            }

            else
            {
                newCTPN.SoLuongBan = int.Parse(txtSLban.Text.ToString());

                SACH s1 = db.SACHes.Single(x => x.MaSach == newCTPN.MaSach);

                newCTPN.ThanhTien = newCTPN.SoLuongBan * s1.GiaBan.Value;

                ThanhTienHoaDonBan += newCTPN.ThanhTien.Value;
                db.CTHOADONBANs.Add(newCTPN);
            }
            db.SaveChanges();
            MessageBox.Show("Thêm thông tin thành công!");
            FormCTHDB_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                CTHOADONBAN selectedCTPN = db.CTHOADONBANs.Single(x => x.MaHD == MaHDChon && x.MaSach == MaSachChon);
                //selectedCTPN.MaSach = int.Parse(cbSach.SelectedValue.ToString());
                ThanhTienHoaDonBan -= selectedCTPN.ThanhTien.Value;



                selectedCTPN.SoLuongBan = int.Parse(txtSLban.Text.ToString());
                
                selectedCTPN.ThanhTien = selectedCTPN.SoLuongBan * selectedCTPN.SACH.GiaBan;
                db.SaveChanges();

                ThanhTienHoaDonBan += selectedCTPN.ThanhTien.Value;
                MessageBox.Show("Sửa thành công!");
                FormCTHDB_Load(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CTHOADONBAN selectedCTPN = db.CTHOADONBANs.Single(x => x.MaHD == MaHDChon && x.MaSach == MaSachChon);
            ThanhTienHoaDonBan -= selectedCTPN.ThanhTien.Value;
            db.CTHOADONBANs.Remove(selectedCTPN);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công!");
            FormCTHDB_Load(sender, e);
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTimKiem.Text == "" || txtTimKiem.Text == null)
            {
                List<CTHOADONBAN> lstCTPN = db.CTHOADONBANs.Where(x => x.MaHD == MaHDChon).ToList();
                HienThiBan(lstCTPN);
            }
            else
            {
                List<CTHOADONBAN> lstCTPN = db.CTHOADONBANs.Where(x => x.MaHD == MaHDChon && x.SACH.TenSach.Contains(txtTimKiem.Text)).ToList();
                HienThiBan(lstCTPN);
            }
        }
    }
}
