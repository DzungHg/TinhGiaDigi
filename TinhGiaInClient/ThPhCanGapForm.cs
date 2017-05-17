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
    public partial class ThPhCanGapForm : Form, IViewGiaCanGap
    {
        CanGapPresenter canGapPres;
        public ThPhCanGapForm(string thongTinHoTro)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinHoTro;
            canGapPres = new CanGapPresenter(this);
            canGapPres.KhoiTaoBanDau();
            LoadThanhPham();
            //Envent
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoDuongCan.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoDuongCan.KeyPress += new KeyPressEventHandler(InputValidator);     
            lbxThanhPham.SelectedIndexChanged += new EventHandler(ListBoxes_SelectedIndex_Changed);
            
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
            get { return canGapPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", canGapPres.TyLeMarkUp(this.IdHangKhachHang)); }
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
         public int SoDuongCan
         {
             get
             {
                 return int.Parse(txtSoDuongCan.Text);
             }
             set
             {
                 txtSoDuongCan.Text = value.ToString();
             }
         }
        public string TenThPhChon 
        {
            get { return lbxThanhPham.Text; }
            set {lbxThanhPham.Text = value;}
        }
       
       
        public decimal ThanhTien
        {
            get { return canGapPres.ThanhTien_ThPh(); }
        }


        public LoaiThanhPham LoaiThPh
        {
            get;
            set;
        }
        public int TinhTrangForm
        {
            get;
            set;
        }
        public string ThongTinHoTro
        {
            get { return txtThongTinBoSung.Text; }
            set { txtThongTinBoSung.Text = value; }
        }
        #endregion

        private void LoadThanhPham()
        {
            //Cán phủ
            lbxThanhPham.Items.Clear();
            foreach (KeyValuePair<int, string> kvp in canGapPres.ThanhPhamS())
            {
                lbxThanhPham.Items.Add(kvp.Value);
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
                if (tb == txtSoLuong)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "1";
                   
                }
                if (tb == txtSoLuong)
                {
                    if (string.IsNullOrEmpty(txtSoDuongCan.Text.Trim()))
                        txtSoDuongCan.Text = "1";
                }
                //Cập nhật thông tin
                lblThanhTien.Text = string.Format("{0:0,0.00}đ", canGapPres.ThanhTien_ThPh());
                lblGiaTB.Text = string.Format("{0:0,0.00}đ", canGapPres.GiaTB_ThPh());
            }

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
                if (t == txtSoDuongCan)//chỉ được nhập số chẵn 
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
                    txtSoDuongCan.Enabled = true;
                }
               
            }
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", canGapPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", canGapPres.GiaTB_ThPh(), this.DonViTinh);
        }

        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = false;
            txtDonViTinh.Enabled = false;
            txtSoDuongCan.Enabled = false;
          
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(this.TenThPhChon))
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
        private void ThPhCanGapForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtThongTinBoSung_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
