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
    public partial class QuanLyEpKimForm : Telerik.WinControls.UI.RadForm, IViewQuanLyEpKim
    {

        public QuanLyEpKimForm()
        {
            InitializeComponent();
            quanLyThanPhamPres = new QuanLyEpKimPresenter(this);
            LoadThanhPham();

            lstThanhPham.SelectedIndex = -1;
            lstThanhPham.SelectedIndex = 0;
            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtBHR.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTocDo.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThoiGianChuanBi.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDonViTinh.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtPhiNgVatLieuChuanBi.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongCB.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDayLoiNhuanCB.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongNiemYet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGiaKhuonCM2.TextChanged += new EventHandler(TextBoxes_TextChanged);
            chkLaNhuViTinh.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);

            txtTen.Leave += new EventHandler(TextBoxes_Leave);
            txtBHR.Leave += new EventHandler(TextBoxes_Leave);
            txtTocDo.Leave += new EventHandler(TextBoxes_Leave);
            txtThoiGianChuanBi.Leave += new EventHandler(TextBoxes_Leave);
            txtDonViTinh.Leave += new EventHandler(TextBoxes_Leave);
            txtPhiNgVatLieuChuanBi.Leave += new EventHandler(TextBoxes_Leave);
            txtDaySoLuongCB.Leave += new EventHandler(TextBoxes_Leave);
            txtDayLoiNhuanCB.Leave += new EventHandler(TextBoxes_Leave);
            txtDaySoLuongNiemYet.Leave += new EventHandler(TextBoxes_Leave);
            txtThuTu.Leave += new EventHandler(TextBoxes_Leave);
            txtGiaKhuonCM2.Leave += new EventHandler(TextBoxes_Leave);
            

            txtPhiNgVatLieuChuanBi.KeyPress += new KeyPressEventHandler(InputValidator);
            txtBHR.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTocDo.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThoiGianChuanBi.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaKhuonCM2.KeyPress += new KeyPressEventHandler(InputValidator);


        }
        QuanLyEpKimPresenter quanLyThanPhamPres;
        #region implementIView
        int _idToInMayDigi = 0;
        public int ID
        {
            get { if (lstThanhPham.SelectedValue != null)
                int.TryParse(lstThanhPham.SelectedValue.ToString(), out _idToInMayDigi) ;
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

        public string DonViTinh
        {
            get
            {
                return txtDonViTinh.Text;
            }
            set
            {
                txtDonViTinh.Text = value;
            }
        }

        public int PhiNguyenVatLieuChuanBi
        {
            get
            {
                return int.Parse(txtPhiNgVatLieuChuanBi.Text);
            }
            set
            {
                txtPhiNgVatLieuChuanBi.Text = value.ToString();
            }
        }
        public int GiaKhuonCM2
        { 
            get {return int.Parse(txtGiaKhuonCM2.Text);}
            set {txtGiaKhuonCM2.Text = value.ToString(); }
        }
        public bool LaNhuViTinh 
        {
            get { return chkLaNhuViTinh.Checked; }
            set { chkLaNhuViTinh.Checked = value; }
        }
        public float ThoiGianChuanBi
        {
            get
            {
                return float.Parse(txtThoiGianChuanBi.Text);
            }
            set
            {
                txtThoiGianChuanBi.Text = value.ToString();
            }
        }
        public int TocDo
        {
            get {
                return int.Parse(txtTocDo.Text);
            }
            set
            {
                txtTocDo.Text = value.ToString();
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

        public bool DuLieuDaThayDoi
        {
            get;
            set;
        }
    
       

        public string DaySoLuongCoBan
        {
            get
            {
                return txtDaySoLuongCB.Text;
            }
            set
            {
                txtDaySoLuongCB.Text = value;
            }
        }

        public string DayLoiNhuanCoBan
        {
            get
            {
                return txtDayLoiNhuanCB.Text;
            }
            set
            {
                txtDayLoiNhuanCB.Text = value;
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

            
        public int BHR
        {
            get
            {
                return int.Parse(txtBHR.Text);
            }
            set
            {
                txtBHR.Text = value.ToString();
            }
        }
        #endregion
        private void LoadThanhPham()
        {

            lstThanhPham.DataSource = quanLyThanPhamPres.ThanhPhamS();
            lstThanhPham.ValueMember = "ID";
            lstThanhPham.DisplayMember = "Ten";                
            
            
        }
       
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTen.ReadOnly = readOnly;
            txtBHR.ReadOnly = readOnly;             
            txtDonViTinh.ReadOnly = readOnly;
            txtTocDo.ReadOnly = readOnly;
            txtThoiGianChuanBi.ReadOnly = readOnly;
            txtPhiNgVatLieuChuanBi.ReadOnly = readOnly;                      
            txtDaySoLuongCB.IsReadOnly = readOnly;
            txtDayLoiNhuanCB.IsReadOnly = readOnly;
            txtDaySoLuongNiemYet.ReadOnly = readOnly;
            txtThuTu.ReadOnly = readOnly;
            txtGiaKhuonCM2.ReadOnly = readOnly;
            chkLaNhuViTinh.ReadOnly = readOnly;
          
            
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyThanPhamPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                //Xử lý dữ liệu thay đổi
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTen || tb == txtTocDo ||
                    tb == txtBHR || tb == txtThuTu ||
                    tb == txtThoiGianChuanBi || tb == txtDonViTinh ||
                    tb == txtDaySoLuongNiemYet || tb == txtPhiNgVatLieuChuanBi ||
                    tb == txtGiaKhuonCM2
                    )
                {
                    this.DuLieuDaThayDoi = true;
                }
                

            }
            Telerik.WinControls.UI.RadTextBoxControl tbc;
            if (sender is Telerik.WinControls.UI.RadTextBoxControl)
            {
                tbc = (Telerik.WinControls.UI.RadTextBoxControl)sender;

                if (tbc == txtDayLoiNhuanCB || tbc == txtDaySoLuongCB)
                {
                    this.DuLieuDaThayDoi = true;
                }               

            }
            Telerik.WinControls.UI.RadCheckBox chk;
            if (sender is Telerik.WinControls.UI.RadCheckBox)
            {
                chk = (Telerik.WinControls.UI.RadCheckBox)sender;
                if (chk == chkLaNhuViTinh)
                    this.DuLieuDaThayDoi = true;
            }
            
            btnLuu.Enabled = this.DuLieuDaThayDoi;

        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                //Xử lý dữ liệu thay đổi
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                
                //Xử lý xóa hêt
                if (tb == txtBHR)
                    if (string.IsNullOrEmpty(txtBHR.Text.Trim()))
                        this.BHR = 1;

                if (tb == txtTocDo)
                    if (string.IsNullOrEmpty(txtTocDo.Text.Trim()))
                        this.TocDo = 1;

                if (tb == txtThoiGianChuanBi)
                    if (string.IsNullOrEmpty(txtThoiGianChuanBi.Text.Trim()))
                        this.ThoiGianChuanBi = 1;

                if (tb == txtPhiNgVatLieuChuanBi)
                    if (string.IsNullOrEmpty(txtPhiNgVatLieuChuanBi.Text.Trim()))
                        this.PhiNguyenVatLieuChuanBi = 0;

                if (tb == txtGiaKhuonCM2)
                    if (string.IsNullOrEmpty(txtGiaKhuonCM2.Text.Trim()))
                        this.GiaKhuonCM2 = 0;


                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        this.ThuTu = 99;

            }
            Telerik.WinControls.UI.RadTextBoxControl tbc;
            if (sender is Telerik.WinControls.UI.RadTextBoxControl)
            {
                tbc = (Telerik.WinControls.UI.RadTextBoxControl)sender;

                if (tbc == txtDayLoiNhuanCB || tbc == txtDaySoLuongCB)
                {
                    this.DuLieuDaThayDoi = true;
                }

            }
            Telerik.WinControls.UI.RadCheckBox chk;
            if (sender is Telerik.WinControls.UI.RadCheckBox)
            {
                chk = (Telerik.WinControls.UI.RadCheckBox)sender;
                if (chk == chkLaNhuViTinh)
                    this.DuLieuDaThayDoi = true;
            }

            btnLuu.Enabled = this.DuLieuDaThayDoi;

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if ( tb == txtThuTu || tb == txtTocDo ||
                    tb == txtBHR || tb == txtPhiNgVatLieuChuanBi  ||
                    tb == txtGiaKhuonCM2)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (tb == txtThoiGianChuanBi)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
              
              
               
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu

            //Kiểm tra xong
            var thongDiep = "";
            quanLyThanPhamPres.Luu(ref thongDiep);
            MessageBox.Show(thongDiep);
            //Lưu xong:
            this.DuLieuDaThayDoi = false;
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
            lstThanhPham.Enabled = true;
            LoadThanhPham();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            lstThanhPham.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            XoaSachNoiDungTatCaTextBox();
            this.DuLieuDaThayDoi = false;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
        }

        private void QuanLyMayInDigiFrom_Load(object sender, EventArgs e)
        {
            //Bật tắt các nút
            btnDong.Enabled = true;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.Edit;
            lstThanhPham.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyThanPhamPres.TrinhBayChiTietMayIn();
            this.DuLieuDaThayDoi = false;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            lblIDBanGia.Text = this.ID.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnDong.Enabled = true;
            this.DuLieuDaThayDoi = false;
            btnLuu.Enabled = this.DuLieuDaThayDoi;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            DatReadOnlyTextBox(true);
            quanLyThanPhamPres.TrinhBayChiTietMayIn();
            lstThanhPham.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnXemMayIn_Click(object sender, EventArgs e)
        {
           /* var frm = new QuanLyMayInDigiForm(this.Id);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý máy in Digital";
            frm.ShowDialog();
            */
        }

        private void cboHangKH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
        }

        private void btnKiemTraDaySoluongLoiNhuan_Click(object sender, EventArgs e)
        {
            if (!quanLyThanPhamPres.KiemTraDaySoLuongVaLoiNhuan())
                MessageBox.Show("Lỗi!");
            else
                MessageBox.Show("Đã khớp 2 số lượng! OK");
        }

        private void chkLaNhuViTinh_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.LaNhuViTinh)
            {
                lblTocDo.Text = "mét/giờ";
            }
            else lblTocDo.Text = "con/giờ";
        }










       
    }
}
