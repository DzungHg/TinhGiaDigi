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
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInClient
{
    public partial class ClientMainForm : Form
    {
        /*QuoteBrowseForm frmQuoteFormBrowse;
        PaperCateManForm frmPaperCateManage;
        PaperManForm frmPaperManage;
         */
        public static string AppPath { get; set; }
        
        public ClientMainForm()
        {
            InitializeComponent();
            AppPath = AppDomain.CurrentDomain.BaseDirectory;

        }
        LietKeTinhGiaForm frmLietKeTinhGia;
        private void mnuQuote_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuView_QuoteBrowser_Click(object sender, EventArgs e)
        {
            if (frmLietKeTinhGia == null)
            {
                frmLietKeTinhGia = new LietKeTinhGiaForm();
                frmLietKeTinhGia.KieuSapXep = SapXepTinhGiaS.Khong;
                frmLietKeTinhGia.FormClosed += new FormClosedEventHandler(ByByWindows);
                frmLietKeTinhGia.MdiParent = this;
                frmLietKeTinhGia.Show();
               
            }
            else frmLietKeTinhGia.Focus();
            
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            
        }

        

        
      
        private bool IsAdmin()
        {
            return true;
            /*
            bool loggedIn = false;

            //1. Khởi động log in:
            LogInForm frm = new LogInForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                if (frm.LoginSucceeded)
                    loggedIn = true;
                else loggedIn = false;               
            //--
            frm.Dispose();
             
            return loggedIn;
             */

        }
        private void mnuSettingFC_Printer_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                return;
            }
            /*
            DigiPrinterManForm frm = new DigiPrinterManForm();

            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Danh sách máy in";
            frm.ButtonOKText = "Đóng";
            frm.ShowDialog();
            frm.Dispose();
             */
        }

        private void mnuSettingFC_StdProdSize_Click(object sender, EventArgs e)
        {
           /* StdProdSizeManForm frm = new StdProdSizeManForm();

            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Danh sách khổ chuẩn";
            frm.OKButtonText = "Đóng";
            frm.ShowDialog();
            frm.Dispose();
            */
        }

        private void mnuSettingFC_Laminating_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                return;
            }
          /*  PostPressManForm frm = new PostPressManForm();

            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Thiết đặt sau in";
            frm.ShowDialog();
            frm.Dispose();
           */
        }

        private void mnuSettingFC_PrePress_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                return;
            }
         /*   PrePressBHRForm frm = new PrePressBHRForm();

            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Điều chỉnh BHR Trước in";
            frm.FormState = (int)Ennums.FormState.Edit;
            frm.ShowDialog();
            frm.Dispose();
          */
        }

      

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuWindows_Cascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);

        }

        private void mnuWindows_TileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuWindows_TileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuWindows_MiniAll_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.WindowState = FormWindowState.Minimized;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }
        private void ByByWindows(object sender, FormClosedEventArgs e)
        {
           Form frm;
            if (sender is Form)
            {
                frm = (Form)sender;
                if (frm == frmLietKeTinhGia)
                    frmLietKeTinhGia = null;
            }
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void mnuQuote_Booklet_Click(object sender, EventArgs e)
        {
           /* BookCostEstForm frm = new BookCostEstForm();
            frm.Show();
            */
        }

        private void mnuSettingFC_BookBinding_Click(object sender, EventArgs e)
        {
            
            if (!IsAdmin())
            {
                return;
            } 
           /* BindingSettingForm frm = new BindingSettingForm();

            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Thiết đặt Đóng cuốn";
            frm.ShowDialog();
            frm.Dispose();
            */
        }

        private void mnuSettingFC_ProdSize_Click(object sender, EventArgs e)
        {
           /* ProductSizeManForm frm = new ProductSizeManForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.FormState = (int)Ennums.FormState.View;
            frm.Text = "Khổ sản phẩm ";
            frm.ShowDialog();
            */

        }

        private void mnuFlatProdEst_Click(object sender, EventArgs e)
        {
            ThemTinhGia(this);
        }
        public void ThemTinhGia(ClientMainForm parentMDIForm)
        {
            var thongTinBanDau = new ThongTinBanDauChoTinhGia();
            thongTinBanDau.TenNguoiDung = "";
            thongTinBanDau.TinhTrangForm = FormStateS.New;

            this.WindowState = FormWindowState.Maximized;
            var frm = new TinhGiaForm(thongTinBanDau);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.MdiParent = parentMDIForm;
            //frm.FormState = (int)Ennums.FormState.New;
            frm.Text = "Tính giá sản phẩm";
            frm.Show();
        }
        private void mnuBookProdEst_Click(object sender, EventArgs e)
        {
          /*  BookCostEstForm frm = new BookCostEstForm();
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.MdiParent = this;
            //frm.FormState = (int)EnFormState.New;
            frm.Text = "Sản phẩm Cuốn";
            frm.Show();
           */
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuAbout_SW_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog();
        }

        private void mnuAbout_QickPrintMarketInfo_Click(object sender, EventArgs e)
        {
            string my_app = AppPath + "\\AddOns\\MarketQuickPrintPrices.exe";
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = my_app;
            pProcess.Start();
            //pProcess.WaitForExit();
            //pProcess.Close();
        }

        private void mnuBangGiaGiay_Click(object sender, EventArgs e)
        {
            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.View);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
        }
        
    }
}
