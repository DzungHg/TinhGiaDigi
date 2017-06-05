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

namespace TinhGiaInClient
{
    public partial class BaiInForm : Form, IViewBaiIn
    {
       
       
        public BaiInForm(ThongTinBanDauChoBaiIn thongTinBanDau,  int idBaiIn = 0)
        {
            InitializeComponent();
            //Chú ý theo thứ tự
            baiInPres = new BaiInPresenter(this);
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.IdHangKhachHang = thongTinBanDau.IdHangKhachHang;
            this.TenHangKhachHang = thongTinBanDau.TenHangKhachHang;
           
            this.ID = idBaiIn;
            
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

            txtCauHinhSP.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtGiayDeIn.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtDonVi.TextChanged += new EventHandler(TextBoxes_TextChanged);
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
        int _idHangKH;
        public int IdHangKhachHang
        {
            get { return _idHangKH; }
            set
            {
                _idHangKH = value;
                this.TenHangKhachHang = baiInPres.TenHangKhachHang();
            }
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
        public BaiIn DocKetQuaBaiIn()
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
            }
        }

        
        private void BaiInForm_Load(object sender, EventArgs e)
        {
            
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
            var frm = new CauHinhSPForm(thongTinCauHinhBanDau(baiIn, FormStateS.New), cauHinhSP);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
          
           
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormTrienKhaiSP_Click(frm);
                
            }

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


            }
        }
        private void btnSuaCauHinhSP_Click(object sender, EventArgs e)
        {
            SuaCauHinhSP();


        }
        private void btnXoaCauHinhSP_Click(object sender, EventArgs e)
        {
            baiInPres.XoaCauHinhSanPham();
            this.TomTatCauHinhSP = baiInPres.TomTatCauHinhSP();
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
                    //Bắt đàu xóa
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
          
            var mucGiayDeIn = new GiayDeIn(32, 47, 1, 1, 1,
                1, false, 0, "", baiIn.ID, 1, 1, 0);//
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
                
            }

        }
        private ThongTinBanDauChoGiayIn thongTinBanDauChoGiayIn(BaiIn baiIn, FormStateS tinhTrangForm)
        {
            var thongTinBanDau = new ThongTinBanDauChoGiayIn();
            thongTinBanDau.IdToIn_MayInChon = baiIn.CauHinhSP.IdMayIn;
            thongTinBanDau.PhuongPhapIn = baiIn.CauHinhSP.PhuongPhapIn;
            thongTinBanDau.IdHangKhachHang = baiIn.IdHangKH;
            thongTinBanDau.TinhTrangForm = tinhTrangForm;
            thongTinBanDau.SoLuongSanPham = baiIn.SoLuong;
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
               
            }


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

                    }
                    break;

            }
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
        
        private ThongTinBanDauChoThanhPham thongTinBanDauChoThanhPham(int idBaiIn, int idHangKH, int soLuongSP, string donViTinh,
            int soToChay, LoaiThanhPhamS loaiThPh,
                string thongDiepThem, FormStateS tinhTrangForm, string tieuDeForm )
        {
            var thongTinBanDau = new ThongTinBanDauChoThanhPham ();
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
                case LoaiThanhPhamS.CanPhu:
                    var thongDiep1 = string.Format("Số tờ chạy: {0} / Khổ: {1}",
                       baiIn.GiayDeInIn.SoToChayTong, baiIn.GiayDeInIn.KhoToChay);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep1;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Cán phủ";
                    thongTinBanDauThPh.LoaiThanhPham = LoaiThanhPhamS.CanPhu;
                    //Mục thành phẩm cán phủ
                    var mucThPhCanPhu = new MucThPhCanPhu();
                    mucThPhCanPhu.IdBaiIn = baiIn.ID;
                    mucThPhCanPhu.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhCanPhu.LoaiThanhPham = LoaiThanhPhamS.CanPhu;
                    mucThPhCanPhu.SoLuong = baiIn.GiayDeInIn.SoToChayTong;
                    mucThPhCanPhu.DonViTinh = "mặt";
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
                case LoaiThanhPhamS.DongCuon:
                    var thongDiep3 = string.Format("Số lượng {0} {1}",
                        baiIn.SoLuong, baiIn.DonVi);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep3;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Đóng cuốn";
                   
                    //tạo mục thành phẩm đóng cuốn
                    var mucThPhamDongCuon = new MucThanhPham();
                    mucThPhamDongCuon.IdBaiIn = baiIn.ID;
                    mucThPhamDongCuon.IdHangKhachHang = baiIn.IdHangKH;
                    mucThPhamDongCuon.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
                    mucThPhamDongCuon.SoLuong = 1; //Cần xác định sau
                    mucThPhamDongCuon.DonViTinh = "cuốn";
                   
                    var frm3 = new ThPhDongCuonForm(thongTinBanDauThPh, mucThPhamDongCuon);

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
                case LoaiThanhPhamS.EpKim:
                    var thongDiep4 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
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
                case LoaiThanhPhamS.GiaCongNgoai:
                    var thongDiep5 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
                       baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep5;
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
                    var frm5 = new ThPhGiaCongNgoaiForm(thongTinBanDauThPh, mucGiaCongNgoai);

                    frm5.MinimizeBox = false;
                    frm5.MaximizeBox = false;
                    frm5.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm5.IdBaiIn = baiIn.ID;
                    frm5.IdHangKhachHang = baiIn.IdHangKH;
                    frm5.ShowDialog();
                    if (frm5.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormThPhamKhac(frm5);
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
                case LoaiThanhPhamS.DongCuon:
                    if (mucThPh is MucDongCuonLoXo)
                    {
                        var thongTinBanDauLoXo = new ThongTinBanDauDongCuon();
                        thongTinBanDauLoXo.ThongDiepCanThiet = string.Format("Số lượng {0} {1}",
                        baiIn.SoLuong, baiIn.DonVi);
                        thongTinBanDauLoXo.TieuDeForm = "[Sửa] Đóng cuốn Lò xo";
                        thongTinBanDauLoXo.TinhTrangForm = FormStateS.Edit;
                        
                        //
                        var frm6 = new ThPhDongCuonLoXoForm(thongTinBanDauLoXo, (MucDongCuonLoXo)mucThPh);

                        frm6.MinimizeBox = false;
                        frm6.MaximizeBox = false;
                        frm6.StartPosition = FormStartPosition.CenterParent;

                        frm6.ShowDialog();
                        if (frm6.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            XuLyNutOKClick_FormDongCuonLoXo(frm6);
                            LoadThanhPhamLenListView();
                        }
                    }
                    else //Các kiểu đóng cuốn còn lại
                    {
                        var thongDiep3 = string.Format("Số lượng {0} {1}",
                            baiIn.SoLuong, baiIn.DonVi);
                        thongTinBanDauThPh.ThongDiepCanThiet = thongDiep3;
                        thongTinBanDauThPh.TieuDeForm = "[Sửa] Đóng cuốn";

                        var frm3 = new ThPhDongCuonForm(thongTinBanDauThPh, mucThPh);

                        frm3.MinimizeBox = false;
                        frm3.MaximizeBox = false;
                        frm3.StartPosition = FormStartPosition.CenterParent;

                        frm3.ShowDialog();
                        if (frm3.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            XuLyNutOKClick_FormDongCuon(frm3);
                            //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                            LoadThanhPhamLenListView();
                            //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                        }
                    }
                    break;

                case LoaiThanhPhamS.EpKim:
                    var thongDiep4 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
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

                case LoaiThanhPhamS.GiaCongNgoai:
                    var thongDiep5 = string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep5;
                    thongTinBanDauThPh.TieuDeForm = "[Sửa]";
                    //Mục thành phẩm riêng
                    var mucThPhKhac = (MucThPhGiaCongNgoai) baiIn.DocThanhPhamTheoID(this.IdThanhPhamChon);

                    var frm5 = new ThPhGiaCongNgoaiForm(thongTinBanDauThPh, mucThPhKhac);

                    frm5.MinimizeBox = false;
                    frm5.MaximizeBox = false;
                    frm5.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua form                   

                    frm5.ShowDialog();
                    if (frm5.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormThPhamKhac(frm5);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
            }

        }
       
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
        #region Cấn gấp
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
        #endregion
        #region Đóng cuốn
        private void XuLyNutOKClick_FormDongCuon(ThPhDongCuonForm frm)
        {
           
            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    //Add
                 
                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không cần
                    frm.LayMucThanhPham();
                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
        #region Riêng về Đóng cuốn Loxo hoặc...
        
        private void ThemDongCuon(int idBaiIn, KieuDongCuonS kieuDongCuon)
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
            var thongTinBanDauThPh = new ThongTinBanDauDongCuon();
            var mucDongCuon = new MucDongCuonLoXo();
            mucDongCuon.IdBaiIn = baiIn.ID;
            mucDongCuon.IdHangKhachHang = baiIn.IdHangKH;
            mucDongCuon.SoLuong = 10; //Vì số lượng có thể không trùng
            mucDongCuon.DonViTinh = "cuốn";
            mucDongCuon.GayCao = 10;
            mucDongCuon.GayDay = 0.5f;
            mucDongCuon.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
           
            //Tiến hành gắn
            switch (kieuDongCuon)
            {
                
                case KieuDongCuonS.LoXo:
                    var thongDiep = string.Format("Số lượng {0} {1}",
                        baiIn.SoLuong, baiIn.DonVi);
                    thongTinBanDauThPh.ThongDiepCanThiet = thongDiep;
                    thongTinBanDauThPh.TieuDeForm = "[Mới] Cuốn Lò xo";                  
                    thongTinBanDauThPh.TinhTrangForm = FormStateS.New;
                    //điều chỉnh mục thành phẩm
                    mucDongCuon.KieuDongCuon = KieuDongCuonS.LoXo;
                    var frm = new ThPhDongCuonLoXoForm(thongTinBanDauThPh, mucDongCuon);

                    frm.MinimizeBox = false;
                    frm.MaximizeBox = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormDongCuonLoXo(frm);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                
            }
        }
      
      
        private void XuLyNutOKClick_FormDongCuonLoXo(ThPhDongCuonLoXoForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:                    
                    baiInPres.ThemThanhPham(frm.LayMucThanhPham());
                    break;
                case FormStateS.Edit:
                    //baiInPres.SuaThanhPham(frm.LayMucThanhPham());//Không cần
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

        private void btnSuaGiayIn_Click_1(object sender, EventArgs e)
        {
            SuaGiayIn();

        }

        private void btnXoaGiayDeIn_Click(object sender, EventArgs e)
        {
            if (this.ID > 0)
            {
                baiInPres.XoaGiayDeIn();
                this.TomTatGiayDeIn = baiInPres.TomTatGiayDeIn();
            }
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();        
        }

      

   

        private void btnXoaHetBaiInNhanh_Click(object sender, EventArgs e)
        {
            baiInPres.XoaHetGiaIn();
            //Cập nhật lại listview
            LoadGiaInLenListView();
            //

            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();       
            
        }

      

        private void btnXoaThanhPham_Click(object sender, EventArgs e)
        {
            baiInPres.XoaThanhPham(baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon));
            //Cần cập nhật lại listview Bài in
            LoadThanhPhamLenListView();
             //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();        
        }

        private void btnXoaHetThanhPham_Click(object sender, EventArgs e)
        {
            baiInPres.XoaHetThanhPham();
            LoadThanhPhamLenListView();
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();        
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
        private void TextBoxes_TextChanged(object sender, EventArgs e)
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
                        txtSoLuong.Text = "1";
                if (tb == txtDonVi)
                    if (string.IsNullOrEmpty(txtDonVi.Text.Trim()))
                        txtDonVi.Text = "đv";
            }

        }

        private void btnCopyToClipBoardNoiDungMucChon_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTomTatBaiIn.Text))
                Clipboard.SetText(txtTomTatBaiIn.Text);
        }

        private void cmnuDongCuon_LoXo_Click(object sender, EventArgs e)
        {
            ThemDongCuon(this.ID, KieuDongCuonS.LoXo);
        }

       

    }
}
