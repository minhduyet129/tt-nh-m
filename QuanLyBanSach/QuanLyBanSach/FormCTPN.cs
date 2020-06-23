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

        public static int MaPNChon;
        private void HienThi(List<CTPHIEUNHAP> listCTPN)
        {
            listViewCTPN.Items.Clear();
            foreach (CTPHIEUNHAP ctpn in listCTPN)
            {
                ListViewItem newItem = new ListViewItem(ctpn.MaSach.ToString());
                newItem.SubItems.Add(ctpn.SACH.TenSach);
                newItem.SubItems.Add(ctpn.SoLuongNhap.ToString());
                newItem.SubItems.Add(ctpn.DonGiaNhap.Value.ToString("#,##"));
                newItem.SubItems.Add(ctpn.ThanhTienNhap.Value.ToString("#,##"));
                listViewCTPN.Items.Add(newItem);
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

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

    }
}
