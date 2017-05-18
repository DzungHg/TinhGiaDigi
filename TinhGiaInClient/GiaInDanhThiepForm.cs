using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;

namespace TinhGiaInClient
{
    
    public partial class GiaInDanhThiepForm : Form, IViewGiaDanhThiep
    {
        public GiaInDanhThiepForm(ThongTinBanDauChoDanhThiep thongTinBanDau,  int idBaiInDanhthiep = 0 )
        {
            InitializeComponent();            
            this.IdHangKH = thongTinBanDau.IdHangKhachHang;        
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.ID = idBaiInDanhthiep;

            giaDanhThiepPres = new GiaDanhThiepPresenter(this);
            txtHangKhachHang.Text = thongTinBanDau.TenHangKhachHang;
            
            LoadDanhSachBangGia();
            cboBangGia.SelectedIndex = 0;
            //envents
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lblTienIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lblTienGiay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lblThanhTien.TextChanged += new EventHandler(TextBoxes_TextChanged);
        }
        GiaDanhThiepPresenter giaDanhThiepPres;
        #region implement IViewDanhThiep
        public int ID
        {
            get;
            set;
        }

        public int IdHangKH
        {
            get;
            set;
        }
        public string TenHangKH
        {
            get { return giaDanhThiepPres.TenHangKH(); }
            set { txtHangKhachHang.Text = value; }
        }
        public int SoMatIn
        {
            get;
            set;
        }
        int _idBangGiaChon;
        public int IdBangGiaChon
        {
            get
            {
                return giaDanhThiepPres.IdBangGiaChon();
            }
            set { _idBangGiaChon = value; }
        }

        public string TenBangGiaChon
        {
            get
            {
                return cboBangGia.Text;
            }
            set
            {
                cboBangGia.Text = value;
            }
        }
        public GiayDeIn GiayDeInChon
        {
            get;
            set;
        }
            
        public int IdGiayChon { get; set; }
        public string TenGiayChon
        {
            get { return giaDanhThiepPres.TenGiayChon(); }
            set { txtTenGiay.Text = value; }
        }
        public string KichThuoc 
        {
            get { return txtKichThuoc.Text; }
            set { txtKichThuoc.Text = value; }
        }
        public int SoLuong
        {
            get { return int.Parse(txtSoLuong.Text); }
            set { txtSoLuong.Text = value.ToString(); }
        }

        decimal _tienIn;
        public decimal TienIn
        {
            get
            {
                _tienIn = giaDanhThiepPres.GiaDanhThiepTheoBang();
                return _tienIn;
            }
            set
            {
                _tienIn = value;
                lblTienIn.Text = string.Format("{0:0,0.00}đ", _tienIn);
            }
        }
        decimal _tienGiay;
        public decimal TienGiay
        {
            get
            {
                _tienGiay = giaDanhThiepPres.TienGiay();
                return _tienGiay;
            }
            set
            {
                _tienGiay = value;
                lblTienGiay.Text = string.Format("{0:0,0.00}đ", _tienGiay);
            }
        }
        decimal _thanhTien;
        public decimal ThanhTien
        {
            get
            {
                _thanhTien = giaDanhThiepPres.ThanhTien();
                return _thanhTien;
            }
            set
            {
                _thanhTien = value;
                lblThanhTien.Text = string.Format("{0:0,0.00}đ", _thanhTien);
            }
        }
        
        public string GiaTBHopInfo
        {
            get
            {
                return giaDanhThiepPres.GiaTBInfo();
            }
            set
            {
                lblGiaTB_Hop.Text = value;
            }
        }

        public FormStates TinhTrangForm
        {
            get;
            set;
        }
     
