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
    public partial class PhieuNhap : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public PhieuNhap()
        {
            InitializeComponent();
        }
        private int MaPN;
        public static decimal ThanhTien;
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThi(List<PHIEUNHAP> listPN)
        {
            listViewPhieuNhap.Items.Clear();
            foreach(PHIEUNHAP pn in listPN)
            {
                ListViewItem newItem = new ListViewItem(pn.MaPN.ToString());
                newItem.SubItems.Add(pn.NgayNhap.Value.ToString("yyyy/MM/dd"));
                newItem.SubItems.Add(pn.NHACUNGCAP.TenNCC);
                newItem.SubItems.Add(pn.TongTienNhap.Value.ToString("#,##"));
                listViewPhieuNhap.Items.Add(newItem);
            }
            cbMaPN.DataSource = db.PHIEUNHAPs.ToList();//đổ dữ liệu ra comboBox
            cbMaPN.DisplayMember = "MaPN";//Tên được dùng

            cbNCC.DataSource = db.NHACUNGCAPs.ToList();
            cbNCC.DisplayMember = "TenNCC";
            cbNCC.ValueMember = "MaNCC";//Khi chọn tên mà dùng lại thì nó sẽ lấy là mã ncc 
            if(FormCTPN.MaPNChon!=0)
            {
                MaPN = FormCTPN.MaPNChon;
                PHIEUNHAP pn = db.PHIEUNHAPs.Single(x => x.MaPN == MaPN);
                pn.TongTienNhap = FormCTPN.ThanhTienPhieuNhap;
                db.SaveChanges();
            }    

        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            List<PHIEUNHAP> lstPN = db.PHIEUNHAPs.ToList();
            HienThi(lstPN);
        }

        private void listViewPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewPhieuNhap.SelectedItems.Count>0)
            {
                ListViewItem selectedItem = listViewPhieuNhap.SelectedItems[0];
                MaPN= int.Parse(selectedItem.SubItems[0].Text);
                cbMaPN.Text = MaPN.ToString();
                dtNgayNhap.Value = DateTime.Parse(selectedItem.SubItems[1].Text);
                cbNCC.Text = selectedItem.SubItems[2].Text;
                txtBoxTongTien.Text = selectedItem.SubItems[3].Text;
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PHIEUNHAP newPN = new PHIEUNHAP();
            newPN.NgayNhap = DateTime.Now;
            newPN.MaNCC = int.Parse(cbNCC.SelectedValue.ToString());
            newPN.TongTienNhap = 0;
            db.PHIEUNHAPs.Add(newPN);
            db.SaveChanges();
            MessageBox.Show("Thêm thành công!");
            PhieuNhap_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PHIEUNHAP selectedPN = db.PHIEUNHAPs.Single(x => x.MaPN == MaPN);
            selectedPN.NgayNhap = dtNgayNhap.Value;
            selectedPN.MaNCC= int.Parse(cbNCC.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Sửa thành công!");
            PhieuNhap_Load(sender, e);
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PHIEUNHAP selectedPN = db.PHIEUNHAPs.Single(x => x.MaPN == MaPN);
            db.PHIEUNHAPs.Remove(selectedPN);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công!");
            PhieuNhap_Load(sender, e);
        }

        private void btnCTPN_Click(object sender, EventArgs e)
        {
            if (MaPN != 0)
            {
                FormCTPN.MaPNChon = MaPN;
                FormCTPN ctpn = new FormCTPN();
                this.Hide();
                ctpn.ShowDialog();
                PhieuNhap_Load(sender, e);
                this.Show();
            }
            else MessageBox.Show("bạn hãy chọn phiếu nhập thì mới xem được chi tiết của nó!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            PhieuNhap_Load(sender, e);
        }
        
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
