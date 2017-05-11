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
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;

namespace TinhGiaInClient
{
    public partial class TinhGiaForm : Form, IViewTinhGiaIn
    {
        TinhGiaPresenter tinhGiaPres = null;
        public TinhGiaForm(int tinhTrangForm)
        {
            InitializeComponent();
            this.TinhTrangForm = tinhTrangForm;
            tinhGiaPres = new TinhGiaPresenter(this);
            tinhGiaPres.NoiDungBanDau();
            //event
            this.FormClosing += new FormClosingEventHandler(Forms_FormClosing);
            
        }
        #region Thi công  IView
        public int ID 
        { get; set; }
        public DateTime NgayTinhGia
        {
            get { return dtpNgay.Value; }
            set { dtpNgay.Value = value; }
        }
        public string So
        {
            get { return txtSoTinhGia.Text; }
            set { txtSoTinhGia.Text = value; }
        }
        public string TenKhachHang
        {
            get { return txtTenKhachHang.Text; }
            set { txtTenKhachHang.Text = value; }
        }
        public string LienHe 
        {
            get { return txtLienHe.Text; }
            set { txtLienHe.Text = value; }
        }
        public string YeuCau
        {
            get { return txtYeuCau.Text; }
            set { txtYeuCau.Text = value; }
        }
        public string TenNhanVien
        {
            get { return txtTenNV.Text; }
            set { txtTenNV.Text = value; }
        }
        public int TinhTrangForm { get; set; }
        public List<string> TomTatCauHinhSP 
        {
            get { return txtCauHinhSP.Lines.ToList(); }
            set { txtCauHinhSP.Lines = value.ToArray(); }
        }
        public List<string> TomTatGiayDeIn 
        {
            get { return txtGiayDeIn.Lines.ToList(); }
            set { txtGiayDeIn.Lines = value.ToArray(); }
        }
        public List<string> TomTatChaoKH
        {
            get { return txtTomTatBaiIn.Lines.ToList(); }
            set { txtTomTatBaiIn.Lines = value.ToArray(); }
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
        
        
        
        
        int _idGiaInChon = 0;
        public int IdGiaInChon
        {
            get
            {
                if (lvwGiaInNhanh.SelectedItems.Count > 0)
                    int.TryParse(lvwGiaInNhanh.SelectedItems[0].Text, out _idGiaInChon);
                return _idGiaInChon;
            }
            set { _idGiaInChon = value; }
        }
        
        int _idThanhPhamChon = 0;
        public int IdThanhPhamChon
        {
            get
            {
                if (lvwThanhPham.SelectedItems.Count > 0)
                    int.TryParse(lvwThanhPham.SelectedItems[0].Text, out _idThanhPhamChon);
                return _idThanhPhamChon;
            }
            set { _idThanhPhamChon = value; }
        }
        #endregion
        Dictionary<int,TabPage> tabList = new Dictionary<int,TabPage>();
        private void txtCustName_TextChanged(object sender, EventArgs e)
        {

        }
        private void TaoCayDanhMucTab()
        {
            //Tạo thư mục gốc, đọc tab control và lôi ra
            TreeNode rootItem = null;
            rootItem = new TreeNode();
            rootItem.Text = this.Text;
            rootItem.Tag = 0;
            tabList.Clear();
            TreeNode item = null;
            int tabI = 0;
            foreach (TabPage tab in tabCtrl01.TabPages)
            {
                item = new TreeNode();
                item.Text = tab.Text;
                item.Tag = tab;
                tabList.Add(tabI, tab);
                rootItem.Nodes.Add(item);
                tabI++;
            }
            trvMucLucBaiIn.Nodes.Add(rootItem);
            trvMucLucBaiIn.ExpandAll();
        }
        private void LoadCayDanhMuc()
        {
            TaoCayDanhMucTab();

            
        }

        private void TinhGiaForm_Load(object sender, EventArgs e)
        {
            LoadCayDanhMuc();
            TrinhBayListView();
        }

        private void trvMucLuc_Click(object sender, EventArgs e)
        {
            
        }

        private void trvMucLuc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Rảo xem theo tab
            if (trvMucLucBaiIn.SelectedNode == null)
                return;

            var selNode = trvMucLucBaiIn.SelectedNode;
            if ((int)selNode.Index <= 0)
            {
                tabCtrl01.SelectedIndex = 0;
                return;
            }
            //MessageBox.Show("Số node " + selNode.Index.ToString());
            TabPage tmpTab = null;
            tmpTab = (TabPage)selNode.Tag;
            
            foreach (KeyValuePair<int,TabPage> kVP in tabList)
            {
                if (kVP.Value.Name == tmpTab.Name)
                {
                   // MessageBox.Show(tab.Name);
                    tabCtrl01.SelectedIndex = kVP.Key;
                    break;
                }                
            }
            
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
            lvwBaiIn.Columns.Add("Cấu hình SP");
            lvwBaiIn.Columns.Add("Giấy In");
            lvwBaiIn.Columns.Add("SL In");
            lvwBaiIn.Columns.Add("SL Th. Phẩm");
            lvwBaiIn.View = System.Windows.Forms.View.Details;
            lvwBaiIn.HideSelection = false;
            lvwBaiIn.FullRowSelect = true;
            //===hết
           

        }
        #region Về Bài In
        private void LoadBaiInLenListView()
        {
            //Xóa;
            lvwBaiIn.Items.Clear();
            if (tinhGiaPres.BaiInS().Count() <= 0)
                return;

            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in tinhGiaPres.BaiInS())
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
            lvwBaiIn.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwBaiIn.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwBaiIn.Columns[8].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void ThemBaiIn()
        {

            var frm = new BaiInForm((int)Enumss.FormState.New);
            
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
        private void SuaBaiIn()
        {

            if (this.IdBaiInChon > 0)
            {
                var baiIn = tinhGiaPres.DocBaiInTheoId(this.IdBaiInChon);
                //Nếu bài in đã có giấy không thể sửa
                if (baiIn.CoGiayIn)
                {
                    MessageBox.Show("Bạn không thể sửa khi đã thiết lập Giấy. Bạn phải xóa nó!");
                    return;
                }
                var frm = new BaiInForm((int)Enumss.FormState.Edit, baiIn.TenHangKH);
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
        private void XoaBaiIn()
        {
            if (this.IdBaiInChon > 0)
            {
                tinhGiaPres.XoaBaiIn(tinhGiaPres.DocBaiInTheoId(this.IdBaiInChon));
                LoadBaiInLenListView();
            }
        }
        private void XuLyNutOKTrenFormBaiIn_Click(BaiInForm frm)
        {
            var baiIn = new BaiIn(frm.TieuDe);
            baiIn.DonVi = frm.DonViTinh;
            baiIn.DienGiai = frm.DienGiai;
            baiIn.TieuDe = frm.TieuDe;
            baiIn.SoLuong = frm.SoLuong;
            baiIn.IdHangKH = frm.IdHangKhachHang;
            baiIn.TenHangKH = frm.TenHangKhachHang;

            switch (frm.TinhTrangForm)
            {           
                case (int)Enumss.FormState.New:
                    tinhGiaPres.ThemBaiIn(baiIn);
                    break;
                case (int)Enumss.FormState.Edit:
                    //Cập nhật lại ID bài in /do tự động +1 khi new
                    baiIn.ID = frm.ID;
                    //Cập nhật lại
                    tinhGiaPres.SuaBaiIn(baiIn);
                    break;
            }
        }
        private void LoadChiTietBaiInTheoIdBaiIn()//theo Id bài in chọn
        {
            lblBaiIn.Text = tinhGiaPres.TieuDeBaInChon();
            //Cấu hình
            this.TomTatCauHinhSP = tinhGiaPres.TomTatCauHinhSP();
            //giấy in
            this.TomTatGiayDeIn = tinhGiaPres.TomTatGiayDeIn();
            //Giá in
            LoadGiaInLenListView();
            //Thành phẩm
            LoadThanhPhamLenListView();
            //Tóm tắt
            this.TomTatChaoKH = tinhGiaPres.TomTatBaiIn_ChaoKH();
        }
        #endregion
        #region Cấu hình SP
        
       
        private void GanCauHinhVoBaiIn()
        {
            if (this.IdBaiInChon <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = tinhGiaPres.DocBaiInTheoId(this.IdBaiInChon);
            if (baiIn.CoCauHinh) //Đã có cấu hình
                return;
            //Gắn
            var frm = new TrienKhaiCauHinhSPForm((int)Enumss.FormState.New);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua
            frm.IdBaiIn = baiIn.ID;
            frm.ThongTinBaiIn = baiIn.DienGiai;
            frm.TenCauHinh = baiIn.TieuDe;
            frm.SoLuong = baiIn.SoLuong;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormTrienKhaiSP_Click(frm);
                LoadBaiInLenListView();
            }

        }

        private void btnSuaCauHinhSP_Click(object sender, EventArgs e)
        {
            if (this.IdBaiInChon <= 0)
                return;
            var chSP = tinhGiaPres.LayCauHinhSPTheoBaiIn();
            if (chSP == null)
                return;

            var frm = new TrienKhaiCauHinhSPForm((int)Enumss.FormState.Edit, chSP);
            //Tiếp tục gắn thêm dữ liệu
            var baiIn = tinhGiaPres.DocBaiInTheoId(this.IdBaiInChon);
            frm.TenCauHinh = baiIn.TieuDe;
            frm.SoLuong = baiIn.SoLuong;
            frm.IdBaiIn = baiIn.ID;
            frm.ThongTinBaiIn = baiIn.DienGiai;
            //Điền giữ liệu:                
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            //Xử Bấm click //trường hợp edit
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormTrienKhaiSP_Click(frm);//Cập nhật dữ liệu

                LoadBaiInLenListView();//Cập nhật
            }


        }
        private void btnXoaCauHinhSP_Click(object sender, EventArgs e)
        {
            tinhGiaPres.XoaCauHinhSanPham();
            this.TomTatCauHinhSP = tinhGiaPres.TomTatCauHinhSP();
            //Xóa               
            LoadBaiInLenListView();
        }
       
       private void XuLyNutOKTrenFormTrienKhaiSP_Click(TrienKhaiCauHinhSPForm frm)
       {
           var cauHinhSP = new CauHinhSanPham(new KhoSanPham
                   {
                       KhoCatRong = frm.KhoCatRong,
                       KhoCatCao = frm.KhoCatCao
                   },                                                                      
                                                     frm.TranLeTren,
                                                      frm.TranLeDuoi,
                                                      frm.TranLeTrong,
                                                      frm.TranLeNgoai,
                                                      frm.LeTren,
                                                      frm.LeDuoi,
                                                      frm.LeTrong,
                                                      frm.LeNgoai,
                                                      frm.IdBaiIn);

           switch (frm.formState)
           {
               case (int)Enumss.FormState.New:
                   //Add
                   tinhGiaPres.GanCHSPVoBaiIn(cauHinhSP);
                   this.TomTatCauHinhSP = tinhGiaPres.TomTatCauHinhSP();
                   break;
               case (int)Enumss.FormState.Edit:
                   cauHinhSP.IDCauHinh = frm.IdCauHinhSP;                  
                   tinhGiaPres.CapNhatCHSPVoBaiIn(cauHinhSP);
                   this.TomTatCauHinhSP = tinhGiaPres.TomTatCauHinhSP();
                   break;
           }
       }
        #endregion cấu hình SP
     
       #region Về Giấy     
       private void GanGiayVoBaiIn()
       {
           if (this.IdBaiInChon <= 0)
               return;
           //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
           var baiIn = tinhGiaPres.DocBaiInTheoId(IdBaiInChon);
           if (baiIn.CoGiayIn) //Đã có thì không gắn
               return;
           //Kiểm nếu đã có cấu hình mới được gắn
           if (!baiIn.CoCauHinh)
           {
               MessageBox.Show("Chưa có cấu hình Sản phẩm. Bạn cần gắn trước");
               return;
           }
           //Tiến hành gắn
           var frm = new GiayDeInForm((int)Enumss.FormState.New);
           frm.MinimizeBox = false;
           frm.MaximizeBox = false;
           frm.StartPosition = FormStartPosition.CenterParent;
           //Data gởi qua ỏm
           frm.IdBaiIn = baiIn.ID;
           frm.IdHangKH = baiIn.IdHangKH;
           frm.DienGiayBaiIn = baiIn.DienGiai;
           frm.ThongTinBaiIn_CauHinh = tinhGiaPres.LayCauHinhSPTheoBaiIn().ThongTinCauHinh
               + string.Format(" / Số lượng: {0} {1}", baiIn.SoLuong, baiIn.DonVi) ;
           
           frm.ShowDialog();
           if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
           {
               XuLyNutOKTrenFormChuanBiGiay_Click(frm);
               //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
               LoadBaiInLenListView();
               //Cập nhật lại danh sách bài in đã nằm trong LoadGiay
               
           }
           
       }
       private void SuaGiayIn()
       {
           if (this.IdBaiInChon <= 0)
               return;

           var giayIn = tinhGiaPres.LayGiayDeInTheoBaiIn();
           if (giayIn == null)
               return;

           var frm = new GiayDeInForm((int)Enumss.FormState.Edit);
           //Điền dữ liệu: 
           var baiIn = tinhGiaPres.DocBaiInTheoId(giayIn.IdBaiIn);
           frm.ID = giayIn.ID;
           frm.DienGiayBaiIn = baiIn.DienGiai; //bài in
           frm.IdHangKH = baiIn.IdHangKH;
           var cauHinhSP = tinhGiaPres.LayCauHinhSPTheoBaiIn();
           frm.ThongTinBaiIn_CauHinh = cauHinhSP.ThongTinCauHinh;
           frm.TenGiayIn = giayIn.TenGiayIn;
           frm.GiayKhachDua = giayIn.GiayKhachDua;
           frm.KhoToChay = giayIn.KhoToChay;
           frm.SoConTrenToChay = giayIn.SoConTrenToChay;
           frm.GiayChon = giayIn.GiayChon;
           frm.SoLuongToChayLyThuyet = giayIn.SoLuongToChayLyThuyet;
           frm.SoLuongToChayBuHao = giayIn.SoLuongToChayBuHao;
           frm.SoToGiayLon = giayIn.SoLuongToLonCan;

           frm.MinimizeBox = false;
           frm.MaximizeBox = false;

           frm.StartPosition = FormStartPosition.CenterParent;
           frm.ShowDialog();
           //Xử Bấm click //trường hợp edit
           if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
           {
               XuLyNutOKTrenFormChuanBiGiay_Click(frm);//Cập nhật dữ liệu

               LoadBaiInLenListView();//đã cập nhật luôn 
           }


       }
       private void XuLyNutOKTrenFormChuanBiGiay_Click(GiayDeInForm frm)
       {
           var gDeIn = new GiayDeIn();
           gDeIn.GiayChon = frm.GiayChon;
           gDeIn.TenGiayIn = frm.TenGiayIn;
           gDeIn.GiayKhachDua = frm.GiayKhachDua;
           gDeIn.IdBaiIn = frm.IdBaiIn;
           gDeIn.KhoToChay = frm.KhoToChay;
           gDeIn.SoConTrenToChay = frm.SoConTrenToChay;
           gDeIn.SoLuongToChayLyThuyet = frm.SoLuongToChayLyThuyet;
           gDeIn.SoLuongToChayBuHao = frm.SoLuongToChayBuHao;
           gDeIn.SoToChayTong = frm.SoLuongToChayTong;
           gDeIn.SoLuongToLonCan = frm.SoToGiayLon;
           gDeIn.GiaBan = frm.GiaBan;
           gDeIn.ThanhTien = frm.ThanhTien;
           switch (frm.FormState)
           {
               case (int)Enumss.FormState.New:
                   //Add                                   
                   tinhGiaPres.GanGiayDeIn(gDeIn);
                   this.TomTatGiayDeIn = tinhGiaPres.TomTatGiayDeIn();
                   break;
               case (int)Enumss.FormState.Edit:                   
                   //Đổi ID vì thêm mới là có id mới
                   gDeIn.ID = frm.ID;
                   //Cập nhật lại
                   tinhGiaPres.CapNhatGiayDeIn(gDeIn);
                   this.TomTatGiayDeIn = tinhGiaPres.TomTatGiayDeIn();
                   break;
           }
       }
       private void btnThemGiay_Click(object sender, EventArgs e)
       {
           
       }
       private void mnuGanGiayChoSP_Click(object sender, EventArgs e)
       {/*
           //Kiểm cấu hình giấy chọn đã được gắn chưa
           if (this.IdCauHinhSPChon > 0)
           {
               GiayDeInForm frm = new GiayDeInForm((int)Ennums.FormState.New);
               frm.MaximizeBox = false;
               frm.MinimizeBox = false;
               frm.Text = "Chuẩn bị Giấy";
               frm.ShowDialog();
           }
         */
       }
        #endregion
       #region Về Giá In
       private void LoadGiaInLenListView()
       {
           //List view Giá In:
           lvwGiaInNhanh.Clear();
           lvwGiaInNhanh.Columns.Add("Id");
           lvwGiaInNhanh.Columns.Add("IdBaiIn");
           lvwGiaInNhanh.Columns.Add("Tên tờ In");
           lvwGiaInNhanh.Columns.Add("Bảng giá");
           lvwGiaInNhanh.Columns.Add("Số lượng");
           lvwGiaInNhanh.Columns.Add("Đơn giá");
           lvwGiaInNhanh.Columns.Add("Thành tiền");
           lvwGiaInNhanh.View = System.Windows.Forms.View.Details;
           lvwGiaInNhanh.HideSelection = false;
           lvwGiaInNhanh.FullRowSelect = true;
           //==đền dữ liệu
           if (tinhGiaPres.GiaInS().Count() > 0)
           {
               //Lấy 2 item từ bài in

               ListViewItem item;
               foreach (GiaIn giaIn in tinhGiaPres.GiaInS())
               {
                   item = new ListViewItem();
                   item.Text = giaIn.ID.ToString();
                   //lấy
                   //MessageBox.Show(chSP.IdBaiIn.ToString());

                   item.SubItems.Add(giaIn.IdBaiIn.ToString());                   
                   item.SubItems.Add(giaIn.TenToInDigiChon);
                   item.SubItems.Add(giaIn.TenBangGiaChon);
                   item.SubItems.Add(string.Format("{0:0,0} A4", giaIn.SoTrangA4));
                   item.SubItems.Add(string.Format("{0:0,0.00}đ/A4", giaIn.TienIn / giaIn.SoTrangA4));
                   item.SubItems.Add(string.Format("{0:0,0.00}đ", giaIn.TienIn));
                   lvwGiaInNhanh.Items.Add(item);
               }
               lvwGiaInNhanh.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiaInNhanh.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiaInNhanh.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               lvwGiaInNhanh.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               lvwGiaInNhanh.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               lvwGiaInNhanh.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiaInNhanh.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               //Load lại bài in để cập nhật tình trạng
               LoadBaiInLenListView();
           }
       }
    
        private void ThemGiaInNhanh()
       {
      
           if (this.IdBaiInChon <= 0)
               return;
           //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
           var baiIn = tinhGiaPres.DocBaiInTheoId(this.IdBaiInChon);
          //Gắn thoải mái vì có thể in mấy lần ví dụ in mực trắng

           //Kiểm nếu đã có cấu hình mới được gắn
           if (!baiIn.CoCauHinh)
           {
               MessageBox.Show("Chưa có cấu hình Sản phẩm. Bạn cần gắn trước");
               return;
           }
           if (!baiIn.CoGiayIn)
           {
               MessageBox.Show("Chưa có giấy. Bạn phải cài giấy trước");
               return;
           }
           //Tiến hành gắn
           //Gắn giấy in
           var giayIn = tinhGiaPres.LayGiayDeInTheoBaiIn();
           var frm = new GiaInForm(baiIn.IdHangKH, giayIn.SoToChayTong);
           frm.FormState = (int)Enumss.FormState.New;
           frm.MinimizeBox = false;
           frm.MaximizeBox = false;
           frm.StartPosition = FormStartPosition.CenterParent;
           //Data gởi qua ỏm
           frm.IdBaiIn = baiIn.ID;           
           frm.ThongTinGiay = giayIn.KhoToChay + "/" + giayIn.TenGiayIn + "/"
               + string.Format("{0}gsm; Tờ chạy: {1} tờ",
               giayIn.GiayChon.DinhLuong, giayIn.SoToChayTong);
          
           frm.ShowDialog();
           if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
           {
               XuLyNutOKTrenFormGiaIn_Click(frm);
               //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
               LoadGiaInLenListView();
               //Cập nhật lại danh sách bài in đã nằm trong LoadGiay
               
           }           
       }
        private void SuaGiaIn()
        {
            if (this.IdGiaInChon > 0)
            {
                var giaIn = tinhGiaPres.LayGiaInTheoId(this.IdGiaInChon);
                var baiIn = tinhGiaPres.DocBaiInTheoId(giaIn.IdBaiIn);
                //Gắn giấy in
                var giayIn = tinhGiaPres.LayGiayDeInTheoBaiIn();
                var frm = new GiaInForm(baiIn.IdHangKH, giayIn.SoToChayTong);
                frm.FormState = (int)Enumss.FormState.Edit;
                //Điền giữ liệu: 

                frm.ID = giaIn.ID;
                frm.TenBangGiaChon = giaIn.TenBangGiaChon;
                frm.TenInDigiChon = giaIn.TenToInDigiChon;
                //bài in
                frm.IdBaiIn = giaIn.IdBaiIn;

                frm.ThongTinGiay = giayIn.KhoToChay + "/" + giayIn.TenGiayIn + "/"
                    + string.Format("{0}gsm; Tờ chạy: {1} tờ",
                    giayIn.GiayChon.DinhLuong, giayIn.SoToChayTong);
                
                frm.MinimizeBox = false;
                frm.MaximizeBox = false;

                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                //Xử Bấm click //trường hợp edit
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    XuLyNutOKTrenFormGiaIn_Click(frm);//Cập nhật dữ liệu

                    LoadGiaInLenListView();//đã cập nhật luôn 
                }
            }
        }

        private void XuLyNutOKTrenFormGiaIn_Click(GiaInForm frm)
        {
            var giaIn = new GiaIn(frm.KieuIn, frm.IdHangKH,
                        frm.SoTrangA4, frm.IdBaiIn, frm.TenBangGiaChon, frm.TenInDigiChon,
                        frm.TienIn, frm.GiaTBTrangInfo);
            switch (frm.FormState)
            {
                case (int)Enumss.FormState.New:
                    //Add
                    ; //Id tự tạo
                                    
                    tinhGiaPres.ThemGiaIn(giaIn);

                    break;
                case (int)Enumss.FormState.Edit:
                    //Tạo 
                    giaIn.ID = IdGiaInChon; //Cần đổi vì new làm mới lại giá in ID                    
                    tinhGiaPres.SuaGiaIn(giaIn);
                    
                    break;
            }
        }
    
       #endregion

        #region Thành phẩm Cán phủ
        private void LoadThanhPhamLenListView()
        {
            //List view Giá In:            
            lvwThanhPham.Clear();
            lvwThanhPham.Columns.Add("Id");
            lvwThanhPham.Columns.Add("IdBaiIn");
            lvwThanhPham.Columns.Add("Tên Bài In");
            lvwThanhPham.Columns.Add("Thành phẩm");            
            lvwThanhPham.Columns.Add("Về Hạng KH");
            lvwThanhPham.Columns.Add("Mark Up");
            lvwThanhPham.Columns.Add("Số lượng");            
            lvwThanhPham.Columns.Add("Thành tiền");
            lvwThanhPham.View = System.Windows.Forms.View.Details;
            lvwThanhPham.HideSelection = false;
            lvwThanhPham.FullRowSelect = true;
            //==đền dữ liệu
            if (tinhGiaPres.ThanhPhamS().Count > 0)
            {                                
                foreach (KeyValuePair<int, List<string>> kvp in tinhGiaPres.TrinhBayThanhPhamS())
                {
                    var item = new ListViewItem();
                    item.Text = kvp.Key.ToString();

                    item.SubItems.AddRange(kvp.Value.ToArray());
                               
                    lvwThanhPham.Items.Add(item);
                }
                lvwThanhPham.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwThanhPham.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwThanhPham.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                //Load lại bài in để cập nhật tình trạng
                LoadBaiInLenListView();
            }
        }
        private void ThemThanhPham(int idBaiIn, int loaiThPh)
        {
            if (idBaiIn <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = tinhGiaPres.DocBaiInTheoId(idBaiIn);
            //Gắn thoải mái vì có thể in mấy lần ví dụ in mực trắng

            //Kiểm nếu đã có cấu hình mới được gắn
            if (!baiIn.CoCauHinh)
            {
                MessageBox.Show("Chưa có cấu hình Sản phẩm. Bạn cần gắn trước");
                return;
            }
            if (!baiIn.CoGiayIn)
            {
                MessageBox.Show("Chưa có giấy. Bạn phải cài giấy trước");
                return;
            }
            //Tiến hành gắn
            switch (loaiThPh)
            {
                case (int)Enumss.LoaiThanhPham.CanPhu:
                    var frm = new ThPhCanPhuForm();
                    frm.TinhTrangForm = (int)Enumss.FormState.New;
                    frm.LoaiThPh = loaiThPh;
                    frm.Text = "Cán Phủ [Mới]";
                    frm.MinimizeBox = false;
                    frm.MaximizeBox = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm.IdBaiIn = baiIn.ID;
                    frm.IdHangKhachHang = baiIn.IdHangKH;
                    //Cần thông tin bổ sung lấy từ bài in và giấy                   
                    frm.ThongTinBoSung = string.Format("Số tờ giấy in {0} khổ: {1}",
                        baiIn.GiayDeInIn.SoToChayTong, baiIn.GiayDeInIn.KhoToChay);
                    
                    frm.ShowDialog();
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanPhu(frm);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case (int)Enumss.LoaiThanhPham.CanGap:
                    var frm2 = new ThPhCanGapForm();
                    frm2.TinhTrangForm = (int)Enumss.FormState.New;
                    frm2.LoaiThPh = loaiThPh;
                    frm2.Text = "Cấn gấp [Mới]";
                    frm2.MinimizeBox = false;
                    frm2.MaximizeBox = false;
                    frm2.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm2.IdBaiIn = baiIn.ID;
                    frm2.IdHangKhachHang = baiIn.IdHangKH;
                    frm2.ShowDialog();
                    if (frm2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanGap(frm2);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case (int)Enumss.LoaiThanhPham.DongCuon:
                    var frm3 = new ThPhDongCuonForm();
                    frm3.TinhTrangForm = (int)Enumss.FormState.New;
                    frm3.LoaiThPh = loaiThPh;
                    frm3.Text = "Đóng cuốn [Mới]";
                    frm3.MinimizeBox = false;
                    frm3.MaximizeBox = false;
                    frm3.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm3.IdBaiIn = baiIn.ID;
                    frm3.IdHangKhachHang = baiIn.IdHangKH;
                    frm3.ShowDialog();
                    if (frm3.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuon(frm3);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case (int)Enumss.LoaiThanhPham.EpKim:
                    var frm4 = new ThPhEpKimForm();
                    frm4.TinhTrangForm = (int)Enumss.FormState.New;
                    frm4.LoaiThPh = loaiThPh;
                    frm4.Text = "Ép kim [Mới]";
                    frm4.MinimizeBox = false;
                    frm4.MaximizeBox = false;
                    frm4.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm4.IdBaiIn = baiIn.ID;
                    frm4.IdHangKhachHang = baiIn.IdHangKH;
                    frm4.ShowDialog();
                    if (frm4.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormEpKim(frm4);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
            }
        }
        private void SuaThanhPham()
        {
            if (this.IdThanhPhamChon <= 0)
                return;
            var mucThPh = tinhGiaPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
            var baiIn = tinhGiaPres.DocBaiInTheoId(mucThPh.IdBaiIn);
            var loaiThanhPham = mucThPh.LoaiThPh;
            switch (loaiThanhPham)
            {
                case (int)Enumss.LoaiThanhPham.CanPhu:
                    var frm1 = new ThPhCanPhuForm();
                    frm1.TinhTrangForm = (int)Enumss.FormState.Edit;
                    frm1.LoaiThPh = (int)Enumss.LoaiThanhPham.CanPhu;
                    frm1.Text = "Cán Phủ [Sửa]";
                    frm1.MinimizeBox = false;
                    frm1.MaximizeBox = false;
                    frm1.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form
                    frm1.IdBaiIn = baiIn.ID;
                    frm1.TenThPhChon = mucThPh.TenThPh;
                    frm1.IdHangKhachHang = mucThPh.IdHangKhachHang;

                    frm1.LoaiThPh = mucThPh.LoaiThPh;
                    frm1.SoLuong = mucThPh.SoLuong;
                    frm1.DonViTinh = mucThPh.DonViTinh;
                    //Cần thông tin bổ sung lấy từ bài in và giấy                   
                    frm1.ThongTinBoSung = string.Format("Số tờ giấy in {0} khổ: {1}",
                        baiIn.GiayDeInIn.SoToChayTong, baiIn.GiayDeInIn.KhoToChay);

                    frm1.ShowDialog();
                    if (frm1.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanPhu(frm1);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case (int)Enumss.LoaiThanhPham.CanGap:
                    var frm2 = new ThPhCanGapForm();
                    frm2.TinhTrangForm = (int)Enumss.FormState.Edit;
                    frm2.LoaiThPh = (int)Enumss.LoaiThanhPham.CanGap;
                    frm2.Text = "Cấn gấp [Sửa]";
                    frm2.MinimizeBox = false;
                    frm2.MaximizeBox = false;
                    frm2.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form
                    frm2.IdBaiIn = baiIn.ID;
                    frm2.TenThPhChon = mucThPh.TenThPh;
                    frm2.IdHangKhachHang = mucThPh.IdHangKhachHang;
                    frm2.LoaiThPh = mucThPh.LoaiThPh;
                    frm2.SoLuong = mucThPh.SoLuong;
                    frm2.DonViTinh = mucThPh.DonViTinh;

                    frm2.ShowDialog();
                    if (frm2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanGap(frm2);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case (int)Enumss.LoaiThanhPham.DongCuon:
                    var frm3 = new ThPhDongCuonForm();
                    frm3.TinhTrangForm = (int)Enumss.FormState.Edit;
                    frm3.LoaiThPh = (int)Enumss.LoaiThanhPham.DongCuon;
                    frm3.Text = "Đóng cuốn [Sửa]";
                    frm3.MinimizeBox = false;
                    frm3.MaximizeBox = false;
                    frm3.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form
                    frm3.IdBaiIn = baiIn.ID;
                    frm3.TenThPhChon = mucThPh.TenThPh;
                    frm3.IdHangKhachHang = mucThPh.IdHangKhachHang;
                    frm3.LoaiThPh = mucThPh.LoaiThPh;
                    frm3.SoLuong = mucThPh.SoLuong;
                    frm3.DonViTinh = mucThPh.DonViTinh;

                    frm3.ShowDialog();
                    if (frm3.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuon(frm3);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;

                case (int)Enumss.LoaiThanhPham.EpKim:
                    var frm4 = new ThPhEpKimForm();
                    frm4.TinhTrangForm = (int)Enumss.FormState.Edit;
                    frm4.LoaiThPh = (int)Enumss.LoaiThanhPham.EpKim;
                    frm4.Text = "Đóng cuốn [Sửa]";
                    frm4.MinimizeBox = false;
                    frm4.MaximizeBox = false;
                    frm4.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form
                    frm4.IdBaiIn = baiIn.ID;
                    frm4.TenThPhChon = mucThPh.TenThPh;
                    frm4.IdHangKhachHang = mucThPh.IdHangKhachHang;
                    frm4.LoaiThPh = mucThPh.LoaiThPh;
                    frm4.SoLuong = mucThPh.SoLuong;
                    frm4.DonViTinh = mucThPh.DonViTinh;

                    frm4.ShowDialog();
                    if (frm4.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormEpKim(frm4);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
            }
            

        }
        private void XoaMucThanhPham (int idMucThanhPham)
        {
            tinhGiaPres.XoaThanhPham(idMucThanhPham);
            //Cần cập nhật lại listview Bài in
        }
        private void XuLyNutOKClick_FormCanPhu(ThPhCanPhuForm frm)
        {

            var mucCanPhu = new MucThanhPham
            {
                IdBaiIn = frm.IdBaiIn,
                TenThPh = frm.TenThPhChon,
                IdHangKhachHang = frm.IdHangKhachHang,
                ThongTinHangKH = frm.ThongTinHangKH,
                ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp,
                LoaiThPh = frm.LoaiThPh,
                SoLuong = frm.SoLuong,
                DonViTinh = frm.DonViTinh,
                ThanhTien = frm.ThanhTien
            };
            switch (frm.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:
                    //Add
                    mucCanPhu = new MucThanhPham
                    {
                       
                    };                      
                    tinhGiaPres.ThemThanhPham(mucCanPhu);
                    break;
                case (int)Enumss.FormState.Edit:
                    //Tạo 
                    mucCanPhu = tinhGiaPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
                    mucCanPhu.IdBaiIn = frm.IdBaiIn;
                    mucCanPhu.TenThPh = frm.TenThPhChon;
                    mucCanPhu.IdHangKhachHang = frm.IdHangKhachHang;
                    mucCanPhu.ThongTinHangKH = frm.ThongTinHangKH;
                    mucCanPhu.ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp;
                    mucCanPhu.LoaiThPh = frm.LoaiThPh;
                    mucCanPhu.SoLuong = frm.SoLuong;
                    mucCanPhu.DonViTinh = frm.DonViTinh;
                    mucCanPhu.ThanhTien = frm.ThanhTien;
                    //Không cần cập nhật vì tự động khi Find
                    
                    break;
            }
        }
        #endregion
        #region Cấn gấp
        private void XuLyNutOKClick_FormCanGap(ThPhCanGapForm frm)
        {
            MucThanhPham mucThPh = null;
            switch (frm.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:
                    //Add
                    mucThPh = new MucThanhPham
                    {
                        IdBaiIn = frm.IdBaiIn,
                        TenThPh = frm.TenThPhChon,
                        IdHangKhachHang = frm.IdHangKhachHang,
                        ThongTinHangKH = frm.ThongTinHangKH,
                        ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp,
                        LoaiThPh = frm.LoaiThPh,
                        SoLuong = frm.SoLuong,
                        DonViTinh = frm.DonViTinh,
                        ThanhTien = frm.ThanhTien
                    };
                    tinhGiaPres.ThemThanhPham(mucThPh);
                    break;
                case (int)Enumss.FormState.Edit:
                    //Tạo 
                    mucThPh = tinhGiaPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
                    mucThPh.IdBaiIn = frm.IdBaiIn;
                    mucThPh.TenThPh = frm.TenThPhChon;
                    mucThPh.IdHangKhachHang = frm.IdHangKhachHang;
                    mucThPh.ThongTinHangKH = frm.ThongTinHangKH;
                    mucThPh.ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp;
                    mucThPh.LoaiThPh = frm.LoaiThPh;
                    mucThPh.SoLuong = frm.SoLuong;
                    mucThPh.DonViTinh = frm.DonViTinh;
                    mucThPh.ThanhTien = frm.ThanhTien;
                    //Không cần cập nhật vì tự động khi Find

                    break;
            }
        }
        #endregion
        #region Đóng cuốn
        private void XuLyNutOKClick_FormDongCuon(ThPhDongCuonForm frm)
        {
            MucThanhPham mucThPh = null;
            switch (frm.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:
                    //Add
                    mucThPh = new MucThanhPham
                    {
                        IdBaiIn = frm.IdBaiIn,
                        TenThPh = frm.TenThPhChon,
                        IdHangKhachHang = frm.IdHangKhachHang,
                        ThongTinHangKH = frm.ThongTinHangKH,
                        ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp,
                        LoaiThPh = frm.LoaiThPh,
                        SoLuong = frm.SoLuong,
                        DonViTinh = frm.DonViTinh,
                        ThanhTien = frm.ThanhTien
                    };
                    tinhGiaPres.ThemThanhPham(mucThPh);
                    break;
                case (int)Enumss.FormState.Edit:
                    //Tạo 
                    mucThPh = tinhGiaPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
                    mucThPh.IdBaiIn = frm.IdBaiIn;
                    mucThPh.TenThPh = frm.TenThPhChon;
                    mucThPh.IdHangKhachHang = frm.IdHangKhachHang;
                    mucThPh.ThongTinHangKH = frm.ThongTinHangKH;
                    mucThPh.ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp;
                    mucThPh.LoaiThPh = frm.LoaiThPh;
                    mucThPh.SoLuong = frm.SoLuong;
                    mucThPh.DonViTinh = frm.DonViTinh;
                    mucThPh.ThanhTien = frm.ThanhTien;
                    //Không cần cập nhật vì tự động khi Find

                    break;
            }
        }
        #endregion
        #region Ép kim
        private void XuLyNutOKClick_FormEpKim(ThPhEpKimForm frm)
        {
            MucThanhPham mucThPh = null;
            switch (frm.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:
                    //Add
                    mucThPh = new MucThanhPham
                    {
                        IdBaiIn = frm.IdBaiIn,
                        TenThPh = frm.TenThPhChon,
                        IdHangKhachHang = frm.IdHangKhachHang,
                        ThongTinHangKH = frm.ThongTinHangKH,
                        ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp,
                        LoaiThPh = frm.LoaiThPh,
                        SoLuong = frm.SoLuong,
                        DonViTinh = frm.DonViTinh,
                        ThanhTien = frm.ThanhTien
                    };
                    tinhGiaPres.ThemThanhPham(mucThPh);
                    break;
                case (int)Enumss.FormState.Edit:
                    //Tạo 
                    mucThPh = tinhGiaPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
                    mucThPh.IdBaiIn = frm.IdBaiIn;
                    mucThPh.TenThPh = frm.TenThPhChon;
                    mucThPh.IdHangKhachHang = frm.IdHangKhachHang;
                    mucThPh.ThongTinHangKH = frm.ThongTinHangKH;
                    mucThPh.ThongTinTyLeMarkUp = frm.ThongTinTyLeMarkUp;
                    mucThPh.LoaiThPh = frm.LoaiThPh;
                    mucThPh.SoLuong = frm.SoLuong;
                    mucThPh.DonViTinh = frm.DonViTinh;
                    mucThPh.ThanhTien = frm.ThanhTien;
                    //Không cần cập nhật vì tự động khi Find

                    break;
            }
        }
        #endregion
        private void btnThemBaiIn_Click(object sender, EventArgs e)
       {
           ThemBaiIn();
       }

       private void btnSuaBaiIn_Click(object sender, EventArgs e)
       {
           SuaBaiIn();
       }

       private void btnXoaBaiIn_Click(object sender, EventArgs e)
       {
           XoaBaiIn();
       }

       private void cmnuGanCauHinhSP_Click(object sender, EventArgs e)
       {
           GanCauHinhVoBaiIn();
       }

       private void cmnuChuanBiGiay_Click(object sender, EventArgs e)
       {
          
           GanGiayVoBaiIn();
           
       }

       private void btnSuaGiayIn_Click(object sender, EventArgs e)
       {
           SuaGiayIn();
       }

      

       private void cmnuGanGiaIn_Click(object sender, EventArgs e)
       {
          ThemGiaInNhanh();
       }

       private void btnSuaGiaInNhanh_Click(object sender, EventArgs e)
       {
           SuaGiaIn();
       }

       private void btnXoaGiaInNhanh_Click(object sender, EventArgs e)
       {
           if (this.IdBaiInChon > 0)
           {
               tinhGiaPres.XoaGiaIn(this.IdGiaInChon);
               LoadGiaInLenListView();//Load lại
           }
          
       }

       private void cmnuThanhPham_Click(object sender, EventArgs e)
       {
           ThemThanhPham(this.IdBaiInChon, (int)Enumss.LoaiThanhPham.CanPhu);
       }

       private void cmnuThPh_CanGap_Click(object sender, EventArgs e)
       {
           ThemThanhPham(this.IdBaiInChon, (int)Enumss.LoaiThanhPham.CanGap);
       }

       private void cmnuThPh_DongCuon_Click(object sender, EventArgs e)
       {
           ThemThanhPham(this.IdBaiInChon, (int)Enumss.LoaiThanhPham.DongCuon);
       }

       private void btnSuaThanhPham_Click(object sender, EventArgs e)
       {
           SuaThanhPham();
       }

       private void lvwBaiIn_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadChiTietBaiInTheoIdBaiIn();
       }

       private void btnSuaGiayIn_Click_1(object sender, EventArgs e)
       {
           SuaGiayIn();
           
       }

       private void btnXoaGiayDeIn_Click(object sender, EventArgs e)
       {
           if (this.IdBaiInChon > 0)
           {
               tinhGiaPres.XoaGiayDeIn();
               this.TomTatGiayDeIn = tinhGiaPres.TomTatGiayDeIn();
           }
          
       }

       private void btnSuaGiaInNhanh_Click_1(object sender, EventArgs e)
       {
           SuaGiaIn();
       }

       private void btnXoaGiaInNhanh_Click_1(object sender, EventArgs e)
       {
           tinhGiaPres.XoaGiaIn(this.IdBaiInChon);
       }

       private void btnXoaHetBaiInNhanh_Click(object sender, EventArgs e)
       {
           tinhGiaPres.XoaHetGiaIn();
       }

       private void btnSuaThanhPham_Click_1(object sender, EventArgs e)
       {
           SuaThanhPham();
       }

       private void btnXoaThanhPham_Click(object sender, EventArgs e)
       {
           tinhGiaPres.XoaThanhPham(this.IdThanhPhamChon);
       }

       private void btnXoaHetThanhPham_Click(object sender, EventArgs e)
       {
           tinhGiaPres.XoaHetThanhPham();
       }

       private bool KiemTraHopLe(ref string errorMessage)
       {
           var result = true;
           List<string> loiS = new List<string>();

           
           if (string.IsNullOrEmpty(txtSoTinhGia.Text))
               loiS.Add("Số tính giá trống");

           if (string.IsNullOrEmpty(txtTenKhachHang.Text))
               loiS.Add("Tên KH trống");
           if (string.IsNullOrEmpty(txtLienHe.Text))
               loiS.Add("Liên hệ bị rỗng");
           if (string.IsNullOrEmpty(txtYeuCau.Text))
               loiS.Add("Yêu cầu bị rỗng");
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
       private void btnLuu_Click(object sender, EventArgs e)
       {
           string str = "";
           if (KiemTraHopLe(ref str))
           {
               MessageBox.Show(tinhGiaPres.LuuTinhGia());
               this.Close();
           }
           else
           {
               var dialogeR = MessageBox.Show(str, "Nội dung thiếu, bạn muốn làm tiêp?",
                        MessageBoxButtons.YesNo);
               if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                   this.Focus();
               else
               {
                   this.FormClosing -= Forms_FormClosing;
                   this.Close();
               }
           }
       }

       private void btnCopy_Click(object sender, EventArgs e)
       {
           var copyText ="";
           foreach (string str in tinhGiaPres.TomTatBaiIn_ChaoKH())
           {
               copyText += str + (char)Keys.Enter + '\n';
           }
           Clipboard.SetText(copyText);
       }

       private void btnClose_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void btnXoaSachBaiIn_Click(object sender, EventArgs e)
       {
           tinhGiaPres.XoaTatCaBaiIn();
       }

       private void btnNoiDungTinhGia_Click(object sender, EventArgs e)
       {
           Clipboard.SetText( tinhGiaPres.TrinhBayNoiDungBaiIn());
       }

       private void tabCtrl01_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

       private void cmnuThPh_EpKim_Click(object sender, EventArgs e)
       {
           ThemThanhPham(this.IdBaiInChon, (int)Enumss.LoaiThanhPham.EpKim);
       }
     
    }
}
