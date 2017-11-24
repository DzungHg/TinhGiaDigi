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
    public partial class NiemYetGiaInNhanhForm : Telerik.WinControls.UI.RadForm, IViewNiemYetGiaInNhanh
    {

        public NiemYetGiaInNhanhForm()
        {
            InitializeComponent();

            niemYetGiaPres = new NiemYetGiaInNhanhPresenter(this);

            LoadNiemYetGia();
            LoadHangKhachHang();

            lstNiemYet.SelectedIndex = -1;
            lstNiemYet.SelectedIndex = 0;
            //Event
            txtTenNiemYet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            
           
          
            txtDienGiai.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
            txtSoTrangToiDaTinh.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
            txtDaySoLuongNiemYet.TextChanged += new EventHandler(TextBoxes_TextChanged);
           

            chkKhongSuDung.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);
            chkDuocGomTrang.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);
            txtTenNiemYet.Leave += new EventHandler(TextBoxes_Leave);
            txtSoTrangToiDaTinh.Leave += new EventHandler(TextBoxes_Leave);
            txtThuTu.Leave += new EventHandler(TextBoxes_Leave);

            txtSoTrangToiDaTinh.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);


        }
        NiemYetGiaInNhanhPresenter niemYetGiaPres;
        #region implementIView
        int _idToInMayDigi = 0;
        public int ID
        {
            get { if (lstNiemYet.SelectedValue != null)
                int.TryParse(lstNiemYet.SelectedValue.ToString(), out _idToInMayDigi) ;
            return _idToInMayDigi;
            }
            set { _idToInMayDigi = value;
            
            }
        }
       
        public bool DuocGomTrang
        {
            get { return chkDuocGomTrang.Checked; }
            set { chkDuocGomTrang.Checked = value; }
        }

        public string DienGiai
        {
            get
            {
                return txtDienGiai.Text;
            }
            set
            {
                txtDienGiai.Text = value;
            }
        }
        public int IdBangGia
        {
            get;
            set;
        }
        public string TenBangGia
        {
            get { return lblTenBangGia.Text; }
            set { lblTenBangGia.Text = value; }
        }
        public string LoaiBangGia
        {
            get { return lblLoaiBangGia.Text; }
            set { lblLoaiBangGia.Text = value; }
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

        public string TenNiemYet
        {
            get
            { return txtTenNiemYet.Text; }
            set { txtTenNiemYet.Text = value; }
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
        public int SoTrangToiDa
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
        private void LoadNiemYetGia()
        {

            lstNiemYet.DataSource = niemYetGiaPres.DanhSachNiemYet();
            lstNiemYet.ValueMember = "ID";
            lstNiemYet.DisplayMember = "Ten";                    
            
        }
        private void LoadHangKhachHang()
        {

            cboHangKH.DataSource = niemYetGiaPres.HangKhachHangS();
            cboHangKH.ValueMember = "ID";
            cboHangKH.DisplayMember = "Ten";

            //Binding bindSource = new Binding("MayInDigi", nguon, "ID");


        }
       
        
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTenNiemYet || tb ==  txtDaySoLuongNiemYet ||                  
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

                if (tbc == txtDienGiai )
                   
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

                 if (chk == chkDuocGomTrang)
                     this.DataChanged = true;
             }

            btnLuu.Enabled = this.DataChanged;

        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTenNiemYet)
                    if (string.IsNullOrEmpty(txtTenNiemYet.Text.Trim()))
                        this.TenNiemYet = "Tên";
                if (   tb == txtSoTrangToiDaTinh)
                    if (string.IsNullOrEmpty(txtSoTrangToiDaTinh.Text.Trim()))
                        this.SoTrangToiDa = 0;
                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        this.ThuTu = 0;
               
                
            }
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

        private void BatTatCacNutDuLieuTheoDieuKienForm()
        {
            switch (this.TinhTrangForm)
            {
                case FormStateS.View:
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    DatReadOnlyTextBox(true);
                    break;
                case FormStateS.New:
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;
                    btnHuy.Enabled = true;
                    DatReadOnlyTextBox(false);
                    break;
                case FormStateS.Edit:
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;
                    btnHuy.Enabled = true;
                    DatReadOnlyTextBox(false);
                    break;


            }
        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTenNiemYet.ReadOnly = readOnly; //luôn là vậy

            txtDienGiai.IsReadOnly = readOnly;
            txtSoTrangToiDaTinh.ReadOnly = readOnly;

            txtDaySoLuongNiemYet.ReadOnly = readOnly;
            txtThuTu.ReadOnly = readOnly;

            cboHangKH.ReadOnly = readOnly;
            chkKhongSuDung.ReadOnly = readOnly;
            chkDuocGomTrang.ReadOnly = readOnly;
            btnChonBangGia.Enabled = !readOnly; //Enable

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu

            //Kiểm tra xong
            var thongDiep = "";
            niemYetGiaPres.Luu(ref thongDiep);
            MessageBox.Show(thongDiep);
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            BatTatCacNutDuLieuTheoDieuKienForm();
            btnLuu.Enabled = this.DataChanged;
           
            
            lstNiemYet.Enabled = true;
            LoadNiemYetGia();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            lstNiemYet.Enabled = false;                        
            //XoaSachNoiDungTatCaTextBox();
            niemYetGiaPres.TrinhBayThemMoi();
            BatTatCacNutDuLieuTheoDieuKienForm();
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
        }

        private void QuanLyMayInDigiFrom_Load(object sender, EventArgs e)
        {
            //Bật tắt các nút
           
            btnLuu.Enabled = this.DataChanged;
            BatTatCacNutDuLieuTheoDieuKienForm();
            //MessageBox.Show(this.TinhTrangForm.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.Edit;
            lstNiemYet.Enabled = false;
            BatTatCacNutDuLieuTheoDieuKienForm();
           
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            niemYetGiaPres.TrinhBayChiTietNiemYet();
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
            lblIDBanGia.Text = this.ID.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnDong.Enabled = true;
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            BatTatCacNutDuLieuTheoDieuKienForm();
          
            niemYetGiaPres.TrinhBayChiTietNiemYet();
            lstNiemYet.Enabled = true;
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
            lblDienGiaiHangKH.Text = niemYetGiaPres.DienGiaiHangKH();
        }

        private void cMnu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnChonBangGia_Click(object sender, EventArgs e)
        {
            DSBangGiaForm frm = new DSBangGiaForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Danh sách bảng giá ";
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.IdBangGia = frm.IdBangGiaChon;
                this.LoaiBangGia = frm.LoaiBangGia;
                if (string.IsNullOrEmpty(this.TenNiemYet) 
                    || this.TinhTrangForm == FormStateS.New)
                    this.TenNiemYet = niemYetGiaPres.TenBangGia(this.IdBangGia, this.LoaiBangGia);

                if (string.IsNullOrEmpty(this.DienGiai.Trim())
                    || this.TinhTrangForm == FormStateS.New)
                    this.DienGiai = niemYetGiaPres.DienGiaiBangGia(this.IdBangGia, this.LoaiBangGia);

            }
        }

        private void radLabel20_Click(object sender, EventArgs e)
        {

        }

        private void lblIDBanGia_Click(object sender, EventArgs e)
        {

        }

        private void radLabel16_Click(object sender, EventArgs e)
        {

        }

        private void txtSoTrangToiDaTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXemBangGiaKem_Click(object sender, EventArgs e)
        {
            if (this.IdBangGia <= 0)
                return;
            //
            var frm = new BangGiaForm(this.LoaiBangGia, FormStateS.View, this.IdBangGia);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.Text = "[Xem]";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
           
        }










    }
}
