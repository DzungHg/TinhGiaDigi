using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;


namespace TinhGiaInNhapLieu
{
    public partial class GiayForm : Form, IViewGiay
    {
        GiayPresenter giayPres;
        public GiayForm(int tinhTrangForm, string tenNhaCC, 
            int idDanhMucGiay, int idGiay = 0)
        {
            InitializeComponent();

            giayPres = new GiayPresenter(this);
            this.IdGiay = idGiay;
            this.TinhTrangForm = tinhTrangForm;
            this.TenNhaCungCap = tenNhaCC;
            this.IdDanhMucGiay = idDanhMucGiay;
            LoadDanhMucGiay();
            //Chọn dm giấy theo IdDanhMucGiay đc cung cấp
            cboDanhMucGiay.Text = giayPres.TenDanhMucGiay(this.IdDanhMucGiay);
            //-
            giayPres.TrinhBayGiay();


            cboDanhMucGiay.TextChanged += new EventHandler(textBox_TextChanged);
            txtTenGiay.TextChanged += new EventHandler(textBox_TextChanged);
            txtDienGiai.TextChanged += new EventHandler(textBox_TextChanged);
            txtKhoGiay.TextChanged += new EventHandler(textBox_TextChanged);
            txtChieuDai.TextChanged += new EventHandler(textBox_TextChanged);
            txtChieuNgan.TextChanged += new EventHandler(textBox_TextChanged);
            txtChieuDai.TextChanged += new EventHandler(textBox_TextChanged);
            txtDinhLuong.TextChanged += new EventHandler(textBox_TextChanged);
            txtMaGiayNCC.TextChanged += new EventHandler(textBox_TextChanged);
            txtGiaMua.TextChanged += new EventHandler(textBox_TextChanged);
            txtThuTu.TextChanged += new EventHandler(textBox_TextChanged);
            chkTonKho.CheckedChanged += new EventHandler(textBox_TextChanged);
            chkKhongCon.CheckedChanged += new EventHandler(textBox_TextChanged);
            txtTenGiayMoRong.TextChanged += new EventHandler(textBox_TextChanged);

            txtChieuNgan.Leave += new EventHandler(textBox_Leave);
            txtDinhLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGiaMua.KeyPress += new KeyPressEventHandler(InputValidator);//chỉ được nhập số chẵn 
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);//chỉ được nhập số chẵn 
            txtChieuNgan.KeyPress += new KeyPressEventHandler(InputValidator);
            txtChieuDai.KeyPress += new KeyPressEventHandler(InputValidator);

            IsDataChanged = false;
            
        }
        #region implement I view;
        public int IdGiay
        {
            get { return int.Parse(lblPaperId.Text); }
            set { lblPaperId.Text = value.ToString(); }
        }

        public string MaGiayNhaCungCap 
        {
            get { return txtMaGiayNCC.Text; }
            set { txtMaGiayNCC.Text = value; }
        }
        public string TenDanhMucGiayChon
        {
            get { return cboDanhMucGiay.Text; }
            set {cboDanhMucGiay.Text = value;}
        }
        public string TenNhaCungCap
        {
            get { return txtTenNCC.Text; }
            set { txtTenNCC.Text = value; }
        }
        public int DinhLuong
        {
            get { return int.Parse(txtDinhLuong.Text); }
            set { txtDinhLuong.Text = value.ToString(); }
        }
        public string TenGiay
        {
            get { return txtTenGiay.Text; }
            set { txtTenGiay.Text = value; }
        }
        public string TenGiayMoRong
        {
            get { return txtTenGiayMoRong.Text; }
            set { txtTenGiayMoRong.Text = value; }
        }
        public float ChieuNgan
        {
            get { return float.Parse(txtChieuNgan.Text); }
            set { txtChieuNgan.Text = value.ToString(); }
        }
        public float ChieuDai
        {
            get { return float.Parse(txtChieuDai.Text); }
            set { txtChieuDai.Text = value.ToString();
            }
            
        }
        public int GiaMua
        {
            get { return int.Parse(txtGiaMua.Text); }
            set { txtGiaMua.Text = value.ToString();
                 }
        }
       

        private int _cateId;
        public int IdDanhMucGiay
        {
            get { return _cateId; }
            set { _cateId= value; }
        }
        
        public string MaTuDat
        {
            get
            {
                return txtMaGiayTuDat.Text;
            }
            set
            {
                txtMaGiayTuDat.Text = value;
            }
        }

        public string DienGiai
        {
            get
            {
                return txtDienGiai.Text;
            }
            set
            {
                txtDienGiai.Text = value;
            }
        }

        public int ThuTu
        {
            get
            {
                return int.Parse(txtThuTu.Text);
            }
            set
            {
                txtThuTu.Text = value.ToString();
            }
        }

