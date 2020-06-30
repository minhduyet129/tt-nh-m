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
    public partial class FormNhanVien : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public FormNhanVien()
        {
            InitializeComponent();
        }

        //
        //Hiện thị thông tin nhân viên
        //
        private void HienThi(List<NHANVIEN> nhanVien)
        {
            listViewNhanVien.Items.Clear(); 
            //dổ dữ liệu vào listview nhân viên

            foreach(NHANVIEN nv in nhanVien)
            {
                ListViewItem newItem = new ListViewItem(nv.MaNV.ToString());
                newItem.SubItems.Add(nv.TenNV);
                newItem.SubItems.Add(nv.DiaChi.ToString());
                newItem.SubItems.Add(nv.Luong.Value.ToString("#,##"));
                listViewNhanVien.Items.Add(newItem);
            }
            cbMaNV.DataSource = db.NHANVIENs.ToList();//đổ dữ liệu ra comboBox
            cbMaNV.DisplayMember = "MaNV";//Tên được dùng

            cbTenNV.DataSource = db.NHANVIENs.ToList();
            cbTenNV.DisplayMember = "TenNV";
            cbTenNV.ValueMember = "MaNV";//Khi chọn tên mà dùng lại thì nó sẽ lấy là mã nv
        }
        //
        //
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            List<NHANVIEN> nhanVien = db.NHANVIENs.ToList();
            HienThi(nhanVien);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        //Thêm Nhân Viên
        //
        private void btnThem_Click(object sender, EventArgs e)
        {
            NHANVIEN newNV = new NHANVIEN();
            List<NHANVIEN> lstNV = db.NHANVIENs.Where(x => x.TenNV== cbTenNV.Text).ToList();
            if (lstNV.Count() == 0)
            {
                newNV.TenNV = cbTenNV.Text;
                newNV.DiaChi = TxtDiaChi.Text;
                newNV.Luong = decimal.Parse(txtLuong.Text);
                db.NHANVIENs.Add(newNV);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                FormNhanVien_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Nhân viên đã tồn tại");
            }
          
        }
        //
        //Khi click vào 1 nhân viên
        //
        private int maNV;
        private void listViewNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewNhanVien.SelectedItems[0];
                maNV = int.Parse(selectedItem.SubItems[0].Text);
                cbMaNV.Text = maNV.ToString();
                cbTenNV.Text = selectedItem.SubItems[1].Text;
                TxtDiaChi.Text = selectedItem.SubItems[2].Text;
                txtLuong.Text = selectedItem.SubItems[3].Text;

            }    
        }
        //
        //Sửa Nhân Viên
        //
        private void btnSua_Click(object sender, EventArgs e)
        {
            NHANVIEN selectedNV = db.NHANVIENs.Single(x => x.MaNV == maNV);
            selectedNV.TenNV = cbTenNV.Text;
            selectedNV.DiaChi = TxtDiaChi.Text;
            selectedNV.Luong= decimal.Parse(txtLuong.Text);
            db.SaveChanges();
            MessageBox.Show("Sửa thành công!");
            FormNhanVien_Load(sender, e);
        }
        //
        //Xóa nhân viên
        //
        private void btnXoa_Click(object sender, EventArgs e)
        {
            NHANVIEN selectedNV = db.NHANVIENs.Single(x => x.MaNV == maNV);
            db.NHANVIENs.Remove(selectedNV);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công");
            FormNhanVien_Load(sender, e);
        }
        //


    }
}
