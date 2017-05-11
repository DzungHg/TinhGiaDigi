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
using TinhGiaInClient.Model;

namespace TinhGiaInClient
{
    public partial class CauHinhSPForm : Form, IViewSanPhamPhang
    {
        public CauHinhSPForm( int formState, CauHinhSanPham cauHinhSP = null)
        {
            InitializeComponent();
            trienKhaiSPPre = new TrienKhaiSanPhamPresenter(this);
            this.formState = formState;
            //Nếu là sửa
            if (cauHinhSP != null)
            {
                this.IdCauHinhSP = cauHinhSP.IDCauHinh;                
                this.KhoCatRong = cauHinhSP.KhoSP.KhoCatRong;
                this.KhoCatCao = cauHinhSP.KhoSP.KhoCatCao;
                this.TranLeTren = cauHinhSP.TranLeTren;
                this.TranLeDuoi = cauHinhSP.TranLeDuoi;
                this.TranLeTrong = cauHinhSP.TranLeTrong;
                this.TranLeNgoai = cauHinhSP.TranLeNgoai;
                this.LeTren = cauHinhSP.LeTren;
                this.LeDuoi = cauHinhSP.LeDuoi;
                this.LeTrong = cauHinhSP.LeTrong;
                this.LeNgoai = cauHinhSP.LeNgoai;
                //this.SoLuong = cauHinhSP.SoLuong;

            }
            else
            {
                //Trình bày mặc định
                this.trienKhaiSPPre.TrinhBayMacDinh();
            }
            //Các events
            txtKhoCatRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtKhoCatCao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtLeTren.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtLeDuoi.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtLeTrong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtLeNgoai.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTranLeTren.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTranLeDuoi.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTranLeTrong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTranLeNgoai.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtKhoCatRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtKhoCatCao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtLeTren.KeyPress += new KeyPressEventHandler(InputValidator);
            txtLeDuoi.KeyPress += new KeyPressEventHandler(InputValidator);
            txtLeTrong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtLeNgoai.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTranLeTren.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTranLeDuoi.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTranLeTrong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtTranLeNgoai.KeyPress += new KeyPressEventHandler(InputValidator);
        }
        #region Thi công IviewSP
        public string ThongTinBaiIn 
        {
            get { return txtDienGiaiBaiIn.Text; }
            set {txtDienGiaiBaiIn.Text = value;}
        }
        public int IdCauHinhSP { get; set; }
        public string TenCauHinh
        {
            get
            {
                return txtTenSanPham.Text;
            }
            set
            {
                txtTenSanPham.Text = value;
            }
        }

        public float KhoCatRong
        {
            get
            {
                return float.Parse(txtKhoCatRong.Text);
            }
            set
            {
                txtKhoCatRong.Text = value.ToString();
            }
        }

        public float KhoCatCao
        {
            get
            {
                return float.Parse(txtKhoCatCao.Text); 
            }
            set
            {
                txtKhoCatCao.Text = value.ToString();
            }
        }

        public float TranLeTren
        {
            get
            {
                return float.Parse(txtTranLeTren.Text);
            }
            set
            {
                txtTranLeTren.Text = value.ToString();
            }
        }

        public float TranLeDuoi
        {
            get
            {
                return float.Parse(txtTranLeDuoi.Text);
            }
            set
            {
                txtTranLeDuoi.Text = value.ToString();
            }
        }

        public float TranLeTrong
        {
            get
            {
                return float.Parse(txtTranLeTrong.Text);
            }
            set
            {
                txtTranLeTrong.Text = value.ToString();
            }
        }

        public float TranLeNgoai
        {
            get
            {
                return float.Parse(txtTranLeNgoai.Text);
            }
            set
            {
                txtTranLeNgoai.Text = value.ToString();
            }
        }

        public float LeTren
        {
            get
            {
                return float.Parse(txtLeTren.Text);
            }
            set
            {
                txtLeTren.Text = value.ToString();
            }
        }

        public float LeDuoi
        {
            get
            {
                return float.Parse(txtLeDuoi.Text);
            }
            set
            {
                txtLeDuoi.Text = value.ToString();
            }
        }

        public float LeTrong
        {
            get
            {
                return float.Parse(txtLeTrong.Text);
            }
            set
            {
                txtLeTrong.Text = value.ToString();
            }
        }

