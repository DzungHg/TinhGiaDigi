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
    public partial class GiaInNhanhForm : Form, IViewGiaInNhanh
    {
        GiaInNhanhPresenter giaInPres;
        public GiaInNhanhForm(ThongTinBanDauChoGiaIn thongTinBanDau, MucGiaIn giaIn)
        {
            InitializeComponent();
            //Thông tin ban đầu cho form
            this.Text = thongTinBanDau.TieuDeForm;
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;            
            this.ThongTinGiay = thongTinBanDau.ThongTinGiay;

            //Tạo 
            giaInPres = new GiaInNhanhPresenter(this, giaIn);
            //Nạp bảng giá vô combo
            LoadNiemYetGia();
            
            //Chọn bảng giá ở đây
            if (this.TinhTrangForm == FormStateS.Edit)
                this.IdNiemYetChon = giaIn.IdNiemYetGiaInNhanh;

            //-event            
            txtSoTrangA4.TextChanged += new EventHandler(TextBoxes_TextedChanged);
            txtSoLuongToChay.KeyPress += new KeyPressEventHandler(InputValidator);
           
            rdbInMotMat.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);
            rdbInHaiMat.CheckedChanged += new EventHandler(RadioButtons_CheckChanged);

            cboNiemYetGia.SelectedIndexChanged += new EventHandler(ComboBoxes_SelectedIndexChanged);
            
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

        int _soMatIn = 1;
        public int SoMatIn
        {
            get {
                if (rdbInMotMat.Checked)
                    _soMatIn = 1;
                else 
                    _soMatIn = 2;

                return _soMatIn;
            }

            set { 
                _soMatIn = value;
                if (_soMatIn <= 1)
                    rdbInMotMat.Checked = true;
                else
                    rdbInHaiMat.Checked = true;
                   
            }
        }

        public int IdHangKH
        {
            get;
            set;
        }

        public int TyLeLoiNhuanTheoHangKH { get; set; }
        int _idMayIn;
        public int IdMayInOrToIn
        {
            get { return _idMayIn; }
            set { 
                _idMayIn = value;
              
            }
        }
        public int SoToChay
        {
            get { return int.Parse(txtSoLuongToChay.Text); }
            set {txtSoLuongToChay.Text = value.ToString();}
        }
        public string TenHangKH
        {
            get { return txtHangKhachHang.Text; }
            set { txtHangKhachHang.Text = value; }
        }


        int _idBangGiaInNhanh = 0;
        public int IdNiemYetChon
        {
            get
            {
                if (cboNiemYetGia.SelectedValue != null)
                    int.TryParse(cboNiemYetGia.SelectedValue.ToString(), 
                        out _idBangGiaInNhanh);
                return _idBangGiaInNhanh;
            }
            set
            {
                cboNiemYetGia.SelectedValue = value; 
            }
        }
        public string LoaiBangGiaNiemYet { get; set; }
        public string TenLoaiBangGia 
        {
            get { return lblLoaiBangGia.Text; }
            set { lblLoaiBangGia.Text = value; }
        }
        public string DienGiaiNiemYet 
        {
            get { return txtDienGiaiNiemYet.Text; }
            set { txtDienGiaiNiemYet.Text = value; }
        }
        public bool ChoTinhGopTrang { get; set; }
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
        public string ThongTinGiay
        {
            get { return txtThongTinGiay.Text; }
            set { txtThongTinGiay.Text = value; }
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
        public MucGiaIn DocGiaIn()
        {
            return giaInPres.DocMucGiaIn();
        }
        #endregion
        public bool FormCanDong { get; set; }
        private void LoadNiemYetGia()
        {
            cboNiemYetGia.DataSource = giaInPres.NiemYetGiaInNhanhS();
            cboNiemYetGia.ValueMember = "ID";
            cboNiemYetGia.DisplayMember = "Ten";
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
            //Form có thể phải đóng khi không có bảng giá
            if (this.FormCanDong) //thiếu dữ liệu giá niêm yết
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                //this.Close();
                MessageBox.Show("Đối tượng Khách hàng này chưa có bảng giá");
                this.Shown += new EventHandler(MyForm_CloseOnStart);
            }
            else
            {
                //Bẫy để cập nhật chi tiết
                cboNiemYetGia.SelectedIndex = -1;
                cboNiemYetGia.SelectedIndex = 0; //có lỗi khi không có dữ liệu
            }
            
            //Ten hang KH
            if (this.IdHangKH > 0)
                this.TenHangKH = giaInPres.TenHangKH(this.IdHangKH);
            else
                this.TenHangKH = "";
           
            //Cập nhật tên tờ in digi
            txtToInDigiChon.Text = giaInPres.TenToInDigiChon();

            if (this.TinhTrangForm == FormStateS.View)
            {
                txtSoLuongToChay.Enabled = true;
                txtSoLuongToChay.ReadOnly = false;
            }
            //cập nhật tính giá = bẩy
            txtSoTrangA4.Text = string.Format("{0} trang", giaInPres.SoTrangA4());
            CapNhatNhanThanhTien();
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
        
            lvwBangGia.View = System.Windows.Forms.View.Details;
            lvwBangGia.Clear();
            lvwBangGia.Columns.Add("Số lượng");
            lvwBangGia.Columns.Add("Giá/Trang");
            ListViewItem item;
            if (giaInPres.TrinhBayBangGia() != null)
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
        private void CapNhatNhanThanhTien()
        {
            decimal giaTBTrang = 0;
            this.TienIn = giaInPres.TinhGiaCuoiCung(ref giaTBTrang);
            lblThanhTien.Text = string.Format("{0:0,0.00}đ ", this.TienIn);
            lblGiaTB_A4.Text = string.Format("{0:0,0.00}đ/A4", giaTBTrang);
        }
        private void TextBoxes_TextedChanged(object sender, EventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                //Paper tab prod paper
                if (t == txtSoTrangA4)//
                {
                    CapNhatNhanThanhTien();
                }

            }
            
        }
        private void ComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb;
            if (sender is ComboBox)
            {
                cb = (ComboBox)sender;
                if (cb == cboNiemYetGia)
                {
                    //Trình bày chi tiết
                    giaInPres.TrinhBayChiTietNiemYet();
                    //Phải theo thứ tự
                    TrinhBayBangGia();
                    //Cập nhật tính toán
                    CapNhatNhanThanhTien();

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
        private void RadioButtons_CheckChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(giaInPres.SoTrangA4().ToString());
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
            this.TyLeLoiNhuanTheoHangKH = giaInPres.TyLeLoiNhuanTheoHangKH();
            this.SoTrangToiDaTheoBangGia = giaInPres.SoTrangToiDaTheoBangGia();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
        private string XayDungBangGia(ListView listView, string tenBangGia)
        {
            var kq = "";

            if (listView.Items.Count <= 0)
                return "";
            //Tính
            //Tiêu đề
            kq += tenBangGia + "\r" + "\n";
            //Lấy cột
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                kq += listView.Columns[i].Text + "\t";
            }
            kq += "\r" + "\n";
            var strB = new StringBuilder();
            strB.Append(kq);
            var str2 = "";
            var str3 = "";
            //Lấy hàng
            foreach (ListViewItem item in listView.Items)
            {
                str2 = item.Text + "\t";
                for (int i = 1; i < item.SubItems.Count; i++)
                {
                    str3 += item.SubItems[i].Text + "\t";

                }
                //nối 2 và 3
                //MessageBox.Show(str3);
                //break;
                str2 += str3 + "\r" + "\n";

                strB.Append(str2);
                str3 = "";
                str2 = "";
                //kq += str2;
            }
            kq = strB.ToString();
            return kq;
        }
        private void btnCopyBangGia_Click(object sender, EventArgs e)
        {
            var kq = XayDungBangGia(lvwBangGia, cboNiemYetGia.Text);
            if (!string.IsNullOrEmpty(kq))
                Clipboard.SetText(kq);

        }


        
    }
}
