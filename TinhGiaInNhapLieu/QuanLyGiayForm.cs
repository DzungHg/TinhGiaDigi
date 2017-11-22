using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient;
using TinhGiaInNhapLieu.View;
using TinhGiaInNhapLieu.Presenter;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu
{
    public partial class QuanLyGiayForm : Form, IViewQuanLyGiay
    {
        QuanLyGiayPresenter quanLyGiayPres;
        public QuanLyGiayForm()
        {
            InitializeComponent();
            quanLyGiayPres = new QuanLyGiayPresenter(this);
            LoadNhaCungCapGiay();
            LoadDanhMucTheoNhaCungCap();
            
        }
        #region Implement Iview..

        public string NhaCungCapChon
        {
            get
            {
                return cboNhaCC.Text;
            }
          
        }

        int _idDanhMucGiayChon = 0;
        public int IdDanhMucGiayChon
        {
            get
            {
                if (lbxDanhMucGiay.SelectedValue != null)
                    int.TryParse(lbxDanhMucGiay.SelectedValue.ToString(), out _idDanhMucGiayChon);
                return _idDanhMucGiayChon;
            }
           
        }
        int _idGiayChon = 0;
        public int IdGiayChon
        {
            get
            {
                if (lvwGiay.SelectedItems.Count > 0)
                    int.TryParse(lvwGiay.SelectedItems[0].Text, out _idGiayChon    );
                return _idGiayChon;
            }
            
        }
        #endregion
        public void LoadNhaCungCapGiay()
        {
            cboNhaCC.DisplayMember = "Ten";
            cboNhaCC.ValueMember = "Ten";
            cboNhaCC.DataSource = quanLyGiayPres.NhaCungCapS();

            //MessageBox.Show(NhaCungCap.DanhSachNCC().Count().ToString());
        }
        public void LoadDanhMucTheoNhaCungCap()
        {
            lbxDanhMucGiay.DisplayMember = "Ten";
            lbxDanhMucGiay.ValueMember = "ID";
            lbxDanhMucGiay.DataSource = quanLyGiayPres.DanhMucTheoNCC();

        }
        private void ChuanBiGiayForm_Load(object sender, EventArgs e)
        {
            lblTieuDeForm.Text = this.Text;
        }

        private void cboNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhMucTheoNhaCungCap();
        }
        private void LoadGiayTheoDanhMuc()
        {
            //Listview Sản phẩm
            lvwGiay.Clear();           
            lvwGiay.Columns.Add("Id");
            lvwGiay.Columns.Add("Tên mở rộng");
            lvwGiay.Columns.Add("Tên giấy");
            lvwGiay.Columns.Add("Định lượng");
            lvwGiay.Columns.Add("Khổ");
            lvwGiay.Columns.Add("Ngắn");
            lvwGiay.Columns.Add("Dài");
            lvwGiay.Columns.Add("Giá mua");
            lvwGiay.Columns.Add("Hết hàng");
            lvwGiay.Columns.Add("Tồn kho?");
            lvwGiay.Columns.Add("Thứ tự");
            lvwGiay.View = System.Windows.Forms.View.Details;
            lvwGiay.HideSelection = false;
            lvwGiay.FullRowSelect = true;
            //Xóa;
           
            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in  quanLyGiayPres.GiaySTheoDanhMucGiay())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();

                item.SubItems.AddRange(kvp.Value.ToArray());
                lvwGiay.Items.Add(item);
            }
            lvwGiay.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[8].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[9].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[10].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        
        private void lbxDanhMucGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            LoadGiayTheoDanhMuc();
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            QuanLyDanhMucGiayForm frm = new QuanLyDanhMucGiayForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.LoadNhaCungCapGiay();

            }
        }

        private void cmuThemGiay_Click(object sender, EventArgs e)
        {
            GiayForm frm = new GiayForm((int)FormStateS.New, this.NhaCungCapChon,
                        this.IdDanhMucGiayChon);
            frm.Text = "Giấy [Thêm mới]";
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.LoadGiayTheoDanhMuc();

            }
        }
        private void SuaGiay()
        {
            if (this.IdGiayChon <= 0)
                return;

            GiayForm frm = new GiayForm((int)FormStateS.Edit, this.NhaCungCapChon,
                        this.IdDanhMucGiayChon, this.IdGiayChon);
            frm.Text = string.Format("Giấy [Sửa: {0}]", this.IdGiayChon);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.LoadGiayTheoDanhMuc();

            }
        }
        private void cmuSuaGiay_Click(object sender, EventArgs e)
        {
            SuaGiay();
        }

        private void cmu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void lvwGiay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SuaGiay();
        }

        private void cmuNhanDoiGiay_Click(object sender, EventArgs e)
        {
            var thongDiep = "";
            var tenGiay = quanLyGiayPres.TenGiayMoRongTheoId(this.IdGiayChon);

            if (MessageBox.Show("Bạn nhân đôi " + tenGiay, "Chú ý", MessageBoxButtons.OKCancel
                , MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
            {
                quanLyGiayPres.NhanDoiGiay(ref thongDiep, this.IdGiayChon);
                MessageBox.Show(thongDiep);
                LoadGiayTheoDanhMuc();
            }
        }

       
    }

}
