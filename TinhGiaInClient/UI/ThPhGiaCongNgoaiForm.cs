using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.UI
{
    public partial class ThPhGiaCongNgoaiForm : Telerik.WinControls.UI.RadForm, IViewThPhGiaCongNgoai
    {
        public ThPhGiaCongNgoaiForm(ThongTinBanDauThanhPham thongTinBanDau, MucThPhGiaCongNgoai mucThPhGiaCongNgoai = null)
        {
            InitializeComponent();
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;
            this.LoaiThPh = thongTinBanDau.LoaiThanhPham;
           
            this.DonViTinh = thongTinBanDau.DonViTinh;
            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
            //Tiếp theo
            thPhamGCongNgoaiPres = new ThPhGiaCongNgoaiPresenter(this, mucThPhGiaCongNgoai);
            if (this.TinhTrangForm == FormStateS.New)
                thPhamGCongNgoaiPres.KhoiTaoBanDau();

            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDonViTinh.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTenNhaCungCap.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtPhiGiaCong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtPhiVanChuyen.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTenNhaCungCap.TextChanged += new EventHandler(TextBoxes_TextChanged);
            spnTyLeLoiNhuan.ValueChanged += new EventHandler(TextBoxes_TextChanged);

            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiGiaCong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiVanChuyen.KeyPress += new KeyPressEventHandler(InputValidator);

        }
        ThPhGiaCongNgoaiPresenter thPhamGCongNgoaiPres;
        const int TYLE_MARK_UP = 25;//Cơ bản vậy mới làm
        #region implement IViewThPhG
        public int ID
        {
            get;
            set;
        }

        public int IdBaiIn
        {
            get;
            set;
        }
        public string ThongTinHoTro
        {
            get { return txtThongTinHoTro.Text; }
            set { txtThongTinHoTro.Text = value; }
        }
        public int IdHangKhachHang
        {
            get;
            set;
        }

        public string ThongTinHangKH
        {
            get { return "gia công"; }
        }
        public string TenThanhPhamChon
        {
            get { return txtTen.Text; }
            set { txtTen.Text = value; }
        }
        public LoaiThanhPhamS LoaiThPh { get; set; }
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
            get { return txtDonViTinh.Text; }
            set { txtDonViTinh.Text = value; }
        }

        public int PhiGiaCong
        {
            get
            {
                return int.Parse(txtPhiGiaCong.Text);
            }
            set
            {
                txtPhiGiaCong.Text = value.ToString();
            }
        }

        public int PhiVanChuyen
        {
            get
            {
                return int.Parse(txtPhiVanChuyen.Text);
            }
            set
            {
                txtPhiVanChuyen.Text = value.ToString();
            }
        }

        public string TenNhaCungCap
        {
            get { return txtTenNhaCungCap.Text; }
            set { txtTenNhaCungCap.Text = value; }
        }

        public int TyLeMarkUp
        {
            get
            {
                return (int)spnTyLeLoiNhuan.Value;
            }
            set
            {
                spnTyLeLoiNhuan.Value = value;
            }
        }
        public string ThongTinTyLeMarkUp
        {
            get { return this.TyLeMarkUp.ToString() + "%"; }
        }
        decimal _thanhTien;
        public decimal ThanhTien
        {
            get
            {
                return _thanhTien;
            }
            set
            {
                _thanhTien = value;
                lblThanhTien.Text = string.Format("{0:0,0.00}đ", _thanhTien);
            }
        }

        public FormStateS TinhTrangForm
        {
            get;
            set;
        }
        #endregion
        public bool DuLieuFormThayDoi;
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTen || tb == txtSoLuong ||
                    tb == txtDonViTinh || tb == txtTenNhaCungCap ||
                    tb == txtPhiGiaCong ||  tb == txtPhiVanChuyen ||
                    tb == txtTenNhaCungCap )
                {
                    this.DuLieuFormThayDoi = true;
                    btnOK.Enabled = this.DuLieuFormThayDoi;

                }
                //Vụ xóa hết
                if (tb == txtSoLuong)
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "1";
                if (tb == txtPhiGiaCong)
                    if (string.IsNullOrEmpty(txtPhiGiaCong.Text.Trim()))
                        txtPhiGiaCong.Text = "0";
                if (tb == txtPhiVanChuyen)
                    if (string.IsNullOrEmpty(txtPhiVanChuyen.Text.Trim()))
                        txtPhiVanChuyen.Text = "0";
                //Cập nhật tính toán
                if (tb == txtPhiGiaCong || tb == txtSoLuong || tb== txtPhiVanChuyen)
                {
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ", thPhamGCongNgoaiPres.ThanhTien());
                }
            }

            Telerik.WinControls.UI.RadSpinEditor spn;
            if (sender is Telerik.WinControls.UI.RadSpinEditor)
            {
                spn = (Telerik.WinControls.UI.RadSpinEditor)sender;

                if (spn == spnTyLeLoiNhuan)
                {
                    this.DuLieuFormThayDoi = true;
                    
                }

                if (spn == spnTyLeLoiNhuan)
                {
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ", thPhamGCongNgoaiPres.ThanhTien());
                }

            }

            btnOK.Enabled = this.DuLieuFormThayDoi;
           

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if (tb == txtSoLuong || tb == txtPhiGiaCong ||
                    tb == txtPhiVanChuyen)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
               /*
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
                */
               

            }
        }

        private void ThPhGiaCongNgoaiForm_Load(object sender, EventArgs e)
        {
            
            spnTyLeLoiNhuan.Minimum = TYLE_MARK_UP;
            spnTyLeLoiNhuan.Maximum = TYLE_MARK_UP + 20;
            this.DuLieuFormThayDoi = false;
            btnOK.Enabled = this.DuLieuFormThayDoi;
        }






        public int IdThanhPhamChon
        {
            get;
            set;
        }

        public MucThanhPham LayMucThanhPham()
        {
            return thPhamGCongNgoaiPres.DocMucThPhGiaCongNgoai();
        }

        private void spnTyLeLoiNhuan_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
