using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient.Common.Enum;

using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;

namespace TinhGiaInClient
{
    public partial class KhoSanPhamSForm : Form, IViewKhoSanPham 
    {
        #region implement IViewProdMan
        
        private int _id = 0;

        public int IdChon
        {
            get
            {
                if (lvwKhoSanPham.SelectedItems.Count > 0)
                {
                    int.TryParse(lvwKhoSanPham.SelectedItems[0].Text, out _id);
                }
                return _id;
                
            }

            set { _id = value; }
        }
        //float _rong = 0;
        public float Rong
        {
            get;
            set;
        }
        public float Cao
        { get; set; }
        public float TranLeTren
        {
            get;
            set;

        }
        public float TranLeDuoi
        {
            get;
            set;

        }
        public float TranLeTrong
        {
            get;
            set;

        }
        public float TranLeNgoai
        {
            get;
            set;

        }

       /* float _cao = 0;
        public float Cao
        {
            get
            {
                if (lvwKhoSanPham.SelectedItems.Count > 0)
                {
                    float.TryParse(lvwKhoSanPham.SelectedItems[0].SubItems[3].Text, out _cao);
                }
                return _cao;
            }
        }*/
        public string TenKho { get; set; }
       /* string _ten = "";
        public string TenKho
        {
            get
            {
                if (lvwKhoSanPham.SelectedItems.Count > 0)
                {
                    _ten = lvwKhoSanPham.SelectedItems[0].SubItems[1].Text;
                }
                return _ten;
            }
        }*/

        public FormStateS TinhTrangForm { get; set; }
        #endregion

        KhoSanPhamPresenter khoSanPhamPres = null;
        public KhoSanPhamSForm(FormStateS formState)
        {
            InitializeComponent();
            khoSanPhamPres = new KhoSanPhamPresenter(this);

            cmnu_AddNew.Click += new EventHandler(MenuItems_Click);
            cmnu_Edit.Click += new EventHandler(MenuItems_Click);
            cmnu_Delete.Click += new EventHandler(MenuItems_Click);
            this.TinhTrangForm = formState;
        }

        private void btnDeletePaperCate_Click(object sender, EventArgs e)
        {

        }
        private void MenuItems_Click(object sender, EventArgs e)
        {
            /*  
            ToolStripMenuItem mnuItem;
            if (sender is ToolStripMenuItem)
            {
                mnuItem = (ToolStripMenuItem)sender;
                if (mnuItem == cmnu_AddNew)
                {
                    ProductSizeForm frm = new ProductSizeForm();
                    frm.MaximizeBox = false;
                    frm.MinimizeBox = false;
                    frm.FormState = (int)Ennums.FormState.New;
                    frm.ShowDialog();
                    if (frm.FormSaved)
                        LoadStdProdSizeList();
                    
                }
                if (mnuItem == cmnu_Edit)
                {
                    if (lvwProductList.SelectedItems.Count > 0)
                    {

                        ProductSizeForm frm = new ProductSizeForm();
                        frm.ProdSizeId = int.Parse(lvwProductList.SelectedItems[0].Text);
                        frm.MaximizeBox = false;
                        frm.MinimizeBox = false;
                        frm.FormState = (int)Ennums.FormState.Edit;
                        frm.ShowDialog();
                        if (frm.FormSaved)
                            LoadStdProdSizeList();

                    }
                    
                }

                if (mnuItem == cmnu_Delete)
                {

                }
                
            }
            */

        }

        private void btnAddNewPaperCate_Click(object sender, EventArgs e)
        {

        }
        private void LoadStdProdSizeList()
        {
            lvwKhoSanPham.Clear();
            lvwKhoSanPham.Columns.Add("Id");
            lvwKhoSanPham.Columns.Add("Tên");
            lvwKhoSanPham.Columns.Add("Rộng x Cao");
            lvwKhoSanPham.Columns.Add("Diễn giải");
            lvwKhoSanPham.View = System.Windows.Forms.View.Details;
            lvwKhoSanPham.HideSelection = false;
            lvwKhoSanPham.FullRowSelect = true;


            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in khoSanPhamPres.KhoSanPhamS())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                foreach (string str in kvp.Value)
                {

                    item.SubItems.Add(str);

                }
                lvwKhoSanPham.Items.Add(item);

            }

            lvwKhoSanPham.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwKhoSanPham.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwKhoSanPham.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwKhoSanPham.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

        }
        private void PaperCateManForm_Load(object sender, EventArgs e)
        {
           
            
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (lvwKhoSanPham.SelectedItems.Count > 0)
            {
                IdChon = int.Parse(lvwKhoSanPham.SelectedItems[0].Text);
                //prodSizeManPres.DisplayProdSize();//Cập nhật các thuộc tính
            }
            else { IdChon = -1; }

        }

        private void cmnu_Main_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmnu_AddNew_Click(object sender, EventArgs e)
        {

        }

        private void ProductSizeManForm_Load(object sender, EventArgs e)
        {
            
        }

        private void KhoSanPhamSForm_Load(object sender, EventArgs e)
        {
            LoadStdProdSizeList();
            switch (this.TinhTrangForm)
            {
                case FormStateS.Get:
                    btnDong.Text = "Nhận";
                    btnDong.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                
            }
            BatNutNhan();
        }

        private void KhoSanPhamSForm_Resize(object sender, EventArgs e)
        {
            lvwKhoSanPham.Width = this.ClientSize.Width - 20;
            lvwKhoSanPham.Left = (this.ClientSize.Width - lvwKhoSanPham.Width) / 2;
            btnDong.Left = (this.ClientSize.Width - btnDong.Width) / 2;

            lvwKhoSanPham.Height = this.ClientSize.Height - btnDong.Height - 6;
            lvwKhoSanPham.Top = 2;
            btnDong.Top = lvwKhoSanPham.Top + lvwKhoSanPham.Height + 2;
        }

        private void lvwKhoSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            khoSanPhamPres.CapNhatChiTietKhoSanPham();
            BatNutNhan();
        }

        private void BatNutNhan()
        {
            var kq = true;
            if (this.IdChon <= 0 || this.Rong <= 0 ||
                this.Cao <= 0)
                kq = false;

            btnDong.Enabled = kq;
        }







    }
}
