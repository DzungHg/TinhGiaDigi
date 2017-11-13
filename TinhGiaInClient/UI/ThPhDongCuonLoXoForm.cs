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
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.UI
{
    public partial class ThPhDongCuonLoXoForm : Telerik.WinControls.UI.RadForm, IViewThPhDongCuonLoXo
    {
        ThPhDongCuonLoXoPresenter thPhLoXoPres;
        public ThPhDongCuonLoXoForm(ThongTinBanDauDongCuon thongTinBanDau, MucDongCuonLoXo mucThPhamDongCuon)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
           
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;
            txtSoLuong.Enabled = thongTinBanDau.MoTextSoLuongCuon;
          

            thPhLoXoPres = new ThPhDongCuonLoXoPresenter(this, mucThPhamDongCuon);
            LoadDongCuonLoXo();
            cboMayLoXo.SelectedIndex = -1;
            cboMayLoXo.SelectedIndex = 0;
            //Load Nhu ep
            LoadLoXoDongCuon();
            
            //Load
            
            //Mục này phải làm ở đây
            if (this.TinhTrangForm == FormStateS.Edit ||
                this.IdThanhPhamChon > 0)
            {
                this.IdThanhPhamChon = mucThPhamDongCuon.IdThanhPhamChon;
               
                this.IdLoXoDongCuonChon = mucThPhamDongCuon.IdLoXoChon;
            }
            //Envent
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGayDay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGayCao.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);
            txtGayDay.TextChanged += new EventHandler(TextBoxes_Leave);
            txtGayCao.TextChanged += new EventHandler(TextBoxes_Leave);

            lstLoXo.SelectedItemChanged += new EventHandler(ListView_SelectedItemChanged);

            cboMayLoXo.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(DropDownList_SelectedIndexChanged);

                       


            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGayDay.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGayCao.KeyPress += new KeyPressEventHandler(InputValidator);

           
            
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
            get { return thPhLoXoPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", thPhLoXoPres.TyLeMarkUp()); }
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
                 if (cboMayLoXo.SelectedValue != null)
                     int.TryParse(cboMayLoXo.SelectedValue.ToString(), out _idThanhPhamChon);
                 return _idThanhPhamChon; 
             }
             set { cboMayLoXo.SelectedValue = value; }
         }
       
        public string TenThanhPhamChon //là ép kim
        {
            get { return cboMayLoXo.Text; }
            set {cboMayLoXo.Text = value;}
        }
       
       
        public decimal ThanhTien
        {
            get { return thPhLoXoPres.ThanhTien_ThPh(); }
            set { ;}
        }


        public LoaiThanhPhamS LoaiThPh
        {
            get;
            set;
        }
        public KieuDongCuonS KieuDongCuon
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
     
       

        int _idLoXo = 0;
        public int IdLoXoDongCuonChon
        {
            get
            {
                if (lstLoXo.SelectedItems.Count > 0)
                {
                    var it = (LoXoDongCuon)lstLoXo.SelectedItems[0].DataBoundItem;
                    _idLoXo = it.ID;
                }
                   
                return _idLoXo;
                
            }
            set
            {
                _idLoXo = value;
                //chọn trên listview
                if (_idLoXo > 0 && lstLoXo.Items.Count > 0)
                {
                    var item = lstLoXo.Items.FirstOrDefault(x => x.Value.ToString() == _idLoXo.ToString());
                    //MessageBox.Show(item.ToString());
                    lstLoXo.SelectedItem = item;
                }

            }
        }

       

        public float GayCao
        {
            get
            {
                return float.Parse(txtGayCao.Text);
            }
            set
            {
                txtGayCao.Text = value.ToString();
            }
        }

        public float GayDay
        {
            get
            {
                return float.Parse(txtGayDay.Text);
            }
            set
            {
                txtGayDay.Text = value.ToString();
            }
        }
        #endregion

        private void LoadDongCuonLoXo()
        {
            //Cán phủ
            cboMayLoXo.DataSource = thPhLoXoPres.ThanhPhamS();
            cboMayLoXo.ValueMember = "ID";
            cboMayLoXo.DisplayMember = "Ten";
         
        }
        private bool dataChanged = false;

        private void BatTatNutTinhToan()
        {
            if (dataChanged)
                btnTinhToan.Enabled = dataChanged;
            else
                btnTinhToan.Enabled = false;
        }
        private void LoadLoXoDongCuon()
        {
            lstLoXo.Columns.Clear();
           // lstLoXo.Columns.Add("Id");
          //  lstLoXo.Columns.Add("Tên");
          //  lstLoXo.Columns.Add("Diễn giải");
           // lstLoXo.Columns.Add("Giá mua");
          //  lstLoXo.Columns.Add("Thứ tự");
            lstLoXo.DataSource = thPhLoXoPres.LoXoDongCuonS();
            lstLoXo.ValueMember = "ID";
            lstLoXo.DisplayMember = "TenVongXoan";

          /* 
            foreach (KeyValuePair<int, List<string>> kvp in thPhLoXoPres.NhuTheoEpKimS())
            {
                var item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                item.SubItems.AddRange(kvp.Value.ToArray());
                lstLoXo.Items.Add(item);
            }
            
            lstLoXo.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstLoXo.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstLoXo.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstLoXo.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstLoXo.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
           */
        }

        private void txtSoLuong_CanPhu_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            

                dataChanged = true;
            BatTatNutTinhToan();
            
            
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
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", thPhLoXoPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", thPhLoXoPres.GiaTB_ThPh(), this.DonViTinh);
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                
                if (t == txtSoLuong )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (t == txtGayCao || t == txtGayDay)// được số lẻ
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
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
            dataChanged = false;
            BatTatNutTinhToan();
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
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoLuong)
                {
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "10";

                }
                //xử lý khi user xóa hết
                if (tb == txtGayCao)
                    if (string.IsNullOrEmpty(txtGayCao.Text.Trim()))
                        txtGayCao.Text = "30";
            }
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
            return thPhLoXoPres.LayMucThanhPham();
        }

        private void cboMayLoXo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

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
            
                e.Column.Width = 120;
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
                if (cb == cboMayLoXo)
                {
                    dataChanged = true;
                    BatTatNutTinhToan();
                }

            }
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            CapNhatLabelGia();
            dataChanged = false;
            BatTatNutTinhToan();
        }

        
    }
}
