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
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient
{
    public partial class GiaInOffsetForm : Form, IViewGiaInOffset
    {
        GiaInOffsetPresenter giaInPres;
        public GiaInOffsetForm(ThongTinBanDauChoGiaIn thongTinBanDau)
        {
            InitializeComponent();
            //
            this.IdHangKH = thongTinBanDau.IdHangKhachHang;
            this.SoToChay = thongTinBanDau.SoToChay;
            this.IdMayIn = thongTinBanDau.IdToIn_MayIn;
            this.IdBaiIn = thongTinBanDau.IdBaiIn;
            this.KhoToChay = thongTinBanDau.KhoToChay;
            giaInPres = new GiaInOffsetPresenter(this);
            //Nạp bảng giá vô combo
          
            
            //-event            
           
            txtSoLuongToChay.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiVanChuyen.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiCanhBai.KeyPress += new KeyPressEventHandler(InputValidator);

            txtKhoToGiayChay.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtPhiCanhBai.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtPhiVanChuyen.TextChanged += new EventHandler(TextBoxes_TextedChanged);

            rdbMotMat.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);           
            rdbTuTro.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbTuTroNhip.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbAB.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
           
            
        }
        #region implement Iview
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

        int _kieuIn = 0;
        public KieuInOffsetS KieuInOffset
        {
            get {
                if (rdbMotMat.Checked)
                    return KieuInOffsetS.MotMat;
                else if (rdbTuTro.Checked)
                    return KieuInOffsetS.TuTro;

                else if (rdbTuTroNhip.Checked)
                    return KieuInOffsetS.TuTroNhip;

                else if (rdbAB.Checked)
                    return KieuInOffsetS.AB;
                else
                    return KieuInOffsetS.MotMat;         

            }

            set {
                switch ( value)
                {
                    case KieuInOffsetS.MotMat:
                        rdbMotMat.Checked = true;
                        break;
                    case KieuInOffsetS.TuTro:
                        rdbTuTro.Checked = true;
                        break;
                    case KieuInOffsetS.TuTroNhip:
                        rdbTuTroNhip.Checked = true;
                        break;
                }
                     }
        }
        public string KhoToChay
        {
            get { return txtKhoToGiayChay.Text; }
            set { txtKhoToGiayChay.Text = value; }
        }
        public int SoTrangIn
        {
            get { return giaInPres.SoMatIn(); }
        }
        public int IdHangKH
        {
            get;
            set;
        }
        public int PhiVanChuyen
        {
            get { return int.Parse(txtPhiVanChuyen.Text); }
            set { txtPhiVanChuyen.Text = value.ToString(); }
        }
        public int PhiCanhBai
        {
            get { return int.Parse(txtPhiCanhBai.Text); }
            set { txtPhiCanhBai.Text = value.ToString(); }
        }

      
        public int IdMayIn
        {
            get;
            set;
        }
        public int SoToChay
        {
            get { return int.Parse(txtSoLuongToChay.Text); }
            set {txtSoLuongToChay.Text = value.ToString();}
        }
        public string TenHangKH
        {
            get { return txtTenHangKH.Text; }
            set { txtTenHangKH.Text = value; }
        }

        decimal _tienIn = 0;
        public decimal TienIn
        {
            get { return giaInPres.GiaInOffset(); }
            set { _tienIn = value; }
        }
        public string GiaTBTrangInfo 
        { 
            get {return string.Format("{0:0,0.00}đ/trang",
                giaInPres.GiaInOffset() / giaInPres.SoMatIn());}
        }
        public PhuongPhapInS PhuongPhapIn
        {
            get { return PhuongPhapInS.Offset; }
        }
        public MucGiaIn DocGiaIn
        {
            get { return giaInPres.DocGiaIn; }
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }

        #endregion
       
        
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                
                
                if (t == txtSoLuongToChay)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (t == txtPhiVanChuyen)//chỉ được nhập số chẵn 
                {
                    
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (t == txtPhiCanhBai)//chỉ được nhập số chẵn 
                {
                   
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
            }
        }
        private void GiaInForm_Load(object sender, EventArgs e)
        {
            
            //Ten hang KH
            if (this.IdHangKH > 0)
                this.TenHangKH = giaInPres.TenHangKH(this.IdHangKH);
            else
                this.TenHangKH = "";
            

            txtToInDigiChon.Text = giaInPres.TenMayInOffsetChon();
            rdbTuTroNhip.Checked = true;
            rdbTuTro.Checked = true;
            //Để thủe
            if (this.TinhTrangForm == FormStateS.View)
            {
                txtSoLuongToChay.Enabled = true;
                txtSoLuongToChay.ReadOnly = false;
            }
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            
        }
       
        private void TextBoxes_TextedChanged(object sender, EventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoLuongToChay)//
                {
                    if (string.IsNullOrEmpty(txtSoLuongToChay.Text.Trim()))
                        txtSoLuongToChay.Text = "0";
                    lblSoMatIn.Text = string.Format("{0:0,0} Mặt", giaInPres.SoMatIn());
                
                }
                if (t == txtPhiVanChuyen)//
                {
                    if (string.IsNullOrEmpty(txtPhiVanChuyen.Text.Trim()))
                        txtPhiVanChuyen.Text = "0";

                }
                if ( t == txtPhiCanhBai)//
                {
                    if (string.IsNullOrEmpty(txtPhiCanhBai.Text.Trim()))
                        txtPhiCanhBai.Text = "0";

                }
               
                //Cập nhật thành tiền
                this.TienIn = giaInPres.GiaInOffset();
                lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.TienIn);
            }
            
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
           
            if (string.IsNullOrEmpty(txtSoLuongToChay.Text))
                loiS.Add("Số lượng A4 có thể = 0 nhưng không thể rỗng");
            

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }
        private void RadioButtons_CheckChanged(object sender, EventArgs e)
        {
            RadioButton rb;
            if (sender is RadioButton)
            {
                rb = (RadioButton)sender;
                //Paper tab prod paper
                if (rb == rdbMotMat || rb == rdbTuTro || rb == rdbTuTroNhip || rb == rdbAB)//
                {
                    this.TienIn = giaInPres.GiaInOffset();
                    lblSoMatIn.Text = string.Format("{0:0,0} Mặt", giaInPres.SoMatIn());
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.TienIn);
                    
                }

            }
           
        }
        private void GiaInForm_FormClosing(object sender, FormClosingEventArgs e)
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
}
