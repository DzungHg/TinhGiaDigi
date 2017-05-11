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

namespace TinhGiaInClient
{
    public partial class LietKeTinhGiaForm : Form, IViewLietKeTinhGia
    {
        public LietKeTinhGiaForm(ClientMainForm parentMDIform)
        {
            InitializeComponent();
            this.MDIForm = parentMDIform;
            lietKeTGPres = new LietKeTinhGiaPresenter(this);

            cboSapXepTheo.SelectedIndex = 0;
            //event
            rdbNguoc.CheckedChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            rdbXuoi.CheckedChanged += new EventHandler(ComboBox_SelectedIndexChanged);
          
            cboSapXepTheo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
        }
        private ClientMainForm MDIForm { get; set; }

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
     
        public int KieuSapXep
        {
            get
            {
                if (cboSapXepTheo.SelectedIndex >= 0)
                    return cboSapXepTheo.SelectedIndex;
                else
                    return 0;
            }
            set
            {
                cboSapXepTheo.SelectedIndex = value;                                
            }
        }
        int _chieuSapXep = 0;
        public int IdChieuSapXep {
            get {
                if (rdbNguoc.Checked)
                    _chieuSapXep = (int)Enumss.ChieuSapXep.Descending;
                else
                    _chieuSapXep = (int)Enumss.ChieuSapXep.Ascending;
               
                return _chieuSapXep;
            }
            set { _chieuSapXep = value;
            if (_chieuSapXep == (int)Enumss.ChieuSapXep.Descending)
                rdbNguoc.Checked = true;
            else
                rdbXuoi.Checked = true;
            }
        }
        public string NoiDungTinhGia
        {
            get { return lietKeTGPres.DocNoiDungTinhGia(); }
            set { txtNoiDungTinhGia.Text = value; }
        }
        //-
        private void LoadTinhGia()
        {           
            lvwTinhGia.Clear();
            lvwTinhGia.Columns.Add("Id");
            lvwTinhGia.Columns.Add("Ngày");            
            lvwTinhGia.Columns.Add("Tiêu đề");
            lvwTinhGia.Columns.Add("Nhân viên");
           
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
            
            
        }

        private void LietKeTinhGiaForm_Load(object sender, EventArgs e)
        {
            LoadTinhGia();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            
        }

        private void lvwTinhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NoiDungTinhGia = lietKeTGPres.DocNoiDungTinhGia();
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButton rb;
            if (sender is RadioButton)
            {
                rb = (RadioButton)sender;
                if (rb == rdbXuoi || rb == rdbNguoc )
                    LoadTinhGia();
            }

            ComboBox cb;
            if (sender is ComboBox)
            {
                cb = (ComboBox)sender;
                if (cb == cboSapXepTheo)
                {
                    LoadTinhGia();
                }
            }
        }

        private void LietKeTinhGiaForm_Resize(object sender, EventArgs e)
        {
            btnDong.Left = (pnlBottomMain.Width - btnDong.Width) / 2;
            lblTieuDeNoiDung.Left = (pnlHeaderNoiDung.Width - lblTieuDeNoiDung.Width) / 2;
            grbSapXep.Left = pnlHeaderDanhSachTinhGia.Left + 5;
            grbSapXep.Top = pnlHeaderDanhSachTinhGia.Top + 5;
            btnThemTinhGia.Left = grbSapXep.Left + grbSapXep.Width + 5;
            btnCopyTinhGia.Left = btnThemTinhGia.Left + btnThemTinhGia.Width + 5;
            btnCopyTinhGia.Top = btnThemTinhGia.Top;

        }

        private void btnCopyTinhGia_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lietKeTGPres.NoiDungToanBoChaoGia_KH());
        }

        private void btnThemTinhGia_Click(object sender, EventArgs e)
        {
            MDIForm.ThemTinhGia(MDIForm);
            this.Close();
        }


    
    }
}
