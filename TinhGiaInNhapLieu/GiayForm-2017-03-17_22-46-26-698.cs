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
    public partial class GiayForm : Form, IViewGiay
    {
        GiayPresenter giayPresenter;
        public GiayForm()
        {
            InitializeComponent();

            giayPresenter = new GiayPresenter(this);
            txtPaperName.TextChanged += new EventHandler(textBox_TextChanged);
            txtLongDim.TextChanged += new EventHandler(textBox_TextChanged);
            txtShortDim.TextChanged += new EventHandler(textBox_TextChanged);
            txtLongDim.TextChanged += new EventHandler(textBox_TextChanged);
            txtSubstance.TextChanged += new EventHandler(textBox_TextChanged);
            txtPaperCode.TextChanged += new EventHandler(textBox_TextChanged);
            txtUnitPrice.TextChanged += new EventHandler(textBox_TextChanged);
            txtProfitMargin.TextChanged += new EventHandler(textBox_TextChanged);
            lblCateName.TextChanged += new EventHandler(textBox_TextChanged);

            txtShortDim.Leave += new EventHandler(textBox_Leave);
            txtSubstance.KeyPress += new KeyPressEventHandler(InputValidator);
            txtUnitPrice.KeyPress += new KeyPressEventHandler(InputValidator);//chỉ được nhập số chẵn 
            txtProfitMargin.KeyPress += new KeyPressEventHandler(InputValidator);//chỉ được nhập số chẵn 
            txtShortDim.KeyPress += new KeyPressEventHandler(InputValidator);
            txtLongDim.KeyPress += new KeyPressEventHandler(InputValidator);

            IsDataChanged = false;
            
        }
        #region implement I view;
        public int Id
        {
            get { return int.Parse(lblPaperId.Text); }
            set { lblPaperId.Text = value.ToString(); }
        }

        public string MaNhaCungCap 
        {
            get { return txtPaperCode.Text; }
            set { txtPaperCode.Text = value; }
        }
        public int DinhLuong
        {
            get { return int.Parse(txtSubstance.Text); }
            set { txtSubstance.Text = value.ToString(); }
        }
        public string TenGiay
        {
            get { return txtPaperName.Text; }
            set { txtPaperName.Text = value; }
        }
        public float ShortDim
        {
            get { return float.Parse(txtShortDim.Text); }
            set { txtShortDim.Text = value.ToString(); }
        }
        public float LongDim
        {
            get { return float.Parse(txtLongDim.Text); }
            set { txtLongDim.Text = value.ToString();
            }
            
        }
        public decimal UnitPrice
        {
            get { return decimal.Parse(txtUnitPrice.Text); }
            set { txtUnitPrice.Text = value.ToString();
                 }
        }
        public int ProfiMarginSet
        {
            get { return int.Parse(txtProfitMargin.Text); }
            set { txtProfitMargin.Text = value.ToString(); }
        }

        private int _cateId;
        public int CateId
        {
            get { return _cateId; }
            set { _cateId= value; }
        }
        public string CategoryName
        {
            get { return lblCateName.Text; }
            set { lblCateName.Text = value; }
        }
       
        #endregion
        public int FormState { get; set; }
        public bool IsDataChanged
        {
            get { return btnSave.Enabled; }
            set { btnSave.Enabled = value; }
        }

        private void PaperCateForm_Load(object sender, EventArgs e)
        {
           
            switch (FormState)
            {
                case (int)Ennums.FormState.New:
                    giayPresenter.AddNewPaper();
                    break;
                case (int)Ennums.FormState.Edit:
                    giayPresenter.DisplayAPaper(Id);                                    
                    break;
            }
            IsDataChanged = false;//
        }
        private void ExchangeShortLongDim()
        {
            if (this.ShortDim > this.LongDim)
            {
                float tmp = this.ShortDim;
                this.ShortDim = this.LongDim;
                this.LongDim = tmp;
            }

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            Label lb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtPaperName ||tb == txtLongDim ||tb == txtShortDim
                    ||tb == txtLongDim ||tb == txtSubstance ||tb == txtPaperCode
                    ||tb == txtUnitPrice || tb == txtProfitMargin)

                {
                    IsDataChanged = true;
                    
                }
            }
            if (sender is Label)
            {
                lb = (Label)sender;
                if (lb == lblCateName)
                {
                    IsDataChanged = true;
                }
            }
        }
       

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtShortDim || tb == txtLongDim  )
                {
                    ;
                }
            }
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Xoay khổ khi bị làm  bị nhập lộn ngắn dài
            ExchangeShortLongDim();
            switch (FormState)
            {
                case (int)Ennums.FormState.New:
                    giayPresenter.SaveNewPaper();
                    break;
                case (int)Ennums.FormState.Edit:
                    giayPresenter.SaveEditingPaper();
                    break;
            }
        }

        private void txtShortDim_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnGetCate_Click(object sender, EventArgs e)
        {
            PaperCateManForm frm = new PaperCateManForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.FormState = (int)Ennums.FormState.View;
            frm.Text = "Chọn danh mục";
            frm.ShowDialog();
            if (frm.SelectedCategoryId > 0)
            {
                CateId = frm.SelectedCategoryId;
                //Cập nhật danh mục vừa lấy
                lblCateName.Text = giayPresenter.PaperCategoryNameById(CateId);
            }
            frm.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                //Chỉ thêm số chẵn      
                if (tb == txtSubstance || tb == txtUnitPrice || tb == txtProfitMargin)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
                if (tb == txtShortDim || tb == txtLongDim)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }


            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblCateName_Click(object sender, EventArgs e)
        {

        }
    }
}