        public bool TonKho
        {
            get
            {
                return chkTonKho.Checked;
            }
            set
            {
                chkTonKho.Checked = value;
            }
        }
        public string KhoGiay
        {
            get
            {
                return txtKhoGiay.Text;
            }
            set
            {
                txtKhoGiay.Text = value;
            }
        }

        public bool KhongCon
        {
            get
            {
                return chkKhongCon.Checked ;
            }
            set
            {
                chkKhongCon.Checked = value;
            }
        }
        public int TinhTrangForm
        {
            get;
            set;
        }
       
        #endregion
        
        public bool IsDataChanged
        {
            get { return btnSave.Enabled; }
            set { btnSave.Enabled = value; }
        }

        private void PaperCateForm_Load(object sender, EventArgs e)
        {
            lblTieuDeForm.Text = this.Text;
            txtMaGiayNCC.Focus();
        }
        private void LoadDanhMucGiay()
        {
            cboDanhMucGiay.Items.Clear();
            foreach (KeyValuePair<int,string> kvp in  giayPres.DanhMucGiaySTheoNCC())
            {
                cboDanhMucGiay.Items.Add(kvp.Value);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtTenGiay || tb == txtDienGiai ||
                    tb == txtKhoGiay || tb == txtTenGiayMoRong ||
                    tb == txtChieuDai || tb == txtChieuNgan
                    ||tb == txtChieuDai ||tb == txtDinhLuong ||
                    tb == txtMaGiayNCC || tb == txtGiaMua ||
                    tb == txtThuTu || tb == txtMaGiayTuDat)

                {
                    IsDataChanged = true;
                    
                }
                if (tb == txtMaGiayNCC)
                {
                    if (string.IsNullOrEmpty(txtMaGiayTuDat.Text.Trim()))
                        txtMaGiayTuDat.Text = txtMaGiayNCC.Text.Trim();
                }
                if (tb == txtTenGiay || tb == txtChieuDai || tb == txtChieuNgan ||
                    tb == txtDinhLuong)
                {
                    txtTenGiayMoRong.Text = string.Format ("{0} {1} {2}x{3}",
                        txtTenGiay.Text.Trim(), txtDinhLuong.Text.Trim(), txtChieuNgan.Text.Trim(), txtChieuDai.Text.Trim());
                }
                if (tb == txtChieuDai || tb == txtChieuNgan)
                {
                    txtKhoGiay.Text = string.Format("{0} x {1}cm", txtChieuNgan.Text.Trim(), txtChieuDai.Text.Trim());
                }
            }
            CheckBox chk;
            if (sender is CheckBox)
            {
                chk = (CheckBox)sender;
                if (chk == chkKhongCon || chk == chkTonKho)
                    IsDataChanged = true;
            }
            ComboBox cb;
            if (sender is ComboBox)
            {
                cb = (ComboBox)sender;
                if (cb == cboDanhMucGiay)
                    IsDataChanged = true;
            }
        }       

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtChieuNgan || tb == txtChieuDai  )
                {
                    ;
                }
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = "";
            //kiểm tra giữ liệu trước khi lưu
            if (!KiemTraHopLe(ref str))
                return;

            //Hoán đổi chiều ngắn dài phù hợp
            giayPres.HoanDoiChieuNganDai();
            MessageBox.Show(giayPres.LuuGiay());
        }

        private void txtShortDim_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnGetCate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                //Chỉ thêm số chẵn      
                if (tb == txtDinhLuong || tb == txtGiaMua || tb == txtThuTu)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
                if (tb == txtChieuNgan || tb == txtChieuDai)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }


            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblCateName_Click(object sender, EventArgs e)
        {

        }

        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(txtTenGiay.Text))
                loiS.Add("Tên Giấy không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtDinhLuong.Text))
                loiS.Add("Định Lượng không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtDienGiai.Text))
                loiS.Add("Diễn Giải không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtKhoGiay.Text))
                loiS.Add("Khổ Giấy không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtChieuNgan.Text))
                loiS.Add("Chiều Ngắn không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtChieuDai.Text))
                loiS.Add("Chiều Dài không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtMaGiayNCC.Text))
                loiS.Add("Mã Giấy NCC không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtMaGiayTuDat.Text))
                loiS.Add("Mã Giấy Tự Đặt không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtGiaMua.Text))
                loiS.Add("Giá Mua không thể = 0 nhưng không thể rỗng");
            if (string.IsNullOrEmpty(txtThuTu.Text))
                loiS.Add("Thứ Tự không thể = 0 nhưng không thể rỗng");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void GiayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ms = "";
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
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

        private void label16_Click(object sender, EventArgs e)
        {

        }



       
    }
}
