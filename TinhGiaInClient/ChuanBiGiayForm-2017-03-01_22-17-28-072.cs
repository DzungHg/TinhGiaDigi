using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInLogic;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;

namespace TinhGiaInClient
{
    public partial class ChuanBiGiayForm : Form, IViewChuanBiGiay
    {
        public ChuanBiGiayForm(int formState)
        {
            InitializeComponent();
            this.FormState = formState;
            //Việc đặt dữ liệu ban đầu
            switch (this.FormState)
            {
                case (int)Ennums.FormState.New:
                    this.SoToGiayLon = 1;
                    this.SoLuongToChayLyThuyet = 1;
                    this.SoLuongToChayBuHao = 0;
                    break;
            }
            //event
            txtSoToChayBuHao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToGiayLon.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayLyThuyet.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoToChayBuHao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToGiayLon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoToChayLyThuyet.TextChanged += new EventHandler(TextBoxes_TextChanged);
        }
        #region Implement Iview..
        
        public int ID { get; set; }
        public int IdBaiIn
        {
            get;
            set;
        }
        public string DienGiayBaiIn 
        {
            get { return txtDienGiaiBaiIn.Text; }
            set { txtDienGiaiBaiIn.Text = value; }
        }
        public string ThongTinCauHinhSP
        {
            get { return txtThongTinCauHinh.Text; }
            set { txtThongTinCauHinh.Text = value; }
        }

        Giay _giayChon;
        public Giay GiayChon
        {
            get
            {
                return _giayChon;
            }
            set
            {
                _giayChon = value;
            }
        }

        public string TenGiayIn
        {
            get
            {
                return txtTenDienGiai.Text;
            }
            set
            {
                txtTenDienGiai.Text = value;
            }
        }

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

        public int SoLuongToChayLyThuyet
        {
            get
            {
                return int.Parse(txtSoToChayLyThuyet.Text);
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
                txtSoToChayBuHao.Text = value.ToString() ;
            }
        }

        public int SoToGiayLon
        {
            get
            {
                return int.Parse(txtSoToGiayLon.Text);
            }
            set
            {
                txtSoToGiayLon.Text = value.ToString();
            }
        }
        
        public int FormState { get; set; }
        #endregion
        public void LoadNhaCungCapGiay()
        {
            cboNhaCC.DisplayMember = "Ten";
            cboNhaCC.ValueMember = "Ten";
            cboNhaCC.DataSource = NhaCungCap.DanhSachNCC();

            //MessageBox.Show(NhaCungCap.DanhSachNCC().Count().ToString());
        }
        public void LoadDanhMucTheoNhaCungCap(string tenNCC)
        {
            lbxDanhMucGiay.DisplayMember = "Ten";
            lbxDanhMucGiay.ValueMember = "ID";
            lbxDanhMucGiay.DataSource = DanhMucGiay.LayTheoNhaCungCap(tenNCC);

        }
        private void ChuanBiGiayForm_Load(object sender, EventArgs e)
        {
            LoadNhaCungCapGiay();
        }

        private void cboNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhMucTheoNhaCungCap(cboNhaCC.SelectedValue.ToString());
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
            lvwGiay.View = System.Windows.Forms.View.Details;
            lvwGiay.HideSelection = false;
            lvwGiay.FullRowSelect = true;
            //Xóa;
            //lvwCauHinhSP.Items.Clear();           
            if (Giay.LayGiayTheoDanhMuc(maDM).Count() <= 0)
                return;
            //Làm


            ListViewItem item;
            foreach (Giay giay in Giay.LayGiayTheoDanhMuc(maDM))
            {
                item = new ListViewItem();
                item.Text = giay.ID.ToString();

                item.SubItems.Add(giay.TenGiay);
                item.SubItems.Add(string.Format("{0}gsm", giay.DinhDinhLuong));
                item.SubItems.Add(giay.KhoGiay);
                item.SubItems.Add(string.Format("{0} đ/tờ", giay.GiaMua,
                    giay.GiaMua));

                lvwGiay.Items.Add(item);
            }
            lvwGiay.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            

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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lvwGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGiay.SelectedItems.Count <=0 )
            {
                _giayChon = null;
                lblChonGiay.Text = "";
                lblTriGia.Text = "";
                lblGiaBanChoKH.Text = "";
                txtKhoToChay.Text = "";
                return;
            }
            int _tmpIdGiay = 0;
            int.TryParse(lvwGiay.SelectedItems[0].Text, out _tmpIdGiay);
            _giayChon = Giay.LayGiayTheoId(_tmpIdGiay);
            lblChonGiay.Text = this.GiayChon.TenGiay;
            lblGiaMua.Text = string.Format("{0}đ/tờ", this.GiayChon.GiaMua);
            txtTenDienGiai.Text = lblChonGiay.Text;
            txtKhoToChay.Text = _giayChon.KhoGiay;
            var giayDeIn = new GiayDeIn(_giayChon, 1);//Chú ý phải đổi markup theo KH
            lblGiaBanChoKH.Text = string.Format("{0}đ/tờ", giayDeIn.GiaBan);
            //this.ThanhTien = giayDeIn.ThanhTien;
            lblTriGia.Text = string.Format("{0}đ/tờ",giayDeIn.ThanhTien);
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoToChayBuHao || t == txtSoToChayLyThuyet || t == txtSoToGiayLon)//chỉ được nhập số chẵn 
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

            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;                
                if (t == txtSoToChayBuHao || t == txtSoToChayLyThuyet || t == txtSoToGiayLon)
                {
                    if (this.GiayChon != null)
                    {
                        var giayDeIn = new GiayDeIn(this.GiayChon, 1);//Chú ý đổi markup
                        lblGiaBanChoKH.Text = string.Format("{0}đ/tờ", giayDeIn.GiaBan);
                        lblTriGia.Text = string.Format("{0}đ/tờ", giayDeIn.ThanhTien);
                    }
                }

            }
        }
    }
}
