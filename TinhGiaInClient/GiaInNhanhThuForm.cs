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
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient
{
    public partial class GiaInNhanhThuForm : Form, IViewGiaInNhanhThu
    {
        GiaInNhanhThuPresenter giaInPres;
        public GiaInNhanhThuForm(FormStateS tinhTrangForm, int idHangKH)
        {
            InitializeComponent();
            //
            this.TinhTrangForm = tinhTrangForm;
            this.IdHangKH = idHangKH;
            giaInPres = new GiaInNhanhThuPresenter(this);
            //Nạp bảng giá vô combo
            this.FormCanDong = !LoadNiemYetGia();

            LoadToChayDigi();
            cboToInDigi.SelectedIndex = 1;
            cboToInDigi.SelectedIndex = 0;
            //-event            
            txtSoTrangA4.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoLuongToChay.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoLuongToChay.KeyPress += new KeyPressEventHandler(InputValidator);

            rdbIn1_0.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbIn1_1.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbIn4_1.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbIn4_0.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);

            cboNiemYetGia.SelectedIndexChanged += new EventHandler(ComboBoxes_SelectedIndexChanged); 
            cboToInDigi.SelectedIndexChanged += new EventHandler(ComboBoxes_SelectedIndexChanged);
            
        }
        #region implement Iview
        int _idNiemYet = 0;
        public int IdNiemYetChon
        {
            get
            {
                if (cboNiemYetGia.SelectedValue != null)
                    int.TryParse(cboNiemYetGia.SelectedValue.ToString(),
                        out _idNiemYet);
                return _idNiemYet;
            }
            set { cboNiemYetGia.SelectedValue = value; }
        }
        public string LoaiBangGiaNiemYet { get; set; }
        public int IdBaiIn
        {
            get;
            set;
        }

        PrintSideColorS _kieuIn = PrintSideColorS.FourFour;
        public PrintSideColorS KieuIn
        {
            get {
                if (rdbIn4_4.Checked)
                    _kieuIn = PrintSideColorS.FourFour;
                if (rdbIn4_1.Checked)
                    _kieuIn = PrintSideColorS.FourOne;
                if (rdbIn4_0.Checked)
                    _kieuIn = PrintSideColorS.FourZero;
                if (rdbIn1_1.Checked)
                    _kieuIn = PrintSideColorS.OneOne;
                if (rdbIn1_0.Checked)
                    _kieuIn = PrintSideColorS.OneZero;

                    return _kieuIn;

            }

            set { _kieuIn = value; }
        }

        public int IdHangKH
        {
            get;
            set;
        }

        public int TyLeLoiNhuanTheoHangKH { get; set; }
        public int IdToInDigiChon
        {
            get { return int.Parse(cboToInDigi.SelectedValue.ToString()); }
            
        }
        public int SoToChay
        {
            get { return int.Parse(txtSoLuongToChay.Text); }
            set {txtSoLuongToChay.Text = value.ToString();}
        }
       

       
       
        public string TenBangGiaChon
        {
            get
            {
                return cboNiemYetGia.Text;
            }
            set
            {
                cboNiemYetGia.Text = value; 
            }
        }
        public string TenLoaiBangGia
        {
            get { return lblTenLoaiBangGia.Text; }
            set { lblTenLoaiBangGia.Text = value; }
        }
        public int SoTrangA4
        {
            get
            {
                return giaInPres.SoTrangA4();
            }            
        }
        public int SoTrangToiDaTheoBangGia 
        {
            get { return int.Parse(txtSoTrangToiDa.Text); }
            set { txtSoTrangToiDa.Text = value.ToString(); }
        }
        public decimal TienIn
        {
            get;
            set;
        }
        public string GiaTBTrangInfo
        {
            get { return lblGiaTB_A4.Text; }
            set { lblGiaTB_A4.Text = value; }
        }
        public PhuongPhapInS PhuongPhapIn
        {
            get { return PhuongPhapInS.Toner; }
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }

        #endregion
        public bool FormCanDong { get; set; }
        private bool LoadNiemYetGia()
        {
            var kq = true;
            if (giaInPres.NiemYetGiaInNhanhS().Count > 0)
            {
                cboNiemYetGia.DataSource = giaInPres.NiemYetGiaInNhanhS();
                cboNiemYetGia.DisplayMember = "Ten";
                cboNiemYetGia.ValueMember = "ID";

            }
            else kq = false;
            
            return kq;
        }
        private void LoadToChayDigi()
        {
            cboToInDigi.ValueMember = "ID";
            cboToInDigi.DisplayMember = "Ten";
            cboToInDigi.DataSource = giaInPres.ToChayDigiS();
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoTrangA4)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (t == txtSoLuongToChay)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
            }
        }
        private void GiaInForm_Load(object sender, EventArgs e)
        {
            
          
            //TrinhBayBangGia();
            if (this.FormCanDong) //thiếu dữ liệu giá niêm yết
            {
                //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                //this.Close();
                MessageBox.Show("Đối tượng Khách hàng này chưa có bảng giá");
                this.Shown += new EventHandler(MyForm_CloseOnStart);
            }
            else
            {
                cboNiemYetGia.SelectedIndex = -1;
                cboNiemYetGia.SelectedIndex = 0; //có lỗi khi không có dữ liệu
            }
       
            rdbIn4_0.Checked = true;
            rdbIn4_4.Checked = true;
            //Để thủe
            if (this.TinhTrangForm == FormStateS.View)
            {
                txtSoLuongToChay.Enabled = true;
                txtSoLuongToChay.ReadOnly = false;
            }
        }
        private void MyForm_CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            LoadNiemYetGia();

        }
        private void TrinhBayBangGia()
        {
            
            //MessageBox.Show(PrintPriceCalc.TrinhBayBangGiaKhoang(this.KhoangSoLuong, this.KhoangGia).Count().ToString());
            lvwBangGia.View = System.Windows.Forms.View.Details;
            lvwBangGia.Clear();
            lvwBangGia.Columns.Add("Số lượng");
            lvwBangGia.Columns.Add("Giá/Trang");
            ListViewItem item;
            if (giaInPres.TrinhBayBangGia() != null )
            {
                foreach (KeyValuePair<string, string> kvp in
                    giaInPres.TrinhBayBangGia())
                {
                    item = new ListViewItem(kvp.Key);
                    item.SubItems.Add(kvp.Value);
                    lvwBangGia.Items.Add(item);
                }
            }
            lvwBangGia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

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
                    //Cập nhật số trang A4
                    if (!string.IsNullOrEmpty(txtSoLuongToChay.Text.Trim()))                   
                        txtSoTrangA4.Text = this.SoTrangA4.ToString();                 
                }
                if (t == txtSoTrangA4)//
                {                  
                        
                        CapNhatKetQuaTinh();
                }

            }
          
        }
        private void ComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {            
            ComboBox cb;
            if (sender is ComboBox)
            {
                cb = (ComboBox)sender;
                if (cb == cboNiemYetGia )
                {
                   
                    lblA4TrenToIn.Text = string.Format("( x {0} A4)", giaInPres.SoA4TheoToInDigi());
                    giaInPres.TrinhBayChiTietNiemYet();
                    //Trình bày bảng giá //theo thứ tự
                    TrinhBayBangGia();
                    //Xóa hết lbl
                    lblA4TrenToIn.Text = "";
                    lblGiaTB_A4.Text = "";
                    lblThanhTien.Text = "";

                    CapNhatKetQuaTinh();
                }
                if (cb == cboToInDigi)
                {
                    //Cập nhật chi tiét
                    CapNhatKetQuaTinh();
                }
               
            }
        }
        private void CapNhatKetQuaTinh()
        {
            decimal giaTBTrang = 0;
            this.TienIn = giaInPres.TinhGiaCuoiCung(ref giaTBTrang);
            lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.TienIn);
            lblGiaTB_A4.Text = string.Format("{0:0,0.00}đ/A4", giaTBTrang);
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
           
            if (string.IsNullOrEmpty(txtSoTrangA4.Text))
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
            txtSoTrangA4.Text = string.Format("{0} trang", giaInPres.SoTrangA4());
            //
           
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

        private void cboBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }


        
    }
}
