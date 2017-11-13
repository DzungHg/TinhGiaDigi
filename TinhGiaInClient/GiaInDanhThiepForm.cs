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
    
    public partial class GiaInDanhThiepForm : Form, IViewGiaDanhThiep
    {
        public GiaInDanhThiepForm(ThongTinBanDauChoDanhThiep thongTinBanDau, BaiInDanhThiep baiInDThiep,  int idBaiInDanhthiep = 0 )
        {
            InitializeComponent();            
            this.IdHangKH = thongTinBanDau.IdHangKhachHang;        
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.ID = idBaiInDanhthiep;

            giaDanhThiepPres = new GiaDanhThiepPresenter(this, baiInDThiep);
            txtHangKhachHang.Text = thongTinBanDau.TenHangKhachHang;
            
            LoadDanhSachBangGia();
            cboBangGia.SelectedIndex = -1;
            cboBangGia.SelectedIndex = 0;
            //envents
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);

            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtTieuDe.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);
            txtTieuDe.Leave += new EventHandler(TextBoxes_Leave);

            lblTienIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lblTienGiay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lblThanhTien.TextChanged += new EventHandler(TextBoxes_TextChanged);
        }
        GiaDanhThiepPresenter giaDanhThiepPres;
        #region implement IViewDanhThiep
        public int ID
        {
            get;
            set;
        }
        public string TieuDe 
        {
            get { return txtTieuDe.Text; }
            set { txtTieuDe.Text = value; }
        }
        public int IdHangKH
        {
            get;
            set;
        }
        public string TenHangKH
        {
            get { return giaDanhThiepPres.TenHangKH(); }
            set { txtHangKhachHang.Text = value; }
        }
        public int SoMatIn
        {
            get;
            set;
        }
        int _idBangGiaChon = 0;
        public int IdBangGiaChon
        {
            get
            {
                if (cboBangGia.SelectedValue != null)
                    int.TryParse(cboBangGia.SelectedValue.ToString(), out _idBangGiaChon);
                return _idBangGiaChon;
            }
            set { _idBangGiaChon = value; }
        }

        public string TenBangGiaChon
        {
            get
            {
                return cboBangGia.Text;
            }
            set
            {
                cboBangGia.Text = value;
            }
        }
        public GiayDeIn GiayDeInChon
        {
            get;
            set;
        }
            
        public int IdGiayChon { get; set; }
        public string TenGiayChon
        {
            get { return giaDanhThiepPres.TenGiayChon(); }
            set { txtTenGiay.Text = value; }
        }
        public string KichThuoc 
        {
            get { return txtKichThuoc.Text; }
            set { txtKichThuoc.Text = value; }
        }
        public int SoLuong
        {
            get { return int.Parse(txtSoLuong.Text); }
            set { txtSoLuong.Text = value.ToString(); }
        }

        decimal _tienIn;
        public decimal TienIn
        {
            get
            {
                _tienIn = giaDanhThiepPres.GiaDanhThiepTheoBang();
                return _tienIn;
            }
            set
            {
                _tienIn = value;
                lblTienIn.Text = string.Format("{0:0,0.00}đ", _tienIn);
            }
        }
        decimal _tienGiay;
        public decimal TienGiay
        {
            get
            {
                _tienGiay = giaDanhThiepPres.TienGiay();
                return _tienGiay;
            }
            set
            {
                _tienGiay = value;
                lblTienGiay.Text = string.Format("{0:0,0.00}đ", _tienGiay);
            }
        }
        
       List<int> _idGiaTuyChonChonS;
        public List<int> IdGiaTuyChonChonS
        {
            get {
                 _idGiaTuyChonChonS = new List<int>();
                if (lbxTuyChon.CheckedItems.Count >0)
                    for (int i = 0; i < lbxTuyChon.CheckedItems.Count; i++)
                    {
                        var gia = (GiaTuyChonModel)lbxTuyChon.CheckedItems[i];                       
                        _idGiaTuyChonChonS.Add(gia.IdTuyChon);
                    };
                return _idGiaTuyChonChonS;
            }
            set
            {
                _idGiaTuyChonChonS = value;
                if (_idGiaTuyChonChonS.Count > 0)
                {//check các item
                    
                    for (int i = 0; i < lbxTuyChon.Items.Count; i++)
                    {
                        GiaTuyChonModel obj = (GiaTuyChonModel)lbxTuyChon.Items[i];
                        if (_idGiaTuyChonChonS.Contains(obj.IdTuyChon))
                            lbxTuyChon.SetItemChecked(i, true);
                    }
                }
            }
        }

        public bool DataChanged
        {
            get;
            set;
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }
     
        #endregion
        public BaiInDanhThiep DocBaiInDanhThiep()
        {
            return giaDanhThiepPres.DocBaiInDanhThiep();
        }
        private void LoadDanhSachBangGia()
        {
            cboBangGia.DataSource = giaDanhThiepPres.BangGiaDanhThiepS();
            cboBangGia.ValueMember = "ID";
            cboBangGia.DisplayMember = "Ten";
        }
        private void LoadTuyChonTheoBangGia()
        {
            ((ListBox)lbxTuyChon).DataSource = giaDanhThiepPres.TuyChonSTheoBangGia();
            ((ListBox)lbxTuyChon).ValueMember = "IdTuyChon";
            ((ListBox)lbxTuyChon).DisplayMember = "TenTuyChon";
        }
        private void cboBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoiDungBangGia.Clear();
            txtNoiDungBangGia.Lines = giaDanhThiepPres.NoiDungBangGia().ToArray();
            this.TienIn = giaDanhThiepPres.GiaDanhThiepTheoBang();            
            this.TenGiayChon = giaDanhThiepPres.TenGiayChon();
            //
            LoadTuyChonTheoBangGia();
            
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoLuong)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                
            }
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            this.DataChanged = true;
            BatTatNutTinh();
           /* TextBox t;
            
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                if (t == txtSoLuong)
                {

                    this.DataChanged = true;
                    BatTatNutTinh();
                    
                }
                if (t == txtTieuDe)
                {
                    this.DataChanged = true;
                    BatTatNutTinh();
                }
            }
           
            Label lb;
            if (sender is Label)
            {
                lb = (Label)sender;
                if (lb == lblTienGiay)
                {
                    this.DataChanged = true;
                    BatTatNutTinh();
                }
            }*/
            

        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox t;
           
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                if (t == txtSoLuong)
                {
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        this.SoLuong = 1;
                    if (t == txtTieuDe)
                    {
                        if (string.IsNullOrEmpty(txtTieuDe.Text.Trim()))
                            this.TieuDe = "Danh thiếp";
                    }
                    CapNhatCacLabelsTriGia();
                    this.TienIn = giaDanhThiepPres.GiaDanhThiepTheoBang();

                }
            }
        }
        private void CapNhatCacLabelsTriGia()
        {
            this.TienIn = giaDanhThiepPres.GiaDanhThiepTheoBang();
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", giaDanhThiepPres.ThanhTien());
            lblGiaTB_Hop.Text = giaDanhThiepPres.GiaTBInfo();


        }
        #region đổi giấy 
        private ThongTinBanDauChoGiayInDanhThiep thongTinBanDauChoGiayIn(FormStateS tinhTrangForm)
        {
            var thongTinBanDau = new ThongTinBanDauChoGiayInDanhThiep();
            thongTinBanDau.TinhTrangForm = tinhTrangForm;
            thongTinBanDau.KichThuocSanPham = new KichThuocPhang
            {
                Rong = 9 + 0.4f,
                Dai = 5.5f + 0.4f
            };
            thongTinBanDau.SoLuongSanPham = this.SoLuong; //Số hộp
            thongTinBanDau.SoDanhThiepTrenHop = giaDanhThiepPres.SoDanhThiepTrenMoiHop(); //lấy từ đatabase
            thongTinBanDau.IdHangKhachHang = this.IdHangKH;
            thongTinBanDau.IdToIn_MayInChon = 1; //Đưa tượng trưng
            thongTinBanDau.PhuongPhapIn = PhuongPhapInS.Toner;
            thongTinBanDau.ThongTinCanThiet = string.Format("Danh thiếp {0} " + '\r' + '\n',
                this.KichThuoc)
                + string.Format("Số hộp: {0})" + '\r' + '\n',
                this.SoLuong)
                + "Cần cẩn thận chọn khổ giấy";

            return thongTinBanDau;

        }
        private void DoiGiayMoi()
        {
            //Tao giay de in
            var mucGiayDeIn = new GiayDeIn(32, 48.5f, 1, 0, 1,
                1, false, 0, "", 1, 1, 1, 0);//
            //Tiến hành gắn
            var frm = new GiayInDanhThiepForm(thongTinBanDauChoGiayIn(FormStateS.New), mucGiayDeIn);
            frm.Text = "[Đổi] Giấy in Danh thiếp";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormChuanBiGiay_Click(frm);
                //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());

            }

        }
        private void SuaGiayIn()
        {
            if (this.GiayDeInChon == null)
                return;

            var frm = new GiayInDanhThiepForm(thongTinBanDauChoGiayIn(FormStateS.Edit), this.GiayDeInChon);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "[Sửa] Giấy In";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            //Xử Bấm click //trường hợp edit
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormChuanBiGiay_Click(frm);//Cập nhật dữ liệu
              

            }


        }
        private void XuLyNutOKTrenFormChuanBiGiay_Click(GiayInDanhThiepForm frm)
        {
            
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    this.GiayDeInChon = frm.DocGiayDeIn();
                    this.TenGiayChon = this.GiayDeInChon.TenGiayIn;
                    this.TienGiay = this.GiayDeInChon.ThanhTienGiay;
                    txtSoLuong.Enabled = false;//Lock lại
                    //Cập nhật tính toán
                    TinhToanToanBo();
                    break;
                case FormStateS.Edit:
                    //Đổi ID vì thêm mới là có id mới
                    this.GiayDeInChon = frm.DocGiayDeIn();
                    this.TenGiayChon = this.GiayDeInChon.TenGiayIn;
                    this.TienGiay = this.GiayDeInChon.ThanhTienGiay;
                    txtSoLuong.Enabled = false;//Lock lại
                    //Cập nhật tính toán
                    TinhToanToanBo();
                    break;
            }
        }
        #endregion

        private void txtNoiDungBangGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChonGiayKhac_Click(object sender, EventArgs e)
        {
            if (this.GiayDeInChon != null)
                SuaGiayIn();
            else
                DoiGiayMoi();
        }

        private void btnResetGiay_Click(object sender, EventArgs e)
        {
            this.GiayDeInChon = null;
            this.TenGiayChon = giaDanhThiepPres.TenGiayChon();
            this.TienGiay = giaDanhThiepPres.TienGiay();
            txtSoLuong.Enabled = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblThanhTien_Click(object sender, EventArgs e)
        {

        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();


            if (string.IsNullOrEmpty(txtKichThuoc.Text))
                loiS.Add("Kích thước trống");
      
            if (this.SoLuong <= 0)
                loiS.Add("Số lượng < 0");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }
        private void BatTatNutTinh()
        {
            if (this.DataChanged)
                btnTinh.Enabled = DataChanged;
            else
                btnTinh.Enabled = false;
        }
        private void GiaInDanhThiepForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
               string ms = "";
               if (!KiemTraHopLe(ref ms))
               {
                   var dialogeR = MessageBox.Show(ms, "Nội dung thiếu, bạn muốn làm tiếp?",
                        MessageBoxButtons.YesNo);
                   if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                       e.Cancel = true;
                   else

                       this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
               }
           
     
        }

        private void GiaInDanhThiepForm_Load(object sender, EventArgs e)
        {
            this.DataChanged = false;
            BatTatNutTinh();
        }

        private void TinhToanToanBo()
        {
            CapNhatCacLabelsTriGia();
            this.DataChanged = false;
            BatTatNutTinh();
            txtSoLuong.Focus();
        }
        private void btnTinh_Click(object sender, EventArgs e)
        {
            TinhToanToanBo();
        }

        private void lbxTuyChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CapNhatCacLabelsTriGia();
            this.DataChanged = true;
            BatTatNutTinh();
        }


       
    }
}
