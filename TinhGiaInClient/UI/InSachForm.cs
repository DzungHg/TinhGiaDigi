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
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.View;
using TinhGiaInClient.Common.Enum;

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

            rdbKhachDV.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(RadioButtons_ToggleStateChanged);
            rdbKhachLe.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(RadioButtons_ToggleStateChanged);

            txtSoTrangBia.Leave += new EventHandler(TextBoxes_Leave);
            txtSoTrangRuot.Leave += new EventHandler(TextBoxes_Leave);

            txtSachCao.KeyPress += new KeyPressEventHandler(InputValidator);
            txtGayDay.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSachRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoCuon.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoTrangBia.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoTrangRuot.KeyPress += new KeyPressEventHandler(InputValidator);

            radWiz1.SelectedPageChanging += new Telerik.WinControls.UI.SelectedPageChangingEventHandler(Wizard_SelectedPageChanging);
            radWiz1.SelectedPageChanged += new Telerik.WinControls.UI.SelectedPageChangedEventHandler(Wizard_SelectedPageChanged);
            
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
        public bool BiaLayNgoai
        {
            get { return chkBiaLayNgoai.Checked; }
            set { chkBiaLayNgoai.Checked = value; }
        }
        public int IdHangKhachHang { get; set; }
        public BaiIn Bia 
        { 
             get; set; 
        }
        public BaiIn Ruot { get; set; }
        public MucThanhPham DongCuon { get; set; }
        public MucGiaIn GiaInChiTiet { get; set; }
        public int IdMonDongCuonChon
        {
            get { return int.Parse(lbxDongCuon.SelectedValue.ToString()); }
            set { lbxDongCuon.SelectedValue = value; }
        }
        public KieuDongCuonS KieuDongCuon { get; set; }
        public FormStateS TinhTrangForm
        { get; set; }
        #endregion
        bool dangDiToi = false;
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
                    
                }
                if (tb == txtSoTrangRuot)
                {
                    if (string.IsNullOrEmpty(txtSoTrangRuot.Text.Trim()))
                        txtSoTrangRuot.Text = "8";
                    
                }

            }
        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                
                if (tb == txtSoTrangBia)
                {
                   
                    CapNhatTongSoTrang();
                }
                if (tb == txtSoTrangRuot)
                {
                   
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
        #region Bìa
        private void ThemBiaSach()
        {
            var thongTinChoBaiIn = new ThongTinBanDauChoBaiIn
            {
                IdHangKhachHang = this.IdHangKhachHang,
                TinhTrangForm = FormStateS.New,
                TieuDeForm = "[Mới] Bìa sách",               
                YeuCauTinhGia =  this.TieuDe + '\r' + '\n'
                            + " - Đóng cuốn: " + lbxDongCuon.SelectedItem.Text + '\r' + '\n'
                 + string.Format(" - Số cuốn: {0}" + '\r' + '\n', this.SoCuon)
                + string.Format(" - Bìa: {0} trg" + '\r' + '\n', this.SoTrangBia),
                DanDoThem = " - Số lượng chỉ là tượng trưng" + '\r' + '\n'
                    + " - Bìa tờ liền (đóng keo, kim) hay Bìa rời (đóng lò xo, nẹp vít)" + '\r' + '\n'
                    + " - Từ đây nhập Số lượng chính xác" + '\r' + '\n'
            };
            var baiIn = new BaiIn("Bìa sách");
            baiIn.DienGiai = "Giấy, In, Thành phẩm, v.v.";
            ///Xác định bìa đơn hay bìa đôi để thêm kích thước và số lượng cho phù hợp
            ///bìa đơn là 2 trang rời, bìa đôi là 2 trang liền
            var monDongCuon = inSachPres.DocMonDongCuonTheoID();
            if (monDongCuon.BiaDon)
            {                
                baiIn.SoLuong = this.SoCuon * 2; //suy luật số lượng bìa
                thongTinChoBaiIn.YeuCauTinhGia += string.Format(" - Bìa khổ: {0} x {1}cm" + '\r' + '\n',
                    this.SachRong, this.SachCao);
                thongTinChoBaiIn.SanPhamRong = this.SachRong;
                
            }
            else
            {
                baiIn.SoLuong = this.SoCuon;
                thongTinChoBaiIn.YeuCauTinhGia += string.Format(" - Bìa khổ: {0} x {1}cm" + '\r' + '\n',
                    this.SachRong * 2 + this.GayDay, this.SachCao);
                thongTinChoBaiIn.SanPhamRong = this.SachRong * 2 + this.GayDay;
            }
            thongTinChoBaiIn.SanPhamCao = this.SachCao;
            
            baiIn.DonVi = "Tờ";
            baiIn.IdHangKH = this.IdHangKhachHang;

            var frm = new BaiInToForm(thongTinChoBaiIn, baiIn);

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
        private void XuLyNutOKTrenFormBaiInBia(BaiInToForm frm)
        {
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    this.Bia = frm.DocBaiIn();
                    break;
                case FormStateS.Edit:
                    frm.DocBaiIn();//Cập nhật
                    break;
            }
            CapNhatChiTietBia();
            
        }
        private void CapNhatChiTietBia()
        {
            var str= "";
            if (this.Bia != null)
            {
                foreach (KeyValuePair<string, string> kvp in this.Bia.TomTat_ChaoKH())
                {
                    str += string.Format("{0} {1}" + '\r' + '\n', kvp.Key, kvp.Value);
                }
                
            }
            txtChiTietBia.Text = str;
        }
        #endregion
        #region Ruột
        private void ThemRuotSach()
        {
            var thongTinChoBaiIn = new ThongTinBanDauChoBaiIn
            {
                IdHangKhachHang = this.IdHangKhachHang,
                TinhTrangForm = FormStateS.New,
               
                TieuDeForm = "[Mới] Ruột Sách",

                YeuCauTinhGia = this.TieuDe + '\r' + '\n'
                 + string.Format(" - Số cuốn: {0}" + '\r' + '\n', this.SoCuon)
                 + " - Đóng cuốn: " + lbxDongCuon.SelectedItem.Text + '\r' + '\n'
                + string.Format(" - Ruột: {0} trg" + '\r' + '\n', this.SoTrangRuot),
                DanDoThem = " - Số lượng chỉ là tượng trưng" + '\r' + '\n'
                    + " - Tờ ruột liền (đóng keo, kim) hay Tờ rời (đóng lò xo, nẹp vít)" + '\r' + '\n'
                    + " - Từ đây nhập Số lượng chính xác" + '\r' + '\n'
            };
            var baiIn = new BaiIn("Ruột sách");
            baiIn.DienGiai = "Giấy, In, Thành phẩm, v.v.";
            //Xác định ruột đôi hay ruột đơn để thêm kích thước và số lượng cho phù hợp
            //Ruột đơn  là 2 trang rời, ruột đôi là 2 trang liền
            var monDongCuon = inSachPres.DocMonDongCuonTheoID();
            if (monDongCuon.RuotDon)
            {
                baiIn.SoLuong = inSachPres.TongSoTrangRuot() / 2;
                thongTinChoBaiIn.YeuCauTinhGia += string.Format(" - Ruột khổ: {0} x {1}cm" + '\r' + '\n',
                    this.SachRong, this.SachCao);

                thongTinChoBaiIn.SanPhamRong = this.SachRong;//Bài in bìa
            }
            else
            {
                baiIn.SoLuong = baiIn.SoLuong = inSachPres.TongSoTrangRuot() / 4; 
                thongTinChoBaiIn.YeuCauTinhGia += string.Format(" - Ruột khổ: {0} x {1}cm" + '\r' + '\n',
                    this.SachRong * 2, this.SachCao);

                thongTinChoBaiIn.SanPhamRong = this.SachRong * 2;//Ruôt rộng gấp đôi
            }
            thongTinChoBaiIn.SanPhamCao = this.SachCao;
            baiIn.DonVi = "tờ";
            baiIn.IdHangKH = this.IdHangKhachHang;
            var frm = new BaiInToForm(thongTinChoBaiIn, baiIn);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormBaiInRuot(frm);
               
            }
        }
        private void XuLyNutOKTrenFormBaiInRuot(BaiInToForm frm)
        {
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    this.Ruot = frm.DocBaiIn();
                    break;
                case FormStateS.Edit:
                    frm.DocBaiIn();//Cập nhật
                    break;
            }
            CapNhatChiTietRuot();
        }
        private void CapNhatChiTietRuot()
        {
            var str = "";
            if (this.Ruot != null)
            {
                foreach (KeyValuePair<string, string> kvp in this.Ruot.TomTat_ChaoKH())
                {
                    str += string.Format("{0} {1}" + '\r' + '\n', kvp.Key, kvp.Value);
                }

            }
            txtChiTietRuot.Text = str;
        }
        #endregion
        #region Đóng cuốn
        private ThongTinBanDauThanhPham ThongTinBanDauCuonKeo()
        {
            var thongTinBanDau = new ThongTinBanDauThanhPham
            {

                IdBaiIn = this.ID,
                IdHangKhachHang = this.IdHangKhachHang,
                ThongDiepCanThiet = string.Format("Số lượng {0} {1}",
                    this.SoCuon, "cuốn")
            };
            return thongTinBanDau;
        }
        private ThongTinBanDauDongCuon ThongTinBanDauCuonLoXo()
        {
            var thongTinBanDau = new ThongTinBanDauDongCuon
            {
                 ThongDiepCanThiet = string.Format("Số lượng {0} {1}",
                        this.SoCuon, "cuốn"),
                        MoTextSoLuongCuon = false

            };
            return thongTinBanDau;
        }
        private ThongTinBanDauDongCuon ThongTinBanDauCuonMoPhang()
        {
            var thongTinBanDau = new ThongTinBanDauDongCuon
            {
                ThongDiepCanThiet = string.Format("Số lượng {0} {1}",
                       this.SoCuon, "cuốn"),
                       MoTextSoLuongCuon = false

            };
            return thongTinBanDau;
        }
        private void ThemDongCuon()
        {///Hiện tại Id chọn các dịch vụ đóng cuốn là Id của MonDongCuon 
         ///Lấy được món đóng cuốn

            var monDongCuon = inSachPres.DocMonDongCuonTheoID();
            switch (monDongCuon.KieuDongCuon) //Thiết lập chỉ 2 loại keo và lò xo
            {
                case KieuDongCuonS.KimKeoNep:
                    //Điều chỉnh thông tin ban đầu
                    var thongTinBanDauCuonKeo = ThongTinBanDauCuonKeo();
                    thongTinBanDauCuonKeo.TinhTrangForm = FormStateS.New;
                    thongTinBanDauCuonKeo.TieuDeForm = "[Mới] Đóng cuốn";

                    //tạo mục thành phẩm đóng cuốn
                    var mucThPhamDongCuon = new MucDongCuon();
                    mucThPhamDongCuon.IdBaiIn = this.ID;
                    mucThPhamDongCuon.IdHangKhachHang = this.IdHangKhachHang;
                    mucThPhamDongCuon.IdThanhPhamChon = inSachPres.DocMonDongCuonTheoID().IdGoc;
                    mucThPhamDongCuon.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
                    mucThPhamDongCuon.KieuDongCuon = KieuDongCuonS.KimKeoNep;
                    mucThPhamDongCuon.SoLuong = this.SoCuon;
                    mucThPhamDongCuon.DonViTinh = "cuốn";

                    var frm1 = new ThPhDongCuonForm(thongTinBanDauCuonKeo, mucThPhamDongCuon);

                    frm1.MinimizeBox = false;
                    frm1.MaximizeBox = false;
                    frm1.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm

                    frm1.ShowDialog();
                    if (frm1.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuon(frm1);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());

                        //Cap nhat noi dung đóng cuốn
                        CapNhatChiTietDongCuon();

                    }
                    break;
                case KieuDongCuonS.LoXo:
                    
                    var mucDongCuon = new MucDongCuonLoXo();
                    mucDongCuon.IdBaiIn = this.ID;
                    mucDongCuon.IdHangKhachHang = this.IdHangKhachHang;
                    mucDongCuon.SoLuong = this.SoCuon; //Vì số lượng có thể không trùng
                    mucDongCuon.DonViTinh = "cuốn";
                    mucDongCuon.GayCao = this.SachCao;
                    mucDongCuon.GayDay = this.GayDay;
                    mucDongCuon.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
                    //Tiếp tục thông tin ban đầu
                    var thongTinBanDauCuonLoXo = this.ThongTinBanDauCuonLoXo();                   
                    thongTinBanDauCuonLoXo.TieuDeForm = "[Mới] Cuốn Lò xo";
                    thongTinBanDauCuonLoXo.TinhTrangForm = FormStateS.New;
                    //điều chỉnh mục thành phẩm
                    mucDongCuon.KieuDongCuon = KieuDongCuonS.LoXo;
                    var frm2 = new ThPhDongCuonLoXoForm(thongTinBanDauCuonLoXo, mucDongCuon);

                    frm2.MinimizeBox = false;
                    frm2.MaximizeBox = false;
                    frm2.StartPosition = FormStartPosition.CenterParent;
                    frm2.ShowDialog();
                    if (frm2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuonLoXo(frm2);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        CapNhatChiTietDongCuon();
                    }
                    break;
                case KieuDongCuonS.MoPhang:

                    var mucDongCuonMP = new MucDongCuonMoPhang();
                    mucDongCuonMP.IdBaiIn = this.ID;
                    mucDongCuonMP.IdHangKhachHang = this.IdHangKhachHang;
                    mucDongCuonMP.SoLuong = this.SoCuon; //Vì số lượng có thể không trùng
                    mucDongCuonMP.DonViTinh = "cuốn";
                    mucDongCuonMP.SoToDoi = this.SoTrangRuot / 2;                    
                    mucDongCuonMP.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
                    //Tiếp tục thông tin ban đầu
                    var thongTinBanDauCuonMP = this.ThongTinBanDauCuonMoPhang();
                    thongTinBanDauCuonMP.TieuDeForm = "[Mới] Cuốn Mở phẳng";
                    thongTinBanDauCuonMP.TinhTrangForm = FormStateS.New;
                    //điều chỉnh mục thành phẩm
                    mucDongCuonMP.KieuDongCuon = KieuDongCuonS.MoPhang;
                    var frm3 = new ThPhDongCuonMoPhangForm(thongTinBanDauCuonMP, mucDongCuonMP);

                    frm3.MinimizeBox = false;
                    frm3.MaximizeBox = false;
                    frm3.StartPosition = FormStartPosition.CenterParent;
                    frm3.ShowDialog();
                    if (frm3.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuonMoPhang(frm3);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        CapNhatChiTietDongCuon();
                    }
                    break;

            }
            
        }
        private void SuaDongCuon()
        {///Hiện tại Id chọn các dịch vụ đóng cuốn là Id của MonDongCuon 
            ///Lấy được món đóng cuốn

            var monDongCuon = inSachPres.DocMonDongCuonTheoID();
            switch (monDongCuon.KieuDongCuon) //Thiết lập chỉ 2 loại keo và lò xo
            {
                case KieuDongCuonS.KimKeoNep:
                    var thongTinChoCuonKeo = this.ThongTinBanDauCuonKeo();

                    thongTinChoCuonKeo.TieuDeForm = "[Sửa] Đóng cuốn";

                    var frm1 = new ThPhDongCuonForm(thongTinChoCuonKeo, (MucDongCuon)this.DongCuon);

                    frm1.MinimizeBox = false;
                    frm1.MaximizeBox = false;
                    frm1.StartPosition = FormStartPosition.CenterParent;

                    frm1.ShowDialog();
                    if (frm1.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuon(frm1);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        CapNhatChiTietDongCuon();
                    }
                    break;
                case KieuDongCuonS.LoXo:
                    var thongTinChoCuonLoXo = this.ThongTinBanDauCuonLoXo();
                    thongTinChoCuonLoXo.TinhTrangForm = FormStateS.Edit;
                    thongTinChoCuonLoXo.TieuDeForm = "[Sửa] Đóng cuốn";
                    thongTinChoCuonLoXo.MoTextSoLuongCuon = true;

                    var frm2 = new ThPhDongCuonLoXoForm(thongTinChoCuonLoXo, (MucDongCuonLoXo)this.DongCuon);

                    frm2.MinimizeBox = false;
                    frm2.MaximizeBox = false;
                    frm2.StartPosition = FormStartPosition.CenterParent;

                    frm2.ShowDialog();
                    if (frm2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuonLoXo(frm2);
                        //Cạp nhật
                        CapNhatChiTietDongCuon();
                    }
                    break;
                case KieuDongCuonS.MoPhang:
                    var thongTinChoCuonMP = this.ThongTinBanDauCuonMoPhang();
                    thongTinChoCuonMP.TinhTrangForm = FormStateS.Edit;
                    thongTinChoCuonMP.TieuDeForm = "[Sửa] Mở phẳng";
                    

                    var frm3 = new ThPhDongCuonMoPhangForm(thongTinChoCuonMP, (MucDongCuonMoPhang)this.DongCuon);

                    frm3.MinimizeBox = false;
                    frm3.MaximizeBox = false;
                    frm3.StartPosition = FormStartPosition.CenterParent;

                    frm3.ShowDialog();
                    if (frm3.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuonMoPhang(frm3);
                        //Cạp nhật
                        CapNhatChiTietDongCuon();
                    }
                    break;
            }
        }
        private void XuLyNutOKClick_FormDongCuon(ThPhDongCuonForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add
                    this.DongCuon = frm.LayMucThanhPham();
                    break;
                case FormStateS.Edit:
                    //Tự cập nhật luôn vì reference
                    frm.LayMucThanhPham();
                    break;
            }
            
            
        }
        private void XuLyNutOKClick_FormDongCuonLoXo(ThPhDongCuonLoXoForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    this.DongCuon = frm.LayMucThanhPham();
                    break;
                case FormStateS.Edit:
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không cần
                    frm.LayMucThanhPham();
                    break;
            }
            
            
        }
        private void XuLyNutOKClick_FormDongCuonMoPhang(ThPhDongCuonMoPhangForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    this.DongCuon = frm.LayMucThanhPham();
                    break;
                case FormStateS.Edit:
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không cần
                    frm.LayMucThanhPham();
                    break;
            }


        }
        private void CapNhatChiTietDongCuon()
        {
            txtChiTietDongCuon.Text = inSachPres.ChiTietDongCuon();
        }
        #endregion
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
            

        }

        private void btnXoaBia_Click(object sender, EventArgs e)
        {
            this.Bia = null;
            CapNhatChiTietBia();
        }

        private void btnThemRuot_Click(object sender, EventArgs e)
        {
            if (this.Ruot == null)
                ThemRuotSach();
            

        }

        private void btnXoaRuot_Click(object sender, EventArgs e)
        {
            this.Ruot = null;
            CapNhatChiTietRuot();
        }

        private void radWiz1_Next(object sender, Telerik.WinControls.UI.WizardCancelEventArgs e)
        {
           
        }

        
        private void Wizard_SelectedPageChanging(object sender, Telerik.WinControls.UI.SelectedPageChangingEventArgs e)
        {
            //MessageBox.Show(e.SelectedPage.Name);
           
            
            if (e.SelectedPage == wzRuotBia && dangDiToi)
            {
                if (this.Bia == null )
                    if (!this.BiaLayNgoai)
                        MessageBox.Show("Bìa chưa có!");

                if (this.Ruot == null)
                {
                    MessageBox.Show("Ruột cần có");
                    e.Cancel = true;
                    return;
                    
                }
                //Kiểm tra hiệu lực để thiết lập giá in
                if (!inSachPres.HieuLucThietLapGiaIn())
                {
                    MessageBox.Show("Bạn cần làm lại Ruột để thiết lập được giá in");
                    e.Cancel = true;
                    return;
                }
                //Nếu qua cập nhật giá in
                this.GiaInChiTiet = this.Ruot.GiaInS[0];//Chỉ lấy cái đầu tiên
                CapNhatChiTietGiaIn();
            }
            //Trang in không cần
            if (e.SelectedPage == wzDongCuon && dangDiToi)//Qua trang tóm tắt
            {
                if (this.DongCuon == null)
                {
                    MessageBox.Show("Bạn cần đóng cuốn để kết thúc!");
                    e.Cancel = true;
                }
                else
                    CapNhatTomTat();
                //Qua được thì cập nhật chi tiết toàn bộ
                
            }
        }
        private void Wizard_SelectedPageChanged(object sender, Telerik.WinControls.UI.SelectedPageChangedEventArgs e)
        {
            //MessageBox.Show(e.SelectedPage.Name);


            if (e.SelectedPage == wzDongCuon)
            {
                CapNhatTomTat();
            }
        }
        private void CapNhatTomTat()
        {
            if (rdbKhachDV.IsChecked)
                txtTomTatTinhGiaKH.Text = inSachPres.TomTatChaoGia_DV();
            else
                txtTomTatTinhGiaKH.Text = inSachPres.TomTatChaoGia_Le();

            txtTomTatKyThuat.Text = inSachPres.TomTatChiTiet_KyThuat();
        }
        private void CapNhatChiTietGiaIn()
        {

            txtChiTietIn.Text = inSachPres.ChiTietGiaIn();
        }

        private void btnThemDongCuon_Click(object sender, EventArgs e)
        {
            if (this.DongCuon == null)
                ThemDongCuon();
            else
                SuaDongCuon();
        }

        private void btnXoaDongCuon_Click(object sender, EventArgs e)
        {
            this.DongCuon = null;
            CapNhatChiTietDongCuon();
        }

        private void radWiz1_Previous(object sender, Telerik.WinControls.UI.WizardCancelEventArgs e)
        {
            dangDiToi = false;
        }

        private void radWiz1_Next_1(object sender, Telerik.WinControls.UI.WizardCancelEventArgs e)
        {
            dangDiToi = true;
        }

        private void lbxDongCuon_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //Khi thay đổi cách đóng cuốn thì phải xóa đóng cuốn cũ
            lblDongCuonDaChon.Text = "Đã chọn: " + lbxDongCuon.SelectedItem.Text;
            if (this.DongCuon != null)
            {
                this.DongCuon = null;
                CapNhatChiTietDongCuon();
                
            }
        }

        private void radWiz1_Finish(object sender, EventArgs e)
        {
            //MessageBox.Show(this.DongCuon.TenThanhPham);//Test OK
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }

        private void radWiz1_Cancel(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnCopyChaoKHLe_Click(object sender, EventArgs e)
        {
            if (tabCtrl.SelectedTab == tabTomTatKH)
            {
                if (rdbKhachDV.IsChecked)
                    Clipboard.SetText(inSachPres.TomTatChaoGia_DV());
                else
                    Clipboard.SetText(inSachPres.TomTatChaoGia_Le());
            }
            else
                Clipboard.SetText(inSachPres.TomTatChiTiet_KyThuat());

        }

      

        private void btnLayKichThuoc_Click(object sender, EventArgs e)
        {
            KhoSanPhamSForm frm = new KhoSanPhamSForm(FormStateS.Get);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Khổ Sản phẩm";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.SachRong = frm.Rong;
                this.SachCao = frm.Cao;
            }
        }

        private void chkBiaLayNgoai_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkBiaLayNgoai.Checked)
            {
                this.SoTrangBia = 0;
                txtSoTrangBia.Enabled = false;
            }
            else
            {
                txtSoTrangBia.Enabled = true;
                this.SoTrangBia = 4;
            }
        }
        private void RadioButtons_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Telerik.WinControls.UI.RadRadioButton rdb;
            if (sender is Telerik.WinControls.UI.RadRadioButton )
            {
                rdb = (Telerik.WinControls.UI.RadRadioButton)sender;
                if (rdb == rdbKhachDV || rdb == rdbKhachLe)
                    if (rdbKhachLe.IsChecked)
                        txtTomTatTinhGiaKH.Text = inSachPres.TomTatChaoGia_Le();
                    else
                        txtTomTatTinhGiaKH.Text = inSachPres.TomTatChaoGia_DV();
            }
        }
    }
}
