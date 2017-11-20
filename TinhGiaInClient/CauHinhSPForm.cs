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
using TinhGiaInClient.Common.Enum;
using TinhGiaInClient.Common;
using TinhGiaInClient.UI;

namespace TinhGiaInClient
{
    public partial class CauHinhSPForm : Form, IViewCauHinhSanPham
    {
        public CauHinhSPForm(ThongTinBanDauChoCauHinhSP thongTinBanDau, CauHinhSanPham cauHinhSP)
        {
            InitializeComponent();
            
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.SoLuong = thongTinBanDau.SoLuongSanPham;
            this.DonViTinh = thongTinBanDau.DonViTinh;
            this.ThongTinBaiIn = thongTinBanDau.YeuCauBaiIn;

            cauHinhSanPhamPres = new CauHinhSanPhamPresenter(this, cauHinhSP);

            if (this.PhuongPhapIn != PhuongPhapInS.KhongIn)
            {
                LoadDanhSachToChay();                
                if (this.TinhTrangForm == FormStateS.Edit)
                {
                    //Phải chọn tờ in lúc này 
                    this.IdToInChon = cauHinhSP.IdMayIn;
                }
            }
            //Nếu là sửa
           
            
            //Các events
            rdbToner.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);
            rdbKhongIn.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);

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
        CauHinhSanPhamPresenter cauHinhSanPhamPres;
        #region Thi công IviewSP
        public string ThongTinBaiIn 
        {
            get { return txtDienGiaiBaiIn.Text; }
            set {txtDienGiaiBaiIn.Text = value;}
        }
        public int IdCauHinhSP { get; set; }
       

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
        
        
        public int SoLuong 
        {
            get {return int.Parse(txtSoLuong.Text);}
            set {txtSoLuong.Text = value.ToString(); }
        }
        public string DonViTinh
        {
            get { return lblDonViTinh.Text; }
            set { lblDonViTinh.Text = value; }
        }
        public int IdBaiIn { get; set; }

        int _idToInChon = 0;
        public int IdToInChon
        {
            get
            {
                if (lstMayIn.SelectedItems.Count > 0)
                    int.TryParse(lstMayIn.SelectedItems[0].Text, out _idToInChon);
                return _idToInChon;
            }
            set
            {
                _idToInChon = value;
                //Làm chọn lstView được không? Được
                if (_idToInChon > 0 && lstMayIn.Items.Count > 0)
                {
                    var item = lstMayIn.FindItemWithText(_idToInChon.ToString());
                    lstMayIn.Items[item.Index].Selected = true;
                    lstMayIn.Select();//chọn nó                
                }
            }
        }

