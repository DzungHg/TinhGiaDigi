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
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;

namespace TinhGiaInNhapLieu
{
    public partial class LietKeTinhGiaForm : Form, IViewLietKeTinhGia
    {
        public LietKeTinhGiaForm()
        {
            InitializeComponent();
            lietKeTGPres = new LietKeTinhGiaPresenter(this);
        }
        LietKeTinhGiaPresenter lietKeTGPres;
        int _idTinhGiaChon = 0;
        public int IdTinhGiaChon
        {
            get
            {
                if (lvwTinhGia.SelectedItems.Count > 0)
                    int.TryParse(lvwTinhGia.SelectedItems[0].Text, out _idTinhGiaChon);
                return _idTinhGiaChon;
            }

        }

        int _kieuSapXep = 0;
        public int KieuSapXep
        {
            get
            {                
                if (rdbTheoTatCa.Checked)
                    _kieuSapXep = (int)Enumss.KieuSapXepTinhGia.TatCa;
                else if (rdbTheoNgayTG.Checked)
                    _kieuSapXep = (int)Enumss.KieuSapXepTinhGia.TheoNgay;
                else if (rdbTheoTenKH.Checked)
                    _kieuSapXep = (int)Enumss.KieuSapXepTinhGia.TheoKH;
                else if (rdbTheoTenNV.Checked)
                    _kieuSapXep = (int)Enumss.KieuSapXepTinhGia.TheoNV;

                return _kieuSapXep;
            }
            set
            {
                _kieuSapXep = value;
                switch (_kieuSapXep)
                {
                    case (int)Enumss.KieuSapXepTinhGia.TatCa:
                        rdbTheoTatCa.Checked = true;
                        break;
                    case (int)Enumss.KieuSapXepTinhGia.TheoNgay:
                        rdbTheoNgayTG.Checked = true;
                        break;
                    case (int)Enumss.KieuSapXepTinhGia.TheoKH:
                        rdbTheoTenKH.Checked = true;
                        break;
                    case (int)Enumss.KieuSapXepTinhGia.TheoNV:
                        rdbTheoTenNV.Checked = true;
                        break;
                }
            }
        }
        //-
        private void LoadTinhGia()
        {           
            lvwTinhGia.Clear();
            lvwTinhGia.Columns.Add("Id");
            lvwTinhGia.Columns.Add("Ngày");
            lvwTinhGia.Columns.Add("Số");
            lvwTinhGia.Columns.Add("Tên KH");
            lvwTinhGia.Columns.Add("Liên hệ");
            lvwTinhGia.Columns.Add("Tên NV");
            lvwTinhGia.Columns.Add("Nội dung");
            lvwTinhGia.View = System.Windows.Forms.View.Details;
            lvwTinhGia.HideSelection = false;
            lvwTinhGia.FullRowSelect = true;



            foreach (KeyValuePair<int, List<string>> kvp in lietKeTGPres.TinhGiaS())
            {
                ListViewItem item = new ListViewItem();
                item.Text = kvp.Key.ToString();
                item.SubItems.AddRange(kvp.Value.ToArray());
                lvwTinhGia.Items.Add(item);
            }
            lvwTinhGia.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTinhGia.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTinhGia.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwTinhGia.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTinhGia.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTinhGia.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwTinhGia.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
