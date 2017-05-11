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

namespace TinhGiaInClient
{
    public partial class GiayDeInForm : Form, IViewGiayDeIn
    {
        GiayDeInPresenter giayDeInPres;
        public GiayDeInForm(ThongTinBanDauChoGiayIn thongTinBanDau, GiayDeIn giayDeIn  = null )
        {
            InitializeComponent();
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.ThongTinBaiIn_CauHinh = thongTinBanDau.ThongTinCanThiet;
            this.SoLuongSanPham = thongTinBanDau.SoLuongSanPham;
            this.IdHangKH = thongTinBanDau.IdHangKhachHang;
            
          
            giayDeInPres = new GiayDeInPresenter(this, giayDeIn);
                           
           
                //cập nhật khổ in

            this.KhoToChay = thongTinBanDau.KhoMayIn;
          
            
            //event
            txtSoToChayBuHao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayTrenToLon.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayLyThuyet.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoConTrenToIn.KeyPress += new KeyPressEventHandler(InputValidator);

            txtSoToChayBuHao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToChayTrenToLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToChayLyThuyet.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoConTrenToIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            chkGiayKhach.CheckedChanged += new EventHandler(TextBoxes_TextChanged);
            lblGiaMua.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lblSoToInTong.TextChanged += new EventHandler(TextBoxes_TextChanged);

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
        
       
        public Giay GiayChon
        {
            get;
            set;
        }
        int _idDanhMucGiayChon = 0;
        public int IdDanhMucGiayChon
        {
            get
            {
                if (lbxDanhMucGiay.SelectedValue != null)
                    int.TryParse(lbxDanhMucGiay.SelectedValue.ToString(), out _idDanhMucGiayChon);
                return _idDanhMucGiayChon;
            }
            set { _idDanhMucGiayChon = value;
                if (_idDanhMucGiayChon >0)
                {
                    lbxDanhMucGiay.SelectedValue = _idDanhMucGiayChon.ToString();
                }
            }
        }
        public string TenNhaCC
        {
            get {return cboNhaCC.Text; }
            set { cboNhaCC.Text = value; }
        }
        public string TenGiayIn
        {
            get
            {
                return txtTenGiayDienGiai.Text;
            }
            set
            {
                txtTenGiayDienGiai.Text = value;
            }
        }
        public bool GiayKhachDua
        {
            get { return chkGiayKhach.Checked; }
            set { chkGiayKhach.Checked = value; }
        }
        public int SoLuongSanPham { get; set; }
        public string KhoToChay
        {
            get
            {
                return txtKhoToChay.Text;
            }
            set
            {
                txtKhoToChay.Text = value;
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
            set
            {
                txtSoToChayLyThuyet.Text = value.ToString();
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
            set
            {
                txtSoToGiayLon.Text = value.ToString();
            }
        }
        public decimal GiaBan
        {
            get { return giayDeInPres.GiaBan(); }
        }
        public int SoLuongToChayTong
        {
            get { return giayDeInPres.SoToChayTong(); }
            set { lblSoToInTong.Text = string.Format("{0:0,0} tờ", value); }
        }

        public decimal ThanhTien
        {
            get { return giayDeInPres.ThanhTien(); }
        }
        public FormStates TinhTrangForm { get; set; }
        #endregion
        public CauHinhGiayIn DocCauHinhGiayIn()
        {
            return giayDeInPres.DocCauHinhGiay();
        }
        public GiayDeIn DocGiayDeIn()
        {
            return giayDeInPres.DocGiayDeIn();
        }
        public void LoadNhaCungCapGiay()
        {
            cboNhaCC.DisplayMember = "Ten";
            cboNhaCC.ValueMember = "Ten";
            cboNhaCC.DataSource = NhaCungCapGiay.DanhSachNCC();

            //MessageBox.Show(NhaCungCap.DanhSachNCC().Count().ToString());
        }
        public void LoadDanhMucTheoNhaCungCap()
        {
            lbxDanhMucGiay.DisplayMember = "Ten";
            lbxDanhMucGiay.ValueMember = "ID";
            lbxDanhMucGiay.DataSource = giayDeInPres.DanhMucTheoNhaCC();

        }
        private void ChuanBiGiayForm_Load(object sender, EventArgs e)
        {
            LoadNhaCungCapGiay();
            //Khóa nếu view
            if (this.TinhTrangForm == FormStates.View)
                KhoaCacControlsChoView();

            lblTieuDeForm.Text = this.Text;
        }

        private void cboNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhMucTheoNhaCungCap();
        }
        private void LoadGiayTheoDanhMuc(int maDM)
        {
            //Listview Sản phẩm
            lvwGiay.Clear();
            lvwGiay.Columns.Add("Id");
            lvwGiay.Columns.Add("Tên giấy");
            lvwGiay.Columns.Add("Định lượng");
            lvwGiay.Columns.Add("Khổ");
            lvwGiay.Columns.Add("Giá mua");
            lvwGiay.Columns.Add("Tồn kho");
            lvwGiay.Columns.Add("Còn hàng?");
            lvwGiay.View = System.Windows.Forms.View.Details;
            lvwGiay.HideSelection = false;
            lvwGiay.FullRowSelect = true;
            //Xóa;
            if (this.IdDanhMucGiayChon <= 0)
                return;

            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in giayDeInPres.GiayTheoDanhMucS())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();

                item.SubItems.AddRange(kvp.Value.ToArray());                
                lvwGiay.Items.Add(item);
            }
            lvwGiay.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);


        }
        
