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

namespace TinhGiaInClient
{
    public partial class ThPhEpKimForm : Form, IViewThPhEpKim
    {
        ThPhEpKimPresenter epKimPres;
        public ThPhEpKimForm()
        {
            InitializeComponent();
            epKimPres = new ThPhEpKimPresenter(this);
            LoadEpKim();
            epKimPres.KhoiTaoBanDau();
            //Load
            LoadEpKim();
            cboEpKim.SelectedIndex = 0;
            
            //Envent
            //txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtCao.Leave += new EventHandler(TextBoxes_Leave);
            txtRong.Leave += new EventHandler(TextBoxes_Leave);
            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);

            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtCao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtRong.KeyPress += new KeyPressEventHandler(InputValidator);

            lbxKhuonEpKim.SelectedIndexChanged += new EventHandler(ListBoxes_SelectedIndex_Changed);
            
        }
        #region Implement Iview
        public int IdBaiIn { get; set; }

        public int IdHangKhachHang
        {
            get;
            set;
        }

        public string ThongTinHangKH
        {
            get { return epKimPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", epKimPres.TyLeMarkUp(this.IdHangKhachHang)); }
        }
         public int SoLuong
        {
            get
            {
                return int.Parse(txtSoLuong.Text);
            }
            set
            {
                txtSoLuong.Text = value.ToString();
            }
        }
         public string DonViTinh
         {
             get
             {
                 return txtDonViTinh.Text ;
             }
             set
             {
                 txtDonViTinh.Text = value;
             }
         }
       
        public string TenThPhChon //là ép kim
        {
            get { return cboEpKim.Text; }
            set {cboEpKim.Text = value;}
        }
       
       
        public decimal ThanhTien
        {
            get { return epKimPres.ThanhTien_ThPh(); }
        }


        public int LoaiThPh
        {
            get;
            set;
        }
        public int TinhTrangForm
        {
            get;
            set;
        }
       //Bổ sung thêm
        int _idKhuonChon = 0;
        public int IdKhuonChon
        {
            get
            {
                _idKhuonChon = int.Parse(lbxKhuonEpKim.SelectedValue.ToString());
                return _idKhuonChon;
            }
            set
            {
                _idKhuonChon = value;
                lbxKhuonEpKim.SelectedItem = _idKhuonChon;
            }
        }

        int _idNhuEpKimChon = 0;
        public int IdNhuEpKimChon
        {
            get
            {
                if (lstNhuEpKim.SelectedItems.Count > 0)
                    int.TryParse(lstNhuEpKim.SelectedItems[0].Text, out _idNhuEpKimChon);
                return _idNhuEpKimChon;
                
            }
            set
            {
                _idNhuEpKimChon = value;
                //chọn trên listview
            }
        }

        public bool LaEpViTinh
        {
            get;
            set;
        }

        public float KhoEpRong
        {
            get
            {
                return float.Parse(txtRong.Text);
            }
            set
            {
                txtRong.Text = value.ToString();
            }
        }

        public float KhoEpCao
        {
            get
            {
                return float.Parse(txtCao.Text);
            }
            set
            {
                txtCao.Text = value.ToString();
            }
        }
        #endregion

        private void LoadEpKim()
        {
            //Cán phủ
            cboEpKim.Items.Clear();
            foreach (KeyValuePair<int,string> kvp in epKimPres.ThanhPhamS())
            {
                cboEpKim.Items.Add(kvp.Value);
            }
         
        }
        private void LoadKhuonEpKimTheoEpKim()
        {
            lbxKhuonEpKim.DisplayMember ="Ten";
            lbxKhuonEpKim.ValueMember ="ID";
            lbxKhuonEpKim.DataSource = epKimPres.KhuonTheoEpKimS();            
        }
        private void LoadNhuEpKimTheoEpKim()
        {
            lstNhuEpKim.Clear();
            lstNhuEpKim.Columns.Add("Id");
            lstNhuEpKim.Columns.Add("Tên");
            lstNhuEpKim.Columns.Add("Diễn giải");
            lstNhuEpKim.Columns.Add("Giá mua");
            lstNhuEpKim.Columns.Add("Thứ tự");
           
            foreach (KeyValuePair<int, List<string>> kvp in epKimPres.NhuTheoEpKimS())
            {
                var item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                item.SubItems.AddRange(kvp.Value.ToArray());
                lstNhuEpKim.Items.Add(item);
            }
            
            lstNhuEpKim.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstNhuEpKim.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstNhuEpKim.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstNhuEpKim.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstNhuEpKim.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void txtSoLuong_CanPhu_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoLuong)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtSoLuong.Text))
                        this.SoLuong = 0;
                    lblThanhTien.Text = string.Format("{0:0,0.00}đ", epKimPres.ThanhTien_ThPh());
                    lblGiaTB.Text = string.Format("{0:0,0.00}đ", epKimPres.GiaTB_ThPh());
                }
               
            }

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                
                if (t == txtSoLuong )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (t == txtCao || t== txtRong)//chỉ được số lẻ
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
            }
        }
        private void ListBoxes_SelectedIndex_Changed(object sender, EventArgs e)
        {
            ListBox lb;
            if (sender is ListBox)
            {
                lb = (ListBox)sender;
                if (lb == lbxKhuonEpKim)
                {
                    txtSoLuong.Enabled = true;
                    txtDonViTinh.Enabled = true;
                }
               
            }
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", epKimPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ", epKimPres.GiaTB_ThPh());
        }

        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = false;
            txtDonViTinh.Enabled = false;
          
        }

        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
            if (string.IsNullOrEmpty(this.TenThPhChon))
                loiS.Add("Tên thành phẩm rỗng");
            if (string.IsNullOrEmpty(txtSoLuong.Text))
                loiS.Add("Số lượng rỗng");
            if (string.IsNullOrEmpty(txtDonViTinh.Text))
                loiS.Add("Đơn vị tính");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void ThPhCanPhuForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void cboEpKim_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadKhuonEpKimTheoEpKim();
            //Load Nhu ep
            LoadNhuEpKimTheoEpKim();
        }

        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                if (t == txtSoLuong)
                    if (string.IsNullOrEmpty(txtSoLuong.Text))
                        this.SoLuong = 1;
                if (t == txtRong)
                    if (string.IsNullOrEmpty(txtRong.Text))
                        this.KhoEpRong = 1;
                if (t == txtCao)
                    if (string.IsNullOrEmpty(txtCao.Text))
                        this.KhoEpCao = 1;


            }

            lblThanhTien.Text = string.Format("{0:0,0.00}đ", epKimPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ", epKimPres.GiaTB_ThPh());
        }
        
    }
}
