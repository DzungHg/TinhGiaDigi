using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Support
{
    public class PhiInOffsetGCMotKem
    {
        public OffsetGiaCong MayInOffset { get; set; }
        public int SoMatIn { get; set; }
        public PhiInOffsetGCMotKem(OffsetGiaCong mayInOffset, int soMatIn)
        {
            this.MayInOffset = mayInOffset;
            this.SoMatIn = soMatIn;
        }
        public decimal PhiIn()
        {
            var tienInGiaCong = 0m;
            if (this.MayInOffset == null || this.SoMatIn <= 0)
                return 0;

            var giaInMotLan = this.MayInOffset.GiaCongIn;
            var soMatCoBan = this.MayInOffset.SoMatInCoBan;
            var giaMotMatVuotCoBan = this.MayInOffset.GiaInMoiMatVuotCoBan;
            var soMatInVuotCoBan = 0;

            if (this.SoMatIn - soMatCoBan > 0)
                soMatInVuotCoBan = this.SoMatIn - soMatCoBan;
            tienInGiaCong = giaInMotLan + soMatInVuotCoBan * giaMotMatVuotCoBan;

            return tienInGiaCong;
        }
    }
}
