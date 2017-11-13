using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient
{
    public partial class GiayDeInForm : Form, IViewGiayDeIn
    {
        GiayDeInPresenter giayDeInPres;
        public GiayDeInForm(ThongTinBanDauChoGiayIn thongTinBanDau, GiayDeIn giayDeIn )
        {
            InitializeComponent();
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.ThongTinBaiIn_CauHinh = thongTinBanDau.ThongTinCanThiet;
            this.SoLuongSanPham = thongTinBanDau.SoLuongSanPham;
            this.IdHangKH = thongTinBanDau.IdHangKhachHang;
            this.PhuongPhapIn = thongTinBanDau.PhuongPhapIn;
            this.SanPhamRong = thongTinBanDau.KichThuocSanPham.Rong;
            this.SanPhamCao = thongTinBanDau.KichThuocSanPham.Dai;
            lblDonViTinh.Text = thongTinBanDau.DonViTinhSanPham;
            
            if (thongTinBanDau.LaInDanhThiep) //bắt nút tính số con
                btnTinhSoConTrenToChay.Enabled = false;
            else
                btnTinhSoConTrenToChay.Enabled = true;
          
            giayDeInPres = new GiayDeInPresenter(this, giayDeIn);                          
           
              //cập nhật khổ in đỡ
          
            
            //event
            txtSoToChayBuHao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayTrenToLon.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayLyThuyet.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoConTrenToIn.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToChayRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToChayDai.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLuongSP.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSPRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSPCao.KeyPress += new KeyPressEventHandler(InputValidator);

            txtSoToChayBuHao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToChayTrenToLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToChayLyThuyet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoConTrenToIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToGiayLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTenGiayIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoLuongSP.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSPRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSPCao.TextChanged += new EventHandler(TextBoxes_TextChanged);

            chkGiayKhach.CheckedChanged += new EventHandler(CheckBoxes_CheckChanged);
           
            lblSoToInTong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToChayRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToChayDai.TextChanged += new EventHandler(TextBoxes_TextChanged);

            

            txtSoConTrenToIn.Leave += new EventHandler(TextBoxes_Leave);
            txtSoToChayBuHao.Leave += new EventHandler(TextBoxes_Leave);
            txtSoToChayTrenToLon.Leave += new EventHandler(TextBoxes_Leave);
            txtSoLuongSP.Leave += new EventHandler(TextBoxes_Leave);
            txtSPRong.Leave += new EventHandler(TextBoxes_Leave);
            txtSPCao.Leave += new EventHandler(TextBoxes_Leave);
           
            
        }
        #region Implement Iview..

        public int ID { get; set; }
        public int IdBaiIn
        {
            get;
            set;
        }
        public PhuongPhapInS PhuongPhapIn { get; set; }
        public int IdHangKH { get; set; }
        public string DienGiaiBaiInVaSoLuong
        {
            get { return txtThongTinBaiIn.Text; }
            set { txtThongTinBaiIn.Text = value; }
        }
       
        public string ThongTinBaiIn_CauHinh
        {
            get { return txtThongTinBaiIn.Text; }
            set { txtThongTinBaiIn.Text = value; }
        }



        public int IdGiay { get; set; }
        public string TenGiayIn
        {
            get
            {
                return txtTenGiayIn.Text;
            }
            set
            {
                txtTenGiayIn.Text = value;
            }
        }
        public float GiayLonRong { get; set; }
        public float GiayLonCao { get; set; }
        public bool GiayKhachDua
        {
            get { return chkGiayKhach.Checked; }
            set { chkGiayKhach.Checked = value; }
        }
        
        public int SoLuongSanPham 
        { 
            get {return int.Parse(txtSoLuongSP.Text);}
            set {txtSoLuongSP.Text = value.ToString(); }
        }
       
        public float SanPhamRong
        {
            get {return float.Parse(txtSPRong.Text);}
            set { txtSPRong.Text = value.ToString();}

        }
         public float SanPhamCao
        {
            get {return float.Parse(txtSPCao.Text);}
            set { txtSPCao.Text = value.ToString();}

        }
        public float ToChayRong {  
            get
            {
                return float.Parse(txtToChayRong.Text);
            }
            set
            {
                txtToChayRong.Text = value.ToString();
            }
        }
        public float ToChayDai
        { 
            get
            {
                return float.Parse(txtToChayDai.Text); 
            }
            set
            {
                txtToChayDai.Text = value.ToString() ;
            }
        } 
       
        public int SoConTrenToChay
        {
            get { return int.Parse(txtSoConTrenToIn.Text); }
            set { txtSoConTrenToIn.Text = value.ToString(); }
        }
        public int SoLuongToChayLyThuyet
        {
            get
            {
                return giayDeInPres.SoToChayLyThuyetTinh();
            }
           
        }

        public int SoLuongToChayBuHao
        {
            get
            {
                return int.Parse(txtSoToChayBuHao.Text);
            }
            set
            {
                txtSoToChayBuHao.Text = value.ToString();
            }
        }
        public int SoToChayTrenToLon
        {
            get
            {
                return int.Parse(txtSoToChayTrenToLon.Text);
            }
            set
            {
                txtSoToChayTrenToLon.Text = value.ToString();
            }
        }
        public int SoToGiayLon
        {
            get
            {
                return giayDeInPres.SoToGiayLon();
            }
         
        }
        public decimal GiaBan
        {
            get { return giayDeInPres.GiaBan(); }
        }
        public int SoLuongToChayTong
        {
            get { return giayDeInPres.SoToChayTong(); }          
        }

        public decimal ThanhTien
        {
            get { return giayDeInPres.ThanhTien(); }
        }
        public FormStateS TinhTrangForm { get; set; }
        #endregion
        private bool dataChanged = false;
        public GiayDeIn DocGiayDeIn()
        {
            return giayDeInPres.DocGiayDeIn();
        }


        private void ChuanBiGiayForm_Load(object sender, EventArgs e)
        {

            //Khóa controls theo formState
            switch (this.TinhTrangForm)
            {
                case FormStateS.View:
                    KhoaCacControlsChoView();
                    break;
                case FormStateS.TinhThu:
                    KhoaCacControlsCho_TinhThu();
                    break;
                default:
                    KhoaCacControlsCho_NewEdit();
                    break;
            }

            lblTieuDeForm.Text = this.Text;
            XuLyGiayKhachHangDua();//Swicth
            //Bật tắt nút Nhận
            BatTatNutOKTheoDieuKien();
            //if (this.PhuongPhapIn == PhuongPhapInS.KhongIn)
            //   ;
            CapNhatMotSoTong();//Mặc định có
            CapNhatTriGiaVoLabels();
            //Đưa form về chưa thay đổi
            dataChanged = false;
            BatTatNutTinhToan();
        }

      
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoToChayBuHao || t == txtSoToChayLyThuyet || t == txtSoToChayTrenToLon ||
                    t == txtSoConTrenToIn || t == txtSoLuongSP)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                
                if (t == txtToChayRong || t == txtToChayDai ||
                    t == txtSPRong || t == txtSPCao)
                    //nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }

               
                 
            }
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoToChayBuHao && this.IdGiay >0)
                {
                    if (!string.IsNullOrEmpty(txtSoToChayBuHao.Text.Trim()))
                        //Tính
                        this.SoToChayTrenToLon = giayDeInPres.SoToChayTrenToLon();

                }
                if (tb == txtSoToChayLyThuyet && this.IdGiay > 0)
                {
                    if (!string.IsNullOrEmpty(txtSoToChayLyThuyet.Text.Trim()))
                        //Tính
                        this.SoToChayTrenToLon = giayDeInPres.SoToChayTrenToLon();

                }
            }
           
           
           
        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {

            TextBox tb;
            CheckBox chk;
            
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSPRong)
                {
                    if (string.IsNullOrEmpty(txtSPRong.Text.Trim()))
                    {
                        this.SanPhamRong = 31;
                    }
                    TinhSoConTrenToChay();
                }
                if (tb == txtSPCao)
                {
                    if (string.IsNullOrEmpty(txtSPCao.Text.Trim()))
                    {
                        this.SanPhamCao = 21;
                    }
                    TinhSoConTrenToChay();
                }

                if (tb == txtToChayRong)
                {
                    if (string.IsNullOrEmpty(txtToChayRong.Text.Trim()))
                    {
                        this.ToChayRong = 5;
                    }
                    TinhSoConTrenToChay();
                }

                if (tb == txtToChayDai)
                {
                    if (string.IsNullOrEmpty(txtToChayDai.Text.Trim()))
                    {
                        this.ToChayDai =10;
                    }
                    TinhSoConTrenToChay();
                }
                if (tb == txtSoConTrenToIn)
                {
                    if (string.IsNullOrEmpty(txtSoConTrenToIn.Text))
                    {
                        this.SoConTrenToChay = 1;

                    }
                    //Cập nhật số tờ chạy lý thuyết
                    txtSoToChayLyThuyet.Text = giayDeInPres.SoToChayLyThuyetTinh().ToString();
                }
                if (tb == txtSoToChayBuHao)
                {
                    if (string.IsNullOrEmpty(txtSoToChayBuHao.Text))
                    {
                        this.SoLuongToChayBuHao = 1;
                    }
                    //Cập nhật số tờ chạy tổng
                    lblSoToInTong.Text = giayDeInPres.SoToChayTong().ToString();
                }
                
                

                if (tb == txtSoToChayLyThuyet)
                {
                    lblSoToInTong.Text = giayDeInPres.SoToChayTong().ToString();

                    CapNhatTriGiaVoLabels();
                }
                
                if (tb == txtSoToChayTrenToLon)
                {
                    if (string.IsNullOrEmpty(txtSoToChayTrenToLon.Text))
                    {
                        txtSoToChayTrenToLon.Text = "1";
                    } else
                    {
                        var soToChayTrenToLonTuTinh = giayDeInPres.SoToChayTrenToLon();
                        if (this.SoToChayTrenToLon > soToChayTrenToLonTuTinh)
                        {
                            MessageBox.Show("Số tờ chạy máy tự tính ít hơn bạn tính!");
                            btnTinhToChayTrenToLon.Focus();
                        }
                    }

                    txtSoToGiayLon.Text = giayDeInPres.SoToGiayLon().ToString();
                    CapNhatTriGiaVoLabels();
                }


               

            }
            if (sender is CheckBox)
            {
                chk = (CheckBox)sender;
                if (chk == chkGiayKhach)
                {

                    CapNhatTriGiaVoLabels();

                }

            }
            
        }
        private void CapNhatTriGiaVoLabels()
        {
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            //Console.WriteLine(String.Format(info, "{0:c}", value));
            lblSoToInTong.Text = giayDeInPres.SoToChayTong().ToString();
            txtSoToGiayLon.Text = giayDeInPres.SoToGiayLon().ToString();
            lblGiaBan.Text = string.Format(info, "{0:c}/tờ", this.GiaBan);
            lblThanhTien.Text = string.Format(info, "{0:c}/tờ", this.ThanhTien);
            txtGiaGiayTB_SPham.Text = string.Format(info, "{0:c}",
                Math.Round(this.ThanhTien / this.SoLuongSanPham, 0));
           
        }
        private void KhoaCacControlsChoView()
        {
            txtTenGiayIn.Enabled = false;
            txtToChayRong.Enabled = false;
            txtToChayDai.Enabled = false;
            txtSoConTrenToIn.Enabled = false;
            txtSoToChayLyThuyet.Enabled = false;
            txtSoToChayBuHao.Enabled = false;
            txtSoToChayTrenToLon.Enabled = false;
        }
        private void KhoaCacControlsCho_NewEdit()
        {
            grbSanPham.Enabled = false;
            grbSanPham.TabStop = false;

            
        }
        private void KhoaCacControlsCho_TinhThu()
        {
            grbSanPham.Enabled = true;
            grbSanPham.TabStop = true;
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (!this.GiayKhachDua)
            {
                if (this.IdGiay <= 0)
                    loiS.Add("Bạn cần chọn giấy");
            }
            if (string.IsNullOrEmpty(txtTenGiayIn.Text))
                loiS.Add("Diễn giải chưa có");

           
            if (string.IsNullOrEmpty(txtSoToChayTrenToLon.Text))
                loiS.Add("Số tờ giấy lớn trống");
            if (string.IsNullOrEmpty(txtSoToChayBuHao.Text))
                loiS.Add("Cần để 0 chứ không thể rỗng");
            if (string.IsNullOrEmpty(txtSoConTrenToIn.Text))
                loiS.Add("Số con trên tờ chạy rỗng");
            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void ChuanBiGiayForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnChonGiay_Click(object sender, EventArgs e)
        {
            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.Get, this.IdHangKH);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.IdGiay = frm.GiayChon.ID;

                txtTenGiayIn.Text = giayDeInPres.TenGiayDeIn();
                //Thứ tự nha:
                giayDeInPres.CapNhatChiTietGiayChon();
                //Tiếp
                this.SoToChayTrenToLon = giayDeInPres.SoToChayTrenToLon();
                //Cập nhật giá trị
                CapNhatTriGiaVoLabels();
                //Bật tắt nút nhận
                BatTatNutOKTheoDieuKien();
                
            }
           
        }
        private void XuLyGiayKhachHangDua()
        {
            if (this.GiayKhachDua)
            {
                if (string.IsNullOrEmpty(this.TenGiayIn.Trim()))
                {
                    this.TenGiayIn = " Đề nghị ghi rõ tên giấy/kích thước/số tờ";
                }
                txtTenGiayIn.Focus();
                this.IdGiay = - 1;
                btnChonGiay.Enabled = false;                
            }
            else 
            {
                if(this.IdGiay <= 0) //chưa có giấy
                    txtTenGiayIn.Text = "";

                btnChonGiay.Enabled = true;                
                btnChonGiay.Focus();
            }
            //Xét nút
            BatTatNutOKTheoDieuKien();
        }

        private void chkGiayKhach_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void CheckBoxes_CheckChanged(object sender, EventArgs e)
        {
            CheckBox chk;
            if (sender is CheckBox )
            {
                chk = (CheckBox)sender;
                if (chk == chkGiayKhach)
                {
                    XuLyGiayKhachHangDua();
                    this.SoToChayTrenToLon = giayDeInPres.SoToChayTrenToLon();
                }
            }
            dataChanged = true;
            BatTatNutTinhToan();
            
        }
        private void TinhSoConTrenToChay()
        {
            this.SoConTrenToChay = TinhToan.SoConTrenToChayDigi(this.ToChayRong, this.ToChayDai,
                           this.SanPhamRong, this.SanPhamCao);
        }
        private void btnTinhSoConTrenToChay_Click(object sender, EventArgs e)
        {
            TinhSoConTrenToChay();

        }
        private void BatTatNutOKTheoDieuKien()
        {
            if (this.GiayKhachDua)
            {               
                btnNhan.Enabled = true;
            }
            else if (this.IdGiay > 0)
            {
                btnNhan.Enabled = true;
            }
            else
                btnNhan.Enabled = false;

        }
       private void BatTatNutTinhToan()
        {
            if (dataChanged)
                btnTinhGiaGiay.Enabled = dataChanged;
            else
                btnTinhGiaGiay.Enabled = false;
        }
        private void CapNhatMotSoTong()
       {
           //Cập nhật số tờ chạy lý thuyết
           txtSoToChayLyThuyet.Text = giayDeInPres.SoToChayLyThuyetTinh().ToString();
           txtSoToGiayLon.Text = giayDeInPres.SoToGiayLon().ToString();
           TinhSoConTrenToChay();
           txtSoToChayLyThuyet.Text = giayDeInPres.SoToChayLyThuyetTinh().ToString();
       }
       private void btnTinh_Click(object sender, EventArgs e)
       {
           CapNhatMotSoTong();
           CapNhatTriGiaVoLabels();
           //Tắt nút tính
           dataChanged = false;
           BatTatNutTinhToan();
       }

       private void btnTinhToChayTrenToLon_Click(object sender, EventArgs e)
       {
           this.SoToChayTrenToLon = giayDeInPres.SoToChayTrenToLon();
       }
    }

}
