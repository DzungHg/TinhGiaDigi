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

namespace TinhGiaInClient
{
    public partial class KhoSanPhamSForm : Form 
    {
        #region implement IViewProdMan
        
        private int _id = 0;

        public int SelProdSizeId
        {
            get
            {
                if (lvwProductList.SelectedItems.Count > 0)
                {
                    int.TryParse(lvwProductList.SelectedItems[0].Text, out _id);
                }
                return _id;
                
            }

            set { _id = value; }
        }
        float _rong = 0;
        public float ChieuRong
        {
            get
            {
                if (lvwProductList.SelectedItems.Count > 0)
                {
                    float.TryParse(lvwProductList.SelectedItems[0].SubItems[2].Text, out _rong);
                }
                return _rong;
            }
        }

        float _cao = 0;
        public float ChieuCao
        {
            get
            {
                if (lvwProductList.SelectedItems.Count > 0)
                {
                    float.TryParse(lvwProductList.SelectedItems[0].SubItems[3].Text, out _cao);
                }
                return _cao;
            }
        }

        string _ten = "";
        public string TenKho
        {
            get
            {
                if (lvwProductList.SelectedItems.Count > 0)
                {
                    _ten = lvwProductList.SelectedItems[0].SubItems[1].Text;
                }
                return _ten;
            }
        }

        public FormStateS TinhTrangForm { get; set; }
        #endregion
        
        public KhoSanPhamSForm(FormStateS formState)
        {
            InitializeComponent();
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
            lvwProductList.Clear();
            lvwProductList.Columns.Add("Id");
            lvwProductList.Columns.Add("Tên");
            lvwProductList.Columns.Add("Rộng");
            lvwProductList.Columns.Add("Cao");
            lvwProductList.View = System.Windows.Forms.View.Details;
            lvwProductList.HideSelection = false;
            lvwProductList.FullRowSelect = true;

            if (KhoSanPham.LayTatCa().Count() > 0)
            {
                ListViewItem item;
                foreach (KhoSanPham kho in KhoSanPham.LayTatCa())
                {
                    item = new ListViewItem();
                    item.Text = kho.ID.ToString();
                    
                    item.SubItems.Add(kho.Ten);
                    item.SubItems.Add(kho.KhoCatRong.ToString());
                    item.SubItems.Add(kho.KhoCatCao.ToString());
                    lvwProductList.Items.Add(item);
                    
                }
                lvwProductList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwProductList.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwProductList.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
              
            }
        }
        private void PaperCateManForm_Load(object sender, EventArgs e)
        {
           
            
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (lvwProductList.SelectedItems.Count > 0)
            {
                SelProdSizeId = int.Parse(lvwProductList.SelectedItems[0].Text);
                //prodSizeManPres.DisplayProdSize();//Cập nhật các thuộc tính
            }
            else { SelProdSizeId = -1; }

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
                    btnClose.Text = "Nhận";
                    btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                
            }
        }



        
    }
}
