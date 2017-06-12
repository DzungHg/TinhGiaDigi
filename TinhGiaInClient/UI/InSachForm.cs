using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Booklet;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.View;

namespace TinhGiaInClient.UI
{
    public partial class InSachForm : Telerik.WinControls.UI.RadForm, IViewInSachDigi
    {
        public InSachForm(ThongTinBanDauChoBaiIn thongTinBanDau, GiaInSachDigi giaInSachDigi)
        {
            InitializeComponent();
            //Theo thứ tự
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.IdHangKhachHang = thongTinBanDau.IdHangKhachHang;
            this.Text = thongTinBanDau.TieuDeForm;
            //Tiếp làm cái này
            inSachPres = new InSachDigiPresenter(this, giaInSachDigi);
            //Loa
            LoadMonDongCuon();

            //Events
            txtTieuDe.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSachCao.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSachRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoCuon.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGayDay.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoTrangBia.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoTrangRuot.TextChanged += new EventHandler(TextBoxes_TextChanged);
      

            txtSachCao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGayDay.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSachRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoCuon.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoTrangBia.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoTrangRuot.KeyPress += new KeyPressEventHandler(InputValidator);
        }
        InSachDigiPresenter inSachPres;

        #region Implement IView
        int _id;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                lblID.Text = _id.ToString();
            }
        }
        public string TieuDe
        {
            get { return txtTieuDe.Text; }
            set { txtTieuDe.Text = value; }
        }
        public int SoTrangRuot
        {
            get
            {
                return int.Parse(txtSoTrangRuot.Text);
            }
            set
            {
                txtSoTrangRuot.Text = value.ToString();
            }
        }

        public int SoTrangBia
        {
            get
            {
                return int.Parse(txtSoTrangBia.Text);
            }
            set
            {
                txtSoTrangBia.Text = value.ToString();
            }
        }

        public float SachRong
        {
            get
            {
                return float.Parse(txtSachRong.Text);
            }
            set
            {
                txtSachRong.Text = value.ToString();
            }
        }

        public float SachCao
        {
            get
            {
                return float.Parse(txtSachCao.Text);
            }
            set
            {
                txtSachCao.Text = value.ToString();
            }
        }

        public float GayDay
        {
            get
            {
                return float.Parse(txtGayDay.Text);
            }
            set
            {
                txtGayDay.Text = value.ToString();
            }
        }

        public int SoCuon
        {
            get
            {
                return int.Parse(txtSoCuon.Text);
            }
            set
            {
                txtSoCuon.Text = value.ToString();
            }
        }
        public int IdHangKhachHang { get; set; }
        public BaiIn Bia { get; set; }
        public BaiIn Ruot { get; set; }
        public int IdMonDongCuonChon
        {
            get { return int.Parse(lbxDongCuon.SelectedValue.ToString()); }
            set { lbxDongCuon.SelectedValue = value; }
        }
        public KieuDongCuonS KieuDongCuon { get; set; }
        public FormStateS TinhTrangForm
        { get; set; }
        #endregion
        private void LoadMonDongCuon()
        {
            lbxDongCuon.DataSource = inSachPres.MonDongCuonS();
            lbxDongCuon.ValueMember = "ID";
            lbxDongCuon.DisplayMember = "Ten";
        }
        private void TextBoxes_TextChanged (object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox )
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtTieuDe)
                {
                    if (string.IsNullOrEmpty(txtTieuDe.Text.Trim()))
                        txtTieuDe.Text = "Tiêu đề";
                }
                if (tb == txtSachRong)
                {
                    if (string.IsNullOrEmpty(txtSachRong.Text.Trim()))
                        txtSachRong.Text = "10";
                }
                if (tb == txtSachCao)
                {
                    if (string.IsNullOrEmpty(txtSachCao.Text.Trim()))
                        txtSachCao.Text = "20";
                }
                if (tb == txtGayDay)
                {
                    if (string.IsNullOrEmpty(txtGayDay.Text.Trim()))
                        txtGayDay.Text = "0.05";
                }
                if (tb == txtSoCuon)
                {
                    if (string.IsNullOrEmpty(txtSoCuon.Text.Trim()))
                        txtSoCuon.Text = "10";
                    CapNhatTongSoTrang();
                }
                if (tb == txtSoTrangBia)
                {
                    if (string.IsNullOrEmpty(txtSoTrangBia.Text.Trim()))
                        txtSoTrangBia.Text = "4";
                    CapNhatTongSoTrang();
                }
                if (tb == txtSoTrangRuot)
                {
                    if (string.IsNullOrEmpty(txtSoTrangRuot.Text.Trim()))
                        txtSoTrangRuot.Text = "8";
                    CapNhatTongSoTrang();
                }

            }
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if (tb == txtSoCuon || tb == txtSoTrangBia || tb == txtSoTrangRuot)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                //thêm được số thập phân
                if (tb == txtSachRong || tb == txtSachCao || tb == txtGayDay)//nhập được số thập phân 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }


            }
        }

        private void CapNhatTongSoTrang()
        {
            lblTongSoTrang.Text = string.Format("{0:0,0} trang (gồm bìa)", inSachPres.TongSoTrang());
        }
        public GiaInSachDigi DocGiaInSachDigi()
        {
            return inSachPres.DocGiaSachDigi();
        }
        private void ThemBiaSach()
        {
            var thongTinChoBaiIn = new ThongTinBanDauChoBaiIn
            {
                IdHangKhachHang = this.IdHangKhachHang,
                TinhTrangForm = FormStateS.New,
                TieuDeForm = "[Mới] Bìa sách",
                DonViTinh = "Tờ",
                YeuCauTinhGia = "???"
            };

            var frm = new BaiInForm(thongTinChoBaiIn);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormBaiInBia(frm);
                //MessageBox.Show(this.BaiInS.Count().ToString());
                //LoadBaiInLenListView();
            }
        }
        private void XuLyNutOKTrenFormBaiInBia(BaiInForm frm)
        {

        }
        private void ThemRuotSach()
        {
            var thongTinChoBaiIn = new ThongTinBanDauChoBaiIn
            {
                IdHangKhachHang = this.IdHangKhachHang,
                TinhTrangForm = FormStateS.New,
                TieuDeBaiIn = this.TieuDe,
                TieuDeForm = "[Mới] Ruột Sách",
                DonViTinh = "trang",
                YeuCauTinhGia = "???"
            };

            var frm = new BaiInForm(thongTinChoBaiIn);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormBaiInRuot(frm);
                //MessageBox.Show(this.BaiInS.Count().ToString());
                //LoadBaiInLenListView();
            }
        }
        private void XuLyNutOKTrenFormBaiInRuot(BaiInForm frm)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InSachForm_Load(object sender, EventArgs e)
        {
            CapNhatTongSoTrang();
        }

        private void btnThemBia_Click(object sender, EventArgs e)
        {
            if (this.Bia == null)
                ThemBiaSach();
            else
                ;//Sửa

        }
    }
}
