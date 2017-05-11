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
    public partial class GiaInNhanhThuForm : Form, IViewGiaInNhanhThu
    {
        GiaInNhanhThuPresenter giaInPres;
        public GiaInNhanhThuForm(int tinhTrangForm)
        {
            InitializeComponent();
            //
            this.FormState = tinhTrangForm;
            giaInPres = new GiaInNhanhThuPresenter(this);
            //Nạp bảng giá vô combo
            LoadBangGia();
            LoadToChayDigi();
            //-event            
            txtSoTrangA4.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoLuongToChay.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoLuongToChay.KeyPress += new KeyPressEventHandler(InputValidator);

            rdbIn1_0.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbIn1_1.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbIn4_1.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbIn4_0.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);

            cboBangGia.SelectedIndexChanged += new EventHandler(TextBoxes_TextedChanged);
            cboToInDigi.SelectedIndexChanged += new EventHandler(TextBoxes_TextedChanged);
            
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
        public int KieuIn
        {
            get {
                if (rdbIn4_4.Checked)
                    _kieuIn = (int)Enumss.PrintSides.FourFour;
                if (rdbIn4_1.Checked)
                    _kieuIn = (int)Enumss.PrintSides.FourOne;
                if (rdbIn4_0.Checked)
                    _kieuIn = (int)Enumss.PrintSides.FourZero;
                if (rdbIn1_1.Checked)
                    _kieuIn = (int)Enumss.PrintSides.OneOne;
                if (rdbIn1_0.Checked)
                    _kieuIn = (int)Enumss.PrintSides.OneZero;

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
                return cboBangGia.Text;
            }
            set
            {
                cboBangGia.Text = value; 
            }
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
       
        public int FormState
        {
            get;
            set;
        }

        #endregion
        private void LoadBangGia()
        {
            cboBangGia.Items.Clear();
            foreach (KeyValuePair<int,string> kvp in giaInPres.BangGiaInNhanhS())
            {
                cboBangGia.Items.Add(kvp.Value);
            
            }
            cboBangGia.SelectedIndex = 0;
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
            
          
            TrinhBayBangGia();

       
            rdbIn4_0.Checked = true;
            rdbIn4_4.Checked = true;
            //Để thủe
            if (this.FormState == (int)Enumss.FormState.View)
            {
                txtSoLuongToChay.Enabled = true;
                txtSoLuongToChay.ReadOnly = false;
            }
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            LoadBangGia();

        }
        private void TrinhBayBangGia()
        {
            

            //MessageBox.Show(PrintPriceCalc.TrinhBayBangGiaKhoang(this.KhoangSoLuong, this.KhoangGia).Count().ToString());
            lvwBangGia.View = System.Windows.Forms.View.Details;
            lvwBangGia.Clear();
            lvwBangGia.Columns.Add("Số lượng");
            lvwBangGia.Columns.Add("Giá/Trang");
            ListViewItem item;
            if (giaInPres.TrinhBayBangGia().Count() > 0)
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
                if (t == txtSoTrangA4 || t == txtSoLuongToChay)//
                {
                    CapNhatKetQuaTinh();
                }

            }
            ComboBox cb;
            if (sender is ComboBox)
            {
                cb = (ComboBox)sender;
                if (cb == cboBangGia ||cb == cboToInDigi)
                {
                    CapNhatKetQuaTinh();
                    lblA4TrenToIn.Text = string.Format("(x{0} A4", giaInPres.SoA4TheoToInDigi());
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
            TrinhBayBangGia();
            
            this.SoTrangToiDaTheoBangGia = giaInPres.SoTrangToiDaTheoBangGia();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }


        
    }
}
