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
using TinhGiaInClient.Model;


namespace TinhGiaInNhapLieu
{
    public partial class QuanLyToLotDCMPForm : Telerik.WinControls.UI.RadForm, IViewQuanLyToLotDCMP
    {

        public QuanLyToLotDCMPForm()
        {
            InitializeComponent();
            quanLyToLotPres = new QuanLyToLotDCMPPresenter(this);

            LoadToLot();
            

            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtMaNCC.TextChanged += new EventHandler(TextBoxes_TextChanged);          
            txtGiaMuaTam.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDienGiai.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtTen.Leave += new EventHandler(TextBoxes_Leave);
            txtMaNCC.Leave += new EventHandler(TextBoxes_Leave);
            txtGiaMuaTam.Leave += new EventHandler(TextBoxes_Leave);
            txtThuTu.Leave += new EventHandler(TextBoxes_Leave);

            lstToLotDCMP.SelectedIndexChanged += new EventHandler(ListViews_SelectedIndexChanged);

           
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaMuaTam.KeyPress += new KeyPressEventHandler(InputValidator);
            
        }
        QuanLyToLotDCMPPresenter quanLyToLotPres;
        #region implementIView
        int _idToLot = 0;
        public int ID
        {
            get { 
                if (lstToLotDCMP.SelectedItems.Count > 0)
                {
                    var item = (ToLotMoPhang)lstToLotDCMP.SelectedItems[0].DataBoundItem;
                    _idToLot = item.ID;
                }
            return _idToLot;
            }
            set { _idToLot = value; }
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

        public string MaNhaCungCap
        {
            get
            {
                return txtMaNCC.Text;
            }
            set
            {
                txtMaNCC.Text = value;
            }
        }
        public string TenNhaCungCap
        {
            get
            {
                return txtTenNhaCC.Text;
            }
            set
            {
                txtTenNhaCC.Text = value;
            }
        }




        public int GiaMuaTo
        {
            get
            {
                return int.Parse(txtGiaMuaTam.Text);
            }
            set
            {
                txtGiaMuaTam.Text = value.ToString();
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

    
        private void LoadToLot()
        {

            lstToLotDCMP.DataSource = quanLyToLotPres.LoXoDongCuonS();
            lstToLotDCMP.ValueMember = "ID";
            lstToLotDCMP.DisplayMember = "Ten";
           
         
            
        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTen.ReadOnly = readOnly;
            txtMaNCC.ReadOnly = readOnly;
            txtGiaMuaTam.ReadOnly = readOnly;            
            txtThuTu.ReadOnly = readOnly;
            txtTenNhaCC.ReadOnly = readOnly;
            txtDienGiai.ReadOnly = readOnly;
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyToLotPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTen || tb == txtMaNCC || 
                    tb == txtTenNhaCC || tb == txtDienGiai ||
                   tb == txtThuTu || tb == txtGiaMuaTam )
                   
                {
                    this.DataChanged = true;
                   
                }
               
               

            }
            btnLuu.Enabled = this.DataChanged;      
        }

        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;

                //Xử lý  bị xóa hêt                

                if (tb == txtGiaMuaTam)
                    if (string.IsNullOrEmpty(txtGiaMuaTam.Text.Trim()))
                        this.GiaMuaTo = 1000;

                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        this.ThuTu = 99;
            }
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if ( tb == txtThuTu || tb == txtGiaMuaTam )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
               
                if (tb == txtMaNCC )//nhập được số thập phân 
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
            MessageBox.Show(quanLyToLotPres.Luu());
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);            
            
            lstToLotDCMP.Enabled = true;
            LoadToLot();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            
            lstToLotDCMP.Enabled = false;
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
            //Bẩy
            lstToLotDCMP.SelectedIndex = -1;
            lstToLotDCMP.SelectedIndex = 0;
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
          
            lstToLotDCMP.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyToLotPres.TrinhBayToBoi();
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
            quanLyToLotPres.TrinhBayToBoi();
           
            lstToLotDCMP.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEpKim_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {           
            LoadToLot();
        }

        private void lstLoXo_ColumnCreating(object sender, Telerik.WinControls.UI.ListViewColumnCreatingEventArgs e)
        {
            if (e.Column.FieldName == "ID")
            {
                e.Column.HeaderText = "ID";
                e.Column.Width = 5;
                e.Column.MinWidth = 5;
            }

            if (e.Column.FieldName == "Ten")
            {
                e.Column.HeaderText = "Tên";
                e.Column.Width = 150;
                e.Column.MinWidth = 100;
            }

            if (e.Column.FieldName == "DienGiai")
            {
                e.Column.Width = 150;
                e.Column.HeaderText = "Diễn giải";
                e.Column.MinWidth = 150;
            }
            if (e.Column.FieldName == "MaNhaCungCap")
            {
                e.Column.Width = 50;
                e.Column.HeaderText = "MaNhaCungCap";
                e.Column.MinWidth = 50;
            }
            if (e.Column.FieldName == "TenNhaCungCap")
            {
                e.Column.Width = 50;
                e.Column.HeaderText = "TenNhaCungCap";
                e.Column.MinWidth = 50;
            }

            if (e.Column.FieldName == "GiaMuaTo")
            {
                e.Column.HeaderText = "Giá mua";
                e.Column.Width = 50;
                e.Column.MinWidth = 20;
            }

            if (e.Column.FieldName == "ThuTu")
            {
                e.Column.HeaderText = "Thứ tự";
                e.Column.Width = 20;
                e.Column.MinWidth = 5;
            }
        }
        private void ListViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            quanLyToLotPres.TrinhBayToBoi();

        }

        private void lstToLotDCMP_SelectedItemChanged(object sender, EventArgs e)
        {

        }




       
    }
}