        private void lbxDanhMucGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmpID = 0;
            int.TryParse(lbxDanhMucGiay.SelectedValue.ToString(), out tmpID);
            LoadGiayTheoDanhMuc(tmpID);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblGiaBanChoKH_Click(object sender, EventArgs e)
        {

        }

        private void lblTriGia_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtThongTinSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblChonGiay_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDienGiai_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSoToChayLyThuyet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKhoToChay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtSoToChayBuHao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoToGiayLon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lvwGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGiay.SelectedItems.Count <= 0)
            {
                this.GiayChon = null;
                lblChonGiay.Text = "";
                lblThanhTien.Text = "";
                lblGiaBanChoKH.Text = "";
                
                return;
            }
            int _tmpIdGiay = 0;
            int.TryParse(lvwGiay.SelectedItems[0].Text, out _tmpIdGiay);
            this.GiayChon = Giay.DocGiayTheoId(_tmpIdGiay);
            lblChonGiay.Text = string.Format("{0}/{1}/{2}gsm",
                        this.GiayChon.TenGiay, this.GiayChon.KhoGiay,
                        this.GiayChon.DinhLuong);
            lblGiaMua.Text = string.Format("{0:0,0.00}đ/tờ", this.GiayChon.GiaMua);
            txtTenGiayDienGiai.Text = lblChonGiay.Text;
            //txtKhoToChay.Text = _giayChon.KhoGiay;
            //Cập nhật 
            CapNhatKetQuaVoLabels();
           
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
                /*
                if (t == txtProdWidthExtend || t == txtProdHeightExtend
                    || t == txtPaper_RunningShtWidth || t == txtPaper_RunningShtHeight)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }

                //--Prepress
                if (t == txtPrePress_PCTime || t == txtPrePress_ProofTime || t == txtPrePress_ImposTime
                   || t == txtPrePress_MiscTime)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
                 */
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
                if (lb == lblGiaMua)
                {
                    if (this.GiayChon != null)
                    {
                        CapNhatKetQuaVoLabels();
                    }
                }
                if (lb == lblSoToInTong)
                {
                    this.SoToGiayLon = giayDeInPres.SoToGiayLon();
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
                    this.SoLuongToChayLyThuyet = giayDeInPres.SoToChayLyThuyetTinh();
                }
                if (tb == txtSoToChayLyThuyet)
                {
                    this.SoToGiayLon = giayDeInPres.SoToGiayLon();
                    this.SoLuongToChayTong = giayDeInPres.SoToChayTong();
                }
                if (tb == txtSoToChayBuHao)
                {
                    if (string.IsNullOrEmpty(txtSoToChayBuHao.Text))
                    {
                        txtSoToChayBuHao.Text = "0";
                    }
                    this.SoLuongToChayTong = giayDeInPres.SoToChayTong();
                }
                if (tb == txtSoToChayTrenToLon)
                {
                    if (string.IsNullOrEmpty(txtSoToChayTrenToLon.Text))
                    {
                        txtSoToChayTrenToLon.Text = "1";
                    }
                    this.SoToGiayLon = giayDeInPres.SoToGiayLon();
                }
                

                if (this.GiayChon != null)
                {
                    CapNhatKetQuaVoLabels();

                }

            }
            if (sender is CheckBox)
            {
                chk = (CheckBox)sender;
                if (chk == chkGiayKhach)
                {
                    if (this.GiayChon != null)
                    {
                        CapNhatKetQuaVoLabels();
                        
                    }
                }

            }

        }
        private void CapNhatKetQuaVoLabels()
        {
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            //Console.WriteLine(String.Format(info, "{0:c}", value));
            lblGiaBanChoKH.Text = string.Format(info, "{0:c}/tờ", this.GiaBan);
            lblThanhTien.Text = string.Format(info, "{0:c}/tờ", this.ThanhTien);
            lblSoToInTong.Text = string.Format("{0:0,0}", this.SoLuongToChayTong);
        }
        private void KhoaCacControlsChoView()
        {
            txtTenGiayDienGiai.Enabled = false;
            txtKhoToChay.Enabled = false;
            txtSoConTrenToIn.Enabled = false;
            txtSoToChayLyThuyet.Enabled = false;
            txtSoToChayBuHao.Enabled = false;
            txtSoToChayTrenToLon.Enabled = false;
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (this.GiayChon.ID <= 0)
                loiS.Add("Bạn cần chọn giấy");

            if (string.IsNullOrEmpty(txtTenGiayDienGiai.Text))
                loiS.Add("Diễn giải chưa có");

            if (string.IsNullOrEmpty(txtKhoToChay.Text))
                loiS.Add("Cần khổ tờ chạy");
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

       
    }

}
