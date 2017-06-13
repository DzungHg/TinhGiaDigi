﻿using System;
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
        public int IdHangKhachHang { get; set; }
        public BaiIn Bia 
        { 
            get {return inSachPres ; set; 
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
                 + string.Format("- Số cuốn: {0}" + '\r' + '\n', this.SoCuon)
                + string.Format("- Bìa: {0} trg" + '\r' + '\n', this.SoTrangBia)
            };
            var baiIn = new BaiIn("Bìa sách");
            baiIn.SoLuong = this.SoCuon;//Số bìa thường theo số cuốn
            baiIn.DonVi = "Tờ";
            baiIn.IdHangKH = this.IdHangKhachHang;

            var frm = new InToForm(thongTinChoBaiIn, baiIn);

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
        private void XuLyNutOKTrenFormBaiInBia(InToForm frm)
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
                 + string.Format("- Số cuốn: {0}" + '\r' + '\n', this.SoCuon)
                + string.Format("- Ruột: {0} trg" + '\r' + '\n', this.SoTrangRuot)
            };
            var baiIn = new BaiIn("Ruột sách");
            baiIn.SoLuong = inSachPres.TongSoTrangRuot() / 2;//Mang tính tham khảo
            baiIn.DonVi = "tờ";
            baiIn.IdHangKH = this.IdHangKhachHang;
            var frm = new InToForm(thongTinChoBaiIn, baiIn);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormBaiInRuot(frm);
               
            }
        }
        private void XuLyNutOKTrenFormBaiInRuot(InToForm frm)
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
        private ThongTinBanDauChoThanhPham ThongTinBanDauCuonKeo()
        {
            var thongTinBanDau = new ThongTinBanDauChoThanhPham
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
                        this.SoCuon, "cuốn")

            };
            return thongTinBanDau;
        }
        private void ThemDongCuon()
        {///Hiện tại Id chọn các dịch vụ đóng cuốn là Id của MonDongCuon 
         ///Lấy được món đóng cuốn

            var monDongCuon = inSachPres.DocMonDongCuonTheoID();
            switch (monDongCuon.KieuDongCuon) //Thiết lập chỉ 2 loại keo và lò xo
            {
                case KieuDongCuonS.Keo:
                    //Điều chỉnh thông tin ban đầu
                    var thongTinBanDauCuonKeo = ThongTinBanDauCuonKeo();
                    thongTinBanDauCuonKeo.TinhTrangForm = FormStateS.New;
                    thongTinBanDauCuonKeo.TieuDeForm = "[Mới] Đóng cuốn";

                    //tạo mục thành phẩm đóng cuốn
                    var mucThPhamDongCuon = new MucThanhPham();
                    mucThPhamDongCuon.IdBaiIn = this.ID;
                    mucThPhamDongCuon.IdHangKhachHang = this.IdHangKhachHang;
                    mucThPhamDongCuon.IdThanhPhamChon = inSachPres.DocMonDongCuonTheoID().IdGoc;
                    mucThPhamDongCuon.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
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
                    mucDongCuon.SoLuong = 10; //Vì số lượng có thể không trùng
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

            }
            
        }
        private void SuaDongCuon()
        {///Hiện tại Id chọn các dịch vụ đóng cuốn là Id của MonDongCuon 
            ///Lấy được món đóng cuốn

            var monDongCuon = inSachPres.DocMonDongCuonTheoID();
            switch (monDongCuon.KieuDongCuon) //Thiết lập chỉ 2 loại keo và lò xo
            {
                case KieuDongCuonS.Keo:
                    var thongTinChoCuonKeo = this.ThongTinBanDauCuonKeo();

                    thongTinChoCuonKeo.TieuDeForm = "[Sửa] Đóng cuốn";

                    var frm1 = new ThPhDongCuonForm(thongTinChoCuonKeo, this.DongCuon);

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
                    MessageBox.Show("Chú ý Bìa chưa có!");

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

                //Qua được thì cập nhật chi tiết toàn bộ

            }
        }
        private void Wizard_SelectedPageChanged(object sender, Telerik.WinControls.UI.SelectedPageChangedEventArgs e)
        {
            //MessageBox.Show(e.SelectedPage.Name);


            if (e.SelectedPage == wzDongCuon)
            {
                CapNatTomTat();
            }
        }
        private void CapNatTomTat()
        {
            txtTomTatTinhGia.Text = inSachPres.TomTatChaoGia_DV();
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

    }
}