        PhuongPhapInS _phPhapIn;
        public PhuongPhapInS PhuongPhapIn
        {
            get
            {
                if (rdbToner.Checked)
                    _phPhapIn = PhuongPhapInS.Toner;

                else if (rdbOffset.Checked)
                    _phPhapIn = PhuongPhapInS.Offset;

                else if (rdbKhongIn.Checked)
                    _phPhapIn = PhuongPhapInS.KhongIn;

                return _phPhapIn;
            }
            set
            {
                _phPhapIn = value;
                switch (_phPhapIn)
                {
                    case PhuongPhapInS.Toner:
                        rdbToner.Checked = true;
                        break;
                    case PhuongPhapInS.Offset:
                        rdbOffset.Checked = true;
                        break;
                    case PhuongPhapInS.KhongIn:
                        rdbKhongIn.Checked = true;
                        break;
                }
            }             
        }
        public string TenPhuongPhapIn 
        {
            get { return cauHinhSanPhamPres.TenPhuongPhapIn(); } 
        }
        public string KhoInChon 
        {
            get { return cauHinhSanPhamPres.KhoMayInChon(); } 
        }
        public FormStateS TinhTrangForm { get; set; }
        #endregion
        //Field Form
        public CauHinhSanPham DocCauHinhSanPham()
        {
            return cauHinhSanPhamPres.DocCauHinhSanPham();
        }
        
      
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
            KhoSanPhamSForm frm = new KhoSanPhamSForm(FormStateS.Get);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Lấy khổ SP";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.KhoCatRong = frm.Rong;
                this.KhoCatCao = frm.Cao;
                this.TranLeTren = frm.TranLeTren;
                this.TranLeDuoi = frm.TranLeDuoi;
                this.TranLeTrong = frm.TranLeTrong;
                this.TranLeNgoai = frm.TranLeNgoai;
            }
        }

        private void TrienKhaiSanPhamForm_Load(object sender, EventArgs e)
        {
            BatTatNutOKTheoDieuKien();
        }
        private void CapNhatLabels()
        {
            cauHinhSanPhamPres.KiemTraTranLe_vs_Le();
            lblKhoGomLe.Text = string.Format("{0} x {1}cm",
                        cauHinhSanPhamPres.KhoRongGomLe(), cauHinhSanPhamPres.KhoCaoGomLe());
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtKhoCatRong)
                    if (string.IsNullOrEmpty(txtKhoCatRong.Text))
                        txtKhoCatRong.Text = "0";

                if (tb == txtKhoCatCao)
                    if (string.IsNullOrEmpty(txtKhoCatCao.Text))
                        txtKhoCatCao.Text = "0";

                if (tb == txtLeTren)
                    if (string.IsNullOrEmpty(txtLeTren.Text))
                        txtLeTren.Text = "0";
                if (tb == txtLeDuoi)
                    if (string.IsNullOrEmpty(txtLeDuoi.Text))
                        txtLeDuoi.Text = "0";
                if (tb == txtLeTrong)
                    if (string.IsNullOrEmpty(txtLeTrong.Text))
                        txtLeTrong.Text = "0";
                if (tb == txtLeNgoai)
                    if (string.IsNullOrEmpty(txtLeNgoai.Text))
                        txtLeNgoai.Text = "0";

                if (tb == txtTranLeTren)
                    if (string.IsNullOrEmpty(txtTranLeTren.Text))
                        txtTranLeTren.Text = "0";
                if (tb == txtTranLeDuoi)
                    if (string.IsNullOrEmpty(txtTranLeDuoi.Text))
                        txtTranLeDuoi.Text = "0";
                if (tb == txtTranLeTrong)
                    if (string.IsNullOrEmpty(txtTranLeTrong.Text))
                        txtTranLeTrong.Text = "0";
                if (tb == txtTranLeNgoai)
                    if (string.IsNullOrEmpty(txtTranLeNgoai.Text))
                        txtTranLeNgoai.Text = "0";               

                CapNhatLabels(); ;//Kiểm và cập nhật luôn
                
            }
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                
                if (tb == txtKhoCatRong || tb == txtKhoCatCao)//nhập luôn số thập phân
                {
                    //if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8) //Số chẵn
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
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
            //Chấp nhận không in
            if (!rdbKhongIn.Checked)
            {
                if (this.IdToInChon <= 0) //Không kiểm nữa vì chấp nhận 0 in
                    loiS.Add("Tờ in chưa chọn");
            }

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
            cauHinhSanPhamPres.DatLeBangTranLe();
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

        private void LoadDanhSachToChay()
        {
            //List view Giá In:            
            lstMayIn.Items.Clear();
            //==đền dữ liệu
            switch (this.PhuongPhapIn)
            {
                case PhuongPhapInS.Toner:
                    foreach (KeyValuePair<int, List<string>> kvp in cauHinhSanPhamPres.TrinhBayToChayDiGiS())
                    {
                        var item = new ListViewItem();
                        item.Text = kvp.Key.ToString();

                        item.SubItems.AddRange(kvp.Value.ToArray());

                        lstMayIn.Items.Add(item);
                    }                    
                    break;
                case PhuongPhapInS.Offset:
                    foreach (KeyValuePair<int, List<string>> kvp in cauHinhSanPhamPres.TrinhBayToChayOffsetS())
                    {
                        var item = new ListViewItem();
                        item.Text = kvp.Key.ToString();
                        item.SubItems.AddRange(kvp.Value.ToArray());
                        lstMayIn.Items.Add(item);
                    }
                    break;
                case PhuongPhapInS.KhongIn: //Không in gì cả
                    lstMayIn.Items.Clear();                    
                    break;
            }
           
            lstMayIn.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstMayIn.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstMayIn.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstMayIn.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void lstMayIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMayInChon.Text = cauHinhSanPhamPres.TrinhBayToChayChon();
            BatTatNutOKTheoDieuKien();
        }

        private void rdbToner_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnThongTinGiay_Click(object sender, EventArgs e)
        {
            var frm = new BangGiaGiayForm(FormStateS.View);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.Text = "Thông tin Giấy";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        private void BatTatNutOKTheoDieuKien()
        {
            switch (this.PhuongPhapIn)
            {
                case PhuongPhapInS.KhongIn:
                    btnOK.Enabled = true;
                    break;
                case PhuongPhapInS.Toner:
                    if (this.IdToInChon > 0)
                        btnOK.Enabled = true;
                    else
                        btnOK.Enabled = false;
                    break;

            }
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb;
            if (sender is RadioButton)
            {
                rdb = (RadioButton)sender;
                if (rdb == rdbToner)
                {
                    LoadDanhSachToChay();
                    BatTatNutOKTheoDieuKien();
                }
                if (rdb == rdbKhongIn)
                {
                    this.IdToInChon = -1;//set lại thành không in
                    LoadDanhSachToChay();
                    BatTatNutOKTheoDieuKien();
                    txtMayInChon.Clear();
                }
            }

        }

        private void btnSSanhInNhanhOffset_Click(object sender, EventArgs e)
        {
            /*if (!Global.CoTheMoFormNay("SoSanhOffsetNhanhForm", "", )) //không có tên form
                return;*/
            //Qua khỏi

            var frm = new  SoSanhOffsetNhanhForm();
            frm.Text = "SO SÁNH CHI PHÍ INHANH v OFFSET";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
