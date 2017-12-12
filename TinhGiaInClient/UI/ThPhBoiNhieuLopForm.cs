using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.UI
{
    public partial class ThPhBoiNhieuLopForm : Telerik.WinControls.UI.RadForm, IViewThPhBoiNhieuLop
    {
        ThPhBoiNhieuLopPresenter thPhBoiNhieuLopPres;
        public ThPhBoiNhieuLopForm(ThongTinBanDauThanhPham thongTinBanDau, MucThPhBoiNhieuLop mucThPhBoiBiaCung)
        {
            InitializeComponent();

            this.ThongTinHoTro = thongTinBanDau.ThongDiepCanThiet;
           
            this.TinhTrangForm = thongTinBanDau.TinhTrangForm;
            this.Text = thongTinBanDau.TieuDeForm;
            txtSoLuong.Enabled = thongTinBanDau.MoTextSoLuong;
          

            thPhBoiNhieuLopPres = new ThPhBoiNhieuLopPresenter(this, mucThPhBoiBiaCung);
            LoadMayBoi();
          
            //Load Nhu ep
        
            
            //Load
            
            //Mục này phải làm ở đây
            if (this.TinhTrangForm == FormStateS.Edit ||
                this.IdThanhPhamChon > 0)
            {
                this.IdThanhPhamChon = mucThPhBoiBiaCung.IdThanhPhamChon;
               
                //this.IdGiayBoiGiuaChon = mucThPhBoiBiaCung.IdGiayBoiGiuaChon;
            }
            //Tiếp xem nếu có giấy bồi khong
            if (this.TinhTrangForm == FormStateS.Edit)
            {
                //Cập nhật thông tin giấy bồi:
                if (this.GiayDeBoiChon != null)
                    txtThongTinGiayLot.Lines = this.GiayDeBoiChon.ThongTinGiayBoi().ToArray();
                //Tính toán
                CapNhatLabelGia();
            }
            //Envent

            txtSoLuong.TextChanged += new EventHandler(TextBoxes_TextChanged);           
            txtSoLopLot.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToBoiRong.TextChanged += new EventHandler(TextBoxes_TextChanged);
            txtToBoiCao.TextChanged += new EventHandler(TextBoxes_TextChanged);

            txtSoLuong.Leave += new EventHandler(TextBoxes_Leave);
            txtSoLopLot.Leave += new EventHandler(TextBoxes_Leave);
            txtToBoiRong.Leave += new EventHandler(TextBoxes_Leave);
            txtToBoiCao.Leave += new EventHandler(TextBoxes_Leave);

            txtSoLuong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtSoLopLot.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToBoiRong.KeyPress += new KeyPressEventHandler(InputValidator);
            txtToBoiCao.KeyPress += new KeyPressEventHandler(InputValidator);

            rdbBoiDap.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(RadioButtons_ToggleStateChanged);
            rdbBoiLotGiua.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(RadioButtons_ToggleStateChanged);


            cboMayBoi.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(DropDownList_SelectedIndexChanged);

           
            
        }
        #region Implement Iview
        public int ID { get; set; }
        public int IdBaiIn { get; set; }

        public int IdHangKhachHang
        {
            get;
            set;
        }

        public string ThongTinHangKH
        {
            get { return thPhBoiNhieuLopPres.ThongTinHangKH(this.IdHangKhachHang); }
        }

        public string ThongTinTyLeMarkUp
        {
            get { return string.Format("{0}%", thPhBoiNhieuLopPres.TyLeMarkUp()); }
        }
         public int SoLuong
        {
            get
            {
                return int.Parse(txtSoLuong.Text);
            }
            set
            {
                txtSoLuong.Text = value.ToString();
            }
        }
         public string DonViTinh
         {
             get
             {
                 return txtDonViTinh.Text ;
             }
             set
             {
                 txtDonViTinh.Text = value;
             }
         }
         int _idThanhPhamChon = 0;
        public int IdThanhPhamChon
         {
             get {
                 if (cboMayBoi.SelectedValue != null)
                     int.TryParse(cboMayBoi.SelectedValue.ToString(), out _idThanhPhamChon);
                 return _idThanhPhamChon; 
             }
             set { cboMayBoi.SelectedValue = value; }
         }
       
        public string TenThanhPhamChon //là ép kim
        {
            get { return cboMayBoi.Text; }
            set {cboMayBoi.Text = value;}
        }
       
       
        public decimal ThanhTien
        {
            get { return thPhBoiNhieuLopPres.ThanhTien_ThPh(); }
            set { ;}
        }


        public LoaiThanhPhamS LoaiThPh
        {
            get;
            set;
        }
       
        public string ThongTinHoTro
        {
            get { return txtThongTinHoTro.Text; }
            set { txtThongTinHoTro.Text = value; }
        }
        public FormStateS TinhTrangForm
        {
            get;
            set;
        }
       //phần bổ sung
        public float ToBoiRong
        {
            get
            {
                return float.Parse(txtToBoiRong.Text);
            }
            set
            {
                txtToBoiRong.Text = value.ToString();
            }
        }

        public float ToBoiCao
        {
            get
            {
                return float.Parse(txtToBoiCao.Text);
            }
            set
            {
                txtToBoiCao.Text = value.ToString();
            }
        }
       

       
        public int IdGiayBoiGiuaChon
        {
            get;
            set;
        }



        public int SoLopLotGiua
        {
            get
            {
                return int.Parse(txtSoLopLot.Text);
            }
            set
            {
                txtSoLopLot.Text = value.ToString();
            }
        }
        public KieuBoiNhieuLop KieuBoi
        {
            get
            {
                if (rdbBoiDap.IsChecked)
                {
                    return KieuBoiNhieuLop.BoiDap;

                }
                else
                    return KieuBoiNhieuLop.BoiLotGiua;
            }
            set
            {
                if (value == KieuBoiNhieuLop.BoiDap)
                {
                    rdbBoiDap.IsChecked = true;
                    lblSoLopLot.Text = "Số tờ đắp thêm";
                    this.SoLopLotGiua = 1; //ít nhất là 1 lớp thêm
                }
                else
                {
                    rdbBoiLotGiua.IsChecked = true;
                    lblSoLopLot.Text = "Số tờ lót giữa";
                    this.SoLopLotGiua = 0;
                }
            }
        }

        public GiayDeBoi GiayDeBoiChon
        { get; set; }
      
        #endregion

        private void LoadMayBoi()
        {
            //Cán phủ
            cboMayBoi.DataSource = thPhBoiNhieuLopPres.ThanhPhamS();
            cboMayBoi.ValueMember = "ID";
            cboMayBoi.DisplayMember = "Ten";
         
        }
       
       

        private void txtSoLuong_CanPhu_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
          /*TextBox tb;
            if (sender is TextBox)
            {
                tb = (TextBox)sender;
               if (tb == txtSoLuong )
                {
                    if (!string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        ;                  
                }
                if (tb == txtToBoiRong)
                {
                    if (!string.IsNullOrEmpty(txtToBoiRong.Text.Trim()))
                        ;
                }
                if (tb == txtToBoiCao)
                {
                    if (!string.IsNullOrEmpty(txtToBoiCao.Text.Trim()))
                        ;
                }
                //xử lý khi user xóa hết bên Leave
                
                if (tb == txtSoLopLot)
                {
                    
                    ;
                }
                
            
            }
            */
            ClearCacLabelTinhToan();
            
        }
        private void CapNhatLabelGia()
        {


            lblThanhTien.Text = string.Format("{0:0,0.00}đ", thPhBoiNhieuLopPres.ThanhTien_ThPh());
            lblGiaTB.Text = string.Format("{0:0,0.00}đ/{1}", thPhBoiNhieuLopPres.GiaTB_ThPh(), this.DonViTinh);

        }
        private void ClearCacLabelTinhToan()
        {
            lblThanhTien.Text = "";
            lblGiaTB.Text = "";
        }
        private void InputValidator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender is TextBox)
            {
                t = (TextBox)sender;
                
                if (t == txtSoLuong || t == txtSoLopLot )//chỉ được nhập số chẵn 
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                }
                if (t == txtToBoiRong || t == txtToBoiCao)// được số lẻ
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                        e.Handled = true;
                }
            }
            
        }
        
        private void ThanhPhamForm_Load(object sender, EventArgs e)
        {
            lblTieuDeForm.Text = this.Text;
            if (this.SoLuong > 1) //bẩy cập nhật tính toán
            {
                SoLuong -= 1;
                SoLuong += 1;
            }
            
            txtDonViTinh.Enabled = false;
            if (this.IdThanhPhamChon > 0)
            {
                btnNhan.Enabled = true;
            }
            
            if (this.TinhTrangForm == FormStateS.View)
            {
                
                
                btnNhan.Enabled = true;
            }
            //Lừa để bât tắt nút lấy giấy
            var soLop = this.SoLopLotGiua;
            this.SoLopLotGiua = -1;
            this.SoLopLotGiua = soLop;
            //bẩy:
            cboMayBoi.SelectedIndex = -1;
            cboMayBoi.SelectedIndex = 0;
        }

        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();
            
            if (string.IsNullOrEmpty(txtSoLuong.Text))
                loiS.Add("Số lượng rỗng");
            if (string.IsNullOrEmpty(txtDonViTinh.Text))
                loiS.Add("Đơn vị tính");

            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void ThPhCanPhuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string ms = "";
                if (!KiemTraHopLe(ref ms))
                {
                    var dialogeR = MessageBox.Show(ms, "Dữ liệu điền chưa chuẩn đó! Điền tiếp?",
                         MessageBoxButtons.YesNo);
                    if (dialogeR == System.Windows.Forms.DialogResult.Yes)
                        e.Cancel = true;
                    else

                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void cboEpKim_SelectedIndexChanged(object sender, EventArgs e)
        {           
           
        }

        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            TextBox tb;
            if (sender is TextBox)
            {
                //xử lý khi user xóa hết
                tb = (TextBox)sender;
                if (tb == txtSoLuong)
                {
                    if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
                        txtSoLuong.Text = "1";
                }
                if (tb == txtToBoiRong)
                {
                    if (string.IsNullOrEmpty(txtToBoiRong.Text.Trim()))
                        this.ToBoiRong = 1;
                }
                if (tb == txtToBoiCao)
                {
                    if (string.IsNullOrEmpty(txtToBoiCao.Text.Trim()))
                        this.ToBoiCao = 1;
                }

                if (tb == txtSoLopLot)
                {
                    if (string.IsNullOrEmpty(txtSoLopLot.Text.Trim()))
                    {
                        this.SoLopLotGiua = 0;

                    }
                    if (this.SoLopLotGiua <= 0)

                        btnLayGiay.Enabled = false;

                    else
                        btnLayGiay.Enabled = true;
                }

            }
            ChoKhongChoNutNhan();
        }

        private void lstNhuEpKim_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = true;
            txtDonViTinh.Enabled = true;
            btnNhan.Enabled = true;
            
        }
        public MucThanhPham LayMucThanhPham()
        {
            return thPhBoiNhieuLopPres.LayMucThanhPham();
        }

        private void cboMayLoXo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void lstMoPhang_ColumnCreating(object sender, Telerik.WinControls.UI.ListViewColumnCreatingEventArgs e)
        {
            /*
            public int ID { get; set; }
        public string Ten { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DienGiai { get; set; }
        public int GiaMuaTo { get; set; }
        public int ThuTu { get; set; }*/

            if (e.Column.FieldName == "ID")
            {
                e.Column.HeaderText = "ID";
                e.Column.Width = 5;
                e.Column.MinWidth = 5;
            }

            if (e.Column.FieldName == "Ten")
            {
                e.Column.HeaderText = "Tên";
            
                e.Column.Width = 120;
            }

            if (e.Column.FieldName == "DoDayCm")
            {
                e.Column.Width = 50;
                e.Column.HeaderText = "Độ dày";
            }         

            if (e.Column.FieldName == "GiaMuaTo")
            {
                e.Column.Visible = false;
            }

            if (e.Column.FieldName == "ThuTu")
            {
                e.Column.HeaderText = "Thứ tự";
                e.Column.Width = 10;
                e.Column.MinWidth = 10;
            }

           
        }
        private void ListView_SelectedItemChanged(object sender, EventArgs e)
        {

            CapNhatLabelGia();

        }
        private void DropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Telerik.WinControls.UI.RadDropDownList cb;
            if (sender is Telerik.WinControls.UI.RadDropDownList)
            {
                cb = (Telerik.WinControls.UI.RadDropDownList)sender;
                if (cb == cboMayBoi)
                {
                    CapNhatLabelGia();
                }

            }
        }

        private void btnLayGiay_Click(object sender, EventArgs e)
        {
            //Thong tin ban đầu
            if (this.SoLopLotGiua <= 0)
            {
                MessageBox.Show("Bạn cần lớp số lớp lót");
                txtSoLopLot.Focus();
                return;
            }
            var thongTinBanDau = new ThongTinBanDauChoGiayIn();
            
            var strThongTin = string.Format(" Tờ bồi: {0} x {1}cm" + '\r' + '\n',
                this.ToBoiRong, this.ToBoiCao);
            strThongTin += string.Format("Tờ lót giữa: {0} tờ", thPhBoiNhieuLopPres.SoToLotGiua());

            ///Nếu mới chưa có giấy bồi là mới còn có giáy bồi là edit
            if (this.GiayDeBoiChon == null)
            {
                thongTinBanDau.TinhTrangForm = FormStateS.New;
                thongTinBanDau.ThongTinCanThiet = "[Mới] Chọn giấy bồi" + '\r' + '\n';
                thongTinBanDau.ThongTinCanThiet += strThongTin;
               
            }
            else
            {
                thongTinBanDau.TinhTrangForm = FormStateS.Edit;
                thongTinBanDau.ThongTinCanThiet = "[Sửa] Giấy để bồi";
                thongTinBanDau.ThongTinCanThiet += strThongTin;
            }

            

            //Tao giay de bồi
            var soLuongToBoi = thPhBoiNhieuLopPres.SoToLotGiua();
            var soToBuHao = 0;
            var idGiay = 0;
            var tenGiayIn = "";
            var soToBoiTrenToLon = 0;
            var soToLonTong = 0;
            if (this.GiayDeBoiChon != null)
            {
                soToBuHao = this.GiayDeBoiChon.SoToBoiBuHao;
                soLuongToBoi = this.GiayDeBoiChon.SoToBoiLyThuyet;
                idGiay = this.GiayDeBoiChon.IdGiay;
                tenGiayIn = this.GiayDeBoiChon.TenGiayIn;
                soToBoiTrenToLon = this.GiayDeBoiChon.SoToBoiTrenToLon;
                soToLonTong = this.GiayDeBoiChon.SoToLonTong;
            }
            var mucGiayDeBoi = new GiayDeBoi(this.ToBoiRong, this.ToBoiCao,
                soToBuHao, soLuongToBoi, idGiay, tenGiayIn, 0,
                soToBoiTrenToLon, soToLonTong, 0);//

            //Tiến hành gắn

            var frm = new GiayDeBoiForm(thongTinBanDau, mucGiayDeBoi);
            if (this.GiayDeBoiChon == null)
                frm.Text = "[Mới] BỒI NHIỀU LỚP";
            else
                frm.Text = "[Sửa] BỒI NHIỀU LỚP";

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                XuLyNutOKTrenFormChuanBiGiay_Click(frm);
                //MessageBox.Show(this.CauHinhSanPhamS.Count().ToString());

            }
        }
        private void XuLyNutOKTrenFormChuanBiGiay_Click(GiayDeBoiForm frm)
        {

            switch (frm.TinhTrangForm)
            {
                case FormStateS.New:
                    this.GiayDeBoiChon = frm.DocGiayDeIn();
                    txtThongTinGiayLot.Lines = this.GiayDeBoiChon.ThongTinGiayBoi().ToArray();

                    txtSoLuong.Enabled = false;//Lock lại
                    //Cập nhật tính toán
                    //TinhToanToanBo();
                    break;
                case FormStateS.Edit:
                    //Đổi ID vì thêm mới là có id mới
                    this.GiayDeBoiChon = frm.DocGiayDeIn();
                    txtThongTinGiayLot.Lines = this.GiayDeBoiChon.ThongTinGiayBoi().ToArray();
                    txtSoLuong.Enabled = false;//Lock lại
                    //Cập nhật tính toán
                    //TinhToanToanBo();
                    break;
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            
            CapNhatLabelGia();
            ChoKhongChoNutNhan();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            thPhBoiNhieuLopPres.LamLai();
            ClearCacLabelTinhToan();
            ChoKhongChoNutNhan();
            txtSoLuong.Enabled = true;
        }
     
        private void ChoKhongChoNutNhan()
        {
            ///các đk cho: nếu só lợp >0 thì giấy bồi phải có
            ///số lượng >0
            ///
            bool kq = true;
            if (this.SoLopLotGiua > 0)
            {
                if (this.GiayDeBoiChon == null)
                {
                    MessageBox.Show("Bạn chưa giấy bồi!");
                    kq = false;
                }
                else
                    kq = true;
            }
            else
                if (this.GiayDeBoiChon != null)
                    this.GiayDeBoiChon = null; //lớp giữã sẽ không có

            if (this.SoLuong <= 0 || this.ToBoiCao <=0
                || this.ToBoiRong <= 0)
                kq = false;
            //Bồi thêm phải có 1 lớp
            if (this.KieuBoi == KieuBoiNhieuLop.BoiDap)
            {
                if (this.SoLopLotGiua <= 0)
                {
                    MessageBox.Show("Kiểu bồi này bạn cần ít nhất 1 tờ lót");
                    txtSoLopLot.Focus();
                    kq = false;
                }
            }
            btnNhan.Enabled = kq;
        }
        private void RadioButtons_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Telerik.WinControls.UI.RadRadioButton rb;
            if (sender is Telerik.WinControls.UI.RadRadioButton)
            {
                rb = (Telerik.WinControls.UI.RadRadioButton)sender;
                if (rdbBoiDap.IsChecked)
                {
                    
                    lblSoLopLot.Text = "Số tờ đắp thêm";
                    this.SoLopLotGiua = 1; //ít nhất là 1 lớp thêm
                }
                else
                {
                    lblSoLopLot.Text = "Số tờ lót giữa";
                    this.SoLopLotGiua = 0; //Bắt đầu là 0
                }
            }
        }
  
    }
}
