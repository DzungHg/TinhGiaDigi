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
    public partial class ThPhKhoanBoGocForm : Telerik.WinControls.UI.RadForm, IViewThPhKhoanBoGoc
    {
        ThPhKhoanBoGocPresenter thPhKhoanBoGocPres;
        public ThPhKhoanBoGocForm(ThongTinBanDauThanhPham thongTinBanDau, MucThPhKhoanBoGoc mucThPhKHoanBoGoc)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;

            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;
            //txtSoLuongBlock.Enabled = thongTinBanDau.MoTextSoLuong;


            thPhKhoanBoGocPres = new ThPhKhoanBoGocPresenter(this, mucThPhKHoanBoGoc);
            LoadMayMoc();
            cboMayMoc.SelectedIndex = -1;
            cboMayMoc.SelectedIndex = 0;
            //Load Nhu ep


            //Load

            //Mục này phải làm ở đây
            if (this.TinhTrangForm == FormStateS.Edit ||
                this.IdThanhPhamChon > 0)
            {
                this.IdThanhPhamChon = mucThPhKHoanBoGoc.IdThanhPhamChon;

                //this.IdGiayBoiGiuaChon = mucThPhBoiBiaCung.IdGiayBoiGiuaChon;
            }
            //Tiếp xem nếu có giấy bồi khong
            if (this.TinhTrangForm == FormStateS.Edit)
            {

                //Tính toán
                CapNhatLabelGia(true);
            }
            //Envent

            /*txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);           
            txtSoLopLot.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToBoiRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToBoiCao.TextChanged += new EventHandler(TextBoxes_TextChanged);*/

            txtSoLuongBlock.Leave += new EventHandler(TextBoxes_Leave);
            txtSoLanKhoanBoTrenBlock.Leave += new EventHandler(TextBoxes_Leave);
            txtKichThuocBlock.Leave += new EventHandler(TextBoxes_Leave);
            txtSoLuongBlock.Leave += new EventHandler(TextBoxes_Leave);

            txtSoLuongBlock.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLanKhoanBoTrenBlock.KeyPress += new KeyPressEventHandler(InputValidator);
            txtKichThuocBlock.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLuongBlock.KeyPress += new KeyPressEventHandler(InputValidator);



            cboMayMoc.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(DropDownList_SelectedIndexChanged);



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
            get { return thPhKhoanBoGocPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", thPhKhoanBoGocPres.TyLeMarkUp()); }
        }
        public int SoLuong
        {
            get
            {
                return int.Parse(txtSoLuongBlock.Text);
            }
            set
            {
                txtSoLuongBlock.Text = value.ToString();
            }
        }
        public string DonViTinh
        {
            get
            {
                return txtDonViTinh.Text;
            }
            set
            {
                txtDonViTinh.Text = value;
            }
        }
        int _idThanhPhamChon = 0;
        public int IdThanhPhamChon
        {
            get
            {
                if (cboMayMoc.SelectedValue != null)
                    int.TryParse(cboMayMoc.SelectedValue.ToString(), out _idThanhPhamChon);
                return _idThanhPhamChon;
            }
            set { cboMayMoc.SelectedValue = value; }
        }

        public string TenThanhPhamChon //là ép kim
        {
            get { return cboMayMoc.Text; }
            set { cboMayMoc.Text = value; }
        }


        public decimal ThanhTien
        {
            get { return thPhKhoanBoGocPres.ThanhTien_ThPh(); }
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
        //phần bổ sung
        public string KichThuocBlock
        {
            get
            {
                return txtKichThuocBlock.Text;
            }
            set
            {
                txtKichThuocBlock.Text = value;
            }
        }





        public string TieuDe
        {
            get { return lblTieuDeForm.Text; }
            set { lblTieuDeForm.Text = value; }
        }



        public int SoLanKhoanBoTrenMoiBlock
        {
            get
            {
                return int.Parse(txtSoLanKhoanBoTrenBlock.Text);
            }
            set
            {
                txtSoLanKhoanBoTrenBlock.Text = value.ToString();
            }
        }




        #endregion

        private void LoadMayMoc()
        {
            //Cán phủ
            cboMayMoc.DataSource = thPhKhoanBoGocPres.ThanhPhamS();
            cboMayMoc.ValueMember = "ID";
            cboMayMoc.DisplayMember = "Ten";

        }



        private void txtSoLuong_CanPhu_TextChanged(object sender, EventArgs e)
        {

        }
        /*private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
          TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
               if (tb == txtSoLuong )
                {
                    if (!string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        CapNhatLabelGia();                    
                }
                if (tb == txtToBoiRong)
                {
                    if (!string.IsNullOrEmpty(txtToBoiRong.Text.Trim()))
                        ;
                }
                if (tb == txtToBoiCao)
                {
                    if (!string.IsNullOrEmpty(txtToBoiCao.Text.Trim()))
                        ;
                }
                //xử lý khi user xóa hết bên Leave
                
                if (tb == txtSoLopLot)
                {
                    
                    ;
                }
                
            
            }

            Telerik.WinControls.UI.RadListView lv;
            if (sender is Telerik.WinControls.UI.RadListView)
            {
                lv = (Telerik.WinControls.UI.RadListView)sender;
                if (lv == lstLoXo)
                {
                    txtSoLuong.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    CapNhatLabelGia();
                }
            }
            
        }*/
        private void CapNhatLabelGia(bool capNhat)
        {
            if (capNhat)
            {

                lblThanhTien.Text = string.Format("{0:0,0.00}đ", thPhKhoanBoGocPres.ThanhTien_ThPh());
                lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", thPhKhoanBoGocPres.GiaTB_ThPh(), this.DonViTinh);
            }
            else
            {
                lblThanhTien.Text = "";
                lblGiaTB.Text = "";
            }
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;

                if (t == txtSoLuongBlock || t == txtSoLanKhoanBoTrenBlock)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                /* if (t == txtKichThuocBlock || t == txtSoLuongBlock)// được số lẻ
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
            //Lừa để bât tắt nút lấy giấy
            var soLop = this.SoLanKhoanBoTrenMoiBlock;
            this.SoLanKhoanBoTrenMoiBlock = -1;
            this.SoLanKhoanBoTrenMoiBlock = soLop;
        }

        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(txtSoLuongBlock.Text))
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





        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                //xử lý khi user xóa hết
                tb = (TextBox)sender;
                if (tb == txtSoLuongBlock)
                {
                    if (string.IsNullOrEmpty(txtSoLuongBlock.Text.Trim()))
                        txtSoLuongBlock.Text = "1";
                }
                if (tb == txtKichThuocBlock)
                {
                    if (string.IsNullOrEmpty(txtKichThuocBlock.Text.Trim()))
                        this.KichThuocBlock = "21 x 30cm";
                }


                if (tb == txtSoLanKhoanBoTrenBlock)
                {
                    if (string.IsNullOrEmpty(txtSoLanKhoanBoTrenBlock.Text.Trim()))
                    {
                        this.SoLanKhoanBoTrenMoiBlock = 1;

                    }

                }

            }
            ChoKhongChoNutNhan();
        }


        public MucThanhPham LayMucThanhPham()
        {
            return thPhKhoanBoGocPres.LayMucThanhPham();
        }

        private void cboMayMoc_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //cập nhật tiêu đề
            lblTieuDeForm.Text = thPhKhoanBoGocPres.TieuDeThPh();
        }





        private void ListView_SelectedItemChanged(object sender, EventArgs e)
        {

            CapNhatLabelGia(true);

        }
        private void DropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Telerik.WinControls.UI.RadDropDownList cb;
            if (sender is Telerik.WinControls.UI.RadDropDownList)
            {
                cb = (Telerik.WinControls.UI.RadDropDownList)sender;
                if (cb == cboMayMoc)
                {
                    CapNhatLabelGia(true);
                }

            }
        }


        private void btnTinh_Click(object sender, EventArgs e)
        {

            CapNhatLabelGia(true);
            ChoKhongChoNutNhan();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            thPhKhoanBoGocPres.LamLai();
            CapNhatLabelGia(false);
            ChoKhongChoNutNhan();
            txtSoLuongBlock.Enabled = true;
        }

        private void ChoKhongChoNutNhan()
        {
            ///các đk cho: nếu só lợp >0 thì giấy bồi phải có
            ///số lượng >0
            ///
            bool kq = true;
            if (string.IsNullOrEmpty(this.KichThuocBlock))
            {
                MessageBox.Show("Cần kích thước");
                txtKichThuocBlock.Focus();
                kq = false;
            }
            if (this.SoLanKhoanBoTrenMoiBlock <= 0)
            {


                MessageBox.Show("Số lượng cần!");
                txtSoLanKhoanBoTrenBlock.Focus();
                kq = false;

            }

            if (this.SoLuong <= 0)
            {

                MessageBox.Show("Số lượng block > 0");
                txtSoLuongBlock.Focus();
                kq = false;

            }
            btnNhan.Enabled = kq;
        }
    
    }
}
