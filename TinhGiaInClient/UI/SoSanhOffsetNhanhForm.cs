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

namespace TinhGiaInClient.UI
{
    public partial class SoSanhOffsetNhanhForm : Form, IViewSoSanhOffsetNhanh
    {
        SoSanhOffsetNhanhPresenter giaInPres;
        public SoSanhOffsetNhanhForm()
        {
            InitializeComponent();
            //

            giaInPres = new SoSanhOffsetNhanhPresenter(this);
            //Nạp bảng giá vô combo
            LoadMayIn();
            //Reset form
            giaInPres.ResetForm();
            //-event            

            txtTongSoToChayO.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiVanChuyen.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiCanhBai.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaGiayD.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaGiayO.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLuongSP.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoSPTrenToChayDigi.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoSPTrenToChayOffset.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayLyThuyetD.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayLyThuyetO.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayBuHaoD.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayBuHaoO.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayTrenToLonD.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayTrenToLonO.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLuotInO.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiVanChuyen.KeyPress += new KeyPressEventHandler(InputValidator);
            txtPhiCanhBai.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSanPhamRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSanPhamCao.KeyPress += new KeyPressEventHandler(InputValidator);

            txtToChayRongD.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToChayCaoD.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToChayRongO.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToChayCaoO.KeyPress += new KeyPressEventHandler(InputValidator);

            

            txtSoLuongSP.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtToChayRongD.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtToChayCaoD.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtToChayRongO.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtToChayCaoO.TextChanged += new EventHandler(TextBoxes_TextedChanged);

            txtSoSPTrenToChayDigi.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoSPTrenToChayOffset.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoToChayLyThuyetD.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoToChayBuHaoO.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoToChayBuHaoD.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoToChayBuHaoO.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoToChayTrenToLonD.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoToChayTrenToLonO.TextChanged += new EventHandler(TextBoxes_TextedChanged);

            txtPhiCanhBai.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtPhiVanChuyen.TextChanged += new EventHandler(TextBoxes_TextedChanged);

            rdbMotMat.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbTuTro.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbTuTroNhip.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbAB.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);

            cboMayInDigi.SelectedIndexChanged += new EventHandler(comboBoxS_SelectedIndexChanged);
            cboMayInOffset.SelectedIndexChanged += new EventHandler(comboBoxS_SelectedIndexChanged);

        }
    
        #region implement Iview
        int _idMayInOffsetChon;
        public int IdMayInOffsetChon
        {
            get
            {
                if (cboMayInOffset.SelectedValue != null)
                    int.TryParse(cboMayInOffset.SelectedValue.ToString(),
                        out _idMayInOffsetChon);
                return _idMayInOffsetChon;
            }
            set { _idMayInOffsetChon = value; }
        }

