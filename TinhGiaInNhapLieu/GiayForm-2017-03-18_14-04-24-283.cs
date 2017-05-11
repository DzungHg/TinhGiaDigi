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
        GiayPresenter giayPres;
        public GiayForm(int tinhTrangForm, string nhaCC, 
            int idDanhMucGiay, int idGiay = 0)
        {
            InitializeComponent();

            giayPres = new GiayPresenter(this);

            this.TinhTrangForm = tinhTrangForm;
            this.MaNhaCungCap = nhaCC;


            txtPaperName.TextChanged += new EventHandler(textBox_TextChanged);
            txtLongDim.TextChanged += new EventHandler(textBox_TextChanged);
            txtShortDim.TextChanged += new EventHandler(textBox_TextChanged);
            txtLongDim.TextChanged += new EventHandler(textBox_TextChanged);
            txtSubstance.TextChanged += new EventHandler(textBox_TextChanged);
            txtPaperCode.TextChanged += new EventHandler(textBox_TextChanged);
            txtUnitPrice.TextChanged += new EventHandler(textBox_TextChanged);
            txtThuTu.TextChanged += new EventHandler(textBox_TextChanged);
            

            txtShortDim.Leave += new EventHandler(textBox_Leave);
            txtSubstance.KeyPress += new KeyPressEventHandler(InputValidator);
            txtUnitPrice.KeyPress += new KeyPressEventHandler(InputValidator);//chỉ được nhập số chẵn 
            txtThuTu.KeyPress += new KeyPressEventHandler(InputValidator);//chỉ được nhập số chẵn 
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
        public float ChieuNgan
        {
            get { return float.Parse(txtShortDim.Text); }
            set { txtShortDim.Text = value.ToString(); }
        }
        public float ChieuDai
        {
            get { return float.Parse(txtLongDim.Text); }
            set { txtLongDim.Text = value.ToString();
            }
            
        }
        public decimal GiaMua
        {
            get { return decimal.Parse(txtUnitPrice.Text); }
            set { txtUnitPrice.Text = value.ToString();
                 }
        }
        public int ProfiMarginSet
        {
            get { return int.Parse(txtThuTu.Text); }
            set { txtThuTu.Text = value.ToString(); }
        }

        private int _cateId;
        public int IdDanhMucGiay
        {
            get { return _cateId; }
            set { _cateId= value; }
        }
        public string MaTuDat
        {
            get
            {
                return txtMaTuDat.Text;
            }
            set
            {
                txtMaTuDat.Text = value;
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

        public int ThuThu
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

        public bool TonKho
        {
            get
            {
                return chkTonKho.Checked;
            }
            set
            {
                chkTonKho.Checked = value;
            }
        }
        public string KhoGiay
        {
            get
            {
                return txtKhoGiay.Text;
            }
            set
            {
                txtKhoGiay.Text = value;
            }
        }

        public bool KhongCon
        {
            get
            {
                return chkKhongCon.Checked ;
            }
            set
            {
                chkKhongCon.Checked = value;
            }
        }
        public int TinhTrangForm
        {
            get;
            set;
        }
       
        #endregion
        
        public bool IsDataChanged
        {
            get { return btnSave.Enabled; }
            set { btnSave.Enabled = value; }
        }

        private void PaperCateForm_Load(object sender, EventArgs e)
        {
         
        }
      

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb;
            
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtPaperName ||tb == txtLongDim ||tb == txtShortDim
                    ||tb == txtLongDim ||tb == txtSubstance ||tb == txtPaperCode
                    ||tb == txtUnitPrice || tb == txtThuTu)

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
          
            switch (TinhTrangForm)
            {
                case (int)Ennums.FormState.New:
                    //giayPres.SaveNewPaper();
                    break;
                case (int)Ennums.FormState.Edit:
                    giayPres.SaveEditingPaper();
                    break;
            }
        }

        private void txtShortDim_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnGetCate_Click(object sender, EventArgs e)
        {
           
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
                if (tb == txtSubstance || tb == txtUnitPrice || tb == txtThuTu)//chỉ được nhập số chẵn 
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
