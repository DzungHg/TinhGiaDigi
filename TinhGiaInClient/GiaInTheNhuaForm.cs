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

namespace TinhGiaInClient
{

    public partial class GiaInTheNhuaForm : Telerik.WinControls.UI.RadForm, IViewGiaTheNhua
    {
        public GiaInTheNhuaForm(ThongTinBanDauChoDanhThiep thongTinBanDau, BaiInTheNhua baiInTheNhua,  int idBaiInDanhthiep = 0)
        {
            InitializeComponent();            
            this.IdHangKH = thongTinBanDau.IdHangKhachHang;        
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.ID = idBaiInDanhthiep;

            giaTheNhuaPres = new GiaTheNhuaPresenter(this, baiInTheNhua);
            txtHangKhachHang.Text = thongTinBanDau.TenHangKhachHang;
            
            LoadDanhSachBangGia();
            cboBangGia.SelectedIndex = 0;
            //envents
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
           
            
            lblThanhTien.TextChanged += new EventHandler(TextBoxes_TextChanged);
        }
        GiaTheNhuaPresenter giaTheNhuaPres;
        #region implement IViewDanhThiep
        public int ID
        {
            get;
            set;
        }

        public int IdHangKH
        {
            get;
            set;
        }
        public string TenHangKH
        {
            get { return giaTheNhuaPres.TenHangKH(); }
            set { txtHangKhachHang.Text = value; }
        }
        public int SoMatIn
        {
            get;
            set;
        }
        int _idBangGiaChon;
        public int IdBangGiaChon
        {
            get
            {
                if (cboBangGia.SelectedValue != null)
                    return int.Parse(cboBangGia.SelectedValue.ToString());
                else
                    return 0;
            }
            set { cboBangGia.SelectedValue = value; }
        }

      
            
      
        public string TenVatLieuBaoGom
        {
            get { return lblTenVatLieuIn.Text;}
            set { lblTenVatLieuIn.Text = value; }
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
        List<int> _idGiaTuyChonChonS;
        public List<int> IdGiaTuyChonChonS 
        { 
            get { 
                _idGiaTuyChonChonS = new List<int>();
                if (lvwTuyChonThem.SelectedItems.Count >0)                
                    for (int i = 0; i <lvwTuyChonThem.SelectedItems.Count; i++)
                    {
                        var gia = (GiaTuyChonTheNhua)lvwTuyChonThem.SelectedItems[i].DataBoundItem;
                        _idGiaTuyChonChonS.Add(gia.IdTuyChonTheNhua);
                    }
                
                return _idGiaTuyChonChonS;
            }
            
                
            set {_idGiaTuyChonChonS = value;}
        }
        public string NoiDungBangGia 
        {
            get { return txtNoiDungBangGia.Text; }
            set { txtNoiDungBangGia.Text = value; }
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }
     
        #endregion
        public BaiInTheNhua DocBaiInDanhThiep()
        {
            return giaTheNhuaPres.DocBaiInTheNhua();
        }
        private void LoadDanhSachBangGia()
        {
           cboBangGia.DataSource = giaTheNhuaPres.BangGiaTheNhuaS();
            cboBangGia.ValueMember = "ID";
            cboBangGia.DisplayMember = "Ten";
        }
        private void cboBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoiDungBangGia.Clear();
            txtNoiDungBangGia.Text = giaTheNhuaPres.NoiDungBangGia();
                            
            
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is TextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                
                if (tb == txtSoLuong)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                
            }
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox t;
            
            if (sender is TextBox)
            {
                t = (Telerik.WinControls.UI.RadTextBox)sender;
                if (t == txtSoLuong)
                {
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "1";
                  
                    
                }                
            }

           

        }
       private void CapNhatThanhTienLabels()
       {
           lblThanhTien.Text = string.Format("{0:0,0.00}đ", giaTheNhuaPres.ThanhTien());
           lblGiaTB_The.Text = giaTheNhuaPres.GiaTBInfo();
                
       }

        private void CapNhatSoLuongTheToDa()
        {
            txtSoTheToiDa.Text = giaTheNhuaPres.SoHopToiDaTheoBangGia().ToString();
        }
        private void txtNoiDungBangGia_TextChanged(object sender, EventArgs e)
        {

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
    }
}
