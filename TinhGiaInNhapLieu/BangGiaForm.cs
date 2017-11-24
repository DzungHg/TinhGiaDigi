using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInNhapLieu
{
    public partial class BangGiaForm : Telerik.WinControls.UI.RadForm, IViewBangGia
    {

        public BangGiaForm(string loaiBangGia, FormStateS tinhTrangForm, int idBangGia = 0 )
        {
            InitializeComponent();
            //NhapMotSoCoban
            this.ID = idBangGia;
            this.LoaiBangGia = loaiBangGia;
            this.TinhTrangForm = tinhTrangForm;
            //
            bangGiaPres = new BangGiaPresenter(this);

           

           
            //Event
            txtTen.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
           
          
            txtDienGiai.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtThuTu.TextChanged += new EventHandler(TextBoxes_TextChanged);
          
           
            txtDaySoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtMucGia.TextChanged += new EventHandler(TextBoxes_TextChanged);
           
           

            chkKhongSuDung.CheckStateChanged += new EventHandler(TextBoxes_TextChanged);   
          
           
           
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);


        }
        BangGiaPresenter bangGiaPres;
        #region implementIView
        public int ID { get; set; }
        public string Ten
        {
            get
            {
                return txtTen.Text;
            }
            set
            {
                txtTen.Text = value;
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




        public string LoaiBangGia
        {
            get { return txtLoaiBangGia.Text; }
            set { txtLoaiBangGia.Text = value; }
        }
        public string DonViTinh
        {
            get { return txtDonViTinh.Text; }
            set { txtDonViTinh.Text = value; }
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

       

        public FormStateS TinhTrangForm
        {
            get;
            set;
        }

      
    

        

        public string DaySoLuong
        {
            get
            {
                return txtDaySoLuong.Text;
            }
            set
            {
                txtDaySoLuong.Text = value;
            }
        }

        public string DayGiaTrang
        {
            get
            {
                return txtMucGia.Text;
            }
            set
            {
                txtMucGia.Text = value;
            }
        }

      

      

      
        public bool KhongSuDung
        {
            get
            {
                return chkKhongSuDung.Checked;
            }
            set
            {
                chkKhongSuDung.Checked = value;
            }
        }
       
        #endregion
        public bool DataChanged
        {
            get;
            set;
        }
        
       
        private void XoaSachNoiDungTatCaTextBox()
        {
            bangGiaPres.TrinhBayThemMoi();
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTen ||  tb == txtThuTu  ||
                    tb == txtDaySoLuong || tb == txtMucGia
                    )
                {
                    this.DataChanged = true;

                }
            }
            Telerik.WinControls.UI.RadTextBoxControl tbc;
            if (sender is Telerik.WinControls.UI.RadTextBoxControl)
            {
                tbc = (Telerik.WinControls.UI.RadTextBoxControl)sender;

                if (tbc == txtDienGiai )
                   
                {
                    this.DataChanged = true;
                }

                Telerik.WinControls.UI.RadCheckBox ch;
                if (sender is Telerik.WinControls.UI.RadCheckBox)
                {
                    ch = (Telerik.WinControls.UI.RadCheckBox)sender;
                    if ( ch == chkKhongSuDung)
                        this.DataChanged = true;
                }
               

            }
             Telerik.WinControls.UI.RadCheckBox chk;
             if (sender is Telerik.WinControls.UI.RadCheckBox)
             {
                 chk = (Telerik.WinControls.UI.RadCheckBox)sender;
                 if (chk == chkKhongSuDung)
                     this.DataChanged = true;
             }

            btnLuu.Enabled = this.DataChanged;

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if ( tb == txtThuTu
                     )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
              
                //Xử lý xóa hêt
               
               
                if (tb == txtThuTu)
                    if (string.IsNullOrEmpty(txtThuTu.Text.Trim()))
                        txtThuTu.Text = "0";
               
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu
            var message = "";
            //Dữ liệu chung
            if (!KiemTraDuLieuChung(out message))
            {
                MessageBox.Show(message);
                return;
            }
            if (!KiemTraBangGia(out message))
            {
                MessageBox.Show(message);
                return;
            }
            //Kiểm tra xong
            var thongDiep = "";
            bangGiaPres.Luu(ref thongDiep);
            MessageBox.Show(thongDiep);
            //Lưu xong:
            this.DataChanged = false;
            this.TinhTrangForm = FormStateS.View;
            btnLuu.Enabled = this.DataChanged;
            
        }

       

        private void QuanLyMayInDigiFrom_Load(object sender, EventArgs e)
        {
            //Bật tắt các nút
            btnDong.Enabled = true;
            btnLuu.Enabled = this.DataChanged;
            //Nếu load để xem bấm trình bày bảng giá luôn
            if (this.TinhTrangForm == FormStateS.View)
                TrinhBayBangGia();
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.TinhTrangForm = FormStateS.Edit;
       
            
        }

        private void lstMayIn_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            bangGiaPres.TrinhBayChiTietBangGia();
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
            lblIDBanGia.Text = this.ID.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnDong.Enabled = true;
            this.DataChanged = false;
            btnLuu.Enabled = this.DataChanged;
            
            bangGiaPres.TrinhBayChiTietBangGia();
           
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TrinhBayBangGia()
        {
            //MessageBox.Show(PrintPriceCalc.TrinhBayBangGiaKhoang(this.KhoangSoLuong, this.KhoangGia).Count().ToString());
            lstTrinhBayBG.View = System.Windows.Forms.View.Details;
            lstTrinhBayBG.Clear();
            lstTrinhBayBG.Columns.Add("Số lượng");
            lstTrinhBayBG.Columns.Add("Giá/Trang");
            ListViewItem item;
            if (bangGiaPres.TrinhBayBangGia() != null)
            {
                foreach (KeyValuePair<string, string> kvp in
                    bangGiaPres.TrinhBayBangGia())
                {
                    item = new ListViewItem(kvp.Key);
                    item.SubItems.Add(kvp.Value);
                    lstTrinhBayBG.Items.Add(item);
                }
            }
            lstTrinhBayBG.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void btnTrinhBay_Click(object sender, EventArgs e)
        {
            TrinhBayBangGia();
        }
        private bool KiemTraDuLieuChung(out string message)
        {
            var messageStr = "";
            var kq = true;
            var lstLoi = new List<string>();
            if (string.IsNullOrEmpty(this.Ten.Trim()))
                lstLoi.Add ("Lỗi Tên" + "\r" + "\n");
            if (string.IsNullOrEmpty(this.DienGiai.Trim()))
                lstLoi.Add ("Thiếu diễn giải" + "\r" + "\n");
            if (string.IsNullOrEmpty(this.DaySoLuong.Trim()))
                lstLoi.Add ("Thiếu dãy số lượng" + "\r" + "\n");
            if (string.IsNullOrEmpty(this.DaySoLuong.Trim()))
                lstLoi.Add ("Thiếu dãy giá" + "\r" + "\n");

            if (lstLoi.Count > 0)
            {
                kq = false;
               foreach (string str in lstLoi)
                {
                    messageStr += str;
                }
            }
           
            message = messageStr;   
            return kq;
        }
        private bool KiemTraBangGia(out string message)
        {
            var kq = true;
            try
            {
                var daySL = this.DaySoLuong.Split(';');
                var dayGia = this.DayGiaTrang.Split(';');
                if (Math.Abs(daySL.Length - dayGia.Length) > 0)
                    kq = false; //Nó phải = nhau
            }
            catch
            {
                message = "Lỗi dãy số lượng hoặc giá";
                kq = false;
            }

            if (!kq)
                message = "Dãy số lượng và dãy giá phải bằng nhau";
            else
                message = "Đạt!";
            return kq;
        }
        private void btnKiemTraBG_Click(object sender, EventArgs e)
        {
            var message = "";
            KiemTraBangGia(out message);
            MessageBox.Show(message);
        }

       

     

    






     
    }
}
