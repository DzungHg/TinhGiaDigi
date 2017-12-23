using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Model
{
    public class GiaInOffsetGiaCong
    {
        public OffsetGiaCong MayInOffset { get; set; }
        public int SoMatIn { get; set; }
        public int TyLeMarkUp { get; set; }
        public KieuInOffsetS KieuInOffset { get; set; }       
        public GiaInOffsetGiaCong(OffsetGiaCong mayInOffset, int soMatIn, int tyLeMarkUp,
            KieuInOffsetS kieuInOffset )
        {
            this.MayInOffset = mayInOffset;
            this.SoMatIn = soMatIn;
            this.TyLeMarkUp = tyLeMarkUp;
            this.KieuInOffset = kieuInOffset;
            
        }
        private decimal PhiInGiaCong()
        {
            if (this.MayInOffset == null || this.SoMatIn <= 0)
                return 0;
            ///Nếu in tự trở chỉ tính 1 lần in, nếu in AB tính 2 lần in
            ///Nếu số trang vượi số trang cơ bản cho phép sẽ tính số trang còn lại theo giá phụ trội            
            decimal tienInGiaCong = 0;
            var giaInMotLan = this.MayInOffset.GiaCongIn;
            var soMatCoBan = this.MayInOffset.SoMatInCoBan;
            var giaMotMatVuotCoBan = this.MayInOffset.GiaInMoiMatVuotCoBan;
            var soMatInVuotCoBan = 0;

            switch (this.KieuInOffset)
            {
                case KieuInOffsetS.MotMat:
                    if (this.SoMatIn - soMatCoBan > 0)
                        soMatInVuotCoBan = this.SoMatIn - soMatCoBan;
                    tienInGiaCong = giaInMotLan + soMatInVuotCoBan * giaMotMatVuotCoBan;
                    break;
                case KieuInOffsetS.TuTro:
                case KieuInOffsetS.TuTroNhip:
                    if (this.SoMatIn - soMatCoBan > 0)
                        soMatInVuotCoBan = this.SoMatIn - soMatCoBan;
                    tienInGiaCong = giaInMotLan + soMatInVuotCoBan * giaMotMatVuotCoBan;
                    break;
                case KieuInOffsetS.AB:// là in 2 kẽm
                    if (this.SoMatIn / 2 - soMatCoBan > 0)
                        soMatInVuotCoBan = (this.SoMatIn /2 - soMatCoBan) * 2;
                    tienInGiaCong = (giaInMotLan * 2) + soMatInVuotCoBan * giaMotMatVuotCoBan;
                    break;
            }
                        
            return tienInGiaCong;
        }
       
     
        public decimal ThanhTien_In()
        {
            decimal result = 0;
            decimal tyLeMK = (decimal)this.TyLeMarkUp / 100;
            decimal tienInBan = this.PhiInGiaCong() + this.PhiInGiaCong() * tyLeMK / (1 - tyLeMK);
            result = tienInBan;
            return result;
        }
    }
}
