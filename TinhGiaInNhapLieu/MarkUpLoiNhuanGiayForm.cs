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
    public partial class MarkUpLoiNhuanGiayForm : Form
    {
        public MarkUpLoiNhuanGiayForm(int tinhTrangForm)
        {
            InitializeComponent();
            this.TinhTrangForm = tinhTrangForm;
            LoadHangKH(this.TinhTrangForm);

        }
        Dictionary<int, string> nguonHangKH = new Dictionary<int, string>();
        public int IdDanhMuc { get; set; }
        public int IdHangKH { get; set; }
        public string DanhMucGiay
        {
            get { return txtDanhMucGiay.Text; }
            set { txtDanhMucGiay.Text = value; }
        }
        public int TiLeLoiNhuan
        {
            get { return int.Parse(txtTiLeLN.Text); }
            set { txtTiLeLN.Text = value.ToString(); }
        }
        public int TinhTrangForm { get; set; }

        private void LoadHangKH (int tinhTrangForm)
        {
            
            
            foreach(HangKhachHang hang in HangKhachHang.LayTatCa())
            {
                nguonHangKH.Add(hang.ID, hang.Ten);
            }
            cboHangKH.Items.Clear();
            foreach (KeyValuePair<int, string> kv in nguonHangKH)
            {
                cboHangKH.Items.Add(kv.Value);
                cboHangKH.SelectedIndex = 0;
            }
            cboHangKH.DropDownStyle = ComboBoxStyle.DropDownList;
          
        }
        private void LuuDuLieu()
        {
            var idHangKH = 0;  
            switch (this.TinhTrangForm)
            {
                case (int)FormStateS.New:                           
                    idHangKH = nguonHangKH.FirstOrDefault(x=>x.Value == cboHangKH.Text).Key;                    
                    MarkUpLoiNhuanGiay.Them(new MarkUpLoiNhuanGiay {
                        IdDanhMucGiay = this.IdDanhMuc,
                        IdHangKhachHang  = idHangKH,
                        TiLeLoiNhuanTrenDoanhThu = this.TiLeLoiNhuan                                                
                    });
                    break;
                case (int)FormStateS.Edit:
                    idHangKH = nguonHangKH.FirstOrDefault(x => x.Value == cboHangKH.Text).Key;
                    MarkUpLoiNhuanGiay.Sua(new MarkUpLoiNhuanGiay
                    {
                        IdDanhMucGiay = this.IdDanhMuc,
                        IdHangKhachHang = idHangKH,
                        TiLeLoiNhuanTrenDoanhThu = this.TiLeLoiNhuan
                    });
                    break;
            }
        
        }
        private bool KiemTraHopLe(ref string errorMessage)
        {
            var result = true;
            List<string> loiS = new List<string>();

            if (string.IsNullOrEmpty(txtTiLeLN.Text))
                loiS.Add("Lợi nhuận không thể = 0 nhưng không thể rỗng");


            if (loiS.Count > 0)
            {
                result = false;
                foreach (string st in loiS)
                    errorMessage += st + "/";
            }
            //MessageBox.Show("Số lỗi " + loiS.Count().ToString());
            return result;
        }

        private void MarkUpLoiNhuanGiayForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string str = "";
            if (KiemTraHopLe(ref str))
                LuuDuLieu();
        }

        private void MarkUpLoiNhuanGiayForm_Load(object sender, EventArgs e)
        {
            //Cập nhật dữ liêu
            switch (this.TinhTrangForm)
            {
              
                case (int)FormStateS.Edit:
                    var tenHangKH = nguonHangKH.FirstOrDefault(x => x.Key == this.IdHangKH).Value;
                    cboHangKH.SelectedIndex = cboHangKH.Items.IndexOf(tenHangKH);
                    break;

            }
        }
    }
}
