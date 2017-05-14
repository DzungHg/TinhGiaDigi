using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.Presenter
{
    public class GiayDeInPresenter
    {
        IViewGiayDeIn View;
        
        public GiayDeInPresenter(IViewGiayDeIn view, GiayDeIn giayDeIn = null)
        {
            View = view;
            
            //
            if (giayDeIn != null)
            {
                View.ID = giayDeIn.ID;
                View.IdBaiIn = giayDeIn.IdBaiIn;
                View.IdHangKH = giayDeIn.IdHangKhachHang;             
                View.SoLuongSanPham = giayDeIn.SoLuongSanPham;
                View.SoConTrenToChay = giayDeIn.SoConTrenToChay;
                View.SoLuongToChayBuHao = giayDeIn.SoLuongToChayBuHao;
                View.GiayKhachDua = giayDeIn.GiayKhachDua;
                View.GiayChon = giayDeIn.GiayChon;
                View.IdDanhMucGiayChon = giayDeIn.GiayChon.IdDanhMucGiay;
                View.TenGiayIn = giayDeIn.TenGiayIn;
                View.KhoToChay = giayDeIn.KhoToChay;
                View.SoToChayTrenToLon = giayDeIn.SoToChayTrenToLon;
               
                //
              
            }
            //Việc đặt dữ liệu ban đầu do 
            if (View.TinhTrangForm == FormStates.New)
                this.KhoiTaoGiaTriBanDau();

        }
        private void KhoiTaoGiaTriBanDau()
        {

            View.SoToGiayLon = 1;
            View.SoLuongToChayLyThuyet = 1;
            View.SoLuongToChayBuHao = 1;
            View.SoConTrenToChay = 1;
            View.SoToChayTrenToLon = 1;

        }
        public int SoToChayLyThuyetTinh()
        {
            int result = 0;
            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return result;
            //Tiếp nếu quá
            if (View.SoLuongSanPham % View.SoConTrenToChay > 0)//Chia lẻ
                result = View.SoLuongSanPham / View.SoConTrenToChay + 1;
            else
                result = View.SoLuongSanPham / View.SoConTrenToChay;

            return result;
        }
        public int SoToChayTong()
        {
            return this.SoToChayLyThuyetTinh() + View.SoLuongToChayBuHao;

        }
        public int SoToGiayLon()
        {
            int result = 0;
            if (View.SoToChayTrenToLon == 0 || View.SoLuongSanPham <= 0)
                return result;
            //Tiếp nếu qua khỏi
            if (this.SoToChayTong() % View.SoToChayTrenToLon > 0)//Chia lẻ
                result = SoToChayTong() / View.SoToChayTrenToLon + 1;
            else
                result = SoToChayTong() / View.SoToChayTrenToLon;

            return result;
        }
        public Dictionary<int, List<string>> GiayTheoDanhMucS()
        {           
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (Giay giay in Giay.DocGiayTheoDanhMuc(View.IdDanhMucGiayChon).Where(x => !x.KhongCon))
            {
                var lst = new List<string>();
                lst.Add(giay.TenGiay);
                lst.Add(string.Format("{0} g/m2", giay.DinhLuong));
                lst.Add(giay.KhoGiay);
                lst.Add(string.Format("{0:0,0.00}đ/tờ", giay.GiaMua));

                if (giay.TonKho)
                    lst.Add("Có");
                else
                    lst.Add("Không");

                if (giay.KhongCon)
                    lst.Add("Hết");
                else
                    lst.Add("Còn hàng");

                dict.Add(giay.ID, lst);
            }

            return dict;
        }
        public string KhoToChay(int ppIn, int idToIn_MayIn)
        {
            var result = "";
            if (ppIn > 0 && idToIn_MayIn > 0)
            {
                switch (ppIn)
                {
                    case (int)Enumss.PhuongPhapIn.Toner:
                        var toChay = ToInMayDigi.DocTheoId(idToIn_MayIn);
                        result = string.Format("{0} x {1}cm", toChay.Rong, toChay.Cao) ;
                        break;
                    case (int)Enumss.PhuongPhapIn.Offset:
                        result = OffsetGiaCong.DocTheoId(idToIn_MayIn).TenKhoIn;
                        break;
                }
            }

            return result;
        }
        public List<DanhMucGiay> DanhMucTheoNhaCC()
        {
            return DanhMucGiay.LayTheoNhaCungCap(View.TenNhaCC);
        }
        private int TiLeMarkUp(int idDanhMucGiay, int idHangKH)
        {
            var result = 0;
            result = MarkUpLoiNhuanGiay.LayTheoId(idDanhMucGiay, idHangKH).TiLeLoiNhuanTrenDoanhThu;
            return result;
        }

        public decimal GiaBan()
        {
            decimal result = 0;
            decimal tiLeMarkUp = (decimal)TiLeMarkUp(View.GiayChon.IdDanhMucGiay, View.IdHangKH) / 100;
          
            result = View.GiayChon.GiaMua + View.GiayChon.GiaMua * tiLeMarkUp /
                    (1 - tiLeMarkUp);          
            return result;

        }
        public decimal ThanhTien()
        {
            decimal result = 0;
            
            if (!View.GiayKhachDua)
            {
                result = View.SoToGiayLon * GiaBan();
            }

            return result;

        }
        public CauHinhGiayIn DocCauHinhGiay()
        {
            var cauHinhGiay = new CauHinhGiayIn();
            cauHinhGiay.IdGiayChon = View.GiayChon.ID;
            cauHinhGiay.KhoToChay = View.KhoToChay;
            cauHinhGiay.SoConTrenToChay = View.SoConTrenToChay;
            cauHinhGiay.SoLuongToChayLyThuyet = View.SoLuongToChayLyThuyet;
            cauHinhGiay.SoLuongToChayBuHao = View.SoLuongToChayBuHao;
            cauHinhGiay.TongSoToChay = this.SoToChayTong();
            cauHinhGiay.SoToChayTrenToLon = View.SoToChayTrenToLon;
            cauHinhGiay.SoToGiayLon = this.SoToGiayLon();
            cauHinhGiay.GiayKhachDua = View.GiayKhachDua;
            cauHinhGiay.TienGiay = this.ThanhTien();

            return cauHinhGiay;
        }
        public GiayDeIn DocGiayDeIn()
        {
            var giayDeIn = new GiayDeIn(View.GiayChon);
            if (View.TinhTrangForm == FormStates.Edit)
                giayDeIn.ID = View.ID;

            giayDeIn.IdBaiIn = View.IdBaiIn;
            giayDeIn.IdHangKhachHang = View.IdHangKH;
            giayDeIn.SoToChayTrenToLon = View.SoToChayTrenToLon;
            giayDeIn.SoLuongToChayBuHao = View.SoLuongToChayBuHao;
            giayDeIn.SoLuongSanPham = View.SoLuongSanPham;
            giayDeIn.GiayChon = View.GiayChon;
            giayDeIn.TenGiayIn = View.TenGiayIn;
            giayDeIn.KhoToChay = View.KhoToChay;
            giayDeIn.SoConTrenToChay = View.SoConTrenToChay;
            giayDeIn.SoLuongToChayLyThuyet = View.SoLuongToChayLyThuyet;
            giayDeIn.SoLuongToChayBuHao = View.SoLuongToChayBuHao;
            giayDeIn.SoToChayTong = this.SoToChayTong();
            giayDeIn.SoToChayTrenToLon = View.SoToChayTrenToLon;
            giayDeIn.SoLuongToLonCan = this.SoToGiayLon();
            giayDeIn.GiayKhachDua = View.GiayKhachDua;
            giayDeIn.ThanhTien = this.ThanhTien();
            //Về in

            return giayDeIn;
        }
    }
}
