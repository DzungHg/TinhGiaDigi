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
            get { return int.Parse(txtTongSoToChayO.Text); }
            set { txtTongSoToChayO.Text = value.ToString(); }
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
                    giaInPres.GiaInMotBaiOffset() / giaInPres.SoMatIn());
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


                if (t == txtTongSoToChayO)//chỉ được nhập số chẵn 
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

        private void TextBoxes_TextedChanged(object sender, EventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtTongSoToChayO)//
                {
                    if (string.IsNullOrEmpty(txtTongSoToChayO.Text.Trim()))
                        txtTongSoToChayO.Text = "0";
                    lblSoMatIn.Text = string.Format("{0:0,0} Mặt", giaInPres.SoMatIn());

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
                    lblSoMatIn.Text = string.Format("{0:0,0} Mặt", giaInPres.SoMatIn());
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
    }
}