        #endregion
        public BaiInDanhThiep DocBaiInDanhThiep()
        {
            return giaDanhThiepPres.DocBaiInDanhThiep();
        }
        private void LoadDanhSachBangGia()
        {
            cboBangGia.Items.Clear();
            foreach (KeyValuePair<int, string> kv in giaDanhThiepPres.BangGiaDanhThiepS())
            {
                cboBangGia.Items.Add(kv.Value);
            }
        }
        private void cboBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoiDungBangGia.Clear();
            txtNoiDungBangGia.Lines = giaDanhThiepPres.NoiDungBangGia().ToArray();
            this.TienIn = giaDanhThiepPres.GiaDanhThiepTheoBang();            
            this.TenGiayChon = giaDanhThiepPres.TenGiayChon();
            
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoLuong)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                
            }
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox t;
            Label lb;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                if (t == txtSoLuong)
                {
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "1";
                    this.TienIn = giaDanhThiepPres.GiaDanhThiepTheoBang();
                    
                }                
            }
            if (sender is Label)
            {
                lb = (Label)sender;
                if (lb == lblTienIn)
                {
                    this.TienGiay = giaDanhThiepPres.TienGiay();
                    this.ThanhTien = giaDanhThiepPres.ThanhTien();
                }
                if (lb== lblTienGiay)
                {
                    this.ThanhTien = giaDanhThiepPres.ThanhTien();
                }
                if (lb == lblThanhTien)
                {
                    lblGiaTB_Hop.Text = giaDanhThiepPres.GiaTBInfo();
                }
            }

        }
        #region đổi giấy 
        private void DoiGiayMoi()
        {
            var thongTinBanDau = new ThongTinBanDauChoGiayIn();
            thongTinBanDau.TinhTrangForm = FormStates.New;
            thongTinBanDau.SoLuongSanPham = this.SoLuong * 100;
            thongTinBanDau.IdHangKhachHang = this.IdHangKH;
            thongTinBanDau.IdToIn_MayInChon = this.GiayDeInChon.IdMayIn;
            thongTinBanDau.ThongTinCanThiet = string.Format("Danh thiếp {0} "  + '\r' + '\n',
                this.KichThuoc)
                + string.Format("Số lượng {0} cái ({1} hộp)" + '\r' + '\n',
                this.SoLuong * 100, this.SoLuong)
                + "Cần cẩn thận chọn khổ giấy";

            //Tiến hành gắn
            var frm = new GiayDeInForm(thongTinBanDau);
            frm.Text = "[Đổi] Giấy In";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormChuanBiGiay_Click(frm);
                //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());

            }

        }
        private void SuaGiayIn()
        {
            if (this.GiayDeInChon == null)
                return;
            var thongTinBanDau = new ThongTinBanDauChoGiayIn();
            thongTinBanDau.TinhTrangForm = FormStates.Edit;
            thongTinBanDau.SoLuongSanPham = this.SoLuong;
            thongTinBanDau.IdHangKhachHang = this.IdHangKH;
            thongTinBanDau.IdToIn_MayInChon = this.GiayDeInChon.IdMayIn;
            thongTinBanDau.ThongTinCanThiet = string.Format("Danh thiếp {0} " + '\r' + '\n',
                this.KichThuoc)
                + string.Format("Số lượng {0} cái ({1} hộp)" + '\r' + '\n',
                this.SoLuong * 100, this.SoLuong)
                + "Cần cẩn thận chọn khổ giấy";
            var frm = new GiayDeInForm(thongTinBanDau, this.GiayDeInChon);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "[Sửa] Giấy In";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            //Xử Bấm click //trường hợp edit
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormChuanBiGiay_Click(frm);//Cập nhật dữ liệu


            }


        }
        private void XuLyNutOKTrenFormChuanBiGiay_Click(GiayDeInForm frm)
        {
            
            switch (frm.TinhTrangForm)
            {
                case FormStates.New:
                    this.GiayDeInChon = frm.DocGiayDeIn();
                    this.TenGiayChon = giaDanhThiepPres.TenGiayChon();
                    this.TienGiay = giaDanhThiepPres.TienGiay();
                    txtSoLuong.Enabled = false;//Lock lại
                    break;
                case FormStates.Edit:
                    //Đổi ID vì thêm mới là có id mới
                    this.GiayDeInChon = frm.DocGiayDeIn();
                    this.TenGiayChon = giaDanhThiepPres.TenGiayChon();
                    this.TienGiay = giaDanhThiepPres.TienGiay();
                    txtSoLuong.Enabled = false;//Lock lại
                    break;
            }
        }
        #endregion

        private void txtNoiDungBangGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChonGiayKhac_Click(object sender, EventArgs e)
        {
            if (this.GiayDeInChon != null)
                SuaGiayIn();
            else
                DoiGiayMoi();
        }

        private void btnResetGiay_Click(object sender, EventArgs e)
        {
            this.GiayDeInChon = null;
            this.TenGiayChon = giaDanhThiepPres.TenGiayChon();
            this.TienGiay = giaDanhThiepPres.TienGiay();
            txtSoLuong.Enabled = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblThanhTien_Click(object sender, EventArgs e)
        {

        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();


            if (string.IsNullOrEmpty(txtKichThuoc.Text))
                loiS.Add("Kích thước trống");
      
            if (this.SoLuong <= 0)
                loiS.Add("Số lượng < 0");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }
        private void GiaInDanhThiepForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
               string ms = "";
               if (!KiemTraHopLe(ref ms))
               {
                   var dialogeR = MessageBox.Show(ms, "Nội dung thiếu, bạn muốn làm tiếp?",
                        MessageBoxButtons.YesNo);
                   if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                       e.Cancel = true;
                   else

                       this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
               }
           
     
        }
    }
}
