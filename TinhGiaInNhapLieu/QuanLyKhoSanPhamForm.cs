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
    public partial class QuanLyKhoSanPhamForm : Telerik.WinControls.UI.RadForm, IViewQuanLyKhoSanPham
    {

        public QuanLyKhoSanPhamForm(int idKhoSanPham = 0)
        {
            InitializeComponent();
            quanLyKhoPres = new QuanLyKhoSanPhamPresenter(this);
            LoadKhoSanPham();
            if (idKhoSanPham > 0) //lấy mã từ ngoài
            {
                lstKhoSanPham.SelectedValue = idKhoSanPham;
            }
            else
            {
                lstKhoSanPham.SelectedIndex = -1;
                lstKhoSanPham.SelectedIndex = 0;
            }
            //Event
            txtTenMay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtKhoCatRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtKhoCatCao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDienGiai.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtKhoCatRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtKhoCatCao.KeyPress += new KeyPressEventHandler(InputValidator);
        }
        QuanLyKhoSanPhamPresenter quanLyKhoPres;
        #region implementIView
        int _idKhoSP = 0;
        public int ID
        {
            get { if (lstKhoSanPham.SelectedValue != null)
                int.TryParse(lstKhoSanPham.SelectedValue.ToString(), out _idKhoSP) ;
            return _idKhoSP;
            }
            set { _idKhoSP = value; }
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

        public float KhoCatRong
        {
            get
            {
                return float.Parse(txtKhoCatRong.Text);
            }
            set
            {
                txtKhoCatRong.Text = value.ToString();
            }
        }

        public float KhoCatCao
        {
            get
            {
                return float.Parse(txtKhoCatCao.Text);
            }
            set
            {
                txtKhoCatCao.Text = value.ToString();
            }
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
        #endregion
        private void LoadKhoSanPham()
        {

            lstKhoSanPham.DataSource = quanLyKhoPres.KhoSanPhamS();
            lstKhoSanPham.ValueMember = "ID";
            lstKhoSanPham.DisplayMember = "Ten";
           
            //Binding bindSource = new Binding("MayInDigi", nguon, "ID");
            
            
        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTenMay.ReadOnly = readOnly;
            txtKhoCatRong.ReadOnly = readOnly;
            txtKhoCatCao.ReadOnly = readOnly;
            txtDienGiai.ReadOnly = readOnly;
            txtThuTu.ReadOnly = readOnly;
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyKhoPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTenMay || tb == txtKhoCatRong ||
                    tb == txtKhoCatCao || tb == txtDienGiai ||
                   tb == txtThuTu )
                   
                {
                    this.DataChanged = true;
                   
                }
                //Xử lý  bị xóa hêt
                if (tb == txtKhoCatRong)
                    if (string.IsNullOrEmpty(txtKhoCatRong.Text.Trim()))
                        txtKhoCatRong.Text = "0";

                if (tb == txtKhoCatCao)
                    if (string.IsNullOrEmpty(txtKhoCatCao.Text.Trim()))
                        txtKhoCatCao.Text = "0";
                
                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        txtThuTu.Text = "0";
               

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
                if ( tb == txtThuTu )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
                if (tb == txtKhoCatRong || tb == txtKhoCatRong )//nhập được số thập phân 
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
            quanLyKhoPres.Luu();
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);
            lstKhoSanPham.Enabled = true;
            LoadKhoSanPham();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            lstKhoSanPham.Enabled = false;
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
            lstKhoSanPham.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyKhoPres.TrinhBayChiTietMayIn();
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
            quanLyKhoPres.TrinhBayChiTietMayIn();
            lstKhoSanPham.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
