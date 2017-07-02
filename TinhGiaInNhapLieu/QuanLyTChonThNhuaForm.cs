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
using TinhGiaInNhapLieu.Presenter;
using TinhGiaInNhapLieu.View;

namespace TinhGiaInNhapLieu
{
    public partial class QuanLyTChonThNhuaForm : Telerik.WinControls.UI.RadForm, IViewQuanLyTChonThNhua
    {
        QuanLyTChonThNhuaPresenter quanLyTChonThNhua;
        public QuanLyTChonThNhuaForm()
        {
            InitializeComponent();
            quanLyTChonThNhua = new QuanLyTChonThNhuaPresenter(this);

            LoadBangGia();
            cboBangGia.SelectedIndex = -1;
            cboBangGia.SelectedIndex = 0;
            LoadTuyChon();
            CheckedTuyChonS();

            //Events
            txtGiaBan.Leave += new EventHandler(TextBoxed_Leave);

            txtGiaBan.KeyPress += new KeyPressEventHandler(InputValidator);
        }
        #region implement Iview...
        public int IdBangGiaChon
        {
            get
            {
                if (cboBangGia.SelectedValue != null)
                    return int.Parse(cboBangGia.SelectedValue.ToString());
                else
                    return 0;
            }
            set
            {
                cboBangGia.SelectedValue = value;
            }
        }
        public int GiaBan
        {
            get { return int.Parse(txtGiaBan.Text); }
            set { txtGiaBan.Text = value.ToString(); }
        }
        #endregion



      
        private void LoadBangGia()
        {
            cboBangGia.ValueMember = "ID";
            cboBangGia.DisplayMember = "Ten";
            cboBangGia.DataSource = quanLyTChonThNhua.BangGiaS();
            
            
        }

        private void LoadTuyChon()
        {
            chkListTuyChon.ValueMember = "ID";
            chkListTuyChon.DisplayMember = "Ten";
            chkListTuyChon.DataSource = quanLyTChonThNhua.TuyChonS();
        }
        private void CheckedTuyChonS()
        {
            //Nếu danh sách khác null thì dò và check tất cả những thứ có
            if (quanLyTChonThNhua.IdTuyChonSCoTrongGiaTheoBangGia() != null)
            {
                //Uncheck tất cả phòng đã check
                chkListTuyChon.UncheckAllItems();
                //Dò check
                //GiaTuyChonTheNhua tuyChanDThiep;
                foreach (int idTuyChon in quanLyTChonThNhua.IdTuyChonSCoTrongGiaTheoBangGia())
                {
                    //Tìm từng item có id tùy chọn check nó
                    for (int i = 0; i < chkListTuyChon.Items.Count(); ++i)
                    {
                        var tuyChanDThiep = (TuyChonTheNhua)chkListTuyChon.Items[i].DataBoundItem;
                        if (tuyChanDThiep.ID == idTuyChon)
                        {
                            //check                            
                            chkListTuyChon.Items[i].CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                            
                            break;
                        }
                    }
                }
              
            }
            else  //Uncheck tất cả
                chkListTuyChon.UncheckAllItems();
            
        }

        private void QuanLyMarkUpLoiNhuanGiayForm_Load(object sender, EventArgs e)
        {

        }

        private void cboBangGia_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtDienGiaiBangGia.Text = quanLyTChonThNhua.MoToBangGia();
            //Check  khi load bảng giá
            CheckedTuyChonS();
            LoadGiaTuyChonTheoBangGia();
        }
        private void LuuMoiDanhSachTuyChon()
        {
            if (chkListTuyChon.CheckedItems.Count > 0)
            {
                //tạo ds
                var lst = new List<int>();
                for (int i = 0; i < chkListTuyChon.CheckedItems.Count; i++ )
                {
                    var tuyChon = (TuyChonTheNhua)chkListTuyChon.CheckedItems[i].DataBoundItem;
                    lst.Add(tuyChon.ID);
                }
                //Lưu lại toàn bộ
                //MessageBox.Show(lst.Count().ToString());//OK rồi
                var thongDiep = "";
                quanLyTChonThNhua.LuuThemMoiTuyChon(ref thongDiep, lst);
                MessageBox.Show(thongDiep);
            }
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCapNhatTuyChon_Click(object sender, EventArgs e)
        {
            //Lưu mấy cái check
            LuuMoiDanhSachTuyChon();
            //Checklai nó
            CheckedTuyChonS();
            LoadTuyChon();
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is Telerik.WinControls.UI.RadTextBox)
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                //Chỉ thêm số chẵn      
                if (tb == txtGiaBan)//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
            }
        }
        private void TextBoxed_Leave(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox tb;
            if (sender is  Telerik.WinControls.UI.RadTextBox )
            {
                tb = (Telerik.WinControls.UI.RadTextBox)sender;
                if (tb == txtGiaBan)
                {
                    if (string.IsNullOrEmpty(txtGiaBan.Text.Trim()))
                        this.GiaBan = 0;
                }
            }
        }
        private void LoadGiaTuyChonTheoBangGia()
        {
           
            lvwGiaTuyChon.DataSource = quanLyTChonThNhua.GiaTuyChonSTheoBangGia();
        }
        private void CapNhatGiaBan()
        {
            var thongDiep = "";
            if (lvwGiaTuyChon.SelectedItems.Count > 0)
            {
                var item = (GiaTuyChonTheNhua)lvwGiaTuyChon.SelectedItems[0].DataBoundItem;
                item.GiaBan = this.GiaBan;
                //Cập nhật nhé
                quanLyTChonThNhua.CapNhatGiaTuyChon(ref thongDiep, item);
                MessageBox.Show(thongDiep);
                LoadGiaTuyChonTheoBangGia();
            }
        }
        private void lvwGiaTuyChon_ColumnCreating(object sender, Telerik.WinControls.UI.ListViewColumnCreatingEventArgs e)
        {
            if (e.Column.FieldName == "IdBangGiaTheNhua")
            {
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "IdTuyChonTheNhua")
            {
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "TenBangGia")
            {
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "TenTuyChon")
            {
                e.Column.HeaderText = "Tùy chọn";
                e.Column.Width = 150;
                e.Column.MinWidth = 50;
                
            }
            if (e.Column.FieldName == "GiaBan")
            {
                e.Column.HeaderText = "Giá bán";
                e.Column.Width = 60;
                e.Column.MinWidth = 50;
            }
            
        }

        private void lvwGiaTuyChon_SelectedItemChanged(object sender, EventArgs e)
        {
            if (lvwGiaTuyChon.SelectedItems.Count > 0)
            {
                var item = (GiaTuyChonTheNhua)lvwGiaTuyChon.SelectedItems[0].DataBoundItem;                
                this.GiaBan = quanLyTChonThNhua.GiaTheoId(item.IdBangGiaTheNhua, item.IdTuyChonTheNhua);
            }
        }

        private void btnCapNhatGia_Click(object sender, EventArgs e)
        {
            CapNhatGiaBan();
        }
    }
}
