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
    public partial class BaiInForm : Form, IViewBaiIn
    {
        #region Implement IView
        public int ID
        {
            get;
            set;
        }
        public string TieuDe
        {
            get { return txtTieuDe.Text; }
            set { txtTieuDe.Text = value; }
        }
        public string DienGiai
        {
            get { return txtDienGiai.Text; }
            set { txtDienGiai.Text = value; }
        }
        public int SoLuong {
            get { return int.Parse(txtSoLuong.Text); }
            set { txtSoLuong.Text = value.ToString(); }
        }
        public string DonViTinh {
            get { return txtDonVi.Text; }
            set { txtDonVi.Text = value.ToString(); }
        }
        
        public string TenHangKhachHang
        {
            get
            {
                return cboHangKH.Text;              
            }
            set { cboHangKH.Text = value; }
        }
        public int IdHangKhachHang
        {
            get { return baiInPres.IdHangKhachHang(); }            
        }
        public string DienGiaiHangKH
        {
            get { return txtDienGiaiHangKH.Text; }
            set { txtDienGiaiHangKH.Text = value; }
        }
        public int TinhTrangForm { get; set; }
        #endregion
        BaiInPresenter baiInPres;
        public BaiInForm(int formState, string tenHangKH = "")
        {
            InitializeComponent();
            //Chú ý theo thứ tự
            baiInPres = new BaiInPresenter(this);
            this.TinhTrangForm = formState;            
            LoadHangKhachHang();            
            cboHangKH.SelectedIndex = 1;
            cboHangKH.SelectedIndex = 0;            
            //Trình bày theo tình trạng form
            baiInPres.TrinhBayBaiIn();
            //làm khéo về hạng KH
            if (!string.IsNullOrEmpty(tenHangKH))
                this.TenHangKhachHang = tenHangKH;
                //cboHangKH.SelectedIndex = cboHangKH.FindStringExact(tenHangKH);

            //event
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            //Khóa số txtSoluong khi sửa
            /*if (formState == (int)Enumss.FormState.Edit)
                txtSoLuong.Enabled = false;
            else
                txtSoLuong.Enabled = true; 
             */
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                
                if (tb ==txtSoLuong)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
            }
        }

        private void LoadHangKhachHang()
        {
            cboHangKH.Items.Clear();
            foreach (KeyValuePair<int,string> kvp in baiInPres.HangKhachHangS())
            {
                cboHangKH.Items.Add(kvp.Value);
            }           
            
        }
        private void BaiInForm_Load(object sender, EventArgs e)
        {
            switch (this.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:                    
                    //Khóa
                    spcChiTietBaiIn.Enabled = false;
                    break;
                case (int)Enumss.FormState.Edit:
                    spcChiTietBaiIn.Enabled = true;
                    break;


            }
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(txtTieuDe.Text))
                loiS.Add("Tiêu đề bị trống");
            if (string.IsNullOrEmpty(txtDienGiai.Text))
                loiS.Add("Diễn giải trống");
            if (string.IsNullOrEmpty(txtDonVi.Text))
                loiS.Add("Đơn vị trống");
            if (string.IsNullOrEmpty(txtSoLuong.Text))
                loiS.Add("Số lượng trống");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void BaiInForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        //e.Cancel = false;
                    }

                }
            }
            
        }

        private void cboHangKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DienGiaiHangKH = baiInPres.DienGiaiHangKH();
        }
    }
}
