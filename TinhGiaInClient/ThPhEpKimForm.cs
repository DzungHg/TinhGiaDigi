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
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient
{
    public partial class ThPhEpKimForm : Form, IViewThPhEpKim
    {
        ThPhEpKimPresenter epKimPres;
        public ThPhEpKimForm(ThongTinBanDauThanhPham thongTinBanDau, MucThPhEpKim mucThPham)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
            
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            

            epKimPres = new ThPhEpKimPresenter(this, mucThPham);            
            //Load
            LoadEpKim();
            cboEpKim.SelectedIndex = -1;
            cboEpKim.SelectedIndex = 0;
            
            //Phải làm ở dây
            if (this.TinhTrangForm == FormStateS.Edit)
            {
                this.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
                this.IdNhuEpKimChon = mucThPham.IdNhuEpKimChon;
            }
            
            //Envent
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            lstNhuEpKim.SelectedIndexChanged += new EventHandler(TextBoxes_TextChanged);
            txtCao.TextChanged += new EventHandler(TextBoxes_TextChanged); 
            txtRong.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);
            txtCao.Leave += new EventHandler(TextBoxes_Leave);
            txtRong.Leave += new EventHandler(TextBoxes_Leave);

            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtCao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtRong.KeyPress += new KeyPressEventHandler(InputValidator);

           
            
        }
        #region Implement Iview
        public int ID { get; set; }
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
            get { return string.Format("{0}%", epKimPres.TyLeMarkUp()); }
        }
        public int SoLuong
        {
            get;
            set;
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
         int _idThanhPhamChon = 0;
        public int IdThanhPhamChon
         {
             get {
                 if (cboEpKim.SelectedValue != null)
                     int.TryParse(cboEpKim.SelectedValue.ToString(), out _idThanhPhamChon);
                 return _idThanhPhamChon; 
             }
             set { cboEpKim.SelectedValue = value; }
         }
        public float KhoToChayRong { get; set; }
        public float KhoToChayDai { get; set; }
        public int SoLuongToChay { get; set; }
        public int SoLuongTinhGia
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
        public string TenThanhPhamChon //là ép kim
        {
            get { return cboEpKim.Text; }
            set {cboEpKim.Text = value;}
        }
       
       
        public decimal ThanhTien
        {
            get { return epKimPres.ThanhTien_ThPh(); }
            set { ;}
        }


        public LoaiThanhPhamS LoaiThPh
        {
            get;
            set;
        }
        public string ThongTinHoTro
        {
            get { return txtThongTinHoTro.Text; }
            set { txtThongTinHoTro.Text = value; }
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }
       //Bổ sung thêm
     
       

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
                if (_idNhuEpKimChon > 0 && lstNhuEpKim.Items.Count >0)
                {
                    var item = lstNhuEpKim.FindItemWithText(_idNhuEpKimChon.ToString());
                    lstNhuEpKim.Items[item.Index].Selected = true;
                    lstNhuEpKim.Select();//chọn nó                
                }
            }
        }

        public bool LaEpViTinh
        {
            get { return epKimPres.LaNhuViTinh(); }
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
        private bool dataChanged = false;
        private void LoadEpKim()
        {
            //Cán phủ
            cboEpKim.DataSource = epKimPres.ThanhPhamS();
            cboEpKim.ValueMember = "ID";
            cboEpKim.DisplayMember = "Ten";
         
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
            

            ListView lv;
            if (sender is ListView)
            {
                lv = (ListView)sender;
                if (lv == lstNhuEpKim)
                {
                    txtSoLuong.Enabled = true;
                    txtDonViTinh.Enabled = true;
                  
                }
            }
            dataChanged = true;
            BatTatNutTinhToan();
        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtSoLuong)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtSoLuong.Text))
                        this.SoLuong = 1;

                    CapNhatLabelGia();
                    
                }
                if (tb == txtRong)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtRong.Text))
                        this.KhoEpRong = 5f;

                    
                }
                if (tb == txtCao)
                {
                    //xử lý khi user xóa hết
                    if (string.IsNullOrEmpty(txtCao.Text))
                        this.KhoEpCao = 5f;

                    
                }
            }
           

        }
        private void BatTatNutTinhToan()
        {
            if (dataChanged)
                btnTinhToan.Enabled = dataChanged;
            else
                btnTinhToan.Enabled = false;
        }
        private void CapNhatLabelGia()
        {
            lblThanhTien.Text = string.Format("{0:0,0.00}đ", epKimPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", epKimPres.GiaTB_ThPh(), this.DonViTinh);
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
        
        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = false;
            txtDonViTinh.Enabled = false;
            btnOK.Enabled = false;
            dataChanged = false;
            BatTatNutTinhToan();
        }

        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
            
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
            //Load Nhu ep
            LoadNhuEpKimTheoEpKim();
            //Xác định khổ
            //Lưu lại khỗ cũ trên text box
            var exKhoEpRong = this.KhoEpRong;
            var exKhoEpCao = this.KhoEpCao;
            if (this.LaEpViTinh)
            {               
                txtRong.ReadOnly = true;
                txtCao.ReadOnly = true;
                this.KhoEpRong = this.KhoToChayRong;
                this.KhoEpCao = this.KhoToChayDai;
                this.SoLuongTinhGia = this.SoLuongToChay;
                this.DonViTinh = "Tờ";
            }
            else
            {
                txtRong.ReadOnly = false;
                txtCao.ReadOnly = false;
                this.KhoEpRong = exKhoEpRong;
                this.KhoEpCao = exKhoEpCao;                
                this.SoLuongTinhGia = this.SoLuong; //Số lượng con
                this.DonViTinh = "Con";
            }
        }

        

        private void lstNhuEpKim_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = true;
            //txtDonViTinh.Enabled = true;
            btnOK.Enabled = true;
            CapNhatLabelGia();
        }
        public MucThanhPham LayMucThanhPham()
        {
            return epKimPres.LayMucThanhPham();
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            CapNhatLabelGia();
            dataChanged = false;
            BatTatNutTinhToan();
        }

        
    }
}
