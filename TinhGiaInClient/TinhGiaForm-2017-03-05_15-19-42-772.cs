﻿using System;
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
    public partial class TinhGiaForm : Form, IViewTinhGia
    {
        TinhGiaPresenter tinhGiaPres = null;
        public TinhGiaForm()
        {
            InitializeComponent();
            _baiInS = new List<BaiIn>();//Chứa bài in
            _cauHinhSPS = new List<CauHinhSanPham>();
            _giayDeInS = new List<GiayDeIn>();//Thùng chứa
            _giaInS = new List<GiaIn>();//Thùng chứa

            tinhGiaPres = new TinhGiaPresenter(this);
            
        }
        #region Thi công  IView
        
        List<BaiIn> _baiInS = null;
        public List<BaiIn> BaiInS
       {
           get
           {
               return _baiInS;
           }
           set
           {
               _baiInS = value;
           }
       }
        int _idCauHinhSPChon = 0;
        public int IdCauHinhSPChon
        {
            get
            {
                if (lvwCauHinhSP.SelectedItems.Count > 0)
                    int.TryParse(lvwCauHinhSP.SelectedItems[0].Text, out _idCauHinhSPChon);
                return _idCauHinhSPChon;
            }
            set { _idCauHinhSPChon = value; }
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
        List<CauHinhSanPham> _cauHinhSPS;
        public List<CauHinhSanPham> CauHinhSanPhamS
        {
            get
            {
                return _cauHinhSPS;
            }
            set
            {
                _cauHinhSPS = value;
            }
        }
        int _idGiayInChon = 0;
        public int IdGiayInChon
        {
            get
            {
                if (lvwGiay.SelectedItems.Count > 0)
                    int.TryParse(lvwGiay.SelectedItems[0].Text, out _idGiayInChon);
                return _idGiayInChon;
            }
            set { _idGiayInChon = value; }
        }
        List<GiayDeIn> _giayDeInS;
        public List<GiayDeIn> GiayDeInS 
        { 
            get {return _giayDeInS;}
            set {_giayDeInS = value; }
        }
        List<GiaIn> _giaInS;
        public List<GiaIn> GiaInS
        {
            get { return _giaInS; }
            set { _giaInS = value; }
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
            trvMucLuc.Nodes.Add(rootItem);
            trvMucLuc.ExpandAll();
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
            if (trvMucLuc.SelectedNode == null)
                return;

            var selNode = trvMucLuc.SelectedNode;
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
            //Listview Sản phẩm

            lvwBaiIn.Clear();
            lvwBaiIn.Columns.Add("Id");
            lvwBaiIn.Columns.Add("Tiêu đề");
            lvwBaiIn.Columns.Add("Diễn giải");
            lvwBaiIn.Columns.Add("Số lượng");
            lvwBaiIn.Columns.Add("Đơn vị");
            lvwBaiIn.Columns.Add("Cấu hình SP");
            lvwBaiIn.Columns.Add("Giấy In");
            lvwBaiIn.Columns.Add("SL Giá In");
            lvwBaiIn.View = System.Windows.Forms.View.Details;
            lvwBaiIn.HideSelection = false;
            lvwBaiIn.FullRowSelect = true;
            //===hết
            //Listview  cấu hìnhSản phẩm
            lvwCauHinhSP.Clear();
            lvwCauHinhSP.Columns.Add("IdCH");
            lvwCauHinhSP.Columns.Add("Sản phẩm");
            lvwCauHinhSP.Columns.Add("Cắt Rộng");
            lvwCauHinhSP.Columns.Add("Cắt Cao");
            lvwCauHinhSP.Columns.Add("Tràn lề");
            lvwCauHinhSP.Columns.Add("Lề");
            lvwCauHinhSP.Columns.Add("Khổ gồm lề");
            
            lvwCauHinhSP.View = System.Windows.Forms.View.Details;
            lvwCauHinhSP.HideSelection = false;
            lvwCauHinhSP.FullRowSelect = true;
            //===hết
            //List view Giấy:

            lvwGiay.Clear();
            lvwGiay.Columns.Add("IdGiayIn");            
            lvwGiay.Columns.Add("Tên Giấy");
            lvwGiay.Columns.Add("Định lượng");           
            lvwGiay.Columns.Add("Khổ chạy");
            lvwGiay.Columns.Add("Số tờ chạy");
            lvwGiay.Columns.Add("Tờ lớn");
            lvwGiay.Columns.Add("Số tờ");
            lvwGiay.Columns.Add("Giá bán");
            lvwGiay.Columns.Add("Thành tiền");
                        
            lvwGiay.View = System.Windows.Forms.View.Details;
            lvwGiay.HideSelection = false;
            lvwGiay.FullRowSelect = true;
            //==
          

        }
        #region 1Về Bài In
        private void LoadBaiInLenListView()
        {
            //Xóa;
            lvwBaiIn.Items.Clear();

            if (this.BaiInS.Count() > 0)
            {
                ListViewItem item;
                foreach (BaiIn bIn in this.BaiInS)
                {
                    item = new ListViewItem();
                    item.Text = bIn.ID.ToString();

                    item.SubItems.Add(bIn.TieuDe);
                    item.SubItems.Add(bIn.DienGiai);
                    
                    item.SubItems.Add(string.Format("{0}", bIn.SoLuong));
                    item.SubItems.Add(bIn.DonVi);
                    item.SubItems.Add(bIn.CoCauHinh.ToString());
                    item.SubItems.Add(bIn.CoGiayIn.ToString());
                    //Số lượng giá in
                    item.SubItems.Add(string.Format("{0}", bIn.SoLuongGiaInKemTheo(this.GiaInS)));

                    lvwBaiIn.Items.Add(item);
                }
                lvwBaiIn.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwBaiIn.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwBaiIn.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwBaiIn.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwBaiIn.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwBaiIn.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwBaiIn.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwBaiIn.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void ThemBaiIn()
        {

            var frm = new BaiInForm((int)Ennums.FormState.New);
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
                var baiIn = this.BaiInS.Find(x => x.ID == this.IdBaiInChon);
                var frm = new BaiInForm((int)Ennums.FormState.Edit);
                //Điền giữ liệu: 
                frm.ID = baiIn.ID;
                frm.TieuDe = baiIn.TieuDe;
                frm.DienGiai = baiIn.DienGiai;
                frm.SoLuong = baiIn.SoLuong;
                frm.DonVi = baiIn.DonVi;

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
                tinhGiaPres.XoaBaiIn(this.IdBaiInChon);
                LoadBaiInLenListView();
            }
        }
        private void XuLyNutOKTrenFormBaiIn_Click(BaiInForm frm)
        {
            switch (frm.FormState)
            {
                case (int)Ennums.FormState.New:
                    //Add
                    var baiIn = new BaiIn(frm.TieuDe);
                    baiIn.DonVi = frm.DonVi;
                    baiIn.DienGiai = frm.DienGiai;
                    baiIn.TieuDe = frm.TieuDe;
                    baiIn.SoLuong = frm.SoLuong;
                    tinhGiaPres.ThemBaiIn(baiIn);
                    break;
                case (int)Ennums.FormState.Edit:
                    //Tạo SP mới
                    var tmpBaiIn = new BaiIn(frm.TieuDe);
                    tmpBaiIn.DonVi = frm.DonVi;
                    tmpBaiIn.DienGiai = frm.DienGiai;
                    tmpBaiIn.TieuDe = frm.TieuDe;
                    tmpBaiIn.SoLuong = frm.SoLuong;                    
                    //Đổi ID vì bị thêm mới là có id mới
                    tmpBaiIn.ID = frm.ID;
                    //Cập nhật lại
                    tinhGiaPres.CapNhatBaiIn(tmpBaiIn);
                    break;
            }
        }
        #endregion
        #region Cấu hình SP
        private void LoadCauHinhSPLenListView()
        {
            //Xóa;
            lvwCauHinhSP.Items.Clear();           

            if (this.CauHinhSanPhamS.Count() > 0)
            {
                //Lấy 2 item từ bài in
                BaiIn baiIn = null;
                ListViewItem item;
                foreach (CauHinhSanPham chSP in CauHinhSanPhamS)
                {
                    item = new ListViewItem();
                    item.Text = chSP.IDCauHinh.ToString();
                    //lấy
                    //MessageBox.Show(chSP.IdBaiIn.ToString());
                    baiIn = this.BaiInS.Find(x => x.ID == chSP.IdBaiIn);
                    item.SubItems.Add(baiIn.TieuDe);
                    item.SubItems.Add(chSP.KhoSP.KhoCatRong.ToString());
                    item.SubItems.Add(chSP.KhoSP.KhoCatCao.ToString());
                    item.SubItems.Add(string.Format("Tr{0};D{1};Trg{2};Ng{3}", chSP.TranLeTren,
                        chSP.TranLeDuoi, chSP.TranLeTrong, chSP.TranLeNgoai));
                    item.SubItems.Add(string.Format("Tr{0};D{1};Trg{2};Ng{3}", chSP.LeTren,
                        chSP.LeDuoi, chSP.LeTrong, chSP.LeNgoai));
                    item.SubItems.Add(string.Format("{0}x{1}cm", chSP.KhoRongGomLe, chSP.KhoCaoGomLe));
                    
                    lvwCauHinhSP.Items.Add(item);
                }
                lvwCauHinhSP.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwCauHinhSP.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwCauHinhSP.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwCauHinhSP.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwCauHinhSP.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwCauHinhSP.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                //Load lại bài in để cập nhật tình trạng
                LoadBaiInLenListView();          
            }
            
        }
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            var frm = new TrienKhaiSanPhamForm((int)Ennums.FormState.New);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormTrienKhaiSP_Click(frm);
                //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                LoadCauHinhSPLenListView();
            }

        }
        private void btnXoaCauHinhSP_Click(object sender, EventArgs e)
        {
           
            if (this.IdCauHinhSPChon >0)
            {
                tinhGiaPres.XoaCauHinhSanPham(this.IdCauHinhSPChon);
                //Xóa               
                LoadCauHinhSPLenListView();
            }
        }

        private void btnSuaCauHinhSP_Click(object sender, EventArgs e)
        {
            
            if (this.IdCauHinhSPChon >0)
            {
                var chSP = this.CauHinhSanPhamS.Find(x => x.IDCauHinh == this.IdCauHinhSPChon);
                var frm = new TrienKhaiSanPhamForm((int)Ennums.FormState.Edit, chSP);
                //Tiếp tục gắn thêm dữ liệu
                var baiIn = this.BaiInS.Find(x => x.ID == chSP.IDCauHinh);
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
                    //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                    LoadCauHinhSPLenListView();
                }
            }
        }
        private void GanCauHinhVoBaiIn(int idBaiIn = 0)
        {
            if (idBaiIn <=0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = this.BaiInS.Find(x => x.ID == idBaiIn);
            if (baiIn.CoCauHinh ) //Đã có cấu hình
                return;
            //Gắn
            var frm = new TrienKhaiSanPhamForm((int)Ennums.FormState.New);
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
                //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                LoadCauHinhSPLenListView();
            }
            
        }
       private void XuLyNutOKTrenFormTrienKhaiSP_Click(TrienKhaiSanPhamForm frm)
       {
           switch (frm.formState)
           {
               case (int)Ennums.FormState.New:
                   //Add
                   tinhGiaPres.ThemCauHinhSanPham(new CauHinhSanPham(new KhoSanPham
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
                                                      frm.IdBaiIn));
                   break;
               case (int)Ennums.FormState.Edit:
                   //Tạo SP mới
                   var tmpCauHinhSP = new CauHinhSanPham(new KhoSanPham
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
                   //Đổi ID vì thêm mới là có id mới
                   tmpCauHinhSP.IDCauHinh = frm.IdCauHinhSP;
                   //Cập nhật lại
                   tinhGiaPres.CapNhatCauHinhSanPham(tmpCauHinhSP);
                   break;
           }
       }
        #endregion cấu hình SP
     
       #region Về Giấy
       private void LoadGiayLenListView()
       {
           //Xóa;
           lvwGiay.Items.Clear();

           if (this.GiayDeInS.Count() > 0)
           {
               //Lấy 2 item từ bài in
               
               ListViewItem item;
               foreach (GiayDeIn giayDeIn in this.GiayDeInS)
               {
                   item = new ListViewItem();
                   item.Text = giayDeIn.ID.ToString();
                   //lấy
                   //MessageBox.Show(chSP.IdBaiIn.ToString());
                   
                   item.SubItems.Add(giayDeIn.TenGiayIn);
                   item.SubItems.Add(string.Format("{0} g/m2", giayDeIn.GiayChon.DinhLuong));
                   item.SubItems.Add(giayDeIn.KhoToChay);
                   item.SubItems.Add(string.Format("{0} tờ", giayDeIn.SoToChayTong));
                   item.SubItems.Add(giayDeIn.GiayChon.KhoGiay);
                   item.SubItems.Add(string.Format("{0} tờ", giayDeIn.SoLuongToLonCan));
                   item.SubItems.Add(string.Format("{0}đ/tờ", giayDeIn.GiaBan));
                   item.SubItems.Add(string.Format("{0}đ", giayDeIn.ThanhTien));

                   lvwGiay.Items.Add(item);
               }
               lvwGiay.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiay.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiay.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               lvwGiay.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               lvwGiay.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiay.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiay.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiay.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiay.Columns[8].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               //Load lại bài in để cập nhật tình trạng
               LoadBaiInLenListView();
           }

       }
       private void GanGiayVoBaiIn(int idBaiIn = 0)
       {
           if (idBaiIn <= 0)
               return;
           //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
           var baiIn = this.BaiInS.Find(x => x.ID == idBaiIn);
           if (baiIn.CoGiayIn) //Đã có thì không gắn
               return;
           //Kiểm nếu đã có cấu hình mới được gắn
           if (!baiIn.CoCauHinh)
           {
               MessageBox.Show("Chưa có cấu hình Sản phẩm. Bạn cần gắn trước");
               return;
           }
           //Tiến hành gắn
           var frm = new ChuanBiGiayForm((int)Ennums.FormState.New);
           frm.MinimizeBox = false;
           frm.MaximizeBox = false;
           frm.StartPosition = FormStartPosition.CenterParent;
           //Data gởi qua ỏm
           frm.IdBaiIn = baiIn.ID;
           frm.DienGiayBaiIn = baiIn.DienGiai;
           frm.ThongTinCauHinhSP = this.CauHinhSanPhamS.Find(x => x.IdBaiIn == baiIn.ID).ThongTinCauHinh
               + string.Format("; Số lượng: {0} {1}", baiIn.SoLuong, baiIn.DonVi) ;
           
           frm.ShowDialog();
           if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
           {
               XuLyNutOKTrenFormChuanBiGiay_Click(frm);
               //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
               LoadGiayLenListView();
               //Cập nhật lại danh sách bài in đã nằm trong LoadGiay
               
           }
           
       }
        private void SuaGiayIn()
       {
           if (this.IdGiayInChon > 0)
           {
               var giayIn = this.GiayDeInS.Find(x => x.ID == this.IdGiayInChon);
               var frm = new ChuanBiGiayForm((int)Ennums.FormState.Edit);
               //Điền giữ liệu: 
               var baiIn = this.BaiInS.Find(x => x.ID == giayIn.IdBaiIn);
               frm.ID = giayIn.ID;
               frm.DienGiayBaiIn = baiIn.DienGiai; //bài in
               var cauHinhSP = this.CauHinhSanPhamS.Find(x => x.IdBaiIn == baiIn.ID);
               frm.ThongTinCauHinhSP = cauHinhSP.ThongTinCauHinh;
               frm.TenGiayIn = giayIn.TenGiayIn;
               frm.KhoToChay = giayIn.KhoToChay;
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
                   
                   LoadGiayLenListView();//đã cập nhật luôn 
               }
           }
       }
       private void XuLyNutOKTrenFormChuanBiGiay_Click(ChuanBiGiayForm frm)
       {
           switch (frm.FormState)
           {
               case (int)Ennums.FormState.New:
                   //Add
                   var gDeIn = new GiayDeIn(frm.GiayChon, 0);
                   gDeIn.TenGiayIn = frm.TenGiayIn;
                   gDeIn.IdBaiIn = frm.IdBaiIn;
                   gDeIn.KhoToChay = frm.KhoToChay;
                   gDeIn.SoLuongToChayLyThuyet = frm.SoLuongToChayLyThuyet;
                   gDeIn.SoLuongToChayBuHao = frm.SoLuongToChayBuHao;
                   gDeIn.SoLuongToLonCan = frm.SoToGiayLon;
                   tinhGiaPres.ThemGiayIn(gDeIn);
                   
                   
                   break;
               case (int)Ennums.FormState.Edit:
                   //Tạo 
                   var gDeInE = new GiayDeIn(frm.GiayChon, 0);
                     
                   gDeInE.TenGiayIn = frm.TenGiayIn;
                   gDeInE.IdBaiIn = frm.IdBaiIn;
                   gDeInE.KhoToChay = frm.KhoToChay;
                   gDeInE.SoLuongToChayLyThuyet = frm.SoLuongToChayLyThuyet;
                   gDeInE.SoLuongToChayBuHao = frm.SoLuongToChayBuHao;
                   gDeInE.SoLuongToLonCan = frm.SoToGiayLon;                   
                   //Đổi ID vì thêm mới là có id mới
                   gDeInE.ID = frm.ID;
                   //Cập nhật lại
                   tinhGiaPres.CapNhatGiayDeIn(gDeInE);
                   break;
           }
       }
       private void btnThemGiay_Click(object sender, EventArgs e)
       {
           ChuanBiGiayForm frm = new ChuanBiGiayForm((int)Ennums.FormState.New);
           frm.MaximizeBox = false;
           frm.MinimizeBox = false;
           frm.Text = "Chuẩn bị Giấy";
           frm.ShowDialog();
           
       }
       private void mnuGanGiayChoSP_Click(object sender, EventArgs e)
       {
           //Kiểm cấu hình giấy chọn đã được gắn chưa
           if (this.IdCauHinhSPChon > 0)
           {
               ChuanBiGiayForm frm = new ChuanBiGiayForm((int)Ennums.FormState.New);
               frm.MaximizeBox = false;
               frm.MinimizeBox = false;
               frm.Text = "Chuẩn bị Giấy";
               frm.ShowDialog();
           }
       }
        #endregion
       #region Về Giá In
       private void LoadGiaInLenListView()
       {
           //List view Giá In:
           lvwGiaInNhanh.Clear();
           lvwGiaInNhanh.Columns.Add("Id");
           lvwGiaInNhanh.Columns.Add("IdBaiIn");
           lvwGiaInNhanh.Columns.Add("Bảng giá");
           lvwGiaInNhanh.Columns.Add("Số lượng");
           lvwGiaInNhanh.Columns.Add("Đơn giá");
           lvwGiaInNhanh.Columns.Add("Thành tiền");
           lvwGiaInNhanh.View = System.Windows.Forms.View.Details;
           lvwGiaInNhanh.HideSelection = false;
           lvwGiaInNhanh.FullRowSelect = true;
           //==đền dữ liệu
           if (this.GiayDeInS.Count() > 0)
           {
               //Lấy 2 item từ bài in

               ListViewItem item;
               foreach (GiaIn giaIn in this.GiaInS)
               {
                   item = new ListViewItem();
                   item.Text = giaIn.ID.ToString();
                   //lấy
                   //MessageBox.Show(chSP.IdBaiIn.ToString());

                   item.SubItems.Add(giaIn.IdBaiIn.ToString());
                   item.SubItems.Add(giaIn.TenBangGiaChon);
                   item.SubItems.Add(string.Format("{0} A4", giaIn.SoTrangA4));
                   item.SubItems.Add(string.Format("{0}đ/A4", giaIn.TienIn / giaIn.SoTrangA4));
                   item.SubItems.Add(string.Format("{0}đ", giaIn.TienIn));
                   lvwGiaInNhanh.Items.Add(item);
               }
               lvwGiaInNhanh.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiaInNhanh.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiaInNhanh.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               lvwGiaInNhanh.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               lvwGiaInNhanh.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               lvwGiaInNhanh.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               //Load lại bài in để cập nhật tình trạng
               LoadBaiInLenListView();
           }
       }
    
        private void GanGiaInNhanhVoBaiIn(int idBaiIn)
       {
      
           if (idBaiIn <= 0)
               return;
           //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
           var baiIn = this.BaiInS.Find(x => x.ID == idBaiIn);
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
           var frm = new GiaInForm();
           frm.FormState = (int)Ennums.FormState.New;
           frm.MinimizeBox = false;
           frm.MaximizeBox = false;
           frm.StartPosition = FormStartPosition.CenterParent;
           //Data gởi qua ỏm
           frm.IdBaiIn = baiIn.ID;
           //Gắn giấy in
           var giayIn = this.GiayDeInS.Find(x => x.IdBaiIn == baiIn.ID);
           frm.ThongTinGiay = giayIn.KhoToChay + "/" + giayIn.TenGiayIn + "/"
               + string.Format("{0}gsm", giayIn.GiayChon.DinhLuong);
          
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
                var giaIn = this.GiaInS.Find(x => x.ID == this.IdGiaInChon);
                var frm = new GiaInForm();
                frm.FormState = (int)Ennums.FormState.Edit;
                //Điền giữ liệu: 

                frm.ID = giaIn.ID;
                frm.IdBangGiaChon = giaIn.IdBangGiaChon;
                frm.LoaiBangGia = giaIn.LoaiBangGia;                
                //bài in
                //Gắn giấy in
                var giayIn = this.GiayDeInS.Find(x => x.IdBaiIn == giaIn.IdBaiIn);
                frm.ThongTinGiay = giayIn.KhoToChay + "/" + giayIn.TenGiayIn + "/"
                    + string.Format("{0}gsm", giayIn.GiayChon.DinhLuong);
                frm.SoTrangA4 = giaIn.SoTrangA4;

                frm.MinimizeBox = false;
                frm.MaximizeBox = false;

                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                //Xử Bấm click //trường hợp edit
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    XuLyNutOKTrenFormGiaIn_Click(frm);//Cập nhật dữ liệu

                    LoadGiayLenListView();//đã cập nhật luôn 
                }
            }
        }

        private void XuLyNutOKTrenFormGiaIn_Click(GiaInForm frm)
        {
            switch (frm.FormState)
            {
                case (int)Ennums.FormState.New:
                    //Add
                    var giaIn = new GiaIn(frm.IdBangGiaChon,frm.KieuIn,frm.LoaiBangGia,
                        frm.SoTrangA4, frm.IdBaiIn, frm.TenBangGiaChon, frm.TienIn ); //Id tự tạo
                                       
                    tinhGiaPres.ThemGiaIn(giaIn);


                    break;
                case (int)Ennums.FormState.Edit:
                    //Tạo 
                    var giaInE = new GiaIn();
                    giaInE.ID = frm.ID;//Tránh ID tự tạo
                    giaInE.IdBangGiaChon = frm.IdBangGiaChon;
                    giaInE.KieuIn = frm.KieuIn;
                    giaInE.LoaiBangGia = frm.LoaiBangGia;
                    giaInE.SoTrangA4 = frm.SoTrangA4;
                    giaInE.TienIn = frm.TienIn;
                    giaInE.IdBaiIn = frm.IdBaiIn;
                    tinhGiaPres.CapNhatGiaIn(giaInE);
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
           GanCauHinhVoBaiIn(this.IdBaiInChon);
       }

       private void cmnuChuanBiGiay_Click(object sender, EventArgs e)
       {
          
           GanGiayVoBaiIn(this.IdBaiInChon);
       }

       private void btnSuaGiayIn_Click(object sender, EventArgs e)
       {
           SuaGiayIn();
       }

      

       private void cmnuGanGiaIn_Click(object sender, EventArgs e)
       {
          GanGiaInNhanhVoBaiIn(this.IdBaiInChon);
       }

       private void btnSuaGiaInNhanh_Click(object sender, EventArgs e)
       {
           SuaGiaIn();
       }

       private void btnXoaGiaInNhanh_Click(object sender, EventArgs e)
       {
           tinhGiaPres.XoaGiaIn(this.IdGiaInChon);
           LoadGiaInLenListView();//Load lại
          
       }





     
    }
}
