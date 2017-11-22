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
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu
{
    public partial class QuanLyMarkUpLoiNhuanGiayForm : Form
    {
        int _idDanhMucGiayChon = 0;
        public int IdDanhMucGiayChon
        {
            get
            {
                if (lbxDanhMucGiay.SelectedValue != null)
                {
                    int.TryParse(lbxDanhMucGiay.SelectedValue.ToString(), out _idDanhMucGiayChon);
                }
                return _idDanhMucGiayChon;
            }
            set { _idDanhMucGiayChon = value; }
        }
        int _idHangKHChon = 0;
        public int IdHangKHChon
        {
            get
            {
                if (lvwLoiNhuan.SelectedItems.Count > 0)
                {
                    var tmps = lvwLoiNhuan.SelectedItems[0].Text.Split(';');
                    int.TryParse(tmps[1], out _idHangKHChon);//Mục 2 là idHangKH
                }
                return _idHangKHChon;
            }
        }
        public QuanLyMarkUpLoiNhuanGiayForm()
        {
            InitializeComponent();
            LoadNhaCungCap();
        }
        private void LoadNhaCungCap()
        {
            cboNhaCC.ValueMember = "Ten";
            cboNhaCC.DisplayMember = "Ten";
            cboNhaCC.DataSource = NhaCungCapGiay.DanhSachNCC();
            
        }

        private void cboNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxDanhMucGiay.ValueMember = "ID";
            lbxDanhMucGiay.DisplayMember = "Ten";
            lbxDanhMucGiay.DataSource = DanhMucGiay.LayTheoNhaCungCap(cboNhaCC.SelectedValue.ToString());
        }
        private void LoadMarkUpLoiNhuanGiay(int idDanhMucGiay)
        {
            lvwLoiNhuan.Clear();
            lvwLoiNhuan.Columns.Add("IdvId");
            lvwLoiNhuan.Columns.Add("Tên hạng KH");
            lvwLoiNhuan.Columns.Add("Tỉ lệ LN");
            lvwLoiNhuan.View = System.Windows.Forms.View.Details;
            lvwLoiNhuan.FullRowSelect = true;
            //---
            if (idDanhMucGiay <= 0)
                return;
            //tiếp tục nếu
          
            var lstMK = MarkUpLoiNhuanGiay.LayTheoIdDanhMucGiay(idDanhMucGiay);
            foreach( MarkUpLoiNhuanGiay mK in lstMK)
            {
                var item = new ListViewItem();
                item.Text = string.Format("{0};{1}", mK.IdDanhMucGiay, mK.IdHangKhachHang);
                item.SubItems.Add(mK.TenHangKhachHang);
                item.SubItems.Add(string.Format("{0}%", mK.TiLeLoiNhuanTrenDoanhThu));
                lvwLoiNhuan.Items.Add(item);
            }
            lvwLoiNhuan.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwLoiNhuan.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwLoiNhuan.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            

        }

        private void lbxDanhMucGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMarkUpLoiNhuanGiay(this.IdDanhMucGiayChon);
        }

        private void cmnuThem_Click(object sender, EventArgs e)
        {
            MarkUpLoiNhuanGiayForm frm = new MarkUpLoiNhuanGiayForm((int)FormStateS.New);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Lợi nhuận theo";
            frm.DanhMucGiay = lbxDanhMucGiay.Text;
            frm.IdDanhMuc = this.IdDanhMucGiayChon;
            frm.TiLeLoiNhuan = 5;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                LoadMarkUpLoiNhuanGiay(this.IdDanhMucGiayChon);
            }
        }

        private void cmnuSua_Click(object sender, EventArgs e)
        {
            if (this.IdDanhMucGiayChon <= 0 || this.IdHangKHChon <= 0)
                return;
            MarkUpLoiNhuanGiayForm frm = new MarkUpLoiNhuanGiayForm((int)FormStateS.Edit);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Lợi nhuận theo";
            frm.DanhMucGiay = lbxDanhMucGiay.Text;
            frm.IdDanhMuc = this.IdDanhMucGiayChon;
            frm.IdHangKH = this.IdHangKHChon;
            frm.TiLeLoiNhuan = MarkUpLoiNhuanGiay.LayTheoId(this.IdDanhMucGiayChon, this.IdHangKHChon).TiLeLoiNhuanTrenDoanhThu;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                LoadMarkUpLoiNhuanGiay(this.IdDanhMucGiayChon);
            }
        }
    }
}
