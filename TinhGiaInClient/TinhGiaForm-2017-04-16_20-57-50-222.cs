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
      
        #endregion
        Dictionary<int,TabPage> tabList = new Dictionary<int,TabPage>();
        private void txtCustName_TextChanged(object sender, EventArgs e)
        {

        }
       
        

        private void TinhGiaForm_Load(object sender, EventArgs e)
        {            
            TrinhBayListView();
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
                tinhGiaPres.Xoa_BaiIn(tinhGiaPres.DocBaiInTheoID(this.IdBaiInChon));
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
                    tinhGiaPres.Them_BaiIn(baiIn);
                    break;
                case (int)Enumss.FormState.Edit:
                    //Cập nhật lại ID bài in /do tự động +1 khi new
                    baiIn.ID = frm.ID;
                    //Cập nhật lại
                    tinhGiaPres.Sua_BaiIn(baiIn);
                    break;
            }
        }
        private void LoadChiTietBaiInTheoIdBaiIn()//theo Id bài in chọn
        {
            ;
        }
        #endregion
        
     
       
       private void btnThemBaiIn_Click(object sender, EventArgs e)
       {
           switch (tabCtrl01.SelectedIndex)
           {
               case 0:
                   break;
               case 1:
                   ThemBaiIn();
                   break;

           }
               

       }

       private void btnSuaBaiIn_Click(object sender, EventArgs e)
       {
           SuaBaiIn();
       }

       private void btnXoaBaiIn_Click(object sender, EventArgs e)
       {
           XoaBaiIn();
       }

       

      

     


       

       private void lvwBaiIn_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadChiTietBaiInTheoIdBaiIn();
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
           tinhGiaPres.XoaTatCa_BaiIn();
       }

       private void btnNoiDungTinhGia_Click(object sender, EventArgs e)
       {
           Clipboard.SetText( tinhGiaPres.TrinhBayNoiDungBaiIn());
       }

       private void tabCtrl01_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

  
    }
}
