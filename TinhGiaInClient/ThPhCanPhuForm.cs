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

namespace TinhGiaInClient
{
    public partial class ThPhCanPhuForm : Form, IViewThPhCanPhu
    {
        CanPhuPresenter canPhuPres;
        public ThPhCanPhuForm(ThongTinBanDauChoThanhPham thongTinBanDau, MucThanhPham mucThPham = null )
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;
            this.IdBaiIn = thongTinBanDau.IdBaiIn;
            this.IdHangKhachHang = thongTinBanDau.IdHangKhachHang;
            this.LoaiThPh = thongTinBanDau.LoaiThanhPham;

            canPhuPres = new CanPhuPresenter(this);
            LoadThanhPham();
            canPhuPres.KhoiTaoBanDau();
            //Envent
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
           
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);           

            lbxCanPhu.SelectedIndexChanged += new EventHandler(ListBoxes_SelectedIndex_Changed);
            
        }
        #region Implement Iview
        public int ID
        {
            get;
            set;
        }

        public int IdThanhPhamChon
        {
            get
            {
                return int.Parse(lbxCanPhu.SelectedValue.ToString());
            }
            set
            {
                lbxCanPhu.SelectedValue = value;
            }
        }
        public int IdBaiIn { get; set; }

        public int IdHangKhachHang
        {
            get;
            set;
        }

        public string ThongTinHangKH
        {
            get { return canPhuPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", canPhuPres.TyLeMarkUp()); }
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
       
     
        public string TenThanhPhamChon
        {
            get 
            {return string.Format( lbxCanPhu.Text+ " {0} mặt",
                this.KieuCanPhu);}
            set { ;}
        }
       
        public decimal ThanhTien
        {
            get { return canPhuPres.ThanhTien_ThPh(); }
            set { ;}
        }


        public LoaiThanhPhamS LoaiThPh
        {
            get;
            set;
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }
        public string ThongTinHoTro
        {
            get { return txtThongTinBoSung.Text; }
            set { txtThongTinBoSung.Text = value; }
        }
        int _matCanPhu = 1;
        public int KieuCanPhu
        {
            get
            {
                if (rdbHaiMat.Checked)
                    _matCanPhu = 2;
                else
                    _matCanPhu = 1;
                return _matCanPhu;
            }
            set
            {
                _matCanPhu = value;
                if (_matCanPhu == 2)
                    rdbHaiMat.Checked = true;
                else
                    rdbMotMat.Checked = true;
            }
        }
        #endregion

        private void LoadThanhPham()
        {
            lbxCanPhu.DataSource = canPhuPres.ThanhPhamS();
            lbxCanPhu.ValueMember = "ID";
            lbxCanPhu.DisplayMember = "Ten";
         
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
                        this.SoLuong = 0;
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ", canPhuPres.ThanhTien_ThPh());
                    lblGiaTB.Text = string.Format("{0:0,0.00}đ", canPhuPres.GiaTB_ThPh());
                }
               
            }

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoLuong )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }

            }
        }
        private void ListBoxes_SelectedIndex_Changed(object sender, EventArgs e)
        {
            ListBox lb;
            if (sender is ListBox)
            {
                lb = (ListBox)sender;
                if (lb == lbxCanPhu)
                {
                    txtSoLuong.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    btnOK.Enabled = true;
                }
               
            }
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", canPhuPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", canPhuPres.GiaTB_ThPh(), this.DonViTinh);
        }

        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = false;
            txtDonViTinh.Enabled = false;
            btnOK.Enabled = false;
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
        public MucThanhPham LayMucThanhPham()
        {
            return canPhuPres.LayMucThanhPham();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }


        
    }
}
