using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInNhapLieu
{
    public partial class QuanLyBGiaDThiepForm : Telerik.WinControls.UI.RadForm, IViewQuanLyBGiaDThiep
    {

        public QuanLyBGiaDThiepForm()
        {
            InitializeComponent();
            quanLyBangGiaPres = new QuanLyBGiaDThiepPresenter(this);
            LoadBangGia();
            LoadHangKhachHang();

            lstBangGia.SelectedIndex = -1;
            lstBangGia.SelectedIndex = 0;
            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);          
            txtNoiDungBangGia.TextChanged += new EventHandler(TextBoxes_TextChanged);          
            txtMoTa.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGiayBao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            
            txtKhoToChay.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
            txtSoHopToiDa.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtMucGia.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongNiemYet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoDanhThiepTrenHop.TextChanged += new EventHandler(TextBoxes_TextChanged);

            chkKhongSuDung.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);
            chkIn2Mat.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);

            txtSoHopToiDa.Leave += new EventHandler(TextBoxes_Leave);
            txtSoDanhThiepTrenHop.Leave += new EventHandler(TextBoxes_Leave);
            txtGiayBao.Leave += new EventHandler(TextBoxes_Leave);

            txtSoHopToiDa.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoDanhThiepTrenHop.KeyPress += new KeyPressEventHandler(InputValidator);


        }
        QuanLyBGiaDThiepPresenter quanLyBangGiaPres;
        #region implementIView
        int _idToInMayDigi = 0;
        public int ID
        {
            get { if (lstBangGia.SelectedValue != null)
                int.TryParse(lstBangGia.SelectedValue.ToString(), out _idToInMayDigi) ;
            return _idToInMayDigi;
            }
            set { _idToInMayDigi = value;
            
            }
        }
        public string Ten
        {
            get
            {
                return txtTen.Text;
            }
            set
            {
                txtTen.Text = value;
            }
        }

        public string NoiDungBangGia
        {
            get
            {
                return txtNoiDungBangGia.Text;
            }
            set
            {
                txtNoiDungBangGia.Text = value;
            }
        }

        public string MoTa
        {
            get
            {
                return txtMoTa.Text;
            }
            set
            {
                txtMoTa.Text = value;
            }
        }

       
       
        int _idHangKH;
        public int IdHangKhachHang
        {
            get { 
                if (cboHangKH.SelectedValue != null)
                    int.TryParse(cboHangKH.SelectedValue.ToString(), out _idHangKH);
                return _idHangKH;
            }
            set
            {
                _idHangKH = value;
                cboHangKH.SelectedValue = _idHangKH;
            }
        }
        public bool InHaiMat 
        {
            get { return chkIn2Mat.Checked; }
                set {chkIn2Mat.Checked = value; }
            }

        public int SoDanhThiepTrenHop
        {
            get { return int.Parse(txtSoDanhThiepTrenHop.Text); }
            set { txtSoDanhThiepTrenHop.Text = value.ToString(); }
        }
        public string GiayBaoGom 
        {
            get { return txtGiayBao.Text; }
            set { txtGiayBao.Text = value; }
        }
        public string KhoToChay
        {
            get { return txtKhoToChay.Text; }
            set { txtKhoToChay.Text = value; }
        }
        public int ThuTu
        {
            get
            {
                return int.Parse(txtThuTu.Text);
            }
            set
            {
                txtThuTu.Text = value.ToString();
            }
        }

       

        public FormStateS TinhTrangForm
        {
            get;
            set;
        }

        public bool DataChanged
        {
            get;
            set;
        }
    

        

        public string DaySoLuong
        {
            get
            {
                return txtDaySoLuong.Text;
            }
            set
            {
                txtDaySoLuong.Text = value;
            }
        }

        public string DayGiaTrang
        {
            get
            {
                return txtMucGia.Text;
            }
            set
            {
                txtMucGia.Text = value;
            }
        }

        public string DaySoLuongNiemYet
        {
            get
            {
                return txtDaySoLuongNiemYet.Text;
            }
            set
            {
                txtDaySoLuongNiemYet.Text = value.ToString();
            }
        }

      

      
        public bool KhongCon
        {
            get
            {
                return chkKhongSuDung.Checked;
            }
            set
            {
                chkKhongSuDung.Checked = value;
            }
        }
        public int SoHopToiDa
        {
            get
            {
                return int.Parse(txtSoHopToiDa.Text);
            }
            set
            {
                txtSoHopToiDa.Text = value.ToString();
            }
        }
        #endregion
        private void LoadBangGia()
        {

            lstBangGia.DataSource = quanLyBangGiaPres.BangGiaDanhThiepS();
            lstBangGia.ValueMember = "ID";
            lstBangGia.DisplayMember = "Ten";
           
            //Binding bindSource = new Binding("MayInDigi", nguon, "ID");
            
            
        }
        private void LoadHangKhachHang()
        {

            cboHangKH.DataSource = quanLyBangGiaPres.HangKhachHangS();
            cboHangKH.ValueMember = "ID";
            cboHangKH.DisplayMember = "Ten";

            //Binding bindSource = new Binding("MayInDigi", nguon, "ID");


        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTen.ReadOnly = readOnly;
            txtNoiDungBangGia.IsReadOnly = readOnly;                  
          
            txtMoTa.IsReadOnly = readOnly;
            txtSoHopToiDa.ReadOnly = readOnly;                        
            txtDaySoLuong.ReadOnly = readOnly;
            txtMucGia.ReadOnly = readOnly;
            txtDaySoLuongNiemYet.ReadOnly = readOnly;
            txtThuTu.ReadOnly = readOnly;
            chkIn2Mat.ReadOnly = readOnly;
            txtGiayBao.ReadOnly = readOnly;
            txtKhoToChay.ReadOnly = readOnly;
            cboHangKH.ReadOnly = readOnly;
            chkKhongSuDung.ReadOnly = readOnly;
            txtSoDanhThiepTrenHop.ReadOnly = readOnly;
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyBangGiaPres.TrinhBayThemMoi();
        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            //Xử lý xóa hêt
                Telerik.WinControls.UI.RadTextBox tb;
                if (sender is Telerik.WinControls.UI.RadTextBox)
                {
                    tb = (Telerik.WinControls.UI.RadTextBox)sender;
                    if (tb == txtSoHopToiDa)
                        if (string.IsNullOrEmpty(txtSoHopToiDa.Text.Trim()))
                            this.SoHopToiDa = 0;
                    if (tb == txtThuTu)
                        if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                            this.ThuTu = 0;

                    if (tb == txtSoDanhThiepTrenHop)
                        if (string.IsNullOrEmpty(txtSoDanhThiepTrenHop.Text.Trim()))
                            this.SoDanhThiepTrenHop = 100;

                    if (tb == txtGiayBao)
                        if (string.IsNullOrEmpty(txtGiayBao.Text.Trim()))
                            this.GiayBaoGom = "Couche 300gsm";
                }
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            this.DataChanged = true;
            btnLuu.Enabled = this.DataChanged;

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if ( tb == txtThuTu ||
                    tb == txtSoHopToiDa || tb == txtSoDanhThiepTrenHop )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
              
                
               
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu

            //Kiểm tra xong
            var thongDiep = "";
            quanLyBangGiaPres.Luu(ref thongDiep);
            MessageBox.Show(thongDiep);
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
            lstBangGia.Enabled = true;
            LoadBangGia();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            lstBangGia.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            XoaSachNoiDungTatCaTextBox();
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
        }

        private void QuanLyMayInDigiFrom_Load(object sender, EventArgs e)
        {
            //Bật tắt các nút
            btnDong.Enabled = true;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.Edit;
            lstBangGia.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyBangGiaPres.TrinhBayChiTietMayIn();
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
            lblIDBanGia.Text = this.ID.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnDong.Enabled = true;
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            DatReadOnlyTextBox(true);
            quanLyBangGiaPres.TrinhBayChiTietMayIn();
            lstBangGia.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnXemMayIn_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyMayInDigiForm(this.IdHangKhachHang);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý máy in Digital";
            frm.ShowDialog();
        }

        private void cboHangKH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            lblDienGiaiHangKH.Text = quanLyBangGiaPres.DienGiaiHangKhachHang();
        }







     
    }
}
