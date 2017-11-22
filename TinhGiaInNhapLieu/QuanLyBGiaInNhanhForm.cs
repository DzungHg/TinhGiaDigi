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
    public partial class QuanLyBGiaInNhanhForm : Telerik.WinControls.UI.RadForm, IViewQuanLyBangGiaInNhanh
    {

        public QuanLyBGiaInNhanhForm()
        {
            InitializeComponent();
            quanLyBangGiaPres = new QuanLyBGiaInNhanhPresenter(this);
            LoadBangGia();
            LoadHangKhachHang();

            lstBangGia.SelectedIndex = -1;
            lstBangGia.SelectedIndex = 0;
            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
            txtNoiDungBangGia.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
            txtMoTa.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
            txtSoTrangToiDaTinh.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtMucGia.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongNiemYet.TextChanged += new EventHandler(TextBoxes_TextChanged);
           

            chkKhongSuDung.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);   
          
           
            txtSoTrangToiDaTinh.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);


        }
        QuanLyBGiaInNhanhPresenter quanLyBangGiaPres;
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
        public bool GiaTheoKhoang
        {
            get
            {
                return chkGiaTheoKhoang.Checked;
            }
            set
            {
                chkGiaTheoKhoang.Checked = value;
            }
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

      

      
        public bool KhongSuDung
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
        public int SoTrangToiDaTinh
        {
            get
            {
                return int.Parse(txtSoTrangToiDaTinh.Text);
            }
            set
            {
                txtSoTrangToiDaTinh.Text = value.ToString();
            }
        }
        #endregion
        private void LoadBangGia()
        {

            lstBangGia.DataSource = quanLyBangGiaPres.BangGiaInNhanhS();
            lstBangGia.ValueMember = "ID";
            lstBangGia.DisplayMember = "TenBangGia";
           
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
            txtSoTrangToiDaTinh.ReadOnly = readOnly;                        
            txtDaySoLuong.ReadOnly = readOnly;
            txtMucGia.ReadOnly = readOnly;
            txtDaySoLuongNiemYet.ReadOnly = readOnly;
            txtThuTu.ReadOnly = readOnly;
           
            cboHangKH.ReadOnly = readOnly;
            chkKhongSuDung.ReadOnly = readOnly;
            
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyBangGiaPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTen ||                  
                    tb == txtSoTrangToiDaTinh || tb == txtThuTu 
                    )
                {
                    this.DataChanged = true;

                }
            }
            Telerik.WinControls.UI.RadTextBoxControl tbc;
            if (sender is Telerik.WinControls.UI.RadTextBoxControl)
            {
                tbc = (Telerik.WinControls.UI.RadTextBoxControl)sender;

                if (tbc == txtMoTa || tbc == txtNoiDungBangGia)
                   
                {
                    this.DataChanged = true;
                }

                Telerik.WinControls.UI.RadCheckBox ch;
                if (sender is Telerik.WinControls.UI.RadCheckBox)
                {
                    ch = (Telerik.WinControls.UI.RadCheckBox)sender;
                    if ( ch == chkKhongSuDung)
                        this.DataChanged = true;
                }
               

            }
             Telerik.WinControls.UI.RadCheckBox chk;
             if (sender is Telerik.WinControls.UI.RadCheckBox)
             {
                 chk = (Telerik.WinControls.UI.RadCheckBox)sender;
                 if (chk == chkKhongSuDung)
                     this.DataChanged = true;
             }

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
                    tb == txtSoTrangToiDaTinh )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
              
                //Xử lý xóa hêt
               
                if (tb == txtSoTrangToiDaTinh)
                    if (string.IsNullOrEmpty(txtSoTrangToiDaTinh.Text.Trim()))
                        txtSoTrangToiDaTinh.Text = "1";
                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        txtThuTu.Text = "0";
               
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

        private void cMnu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mnuNhanDoiBangGia_Click(object sender, EventArgs e)
        {
            var thongDiep = "";
            if (MessageBox.Show("Bạn nhân đôi " + this.Ten, "Chú ý", MessageBoxButtons.OKCancel
                , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
            {
                quanLyBangGiaPres.NhanDoiBangGia(ref thongDiep);
                MessageBox.Show(thongDiep);
                LoadBangGia();
            }
        }







     
    }
}
