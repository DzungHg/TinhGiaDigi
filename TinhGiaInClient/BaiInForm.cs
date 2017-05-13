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
    public partial class BaiInForm : Form, IViewBaiIn
    {
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
        public int SoLuong {
            get { return int.Parse(txtSoLuong.Text); }
            set { txtSoLuong.Text = value.ToString(); }
        }
        public string DonViTinh {
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
            set { _idHangKH = value;
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
            get { return baiInPres.TomTatNoiDungBaiIn_ChaoKH();}
            set { txtTomTatBaiIn.Lines = value.ToArray(); }
        }
        public BaiIn DocKetQuaBaiIn()
        {
            return baiInPres.DocBaiIn();
        }
        public FormStates TinhTrangForm { get; set; }
        #endregion
        BaiInPresenter baiInPres;
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
                case FormStates.Edit:
                case FormStates.New:
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


            //Khóa số txtSoluong khi sửa
            /*if (formState == (int)FormState.Edit)
                txtSoLuong.Enabled = false;
            else
                txtSoLuong.Enabled = true; 
             */
        }
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

        private void GanCauHinhVoBaiIn()
        {
           
               
            if (this.ID <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = baiInPres.DocBaiIn();
            var thongTinChoCauHinh = new ThongTinBanDauChoCauHinhSP();
            thongTinChoCauHinh.YeuCauBaiIn = baiIn.TieuDe + '\r' + '\n'
                + baiIn.DienGiai;
            thongTinChoCauHinh.SoLuongSanPham = baiIn.SoLuong;
            thongTinChoCauHinh.DonViTinh = baiIn.DonVi;
            thongTinChoCauHinh.TinhTrangForm = FormStates.New;
            if (baiIn.CoCauHinh) //Đã có cấu hình
                return;
            //Gắn
            var frm = new CauHinhSPForm(thongTinChoCauHinh);
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


            //Tiếp tục gắn thêm dữ liệu

            var thongTinChoCauHinh = new ThongTinBanDauChoCauHinhSP();
            thongTinChoCauHinh.YeuCauBaiIn = baiIn.TieuDe + '\r' + '\n'
                + baiIn.DienGiai;
            thongTinChoCauHinh.SoLuongSanPham = baiIn.SoLuong;
            thongTinChoCauHinh.DonViTinh = baiIn.DonVi;
            thongTinChoCauHinh.TinhTrangForm = FormStates.Edit;

            var frm = new CauHinhSPForm(thongTinChoCauHinh, baiIn.CauHinhSP);


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
           
        }

        private void XuLyNutOKTrenFormTrienKhaiSP_Click(CauHinhSPForm frm)
        {
            ///Cấu hình SP rất quan trọng
            ///Nếu mở form sửa xong nhấn OK thì  nếu có giấy, in, thành phẩm, v.v phải bị xóa hết
            ///

            switch (frm.TinhTrangForm)
            {
                case FormStates.New:
                    //Add
                    baiInPres.GanCHSPVoBaiIn(frm.DocCauHinhSanPham());
                    this.TomTatCauHinhSP = baiInPres.TomTatCauHinhSP();
                    break;
                case FormStates.Edit:
                    //cauHinhSP.IDCauHinh = frm.IdCauHinhSP;
                    baiInPres.CapNhatCHSPVoBaiIn(frm.DocCauHinhSanPham());
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
            var thongTinBanDau = new ThongTinBanDauChoGiayIn();
            thongTinBanDau.KhoMayIn = baiIn.CauHinhSP.KhoMayIn;
            thongTinBanDau.IdHangKhachHang = baiIn.IdHangKH;
            thongTinBanDau.TinhTrangForm = FormStates.New;
            thongTinBanDau.SoLuongSanPham = baiIn.SoLuong;
            thongTinBanDau.ThongTinCanThiet = baiIn.TieuDe + '\r' + '\n'
                 + baiIn.DienGiai + '\r' + '\n'
                 + string.Format(" *Số lượng: {0} {1}" + '\r' + '\n', baiIn.SoLuong, baiIn.DonVi)
                 + baiIn.DienGiai + '\r' + '\n'
                 + baiIn.CauHinhSP.TenPhuongPhapIn + '\r' + '\n'
                 + "--Khổ máy: " + baiIn.CauHinhSP.KhoMayIn + '\r' + '\n';
            //Tiến hành gắn
            var frm = new GiayDeInForm(thongTinBanDau, null);
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
        private void SuaGiayIn()
        {
            if (this.ID <= 0)
                return;
            //Tìm bài in, gắn vô với đk sp chưa có trong danh sách cấu hình
            var baiIn = baiInPres.DocBaiIn();

            var giayIn = baiInPres.LayGiayDeInTheoBaiIn();
            if (giayIn == null)
                return;

             var thongTinBanDau = new ThongTinBanDauChoGiayIn();
            thongTinBanDau.KhoMayIn = baiIn.CauHinhSP.KhoMayIn;
            thongTinBanDau.IdHangKhachHang = baiIn.IdHangKH;
            thongTinBanDau.TinhTrangForm = FormStates.New;
            thongTinBanDau.SoLuongSanPham = baiIn.SoLuong;
            thongTinBanDau.ThongTinCanThiet = baiIn.TieuDe + '\r' + '\n'
                 + baiIn.DienGiai + '\r' + '\n'
                 + string.Format(" *Số lượng: {0} {1}" + '\r' + '\n', baiIn.SoLuong, baiIn.DonVi)
                 + baiIn.DienGiai + '\r' + '\n'
                 + baiIn.CauHinhSP.TenPhuongPhapIn + '\r' + '\n'
                 + "--Khổ máy: " + baiIn.CauHinhSP.KhoMayIn + '\r' + '\n';
            var frm = new GiayDeInForm(thongTinBanDau, baiIn.GiayDeInIn);
                    
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
                case FormStates.New:
                    //Add                                   
                    baiInPres.GanGiayDeIn(frm.DocGiayDeIn());
                    this.TomTatGiayDeIn = baiInPres.TomTatGiayDeIn();
                    break;
                case FormStates.Edit:
                    baiInPres.CapNhatGiayDeIn(frm.DocGiayDeIn());
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
            if (baiIn.CauHinhSP.IdPhapIn == (int)Enumss.PhuongPhapIn.KhongIn) //Không in
            {
                MessageBox.Show("Bạn đã đặt Không In");
                return;
            }

            if (!baiIn.CoGiayIn)
            {
                MessageBox.Show("Chưa có giấy. Bạn phải cài giấy trước");
                return;
            }
            //Tiến hành gắn
            //Gắn giấy in
            var giayIn = baiInPres.LayGiayDeInTheoBaiIn();
            //Bắt đầu
            var thongTinBanDau = new ThongTinBanDauChoGiaIn();
            thongTinBanDau.TinhTrangForm = FormStates.New;
            thongTinBanDau.IdHangKhachHang = IdHangKhachHang;
            thongTinBanDau.IdBaiIn = baiIn.ID;
            thongTinBanDau.SoLuongToChay = giayIn.SoToChayTong;
            thongTinBanDau.IdToIn_MayIn = baiIn.CauHinhSP.IdMayIn;
            thongTinBanDau.ThongTinGiay = string.Format("{0}/{1}/{2}gm2", giayIn.KhoToChay,
                                 giayIn.TenGiayIn, giayIn.GiayChon.DinhLuong);
            thongTinBanDau.KhoToChay = baiIn.GiayDeInIn.KhoToChay;

            switch (baiIn.CauHinhSP.IdPhapIn)
            {
                case (int)Enumss.PhuongPhapIn.Toner:
                    var frmDigi = new GiaInNhanhForm(thongTinBanDau);
                    frmDigi.TinhTrangForm = FormStates.New;
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
                case (int)Enumss.PhuongPhapIn.KhongIn:
                    break;
                case (int)Enumss.PhuongPhapIn.Offset:                   
                    var frmOffset = new GiaInOffsetForm(thongTinBanDau);                 
                    frmOffset.TinhTrangForm = FormStates.New;
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

                if (baiIn.CauHinhSP.IdPhapIn == (int)Enumss.PhuongPhapIn.KhongIn) //Không in
                    return;

                //Gắn giấy in
                var giayIn = baiInPres.LayGiayDeInTheoBaiIn();
                var thongTinBanDau = new ThongTinBanDauChoGiaIn();
                thongTinBanDau.TinhTrangForm = FormStates.New;
                thongTinBanDau.IdBaiIn = baiIn.ID;
                thongTinBanDau.IdHangKhachHang = IdHangKhachHang;
                thongTinBanDau.SoLuongToChay = giayIn.SoToChayTong;
                thongTinBanDau.IdToIn_MayIn = baiIn.CauHinhSP.IdMayIn;
                thongTinBanDau.ThongTinGiay = string.Format("{0}/{1}/{2}gm2", giayIn.KhoToChay,
                                     giayIn.TenGiayIn, giayIn.GiayChon.DinhLuong);

                var frm = new GiaInNhanhForm(thongTinBanDau, giaIn);
                frm.TinhTrangForm = FormStates.Edit;
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
                case FormStates.New:
                    //Add
                    ; //Id tự tạo

                    baiInPres.ThemGiaIn(frm.DocGiaIn);

                    break;
                case FormStates.Edit:
                    //Tạo                     
                    baiInPres.SuaGiaIn(frm.DocGiaIn);

                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        private void XuLyNutOKTrenFormGiaInOffset_Click(GiaInOffsetForm frm)
        {
            
            switch (frm.TinhTrangForm)
            {
                case FormStates.New:
                    //Add
                    ; //Id tự tạo

                    baiInPres.ThemGiaIn(frm.DocGiaIn);

                    break;
                case FormStates.Edit:
                                                           
                    baiInPres.SuaGiaIn(frm.DocGiaIn);

                    break;
            }
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
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
                lvwThanhPham.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwThanhPham.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwThanhPham.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
               
               
            }
        }
        private void ThemThanhPham(int idBaiIn, LoaiThanhPham loaiThPh)
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
            //Tiến hành gắn
            switch (loaiThPh)
            {
                case LoaiThanhPham.CanPhu:
                    var frm = new ThPhCanPhuForm(string.Format("Số tờ giấy in {0} khổ: {1}",
                        baiIn.GiayDeInIn.SoToChayTong, baiIn.GiayDeInIn.KhoToChay));
                    frm.TinhTrangForm = (int)FormStates.New;
                    frm.LoaiThPh = loaiThPh;
                    frm.Text = "Cán Phủ [Mới]";
                    frm.MinimizeBox = false;
                    frm.MaximizeBox = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    //Data gởi qua ỏm
                    frm.IdBaiIn = baiIn.ID;
                    frm.IdHangKhachHang = baiIn.IdHangKH;
                    //Cần thông tin bổ sung lấy từ bài in và giấy                   
                    

                    frm.ShowDialog();
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        XuLyNutOKClick_FormCanPhu(frm);
                        //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());
                        LoadThanhPhamLenListView();
                        //Cập nhật lại danh sách bài in đã nằm trong LoadGiay

                    }
                    break;
                case LoaiThanhPham.CanGap:
                    var frm2 = new ThPhCanGapForm(string.Format("Số lượng SP: {0} / Số lượng tờ chạy: {1}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay));
                    frm2.TinhTrangForm = (int)FormStates.New;
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
                case LoaiThanhPham.DongCuon:
                    var frm3 = new ThPhDongCuonForm(string.Format("Số lượng {0} {1}",
                        baiIn.SoLuong, baiIn.DonVi));
                    frm3.TinhTrangForm = (int)FormStates.New;
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
                case LoaiThanhPham.EpKim:
                    var frm4 = new ThPhEpKimForm(string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
                        baiIn.SoLuong,  baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong));
                    frm4.TinhTrangForm = (int)FormStates.New;
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
            var mucThPh = baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
            var baiIn = baiInPres.DocBaiIn();
            var loaiThanhPham = mucThPh.LoaiThPh;
            switch (loaiThanhPham)
            {
                case LoaiThanhPham.CanPhu:
                    var frm1 = new ThPhCanPhuForm(string.Format("Số tờ giấy in {0} khổ: {1}",
                        baiIn.GiayDeInIn.SoToChayTong, baiIn.GiayDeInIn.KhoToChay));
                    frm1.TinhTrangForm = (int)FormStates.Edit;
                    frm1.LoaiThPh = LoaiThanhPham.CanPhu;
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
                    frm1.ThongTinHoTro = string.Format("Số tờ giấy in {0} khổ: {1}",
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
                case LoaiThanhPham.CanGap:
                    var frm2 = new ThPhCanGapForm(string.Format("Số lượng {0} / Số tờ chạy: {1}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.SoToChayTong));
                    frm2.TinhTrangForm = (int)FormStates.Edit;
                    frm2.LoaiThPh = LoaiThanhPham.CanGap;
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
                case LoaiThanhPham.DongCuon:
                    var frm3 = new ThPhDongCuonForm(string.Format("Số lượng {0} {1}",
                        baiIn.SoLuong, baiIn.DonVi));
                    frm3.TinhTrangForm = (int)FormStates.Edit;
                    frm3.LoaiThPh = LoaiThanhPham.DongCuon;
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

                case LoaiThanhPham.EpKim:
                    var frm4 = new ThPhEpKimForm(string.Format("Số lượng {0} / khổ tờ chạy: {1} / Khổ tờ chạy {2}",
                        baiIn.SoLuong, baiIn.GiayDeInIn.KhoToChay, baiIn.GiayDeInIn.SoToChayTong));
                    frm4.TinhTrangForm = (int)FormStates.Edit;
                    frm4.LoaiThPh = LoaiThanhPham.EpKim;
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
        private void XoaMucThanhPham(int idMucThanhPham)
        {
            baiInPres.XoaThanhPham(idMucThanhPham);
            //Cần cập nhật lại listview Bài in
        }
        private void XuLyNutOKClick_FormCanPhu(ThPhCanPhuForm frm)
        {

            var mucCanPhu = new MucThanhPham
            {
                IdBaiIn = frm.IdBaiIn,
                TenThPh = frm.TenThPhChon,
                TenThPhMoRong = frm.TenCanPhuMoRong,
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
                case (int)FormStates.New:
                    //Add                             
                    baiInPres.ThemThanhPham(mucCanPhu);
                    break;
                case (int)FormStates.Edit:
                    //Refer
                    mucCanPhu = baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
                    mucCanPhu.IdBaiIn = frm.IdBaiIn;
                    mucCanPhu.TenThPh = frm.TenThPhChon;
                    mucCanPhu.TenThPhMoRong = frm.TenCanPhuMoRong;
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
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
        #region Cấn gấp
        private void XuLyNutOKClick_FormCanGap(ThPhCanGapForm frm)
        {
            MucThanhPham mucThPh = null;
            switch (frm.TinhTrangForm)
            {
                case (int)FormStates.New:
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
                    baiInPres.ThemThanhPham(mucThPh);
                    break;
                case (int)FormStates.Edit:
                    //Tạo 
                    mucThPh = baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
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
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
        #region Đóng cuốn
        private void XuLyNutOKClick_FormDongCuon(ThPhDongCuonForm frm)
        {
            MucThanhPham mucThPh = null;
            switch (frm.TinhTrangForm)
            {
                case (int)FormStates.New:
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
                    baiInPres.ThemThanhPham(mucThPh);
                    break;
                case (int)FormStates.Edit:
                    //Tạo 
                    mucThPh = baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
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
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
        #region Ép kim
        private void XuLyNutOKClick_FormEpKim(ThPhEpKimForm frm)
        {
            MucThanhPham mucThPh = null;
            switch (frm.TinhTrangForm)
            {
                case (int)FormStates.New:
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
                    baiInPres.ThemThanhPham(mucThPh);
                    break;
                case (int)FormStates.Edit:
                    //Tạo 
                    mucThPh = baiInPres.LayThanhPhamTheoId(this.IdThanhPhamChon);
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
            //Cap nhat noi dung bai in
            txtTomTatBaiIn.Lines = baiInPres.TomTatNoiDungBaiIn_ChaoKH().ToArray();
        }
        #endregion
       

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
            ThemGiaIn();
        }

        private void btnSuaGiaInNhanh_Click(object sender, EventArgs e)
        {
            SuaGiaIn();
        }

        private void btnXoaGiaInNhanh_Click(object sender, EventArgs e)
        {
            if (this.ID > 0)
            {
                baiInPres.XoaGiaIn(this.IdGiaInChon);
                LoadGiaInLenListView();//Load lại
            }

        }

        private void cmnuThanhPham_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPham.CanPhu);
        }

        private void cmnuThPh_CanGap_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPham.CanGap);
        }

        private void cmnuThPh_DongCuon_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPham.DongCuon);
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

        }

      

   

        private void btnXoaHetBaiInNhanh_Click(object sender, EventArgs e)
        {
            baiInPres.XoaHetGiaIn();
        }

      

        private void btnXoaThanhPham_Click(object sender, EventArgs e)
        {
            baiInPres.XoaThanhPham(this.IdThanhPhamChon);
        }

        private void btnXoaHetThanhPham_Click(object sender, EventArgs e)
        {
            baiInPres.XoaHetThanhPham();
        }
        private void cmnuThPh_EpKim_Click(object sender, EventArgs e)
        {
            ThemThanhPham(this.ID, LoaiThanhPham.EpKim);
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
            }

        }

        private void btnCopyToClipBoardNoiDungMucChon_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtTomTatBaiIn.Text);
        }

    }
}
