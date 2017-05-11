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
            txtCategoryName.TextChanged += new EventHandler(textBox_TextChanged);
            danhMucGiayPres = new DanhMucGiayPresenter(this);
        }
        #region implement I view;
        public int IdDanhMucgiay
        {
            get { return int.Parse(lblCateId.Text); }
            set { lblCateId.Text = value.ToString(); }
        }
        public string TenDanhMuc
        {
            get { return txtCategoryName.Text; }
            set { txtCategoryName.Text = value; }
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
        
        public int TinhTrangForm { get; set; }
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
            switch (TinhTrangForm)
            {
                case (int)Ennums.FormState.New:
                    danhMucGiayPres.AddNewPaperCate();
                    btnSave.Enabled = false;
                    break;
                case (int)Ennums.FormState.Edit:
                    danhMucGiayPres.DisplayAPaperCate(IdDanhMucgiay);
                    break;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtCategoryName)
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (TinhTrangForm)
            {
                case (int)Ennums.FormState.New:
                    danhMucGiayPres.SaveNewPaperCate();
                    break;
                case (int)Ennums.FormState.Edit:
                    danhMucGiayPres.SaveEditingPaperCate();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }



        
    }
}
