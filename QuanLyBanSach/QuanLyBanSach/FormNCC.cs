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
    public partial class FormNCC : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public FormNCC()
        {
            InitializeComponent();
        }

        //
        //Hiện thị thông tin nhà cung cấp
        //
        private void HienThi(List<NHACUNGCAP> listNcc)
        {
            listViewNCC.Items.Clear();
            //dổ dữ liệu vào listview nhà cung cấp

            foreach (NHACUNGCAP Ncc in listNcc)
            {
                ListViewItem newItem = new ListViewItem(Ncc.MaNCC.ToString());
                newItem.SubItems.Add(Ncc.TenNCC);
                newItem.SubItems.Add(Ncc.SDT);
                newItem.SubItems.Add(Ncc.DiaChi);
                listViewNCC.Items.Add(newItem);
            }
            cbMaNCC.DataSource = db.NHACUNGCAPs.ToList();//đổ dữ liệu ra comboBox
            cbMaNCC.DisplayMember = "MaNCC";//Tên được dùng

            cbTenNCC.DataSource = db.NHACUNGCAPs.ToList();
            cbTenNCC.DisplayMember = "TenNCC";
            cbTenNCC.ValueMember = "MaNCC";//Khi chọn tên mà dùng lại thì nó sẽ lấy là mã ncc 
        }

        private void FormNCC_Load(object sender, EventArgs e)
        {
            List<NHACUNGCAP> listNcc = db.NHACUNGCAPs.ToList();
            HienThi(listNcc);
        }
        //
        //Click vào listview
        //
        private int maNCC;
        private void listViewNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNCC.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewNCC.SelectedItems[0];
                maNCC = int.Parse(selectedItem.SubItems[0].Text);
                cbMaNCC.Text = maNCC.ToString();
                cbTenNCC.Text = selectedItem.SubItems[1].Text;
                txtSDT.Text = selectedItem.SubItems[2].Text;
                txtDiaChi.Text = selectedItem.SubItems[3].Text;

            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NHACUNGCAP newNCC = new NHACUNGCAP();
            List<NHACUNGCAP> lstNcc = db.NHACUNGCAPs.Where(x => x.TenNCC== cbTenNCC.Text).ToList();
            if (lstNcc.Count() == 0)
            {
                newNCC.TenNCC = cbTenNCC.Text;
                newNCC.SDT = txtSDT.Text;
                newNCC.DiaChi= txtDiaChi.Text;
                db.NHACUNGCAPs.Add(newNCC);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                FormNCC_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Nhà cung cấp đã tồn tại đã tồn tại");
            }
        }
        //
        //Sửa nhà cung cấp
        //
        private void btnSua_Click(object sender, EventArgs e)
        {
            NHACUNGCAP selectedNcc = db.NHACUNGCAPs.Single(x => x.MaNCC == maNCC);
            selectedNcc.TenNCC= cbTenNCC.Text;
            selectedNcc.SDT= txtSDT.Text;
            selectedNcc.DiaChi= txtDiaChi.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thành công!");
            FormNCC_Load(sender, e);
        }
        //
        //Xóa Nhà cung cấp
        //
        private void btnXoa_Click(object sender, EventArgs e)
        {
            NHACUNGCAP selectedNcc = db.NHACUNGCAPs.Single(x => x.MaNCC == maNCC);
            db.NHACUNGCAPs.Remove(selectedNcc);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công!");
            FormNCC_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //

    }
}
