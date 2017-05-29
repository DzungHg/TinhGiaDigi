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

namespace TinhGiaInClient
{
    public partial class ThPhDongCuonForm : Form, IViewThanhPham
    {
        DongCuonPresenter dongCuonPres;
        public ThPhDongCuonForm(ThongTinBanDauChoThanhPham thongTinBanDau, MucThanhPham mucThPham= null)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
            this.Text = thongTinBanDau.TieuDeForm;
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.DonViTinh = thongTinBanDau.DonViTinh;
            this.SoLuong = thongTinBanDau.SoLuongSanPham;
            this.IdHangKhachHang = thongTinBanDau.IdHangKhachHang;
            this.IdBaiIn = thongTinBanDau.IdBaiIn;
            this.LoaiThPh = thongTinBanDau.LoaiThanhPham;

            dongCuonPres = new DongCuonPresenter(this, mucThPham);
            dongCuonPres.KhoiTaoBanDau();
            LoadThanhPham();
            
            //Envent
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
           
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);           

            lbxThanhPham.SelectedIndexChanged += new EventHandler(ListBoxes_SelectedIndex_Changed);
            
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
            get { return dongCuonPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", dongCuonPres.TyLeMarkUp(this.IdHangKhachHang)); }
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
         public int IdThanhPhamChon
         {
             get
             {
                 return int.Parse(lbxThanhPham.SelectedValue.ToString());
             }
             set
             {
                 lbxThanhPham.SelectedValue = value;
             }
         }
        public string TenThanhPhamChon 
        {
            get { return lbxThanhPham.Text; }
            set {lbxThanhPham.Text = value;}
        }
       
       
        public decimal ThanhTien
        {
            get { return dongCuonPres.ThanhTien_ThPh(); }
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
       
        #endregion

        private void LoadThanhPham()
        {
            //Cán phủ
            lbxThanhPham.DataSource = dongCuonPres.ThanhPhamS();
            lbxThanhPham.ValueMember = "ID";
            lbxThanhPham.DisplayMember = "Ten";
         
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
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ", dongCuonPres.ThanhTien_ThPh());
                    lblGiaTB.Text = string.Format("{0:0,0.00}đ", dongCuonPres.GiaTB_ThPh());
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
                if (lb == lbxThanhPham)
                {
                    txtSoLuong.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    btnOK.Enabled = true;
                }
               
            }
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", dongCuonPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", dongCuonPres.GiaTB_ThPh(), this.DonViTinh);
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
            if (string.IsNullOrEmpty(this.TenThanhPhamChon) )
                loiS.Add("Tên thành phẩm rỗng");
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


        public CanGapPresenter canGapPres { get; set; }

        private void ThPhDongCuonForm_FormClosing(object sender, FormClosingEventArgs e)
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
            return dongCuonPres.LayMucThanhPham();
        }
    }
}
