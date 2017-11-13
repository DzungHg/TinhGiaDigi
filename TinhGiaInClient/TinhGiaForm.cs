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
using TinhGiaInClient.Model.Booklet;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.UI;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient
{

    public partial class TinhGiaForm : Telerik.WinControls.UI.RadForm, IViewTinhGiaIn
    {
        TinhGiaPresenter tinhGiaPres = null;
        public TinhGiaForm(ThongTinBanDauChoTinhGia thongTinBanDau)
        {
            InitializeComponent();
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.TenNhanVien = thongTinBanDau.TenNguoiDung;
            this.TieuDeTinhGia = "Tính giá";
            //Rồi mới tiếp tục
            tinhGiaPres = new TinhGiaPresenter(this);
            tinhGiaPres.NoiDungBanDau();
            LoadHangKhachHang();
            cboHangKH.SelectedIndex = 0;
            
            //event
            this.FormClosing += new FormClosingEventHandler(Forms_FormClosing);

            lvwBaiIn.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            lvwDanhThiep.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            lvwCuon.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            lvwTheNhua.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);

            txtTieuDeTinhGia.TextChanged += new EventHandler(TextBoxe_TextChanged);
            txtTenNV.TextChanged += new EventHandler(TextBoxe_TextChanged);
            txtTenKhachHang.TextChanged += new EventHandler(TextBoxe_TextChanged);
            dtpNgay.ValueChanged += new EventHandler(TextBoxe_TextChanged);
            //
            
        }
        #region Thi công  IView
        public int ID
        {
            get { return int.Parse(lblIdTinhGia.Text); }
            set { lblIdTinhGia.Text = value.ToString(); }
        }
        public DateTime NgayTinhGia
        {
            get { return dtpNgay.Value; }
            set { dtpNgay.Value = value; }
        }
        public int IdNguoiDung
        {
            get;
            set;
        }
        public string TieuDeTinhGia
        {
            get { return txtTieuDeTinhGia.Text; }
            set { txtTieuDeTinhGia.Text = value; }
        }

        public bool QuyetDinhGopTrangIn 
        {// chỉ lấy giá trị này để tính gộp
            get { return chkGopSoTrangInTo.Checked; }
            
        }//Chỉ dành cho bài in
        public string TenNhanVien
        {
            get { return txtTenNV.Text; }
            set { txtTenNV.Text = value; }
        }
        public string TenKhachHang
        {
            get { return txtTenKhachHang.Text; }
            set { txtTenKhachHang.Text = value; }
        }
        public string TomTatTinhGia
        {
            get { return txtTomTatTinhGia.Text; }
            set { txtTomTatTinhGia.Text = value; }
        }
        public FormStateS TinhTrangForm { get; set; }
      
        public string TomTatTungMucChaoKH
        {
            get { return txtTomTatBaiIn.Text; }
            set { txtTomTatBaiIn.Text = value; }
        }
        
        int _idBaiInChon = 0;
        public int IdBaiInChon
        {
            get
            {
                if (lvwBaiIn.SelectedItems.Count > 0)
                    int.TryParse(lvwBaiIn.SelectedItems[0].Text, out _idBaiInChon);
                return _idBaiInChon;
            }
            set { _idBaiInChon = value; }
        }

        

        int _idDanhThiepChon = 0;
        public int IdDanhThiepChon
        {
            get
            {
                if (lvwDanhThiep.SelectedItems.Count > 0)
                    int.TryParse(lvwDanhThiep.SelectedItems[0].Text, out _idDanhThiepChon);
                return _idDanhThiepChon;
            }
            set { _idDanhThiepChon = value; }
        }
        int _idGiaSachDigiChon = 0;
        public int IdGiaSachDiGiChon
        {
            get
            {
                if (lvwCuon.SelectedItems.Count > 0)
                    int.TryParse(lvwCuon.SelectedItems[0].Text, out _idGiaSachDigiChon);
                return _idGiaSachDigiChon;
            }
            set { _idGiaSachDigiChon = value; }
        }
        int _idTheNhuaChon = 0;
        public int IdTheNhuaChon
        {
            get
            {
                if (lvwTheNhua.SelectedItems.Count > 0)
                    int.TryParse(lvwTheNhua.SelectedItems[0].Text, out _idTheNhuaChon);
                return _idTheNhuaChon;
            }
            set { _idTheNhuaChon = value; }
        }
        public string TenHangKH
        {
            get { return cboHangKH.Text; }
            set { cboHangKH.Text = value; }
        }
        public int IdHangKhachHang()
        {
            return tinhGiaPres.IdHangKH();
        }
      
        public Boolean FormChanged { get; set; }
       
      
        #endregion
        Dictionary<int,TabPage> tabList = new Dictionary<int,TabPage>();
       
       
        

        private void TinhGiaForm_Load(object sender, EventArgs e)
        {            
            TrinhBayListView();
            MakeFormChange(false);
            CapNhatTextNutThemXoa();
        }

        private void trvMucLuc_Click(object sender, EventArgs e)
        {
            
        }

     

       
        private void TrinhBayListView()
        {
            //Listview bài in

            lvwBaiIn.Clear();
            lvwBaiIn.Columns.Add("Id");
            lvwBaiIn.Columns.Add("Tiêu đề");
            lvwBaiIn.Columns.Add("Diễn giải");
            lvwBaiIn.Columns.Add("Số lượng");
            lvwBaiIn.Columns.Add("Đơn vị");
            lvwBaiIn.Columns.Add("Trị giá");
           
            lvwBaiIn.View = System.Windows.Forms.View.Details;
            lvwBaiIn.HideSelection = false;
            lvwBaiIn.FullRowSelect = true;
            //===hết

            //Listview danh thiếp

            lvwDanhThiep.Clear();
            lvwDanhThiep.Columns.Add("Id");
            lvwDanhThiep.Columns.Add("Tiêu đề");
            lvwDanhThiep.Columns.Add("Diễn giải");
            lvwDanhThiep.Columns.Add("Số lượng");
            lvwDanhThiep.Columns.Add("Đơn vị");
            lvwDanhThiep.Columns.Add("Trị giá");

            lvwDanhThiep.View = System.Windows.Forms.View.Details;
            lvwDanhThiep.HideSelection = false;
            lvwDanhThiep.FullRowSelect = true;
            //===hết
            //Listview Cuốn

            lvwCuon.Clear();
            lvwCuon.Columns.Add("Id");
            lvwCuon.Columns.Add("Tiêu đề");
            lvwCuon.Columns.Add("Khổ cuốn");
            lvwCuon.Columns.Add("Số Trang/Cuốn");
            lvwCuon.Columns.Add("Số lượng");
            lvwCuon.Columns.Add("Thành tiền");

            lvwCuon.View = System.Windows.Forms.View.Details;
            lvwCuon.HideSelection = false;
            lvwCuon.FullRowSelect = true;
            //===hết
            //Listview Thẻ nhựa

            lvwTheNhua.Clear();
            lvwTheNhua.Columns.Add("Id");
            lvwTheNhua.Columns.Add("Tiêu đề");
            lvwTheNhua.Columns.Add("Diễn giải");           
            lvwTheNhua.Columns.Add("Số lượng");
            lvwTheNhua.Columns.Add("Đơn vị");
            lvwTheNhua.Columns.Add("Trị giá");

            lvwTheNhua.View = System.Windows.Forms.View.Details;
            lvwTheNhua.HideSelection = false;
            lvwTheNhua.FullRowSelect = true;
        }
        private void LoadHangKhachHang()
        {
            cboHangKH.Items.Clear();
            foreach (KeyValuePair<int, string> kvp in tinhGiaPres.HangKhachHangS())
            {
                cboHangKH.Items.Add(kvp.Value);
            }

        }    
            
        #region Về Bài In
        private void LoadBaiInLenListView()
        {
            //Xóa;
            lvwBaiIn.Items.Clear();
            if (tinhGiaPres.TrinhBayKetQuaBaiInS().Count() <= 0)
                return;

            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in tinhGiaPres.TrinhBayKetQuaBaiInS())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                item.SubItems.AddRange(kvp.Value.ToArray());

                lvwBaiIn.Items.Add(item);
            }
            lvwBaiIn.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwBaiIn.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwBaiIn.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwBaiIn.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwBaiIn.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwBaiIn.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);          

        }
        
        private void ThemBaiIn()
        {
            var thongTinChoBaiIn = new ThongTinBanDauChoBaiIn{
                IdHangKhachHang = this.IdHangKhachHang(),
                TinhTrangForm = FormStateS.New,
                YeuCauTinhGia = "",
                SanPhamRong = 21f,
                SanPhamCao = 29.7f
            };
            var baiIn = new BaiIn("Bài in");
            baiIn.TieuDe = "Tiêu đề";
            baiIn.DienGiai = "Giấy, In, Thành phẩm, ...";
            baiIn.SoLuong = 10;
            baiIn.DonVi = "tờ";
            baiIn.IdHangKH = this.IdHangKhachHang();
            var frm = new BaiInToForm(thongTinChoBaiIn, baiIn);
            
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
           
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormBaiIn_Click(frm);
                //MessageBox.Show(this.BaiInS.Count().ToString());
                LoadBaiInLenListView();
            }
        }



        /* private void SuaBaiIn()
         {
            var thongTinChoBaiIn = new ThongTinBanDauChoBaiIn{
                 IdHangKhachHang = this.IdHangKhachHang(),
                 TinhTrangForm = (int)FormState.New,
                 YeuCauTinhGia = this.YeuCau

             if (this.IdBaiInChon > 0)
             {
                 var baiIn = tinhGiaPres.DocBaiInTheoID(this.IdBaiInChon);
                 //Nếu bài in đã có giấy không thể sửa
                 if (baiIn.CoGiayIn)
                 {
                     MessageBox.Show("Bạn không thể sửa khi đã thiết lập Giấy. Bạn phải xóa nó!");
                     return;
                 }
                 var frm = new BaiInForm(this.IdBaiInChon, (int)FormState.Edit, this.YeuCau, tinhGiaPres.IdHangKH());
                 //Điền giữ liệu: 
                 frm.ID = baiIn.ID;
                 frm.TieuDe = baiIn.TieuDe;
                 frm.DienGiai = baiIn.DienGiai;
                 frm.SoLuong = baiIn.SoLuong;
                 frm.DonViTinh = baiIn.DonVi;
                 //frm.TenHangKhachHang = baiIn.TenHangKH;//Điể form cập nhật

                 frm.MinimizeBox = false;
                 frm.MaximizeBox = false;
                 frm.StartPosition = FormStartPosition.CenterParent;
                 frm.ShowDialog();
                 //Xử Bấm click //trường hợp edit
                 if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                 {
                     XuLyNutOKTrenFormBaiIn_Click(frm);//Cập nhật dữ liệu
                     //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                     LoadBaiInLenListView();
                 }
             }
         }
         */

        private void XoaBaiIn()
        {
            if (this.IdBaiInChon > 0)
            {
                tinhGiaPres.Xoa_BaiIn(tinhGiaPres.DocBaiInTheoID(this.IdBaiInChon));
                LoadBaiInLenListView();
            }
        }
        private void XoaInCuon()
        {
            if (this.IdGiaSachDiGiChon > 0)
            {
                tinhGiaPres.Xoa_Cuon(tinhGiaPres.DocCuonTheoID(this.IdGiaSachDiGiChon));
                LoadCuonLenListView();
            }
        }
        
        private void XuLyNutOKTrenFormBaiIn_Click(BaiInToForm frm)
        {
            /*var baiIn = new KetQuaBaiIn();
            baiIn.DonVi = frm.DonViTinh;
            baiIn.DienGiai = frm.DienGiai;
            baiIn.TieuDe = frm.TieuDe;
            baiIn.SoLuong = frm.SoLuong;
            baiIn.IdHangKH = frm.IdHangKhachHang;
            baiIn.IdTinhGia = 0;
            baiIn.TomTat_ChaoKH = frm.TomTatBaiIn_ChaoKH; */

            switch (frm.TinhTrangForm)
            {
                case FormStateS.Edit:
                case FormStateS.New:
                    tinhGiaPres.Them_BaiIn(frm.DocBaiIn());
                    break;                                  
            }
        }
        private void LoadChiTietBaiInTheoIdBaiIn()//theo Id bài in chọn
        {
            txtTomTatBaiIn.Text = tinhGiaPres.TrinhBayNoiDungBaiIn();
        }
        private void LoadChiTietDanhThiepTheoIdDanhThiep()
        {
            txtTomTatBaiIn.Text = tinhGiaPres.TrinhBayNoiDungDanhThiep();
        }
        private void LoadChiTietInCuonDigi()
        {
            txtTomTatBaiIn.Text = tinhGiaPres.TrinhBayNoiDungInCuonDigi();
        }
        private void LoadChiTietBaiInTheNhua()
        {
            txtTomTatBaiIn.Text = tinhGiaPres.TrinhBayNoiDungTheNhua();
        }

        #endregion
        #region Về danh thiếp
        private void LoadDanhThiepListView()
        {
            //Xóa;
            lvwDanhThiep.Items.Clear();
            if (tinhGiaPres.TrinhBayDanhThiepS().Count() <= 0)
                return;

            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in tinhGiaPres.TrinhBayDanhThiepS())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                item.SubItems.AddRange(kvp.Value.ToArray());

                lvwDanhThiep.Items.Add(item);
            }
            lvwDanhThiep.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwDanhThiep.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwDanhThiep.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwDanhThiep.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwDanhThiep.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwDanhThiep.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void ThemDanhThiep()
        {
            var thongTinBanDau = new ThongTinBanDauChoDanhThiep
            {
                IdHangKhachHang = this.IdHangKhachHang(),
                TinhTrangForm = FormStateS.New
            };

            BaiInDanhThiep baiInDThiep = new BaiInDanhThiep(0, "", "9 x 5.5cm", 5, 2);
            baiInDThiep.TieuDe = "Danh thiếp";

            var frm = new GiaInDanhThiepForm(thongTinBanDau, baiInDThiep);
            frm.Text = "Tính giá danh thiếp";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormDanhThiep(frm);
                //MessageBox.Show(this.BaiInS.Count().ToString());
                LoadDanhThiepListView();
            }
        }
        private void XuLyNutOKTrenFormDanhThiep(GiaInDanhThiepForm frm)
        {
            /*var baiIn = new KetQuaBaiIn();
            baiIn.DonVi = frm.DonViTinh;
            baiIn.DienGiai = frm.DienGiai;
            baiIn.TieuDe = frm.TieuDe;
            baiIn.SoLuong = frm.SoLuong;
            baiIn.IdHangKH = frm.IdHangKhachHang;
            baiIn.IdTinhGia = 0;
            baiIn.TomTat_ChaoKH = frm.TomTatBaiIn_ChaoKH; */

            switch (frm.TinhTrangForm)
            {
                case FormStateS.Edit:
                case FormStateS.New:
                    tinhGiaPres.Them_DanhThiep(frm.DocBaiInDanhThiep());
                    break;
            }
        }
        private void XoaDanhThiep()
        {
            if (this.IdDanhThiepChon > 0)
            {
                tinhGiaPres.Xoa_DanhThiep(tinhGiaPres.DocDanhThiepTheoID(this.IdDanhThiepChon));
                LoadDanhThiepListView();
            }
        }
        #endregion


        private void btnThemBaiIn_Click(object sender, EventArgs e)
       {
           switch (tabCtrl01.SelectedIndex)
           {
               case 0:
                   ThemDanhThiep();
                   break;
               case 1:
                   ThemBaiIn();
                  
                   //MessageBox.Show(this.DuocGopTrangInCuaBaiIn.ToString());
                   break;
               case 2:
                   ThemCuon();
                   break;
               case 3:
                   ThemTheNhua();
                   break;

           }

           CapNhatThanhTienTheoTab();
           //Cập nhật tổng kết bài
           this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTinhGia_ChaoKH();
       }
        #region VeCuon
        private void ThemCuon()
        {
            var thongTinChoSach = new ThongTinBanDauChoBaiIn
            {
                IdHangKhachHang = this.IdHangKhachHang(),
                TinhTrangForm = FormStateS.New,
                TieuDeForm = "[Mới] Tính giá Cuốn",
                YeuCauTinhGia = ""
            };
            var quiCachSach = new Sach
            {
                ChieuCao = 10,
                ChieuRong = 5,
                GayDay = 0.5f,
                KieuDongCuon = KieuDongCuonS.KimKeoNep,
                SoTrangBia = 4,
                SoTrangRuot = 8
            };
            var giaSach = new GiaInSachDigi(quiCachSach, 10, this.IdHangKhachHang(),
                 0, "In cataloque");

            var frm = new InSachForm(thongTinChoSach, giaSach);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormCuon(frm);
                //MessageBox.Show(this.BaiInS.Count().ToString());
                LoadCuonLenListView();
            }
        }
        private void SuaCuon()
        {
            var thongTinChoSach = new ThongTinBanDauChoBaiIn
            {
                IdHangKhachHang = this.IdHangKhachHang(),
                TinhTrangForm = FormStateS.Edit,
                YeuCauTinhGia = ""
            };
            
            var giaSach = tinhGiaPres.DocCuonTheoID(this.IdGiaSachDiGiChon);

            var frm = new InSachForm(thongTinChoSach, giaSach);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                 XuLyNutOKTrenFormCuon(frm);
                //MessageBox.Show(this.BaiInS.Count().ToString());
                 LoadCuonLenListView();
            }
        }
        private void XuLyNutOKTrenFormCuon(InSachForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.Edit:
                    frm.DocGiaInSachDigi();//Để cập nhật
                    break;
                case FormStateS.New:
                    tinhGiaPres.Them_Sach(frm.DocGiaInSachDigi());
                    break;
            }
        }
        private void LoadCuonLenListView()
        {
            /*lvwCuon.Columns.Add("Id");
           lvwCuon.Columns.Add("Tiêu đề");
           lvwCuon.Columns.Add("Khổ cuốn");
           lvwCuon.Columns.Add("Số Trang/Cuốn");
           lvwCuon.Columns.Add("Số lượng");
           lvwCuon.Columns.Add("Thành tiền"); */ 
            //Xóa;
            lvwCuon.Items.Clear();
            //MessageBox.Show(tinhGiaPres.TrinhBayCuonS().Count().ToString());
            if (tinhGiaPres.TrinhBayCuonS().Count() <= 0)
                return;

            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in tinhGiaPres.TrinhBayCuonS())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                item.SubItems.AddRange(kvp.Value.ToArray());

                lvwCuon.Items.Add(item);
            }
            lvwCuon.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwCuon.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwCuon.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwCuon.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwCuon.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwCuon.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        #endregion
        #region Về thẻ nhựa
        private void LoadTheNhuaListView()
        {
            //Xóa;
            lvwTheNhua.Items.Clear();
            if (tinhGiaPres.TrinhBayTheNhuaS().Count() <= 0)
                return;

            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in tinhGiaPres.TrinhBayTheNhuaS())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                item.SubItems.AddRange(kvp.Value.ToArray());

                lvwTheNhua.Items.Add(item);
            }
            lvwTheNhua.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTheNhua.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTheNhua.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTheNhua.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwTheNhua.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTheNhua.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void ThemTheNhua()
        {
            var thongTinBanDau = new ThongTinBanDauChoDanhThiep
            {
                IdHangKhachHang = this.IdHangKhachHang(),
                TinhTrangForm = FormStateS.New
            };
            var baiInTheNhua = new BaiInTheNhua(0, "", "", 10, 2);
            baiInTheNhua.TieuDe = "In thẻ VIP";
            baiInTheNhua.KichThuoc = "8 x 5.5cm";
            baiInTheNhua.SoLuongThe = 10;
            

            var frm = new GiaInTheNhuaForm(thongTinBanDau, baiInTheNhua);
            frm.Text = "Tính giá Thẻ nhựa";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormTheNhua(frm);
                //MessageBox.Show(this.BaiInS.Count().ToString());
                LoadDanhThiepListView();
            }
        }
        private void XuLyNutOKTrenFormTheNhua(GiaInTheNhuaForm frm)
        {
            switch (frm.TinhTrangForm)
            {
                case FormStateS.Edit:

                case FormStateS.New:
                    tinhGiaPres.Them_TheNhua(frm.DocBaiInDanhThiep());
                    break;
            }
            LoadTheNhuaListView();
        }
        private void XoaTheNhua()
        {
            if (this.IdTheNhuaChon > 0)
            {
                tinhGiaPres.Xoa_TheNhua(tinhGiaPres.DocTheNhuaTheoID(this.IdTheNhuaChon));
                LoadTheNhuaListView();
            }
        }
        #endregion
        private void btnSuaBaiIn_Click(object sender, EventArgs e)
       {
           switch (tabCtrl01.SelectedIndex)
           {
               case 0:
                   break;
           
           }
       }

       private void btnXoaBaiIn_Click(object sender, EventArgs e)
       {
           switch (tabCtrl01.SelectedIndex)
           {
               case 0:
                   XoaDanhThiep();
                   
                   break;
               case 1:
                   XoaBaiIn();
                  
                   break;
               case 2:
                   XoaInCuon();
                   //Xóa load luôn trong Hàm rồi
                   break;
               case 3:
                   XoaTheNhua();
                   
                   break;
           }
           CapNhatThanhTienTheoTab();
           //Cập nhật tổng kết bài
           this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTinhGia_ChaoKH();
       }
              

      
       private void ListView_SelectedIndexChanged(object sender, EventArgs e)
       {
           ListView lv;
           if (sender is ListView)
           {
               lv = (ListView)sender;
               if (lv == lvwBaiIn)
               {
                   LoadChiTietBaiInTheoIdBaiIn();
               }
               if (lv == lvwDanhThiep)
               {
                   LoadChiTietDanhThiepTheoIdDanhThiep();
               }
               if (lv == lvwCuon)
                   LoadChiTietInCuonDigi();
               if (lv == lvwTheNhua)
                   LoadChiTietBaiInTheNhua();
           }
          
           //txtTomTatTinhGia.Text = tinhGiaPres.TomTatTinhGia_ChaoKH();
           //Cập nhật thành tiền
           CapNhatThanhTienTheoTab();
       }

       private bool KiemTraHopLe(ref string errorMessage)
       {
           var result = true;
           List<string> loiS = new List<string>();

        
           if (string.IsNullOrEmpty(txtTieuDeTinhGia.Text))
               loiS.Add("Tiêu đề tính giá cần có");
          
           
           if (string.IsNullOrEmpty(txtTenNV.Text))
               loiS.Add("Tên nhân viên rỗi");
           
           if (loiS.Count > 0)
           {
               result = false;
               foreach (string st in loiS)
                   errorMessage += st + "/";
           }
           //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
           return result;
       }

       private void TinhGiaForm_FormClosing(object sender, FormClosingEventArgs e)
       {
          
               string ms = "";
               if (!KiemTraHopLe(ref ms))
               {
                   var dialogeR = MessageBox.Show(ms, "Nội dung thiếu, bạn muốn làm tiêp?",
                        MessageBoxButtons.YesNo);
                   if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                       e.Cancel = true;
                   else

                       this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
               }
           
       }
       private void Forms_FormClosing(object sender, FormClosingEventArgs e)
       {
           if (this.FormChanged)
           {
               var dialogeR = MessageBox.Show(this.Text, "Dữ liệu đãy thay đổi, bạn muốn lưu?",
                    MessageBoxButtons.YesNo);
               if (dialogeR == System.Windows.Forms.DialogResult.Yes)
               {
                   e.Cancel = true;
                   if (LuuLai())
                   {
                       MakeFormChange(false);
                       e.Cancel = false;
                   
                   }
               }
               e.Cancel = false;
           }
           /*
           string ms = "";
           if (!KiemTraHopLe(ref ms))
           {
               var dialogeR = MessageBox.Show(ms, "Nội dung thiếu, bạn muốn làm tiêp?",
                    MessageBoxButtons.YesNo);
               if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                   e.Cancel = true;
               else

                   this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           }
            */

       }
       private bool LuuLai()
       {
           var ketQua = true;
           string str = "";
           if (KiemTraHopLe(ref str))
           {
               switch (this.TinhTrangForm)
               {
                   case FormStateS.New:
                       MessageBox.Show(tinhGiaPres.ThemTinhGia());

                       break;
                   case FormStateS.Edit:
                       MessageBox.Show(tinhGiaPres.CapNhatTinhGia());

                       break;
               }              
           }
           else
           {
               ketQua = false;
               MessageBox.Show(str, "...là nội dung thiếu, bạn cần điền vô");               
           }
           return ketQua;
       }
       private void btnLuu_Click(object sender, EventArgs e)
       {
           //Cập nhật lại tóm tắt cho chắc
           this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTinhGia_ChaoKH();
           if (LuuLai())
               MakeFormChange(false);
       }

       private void btnCopy_Click(object sender, EventArgs e)
       {
         
           Clipboard.SetText(tinhGiaPres.TomTatTinhGia_ChaoKH());
       }

       private void btnClose_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void btnXoaSachBaiIn_Click(object sender, EventArgs e)
       {
           switch (tabCtrl01.SelectedIndex)
           {
               case 0:
                   tinhGiaPres.XoaTatCa_DanhThiep();
                   LoadDanhThiepListView();
                   break;
               case 1:
                   tinhGiaPres.XoaTatCa_BaiIn();
                   LoadBaiInLenListView();
                   break;
               case 2:
                   tinhGiaPres.XoaTatCa_Cuon();
                   LoadCuonLenListView();
                   break;
               case 3:
                   tinhGiaPres.XoaTatCa_TheNhua();
                   LoadTheNhuaListView();
                   break;

           }
           CapNhatThanhTienTheoTab();
           //Cập nhật tổng kết bài
           this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTinhGia_ChaoKH();
           
       }

       private void btnNoiDungTinhGia_Click(object sender, EventArgs e)
       {
           Clipboard.SetText( tinhGiaPres.TrinhBayNoiDungBaiIn());
       }

       private void tabCtrl01_SelectedIndexChanged(object sender, EventArgs e)
       {

       }
       private void MakeFormChange(bool ketQua)
       {
           this.FormChanged = ketQua;
           btnLuu.Enabled = this.FormChanged;
       }

       private void cboHangKH_SelectedIndexChanged(object sender, EventArgs e)
       {
           txtDienGiaiHangKH.Text = tinhGiaPres.DienGiaiHangKH();
           MakeFormChange(true);
       }
       private void TextBoxe_TextChanged(object sender, EventArgs e)
       {
           Telerik.WinControls.UI.RadTextBox tb;
           if (sender is Telerik.WinControls.UI.RadTextBox)
           {
               tb = (Telerik.WinControls.UI.RadTextBox)sender;
               if (tb == txtTenNV || tb == txtTieuDeTinhGia ||
                   tb == txtTenKhachHang)
               {
                   MakeFormChange(true);
               }
           }
          Telerik.WinControls.UI.RadDateTimePicker dtp;
          if (sender is Telerik.WinControls.UI.RadDateTimePicker)
           {
               dtp = (Telerik.WinControls.UI.RadDateTimePicker)sender;
               if (dtp == dtpNgay)
               {
                   MakeFormChange(true);
               }
           }
       }
       private void CapNhatTextNutThemXoa()
       {
           //Cập nhật các nút
           btnThem.Text = "Thêm " + tabCtrl01.SelectedTab.Text;
           btnXoa.Text = "Xóa " + tabCtrl01.SelectedTab.Text;
       }
       private void btnCopyToClipboardMucTinh_Click(object sender, EventArgs e)
       {
           if (!string.IsNullOrEmpty(txtTomTatBaiIn.Text.Trim()))
               Clipboard.SetText(txtTomTatBaiIn.Text);
       }
       private void btnCopyToClipboarTinhGia_Click(object sender, EventArgs e)
       {
           if (!string.IsNullOrEmpty(txtTomTatTinhGia.Text.Trim()))
               Clipboard.SetText(txtTomTatTinhGia.Text);
       }

       private void tabCtrl01_SelectedIndexChanged_1(object sender, EventArgs e)
       {
           CapNhatTextNutThemXoa();
           //Cập nhật thành tiền từng tab
           CapNhatThanhTienTheoTab();
           CapNhatTomTatNoiDungTheoTab();
       }

       private void CapNhatThanhTienTheoTab()
       {
           //và đóng mở cập nhật nút checkbox gom
           decimal thanhTien = 0;
           switch (tabCtrl01.SelectedIndex)
           {
               case 0: //Danh thiếp
                   thanhTien = tinhGiaPres.TongGiaDanhThiep();
                   chkGopSoTrangInTo.Visible = false;
                   break;
               case 1: //Bài in
                   thanhTien = tinhGiaPres.TongGiaBaiIn();
                   chkGopSoTrangInTo.Visible = true;
                   break;
               case 2: //Cuốn
                   thanhTien = tinhGiaPres.TongGiaCuon();
                   chkGopSoTrangInTo.Visible = false;
                   break;
               case 3: //Thẻ nhựa
                   thanhTien = tinhGiaPres.TongGiaTheNhua();
                   chkGopSoTrangInTo.Visible = false;
                   break;

           }

           txtThanhTien.Text = string.Format("{0:0,0.00}đ", thanhTien);

       }
        private void CapNhatTomTatNoiDungTheoTab()
       {
            //Theo tổng tab
           switch (tabCtrl01.SelectedIndex)
           {
               case 0: //Danh thiếp
                   this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTab_DanhThiep();
                   break;
               case 1: //Bài in
                   this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTab_BaiIn();
                   break;
               case 2: //Cuốn
                   this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTab_InCuon();
                   break;
               case 3: //Thẻ nhựa
                   this.TomTatTungMucChaoKH = tinhGiaPres.TomTatTab_TheNhua();
                   break;

           }
       }

       private void TinhGiaForm_Resize(object sender, EventArgs e)
       {
           pnlSubTotal.Width = tabCtrl01.Width;
           pnlSubTotal.Left = tabCtrl01.Left;
       }

       private void lvwTheNhua_ColumnCreating(object sender, Telerik.WinControls.UI.ListViewColumnCreatingEventArgs e)
       {
           
        
       }

       private void chkGopSoTrangInTo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
       {
           //xét xem có cho Gộp trang in hay không
           var duocGopTrang = tinhGiaPres.DuocGopTrangInTheoBaiIn();
           //Nếu True thì cho phép check được
           if (!duocGopTrang)
           {
               if (chkGopSoTrangInTo.Checked) //nếu lỡ check
                   chkGopSoTrangInTo.Checked = false;
           }
           //Quan trọng vì tính gộp giá là do mục này
           tinhGiaPres.CapNhatQuyetDinhGopGia();
           //
           CapNhatThanhTienTheoTab();
           CapNhatTomTatNoiDungTheoTab();
       }

       private void txtTomTatTinhGia_Enter(object sender, EventArgs e)
       {
           this.TomTatTinhGia = tinhGiaPres.TomTatTinhGia_ChaoKH();
       }
      
       
    }
}
