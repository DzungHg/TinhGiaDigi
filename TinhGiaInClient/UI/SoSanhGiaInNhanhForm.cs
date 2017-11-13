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
using TinhGiaInClient.Common;

namespace TinhGiaInClient.UI
{
    public partial class SoSanhGiaInNhanhForm : Form, IViewSoSanhGiaInNhanh
    {
        SoSanhGiaInNhanhPresenter soSanhGiaInPres;
        public SoSanhGiaInNhanhForm()
        {
            InitializeComponent();
            //
         
            soSanhGiaInPres = new SoSanhGiaInNhanhPresenter(this);
            //
            this.TenNhaInA = "Nhà in A";
            this.TenNhaInB = "Nhà in B";
            //
            this.DaySoLuongTrangA4 = Global.cDaySoLuongA4TinhThu;
            //Nạp bảng giá vô combo
            LoadNiemYetGia();
            //
            
            //events;
            txtDayTrangA4.Leave += new EventHandler(TextBoxes_Leave);
                    
            cboNiemYetGiaA.SelectedIndexChanged += new EventHandler(Combos_SelectedIndexChanged);
            cboNiemYetGiaB.SelectedIndexChanged += new EventHandler(Combos_SelectedIndexChanged);
            
        }
        #region implement Iview
        public string TenNhaInA
        {
            get
            {
                return txtTenNhaInA.Text;
            }
            set
            {
                txtTenNhaInA.Text = value;
            }
        }

        public string TenNhaInB
        {
            get
            {
                return txtTenNhaInB.Text;
            }
            set
            {
                txtTenNhaInB.Text = value;
            }
        }
        int _idNiemYetA = 0;
        public int IdNiemYetChonA
        {
            get
            {
                if (cboNiemYetGiaA.SelectedValue != null)
                    int.TryParse(cboNiemYetGiaA.SelectedValue.ToString(),
                        out _idNiemYetA);
                return _idNiemYetA;
            }
            set { cboNiemYetGiaA.SelectedValue = value; }
        }

        int _idNiemYetB = 0;
        public int IdNiemYetChonB
        {
            get
            {
                if (cboNiemYetGiaB.SelectedValue != null)
                    int.TryParse(cboNiemYetGiaB.SelectedValue.ToString(),
                        out _idNiemYetB);
                return _idNiemYetB;
            }
            set { cboNiemYetGiaB.SelectedValue = value; }
        }
        public string DienGiaiNiemYetA 
        {
            get { return txtDienGiaiNYGiaA.Text; }
            set { txtDienGiaiNYGiaA.Text = value; }
        }
        public string DienGiaiNiemYetB
        {
            get { return txtDienGiaiNYGiaB.Text; }
            set { txtDienGiaiNYGiaB.Text = value; }
        }
        public string LoaiBangGiaNiemYetA
        {
            get { return lblTenLoaiBangGiaA.Text; }
            set { lblTenLoaiBangGiaA.Text = value; }
        }
        public string LoaiBangGiaNiemYetB
        {
            get { return lblTenLoaiBangGiaB.Text; }
            set { lblTenLoaiBangGiaB.Text = value; }
        }



        public string DaySoLuongTrangA4
        {
            get { return txtDayTrangA4.Text; }
            set { txtDayTrangA4.Text = value; }
        }
       

        #endregion
        int chieuRongHienBanDauCuaClient = 0;
        private bool LoadNiemYetGia()
        {
            var kq = true;
            if (soSanhGiaInPres.NiemYetGiaInNhanhA().Count > 0)
            {
                cboNiemYetGiaA.DataSource = soSanhGiaInPres.NiemYetGiaInNhanhA();
                cboNiemYetGiaA.DisplayMember = "Ten";
                cboNiemYetGiaA.ValueMember = "ID";
                //B
                cboNiemYetGiaB.DataSource = soSanhGiaInPres.NiemYetGiaInNhanhB();
                cboNiemYetGiaB.DisplayMember = "Ten";
                cboNiemYetGiaB.ValueMember = "ID";

            }
            else kq = false;
            
            return kq;
        }
      
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
         
        }
        private void GiaInForm_Load(object sender, EventArgs e)
        {
            
          
     
                cboNiemYetGiaA.SelectedIndex = -1;
                cboNiemYetGiaA.SelectedIndex = 0; //có lỗi khi không có dữ liệu
                cboNiemYetGiaB.SelectedIndex = -1;
                cboNiemYetGiaB.SelectedIndex = 0; //có lỗi khi không có dữ liệu

                this.chieuRongHienBanDauCuaClient = ClientSize.Width;
        }
       
