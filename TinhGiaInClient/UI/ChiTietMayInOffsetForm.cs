using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.UI
{
    public partial class ChiTietMayInOffsetForm : Telerik.WinControls.UI.RadForm
    {
        public ChiTietMayInOffsetForm(int idMayInOffsetGiaCong = 0)
        {
            InitializeComponent();
            this.IdMayInOffsetGiaCong = idMayInOffsetGiaCong;
        }
        public int IdMayInOffsetGiaCong
        { get; set; }
        private void TrinhBayChiTiet()
        {
            if (this.IdMayInOffsetGiaCong <= 0)
            {
                txtChiTiet.Clear();
                return;
            }
            //Vượt
            var lst = new List<string>();
            var mayIn = OffsetGiaCong.DocTheoId(this.IdMayInOffsetGiaCong);
            lst.Add(string.Format("Tên: {0}", mayIn.TenMoRong));
            lst.Add(string.Format("Khổ in max (RxC): {0} x {1}cm", mayIn.KhoInRongMax, mayIn.KhoInDaiMax));
            lst.Add(string.Format("Khổ in min (RxC): {0} x {1}cm", mayIn.KhoInRongMin, mayIn.KhoInDaiMin));
            lst.Add(string.Format("Nhà in: {0}", mayIn.TenNhaCungCap));
            var strT = "";
            if (mayIn.TuTroNhip)
            { 
                strT = "Có";
                lst.Add(string.Format("Tự trở nhíp: {0}", strT));
            }
            lst.Add(string.Format("Giá công in: {0:0,0.00}đ / bài", mayIn.GiaCongIn));
            lst.Add(string.Format("Số mặt tối đa: {0}", mayIn.SoMatInCoBan));
            lst.Add(string.Format("Giá mặt vượt tối đa: {0:0,00.00}đ  /mặt", mayIn.GiaInMoiMatVuotCoBan));
            lst.Add(string.Format("Số tờ giấy bù hao tối thiểu: {0} tờ", mayIn.GiaInMoiMatVuotCoBan));

            //
            txtChiTiet.Lines = lst.ToArray();

        }

        private void ChiTietMayInOffsetForm_SizeChanged(object sender, EventArgs e)
        {
            txtChiTiet.Width = this.ClientSize.Width - 10;
            txtChiTiet.Left = (this.ClientSize.Width - txtChiTiet.Width) / 2;
            txtChiTiet.Height = this.ClientSize.Height - btnClose.Height - 20;
            txtChiTiet.Top = 5;

            btnClose.Left = (this.ClientSize.Width - btnClose.Width) / 2;
            btnClose.Top = txtChiTiet.Top + txtChiTiet.Height + 5;

        }

        private void ChiTietMayInOffsetForm_Load(object sender, EventArgs e)
        {
            TrinhBayChiTiet();
        }
    }
}
