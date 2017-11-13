using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient
{
    public partial class ThPhCanGapForm : Form, IViewGiaCanGap
    {
        ThPhCanGapPresenter canGapPres;
        public ThPhCanGapForm(ThongTinBanDauThanhPham thongTinBanDau, MucThPhCanGap mucThPham)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;


            canGapPres = new ThPhCanGapPresenter(this, mucThPham);
            LoadThanhPham();
            //Bẩy
            lbxThanhPham.SelectedIndex = -1;
            lbxThanhPham.SelectedIndex = 0;
            //Xử lý ở đây vì trong present không thể
            if (this.TinhTrangForm == FormStateS.Edit)
            {
                this.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
            }

            if (this.TinhTrangForm == FormStateS.New)
                canGapPres.KhoiTaoBanDau();
            //Envent
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoDuongCan.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lbxThanhPham.SelectedIndexChanged += new EventHandler(ListBoxes_SelectedIndex_Changed);

            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoDuongCan.KeyPress += new KeyPressEventHandler(InputValidator);

            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);
            txtSoDuongCan.Leave += new EventHandler(TextBoxes_Leave);

        }
        #region Implement Iview
        public int IdBaiIn { get; set; }

        public int IdHangKhachHang
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }
        int _idThanhPhamChon = 0;
        public int IdThanhPhamChon
        {
            get { 
                if (lbxThanhPham.SelectedValue != null)
                    int.TryParse(lbxThanhPham.SelectedValue.ToString(), out _idThanhPhamChon);
                return _idThanhPhamChon;
            }
            set { lbxThanhPham.SelectedValue = value; }
        }
        public string TenThanhPhamChon
        {
            get
            {
                return string.Format("{0} {1} đường", lbxThanhPham.Text,
                    this.SoDuongCan);
            }
            set { ;}
            
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
    
       
       
        public decimal ThanhTien
        {
            get { return canGapPres.ThanhTien_ThPh(); }
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
        #endregion
        private bool dataChanged = false;

        private void LoadThanhPham()
        {
            lbxThanhPham.DataSource = canGapPres.ThanhPhamS();
            lbxThanhPham.ValueMember = "ID";
            lbxThanhPham.DisplayMember = "Ten";
           
         
        }

        private void txtSoLuong_CanPhu_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            dataChanged = true;
            BatTatNutTinhToan();
            btnOK.Enabled = true;
        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoLuong)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        this.SoLuong = 10;

                }
                if (tb == txtSoDuongCan)
                {
                    if (string.IsNullOrEmpty(txtSoDuongCan.Text.Trim()))
                        this.SoDuongCan = 1;
                    CapNhatCacNhanThanhTien();
                }
               
            }
            btnOK.Enabled = true;
        }
        private void CapNhatCacNhanThanhTien()
        {
            //Cập nhật thông tin
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", canGapPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ", canGapPres.GiaTB_ThPh());
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
                                    
                  
                    btnOK.Enabled = true;
                }
               
            }
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", canGapPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", canGapPres.GiaTB_ThPh(), this.DonViTinh);
        }

        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            
            txtDonViTinh.Enabled = false;
            
            btnOK.Enabled = false;
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
        private void BatTatNutTinhToan()
        {
            if (dataChanged)
                btnTinhToan.Enabled = dataChanged;
            else
                btnTinhToan.Enabled = false;
        }

      
        public MucThanhPham LayMucThanhPham()
        {
            return canGapPres.LayMucThanhPham();
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            CapNhatCacNhanThanhTien();
            dataChanged = false;
            BatTatNutTinhToan();
        }
    }
}
