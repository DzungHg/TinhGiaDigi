using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using TinhGiaInClient;
using TinhGiaInClient.Model;

namespace TinhGiaInNhapLieu
{
    public partial class DSBangGiaForm : Telerik.WinControls.UI.RadForm
    {
        public DSBangGiaForm()
        {
            InitializeComponent();

            LoadBangGia();
        }
        //Thêm field
        public int IdBangGiaChon
        { get; set; }
        public string LoaiBangGia { get; set; }
        //
        public void LoadBangGia()
        {
            lstBangGia.DataSource = DanhSachBangGia.DanhSachS();
            lstBangGia.DataMember = "ID";

        }

        public void BatNutNhan()
        {
            var kq = true;
            if (this.IdBangGiaChon <= 0)
                kq = false;//không chọn

            btnNhan.Enabled = kq;
        }

        private void DSBangGiaForm_Load(object sender, EventArgs e)
        {

            BatNutNhan();
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
                e.Column.HeaderText = "Tên bảng giá";

                e.Column.Width = 100;
            }
            if (e.Column.FieldName == "DaySoLuong")
            {
                e.Column.Visible = false;

                
            }
            if (e.Column.FieldName == "DayGia")
            {
                e.Column.Visible = false;


            }
            if (e.Column.FieldName == "DonViTinh")
            {
                e.Column.HeaderText = "ĐVT";

                e.Column.Width = 50;
            }
            if (e.Column.FieldName == "ThuTu")
            {
                e.Column.Visible = false;


            }
            if (e.Column.FieldName == "LoaiBangGia")
            {
                e.Column.HeaderText = "Loại";

                e.Column.Width = 50;
            }
        }

        private void lstBangGia_SelectedItemChanged(object sender, EventArgs e)
        {
             
                if (lstBangGia.SelectedItems.Count > 0)
                {
                    var item = (BangGiaBase)lstBangGia.SelectedItems[0].DataBoundItem;
                    this.IdBangGiaChon = item.ID;
                    this.LoaiBangGia = item.LoaiBangGia;
                }
                else
                {
                    this.IdBangGiaChon = 0;
                    this.LoaiBangGia = "";
                }
                BatNutNhan();
            
        }
    }
}