        public int SoSanPhamTrenToChayDigi 
        {
            get { return int.Parse(txtSoSPTrenToChayDigi.Text); }
            set { txtSoSPTrenToChayDigi.Text = value.ToString(); }
        }
        public int SoSanPhamTrenToChayOffset 
        {
            get { return int.Parse(txtSoSPTrenToChayOffset.Text); }
            set { txtSoSPTrenToChayOffset.Text = value.ToString(); }
        }
        public MotHaiMat KieuInDigi
        {
            get
            {
                if (rdbMotMatDigi.Checked)
                    return MotHaiMat.MotMat;
                else if (rdbHaiMatDigi.Checked)
                    return MotHaiMat.HaiMat;
                else
                    return MotHaiMat.MotMat;

            }
            set
            {
                switch (value)
                {
                    case MotHaiMat.MotMat:
                        rdbMotMatDigi.Checked = true;
                        break;
                    case MotHaiMat.HaiMat:
                        rdbHaiMatDigi.Checked = true;
                        break;
                }
            }
        }
        public KieuInOffsetS KieuInOffset
        {
            get
            {
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

            set
            {
                switch (value)
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

        public int SoToChayBuHaoDigi
        {
            get { return int.Parse(txtSoToChayBuHaoD.Text); }
            set { txtSoToChayBuHaoD.Text = value.ToString(); }
        }
        public int GiaGiayOffset
        {
            get { return int.Parse(txtGiaGiayO.Text); }
            set { txtGiaGiayO.Text = value.ToString(); }
        }
        public int PhiVanChuyenOffset
        {
            get { return int.Parse(txtPhiVanChuyen.Text); }
            set { txtPhiVanChuyen.Text = value.ToString(); }
        }
        public int PhiCanhBaiOffset
        {
            get { return int.Parse(txtPhiCanhBai.Text); }
            set { txtPhiCanhBai.Text = value.ToString(); }
        }

        int _idMayInDigiChon;
        public int IdMayInDiGiChon
        {
            get
            {
                if (cboMayInDigi.SelectedValue != null)
                    int.TryParse(cboMayInDigi.SelectedValue.ToString(),
                        out _idMayInDigiChon);
                return _idMayInDigiChon;
            }
            set { _idMayInDigiChon = value; }
        }
        public int SoToChayLyThuyetDigi
        {
            get { return int.Parse(txtSoToChayLyThuyetD.Text); }
            set { txtSoToChayLyThuyetD.Text = value.ToString(); }
        }
        public string TenGiayOfset
        {
            get { return txtTenGiayOffset.Text; }
            set { txtTenGiayOffset.Text = value; }
        }

        decimal _tienIn = 0;
        public decimal PhiInOffset
        {
            get { return giaInPres.GiaInMotBaiOffset(); }
            set { _tienIn = value; }
        }
        public string GiaTBTrangInfo
        {
            get
            {
                return string.Format("{0:0,0.00}đ/trang",
                    giaInPres.GiaInMotBaiOffset() / giaInPres.SoMatInOffset());
            }
        }
        public PhuongPhapInS PhuongPhapIn
        {
            get { return PhuongPhapInS.Offset; }
        }


        public string TieuDe
        {
            get
            {
                return txtTieuDe.Text;
            }
            set
            {
                txtTieuDe.Text = value;
            }
        }

        public float SanPhamRong
        {
            get
            {
                return float.Parse(txtSanPhamRong.Text);
            }
            set
            {
                txtSanPhamRong.Text = value.ToString();
            }
        }

        public float SanPhamCao
        {
            get
            {
                return float.Parse(txtSanPhamCao.Text);
            }
            set
            {
                txtSanPhamCao.Text = value.ToString();
            }
        }

        public int SoLuongSP
        {
            get
            {
                return int.Parse(txtSoLuongSP.Text);
            }
            set
            {
                txtSoLuongSP.Text = value.ToString();
            }
        }
        public int IdGiayDiGiChon { get; set; }
        public int IdGiayOffsetChon { get; set; }
        public float KhoGiayRongDigi { get; set; }
        public float KhoGiayCaoDigi { get; set; }
        public float KhoGiayRongOffset { get; set; }
        public float KhoGiayCaoOffset { get; set; }
        public int GiaGiayDigi
        {
            get
            {
                return int.Parse(txtGiaGiayD.Text);
            }
            set
            {
                txtGiaGiayD.Text = value.ToString();
            }
        }

        public string TenGiayDigi
        {
            get
            {
                return txtTenGiayDigi.Text;
            }
            set
            {
                txtTenGiayDigi.Text = value;
            }
        }

        public float ToChayRongDigi
        {
            get
            {
                return float.Parse(txtToChayRongD.Text);
            }
            set
            {
                txtToChayRongD.Text = value.ToString();
            }
        }

        public float ToChayCaoDigi
        {
            get
            {
                return float.Parse(txtToChayCaoD.Text);
            }
            set
            {
                txtToChayCaoD.Text = value.ToString();
            }
        }

        public float ToChayRongOffset
        {
            get
            {
                return float.Parse(txtToChayRongO.Text);
            }
            set
            {
                txtToChayRongO.Text = value.ToString();
            }
        }

        public float ToChayCaoOffset
        {
            get
            {
                return float.Parse(txtToChayCaoO.Text);
            }
            set
            {
                txtToChayCaoO.Text = value.ToString();
            }
        }

        public int SoToChayLyThuyetOffset
        {
            get
            {
                return int.Parse(txtSoToChayLyThuyetO.Text);
            }
            set
            {
                txtSoToChayLyThuyetO.Text = value.ToString();
            }
        }



        public int SoToChayBuHaoOffset
        {
            get
            {
                return int.Parse(txtSoToChayBuHaoO.Text);
            }
            set
            {
                txtSoToChayBuHaoO.Text = value.ToString();
            }
        }

        public int TongSoToChayDigi
        {
            get
            {
                return int.Parse(txtTongSoToChayD.Text);
            }
            set
            {
                txtTongSoToChayD.Text = value.ToString();
            }
        }

        public int TongSoToChayOffset
        {
            get
            {
                return int.Parse(txtTongSoToChayO.Text);
            }
            set
            {
                txtTongSoToChayO.Text = value.ToString();
            }
        }

        public int SoToChayTrenToLonDigi
        {
            get
            {
                return int.Parse(txtSoToChayTrenToLonD.Text);
            }
            set
            {
                txtSoToChayTrenToLonD.Text = value.ToString();
            }
        }

        public int SoToChayTrenToLonOffset
        {
            get
            {
                return int.Parse(txtSoToChayTrenToLonO.Text);
            }
            set
            {
                txtSoToChayTrenToLonO.Text = value.ToString();
            }
        }

        public int TongSoToGiayLonDigi
        {
            get
            {
                return int.Parse(txtTongSoToGiayLonD.Text);
            }
            set
            {
                txtTongSoToGiayLonD.Text = value.ToString();
            }
        }

        public int TongSoToGiayLonOffset
        {
            get
            {
                return int.Parse(txtTongSoToGiayLonO.Text);
            }
            set
            {
                txtTongSoToGiayLonO.Text = value.ToString();
            }
        }

        public int SoLuotInOffset
        {
            get
            {
                return int.Parse(txtSoLuotInO.Text);
            }
            set
            {
                txtSoLuotInO.Text = value.ToString();

            }
        }

        public decimal PhiGiayOffset
        {
            get
            {
                return decimal.Parse(txtPhiGiayO.Text);
            }
            set
            {
                txtPhiGiayO.Text = value.ToString();
            }
        }

        public decimal PhiGiayDigi
        {
            get
            {
                return decimal.Parse(txtPhiGiayD.Text);
            }
            set
            {
                txtPhiGiayD.Text = value.ToString();
            }
        }

        public decimal PhiInDigi
        {
            get
            {
                return decimal.Parse(txtPhiInD.Text);
            }
            set
            {
                txtPhiInD.Text = value.ToString();
            }
        }

        public decimal TongPhiDigi
        {
            get
            {
                return decimal.Parse(txtTongPhiD.Text);
            }
            set
            {
                txtTongPhiD.Text = value.ToString();

            }
        }

        public decimal TongPhiOffset
        {
            get
            {
                return decimal.Parse(txtTongPhiO.Text);
            }
            set
            {
                txtTongPhiO.Text = value.ToString();

            }
        }
        #endregion

        private void LoadMayIn()
        {
            cboMayInDigi.DataSource = giaInPres.MayInDigiS();
            cboMayInDigi.ValueMember = "ID";
            cboMayInDigi.DisplayMember = "Ten";

            cboMayInOffset.DataSource = giaInPres.MayInOffsetS();
            cboMayInOffset.ValueMember = "ID";
            cboMayInOffset.DisplayMember = "TenMoRong";
        }

        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;

                
                if (t == txtTongSoToChayO || t == txtGiaGiayD ||
                    t == txtGiaGiayO || t == txtSoLuongSP ||
                    t == txtSoSPTrenToChayDigi || t == txtSoSPTrenToChayOffset ||
                    t == txtSoToChayLyThuyetD || t == txtSoToChayLyThuyetO ||
                    t == txtSoToChayBuHaoD || t == txtSoToChayBuHaoO||
                    t == txtSoToChayTrenToLonD || t == txtSoToChayTrenToLonO ||
                    t == txtSoLuotInO || t == txtPhiVanChuyen ||
                    t == txtPhiCanhBai)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (t == txtSanPhamRong || t == txtSanPhamCao ||
                    t == txtToChayRongD || t == txtToChayCaoD ||
                    t == txtToChayRongO || t == txtToChayCaoO) //Cho nhập số thập phân
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
            }
        }
        private void GiaInForm_Load(object sender, EventArgs e)
        {
            //Bẩy thay đổi
            cboMayInDigi.SelectedIndex = -1;
            cboMayInDigi.SelectedIndex = 0;

            cboMayInOffset.SelectedIndex = -1;
            cboMayInOffset.SelectedIndex = 0;
            //

            rdbTuTroNhip.Checked = true;
            rdbTuTro.Checked = true;

        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {

        }
        //Digi
        private void CapNhatSoToToChayLyThuyetDigi()
        {
            this.SoToChayLyThuyetDigi = giaInPres.SoToChayLyThuyetDigi();
        }
        private void CapNhatTongSoToToChayDigi()
        {
            this.TongSoToChayDigi = giaInPres.TongSoToChayDigi();
        }
        private void CapNhatTongSoToGiayLonDigi()
        {
            this.TongSoToGiayLonDigi = giaInPres.TongSoToGiayLonDigi();
        }
        //offset
        private void CapNhatSoToToChayLyThuyetOffset()
        {
            this.SoToChayLyThuyetOffset = giaInPres.SoToChayLyThuyetOffset();
        }
        private void CapNhatTongSoToToChayOffset()
        {
            this.TongSoToChayOffset = giaInPres.TongSoToChayOffset();
        }
        private void CapNhatTongSoToGiayLonOffset()
        {
            this.TongSoToGiayLonOffset = giaInPres.TongSoToGiayLonOffset();
        }
        private void TextBoxes_TextedChanged(object sender, EventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                if (t == txtSoLuongSP)
                    if (!string.IsNullOrEmpty(txtSoLuongSP.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatSoToToChayLyThuyetDigi();
                    }
                //Digi
                if (t == txtToChayRongD)
                    if (!string.IsNullOrEmpty(txtToChayRongD.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatSoToToChayLyThuyetDigi();
                        //
                    }
                if (t == txtToChayCaoD)
                    if (!string.IsNullOrEmpty(txtToChayCaoD.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatSoToToChayLyThuyetDigi();
                        //
                    }
                if (t == txtSoSPTrenToChayDigi)
                    if (!string.IsNullOrEmpty(txtSoSPTrenToChayDigi.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatSoToToChayLyThuyetDigi();
                        //
                        //MessageBox.Show(giaInPres.SoToChayLyThuyetDigi().ToString());
                    }
                if (t == txtSoToChayLyThuyetD)
                    if (!string.IsNullOrEmpty(txtSoToChayLyThuyetD.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatTongSoToToChayDigi();
                        //
                    }
                if (t == txtSoToChayBuHaoD)
                    if (!string.IsNullOrEmpty(txtSoToChayBuHaoD.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatTongSoToToChayDigi();
                        //
                    }

                if (t == txtSoToChayTrenToLonD)
                    if (!string.IsNullOrEmpty(txtSoToChayTrenToLonD.Text.Trim()))
                    {
                        //Cập nhật
                        CapNhatTongSoToGiayLonDigi();
                    }

                //Offset
                if (t == txtToChayRongO)
                    if (!string.IsNullOrEmpty(txtToChayRongO.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatSoToToChayLyThuyetOffset();
                        //
                    }
                if (t == txtToChayCaoO)
                    if (!string.IsNullOrEmpty(txtToChayCaoO.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatSoToToChayLyThuyetOffset();
                        //
                    }
                if (t == txtSoSPTrenToChayOffset)
                    if (!string.IsNullOrEmpty(txtSoSPTrenToChayOffset.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatSoToToChayLyThuyetOffset();
                        //
                        //MessageBox.Show(giaInPres.SoToChayLyThuyetDigi().ToString());
                    }
                if (t == txtSoToChayLyThuyetO)
                    if (!string.IsNullOrEmpty(txtSoToChayLyThuyetO.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatTongSoToToChayOffset();
                        //
                    }
                if (t == txtSoToChayBuHaoO)
                    if (!string.IsNullOrEmpty(txtSoToChayBuHaoO.Text.Trim()))
                    {
                        //Cập nhật số tờ chạy lý thuyết digi
                        CapNhatTongSoToToChayOffset();
                        //
                    }

                if (t == txtSoToChayTrenToLonO)
                    if (!string.IsNullOrEmpty(txtSoToChayTrenToLonO.Text.Trim()))
                    {
                        //Cập nhật
                        CapNhatTongSoToGiayLonOffset();
                    }
                if (t == txtTongSoToChayO)//
                {
                    if (string.IsNullOrEmpty(txtTongSoToChayO.Text.Trim()))
                        txtTongSoToChayO.Text = "0";
                    lblSoMatIn.Text = string.Format("{0:0,0} Mặt", giaInPres.SoMatInOffset());

                }
                if (t == txtPhiVanChuyen)//
                {
                    if (string.IsNullOrEmpty(txtPhiVanChuyen.Text.Trim()))
                        txtPhiVanChuyen.Text = "0";

                }
                if (t == txtPhiCanhBai)//
                {
                    if (string.IsNullOrEmpty(txtPhiCanhBai.Text.Trim()))
                        txtPhiCanhBai.Text = "0";
                }

                //Cập nhật thành tiền
                this.PhiInOffset = giaInPres.GiaInMotBaiOffset();
                //lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.PhiInOffset);
            }

        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(txtTongSoToChayO.Text))
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
                    this.PhiInOffset = giaInPres.GiaInMotBaiOffset();
                    lblSoMatIn.Text = string.Format("{0:0,0} Mặt", giaInPres.SoMatInOffset());
                    //lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.PhiInOffset);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBoxS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb;
            if (sender is ComboBox)
            {
                cb = (ComboBox)sender;
                if (cb == cboMayInDigi)
                {
                    giaInPres.CapNhatKhoToChayDigi();
                }
                if (cb == cboMayInOffset)
                {
                    giaInPres.CapNhatKhoToChayOffset();
                }
            }
        }

        private void btnLayGiayDigi_Click(object sender, EventArgs e)
        {
            //var thongTinGiayChon =giayDeBoiPres.TenGiayDeIn();

            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.Get, 0, this.TenGiayDigi);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Cập nhật IdGiay trước
                if (frm.GiayChon != null)
                {
                    this.IdGiayDiGiChon = frm.GiayChon.ID;
                    //Cập nhật tiếp các chi tiết
                    giaInPres.CapNhatChiTietGiayDigi();
                }
            }


        }

        private void btnLayGiayOffset_Click(object sender, EventArgs e)
        {
            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.Get, 0, this.TenGiayDigi);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Cập nhật IdGiay trước
                if (frm.GiayChon != null)
                {
                    this.IdGiayOffsetChon = frm.GiayChon.ID;
                    giaInPres.CapNhatChiTietGiayOffset();
                }
                //Cập nhật tiếp các chi tiết
            }
        }

        private void btnLayKichThuocSP_Click(object sender, EventArgs e)
        {
            KhoSanPhamSForm frm = new KhoSanPhamSForm(FormStateS.Get);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Khổ Sản phẩm";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.SanPhamRong = frm.Rong;
                this.SanPhamCao = frm.Cao;
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            giaInPres.ResetForm();
            //tiếp gì đó
        }

        private void btnTinhSPTrenToChayDigi_Click(object sender, EventArgs e)
        {
            this.SoSanPhamTrenToChayDigi = giaInPres.SoConTrenToLon(this.ToChayRongDigi,
                                this.ToChayCaoDigi, this.SanPhamRong, this.SanPhamCao);
        }

        private void btnTinhSPTrenToChayOffset_Click(object sender, EventArgs e)
        {
            this.SoSanPhamTrenToChayOffset = giaInPres.SoConTrenToLon(this.ToChayRongOffset,
                                this.ToChayCaoOffset, this.SanPhamRong, this.SanPhamCao);
        }

        private void btnTinhToChayTrenToLonDigi_Click(object sender, EventArgs e)
        {
            this.SoToChayTrenToLonDigi = 1;
            if (this.IdGiayDiGiChon > 0)
                this.SoToChayTrenToLonDigi = giaInPres.SoConTrenToLon(this.KhoGiayRongDigi,
                               this.KhoGiayCaoDigi, this.ToChayRongDigi, this.ToChayCaoDigi);
        }

        private void btnTinhToChayTrenToLonOffset_Click(object sender, EventArgs e)
        {
            this.SoToChayTrenToLonOffset = 1;
            if (this.IdGiayDiGiChon > 0)
                this.SoToChayTrenToLonOffset = giaInPres.SoConTrenToLon(this.KhoGiayRongOffset,
                               this.KhoGiayCaoOffset, this.ToChayRongOffset, this.ToChayCaoOffset);
        }
    }
}
