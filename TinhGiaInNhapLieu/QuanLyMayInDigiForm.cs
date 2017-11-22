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
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInNhapLieu
{
    public partial class QuanLyMayInDigiForm : Telerik.WinControls.UI.RadForm, IViewQuanLyMayInDigi
    {

        public QuanLyMayInDigiForm(int idMayInDigi = 0)
        {
            InitializeComponent();
            quanLyMayPres = new QuanLyMayInDigiPresenter(this);
            LoadMayIn();
            if (idMayInDigi > 0) //lấy mã từ ngoài
            {
                lstMayIn.SelectedValue = idMayInDigi;
            }
            else
            {
                lstMayIn.SelectedIndex = -1;
                lstMayIn.SelectedIndex = 0;
            }
            //Event
            txtTenMay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtKhoInMin.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtKhoInMax.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThongTinTocDo.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTocDoHieuQua.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtBHR.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtPhiPhePhamSanSang.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThoiGianSanSang.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtClickA4_4M.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtClickA4_1M.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtClickA4_6M.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtBHR.KeyPress += new KeyPressEventHandler(InputValidator);
            txtClickA4_1M.KeyPress += new KeyPressEventHandler(InputValidator);
            txtClickA4_4M.KeyPress += new KeyPressEventHandler(InputValidator);
            txtClickA4_6M.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiPhePhamSanSang.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThoiGianSanSang.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTocDoHieuQua.KeyPress += new KeyPressEventHandler(InputValidator);
        }
        QuanLyMayInDigiPresenter quanLyMayPres;
        #region implementIView
        int _idMayIn = 0;
        public int ID
        {
            get { if (lstMayIn.SelectedValue != null)
                int.TryParse(lstMayIn.SelectedValue.ToString(), out _idMayIn) ;
            return _idMayIn;
            }
            set { _idMayIn = value; }
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

        public string KhoInMin
        {
            get
            {
                return txtKhoInMin.Text;
            }
            set
            {
                txtKhoInMin.Text = value;
            }
        }

        public string KhoInMax
        {
            get
            {
                return txtKhoInMax.Text;
            }
            set
            {
                txtKhoInMax.Text = value;
            }
        }

        public string ThongTinTocDo
        {
            get
            {
                return txtThongTinTocDo.Text;
            }
            set
            {
                txtThongTinTocDo.Text = value;
            }
        }

        public int TocDoHieuQua
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

        public int PhiPhePhamSanSang
        {
            get
            {
                return int.Parse(txtPhiPhePhamSanSang.Text);
            }
            set
            {
                txtPhiPhePhamSanSang.Text = value.ToString();
            }
        }

        public float ThoiGianSanSang
        {
            get
            {
                return float.Parse(txtThoiGianSanSang.Text);
            }
            set
            {
                txtThoiGianSanSang.Text = value.ToString();
            }
        }

        public int ClickA4_4M
        {
            get
            {
                return int.Parse(txtClickA4_4M.Text);
            }
            set
            {
                txtClickA4_4M.Text = value.ToString();
            }
        }

        public int ClickA4_1M
        {
            get
            {
                return int.Parse(txtClickA4_1M.Text);
            }
            set
            {
                txtClickA4_1M.Text = value.ToString();
            }
        }

        public int ClickA4_6M
        {
            get
            {
                return int.Parse(txtClickA4_6M.Text);
            }
            set
            {
                txtClickA4_6M.Text = value.ToString();
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
        #endregion
        private void LoadMayIn()
        {

            lstMayIn.DataSource = quanLyMayPres.MayInDigiS();
            lstMayIn.ValueMember = "ID";
            lstMayIn.DisplayMember = "Ten";
           
            //Binding bindSource = new Binding("MayInDigi", nguon, "ID");
            
            
        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTenMay.ReadOnly = readOnly;
            txtKhoInMin.ReadOnly = readOnly;
            txtKhoInMax.ReadOnly = readOnly;
            txtThongTinTocDo.ReadOnly = readOnly;
            txtTocDoHieuQua.ReadOnly = readOnly;
            txtBHR.ReadOnly = readOnly;
            txtPhiPhePhamSanSang.ReadOnly = readOnly;
            txtThoiGianSanSang.ReadOnly = readOnly;
            txtClickA4_4M.ReadOnly = readOnly;
            txtClickA4_1M.ReadOnly = readOnly;
            txtClickA4_6M.ReadOnly = readOnly;
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
                if (tb == txtTenMay || tb == txtKhoInMin ||
                    tb == txtKhoInMax || tb == txtThongTinTocDo ||
                    tb == txtTocDoHieuQua || tb == txtBHR ||
                    tb == txtPhiPhePhamSanSang || tb == txtThoiGianSanSang ||
                    tb == txtClickA4_4M || tb == txtClickA4_1M ||
                    tb == txtClickA4_6M)
                {
                    this.DataChanged = true;
                   
                }
                //Xử lý xóa hêt
                if (tb == txtTocDoHieuQua)                
                    if (string.IsNullOrEmpty(txtTocDoHieuQua.Text.Trim()))
                        txtTocDoHieuQua.Text = "1";
                
                if (tb == txtClickA4_1M)
                    if (string.IsNullOrEmpty(txtClickA4_1M.Text.Trim()))
                        txtClickA4_1M.Text = "0";
                if (tb == txtClickA4_4M)
                    if (string.IsNullOrEmpty(txtClickA4_4M.Text.Trim()))
                        txtClickA4_4M.Text = "0";
                if (tb == txtClickA4_6M)
                    if (string.IsNullOrEmpty(txtClickA4_6M.Text.Trim()))
                        txtClickA4_6M.Text = "0";

                if (tb == txtBHR)
                    if (string.IsNullOrEmpty(txtBHR.Text.Trim()))
                        txtBHR.Text = "1";
                if (tb == txtThoiGianSanSang)
                    if (string.IsNullOrEmpty(txtThoiGianSanSang.Text.Trim()))
                        txtThoiGianSanSang.Text = "0";
                if (tb == txtPhiPhePhamSanSang)
                    if (string.IsNullOrEmpty(txtPhiPhePhamSanSang.Text.Trim()))
                        txtPhiPhePhamSanSang.Text = "0";

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
                if (tb == txtBHR || tb == txtClickA4_1M ||
                    tb == txtClickA4_4M || tb == txtClickA4_6M ||
                    tb == txtTocDoHieuQua)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
                if (tb == txtThoiGianSanSang)//nhập được số thập phân 
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
            quanLyMayPres.Luu();
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
            lstMayIn.Enabled = true;
            LoadMayIn();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            lstMayIn.Enabled = false;
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
            lstMayIn.Enabled = false;
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
            lstMayIn.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
