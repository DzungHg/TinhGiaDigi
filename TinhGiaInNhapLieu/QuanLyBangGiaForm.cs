using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu
{
    public partial class QuanLyBangGiaForm : Telerik.WinControls.UI.RadForm, IViewQuanLyBangGia
    {
        public QuanLyBangGiaForm()
        {
            InitializeComponent();
            quanLyBGPres = new QuanLyBangGiaPresenter(this);
            //Event
            rdbLuyTien.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(RadRadioButtons_ToggleStateChanged);
            rdbBuoc.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(RadRadioButtons_ToggleStateChanged);
            rdbGoi.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(RadRadioButtons_ToggleStateChanged);

            //Giọi hàm

            LoadBangGia();
        }
        QuanLyBangGiaPresenter quanLyBGPres;

        #region emplement IVew
        int _idBangGiaChon;
        public int IdBangGiaChon
        {
            get
            {
                if (lstBangGia.SelectedItems.Count > 0)
                {
                    var item = (BangGiaBase)lstBangGia.SelectedItems[0].DataBoundItem;
                    _idBangGiaChon = item.ID;
                }
                return _idBangGiaChon;
            }
            set { _idBangGiaChon = value; }
        }

        public LoaiBangGiaS LoaiBangGia
        {
            get
            {
                if (rdbLuyTien.IsChecked)
                    return LoaiBangGiaS.LuyTien;
                else
                    if (rdbBuoc.IsChecked)
                        return LoaiBangGiaS.Buoc;
                    else
                        return LoaiBangGiaS.Goi;
            }
            set
            {
                switch (value)
                {
                    case LoaiBangGiaS.LuyTien:
                        rdbLuyTien.IsChecked = true;
                        break;
                    case LoaiBangGiaS.Buoc:
                        rdbBuoc.IsChecked = true;
                        break;
                    case LoaiBangGiaS.Goi:
                        rdbGoi.IsChecked = true;
                        break;
                }
            }
        }
        public int SoTrangTinhThu
        {
            get { return int.Parse(txtSoTrangTinhThu.Text);}
            set {txtSoTrangTinhThu.Text = value.ToString();}
        }
#endregion
        private void LoadBangGia()
        {
            lstBangGia.DataSource = null;
            lstBangGia.DataSource = quanLyBGPres.BangGiaTheoLoai();
            lstBangGia.DataMember = "ID";
            lstBangGia.DisplayMember = "Ten";
            lstBangGia.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
        }
        private void TrinhBayBangGia()
        {
            //MessageBox.Show(PrintPriceCalc.TrinhBayBangGiaKhoang(this.KhoangSoLuong, this.KhoangGia).Count().ToString());
            lstTrinhBayBG.View = System.Windows.Forms.View.Details;
            lstTrinhBayBG.Clear();
            lstTrinhBayBG.Columns.Add("Số lượng");
            lstTrinhBayBG.Columns.Add("Giá/Trang");
            ListViewItem item;
            if (quanLyBGPres.TrinhBayBangGia() != null)
            {
                foreach (KeyValuePair<string, string> kvp in
                    quanLyBGPres.TrinhBayBangGia())
                {
                    item = new ListViewItem(kvp.Key);
                    item.SubItems.Add(kvp.Value);
                    lstTrinhBayBG.Items.Add(item);
                }
            }
            lstTrinhBayBG.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void RadRadioButtons_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Telerik.WinControls.UI.RadRadioButton rdb;
            if (sender is Telerik.WinControls.UI.RadRadioButton)
            {
                rdb = (Telerik.WinControls.UI.RadRadioButton)sender;
                //Cập nhật
                LoadBangGia();
            }

        }

        private void lstBangGia_SelectedItemChanged(object sender, EventArgs e)
        {
            TrinhBayBangGia();
            txtCtrDienGiai.Text = quanLyBGPres.DienGiaiBangGia();
            //Clear tính thử
            lblTinhThu_TBA4.Text = "";
            lblTinhThu_TriGia.Text = "";
        }

        private void lstBangGia_ColumnCreating(object sender, Telerik.WinControls.UI.ListViewColumnCreatingEventArgs e)
        {
            
            if (e.Column.FieldName == "ID")
            {
                e.Column.HeaderText = "ID";
                e.Column.Width = 5;
                e.Column.MinWidth = 5;
            }
            if (e.Column.FieldName == "Ten")
            {
                e.Column.HeaderText = "Tên";
                e.Column.Width = 120;
                e.Column.MinWidth = 100;
            }
            if (e.Column.FieldName == "LoaiBangGia")
            {
                e.Column.HeaderText = "Loại";
                e.Column.Width = 80;
                e.Column.MinWidth = 80;
            }
            if (e.Column.FieldName == "DienGiai")
            {
                e.Column.HeaderText = "Diễn giải";
                e.Column.Width = 150;
                e.Column.MinWidth = 50;
            }
            if (e.Column.FieldName == "DaySoLuong")
            {
                e.Column.HeaderText = "Dãy số lượng";
                e.Column.Width = 120;
                e.Column.MinWidth = 120;
            }
            if (e.Column.FieldName == "DayGia")
            {
                e.Column.HeaderText = "Dãy giá";
                e.Column.Width = 120;
                e.Column.MinWidth = 120;
            }
            if (e.Column.FieldName == "DonViTinh")
            {
                e.Column.HeaderText = "ĐVT";
                e.Column.Width = 50;
                e.Column.MinWidth = 50;
            }
         
            if (e.Column.FieldName == "ThuTu")
            {
                e.Column.HeaderText = "Thứ tự";
                e.Column.Width = 10;
                e.Column.MinWidth = 10;
            }
            if (e.Column.FieldName == "KhongCon")
            {
                e.Column.HeaderText = "Không sử dụng";
                e.Column.Width = 10;
                e.Column.MinWidth = 10;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new BangGiaForm(quanLyBGPres.LoaiBanGiaStr(), FormStateS.New);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.Text = "[Thêm mới]";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                LoadBangGia();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.IdBangGiaChon <= 0)
                return;
            //
            var frm = new BangGiaForm(quanLyBGPres.LoaiBanGiaStr(), FormStateS.Edit, this.IdBangGiaChon);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.Text = "[Sửa]";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                LoadBangGia();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa thực thi");
        }

        private void btnTinhThu_Click(object sender, EventArgs e)
        {
            var message = "";
            lblTinhThu_TriGia.Text = string.Format("{0:0,0.00}đ", quanLyBGPres.TinhThuSoTrang(ref message));
            lblTinhThu_TBA4.Text = message;
        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuanLyBangGiaForm_Load(object sender, EventArgs e)
        {
            
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
        private void btnCopyBangGia_Click(object sender, EventArgs e)
        {
            var chuoiBangGia = XayDungBangGia(this.lstTrinhBayBG);
            if (!string.IsNullOrEmpty(chuoiBangGia))
                Clipboard.SetText(chuoiBangGia);
        }
    }
}
