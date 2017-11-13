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
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.UI;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient
{
    public partial class BaiInToForm : Form, IViewBaiIn
    {
       
       
        public BaiInToForm(ThongTinBanDauChoBaiIn thongTinBanDau,  BaiIn baiIn)
        {
            InitializeComponent();
            //Chú ý theo thứ tự
            baiInPres = new BaiInPresenter(this, baiIn);
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.IdHangKhachHang = thongTinBanDau.IdHangKhachHang;
            this.TenHangKhachHang = thongTinBanDau.TenHangKhachHang;            
            this.Text = thongTinBanDau.TieuDeForm;
            
            this.DanDoThem = thongTinBanDau.DanDoThem;
            this.SanPhamRong = thongTinBanDau.SanPhamRong;
            this.SanPhamCao = thongTinBanDau.SanPhamCao;

            CapNhatTenHangKH();
            // 
            TaoCayDanhMucTab();
            
            //Trình bày theo tình trạng form
            switch (this.TinhTrangForm)
            {
                case FormStateS.Edit:
                case FormStateS.New:
                    //Khóa
                    spcChiTietBaiIn.Enabled = true;                    
                    break;
                
            }
            baiInPres.TrinhBayBaiIn();//Cũng tùy tình huống
            //làm khéo về hạng KH
            
            //event
            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtKhoCatRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtKhoCatCao.KeyPress += new KeyPressEventHandler(InputValidator);

            txtCauHinhSP.Leave += new EventHandler(TextBoxes_Leave);
            txtGiayDeIn.Leave += new EventHandler(TextBoxes_Leave);
            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);
            txtDonVi.Leave += new EventHandler(TextBoxes_Leave);
            txtKhoCatRong.Leave += new EventHandler(TextBoxes_Leave);
            txtKhoCatCao.Leave += new EventHandler(TextBoxes_Leave);

            txtKhoCatRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtKhoCatCao.KeyPress += new KeyPressEventHandler(InputValidator);

            lvwGiaInNhanh.SelectedIndexChanged += new EventHandler(ListViews_SelectedIndexChanged);
            lvwThanhPham.SelectedIndexChanged += new EventHandler(ListViews_SelectedIndexChanged);
            lvwTruocIn.SelectedIndexChanged += new EventHandler(ListViews_SelectedIndexChanged);
          
            //Khóa số txtSoluong khi sửa
            /*if (formState == (int)FormState.Edit)
                txtSoLuong.Enabled = false;
            else
                txtSoLuong.Enabled = true; 
             */
        }
        BaiInPresenter baiInPres;
        #region Implement IView

        public int ID
        {
            get { return int.Parse(lblIDBaiIn.Text); }
            set { lblIDBaiIn.Text = value.ToString(); }
        }
        public string TieuDe
        {
            get { return txtTieuDe.Text; }
            set { txtTieuDe.Text = value; }
        }
        public string DienGiai
        {
            get { return txtDienGiai.Text; }
            set { txtDienGiai.Text = value; }
        }
        public string DanDoThem
        {
            get { return txtDanDoThem.Text; }
            set { txtDanDoThem.Text = value; }
        }
        public float SanPhamRong
        {
            get { return float.Parse(txtKhoCatRong.Text); }
            set { txtKhoCatRong.Text = value.ToString(); }
        }
        public float SanPhamCao 
        {
            get { return float.Parse(txtKhoCatCao.Text); }
            set { txtKhoCatCao.Text = value.ToString(); }
        }
        public int SoLuong
        {
            get { return int.Parse(txtSoLuong.Text); }
            set { txtSoLuong.Text = value.ToString(); }
        }
        public string DonViTinh
        {
            get { return txtDonVi.Text; }
            set { txtDonVi.Text = value.ToString(); }
        }

        public string TenHangKhachHang
        {
            get
            {
                return lblHangKhachHang.Text;
            }
            set { lblHangKhachHang.Text = value; }
        }

        public int IdHangKhachHang
        {
            get;
            set;
        }

        public string TomTatCauHinhSP
        {
            get { return txtCauHinhSP.Text; }
            set { txtCauHinhSP.Text = value; }
        }
        public List<string> TomTatGiayDeIn
        {
            get { return txtGiayDeIn.Lines.ToList(); }
            set { txtGiayDeIn.Lines = value.ToArray(); }
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
        public List<string> TomTatBaiIn_ChaoKH
        {
            get { return baiInPres.TomTatNoiDungBaiIn_ChaoKH(); }
            set { txtTomTatBaiIn.Lines = value.ToArray(); }
        }
        public BaiIn DocBaiIn()
        {
            return baiInPres.DocBaiIn();
        }
        public FormStateS TinhTrangForm { get; set; }
        #endregion
        Dictionary<int, TabPage> tabList = new Dictionary<int, TabPage>();
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

            foreach (KeyValuePair<int, TabPage> kVP in tabList)
            {
                if (kVP.Value.Name == tmpTab.Name)
                {
                    // MessageBox.Show(tab.Name);
                    tabCtrl01.SelectedIndex = kVP.Key;
                    break;
                }
            }

        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                
                if (tb ==txtSoLuong)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (tb == txtKhoCatRong || tb == txtKhoCatCao) //Sô lẻ
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
            }
        }

        
        private void BaiInForm_Load(object sender, EventArgs e)
        {
            lblTieuDeForm.Text = this.Text;
            BatTatNutTabCauHinh();
            BatTatNutTabGiay();
            BatTatNutTabIn();
            BatTatNutTabThPham();
            BatNutNhan();
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(txtTieuDe.Text))
                loiS.Add("Tiêu đề bị trống");
            if (string.IsNullOrEmpty(txtDienGiai.Text))
                loiS.Add("Diễn giải trống");
            if (string.IsNullOrEmpty(txtDonVi.Text))
                loiS.Add("Đơn vị trống");
            if (string.IsNullOrEmpty(txtSoLuong.Text))
                loiS.Add("Số lượng trống");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void BaiInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string ms = "";
                if (!KiemTraHopLe(ref ms))
                {
                    var dialogeR = MessageBox.Show(ms, "Dữ liệu điền chưa chuẩn đó! Điền tiếp?",
                         MessageBoxButtons.YesNo);
                    if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                        e.Cancel = true;
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        //e.Cancel = false;
                    }

                }
            }
            
        }

      
        
        #region Cấu hình SP
        private ThongTinBanDauChoCauHinhSP thongTinCauHinhBanDau(BaiIn baiIn, FormStateS tinhTrangForm)
        {
            var thongTinChoCauHinh = new ThongTinBanDauChoCauHinhSP();
            thongTinChoCauHinh.TinhTrangForm = tinhTrangForm;
            thongTinChoCauHinh.YeuCauBaiIn = baiIn.TieuDe + '\r' + '\n'
               + baiIn.DienGiai;
            thongTinChoCauHinh.SoLuongSanPham = baiIn.SoLuong;
            thongTinChoCauHinh.DonViTinh = baiIn.DonVi;
            return thongTinChoCauHinh;
        }
        private void ThemCauHinh()
        {
                          
            if (this.ID <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = baiInPres.DocBaiIn();
            
            if (baiIn.CoCauHinh) //Đã có cấu hình
                return;
            //Tạo cấu hình
            var cauHinhSP = new CauHinhSanPham(5, 5, 0.2f, 0.2f, 0.2f, 0.2f,
                            0.2f, 0.2f, 0.2f, 0.2f,
                            baiIn.ID, PhuongPhapInS.Toner
                            , 0, "");
            //Xem có cài sẵn kích thước sản phẩm không
            if (this.SanPhamRong > 0 || this.SanPhamCao > 0)
            {
                cauHinhSP.KhoCatRong = this.SanPhamRong;
                cauHinhSP.KhoCatCao = this.SanPhamCao;
            }
            //Tiếp
            var frm = new CauHinhSPForm(thongTinCauHinhBanDau(baiIn, FormStateS.New), cauHinhSP);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
          
           
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormTrienKhaiSP_Click(frm);
                CapNhatTomTatBaiIn();
            }

            //Khóa các control về kích thước và số lượg
            KhoaMoControlsSoLuongKichThuoc(true);
            BatTatNutTabCauHinh();
            //Bật tắt
            BatNutNhan();
        }
        private void SuaCauHinhSP()
        {
            if (this.ID <= 0)
                return;
            var baiIn = baiInPres.DocBaiIn();
            if (!baiIn.CoCauHinh)
                return;

            var frm = new CauHinhSPForm(this.thongTinCauHinhBanDau(baiIn, FormStateS.Edit), baiIn.CauHinhSP);
            //Điền giữ liệu:                
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            //Xử Bấm click //trường hợp edit
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormTrienKhaiSP_Click(frm);//Cập nhật dữ liệu
                //Phải xóa giấy và mọi thứ còn lại sau đó mở khóa
                XoaGiay();
                XoaBaiInSach();
                XoaThanhPhamSach();
                //Cập nhật tóm tắt
                CapNhatTomTatBaiIn();

            }

            //Khóa các control về kích thước và số lượg
            KhoaMoControlsSoLuongKichThuoc(true);
            BatTatNutTabCauHinh();
            //Bật tắt
            BatNutNhan();
        }
        private void btnSuaCauHinhSP_Click(object sender, EventArgs e)
        {
            SuaCauHinhSP();           

        }
        private void btnXoaCauHinhSP_Click(object sender, EventArgs e)
        {
            XoaCauHinhSP();
            
           
           
        }
        private void XoaCauHinhSP()
        {
            baiInPres.XoaCauHinhSanPham();
            this.TomTatCauHinhSP = baiInPres.TomTatCauHinhSP();
            //Phải xóa giấy và mọi thứ còn lại sau đó mở khóa
            XoaGiay();
            XoaBaiInSach();
            XoaThanhPhamSach();
            //Mở một số controls:
            KhoaMoControlsSoLuongKichThuoc(false);
            BatTatNutTabCauHinh();
            BatNutNhan();
            //cập nhật
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();      
           
        }

        private void XuLyNutOKTrenFormTrienKhaiSP_Click(CauHinhSPForm frm)
        {
            ///Cấu hình SP rất quan trọng
            ///Nếu mở form sửa xong nhấn OK thì  nếu có giấy, in, thành phẩm, v.v phải bị xóa hết
            ///

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add
                    baiInPres.GanCHSPVoBaiIn(frm.DocCauHinhSanPham());
                    this.TomTatCauHinhSP = baiInPres.TomTatCauHinhSP();
                    break;
                case FormStateS.Edit:
                    //cauHinhSP.IDCauHinh = frm.IdCauHinhSP;
                    //baiInPres.CapNhatCHSPVoBaiIn(frm.DocCauHinhSanPham());
                    frm.DocCauHinhSanPham();//Để nó tự cập nhật
                    this.TomTatCauHinhSP = baiInPres.TomTatCauHinhSP();
                    //Xóa hết mọi thứ liên quan
                    baiInPres.XoaGiayDeIn();
                    baiInPres.XoaHetGiaIn();
                    baiInPres.XoaHetThanhPham();
                    //Load lại list view
                    this.TomTatGiayDeIn = baiInPres.TomTatGiayDeIn();
                    this.TomTatBaiIn_ChaoKH = baiInPres.TomTatNoiDungBaiIn_ChaoKH();
                    LoadGiaInLenListView();
                    LoadThanhPhamLenListView();
                    break;
            }
            //Cập nhật lại khổ sản phẩm trong bài in
            var baiIn = baiInPres.DocBaiIn();
            if (baiIn.CoCauHinh)
            {
                this.SanPhamRong = baiIn.CauHinhSP.KhoCatRong;
                this.SanPhamCao = baiIn.CauHinhSP.KhoCatCao;
            }

        }
        #endregion cấu hình SP

        #region Về Giấy
        private void GanGiayVoBaiIn()
        {
           
            if (this.ID <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình

            var baiIn = baiInPres.DocBaiIn();
            if (baiIn.CoGiayIn) //Đã có thì không gắn
                return;
            //Kiểm nếu đã có cấu hình mới được gắn
            if (!baiIn.CoCauHinh)
            {
                MessageBox.Show("Chưa có cấu hình Sản phẩm. Bạn cần gắn trước");
                return;
            }           
            //Tao giay de in
            
            var mucGiayDeIn = new GiayDeIn(baiIn.CauHinhSP.ToChayRong(), baiIn.CauHinhSP.ToChayCao(),
                1, 1, 1, 1, false, 0, "", baiIn.ID, 1, 1, 0);//
            //Tiến hành gắn
            var frm = new GiayDeInForm(thongTinBanDauChoGiayIn(baiIn, FormStateS.New), mucGiayDeIn);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;           
                 
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormChuanBiGiay_Click(frm);
                //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                CapNhatTomTatBaiIn();
            }
            BatNutNhan();
        }
        private ThongTinBanDauChoGiayIn thongTinBanDauChoGiayIn(BaiIn baiIn, FormStateS tinhTrangForm)
        {
            var thongTinBanDau = new ThongTinBanDauChoGiayIn();
            thongTinBanDau.IdToIn_MayInChon = baiIn.CauHinhSP.IdMayIn;
            thongTinBanDau.PhuongPhapIn = baiIn.CauHinhSP.PhuongPhapIn;
            thongTinBanDau.IdHangKhachHang = baiIn.IdHangKH;
            thongTinBanDau.TinhTrangForm = tinhTrangForm;
            thongTinBanDau.SoLuongSanPham = baiIn.SoLuong;
            thongTinBanDau.DonViTinhSanPham = baiIn.DonVi;
            thongTinBanDau.LaInDanhThiep = false;
            //lấy kích thước sp
            KichThuocPhang kichThuocSP = new KichThuocPhang();
            kichThuocSP.Rong = baiIn.CauHinhSP.KhoRongGomLe;
            kichThuocSP.Dai = baiIn.CauHinhSP.KhoCaoGomLe;
            thongTinBanDau.KichThuocSanPham = kichThuocSP;
            //Cập nhật thông tinh cần thiết, cần bao gồm khổ tờ chạy máy in
            thongTinBanDau.ThongTinCanThiet = baiIn.TieuDe + '\r' + '\n'
                + baiIn.DienGiai + '\r' + '\n'
                + string.Format("Kích thước SP: {0} x {1}cm" + '\r' + '\n', 
                        baiIn.CauHinhSP.KhoRongGomLe, baiIn.CauHinhSP.KhoCaoGomLe)
                + string.Format(" *Số lượng: {0} {1}" + '\r' + '\n', baiIn.SoLuong, baiIn.DonVi)
                + baiIn.DienGiai + '\r' + '\n'
                + baiIn.CauHinhSP.TenPhuongPhapIn + '\r' + '\n'
                + "--Khổ máy: " + baiIn.CauHinhSP.KhoMayIn + '\r' + '\n';

            return thongTinBanDau;

        }
        private void SuaGiayIn()
        {
            if (this.ID <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = baiInPres.DocBaiIn();

            var giayIn = baiInPres.LayGiayDeInTheoBaiIn();
            if (giayIn == null)
                return;

            
            var frm = new GiayDeInForm(this.thongTinBanDauChoGiayIn(baiIn,FormStateS.Edit), baiIn.GiayDeInIn);
                    
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            //Xử Bấm click //trường hợp edit
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormChuanBiGiay_Click(frm);//Cập nhật dữ liệu
                XoaGiay();              
                //Cập nhật
                CapNhatTomTatBaiIn();
            }
            //Bật tắt các nút
            //Tiếp
            BatTatNutTabGiay();
            //Tiếp
            BatNutNhan();

        }
        private void XuLyNutOKTrenFormChuanBiGiay_Click(GiayDeInForm frm)
        {
           
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add                                   
                    baiInPres.GanGiayDeIn(frm.DocGiayDeIn());
                    this.TomTatGiayDeIn = baiInPres.TomTatGiayDeIn();
                    break;
                case FormStateS.Edit:
                    frm.DocGiayDeIn();//Đọc để cập nhật
                    this.TomTatGiayDeIn = baiInPres.TomTatGiayDeIn();
                    //Phải xóa hết In luôn
                    XoaBaiInSach();
                    XoaThanhPhamSach();
                    break;
            }
        }
        private void btnThemGiay_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Về Giá In
        private void LoadGiaInLenListView()
        {
            //List view Giá In:
            lvwGiaInNhanh.Clear();
            lvwGiaInNhanh.Columns.Add("Id");
            lvwGiaInNhanh.Columns.Add("IdBaiIn");
            lvwGiaInNhanh.Columns.Add("Kiểu In");
            lvwGiaInNhanh.Columns.Add("Diễn giải");
            lvwGiaInNhanh.Columns.Add("Số lượng");
            lvwGiaInNhanh.Columns.Add("Đơn giá");
            lvwGiaInNhanh.Columns.Add("Thành tiền");
            lvwGiaInNhanh.View = System.Windows.Forms.View.Details;
            lvwGiaInNhanh.HideSelection = false;
            lvwGiaInNhanh.FullRowSelect = true;
            //==đền dữ liệu
            if (baiInPres.GiaInS().Count() > 0)
            {
                //Lấy 2 item từ bài in

                foreach (KeyValuePair<int, List<string>> kvp in baiInPres.TrinhBayGiaInS())
                {
                    var item = new ListViewItem();
                    item.Text = kvp.Key.ToString();
                    item.SubItems.AddRange(kvp.Value.ToArray());
                    lvwGiaInNhanh.Items.Add(item);
                }
                lvwGiaInNhanh.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwGiaInNhanh.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwGiaInNhanh.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwGiaInNhanh.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwGiaInNhanh.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwGiaInNhanh.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwGiaInNhanh.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
              
            }
        }
        private ThongTinBanDauChoGiaIn thongTinBanDauChoGiaIn (BaiIn baiIn, FormStateS tinhTrangForm)
        {
            //Bắt đầu
            var thongTinBanDau = new ThongTinBanDauChoGiaIn();
            thongTinBanDau.TinhTrangForm = tinhTrangForm;
            thongTinBanDau.TieuDeForm = "Giá In nhanh";
            thongTinBanDau.IdHangKhachHang = IdHangKhachHang;
            thongTinBanDau.IdBaiIn = baiIn.ID;
            thongTinBanDau.SoToChay = baiIn.GiayDeInIn.SoToChayTong;
            thongTinBanDau.IdToIn_MayIn = baiIn.CauHinhSP.IdMayIn;
            thongTinBanDau.ThongTinGiay = string.Format("{0}/{1}", baiIn.GiayDeInIn.KhoToChay,
                                 baiIn.GiayDeInIn.TenGiayIn);
            thongTinBanDau.KhoToChay = baiIn.GiayDeInIn.KhoToChay;
            return thongTinBanDau;
        }
        private void ThemGiaIn()
        {

            if (this.ID <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = baiInPres.DocBaiIn();
            //Gắn thoải mái vì có thể in mấy lần ví dụ in mực trắng

            //Kiểm nếu đã có cấu hình mới được gắn
            if (!baiIn.CoCauHinh)
            {
                MessageBox.Show("Chưa có cấu hình Sản phẩm. Bạn cần gắn trước");
                return;
            }
            if (baiIn.CauHinhSP.PhuongPhapIn == (int)PhuongPhapInS.KhongIn) //Không in
            {
                MessageBox.Show("Bạn đã đặt Không In");
                return;
            }

            if (!baiIn.CoGiayIn)
            {
                MessageBox.Show("Chưa có giấy. Bạn phải cài giấy trước");
                return;
            }
            //tạo mục Giá In để tạo mới
            var mucGiaIn = new MucGiaIn(baiIn.CauHinhSP.PhuongPhapIn, 0, baiIn.ID,
                            baiIn.CauHinhSP.IdMayIn, 0, "0", baiIn.IdHangKH,
                            baiIn.GiayDeInIn.SoToChayTong, 2);
                   

            switch (baiIn.CauHinhSP.PhuongPhapIn)
            {
                case PhuongPhapInS.Toner:
                    var frmDigi = new GiaInNhanhForm(this.thongTinBanDauChoGiaIn(baiIn, FormStateS.New), mucGiaIn);
                    frmDigi.TinhTrangForm = FormStateS.New;
                    frmDigi.MinimizeBox = false;
                    frmDigi.MaximizeBox = false;
                    frmDigi.StartPosition = FormStartPosition.CenterParent;
                    frmDigi.ShowDialog();
                    if (frmDigi.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKTrenFormGiaIn_Click(frmDigi);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadGiaInLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay
                        CapNhatTomTatBaiIn();
                    }
                    break;
                case PhuongPhapInS.KhongIn:
                    break;
                case PhuongPhapInS.Offset:                   
                    var frmOffset = new GiaInOffsetForm(this.thongTinBanDauChoGiaIn(baiIn, FormStateS.New));                 
                    frmOffset.TinhTrangForm = FormStateS.New;
                    frmOffset.MinimizeBox = false;
                    frmOffset.MaximizeBox = false;
                    frmOffset.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form
                   
                   
                    frmOffset.ShowDialog();
                    if (frmOffset.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKTrenFormGiaInOffset_Click(frmOffset);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadGiaInLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay
                        CapNhatTomTatBaiIn();
                    }
                    break;

            }
            //bật tắt
            BatTatNutTabIn();
            BatNutNhan();
        }
        private void SuaGiaIn()
        {

            if (this.IdGiaInChon > 0)
            {
                var giaIn = baiInPres.LayGiaInTheoId(this.IdGiaInChon);
                var baiIn = baiInPres.DocBaiIn();

                if (baiIn.CauHinhSP.PhuongPhapIn == PhuongPhapInS.KhongIn) //Không in
                    return;
     
                var frm = new GiaInNhanhForm(this.thongTinBanDauChoGiaIn(baiIn, FormStateS.Edit), giaIn);
                frm.TinhTrangForm = FormStateS.Edit;
                //Điền giữ liệu: 

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
            //bật tắt
            BatTatNutTabIn();
            BatNutNhan();
        }

        private void XuLyNutOKTrenFormGiaIn_Click(GiaInNhanhForm frm)
        {
            
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add
                    ; //Id tự tạo

                    baiInPres.ThemGiaIn(frm.DocGiaIn());

                    break;
                case FormStateS.Edit:
                    //cập nhật 
                    frm.DocGiaIn();//Đọc vậy là cập nhật luôn rồi.
                    

                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        private void XuLyNutOKTrenFormGiaInOffset_Click(GiaInOffsetForm frm)
        {
            
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add
                    ; //Id tự tạo

                    baiInPres.ThemGiaIn(frm.DocGiaIn);

                    break;
                case FormStateS.Edit:
                                                           
                    baiInPres.SuaGiaIn(frm.DocGiaIn);

                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }

        #endregion

        #region Thành phẩm Chung
        private void LoadThanhPhamLenListView()
        {
            //List view Giá In:            
            lvwThanhPham.Clear();
            lvwThanhPham.Columns.Add("Id");                        
            lvwThanhPham.Columns.Add("Tên Thành phẩm");           
            lvwThanhPham.Columns.Add("Số lượng");
            lvwThanhPham.Columns.Add("ĐVT");
            lvwThanhPham.Columns.Add("Thành tiền");
            lvwThanhPham.View = System.Windows.Forms.View.Details;
            lvwThanhPham.HideSelection = false;
            lvwThanhPham.FullRowSelect = true;
            //==đền dữ liệu
            if (baiInPres.ThanhPhamS().Count > 0)
            {
                foreach (KeyValuePair<int, List<string>> kvp in baiInPres.TrinhBayThanhPhamS())
                {
                    var item = new ListViewItem();
                    item.Text = kvp.Key.ToString();
                    item.SubItems.AddRange(kvp.Value.ToArray());
                    lvwThanhPham.Items.Add(item);
                }
                lvwThanhPham.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwThanhPham.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
             
               
            }
        }
        
        private ThongTinBanDauThanhPham thongTinBanDauChoThanhPham(int idBaiIn, int idHangKH, int soLuongSP, string donViTinh,
            int soToChay, LoaiThanhPhamS loaiThPh,
                string thongDiepThem, FormStateS tinhTrangForm, string tieuDeForm )
        {
            var thongTinBanDau = new ThongTinBanDauThanhPham ();
            thongTinBanDau.IdBaiIn = idBaiIn;
            thongTinBanDau.IdHangKhachHang = idHangKH;
            thongTinBanDau.ThongDiepCanThiet = thongDiepThem;
            thongTinBanDau.TinhTrangForm = tinhTrangForm;
            thongTinBanDau.SoLuongSanPham = soLuongSP;
            thongTinBanDau.DonViTinh = donViTinh;
            thongTinBanDau.SoLuongToChay = soToChay;
            thongTinBanDau.LoaiThanhPham = loaiThPh;
            thongTinBanDau.TieuDeForm = tieuDeForm;
            return thongTinBanDau;
        }
        private void ThemThanhPham(int idBaiIn, LoaiThanhPhamS loaiThPh)
        {
            if (idBaiIn <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = baiInPres.DocBaiIn();
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
            var thongTinBanDauThPh = this.thongTinBanDauChoThanhPham(baiIn.ID, baiIn.IdHangKH,
                        baiIn.SoLuong, baiIn.DonVi, baiIn.GiayDeInIn.SoToChayTong,
                        LoaiThanhPhamS.CanGap, "", FormStateS.New, "");
            //Tiến hành gắn
            switch (loaiThPh)
            {
                #region Cán phủ, cấn gấp, cắt decal, ép kim
                case LoaiThanhPhamS.CanPhu:
                    var thongDiep1 = string.Format("Số tờ chạy: {0} / Khổ: {1}",
                       baiIn.GiayDeInIn.SoToChayTong, baiIn.GiayDeInIn.KhoToChay);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep1;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Cán phủ";
                    thongTinBanDauThPh.LoaiThanhPham = LoaiThanhPhamS.CanPhu;
                    thongTinBanDauThPh.MoTextSoLuong = false; //Tắt số lượng
                    //Mục thành phẩm cán phủ
                    var mucThPhCanPhu = new MucThPhCanPhu();
                    mucThPhCanPhu.IdBaiIn = baiIn.ID;
                    mucThPhCanPhu.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhCanPhu.LoaiThanhPham = LoaiThanhPhamS.CanPhu;
                    mucThPhCanPhu.SoLuong = baiIn.GiayDeInIn.SoToChayTong; //Số tờ chạy
                    mucThPhCanPhu.ToChayRong = baiIn.GiayDeInIn.ToChayRong;
                    mucThPhCanPhu.ToChayDai = baiIn.GiayDeInIn.ToChayDai;
                    mucThPhCanPhu.DonViTinh = "tờ";
                    mucThPhCanPhu.SoMatCan = 1;

                    var frm = new ThPhCanPhuForm(thongTinBanDauThPh, mucThPhCanPhu);

                    frm.MinimizeBox = false;
                    frm.MaximizeBox = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanPhu(frm);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.CanGap:
                    var thongDiep2 = string.Format("Số lượng SP: {0} / Số lượng tờ chạy: {1}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep2;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Cấn gấp";
                    thongTinBanDauThPh.LoaiThanhPham = LoaiThanhPhamS.CanGap;
                    //Mục thành phẩm cấn gấp
                    var mucThPhCanGap = new MucThPhCanGap();
                    mucThPhCanGap.IdBaiIn = baiIn.ID;
                    mucThPhCanGap.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhCanGap.LoaiThanhPham = LoaiThanhPhamS.CanGap;
                    mucThPhCanGap.SoLuong = baiIn.SoLuong;
                    mucThPhCanGap.DonViTinh = "con";
                    mucThPhCanGap.SoDuongCan = 1;
                    var frm2 = new ThPhCanGapForm(thongTinBanDauThPh, mucThPhCanGap);

                    frm2.MinimizeBox = false;
                    frm2.MaximizeBox = false;
                    frm2.StartPosition = FormStartPosition.CenterParent;

                    frm2.ShowDialog();
                    if (frm2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanGap(frm2);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.KhoanBoGoc:
                    var thongDiep9 = string.Format("Tờ chạy: {0} // {1} tờ" + '\r' + '\n',
                                    baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongDiep9 += string.Format("Sản phẩm: {0} x {1}cm // {2} {3}",
                        baiIn.CauHinhSP.KhoCatRong, baiIn.CauHinhSP.KhoCatCao,
                        baiIn.SoLuong, baiIn.DonVi);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep9;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Khoan/Bo bóc";
                    thongTinBanDauThPh.LoaiThanhPham = LoaiThanhPhamS.KhoanBoGoc;
                    
                    //Mục thành phẩm cấn gấp
                    var mucThPhKhoanBoGoc = new MucThPhKhoanBoGoc();
                    mucThPhKhoanBoGoc.IdBaiIn = baiIn.ID;
                    mucThPhKhoanBoGoc.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhKhoanBoGoc.LoaiThanhPham = LoaiThanhPhamS.KhoanBoGoc;
                    mucThPhKhoanBoGoc.KhoSanPhamRong = baiIn.CauHinhSP.KhoCatRong;
                    mucThPhKhoanBoGoc.KhoSanPhamCao = baiIn.CauHinhSP.KhoCatCao;
                    mucThPhKhoanBoGoc.SoLuongSanPham = baiIn.SoLuong; //Số lượng sản phẩm
                    mucThPhKhoanBoGoc.DonViTinh = "block";
                    mucThPhKhoanBoGoc.SoLanKhoanBoTrenMoiBlock = 1;

                    var frm9 = new ThPhKhoanBoGocForm(thongTinBanDauThPh, mucThPhKhoanBoGoc);

                    frm9.MinimizeBox = false;
                    frm9.MaximizeBox = false;
                    frm9.StartPosition = FormStartPosition.CenterParent;

                    frm9.ShowDialog();
                    if (frm9.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormKhoanBoGoc(frm9);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                #endregion
                #region Cắt decal, ép kim, Bế
                case LoaiThanhPhamS.CatDecal:
                    var thongDiep3 = string.Format("Số lượng {0} {1}",
                        baiIn.SoLuong, baiIn.DonVi);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep3;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Cắt decal";
                    
                    //tạo mục thành phẩm đóng cuốn
                    var mucThPhCatDecal = new MucThPhCatDecal();
                    mucThPhCatDecal.IdBaiIn = baiIn.ID;
                    mucThPhCatDecal.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhCatDecal.LoaiThanhPham = LoaiThanhPhamS.CatDecal;
                    mucThPhCatDecal.SoLuong = this.SoLuong;
                    mucThPhCatDecal.ConRong = baiIn.CauHinhSP.KhoCatRong;
                    mucThPhCatDecal.ConCao = baiIn.CauHinhSP.KhoCatCao;
                    mucThPhCatDecal.DonViTinh = "con";
                   
                    var frm3 = new ThPhCatDecalForm(thongTinBanDauThPh, mucThPhCatDecal);

                    frm3.MinimizeBox = false;
                    frm3.MaximizeBox = false;
                    frm3.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm3.IdBaiIn = baiIn.ID;
                    frm3.IdHangKhachHang = baiIn.IdHangKH;
                    frm3.ShowDialog();
                    if (frm3.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCatDecal(frm3);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.EpKim:
                    var thongDiep4 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Số tờ chạy {2}",
                       baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep4;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Ép kim";
                    thongTinBanDauThPh.LoaiThanhPham = LoaiThanhPhamS.EpKim;
                    //tạo mới mục ép kim
                    var mucThPhEpKim = new MucThPhEpKim();
                    mucThPhEpKim.IdBaiIn = baiIn.ID;
                    mucThPhEpKim.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhEpKim.LoaiThanhPham = LoaiThanhPhamS.EpKim;
                    mucThPhEpKim.SoLuong = baiIn.SoLuong; //Tạm
                    mucThPhEpKim.DonViTinh = "con";
                    mucThPhEpKim.KhoEpRong = 5f;
                    mucThPhEpKim.KhoEpCao = 5f;
                    mucThPhEpKim.KhoToChayRong = baiIn.GiayDeInIn.ToChayRong;
                    mucThPhEpKim.KhoToChayDai = baiIn.GiayDeInIn.ToChayDai;
                    mucThPhEpKim.SoLuongToChay = baiIn.GiayDeInIn.SoToChayTong;

                    var frm4 = new ThPhEpKimForm(thongTinBanDauThPh,mucThPhEpKim);

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
               
                
                case LoaiThanhPhamS.Be:
                    var thongDiep6 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Số tờ chạy {2}",
                       baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep6;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Bế";
                    thongTinBanDauThPh.LoaiThanhPham = LoaiThanhPhamS.Be;
                    //tạo mới mục ép kim
                    var mucThPhBe= new MucThPhBe();
                    mucThPhBe.IdBaiIn = baiIn.ID;
                    mucThPhBe.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhBe.LoaiThanhPham = LoaiThanhPhamS.Be;
                    mucThPhBe.SoLuong = baiIn.SoLuong; //Tạm
                    //mucThPhBe.DonViTinh = "con";
                    mucThPhBe.KhoBeRong = baiIn.GiayDeInIn.ToChayRong;
                    mucThPhBe.KhoBeCao = baiIn.GiayDeInIn.ToChayDai;
                    mucThPhBe.KhoToChayRong = baiIn.GiayDeInIn.ToChayRong;
                    mucThPhBe.KhoToChayDai = baiIn.GiayDeInIn.ToChayDai;
                    mucThPhBe.SoLuongToChay = baiIn.GiayDeInIn.SoToChayTong;
                    mucThPhBe.SoLuong = mucThPhBe.SoLuongToChay;

                    var frm6 = new ThPhBeForm(thongTinBanDauThPh, mucThPhBe);

                    frm6.MinimizeBox = false;
                    frm6.MaximizeBox = false;
                    frm6.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm6.IdBaiIn = baiIn.ID;
                    frm6.IdHangKhachHang = baiIn.IdHangKH;
                    frm6.ShowDialog();
                    if (frm6.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormBe(frm6);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                #endregion

                #region mục bồi bìa cứng, bồi nhiều lớp
                case LoaiThanhPhamS.BoiBiaCung:
                    var thongDiep5 = string.Format("Tờ chạy: {0}" + '\r' + '\n',
                        baiIn.GiayDeInIn.KhoToChay);
                        thongDiep5 += string.Format("Số lượng SP: {0} {1}" + '\r' + '\n',
                        baiIn.SoLuong, baiIn.DonVi);
                    
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep5;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Bồi bìa cứng";
                    thongTinBanDauThPh.MoTextSoLuong = true;
                    //tạo mục thành phẩm đóng cuốn
                    var mucThPhBoiBiaCung = new MucThPhBoiBiaCung();
                    mucThPhBoiBiaCung.IdBaiIn = baiIn.ID;
                    mucThPhBoiBiaCung.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhBoiBiaCung.LoaiThanhPham = LoaiThanhPhamS.BoiBiaCung;
                    mucThPhBoiBiaCung.SoLuong = this.SoLuong;
                    mucThPhBoiBiaCung.TamRong = baiIn.CauHinhSP.KhoCatRong;
                    mucThPhBoiBiaCung.TamCao = baiIn.CauHinhSP.KhoCatCao;
                    mucThPhBoiBiaCung.DonViTinh = "tấm";

                    var frm5 = new ThPhBoiBiaCungForm(thongTinBanDauThPh, mucThPhBoiBiaCung);

                    frm5.MinimizeBox = false;
                    frm5.MaximizeBox = false;
                    frm5.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm5.IdBaiIn = baiIn.ID;
                    frm5.IdHangKhachHang = baiIn.IdHangKH;
                    frm5.ShowDialog();
                    if (frm5.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormBoiBiaCung(frm5);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.BoiNhieuLop:
                    var thongDiep7 = string.Format("Tờ chạy: {0}" + '\r' + '\n',
                        baiIn.GiayDeInIn.KhoToChay);
                        thongDiep7 += string.Format("Số lượng {0} {1}" + '\r' + '\n',
                        baiIn.GiayDeInIn.SoToChayTong, "tấm");
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep7;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Bồi nhiều lớp";
                    thongTinBanDauThPh.MoTextSoLuong = true;
                    //tạo mục thành phẩm đóng cuốn
                    var mucThPhBoiNhieuLop = new MucThPhBoiNhieuLop();
                    mucThPhBoiNhieuLop.IdBaiIn = baiIn.ID;
                    mucThPhBoiNhieuLop.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhBoiNhieuLop.LoaiThanhPham = LoaiThanhPhamS.BoiNhieuLop;
                    mucThPhBoiNhieuLop.SoLuongToChay = baiIn.GiayDeInIn.SoToChayTong;
                    //mucThPhBoiNhieuLop.SoLuong = baiIn.GiayDeInIn.SoToChayTong; //lấy số lượng theo tờ chạy
                    mucThPhBoiNhieuLop.SoLopLotGiua = 0; //không lót giữa
                    mucThPhBoiNhieuLop.ToBoiRong = baiIn.GiayDeInIn.ToChayRong;
                    mucThPhBoiNhieuLop.ToBoiCao = baiIn.GiayDeInIn.ToChayDai;
                    mucThPhBoiNhieuLop.DonViTinh = "tấm";

                    var frm7 = new ThPhBoiNhieuLopForm(thongTinBanDauThPh, mucThPhBoiNhieuLop);

                    frm7.MinimizeBox = false;
                    frm7.MaximizeBox = false;
                    frm7.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm7.IdBaiIn = baiIn.ID;
                    frm7.IdHangKhachHang = baiIn.IdHangKH;
                    frm7.ShowDialog();
                    if (frm7.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormBoiNhieuLop(frm7);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                #endregion
                case LoaiThanhPhamS.GiaCongNgoai:
                    var thongDiep12 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
                       baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep12;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Khác";
                    
                    //Mục gia công ngoài
                    var mucGiaCongNgoai = new MucThPhGiaCongNgoai();
                    mucGiaCongNgoai.TenThanhPham = "Thành phẩm";
                    mucGiaCongNgoai.LoaiThanhPham = LoaiThanhPhamS.GiaCongNgoai;
                    mucGiaCongNgoai.SoLuong = 10;
                    mucGiaCongNgoai.DonViTinh = "???";
                    mucGiaCongNgoai.PhiGiaCong = 1;
                    mucGiaCongNgoai.PhiVanChuyen = 0;    
                    //Nạp
                    var frm12 = new ThPhGiaCongNgoaiForm(thongTinBanDauThPh, mucGiaCongNgoai);

                    frm12.MinimizeBox = false;
                    frm12.MaximizeBox = false;
                    frm12.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm12.IdBaiIn = baiIn.ID;
                    frm12.IdHangKhachHang = baiIn.IdHangKH;
                    frm12.ShowDialog();
                    if (frm12.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormThPhamKhac(frm12);
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
            var mucThPh = baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
            
            var baiIn = baiInPres.DocBaiIn();
            var thongTinBanDauThPh = this.thongTinBanDauChoThanhPham(baiIn.ID, baiIn.IdHangKH,
                     baiIn.SoLuong, baiIn.DonVi, baiIn.GiayDeInIn.SoToChayTong,
                      mucThPh.LoaiThanhPham, "", FormStateS.Edit, "");
            

            switch (thongTinBanDauThPh.LoaiThanhPham)
            {
                case LoaiThanhPhamS.CanPhu:
                     var thongDiep1 = string.Format("Số tờ giấy in {0} khổ: {1}",
                        baiIn.GiayDeInIn.SoToChayTong, baiIn.GiayDeInIn.KhoToChay);
                     thongTinBanDauThPh.ThongDiepCanThiet = thongDiep1;
                     thongTinBanDauThPh.TieuDeForm = "[Sửa] Cán phủ";

                     var frm1 = new ThPhCanPhuForm(thongTinBanDauThPh, (MucThPhCanPhu)mucThPh);
                    
                    frm1.MinimizeBox = false;
                    frm1.MaximizeBox = false;
                    frm1.StartPosition = FormStartPosition.CenterParent;
                                     
                    frm1.ShowDialog();
                    if (frm1.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanPhu(frm1);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.CanGap:
                    var thongDiep2 = string.Format("Số lượng SP: {0} / Số lượng tờ chạy: {1}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep2;
                     thongTinBanDauThPh.TieuDeForm = "[Sửa] Cấn gấp";
                     var frm2 = new ThPhCanGapForm(thongTinBanDauThPh, (MucThPhCanGap)mucThPh);
                    
                    frm2.Text = "Cấn gấp [Sửa]";
                    frm2.MinimizeBox = false;
                    frm2.MaximizeBox = false;
                    frm2.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form
                   
                    frm2.TenThanhPhamChon = mucThPh.TenThanhPham;
                  
                    frm2.ShowDialog();
                    if (frm2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanGap(frm2);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.KhoanBoGoc:
                     var thongDiep9 = string.Format("Tờ chạy: {0} // {1} tờ" + '\r' + '\n',
                                    baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongDiep9 += string.Format("Sản phẩm: {0} x {1}cm // {2} {3}",
                        baiIn.CauHinhSP.KhoCatRong, baiIn.CauHinhSP.KhoCatCao,
                        baiIn.SoLuong, baiIn.DonVi);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep9;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa] Khoan/Bo bóc";

                    var frm9 = new ThPhKhoanBoGocForm(thongTinBanDauThPh, (MucThPhKhoanBoGoc)mucThPh);

                    frm9.Text = "[Sửa] Khoan/Bo góc";
                    frm9.MinimizeBox = false;
                    frm9.MaximizeBox = false;
                    frm9.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form

                    //frm8.TenThanhPhamChon = mucThPh.TenThanhPham;

                    frm9.ShowDialog();
                    if (frm9.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormKhoanBoGoc(frm9);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;

                #region Ép kim, Bế
                case LoaiThanhPhamS.EpKim:
                    var thongDiep4 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Số tờ chạy {2}",
                        baiIn.SoLuong,  baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep4;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa] Ép kim";
                    var frm4 = new ThPhEpKimForm(thongTinBanDauThPh, (MucThPhEpKim)mucThPh);
                    
                    frm4.MinimizeBox = false;
                    frm4.MaximizeBox = false;
                    frm4.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form                   

                    frm4.ShowDialog();
                    if (frm4.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormEpKim(frm4);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.Be:
                    var thongDiep7 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Số tờ chạy {2}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep7;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa] Bế";
                    var frm7 = new ThPhBeForm(thongTinBanDauThPh, (MucThPhBe)mucThPh);

                    frm7.MinimizeBox = false;
                    frm7.MaximizeBox = false;
                    frm7.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form                   

                    frm7.ShowDialog();
                    if (frm7.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormBe(frm7);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                #endregion
                #region Bồi, căt decal, dán
                case LoaiThanhPhamS.BoiBiaCung:
                    var thongDiep5 = string.Format("Số lượng {0} con / khổ tờ chạy: {1}" + '\n' + '\r',
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong)
                        + string.Format("Con: {0} x {1}cm" + '\n' + '\r',
                        baiIn.CauHinhSP.KhoCatRong, baiIn.CauHinhSP.KhoCatCao);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep5;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa] Bồi bìa cứng";
                    thongTinBanDauThPh.MoTextSoLuong = true;
                    var frm5 = new ThPhBoiBiaCungForm(thongTinBanDauThPh, (MucThPhBoiBiaCung)mucThPh);

                    frm5.MinimizeBox = false;
                    frm5.MaximizeBox = false;
                    frm5.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form                   

                    frm5.ShowDialog();
                    if (frm5.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {

                        XuLyNutOKClick_FormBoiBiaCung(frm5);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.BoiNhieuLop:
                     var thongDiep8 = string.Format("Tờ chạy: {0}" + '\r' + '\n',
                        baiIn.GiayDeInIn.KhoToChay);
                        thongDiep8 += string.Format("Số lượng {0} {1}" + '\r' + '\n',
                        baiIn.GiayDeInIn.SoToChayTong, "tấm");

                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep8;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa] Bồi nhiều lớp";
                    thongTinBanDauThPh.MoTextSoLuong = true;
                    var frm8 = new ThPhBoiNhieuLopForm(thongTinBanDauThPh, (MucThPhBoiNhieuLop)mucThPh);

                    frm8.MinimizeBox = false;
                    frm8.MaximizeBox = false;
                    frm8.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form                   

                    frm8.ShowDialog();
                    if (frm8.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {

                        XuLyNutOKClick_FormBoiNhieuLop(frm8);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPhamS.CatDecal:
                    var thongDiep6 = string.Format("Số lượng {0} con / khổ tờ chạy: {1}" + '\n' + '\r',
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong)
                        + string.Format("Con: {0} x {1}cm" + '\n' + '\r',
                        baiIn.CauHinhSP.KhoCatRong, baiIn.CauHinhSP.KhoCatCao);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep6;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa] Bồi bìa cứng";
                    var frm6 = new ThPhCatDecalForm(thongTinBanDauThPh, (MucThPhCatDecal)mucThPh);

                    frm6.MinimizeBox = false;
                    frm6.MaximizeBox = false;
                    frm6.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form                   

                    frm6.ShowDialog();
                    if (frm6.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {

                        XuLyNutOKClick_FormCatDecal(frm6);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                #endregion
                case LoaiThanhPhamS.GiaCongNgoai:
                    var thongDiep12 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep12;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa]";
                    //Mục thành phẩm riêng
                    var mucThPhKhac = (MucThPhGiaCongNgoai) baiIn.DocThanhPhamTheoID(this.IdThanhPhamChon);

                    var frm12 = new ThPhGiaCongNgoaiForm(thongTinBanDauThPh, mucThPhKhac);

                    frm12.MinimizeBox = false;
                    frm12.MaximizeBox = false;
                    frm12.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form                   

                    frm12.ShowDialog();
                    if (frm12.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormThPhamKhac(frm12);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
            }
            //Bật tắt
            BatTatNutTabThPham();
            BatNutNhan();

        }
#endregion
        #region Xử lý form Cán phủ
        private void XuLyNutOKClick_FormCanPhu(ThPhCanPhuForm frm)
        {

            
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add                             
                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //Referen nên không cần làm kiểu cũ
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());
                    frm.LayMucThanhPham();
                   
                    //Không cần cập nhật vì tự động khi Find

                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion

        #region Cấn gấp, khoan bo góc
        private void XuLyNutOKClick_FormCanGap(ThPhCanGapForm frm)
        {
          
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add
                  
                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                   
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//không cần làm vậy vì reference
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        private void XuLyNutOKClick_FormKhoanBoGoc(ThPhKhoanBoGocForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add

                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:

                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//không cần làm vậy vì reference
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
      
        #region Ép kim
        private void XuLyNutOKClick_FormEpKim(ThPhEpKimForm frm)
        {
           
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                   
                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //Tạo 
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không còn 
                    //Gọi để cập nhật
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
        #region Bế, cắt decal
        private void XuLyNutOKClick_FormBe(ThPhBeForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:

                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //Tạo 
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không còn 
                    //Gọi để cập nhật
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
       
       
        private void XuLyNutOKClick_FormCatDecal(ThPhCatDecalForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:

                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //Tạo 
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không còn 
                    //Gọi để cập nhật
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
        #region Xử lý form bồi bìa cứng, bồi nhiều lớp
        private void XuLyNutOKClick_FormBoiBiaCung(ThPhBoiBiaCungForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:

                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //Tạo 
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không còn 
                    //Gọi để cập nhật
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        private void XuLyNutOKClick_FormBoiNhieuLop(ThPhBoiNhieuLopForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:

                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //Tạo 
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không còn 
                    //Gọi để cập nhật
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
        #region Thành phẩm khác
        private void XuLyNutOKClick_FormThPhamKhac(ThPhGiaCongNgoaiForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:

                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //Tạo 
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//khong còn cần
                    //Cập nhật nè
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion

        private void cmnuGanCauHinhSP_Click(object sender, EventArgs e)
        {
            ThemCauHinh();
            BatTatNutTabCauHinh();
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
            ThemGiaIn();
        }

        private void btnSuaGiaInNhanh_Click(object sender, EventArgs e)
        {
            SuaGiaIn();
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();        
        }

        private void btnXoaGiaInNhanh_Click(object sender, EventArgs e)
        {
            if (this.ID > 0)
            {
                baiInPres.XoaGiaIn(this.IdGiaInChon);
                LoadGiaInLenListView();//Load lại
            }
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();   
            //batTat
            BatTatNutTabIn();
            BatNutNhan();

        }

        private void cmnuThanhPham_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.CanPhu);
        }

        private void cmnuThPh_CanGap_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.CanGap);
        }

        private void cmnuThPh_DongCuon_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.DongCuon);
        }

        private void btnSuaThanhPham_Click(object sender, EventArgs e)
        {
            SuaThanhPham();
        }

        private void lvwBaiIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadChiTietBaiInTheoIdBaiIn();
        }

        
        private void btnXoaGiayDeIn_Click(object sender, EventArgs e)
        {
            XoaGiay();
           
        }
        private void XoaGiay()
        {
            if (this.ID > 0)
            {
                baiInPres.XoaGiayDeIn();
                this.TomTatGiayDeIn = baiInPres.TomTatGiayDeIn();
            }
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
            //Bật tắt nút
            //Tiếp
            BatTatNutTabGiay();
            //Tiếp
            BatNutNhan();
        }

        private void btnXoaHetBaiInNhanh_Click(object sender, EventArgs e)
        {
            XoaBaiInSach();
        }
        private void XoaBaiInSach()
        {
            baiInPres.XoaHetGiaIn();
            //Cập nhật lại listview
            LoadGiaInLenListView();
            //
            //batTat
            BatTatNutTabIn();
            BatNutNhan();
            //Cap nhat
            CapNhatTomTatBaiIn();        
        }
        private void CapNhatTomTatBaiIn()
        {
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();    
        }
        private void btnXoaThanhPham_Click(object sender, EventArgs e)
        {
            baiInPres.XoaThanhPham(baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon));
            //Cần cập nhật lại listview Bài in
            LoadThanhPhamLenListView();
            //Bật tắt
            BatTatNutTabThPham();
            BatNutNhan();
             //Cap nhat noi dung bai in
            CapNhatTomTatBaiIn();       
        }
        private void btnXoaHetThanhPham_Click(object sender, EventArgs e)
        {
            XoaThanhPhamSach();
        }
        private void XoaThanhPhamSach()
        {
            baiInPres.XoaHetThanhPham();
            LoadThanhPhamLenListView();
            //Bật tắt
            BatTatNutTabThPham();
            BatNutNhan();
            //Cap Nhat cac nhan
            CapNhatTomTatBaiIn();  
        }
        private void cmnuThPh_EpKim_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.EpKim);
        }
       

        private void cmnuThPh_Khac_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.GiaCongNgoai);
        }

        private void cmuTabBaiIn_Opening(object sender, CancelEventArgs e)
        {

        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                if (tb == txtCauHinhSP || tb == txtGiayDeIn
                    )
                    txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
                if (tb == txtSoLuong)
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "10";
                if (tb == txtDonVi)
                    if (string.IsNullOrEmpty(txtDonVi.Text.Trim()))
                        txtDonVi.Text = "đv";
                if (tb == txtKhoCatRong)
                    if (string.IsNullOrEmpty(txtKhoCatRong.Text.Trim()))
                        this.SanPhamRong = 5;
                if (tb == txtKhoCatCao)
                    if (string.IsNullOrEmpty(txtKhoCatCao.Text.Trim()))
                        this.SanPhamCao = 5;

            }

        }
       
        private void btnCopyToClipBoardNoiDungMucChon_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTomTatBaiIn.Text))
                Clipboard.SetText(txtTomTatBaiIn.Text);
        }
        private void ListViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv;
            if (sender is ListView)
            {
                lv = (ListView)sender;
                if (lv == lvwGiaInNhanh)
                {
                    if (lv.SelectedItems.Count <= 0)
                    {
                        btnSuaGiaInNhanh.Enabled = false;
                        btnXoaGiaInNhanh.Enabled = false;
                        btnXoaSachGiaiIn.Enabled = false;
                    }
                    else
                    {
                        btnSuaGiaInNhanh.Enabled = true;
                        btnXoaGiaInNhanh.Enabled = true;
                        btnXoaSachGiaiIn.Enabled = true;
                    }
                }
                if (lv == lvwThanhPham)
                {
                    if (lv.SelectedItems.Count <= 0)
                    {
                        btnSuaThanhPham.Enabled = false;
                        btnXoaThanhPham.Enabled = false;
                        btnXoaHetThanhPham.Enabled = false;
                    }
                    else
                    {
                        btnSuaThanhPham.Enabled = true;
                        btnXoaThanhPham.Enabled = true;
                        btnXoaHetThanhPham.Enabled = true;
                    }
                }

            }
           

        }
       
        private void CapNhatTenHangKH()
        {
            this.TenHangKhachHang = baiInPres.TenHangKhachHang();
        }

        private void cmnuThPh_CatDecal_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.CatDecal);
        }

        private void cmnuThPh_BoiBiaCung_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.BoiBiaCung);
        }

        private void btnGetProdTemplate_Click(object sender, EventArgs e)
        {
            KhoSanPhamSForm frm = new KhoSanPhamSForm(FormStateS.Get);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Lấy khổ SP";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.SanPhamRong = frm.Rong;
                this.SanPhamCao = frm.Cao;
            }
        }

        private void tabCtrl01_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bật tắt các nút
            if (tabCtrl01.SelectedTab == tabGiaIn)
            {
                ListViews_SelectedIndexChanged(lvwGiaInNhanh, e);
            }
            if (tabCtrl01.SelectedTab == tabThanhPham)
            {
                ListViews_SelectedIndexChanged(lvwThanhPham, e);
            }
            if (tabCtrl01.SelectedTab == tabTruocIn)
            {
                ListViews_SelectedIndexChanged(lvwTruocIn, e);
            }
           
        }

        private void cmnuThPh_Be_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.Be);
        }

        private void cmnuThPh_BoiNhieuLop_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.BoiNhieuLop);
        }
        private void cmnuThPh_KhoanBoGoc_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPhamS.KhoanBoGoc);
        }
        
        private void BatTatNutTabGiay()
        {
            var baiIn = baiInPres.DocBaiIn();
            if (baiIn.CoGiayIn)
            {
                btnSuaGiayIn.Enabled = true;
                btnXoaGiayDeIn.Enabled = true;
            }
            else
            {
                btnSuaGiayIn.Enabled = false;
                btnXoaGiayDeIn.Enabled = false;
            }
        }
        private void BatTatNutTabCauHinh()
        {
            var baiIn = baiInPres.DocBaiIn();
            if (baiIn.CoCauHinh)
            {
                btnSuaCauHinhSP.Enabled = true;
                btnXoaCauHinhSP.Enabled = true;
            }
            else
            {
                btnSuaCauHinhSP.Enabled = false;
                btnXoaCauHinhSP.Enabled = false;
            }
        }
        private void BatTatNutTabIn()
        {
             var baiIn = baiInPres.DocBaiIn();
             if (baiIn.CoIn)
             {
                 btnSuaGiaInNhanh.Enabled = true;
                 btnXoaGiaInNhanh.Enabled = true;
                 btnXoaSachGiaiIn.Enabled = true;
             }
             else
             {
                 btnSuaGiaInNhanh.Enabled = false;
                 btnXoaGiaInNhanh.Enabled = false;
                 btnXoaSachGiaiIn.Enabled = false;
             }
        }
        private void BatTatNutTabThPham()
        {
            var baiIn = baiInPres.DocBaiIn();
             if (baiIn.CoThanhPham)
             {
                 btnSuaThanhPham.Enabled = true;
                 btnXoaThanhPham.Enabled = true;
                 btnXoaHetThanhPham.Enabled = true;
             }
             else
             {
                 btnSuaThanhPham.Enabled = false;
                 btnXoaThanhPham.Enabled = false;
                 btnXoaHetThanhPham.Enabled = false;
             }
        }
        private void BatNutNhan()
        {
            var kq = true;
           
            var baiIn = baiInPres.DocBaiIn();
            if (baiIn == null) //Thuát luôn
            {
                btnOK.Enabled = false;
                return;
            }
            //Xem cấu hình
            if (!baiIn.CoCauHinh)
            {
                kq = false;
            }
            else
            {
                if (!baiIn.CoGiayIn)
                    kq = false;
                if (baiIn.CauHinhSP.PhuongPhapIn != PhuongPhapInS.KhongIn)
                {
                    if (baiIn.GiaInS.Count <= 0)
                    {
                        lblThongTinCanhBaoNutNhan.Text = "Bạn chọn In cần có Giá in!";
                        kq = false;
                    }
                }
            }

            btnOK.Enabled = kq;
            if (kq) //True cho phép nhận thôi cảnh báo
                lblThongTinCanhBaoNutNhan.Text = "";
        }

        private void cmnuCauHinhToiIn_Opening(object sender, CancelEventArgs e)
        {
            var baiIn = baiInPres.DocBaiIn();
            if (baiIn.CoCauHinh)
            {
                //Cấu hình
                cmnuGanCauHinhSP.Enabled = false;
                btnSuaCauHinhSP.Enabled = true;
                //Phương pháp in
                if (baiIn.CauHinhSP.PhuongPhapIn == PhuongPhapInS.KhongIn)
                {
                    cmnuGanGiaIn.Enabled = false;
                    btnSuaGiaInNhanh.Enabled = false;
                }
                else
                {

                    cmnuGanGiaIn.Enabled = true;
                    btnSuaGiaInNhanh.Enabled = true;
                }
                //Giấy
                if (baiIn.CoGiayIn)
                {
                    cmnuChuanBiGiay.Enabled = false;
                    btnSuaGiayIn.Enabled = true;
                }
                else
                {
                    cmnuChuanBiGiay.Enabled = true;
                    btnSuaGiayIn.Enabled = false;
                }
            }
            else
            {
                cmnuGanCauHinhSP.Enabled = true;
                btnSuaCauHinhSP.Enabled = false;
            }
            
        }
        private void KhoaMoControlsSoLuongKichThuoc(bool khoa)
        {
            if (khoa)
            {
                txtSoLuong.Enabled = false;
                txtKhoCatCao.Enabled = false;
                txtKhoCatRong.Enabled = false;
                txtDonVi.Enabled = false;
                btnLayKichThuocSP.Enabled = false;
            } else
            {
                txtSoLuong.Enabled = true;
                txtKhoCatCao.Enabled = true;
                txtKhoCatRong.Enabled = true;
                txtDonVi.Enabled = true;
                btnLayKichThuocSP.Enabled = true;
            }
        }
        private void LamLai()
        {
            KhoaMoControlsSoLuongKichThuoc(false);
            //
            this.SanPhamRong = 21;
            this.SanPhamCao = 29.7f;
            this.SoLuong = 10;
            //bài in
            XoaCauHinhSP();
            XoaGiay();
            XoaBaiInSach();
            XoaThanhPhamSach();
            btnLayKichThuocSP.Focus();
            //bật nút nhận
            BatNutNhan();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            LamLai();                       
        }

        private void InToForm_Resize(object sender, EventArgs e)
        {
            //
            tabCtrl01.Width = spcChiTietBaiIn.Panel2.Width / 3 * 2;
            tabCtrl01.Left = spcChiTietBaiIn.Panel2.Left + 1;
            txtTomTatBaiIn.Width = spcChiTietBaiIn.Panel2.Width / 3 * 1;
            txtTomTatBaiIn.Left = tabCtrl01.Left + tabCtrl01.Width + 1;
            lblTomTatBaiIn.Left = txtTomTatBaiIn.Left;
            btnCopyToClipBoardNoiDungMucChon.Left = txtTomTatBaiIn.Left + 
                (txtTomTatBaiIn.Width - btnCopyToClipBoardNoiDungMucChon.Width) -2;
            //
            lblThongTinCanhBaoNutNhan.Left = trvMucLucBaiIn.Left + trvMucLucBaiIn.Width + 2;
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

       
    }
}
