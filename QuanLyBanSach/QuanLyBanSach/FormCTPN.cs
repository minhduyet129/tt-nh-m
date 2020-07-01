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
    public partial class FormCTPN : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public FormCTPN()
        {
            InitializeComponent();
        }
        public static decimal ThanhTienPhieuNhap { get; set; }
        public static int MaPNChon;
        private int MaSachChon;


        private void HienThi(List<CTPHIEUNHAP> listCTPN)
        {
            ThanhTienPhieuNhap = 0;
            listViewCTPN.Items.Clear();
            foreach (CTPHIEUNHAP ctpn in listCTPN)
            {
                ListViewItem newItem = new ListViewItem(ctpn.MaSach.ToString());
                newItem.SubItems.Add(ctpn.SACH.TenSach);
                newItem.SubItems.Add(ctpn.SoLuongNhap.ToString());
                newItem.SubItems.Add(ctpn.DonGiaNhap.Value.ToString("#,##"));
                newItem.SubItems.Add(ctpn.ThanhTienNhap.Value.ToString("#,##"));
                listViewCTPN.Items.Add(newItem);
                ThanhTienPhieuNhap += ctpn.ThanhTienNhap.Value;
            }
            cbSach.DataSource = db.SACHes.ToList();//đổ dữ liệu ra comboBox
            cbSach.DisplayMember = "TenSach";//Tên được dùng
            cbSach.ValueMember = "MaSach";//Khi chọn tên mà dùng lại thì nó sẽ lấy là mã sách 
            
        }

        private void FormCTPN_Load(object sender, EventArgs e)
        {
            labelTT.Text += MaPNChon.ToString();
            List<CTPHIEUNHAP> lstCTPN = db.CTPHIEUNHAPs.Where(x => x.MaPN == MaPNChon).ToList();
            HienThi(lstCTPN);
        }

        private void listViewCTPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCTPN.SelectedItems.Count > 0)
            {
                ListViewItem listCTPN = listViewCTPN.SelectedItems[0];
                MaSachChon = int.Parse(listCTPN.SubItems[0].Text.ToString());
                cbSach.Text = listCTPN.SubItems[1].Text;
                txtSLnhap.Text = listCTPN.SubItems[2].Text;
                txtDonGia.Text = listCTPN.SubItems[3].Text;
                txtThanhTien.Text = listCTPN.SubItems[4].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CTPHIEUNHAP newCTPN = new CTPHIEUNHAP();
            newCTPN.MaPN = MaPNChon;
            newCTPN.MaSach = int.Parse(cbSach.SelectedValue.ToString());
            newCTPN.SoLuongNhap = int.Parse(txtSLnhap.Text.ToString());
            newCTPN.DonGiaNhap = decimal.Parse(txtDonGia.Text.ToString());
            newCTPN.ThanhTienNhap = newCTPN.SoLuongNhap * newCTPN.DonGiaNhap;
            ThanhTienPhieuNhap += newCTPN.ThanhTienNhap.Value;
            db.CTPHIEUNHAPs.Add(newCTPN);
            db.SaveChanges();
            MessageBox.Show("Thêm thông tin thành công!");
            FormCTPN_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                CTPHIEUNHAP selectedCTPN = db.CTPHIEUNHAPs.Single(x => x.MaPN == MaPNChon && x.MaSach == MaSachChon);
                //selectedCTPN.MaSach = int.Parse(cbSach.SelectedValue.ToString());
                ThanhTienPhieuNhap -= selectedCTPN.ThanhTienNhap.Value;



                selectedCTPN.SoLuongNhap = int.Parse(txtSLnhap.Text.ToString());
                selectedCTPN.DonGiaNhap = decimal.Parse(txtDonGia.Text.ToString());
                selectedCTPN.ThanhTienNhap = selectedCTPN.SoLuongNhap * selectedCTPN.DonGiaNhap;
                db.SaveChanges();

                ThanhTienPhieuNhap += selectedCTPN.ThanhTienNhap.Value;
                MessageBox.Show("Sửa thành công!");
                FormCTPN_Load(sender, e);
            }
            catch(Exception ex) { MessageBox.Show("" + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CTPHIEUNHAP selectedCTPN = db.CTPHIEUNHAPs.Single(x => x.MaPN == MaPNChon && x.MaSach == MaSachChon);
            ThanhTienPhieuNhap -= selectedCTPN.ThanhTienNhap.Value;
            db.CTPHIEUNHAPs.Remove(selectedCTPN);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công!");
            FormCTPN_Load(sender, e);
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtTimKiem.Text=="" || txtTimKiem.Text == null)
            {
                List<CTPHIEUNHAP> lstCTPN = db.CTPHIEUNHAPs.Where(x => x.MaPN == MaPNChon).ToList();
                HienThi(lstCTPN);
            }
            else
            {
                List<CTPHIEUNHAP> lstCTPN = db.CTPHIEUNHAPs.Where(x => x.MaPN == MaPNChon && x.SACH.TenSach.Contains(txtTimKiem.Text)).ToList();
                HienThi(lstCTPN);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
