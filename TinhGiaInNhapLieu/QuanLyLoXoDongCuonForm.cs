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
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu
{
    public partial class QuanLyLoXoDongCuonForm : Telerik.WinControls.UI.RadForm, IViewQuanLyLoXoDongCuon
    {

        public QuanLyLoXoDongCuonForm()
        {
            InitializeComponent();
            quanLyKhoPres = new QuanLyLoXoDongCuonPresenter(this);

            LoadLoXo();
           

            //Event
            txtTen_VongXoan.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtKichCoBuoc.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtMauSac.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtChoDoDay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGiaMuaMet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);

            lstLoXo.SelectedIndexChanged += new EventHandler(ListViews_SelectedIndexChanged);

            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaMuaMet.KeyPress += new KeyPressEventHandler(InputValidator);
            
        }
        QuanLyLoXoDongCuonPresenter quanLyKhoPres;
        #region implementIView
        int _idNhuEpKim = 0;
        public int ID
        {
            get { 
                if (lstLoXo.SelectedItems.Count > 0)
                {
                    var item = (LoXoDongCuon)lstLoXo.SelectedItems[0].DataBoundItem;
                    _idNhuEpKim = item.ID;
                }
            return _idNhuEpKim;
            }
            set { _idNhuEpKim = value; }
        }
        public string Ten_VongXoan
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

        public string KichCoBuoc
        {
            get
            {
                return txtKichCoBuoc.Text;
            }
            set
            {
                txtKichCoBuoc.Text = value;
            }
        }

        public string MauSac
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

        public string ChoDoDay
        {
            get
            {
                return txtChoDoDay.Text;
            }
            set
            {
                txtChoDoDay.Text = value;
            }
        }     

        public int GiaMuaTheoMet
        {
            get
            {
                return int.Parse(txtGiaMuaMet.Text);
            }
            set
            {
                txtGiaMuaMet.Text = value.ToString();
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

    
        private void LoadLoXo()
        {

            lstLoXo.DataSource = quanLyKhoPres.LoXoDongCuonS();
            lstLoXo.ValueMember = "ID";
            lstLoXo.DisplayMember = "TenVongXoan";
           
         
            
        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTen_VongXoan.ReadOnly = readOnly;
            txtKichCoBuoc.ReadOnly = readOnly;
            txtMauSac.ReadOnly = readOnly;
            txtChoDoDay.ReadOnly = readOnly;
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
                if (tb == txtTen_VongXoan || tb == txtKichCoBuoc ||
                    tb == txtMauSac || tb == txtChoDoDay ||
                   tb == txtThuTu || tb == txtGiaMuaMet )
                   
                {
                    this.DataChanged = true;
                   
                }
                //Xử lý  bị xóa hêt
                if (tb == txtKichCoBuoc)
                    if (string.IsNullOrEmpty(txtKichCoBuoc.Text.Trim()))
                        txtKichCoBuoc.Text = "xx";

                if (tb == txtMauSac)
                    if (string.IsNullOrEmpty(txtMauSac.Text.Trim()))
                        txtMauSac.Text = "Trắng";

                if (tb == txtGiaMuaMet)
                    if (string.IsNullOrEmpty(txtGiaMuaMet.Text.Trim()))
                        txtGiaMuaMet.Text = "1";
                
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
                if ( tb == txtThuTu || tb == txtGiaMuaMet )//chỉ được nhập số chẵn 
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
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);            
            
            lstLoXo.Enabled = true;
            LoadLoXo();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            
            lstLoXo.Enabled = false;
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
            //Bẩy:
            lstLoXo.SelectedIndex = -1;
            lstLoXo.SelectedIndex = 0;
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
          
            lstLoXo.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyKhoPres.TrinhBayLoXo();
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
            quanLyKhoPres.TrinhBayLoXo();
           
            lstLoXo.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEpKim_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {           
            LoadLoXo();
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
            
                e.Column.Width = 150;
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
                e.Column.Width = 15;
                e.Column.MinWidth = 15;
            }
        }
        private void ListViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            quanLyKhoPres.TrinhBayLoXo();

        }

        private void lstLoXo_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        
    }
}