        public float LeNgoai
        {
            get
            {
                return float.Parse(txtLeNgoai.Text);
            }
            set
            {
                txtLeNgoai.Text = value.ToString();
            }
        }
        
        public float KhoRongGomLe
        {
            get;
            set;
        }
        
        public float KhoCaoGomLe
        {
            get;
            set;
        }
        public int SoLuong 
        {
            get {return int.Parse(txtSoLuong.Text);}
            set {txtSoLuong.Text = value.ToString(); }
        }
        public int IdBaiIn { get; set; }
        #endregion
        //Field Form
        public int formState;
        public TrienKhaiSanPhamPresenter trienKhaiSPPre;
        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void txtProd_CutWidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProd_CutHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReverseProdSize_Click(object sender, EventArgs e)
        {
            var tmp = this.KhoCatCao;
            this.KhoCatCao = this.KhoCatRong;
            this.KhoCatRong = tmp;
        }

        private void btnGetProdTemplate_Click(object sender, EventArgs e)
        {
            KhoSanPhamSForm frm = new KhoSanPhamSForm((int)Enumss.FormState.Get);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Lấy khổ SP";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.KhoCatRong = frm.ChieuRong;
                this.KhoCatCao = frm.ChieuCao;                
            }
        }

        private void TrienKhaiSanPhamForm_Load(object sender, EventArgs e)
        {
           
        }
        private void CapNhatLabels()
        {
            trienKhaiSPPre.KiemTraTranLe_vs_Le();
            lblKhoGomLe.Text = string.Format("{0}x{1}cm", this.KhoRongGomLe, this.KhoCaoGomLe);
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtKhoCatRong || tb == txtKhoCatCao ||
                    tb == txtLeTren || tb == txtLeDuoi || tb == txtLeTrong
                    || tb == txtLeNgoai || tb == txtTranLeTren || tb == txtTranLeDuoi
                    || tb == txtTranLeTrong || tb == txtTranLeNgoai)

                CapNhatLabels(); ;//Kiểm và cập nhật luôn
                
            }
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                
                if (tb == txtKhoCatRong || tb == txtKhoCatCao)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                
                if (tb == txtKhoCatRong || tb == txtKhoCatCao ||
                    tb == txtLeTren || tb == txtLeDuoi || tb == txtLeTrong
                    || tb == txtLeNgoai || tb == txtTranLeTren || tb == txtTranLeDuoi
                    || tb == txtTranLeTrong || tb == txtTranLeNgoai)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
               
            }
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(txtKhoCatCao.Text))
                loiS.Add("Khổ cắt  Cao rỗng");
            if (string.IsNullOrEmpty(txtKhoCatRong.Text))
                loiS.Add("Khổ cắt rộng rỗng");

            if (string.IsNullOrEmpty(txtLeTren.Text))
                loiS.Add("Lề Trên trống");
            if (string.IsNullOrEmpty(txtLeDuoi.Text))
                loiS.Add("Lề Dưới trống");
            if (string.IsNullOrEmpty(txtLeTrong.Text))
                loiS.Add("Lề Trong trống");
            if (string.IsNullOrEmpty(txtLeNgoai.Text))
                loiS.Add("Lề Ngoài trống");

            if (string.IsNullOrEmpty(txtTranLeTren.Text))
                loiS.Add("Tràn lề Trên trống");
            if (string.IsNullOrEmpty(txtTranLeDuoi.Text))
                loiS.Add("Tràn lề Dưới trống");
            if (string.IsNullOrEmpty(txtTranLeTrong.Text))
                loiS.Add("Tràn lề Trong trống");
            if (string.IsNullOrEmpty(txtTranLeNgoai.Text))
                loiS.Add("Tràn lề Ngoài trống");

            if (string.IsNullOrEmpty(txtTenSanPham.Text))
                loiS.Add("Tên bị rỗng");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }
        private void btnLeBangTranLe_Click(object sender, EventArgs e)
        {
            trienKhaiSPPre.DatLeBangTranLe();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void TrienKhaiCauHinhSPForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnThongTinGiay_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txtTranLeTren_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTranLeNgoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTranLeTrong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTranLeDuoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void lblKhoGomLe_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtLeDuoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLeTrong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLeNgoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLeTren_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
    }
}
