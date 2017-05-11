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
        public TinhGiaForm(ThongTinBanDauChoTinhGia thongTinBanDau)
        {
            InitializeComponent();
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.TenNhanVien = thongTinBanDau.TenNguoiDung;
            tinhGiaPres = new TinhGiaPresenter(this);
            tinhGiaPres.NoiDungBanDau();
            LoadHangKhachHang();
            cboHangKH.SelectedIndex = 0;

            
            //event
            this.FormClosing += new FormClosingEventHandler(Forms_FormClosing);

            lvwBaiIn.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            lvwDanhThiep.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            txtTieuDeTinhGia.TextChanged += new EventHandler(TextBoxe_TextChanged);
            txtTenNV.TextChanged += new EventHandler(TextBoxe_TextChanged);
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
        
     
        public string TenNhanVien
        {
            get { return txtTenNV.Text; }
            set { txtTenNV.Text = value; }
        }
        public FormStates TinhTrangForm { get; set; }
      
        public string TomTatChaoKH
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
        private void txtCustName_TextChanged(object sender, EventArgs e)
        {

        }
       
        

        private void TinhGiaForm_Load(object sender, EventArgs e)
        {            
            TrinhBayListView();
            MakeFormChange(false);
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
                TinhTrangForm = FormStates.New,
                YeuCauTinhGia = ""
            };

            var frm = new BaiInForm(thongTinChoBaiIn);
            
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
        private void XuLyNutOKTrenFormBaiIn_Click(BaiInForm frm)
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
                case FormStates.Edit:
                case FormStates.New:
                    tinhGiaPres.Them_BaiIn(frm.DocKetQuaBaiIn());
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
                TinhTrangForm = FormStates.New
            };


            var frm = new GiaInDanhThiepForm(thongTinBanDau);
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
                case FormStates.Edit:
                case FormStates.New:
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
                   break;

           }
               

       }

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
           }
       }
       
       

       private void lvwBaiIn_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadChiTietBaiInTheoIdBaiIn();
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
           }
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
                   case FormStates.New:
                       MessageBox.Show(tinhGiaPres.ThemTinhGia());

                       break;
                   case FormStates.Edit:
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
           tinhGiaPres.XoaTatCa_BaiIn();
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
           TextBox tb;
           if (sender is TextBox)
           {
               tb = (TextBox)sender;
               if (tb == txtTenNV || tb == txtTieuDeTinhGia )
               {
                   MakeFormChange(true);
               }
           }
           DateTimePicker dtp;
           if (sender is DateTimePicker)
           {
               dtp = (DateTimePicker)sender;
               if (dtp == dtpNgay)
               {
                   MakeFormChange(true);
               }
           }
       }
       
    }
}
