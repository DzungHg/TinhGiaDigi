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

namespace TinhGiaInClient
{
    public partial class GiaInForm : Form, IViewGiaIn
    {
        GiaInPresenter giaInPres;
        public GiaInForm()
        {
            InitializeComponent();
            giaInPres = new GiaInPresenter(this);

        }
        #region implement Iview
        public int ID
        {
            get;
            set;
        }

        public int IdBaiIn
        {
            get;
            set;
        }

        public int KieuIn
        {
            get;
            set;
        }

        public int LoaiBangGia
        {
            get
            {
                if (rdbInNhanh.Checked)
                    return 0;
                else if(rdbInTheoMay.Checked)
                    return 1;
                else
                    return 0;
            }
            set
            {
                var tmp = value;
                switch (tmp)
                {
                    case (int)Ennums.LoaiBangGia.InNhanh:
                        rdbInNhanh.Checked = true;
                        break;
                    case (int)Ennums.LoaiBangGia.InNhanhTheoMay:
                        rdbInTheoMay.Checked = true;
                        break;
                }
            }
        }

        int _idBangGiaChon = 0;
        public int IdBangGiaChon
        {
            get
            {
                int.TryParse(cboBangGia.SelectedValue.ToString(), out _idBangGiaChon);
                return _idBangGiaChon;
            }
            set
            {
                _idBangGiaChon = value;
            }
        }
        public string TenBangGiaChon
        {
            get
            {
                return cboBangGia.Text;
            }
            set
            { var tmp = value; }
        }
        public int SoTrangA4
        {
            get
            {
                return int.Parse(txtSoTrangA4.Text);
            }
            set
            {
                txtSoTrangA4.Text = value.ToString();
            }
        }

        public int TienIn
        {
            get
            {
                return 0;
            }
            set
            {
                ;
            }
        }
        public string ThongTinGiay
        {
            get { return txtThongTinGiay.Text; }
            set { txtThongTinGiay.Text = value; }
        }
        public int FormState
        {
            get;
            set;
        }

        #endregion
        private void LoadBangGia()
        {
            cboBangGia.DataSource = null;
            cboBangGia.ValueMember = "";
            cboBangGia.DisplayMember = "";
             switch (this.LoaiBangGia)
             {
                 case (int)Ennums.LoaiBangGia.InNhanh:
                     cboBangGia.ValueMember = "ID";
                     cboBangGia.DisplayMember = "TenBangGia";
                     cboBangGia.DataSource = BangGiaInNhanh.LayTatCa();
                     break;
                 case (int)Ennums.LoaiBangGia.InNhanhTheoMay:
                     cboBangGia.ValueMember = "ID";
                     cboBangGia.DisplayMember = "Ten";
                     cboBangGia.DataSource = ToChayDigi.LayTatCa();
                     MessageBox.Show(ToChayDigi.LayTatCa().Count().ToString());
                     break;
             }
        }

        private void GiaInForm_Load(object sender, EventArgs e)
        {
            LoadBangGia();
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            LoadBangGia();

        }
    }
}
