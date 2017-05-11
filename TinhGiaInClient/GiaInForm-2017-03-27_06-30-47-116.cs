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
    public partial class GiaInForm : Form, IViewGiaIn
    {
        GiaInPresenter giaInPres;
        public GiaInForm(int idHangKH, int soToChay, int idToInDigiChon)
        {
            InitializeComponent();
            //
            this.IdHangKH = idHangKH;
            this.SoToChay = soToChay;
            this.IdToInDigiChon = idToInDigiChon;
            giaInPres = new GiaInPresenter(this);
            //Nạp bảng giá vô combo
            LoadBangGia();
            
            //-event            
            txtSoTrangA4.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            
            rdbIn1_0.CheckedChanged += new EventHandler(Combos_SelectedIndexChanged);
            rdbIn1_1.CheckedChanged += new EventHandler(Combos_SelectedIndexChanged);
            rdbIn4_1.CheckedChanged += new EventHandler(Combos_SelectedIndexChanged);
            rdbIn4_0.CheckedChanged += new EventHandler(Combos_SelectedIndexChanged);
            

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

        public int IdToInDigiChon
        {
            get;
            set;
        }
        public int SoToChay
        {
            get { return int.Parse(lblSoLuongToChay.Text); }
            set {lblSoLuongToChay.Text = value.ToString();}
        }
        public string TenHangKH
        {
            get { return txtHangKhachHang.Text; }
            set { txtHangKhachHang.Text = value; }
        }

       
       
        public string TenBangGiaChon
        {
            get
            {
                return txtToInDigiChon.Text;
            }
            set
            { txtToInDigiChon.Text = value; }
        }
        public int SoTrangA4
        {
            get
            {
                return giaInPres.SoTrangA4();
            }            
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
        public string ThongTinGiay
        {
            get { return txtThongTinGiay.Text; }
            set { txtThongTinGiay.Text = value; }
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
                
            }
        }
        private void GiaInForm_Load(object sender, EventArgs e)
        {
            
            //Ten hang KH
            if (this.IdHangKH > 0)
                this.TenHangKH = giaInPres.TenHangKH(this.IdHangKH);
            else
                this.TenHangKH = "";
            TrinhBayBangGia();
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
                if (t == txtSoTrangA4)//chỉ được nhập số chẵn 
                {
                    decimal giaTBTrang = 0;
                    this.TienIn = giaInPres.TinhGiaInNhanh(this.TenBangGiaChon, this.SoTrangA4, ref giaTBTrang);
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.TienIn);
                    lblGiaTB_A4.Text = string.Format("{0:0,0.00}đ/A4", giaTBTrang);
                }

            }
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
        private void Combos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoTrangA4.Text = string.Format("{0} trang", giaInPres.SoTrangA4());
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
        }


        
    }
}
