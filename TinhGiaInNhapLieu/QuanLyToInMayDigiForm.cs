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
    public partial class QuanLyToInMayDigiForm : Telerik.WinControls.UI.RadForm, IViewQuanLyToInMayDigi
    {

        public QuanLyToInMayDigiForm()
        {
            InitializeComponent();
            quanLyMayPres = new QuanLyToInMayDigiPresenter(this);
            LoadToInMayDiGi();
            LoadMayIn();

            lstToInDigi.SelectedIndex = -1;
            lstToInDigi.SelectedIndex = 0;
            //Event
            txtTenMay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtCao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtVungInRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtVungInCao.TextChanged += new EventHandler(TextBoxes_TextChanged);            
            txtTocDoHieuQua.TextChanged += new EventHandler(TextBoxes_TextChanged);
         
            txtKhoToChayCoTheIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
            
            txtQuiSoTrangA4.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongCB.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDayLoiNhuanCB.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDaySoLuongNiemYet.TextChanged += new EventHandler(TextBoxes_TextChanged);
           

            chkInTuTro.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);
            chkHPIndigo.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);
            chkKhongSuDung.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);   

            txtRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtCao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtVungInRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtVungInCao.KeyPress += new KeyPressEventHandler(InputValidator);
           
            txtQuiSoTrangA4.KeyPress += new KeyPressEventHandler(InputValidator);
                
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTocDoHieuQua.KeyPress += new KeyPressEventHandler(InputValidator);

        }
        QuanLyToInMayDigiPresenter quanLyMayPres;
        #region implementIView
        int _idToInMayDigi = 0;
        public int ID
        {
            get { if (lstToInDigi.SelectedValue != null)
                int.TryParse(lstToInDigi.SelectedValue.ToString(), out _idToInMayDigi) ;
            return _idToInMayDigi;
            }
            set { _idToInMayDigi = value;
            
            }
        }
        public string Ten
        {
            get
            {
                return txtTenMay.Text;
            }
            set
            {
                txtTenMay.Text = value;
            }
        }

        public float Rong
        {
            get
            {
                return float.Parse(txtRong.Text);
            }
            set
            {
                txtRong.Text = value.ToString();
            }
        }

        public float Cao
        {
            get
            {
                return float.Parse(txtCao.Text);
            }
            set
            {
                txtCao.Text = value.ToString();
            }
        }

        public float VungInRong
        {
            get
            {
                return float.Parse(txtVungInRong.Text);
            }
            set
            {
                txtVungInRong.Text = value.ToString();
            }
        }

        public float VungInCao
        {
            get
            {
                return float.Parse(txtVungInCao.Text);
            }
            set
            {
                txtVungInCao.Text = value.ToString();
            }
        }

        public int TocDo
        {
            get
            {
                return int.Parse(txtTocDoHieuQua.Text);
            }
            set
            {
                txtTocDoHieuQua.Text = value.ToString();
            }
        }
       
        int _idMayInDigi;
        public int IdMayInDigi
        {
            get { 
                if (cboMayIn.SelectedValue != null)
                    int.TryParse(cboMayIn.SelectedValue.ToString(), out _idMayInDigi);
                return _idMayInDigi;
            }
            set
            {
                _idMayInDigi = value;
                cboMayIn.SelectedValue = _idMayInDigi;
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
        public string KhoToChayCoTheIn
        {
            get
            {
                return txtKhoToChayCoTheIn.Text;
            }
            set
            {
                txtKhoToChayCoTheIn.Text = value;
            }
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

        public bool InTuTro
        {
            get
            {
                return chkInTuTro.Checked;
            }
            set
            {
                chkInTuTro.Checked = value;
            }
        }

        public bool HPIndigo
        {
            get
            {
                return chkHPIndigo.Checked;
            }
            set
            {
                chkHPIndigo.Checked = value;
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
        public int QuiSoTrangA4
        {
            get
            {
                return int.Parse(txtQuiSoTrangA4.Text);
            }
            set
            {
                txtQuiSoTrangA4.Text = value.ToString();
            }
        }
        #endregion
        private void LoadToInMayDiGi()
        {

            lstToInDigi.DataSource = quanLyMayPres.ToInMayDigiS();
            lstToInDigi.ValueMember = "ID";
            lstToInDigi.DisplayMember = "Ten";
           
            //Binding bindSource = new Binding("MayInDigi", nguon, "ID");
            
            
        }
        private void LoadMayIn()
        {

            cboMayIn.DataSource = quanLyMayPres.MayInDigiS();
            cboMayIn.ValueMember = "ID";
            cboMayIn.DisplayMember = "Ten";

            //Binding bindSource = new Binding("MayInDigi", nguon, "ID");


        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTenMay.ReadOnly = readOnly;
            txtRong.ReadOnly = readOnly;
            txtCao.ReadOnly = readOnly;
            txtVungInRong.ReadOnly = readOnly;
            txtVungInCao.ReadOnly = readOnly;
            
            txtTocDoHieuQua.ReadOnly = readOnly;
          
            txtKhoToChayCoTheIn.IsReadOnly = readOnly;
            txtQuiSoTrangA4.ReadOnly = readOnly;                        
            txtDaySoLuongCB.IsReadOnly = readOnly;
            txtDayLoiNhuanCB.IsReadOnly = readOnly;
            txtDaySoLuongNiemYet.ReadOnly = readOnly;
            txtThuTu.ReadOnly = readOnly;
          
            cboMayIn.ReadOnly = readOnly;
            chkKhongSuDung.ReadOnly = readOnly;
            chkHPIndigo.ReadOnly = readOnly;
            chkInTuTro.ReadOnly = readOnly;
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyMayPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTenMay || tb == txtRong ||
                    tb == txtCao || tb == txtVungInRong ||
                    tb == txtVungInCao ||
                    tb == txtTocDoHieuQua ||
                    tb == txtQuiSoTrangA4 || tb == txtThuTu
                  )
                {
                    this.DataChanged = true;

                }
            }
            Telerik.WinControls.UI.RadTextBoxControl tbc;
            if (sender is Telerik.WinControls.UI.RadTextBoxControl)
            {
                tbc = (Telerik.WinControls.UI.RadTextBoxControl)sender;

                if (tbc == txtKhoToChayCoTheIn || tbc == txtDaySoLuongCB ||
                    tbc == txtDayLoiNhuanCB)
                {
                    this.DataChanged = true;
                }

                Telerik.WinControls.UI.RadCheckBox ch;
                if (sender is Telerik.WinControls.UI.RadCheckBox)
                {
                    ch = (Telerik.WinControls.UI.RadCheckBox)sender;
                    if (ch == chkHPIndigo || ch == chkInTuTro ||
                        ch == chkKhongSuDung)
                        this.DataChanged = true;
                }
               

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
                if (tb == txtTocDoHieuQua || tb == txtThuTu ||
                    tb == txtQuiSoTrangA4 )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
                if (tb == txtRong || tb == txtCao ||
                    tb == txtVungInRong || tb == txtVungInCao)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
                //Xử lý xóa hêt
                if (tb == txtTocDoHieuQua)
                    if (string.IsNullOrEmpty(txtTocDoHieuQua.Text.Trim()))
                        txtTocDoHieuQua.Text = "1";
               

               
                if (tb == txtQuiSoTrangA4)
                    if (string.IsNullOrEmpty(txtQuiSoTrangA4.Text.Trim()))
                        txtQuiSoTrangA4.Text = "1";
                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        txtThuTu.Text = "0";
                if (tb == txtRong)
                    if (string.IsNullOrEmpty(txtRong.Text.Trim()))
                        txtRong.Text = "1";
                if (tb == txtCao)
                    if (string.IsNullOrEmpty(txtCao.Text.Trim()))
                        txtCao.Text = "1";
                if (tb == txtVungInRong)
                    if (string.IsNullOrEmpty(txtVungInRong.Text.Trim()))
                        txtVungInRong.Text = "1";
                if (tb == txtVungInCao)
                    if (string.IsNullOrEmpty(txtVungInCao.Text.Trim()))
                        txtRong.Text = "1";

            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu

            //Kiểm tra xong
            var thongDiep = "";
            quanLyMayPres.Luu(ref thongDiep);
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
            lstToInDigi.Enabled = true;
            LoadToInMayDiGi();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            lstToInDigi.Enabled = false;
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
            lstToInDigi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyMayPres.TrinhBayChiTietMayIn();
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
            lblIDToIn.Text = this.ID.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnDong.Enabled = true;
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            DatReadOnlyTextBox(true);
            quanLyMayPres.TrinhBayChiTietMayIn();
            lstToInDigi.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKiemTraDaySoluongLoiNhuan_Click(object sender, EventArgs e)
        {
            if (!quanLyMayPres.KiemTraDaySoLuongVaLoiNhuan())
                MessageBox.Show("Lỗi!");
            else
                MessageBox.Show("Đã khớp 2 số lượng! OK");
        }

        private void btnXemMayIn_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyMayInDigiForm(this.IdMayInDigi);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý máy in Digital";
            frm.ShowDialog();
        }




        
    }
}
