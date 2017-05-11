using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhGiaInClient
{
    public partial class BaiInForm : Form
    {
        #region Thuộc tính
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
        public string DonVi {
            get { return txtDonVi.Text; }
            set { txtDonVi.Text = value.ToString(); }
        }
        public int FormState { get; set; }
        #endregion
        public BaiInForm(int formState)
        {
            InitializeComponent();
            this.FormState = formState;
            //event
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
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

        private void BaiInForm_Load(object sender, EventArgs e)
        {
            
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            return true;
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
                return false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            else
                loiS.Clear();
            

        }
    }
}
