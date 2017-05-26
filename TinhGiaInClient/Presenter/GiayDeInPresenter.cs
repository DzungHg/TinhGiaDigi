using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Presenter
{
    public class GiayDeInPresenter
    {
        IViewGiayDeIn View;
      
        public GiayDeInPresenter(IViewGiayDeIn view, GiayDeIn giayDeIn = null)
        {
            View = view;
            //Việc đặt dữ liệu ban đầu do 
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:
                    this.KhoiTaoGiaTriBanDau();
                  
                    break;
                case FormStateS.Edit: //Chắc chắn có giấy
                    View.ID = giayDeIn.ID;
                    View.IdBaiIn = giayDeIn.IdBaiIn;                                        
                    View.SoConTrenToChay = giayDeIn.SoConTrenToChay;
                    View.SoLuongToChayBuHao = giayDeIn.SoToChayBuHao;
                    View.GiayKhachDua = giayDeIn.GiayKhachDua;                    
                    View.TenGiayIn = giayDeIn.TenGiayIn;
                    View.ToChayRong = giayDeIn.ToChayRong;
                    View.ToChayDai = giayDeIn.ToChayDai;
                    View.SoToChayTrenToLon = giayDeIn.SoToChayTrenToLon;
                   
                    break;

            }
            
                     

        }
        private void KhoiTaoGiaTriBanDau()
        {            
            
            View.SoLuongToChayBuHao = 1;
            View.SoConTrenToChay = 1;
            View.SoToChayTrenToLon = 1;
            View.ToChayDai = 1;
            View.ToChayRong = 1;

        }
        public int SoToChayLyThuyetTinh()
        {
         

            int kq = 0;
            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return kq;
            //Tiếp nếu quá
            if (View.SoLuongSanPham % View.SoConTrenToChay > 0)//Chia lẻ
                kq = View.SoLuongSanPham / View.SoConTrenToChay + 1;
            else
                kq = View.SoLuongSanPham / View.SoConTrenToChay;

            return kq;

         
        }
        public int SoToChayTong()
        {
            int result = 0;

            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return result;
            //Tiếp nếu quá
            result = SoToChayLyThuyetTinh() + View.SoLuongToChayBuHao;

            return result;

        }
        public int SoToGiayLon()
        {

            int kq = 0;
            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return kq;
            //Tiếp nếu quá
            if (SoToChayTong()  % View.SoToChayTrenToLon > 0)//Chia lẻ
                kq = SoToChayTong() / View.SoToChayTrenToLon + 1;
            else
                kq = SoToChayTong() / View.SoToChayTrenToLon;

            return kq;
        }
       
    
       
        private int TyLeMarkUp()
        {
            var result = 0;
            if (View.IdGiay > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiay);
                result = MarkUpLoiNhuanGiay.LayTheoId(giay.IdDanhMucGiay, View.IdHangKH).TiLeLoiNhuanTrenDoanhThu;
            }
            return result;
        }

        public decimal GiaBan()
        {
            decimal result = 0;
            if (!View.GiayKhachDua && View.IdGiay > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiay);
                var giaGiay = new GiaGiay(giay, TyLeMarkUp());
                result = giaGiay.GiaBan();
            }
            return result;
        }
        public decimal ThanhTien()
        {
            return GiaBan() * View.SoToGiayLon;

        }
       
        public GiayDeIn DocGiayDeIn()
        {
            var giayDeIn = new GiayDeIn(View.ToChayRong, View.ToChayDai,
                View.SoConTrenToChay, View.SoLuongToChayBuHao,
                this.SoToChayLyThuyetTinh(), this.SoToChayTong(),
                View.GiayKhachDua, View.IdGiay,
                View.TenGiayIn, View.IdBaiIn, View.SoToChayTrenToLon,
                View.SoToGiayLon, this.ThanhTien());
            

            if (View.TinhTrangForm == FormStateS.Edit)
                giayDeIn.ID = View.ID;
            

            return giayDeIn;
        }
    }
}
