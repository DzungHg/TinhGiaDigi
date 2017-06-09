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
            this.KichThuocSanPham = thongTinBanDau.KichThuocSanPham;
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
            txtSoToChayBuHao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToChayTrenToLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToChayLyThuyet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoConTrenToIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToGiayLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTenGiayIn.TextChanged += new EventHandler(TextBoxes_TextChanged);

            chkGiayKhach.CheckedChanged += new EventHandler(TextBoxes_TextChanged);
           
            lblSoToInTong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToChayRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToChayDai.TextChanged += new EventHandler(TextBoxes_TextChanged);
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
        public bool GiayKhachDua
        {
            get { return chkGiayKhach.Checked; }
            set { chkGiayKhach.Checked = value; }
        }
        
        public int SoLuongSanPham { get; set; }
        public KichThuocPhang KichThuocSanPham { get; set; }
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
        
        public GiayDeIn DocGiayDeIn()
        {
            return giayDeInPres.DocGiayDeIn();
        }
     
      
        private void ChuanBiGiayForm_Load(object sender, EventArgs e)
        {
           
            //Khóa nếu view
            if (this.TinhTrangForm == FormStateS.View)
                KhoaCacControlsChoView();

            lblTieuDeForm.Text = this.Text;
            XuLyGiayKhachHangDua();//Swicth
            //Bật tắt nút Nhận
            BatTatNutOKTheoDieuKien();
            //if (this.PhuongPhapIn == PhuongPhapInS.KhongIn)
             //   ;
            CapNhatTriGiaVoLabels();
        }

      
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoToChayBuHao || t == txtSoToChayLyThuyet || t == txtSoToChayTrenToLon ||
                    t == txtSoConTrenToIn)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                
                if (t == txtToChayRong || t == txtToChayDai)
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
            CheckBox chk;
            Label lb;
            if (sender is Label)
            {
                lb = (Label)sender;
               
                if (lb == lblSoToInTong)
                {
                    ;
                }
            }
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoConTrenToIn)
                {
                    if (string.IsNullOrEmpty(txtSoConTrenToIn.Text))
                    {
                        txtSoConTrenToIn.Text = "1";

                    }
                    txtSoToChayLyThuyet.Text = giayDeInPres.SoToChayLyThuyetTinh().ToString() ;
                }
                if (tb == txtTenGiayIn)
                {
                    //Bẩy để cập nhật label
                    this.SoConTrenToChay += 1;
                    this.SoConTrenToChay -= 1;
                    this.SoToChayTrenToLon += 1;
                    this.SoToChayTrenToLon -= 1; //Bẩy

                }
                if (tb == txtToChayRong)
                {
                    if (string.IsNullOrEmpty(txtToChayRong.Text.Trim()))
                    {
                        txtToChayRong.Text = "1";
                    }
                    
                }

                if (tb == txtToChayDai)
                {
                    if (string.IsNullOrEmpty(txtToChayDai.Text.Trim()))
                    {
                        txtToChayDai.Text = "1";
                    }

                }

                if (tb == txtSoToChayLyThuyet)
                {
                    lblSoToInTong.Text = giayDeInPres.SoToChayTong().ToString();
                   
                    CapNhatTriGiaVoLabels();
                }
                if (tb == txtSoToChayBuHao)
                {
                    if (string.IsNullOrEmpty(txtSoToChayBuHao.Text))
                    {
                        txtSoToChayBuHao.Text = "0";
                    }
                    lblSoToInTong.Text = giayDeInPres.SoToChayTong().ToString();
                }
                if (tb == txtSoToChayTrenToLon)
                {
                    if (string.IsNullOrEmpty(txtSoToChayTrenToLon.Text))
                    {
                        txtSoToChayTrenToLon.Text = "1";
                    }
                    txtSoToGiayLon.Text = giayDeInPres.SoToGiayLon().ToString();
                    
                }
                if (tb == txtSoToGiayLon)
                {
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
            CapNhatTriGiaVoLabels();
        }
        private void CapNhatTriGiaVoLabels()
        {
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            //Console.WriteLine(String.Format(info, "{0:c}", value));
            lblSoToInTong.Text = giayDeInPres.SoToChayTong().ToString();
            txtSoToGiayLon.Text = giayDeInPres.SoToGiayLon().ToString();
            lblGiaBan.Text = string.Format(info, "{0:c}/tờ", this.GiaBan);
            lblThanhTien.Text = string.Format(info, "{0:c}/tờ", this.ThanhTien);
           
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

                txtTenGiayIn.Text = frm.GiayChon.TenGiayMoRong;
                
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
                    this.TenGiayIn = "Giấy khách";
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
            XuLyGiayKhachHangDua();
        }

        private void btnTinhSoConTrenToChay_Click(object sender, EventArgs e)
        {
            this.SoConTrenToChay = TinhToan.SoConTrenToChayDigi(this.ToChayRong, this.ToChayDai,
                            this.KichThuocSanPham.Rong, this.KichThuocSanPham.Dai);

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
       
    }

}
