﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;


namespace TinhGiaInNhapLieu
{
    public partial class QuanLyLoXoDongCuonForm : Telerik.WinControls.UI.RadForm, IViewQuanLyLoXoDongCuon
    {

        public QuanLyLoXoDongCuonForm()
        {
            InitializeComponent();
            quanLyKhoPres = new QuanLyLoXoDongCuonPresenter(this);

            LoadEpKim();
           

            //Event
            txtTen_VongXoan.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtMaNhaCC.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtMauSac.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDienGiai.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGiaMuaCm2.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaMuaCm2.KeyPress += new KeyPressEventHandler(InputValidator);
            
        }
        QuanLyLoXoDongCuonPresenter quanLyKhoPres;
        #region implementIView
        int _idNhuEpKim = 0;
        public int ID
        {
            get { if (lstNhuEpKim.SelectedValue != null)
                int.TryParse(lstNhuEpKim.SelectedValue.ToString(), out _idNhuEpKim) ;
            return _idNhuEpKim;
            }
            set { _idNhuEpKim = value; }
        }
        public string Ten
        {
            get
            {
                return txtTen_VongXoan.Text;
            }
            set
            {
                txtTen_VongXoan.Text = value;
            }
        }

        public string MaNhaCungCap
        {
            get
            {
                return txtMaNhaCC.Text;
            }
            set
            {
                txtMaNhaCC.Text = value;
            }
        }

        public string TenNhaCungCap
        {
            get
            {
                return txtMauSac.Text;
            }
            set
            {
                txtMauSac.Text = value.ToString();
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

        public int GiaMuaCm2
        {
            get
            {
                return int.Parse(txtGiaMuaCm2.Text);
            }
            set
            {
                txtGiaMuaCm2.Text = value.ToString();
            }
        }
        int _idEpKim = 0;
        public int IdEpKim
        {
            get {
                if ( cboEpKim.SelectedValue != null)
                    int.TryParse(cboEpKim.SelectedValue.ToString(), out _idEpKim);
                return _idEpKim;
            }
            set
            {
                _idEpKim = value;
                if (_idEpKim >0)
                    cboEpKim.SelectedValue = value; 
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

     

        public TinhGiaInClient.FormStateS TinhTrangForm
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

        private void LoadEpKim()
        {

            cboEpKim.DataSource = quanLyKhoPres.EpKimS();
            cboEpKim.ValueMember = "ID";
            cboEpKim.DisplayMember = "Ten";
        }
        private void LoadNhuEpKim()
        {

            lstNhuEpKim.DataSource = quanLyKhoPres.NhuEpKimSTheoEpKim();
            lstNhuEpKim.ValueMember = "ID";
            lstNhuEpKim.DisplayMember = "Ten";
           
         
            
        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTen_VongXoan.ReadOnly = readOnly;
            txtMaNhaCC.ReadOnly = readOnly;
            txtMauSac.ReadOnly = readOnly;
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
                if (tb == txtTen_VongXoan || tb == txtMaNhaCC ||
                    tb == txtMauSac || tb == txtDienGiai ||
                   tb == txtThuTu || tb == txtGiaMuaCm2 )
                   
                {
                    this.DataChanged = true;
                   
                }
                //Xử lý  bị xóa hêt
                if (tb == txtMaNhaCC)
                    if (string.IsNullOrEmpty(txtMaNhaCC.Text.Trim()))
                        txtMaNhaCC.Text = "Mã";

                if (tb == txtMauSac)
                    if (string.IsNullOrEmpty(txtMauSac.Text.Trim()))
                        txtMauSac.Text = "NCC";

                if (tb == txtGiaMuaCm2)
                    if (string.IsNullOrEmpty(txtGiaMuaCm2.Text.Trim()))
                        txtGiaMuaCm2.Text = "1";
                
                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        txtThuTu.Text = "99";
               

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
                if ( tb == txtThuTu || tb == txtGiaMuaCm2 )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
                /*
                if (tb == txtMaNhaCC || tb == txtMaNhaCC )//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                } */


            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu

            //Kiểm tra xong
            MessageBox.Show(quanLyKhoPres.Luu());
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = TinhGiaInClient.FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);            
            cboEpKim.Enabled = true;
            lstNhuEpKim.Enabled = true;
            LoadEpKim();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = TinhGiaInClient.FormStateS.New;
            cboEpKim.Enabled = false;
            lstNhuEpKim.Enabled = false;
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
            this.TinhTrangForm = TinhGiaInClient.FormStateS.Edit;
            cboEpKim.Enabled = false;
            lstNhuEpKim.Enabled = false;
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
            cboEpKim.Enabled = true;
            lstNhuEpKim.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEpKim_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {           
            LoadNhuEpKim();
        }

        private void lstLoXo_ColumnCreating(object sender, Telerik.WinControls.UI.ListViewColumnCreatingEventArgs e)
        {
            if (e.Column.FieldName == "ID")
            {
                e.Column.HeaderText = "ID";
                e.Column.Width = 5;
                e.Column.MinWidth = 5;
            }

            if (e.Column.FieldName == "TenVongXoan")
            {
                e.Column.HeaderText = "Vòng xoắn";
            
                e.Column.Width = 90;
            }

            if (e.Column.FieldName == "KichCoBuoc")
            {
                e.Column.Width = 50;
                e.Column.HeaderText = "Kích cở Bước";
            }

            if (e.Column.FieldName == "MauSac")
            {
                e.Column.HeaderText = "Màu";
                e.Column.Width = 50;
            }

            if (e.Column.FieldName == "ChoDoDay")
            {
                e.Column.HeaderText = "Độ dày cuốn";
                e.Column.Width = 90;
            }

            if (e.Column.FieldName == "GiaMuaTheoMet")
            {
                e.Column.HeaderText = "Giá tồn kho";
                e.Column.Width = 50;
            }

            if (e.Column.FieldName == "ThuTu")
            {
                e.Column.HeaderText = "Thứ tự";
                e.Column.Width = 5;
                e.Column.MinWidth = 5;
            }
        }




        
    }
}
