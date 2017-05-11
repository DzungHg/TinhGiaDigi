using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;


namespace TinhGiaInNhapLieu
{
    public partial class DanhMucGiayForm : Form, IViewDanhMucGiay
    {
        DanhMucGiayPresenter danhMucGiayPres;
        public DanhMucGiayForm()
        {
            InitializeComponent();
            
            danhMucGiayPres = new DanhMucGiayPresenter(this);
            LoadNhaCungCap();

            txtTenDanhMuc.TextChanged += new EventHandler(textBox_TextChanged);
            txtThuTu.TextChanged += new EventHandler(textBox_TextChanged);

        }
        #region implement I view;
        public int IdDanhMucgiay
        {
            get { return int.Parse(lblIdDanhMuc.Text); }
            set { lblIdDanhMuc.Text = value.ToString(); }
        }
        public string TenDanhMuc
        {
            get { return txtTenDanhMuc.Text; }
            set { txtTenDanhMuc.Text = value; }
        }
        public string TenNhaCungCapChon
        {
            get
            {
                return cboNhaCC.Text;
            }
            set
            {
                cboNhaCC.Text = value;
            }
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
        public int TinhTrangForm { get; set; }
        public string ThongTin
        {
            get;
            set;
        }
        #endregion
        private void LoadNhaCungCap()
        {
            cboNhaCC.Items.Clear();
            foreach (string str in danhMucGiayPres.NhaCungCapS())
            {
                cboNhaCC.Items.Add(str);
            }
        }
        private void PaperCateForm_Load(object sender, EventArgs e)
        {
           /* switch (TinhTrangForm)
            {
                case (int)Ennums.FormState.New:
                    danhMucGiayPres.AddNewPaperCate();
                    btnSave.Enabled = false;
                    break;
                case (int)Ennums.FormState.Edit:
                    danhMucGiayPres.DisplayAPaperCate(IdDanhMucgiay);
                    break;
            }
            */
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtTenDanhMuc || tb == txtThuTu)
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = "";
            if (!KiemTraHopLe(ref str)) ;
            return;

            switch (this.TinhTrangForm)
            {
                case (int)Ennums.FormState.New:
                    danhMucGiayPres.ThemDanhMucGiay();
                    break;
                case (int)Ennums.FormState.Edit:
                    danhMucGiayPres.SuaDanhMucGiay();
                    break;                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }


        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
            if (string.IsNullOrEmpty(cboNhaCC.Text))
                loiS.Add("Nhà cung cấp rỗng");
            if (string.IsNullOrEmpty(txtTenDanhMuc.Text)) ;
                loiS.Add("Tên danh mục rỗng");
            if (string.IsNullOrEmpty(txtThuTu.Text))
                loiS.Add("Thứ tự rỗng");


            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void DanhMucGiayForm_FormClosing(object sender, FormClosingEventArgs e)
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
}
