﻿using System;
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
    public partial class ThPhDongCuonLoXoForm : Telerik.WinControls.UI.RadForm, IViewThPhDongCuonLoXo
    {
        ThPhDongCuonLoXoPresenter thPhLoXoPres;
        public ThPhDongCuonLoXoForm(ThongTinBanDauChoThanhPham thongTinBanDau, MucThanhPham mucThPham = null)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
            this.IdBaiIn = thongTinBanDau.IdBaiIn;
            this.IdHangKhachHang = thongTinBanDau.IdHangKhachHang;
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;
            this.LoaiThPh = thongTinBanDau.LoaiThanhPham;
            this.SoLuong = thongTinBanDau.SoLuongSanPham;
            this.DonViTinh = thongTinBanDau.DonViTinh;

            thPhLoXoPres = new ThPhDongCuonLoXoPresenter(this, mucThPham);
            LoadDongCuonLoXo();
            //Load Nhu ep
            LoadLoXoDongCuon();

            thPhLoXoPres.KhoiTaoBanDau();
            //Load
            LoadDongCuonLoXo();
            cboMayLoXo.SelectedIndex = -1;
            cboMayLoXo.SelectedIndex = 0;
            
            //Envent
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);

            lstLoXo.SelectedItemChanged += new EventHandler(ListView_SelectedItemChanged);

            cboMayLoXo.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(DropDownList_SelectedIndexChanged);

            txtGayDay.Leave += new EventHandler(TextBoxes_Leave);
            txtGayRong.Leave += new EventHandler(TextBoxes_Leave);
            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);



            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGayDay.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGayRong.KeyPress += new KeyPressEventHandler(InputValidator);

           
            
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
            }
        }

       

        public float GayRong
        {
            get
            {
                return float.Parse(txtGayRong.Text);
            }
            set
            {
                txtGayRong.Text = value.ToString();
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
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoLuong)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtSoLuong.Text))
                        this.SoLuong = 1;

                    CapNhatLabelGia();
                }               
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
                if (t == txtGayDay || t== txtGayRong)//chỉ được số lẻ
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
            txtSoLuong.Enabled = false;
            txtDonViTinh.Enabled = false;
            btnNhan.Enabled = false;
            
            if (this.TinhTrangForm == FormStateS.View)
            {
                txtSoLuong.Enabled = true;
                
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
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                if (t == txtSoLuong)
                    if (string.IsNullOrEmpty(txtSoLuong.Text))
                        this.SoLuong = 1;
                if (t == txtGayRong)
                    if (string.IsNullOrEmpty(txtGayRong.Text))
                        this.GayRong = 1;
                if (t == txtGayDay)
                    if (string.IsNullOrEmpty(txtGayDay.Text))
                        this.GayDay = 1;

            }

            CapNhatLabelGia();
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
                    CapNhatLabelGia();
                }

            }
        }
        private void lstLoXo_SelectedItemChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
