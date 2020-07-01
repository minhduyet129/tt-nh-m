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
    public partial class FormThongKe : Form
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            int slnv = db.NHANVIENs.Count();
            txtSLNV.Text = slnv.ToString();
            int slncc = db.NHACUNGCAPs.Count();
            txtSLNCC.Text = slncc.ToString();
            decimal tongTienHoaDon = db.HOADONBANs.Sum(x => x.TongTien).Value;
            txtDoanhThu.Text = tongTienHoaDon.ToString("#,##");
            decimal tongTienNhap = db.PHIEUNHAPs.Sum(x => x.TongTienNhap).Value;
            txtTienNhap.Text = tongTienNhap.ToString("#,##");
        }
        
        void thongKe(DateTime batDau, DateTime ketThuc)
        {
            List<HOADONBAN> dsHD = db.HOADONBANs.Where(x => x.NgayBan <= ketThuc && x.NgayBan >= batDau).ToList();
            List<PHIEUNHAP> dsPN = db.PHIEUNHAPs.Where(x => x.NgayNhap <= ketThuc && x.NgayNhap >= batDau).ToList();

            if(dsHD.Count()==0 && dsPN.Count()==0)
            {
                MessageBox.Show("Ngày nhập sai vui lòng nhập lại!");
            }    
            else
            {
                if (dsHD.Count() == 0)
                {
                    txtDoanhThu.Text = "0";
                }
                else txtDoanhThu.Text = dsHD.Sum(x => x.TongTien).Value.ToString("#,##"); 
                if (dsPN.Count() == 0)
                {
                    txtTienNhap.Text = "0";
                }
                else txtTienNhap.Text = dsPN.Sum(x => x.TongTienNhap).Value.ToString("#,##");
            }



            //decimal tongTienHoaDon = db.HOADONBANs.Where(x => x.NgayBan <= ketThuc && x.NgayBan >= batDau).Sum(x => x.TongTien).Value;
            //txtDoanhThu.Text = tongTienHoaDon.ToString("#,##");
            //decimal tongTienNhap = db.PHIEUNHAPs.Where(x => x.NgayNhap <= ketThuc && x.NgayNhap >= batDau).Sum(x => x.TongTienNhap).Value;
            //txtTienNhap.Text = tongTienNhap.ToString("#,##");
        }

        private void bntKiemTra_Click(object sender, EventArgs e)
        {
            thongKe(dateTimePickerNgayBD.Value, dateTimePickerNgayKT.Value);
        }
    }
}
