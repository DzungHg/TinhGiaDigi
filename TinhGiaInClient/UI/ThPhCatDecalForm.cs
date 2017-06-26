using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.UI
{
    public partial class ThPhCatDecalForm : Telerik.WinControls.UI.RadForm, IViewThPhCatDecal
    {
        ThPhCatDecalPresenter thPhMoPhangPres;
        public ThPhCatDecalForm(ThongTinBanDauDongCuon thongTinBanDau, MucThPhCatDecal mucThPhCatDecal)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
           
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;
            txtSoLuong.Enabled = thongTinBanDau.MoTextSoLuongCuon;


            thPhMoPhangPres = new ThPhCatDecalPresenter(this, mucThPhCatDecal);
            LoadMayThanhPham();
            cboMayThPh.SelectedIndex = -1;
            cboMayThPh.SelectedIndex = 0;
            //Load Nhu ep
            LoadToLot();
            
            //Load
            
            //Mục này phải làm ở đây
            if (this.TinhTrangForm == FormStateS.Edit ||
                this.IdThanhPhamChon > 0)
            {
                this.IdThanhPhamChon = mucThPhCatDecal.IdThanhPhamChon;
               
                
            }
            //Envent

            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);           
            txtConRong.TextChanged += new EventHandler(TextBoxes_TextChanged);


            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtConRong.KeyPress += new KeyPressEventHandler(InputValidator);


           

            cboMayThPh.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(DropDownList_SelectedIndexChanged);

           
            
        }
        #region Implement Iview
        public int ID { get; set; }
        public int IdBaiIn { get; set; }

        public int IdHangKhachHang
        {
            get;
            set;
        }

        public string ThongTinHangKH
        {
            get { return thPhMoPhangPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", thPhMoPhangPres.TyLeMarkUp()); }
        }
         public int SoLuong
        {
            get
            {
                return int.Parse(txtSoLuong.Text);
            }
            set
            {
                txtSoLuong.Text = value.ToString();
            }
        }
         public string DonViTinh
         {
             get
             {
                 return txtDonViTinh.Text ;
             }
             set
             {
                 txtDonViTinh.Text = value;
             }
         }
         int _idThanhPhamChon = 0;
        public int IdThanhPhamChon
         {
             get {
                 if (cboMayThPh.SelectedValue != null)
                     int.TryParse(cboMayThPh.SelectedValue.ToString(), out _idThanhPhamChon);
                 return _idThanhPhamChon; 
             }
             set { cboMayThPh.SelectedValue = value; }
         }
       
        public string TenThanhPhamChon //là ép kim
        {
            get { return cboMayThPh.Text; }
            set {cboMayThPh.Text = value;}
        }
       
       
        public decimal ThanhTien
        {
            get { return thPhMoPhangPres.ThanhTien_ThPh(); }
            set { ;}
        }


        public LoaiThanhPhamS LoaiThPh
        {
            get;
            set;
        }
       
        public string ThongTinHoTro
        {
            get { return txtThongTinHoTro.Text; }
            set { txtThongTinHoTro.Text = value; }
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }
       //Bổ sung thêm
     
       

     
       

        public int ConRong
        {
            get
            {
                return int.Parse(txtConRong.Text);
            }
            set
            {
                txtConRong.Text = value.ToString();
            }
        }
        public int ConCao
        {
            get
            {
                return int.Parse(txtConCao.Text);
            }
            set
            {
                txtConCao.Text = value.ToString();
            }
        }

      
        #endregion

        private void LoadMayThanhPham()
        {
            //Cán phủ
            cboMayThPh.DataSource = thPhMoPhangPres.ThanhPhamS();
            cboMayThPh.ValueMember = "ID";
            cboMayThPh.DisplayMember = "Ten";
         
        }
       
       

        private void txtSoLuong_CanPhu_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoLuong )
                {
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "1";
                    
                }
                //xử lý khi user xóa hết
                if ( tb == txtConRong)
                    if (string.IsNullOrEmpty(txtConRong.Text.Trim()))
                        txtConRong.Text = "10";

                CapNhatLabelGia();
            
            }
            /*Telerik.WinControls.UI.RadListView lv;
            if (sender is Telerik.WinControls.UI.RadListView)
            {
                lv = (Telerik.WinControls.UI.RadListView)sender;
                if (lv == lstLoXo)
                {
                    txtSoLuong.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    CapNhatLabelGia();
                }
            }*/
           
        }
        private void CapNhatLabelGia()
        {
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", thPhMoPhangPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", thPhMoPhangPres.GiaTB_ThPh(), this.DonViTinh);
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                
                if (t == txtSoLuong || t == txtConRong )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
               /* if (t == txtGayDay)// được số lẻ
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }*/
            }
            
        }
        
        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            lblTieuDeForm.Text = this.Text;
            if (this.SoLuong > 1) //bẩy cập nhật tính toán
            {
                SoLuong -= 1;
                SoLuong += 1;
            }
            
            txtDonViTinh.Enabled = false;
            if (this.IdThanhPhamChon > 0)
            {
                btnNhan.Enabled = true;
            }
            
            if (this.TinhTrangForm == FormStateS.View)
            {
                
                
                btnNhan.Enabled = true;
            }
            
        }

        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
            
            if (string.IsNullOrEmpty(txtSoLuong.Text))
                loiS.Add("Số lượng rỗng");
            if (string.IsNullOrEmpty(txtDonViTinh.Text))
                loiS.Add("Đơn vị tính");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void ThPhCanPhuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string ms = "";
                if (!KiemTraHopLe(ref ms))
                {
                    var dialogeR = MessageBox.Show(ms, "Dữ liệu điền chưa chuẩn đó! Điền tiếp?",
                         MessageBoxButtons.YesNo);
                    if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                        e.Cancel = true;
                    else

                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void cboEpKim_SelectedIndexChanged(object sender, EventArgs e)
        {           
           
        }

        private void TextBoxes_Leave(object sender, EventArgs e)
        {

        }

        private void lstNhuEpKim_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = true;
            txtDonViTinh.Enabled = true;
            btnNhan.Enabled = true;
            CapNhatLabelGia();
        }
        public MucThanhPham LayMucThanhPham()
        {
            return thPhMoPhangPres.LayMucThanhPham();
        }

        private void cboMayLoXo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void lstMoPhang_ColumnCreating(object sender, Telerik.WinControls.UI.ListViewColumnCreatingEventArgs e)
        {
            /*
            public int ID { get; set; }
        public string Ten { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DienGiai { get; set; }
        public int GiaMuaTo { get; set; }
        public int ThuTu { get; set; }*/

            if (e.Column.FieldName == "ID")
            {
                e.Column.HeaderText = "ID";
                e.Column.Width = 5;
                e.Column.MinWidth = 5;
            }

            if (e.Column.FieldName == "Ten")
            {
                e.Column.HeaderText = "Tên";
            
                e.Column.Width = 120;
            }

            if (e.Column.FieldName == "DienGiai")
            {
                e.Column.Width = 150;
                e.Column.HeaderText = "Diễu giải";
            }

            if (e.Column.FieldName == "MaNhaCungCap")
            {
                e.Column.Visible = false;
            }

            if (e.Column.FieldName == "TenNhaCungCap")
            {
                e.Column.Visible = false;
            }

            if (e.Column.FieldName == "GiaMuaTo")
            {
                e.Column.Visible = false;
            }

            if (e.Column.FieldName == "ThuTu")
            {
                e.Column.HeaderText = "Thứ tự";
                e.Column.Width = 5;
                e.Column.MinWidth = 5;
            }

           
        }
        private void ListView_SelectedItemChanged(object sender, EventArgs e)
        {

            CapNhatLabelGia();

        }
        private void DropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Telerik.WinControls.UI.RadDropDownList cb;
            if (sender is Telerik.WinControls.UI.RadDropDownList)
            {
                cb = (Telerik.WinControls.UI.RadDropDownList)sender;
                if (cb == cboMayThPh)
                {
                    CapNhatLabelGia();
                }

            }
        }

        
    }
}
