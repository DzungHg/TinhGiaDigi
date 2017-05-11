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

namespace TinhGiaInClient
{
    public partial class ThPhCanPhuForm : Form, IViewThanhPham
    {
        CanPhuPresenter canPhuPres;
        public ThPhCanPhuForm()
        {
            InitializeComponent();
            canPhuPres = new CanPhuPresenter(this);
            LoadThanhPham();
            canPhuPres.KhoiTaoBanDau();
            //Envent
            txtSoLuong_CanPhu.TextChanged += new EventHandler(TextBoxes_TextChanged);
           
            txtSoLuong_CanPhu.KeyPress += new KeyPressEventHandler(InputValidator);
           

            lbxCanPhu.SelectedIndexChanged += new EventHandler(ListBoxes_SelectedIndex_Changed);
            
        }
        #region Implement Iview
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
            get { return string.Format("{0}%", canPhuPres.TyLeMarkUp(this.IdHangKhachHang)); }
        }
         public int SoLuong
        {
            get
            {
                return int.Parse(txtSoLuong_CanPhu.Text);
            }
            set
            {
                txtSoLuong_CanPhu.Text = value.ToString();
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
       
        public string TenTenThPh 
        {
            get { return lbxCanPhu.Text; }
            set {lbxCanPhu.Text = value;}
        }
       
       
        public decimal ThanhTienCanPhu
        {
            get { return canPhuPres.ThanhTien_ThPh(); }
        }


        public int LoaiThPh
        {
            get;
            set;
        }
        public int TinhTrangForm
        {
            get;
            set;
        }
       
        #endregion

        private void LoadThanhPham()
        {
            //Cán phủ
            lbxCanPhu.Items.Clear();
            foreach (KeyValuePair<int,string> kvp in canPhuPres.ThanhPhamS())
            {
                lbxCanPhu.Items.Add(kvp.Value);
            }
         
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
                if (tb == txtSoLuong_CanPhu)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtSoLuong_CanPhu.Text))
                        this.SoLuong = 0;
                    lblThanhTien_CanPhu.Text = string.Format("{0:0,0.00}đ", canPhuPres.ThanhTien_ThPh());
                    lblGiaTB_CanPhu.Text = string.Format("{0:0,0.00}đ", canPhuPres.GiaTB_ThPh());
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
                if (t == txtSoLuong_CanPhu )//chỉ được nhập số chẵn 
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
                    txtSoLuong_CanPhu.Enabled = true;
                    txtDonViTinh.Enabled = true;
                }
               
            }
        }

        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            txtSoLuong_CanPhu.Enabled = false;
            txtDonViTinh.Enabled = false;
          
        }


       
    }
}
