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
    public partial class GiayDeBoiForm : Form, IViewGiayDeBoi
    {
        GiayDeBoiPresenter giayDeBoiPres;
        public GiayDeBoiForm(ThongTinBanDauChoGiayIn thongTinBanDau, GiayDeBoi giayDeBoi)
        {
            InitializeComponent();
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.ThongTinBaiIn_CauHinh = thongTinBanDau.ThongTinCanThiet;
           
            this.IdHangKH = thongTinBanDau.IdHangKhachHang;
            
           
            
            
            if (thongTinBanDau.LaInDanhThiep) //bắt nút tính số con
                btnTinhSoConTrenToChay.Enabled = false;
            else
                btnTinhSoConTrenToChay.Enabled = true;
          
            giayDeBoiPres = new GiayDeBoiPresenter(this, giayDeBoi);                          
           
              //cập nhật khổ in đỡ
          
            
            //event
            txtSoToBoiBuHao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToBoiTrenToLon.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToBoiLyThuyet.KeyPress += new KeyPressEventHandler(InputValidator);
           
            txtToBoiRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToBoiCao.KeyPress += new KeyPressEventHandler(InputValidator);
           

            txtSoToBoiBuHao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToBoiTrenToLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToBoiLyThuyet.TextChanged += new EventHandler(TextBoxes_TextChanged);
           
            txtSoToGiayLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTenGiayBoi.TextChanged += new EventHandler(TextBoxes_TextChanged);
           
           
            lblSoToInTong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToBoiRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToBoiCao.TextChanged += new EventHandler(TextBoxes_TextChanged);

          
            txtSoToBoiBuHao.Leave += new EventHandler(TextBoxes_Leave);
            txtSoToBoiTrenToLon.Leave += new EventHandler(TextBoxes_Leave);
           
           
            
        }
        #region Implement Iview..

        public int ID { get; set; }
        public int IdBaiIn
        {
            get;
            set;
        }
       
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
        public string TenGiayBoi
        {
            get
            {
                return txtTenGiayBoi.Text;
            }
            set
            {
                txtTenGiayBoi.Text = value;
            }
        }

        public float GiayLonRong { get; set; }
        public float GiayLonCao { get; set; }
    
        public float ToBoiRong {  
            get
            {
                return float.Parse(txtToBoiRong.Text);
            }
            set
            {
                txtToBoiRong.Text = value.ToString();
            }
        }
        public float ToBoiCao
        { 
            get
            {
                return float.Parse(txtToBoiCao.Text); 
            }
            set
            {
                txtToBoiCao.Text = value.ToString() ;
            }
        } 
       
     
        public int SoLuongToBoiLyThuyet
        {
            get
            {
                return int.Parse(txtSoToBoiLyThuyet.Text);
            }
            set { txtSoToBoiLyThuyet.Text = value.ToString(); }
           
        }

        public int SoLuongToBoiBuHao
        {
            get
            {
                return int.Parse(txtSoToBoiBuHao.Text);
            }
            set
            {
                txtSoToBoiBuHao.Text = value.ToString();
            }
        }
        public int SoToChayTrenToLon
        {
            get
            {
                return int.Parse(txtSoToBoiTrenToLon.Text);
            }
            set
            {
                txtSoToBoiTrenToLon.Text = value.ToString();
            }
        }
        public int SoToGiayLon
        {
            get
            {
                return giayDeBoiPres.SoToGiayLon();
            }
         
        }
        public decimal GiaGiayBan
        {
            get { return giayDeBoiPres.GiaBanChoKhach(); }
        }
        public int SoLuongToBoiTong
        {
            get { return giayDeBoiPres.SoToBoiTongTong(); }          
        }

        public decimal ThanhTien
        {
            get { return giayDeBoiPres.ThanhTien(); }
        }
        public FormStateS TinhTrangForm { get; set; }
        #endregion
        private bool dataChanged = false;
        public GiayDeBoi DocGiayDeIn()
        {
            return giayDeBoiPres.DocGiayDeBoi();
        }


        private void ChuanBiGiayForm_Load(object sender, EventArgs e)
        {

            //Khóa controls theo formState
            switch (this.TinhTrangForm)
            {
                case FormStateS.View:
                    KhoaCacControlsChoView();
                    break;
               
            }

            lblTieuDeForm.Text = this.Text;
           
            //Bật tắt nút Nhận
            BatTatNutNhanTheoDieuKien();
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
                if (t == txtSoToBoiBuHao || t == txtSoToBoiLyThuyet || t == txtSoToBoiTrenToLon    )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                
                if (t == txtToBoiRong || t == txtToBoiCao 
                   )
                    //nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }

               
                 
            }
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {                     
           
            dataChanged = true;
            BatTatNutTinhToan();
           
        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {

            TextBox tb;
           
            
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
              

                if (tb == txtToBoiRong)
                {
                    if (string.IsNullOrEmpty(txtToBoiRong.Text.Trim()))
                    {
                        this.ToBoiRong = 5;
                    }
                    TinhToBoiTrenToLon();
                }

                if (tb == txtToBoiCao)
                {
                    if (string.IsNullOrEmpty(txtToBoiCao.Text.Trim()))
                    {
                        this.ToBoiCao =10;
                    }
                    TinhToBoiTrenToLon();
                }
                
                if (tb == txtSoToBoiBuHao)
                {
                    if (string.IsNullOrEmpty(txtSoToBoiBuHao.Text))
                    {
                        this.SoLuongToBoiBuHao = 1;
                    }
                    //Cập nhật số tờ chạy tổng
                    lblSoToInTong.Text = giayDeBoiPres.SoToBoiTongTong().ToString();
                }
                
                

                if (tb == txtSoToBoiLyThuyet)
                {
                    lblSoToInTong.Text = giayDeBoiPres.SoToBoiTongTong().ToString();

                    CapNhatTriGiaVoLabels();
                }
                
                if (tb == txtSoToBoiTrenToLon)
                {
                    if (string.IsNullOrEmpty(txtSoToBoiTrenToLon.Text))
                    {
                        txtSoToBoiTrenToLon.Text = "1";
                    }
                    txtSoToGiayLon.Text = giayDeBoiPres.SoToGiayLon().ToString();
                    CapNhatTriGiaVoLabels();
                }


               

            }
           
            
        }
        private void CapNhatTriGiaVoLabels()
        {
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            //Console.WriteLine(String.Format(info, "{0:c}", value));
            lblSoToInTong.Text = giayDeBoiPres.SoToBoiTongTong().ToString();
            txtSoToGiayLon.Text = giayDeBoiPres.SoToGiayLon().ToString();
            lblGiaBan.Text = string.Format(info, "{0:c}/tờ", this.GiaGiayBan);
            lblThanhTien.Text = string.Format(info, "{0:c}/tờ", this.ThanhTien);
           
           
        }
        private void KhoaCacControlsChoView()
        {
            
            txtToBoiRong.Enabled = false;
            txtToBoiCao.Enabled = false;
          
            txtSoToBoiLyThuyet.Enabled = false;
            txtSoToBoiBuHao.Enabled = false;
            txtSoToBoiTrenToLon.Enabled = false;
        }
      
       
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            

           
            if (string.IsNullOrEmpty(txtSoToBoiTrenToLon.Text))
                loiS.Add("Số tờ giấy lớn trống");
            if (string.IsNullOrEmpty(txtSoToBoiBuHao.Text))
                loiS.Add("Cần để 0 chứ không thể rỗng");
         
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
            var thongTinGiayChon =giayDeBoiPres.TenGiayDeIn();

            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.Get, this.IdHangKH, thongTinGiayChon);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Cập nhật IdGiay trước
                if (frm.GiayChon != null)
                    this.IdGiay = frm.GiayChon.ID;
                //Cập nhật tiếp các chi tiết
                
                
                giayDeBoiPres.CapNhatGiayDeBoi();
                CapNhatMotSoTong();
                CapNhatTriGiaVoLabels();
                //Bật tắt nút nhận
                BatTatNutNhanTheoDieuKien();
                
            }
           
        }
       

        private void chkGiayKhach_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void TinhToBoiTrenToLon()
        {
            this.SoToChayTrenToLon = TinhToan.SoConTrenToChayDigi(this.GiayLonRong, this.GiayLonCao,
                           this.ToBoiRong, this.ToBoiCao);
        }
        private void btnTinhSoConTrenToChay_Click(object sender, EventArgs e)
        {
            TinhToBoiTrenToLon();
            CapNhatMotSoTong();

        }
        private void BatTatNutNhanTheoDieuKien()
        {
            var kq = true;
            if (this.IdGiay > 0)
            {
                if (this.ToBoiRong <=0 || ToBoiCao <= 0)
                    kq  = false;
                if (this.SoToChayTrenToLon <= 0)
                    kq = false;
            }
            else
                kq = false;

            btnNhan.Enabled = kq;

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
           txtSoToBoiLyThuyet.Text = giayDeBoiPres.SoToBoiTongTong().ToString();
           txtSoToGiayLon.Text = giayDeBoiPres.SoToGiayLon().ToString();
           TinhToBoiTrenToLon();
           //txtSoToBoiLyThuyet.Text = 
       }
       private void btnTinh_Click(object sender, EventArgs e)
       {
           CapNhatMotSoTong();
           CapNhatTriGiaVoLabels();
           //Tắt nút tính
           dataChanged = false;
           BatTatNutTinhToan();
       }
    }

}