        private void TrinhBayBangGiaA()
        {
            

            //MessageBox.Show(PrintPriceCalc.TrinhBayBangGiaKhoang(this.KhoangSoLuong, this.KhoangGia).Count().ToString());
            lvwTrinhBayBangGiaA.View = System.Windows.Forms.View.Details;
            lvwTrinhBayBangGiaA.Clear();
            lvwTrinhBayBangGiaA.Columns.Add("Số lượng");
            lvwTrinhBayBangGiaA.Columns.Add("Giá/Trang");
            ListViewItem item;
            if (soSanhGiaInPres.TrinhBayBangGia(this.LoaiBangGiaNiemYetA, this.IdNiemYetChonA) != null )
            {
                foreach (KeyValuePair<string, string> kvp in
                    soSanhGiaInPres.TrinhBayBangGia(this.LoaiBangGiaNiemYetA, this.IdNiemYetChonA))
                {
                    item = new ListViewItem(kvp.Key);
                    item.SubItems.Add(kvp.Value);
                    lvwTrinhBayBangGiaA.Items.Add(item);
                }
            }
            lvwTrinhBayBangGiaA.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void TrinhBayBangGiaB()
        {

            lvwTrinhBayBangGiaB.View = System.Windows.Forms.View.Details;
            lvwTrinhBayBangGiaB.Clear();
            lvwTrinhBayBangGiaB.Columns.Add("Số lượng");
            lvwTrinhBayBangGiaB.Columns.Add("Giá");
            ListViewItem item;
            if (soSanhGiaInPres.TrinhBayBangGia(this.LoaiBangGiaNiemYetB, this.IdNiemYetChonB) != null)
            {
                foreach (KeyValuePair<string, string> kvp in
                    soSanhGiaInPres.TrinhBayBangGia(this.LoaiBangGiaNiemYetB, this.IdNiemYetChonB))
                {
                    item = new ListViewItem(kvp.Key);
                    item.SubItems.Add(kvp.Value);
                    lvwTrinhBayBangGiaB.Items.Add(item);
                }
            }
            lvwTrinhBayBangGiaB.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }
        private void TrinhBayKetQuaTinh()
        {

            
            lvwKetQua.View = System.Windows.Forms.View.Details;
            lvwKetQua.Clear();
            lvwKetQua.Columns.Add("STT");
            lvwKetQua.Columns.Add("SL A4");
            lvwKetQua.Columns.Add(this.TenNhaInA);
            lvwKetQua.Columns.Add(this.TenNhaInB);
            ListViewItem item;
            if (soSanhGiaInPres.TrinhBayKetQua().Count > 0)
            {
                foreach (KeyValuePair<int, List<string>> kvp in
                    soSanhGiaInPres.TrinhBayKetQua())
                {
                    item = new ListViewItem(kvp.Key.ToString());
                    item.SubItems.AddRange(kvp.Value.ToArray());
                    lvwKetQua.Items.Add(item);
                }
            }
            lvwKetQua.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }
        private void Combos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb;
            if (sender is ComboBox)
            {
                cb = (ComboBox)sender;
                soSanhGiaInPres.TrinhBayChiTietNiemYet();
                if (cb == cboNiemYetGiaA)
                {
                    
                    TrinhBayBangGiaA();
                }
                if (cb == cboNiemYetGiaB)
                {                    
                    
                    TrinhBayBangGiaB();
                }
            }
        }
        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                
                if (tb == txtDayTrangA4)
                {
                    if (string.IsNullOrEmpty(txtDayTrangA4.Text.Trim()))
                        this.DaySoLuongTrangA4 = "50;100";
                    
                }
                
            }
        }
       
        private void GiaInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void cboBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TrinhBayKetQuaTinh();
        }

        private void SoSanhGiaInNhanhForm_Resize(object sender, EventArgs e)
        {
           
            var chieuRongGianNoCuaClient = ClientSize.Width - this.chieuRongHienBanDauCuaClient;
            //Dãn lvw
            lvwKetQua.Width += chieuRongGianNoCuaClient - 10;
        }

        private string LayChuoiKetQua()
        {
            var kq = "";
            
            if (lvwKetQua.Items.Count <= 0)
                return "";
            //Tính
            //Lấy cột
            for (int i = 0; i < lvwKetQua.Columns.Count; i++)
            {
                kq += lvwKetQua.Columns[i].Text + "\t";
            }
            kq += "\r" + "\n";
            var strB = new StringBuilder();
            strB.Append(kq);
            var str2 = "";
            var str3 = "";
            //Lấy hàng
            foreach (ListViewItem item in lvwKetQua.Items)
            {
                str2 = item.Text + "\t";
                for (int i = 1; i < item.SubItems.Count; i++ )
                {
                    str3 += item.SubItems[i].Text + "\t";
                    
                }
                //nối 2 và 3
                //MessageBox.Show(str3);
                //break;
                str2 += str3 + "\r" + "\n";
                
                strB.Append(str2);
                str3 = "";
                str2 = "";
                //kq += str2;
            }
            kq = strB.ToString();
            return kq;
        }
        private string XayDungBangGia(ListView listView)
        {
            var kq = "";

            if (listView.Items.Count <= 0)
                return "";
            //Tính
            //Lấy cột
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                kq += listView.Columns[i].Text + "\t";
            }
            kq += "\r" + "\n";
            var strB = new StringBuilder();
            strB.Append(kq);
            var str2 = "";
            var str3 = "";
            //Lấy hàng
            foreach (ListViewItem item in listView.Items)
            {
                str2 = item.Text + "\t";
                for (int i = 1; i < item.SubItems.Count; i++)
                {
                    str3 += item.SubItems[i].Text + "\t";

                }
                //nối 2 và 3
                //MessageBox.Show(str3);
                //break;
                str2 += str3 + "\r" + "\n";

                strB.Append(str2);
                str3 = "";
                str2 = "";
                //kq += str2;
            }
            kq = strB.ToString();
            return kq;
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.LayChuoiKetQua()))
                Clipboard.SetText(this.LayChuoiKetQua());
        }

        private void btnCopyBangGiaA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.XayDungBangGia(lvwTrinhBayBangGiaA)))
                Clipboard.SetText(this.XayDungBangGia(lvwTrinhBayBangGiaA));
        }

        private void btnCopyBangGiaB_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.XayDungBangGia(lvwTrinhBayBangGiaB)))
                Clipboard.SetText(this.XayDungBangGia(lvwTrinhBayBangGiaB));
        }







       
    }
}
