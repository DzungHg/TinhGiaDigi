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
    public partial class QuanLyToBoiBiaCungForm : Telerik.WinControls.UI.RadForm, IViewQuanLyToBoiBiaCung
    {

        public QuanLyToBoiBiaCungForm()
        {
            InitializeComponent();
            quanLyToBoiBCPres = new QuanLyToBoiBiaCungPresenter(this);

            LoadToBoi();
            

            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDoDayCm.TextChanged += new EventHandler(TextBoxes_TextChanged);          
            txtGiaMuaTam.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtTen.Leave += new EventHandler(TextBoxes_Leave);
            txtDoDayCm.Leave += new EventHandler(TextBoxes_Leave);
            txtGiaMuaTam.Leave += new EventHandler(TextBoxes_Leave);
            txtThuTu.Leave += new EventHandler(TextBoxes_Leave);

            lstToBoiBiaCung.SelectedIndexChanged += new EventHandler(ListViews_SelectedIndexChanged);

            txtDoDayCm.KeyPress += new KeyPressEventHandler(InputValidator);
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaMuaTam.KeyPress += new KeyPressEventHandler(InputValidator);
            
        }
        QuanLyToBoiBiaCungPresenter quanLyToBoiBCPres;
        #region implementIView
        int _idToBoi = 0;
        public int ID
        {
            get { 
                if (lstToBoiBiaCung.SelectedItems.Count > 0)
                {
                    var item = (ToBoiBiaCung)lstToBoiBiaCung.SelectedItems[0].DataBoundItem;
                    _idToBoi = item.ID;
                }
            return _idToBoi;
            }
            set { _idToBoi = value; }
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

        public float DoDayCm
        {
            get
            {
                return float.Parse(txtDoDayCm.Text);
            }
            set
            {
                txtDoDayCm.Text = value.ToString();
            }
        }




        public int GiaMuaTheoTam
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

    
        private void LoadToBoi()
        {

            lstToBoiBiaCung.DataSource = quanLyToBoiBCPres.LoXoToBoiS();
            lstToBoiBiaCung.ValueMember = "ID";
            lstToBoiBiaCung.DisplayMember = "Ten";
           
         
            
        }
        private void DatReadOnlyTextBox(bool readOnly)
        {
            txtTen.ReadOnly = readOnly;
            txtDoDayCm.ReadOnly = readOnly;
            txtGiaMuaTam.ReadOnly = readOnly;            
            txtThuTu.ReadOnly = readOnly;
        }
        private void XoaSachNoiDungTatCaTextBox()
        {
            quanLyToBoiBCPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTen || tb == txtDoDayCm ||                   
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
                if (tb == txtDoDayCm)
                    if (string.IsNullOrEmpty(txtDoDayCm.Text.Trim()))
                        this.DoDayCm = 0.3f;


                if (tb == txtGiaMuaTam)
                    if (string.IsNullOrEmpty(txtGiaMuaTam.Text.Trim()))
                        this.GiaMuaTheoTam = 1000;

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
               
                if (tb == txtDoDayCm )//nhập được số thập phân 
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
            MessageBox.Show(quanLyToBoiBCPres.Luu());
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            DatReadOnlyTextBox(true);            
            
            lstToBoiBiaCung.Enabled = true;
            LoadToBoi();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.New;
            
            lstToBoiBiaCung.Enabled = false;
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
            lstToBoiBiaCung.SelectedIndex = -1;
            lstToBoiBiaCung.SelectedIndex = 0;
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
          
            lstToBoiBiaCung.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            DatReadOnlyTextBox(false);
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            quanLyToBoiBCPres.TrinhBayToBoi();
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
            quanLyToBoiBCPres.TrinhBayToBoi();
           
            lstToBoiBiaCung.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEpKim_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {           
            LoadToBoi();
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

            if (e.Column.FieldName == "DoDayCm")
            {
                e.Column.Width = 50;
                e.Column.HeaderText = "Độ dày";
                e.Column.MinWidth = 30;
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
            quanLyToBoiBCPres.TrinhBayToBoi();

        }




       
    }
}
