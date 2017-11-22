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
    public partial class QuanLyDanhMucGiayForm : Form, IViewQuanLyDMGiay
    {
        QuanLyDMGiayPresenter qLyDMGiayPres;
        public int FormState { get; set; }

        private int _selCateId = 0;
        public int IdDanhMucGiayChon
        {
            get
            {
                if (lvwDanhMucGiay.SelectedItems.Count > 0)
                    int.TryParse(lvwDanhMucGiay.SelectedItems[0].Text, out _selCateId);
                return _selCateId;
            }
            set { _selCateId = value; }
        }
        public string NhaCungCapChon
        {
            get
            {
                return lbxNhaCungCap.Text;
            }
            set
            {
                lbxNhaCungCap.Text = value;
            }
        }
        public string ThongTin
        {
            get { return lblThongTin.Text; }
            set { lblThongTin.Text = value; }
        }

public QuanLyDanhMucGiayForm()
        {
            InitializeComponent();
         
            qLyDMGiayPres = new QuanLyDMGiayPresenter(this);
            LoadNhaCungCap();
            lbxNhaCungCap.SelectedIndex = 0;
            LoadDanhMucGiay();
            
            //event
            cmnuThemDM.Click += new EventHandler(AcctingButtons_Click);
            cmnuSuaDM.Click += new EventHandler(AcctingButtons_Click);
            cmnuXoaDM.Click += new EventHandler(AcctingButtons_Click);
        }

        private void btnDeletePaperCate_Click(object sender, EventArgs e)
        {

        }
        private void AcctingButtons_Click(object sender, EventArgs e)
        {
          
        }

        private void btnAddNewPaperCate_Click(object sender, EventArgs e)
        {

        }
        private void LoadNhaCungCap()
        {
            lbxNhaCungCap.Items.Clear();
            foreach (string str in qLyDMGiayPres.NhaCungCapS())
            {
                lbxNhaCungCap.Items.Add(str);
            }
        }
        private void  LoadDanhMucGiay()
        {
            lvwDanhMucGiay.Clear();
            lvwDanhMucGiay.Columns.Add("Id");
            lvwDanhMucGiay.Columns.Add("Danh mục");
            lvwDanhMucGiay.Columns.Add("Nguồn CC");
            lvwDanhMucGiay.Columns.Add("Thứ tự hiện");
            lvwDanhMucGiay.View = System.Windows.Forms.View.Details;
            lvwDanhMucGiay.HideSelection = false;
            lvwDanhMucGiay.FullRowSelect = true;
                
            
        
                foreach (KeyValuePair<int, List<string>> kvp in qLyDMGiayPres.DanhMucTheoNCC())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = kvp.Key.ToString();
                    item.SubItems.AddRange(kvp.Value.ToArray());
                    lvwDanhMucGiay.Items.Add(item);
                }
                lvwDanhMucGiay.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwDanhMucGiay.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwDanhMucGiay.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwDanhMucGiay.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            
        }
        private void PaperCateManForm_Load(object sender, EventArgs e)
        {
            LoadDanhMucGiay();
            switch (FormState)
            {
                case (int)FormStateS.View:
                    btnClose.Text = "Chọn";
                    break;
            }
        }

        private void btnEditPaperCate_Click(object sender, EventArgs e)
        {

        }

        private void lbxNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhMucGiay();//Chạy theo nhà CC:
        }

        private void cmnuThemDM_Click(object sender, EventArgs e)
        {
           
                var frm = new DanhMucGiayForm();
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.TinhTrangForm = (int)FormStateS.New;
                frm.IdDanhMucgiay = 0;
                frm.TenDanhMuc = "Cần tên danh mục";
                frm.TenNhaCungCapChon = lbxNhaCungCap.Text;
                frm.ThuTu = 99;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    LoadDanhMucGiay();
                }

            
        }

        private void cmnuSuaDM_Click(object sender, EventArgs e)
        {

            if (lvwDanhMucGiay.SelectedItems.Count > 0)
            {

                DanhMucGiayForm frm = new DanhMucGiayForm();
                frm.IdDanhMucgiay = int.Parse(lvwDanhMucGiay.SelectedItems[0].Text);
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.TinhTrangForm = (int)FormStateS.Edit;
                frm.IdDanhMucgiay = IdDanhMucGiayChon;
                frm.TenDanhMuc = lvwDanhMucGiay.SelectedItems[0].SubItems[1].Text;
                frm.TenNhaCungCapChon = lbxNhaCungCap.Text;
                frm.ThuTu = int.Parse(lvwDanhMucGiay.SelectedItems[0].SubItems[3].Text);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    LoadDanhMucGiay();
                }
            }
        }
    

}
}
