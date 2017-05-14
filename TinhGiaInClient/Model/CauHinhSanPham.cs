using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Model
{
    public class CauHinhSanPham
    {


        public KhoSanPham KhoSP
        {
            get;
            set;
        }
        private static int _lastIdCauHinh = 0;
        public int IDCauHinh
        { 
            get;set;        
        }
        #region Kích thước sản phẩm
        public float TranLeTren { get; set; }
        public float TranLeDuoi { get; set; }
        public float TranLeTrong { get; set; }
        public float TranLeNgoai { get; set; }
        public float LeTren { get; set; }
        public float LeDuoi { get; set; }
        public float LeTrong { get; set; }
        public float LeNgoai { get; set; }
        public float KhoRongGomLe
        {
            get
            {
                return this.KhoSP.KhoCatRong +
                    this.LeTrong + this.LeNgoai;
            }
        }
        public float KhoCaoGomLe
        {
            get
            {
                return this.KhoSP.KhoCatCao +
                    this.LeTren + this.LeDuoi;
            }
        }
        #endregion
        public int IdMayIn { get; set; }//Tờ in
        public int IdPhapIn { get; set; }
        public string TenPhuongPhapIn { get; set; }
        public string KhoMayIn { get; set; }


        public string ThongTinCauHinh
        {
            get
            {
                var str = "";
                str += string.Format("Khổ cắt: {0} x {1}cm", this.KhoSP.KhoCatRong,
                    this.KhoSP.KhoCatCao) + '\r' + '\n' ;
                str += string.Format("Tràn lề: trên {0}, dưới {1}, trong {2}, ngoài {3}",
                               this.TranLeTren, this.TranLeDuoi,
                               this.TranLeTrong, this.TranLeNgoai) + + '\r' + '\n';
                str += string.Format("Lề: trên {0}, dưới {1}, trong {2}, ngoài {3}",
                               this.LeTren, this.LeDuoi,
                               this.LeTrong, this.LeNgoai) + '\r' + '\n';                
                str += string.Format("Khổ SP gồm lề: {0} x {1}cm",
                    this.KhoRongGomLe, this.KhoCaoGomLe) + '\r' + '\n';

                switch (this.IdPhapIn)
                {
                    case (int)Enumss.PhuongPhapIn.Toner:
                        var toChayDigi = ToInMayDigi.DocTheoId(this.IdMayIn);
                        str += "**In Nhanh: " + '\r' + '\n';
                        str += string.Format("Khổ chạy Max: {0} x {1}cm",
                            toChayDigi.Rong, toChayDigi.Cao) + '\r' + '\n';
                        str += string.Format("Khổ giấy có thể in: {0}",
                            toChayDigi.KhoToChayCoTheIn) + '\r' + '\n';
                        break;
                    case (int)Enumss.PhuongPhapIn.Offset:
                        var mayInOffset = OffsetGiaCong.DocTheoId(this.IdMayIn);
                        str += "**In Offset: " + '\r' + '\n';
                        str += string.Format("Khổ chạy Max: {0} x {1}cm",
                            mayInOffset.KhoInRongMax, mayInOffset.KhoInDaiMax) + '\r' + '\n';
                        str += string.Format("Khổ chạy Min: {0} x {1}cm",
                            mayInOffset.KhoInRongMin, mayInOffset.KhoInDaiMin) + '\r' + '\n';
                        break;
                    case (int)Enumss.PhuongPhapIn.KhongIn:
                        str += "**Không In" + '\r' + '\n';                            
                        break;
                }

                return str;
            }
        }
        public int IdBaiIn { get; set; }
        public CauHinhSanPham(KhoSanPham khoSP, float tranLeTren, float tranLeDuoi,
                        float tranLeTrong, float tranLeNgoai, float leTren,
                        float leDuoi, float leTrong, float leNgoai, int idBaiIn,
                        int idPhuongPhapIn, int idMayIn, string tenPhuongPhapIn, string khoMayIn)
        {
            this.KhoSP = khoSP;

            this.TranLeTren = tranLeTren;            
            this.TranLeDuoi = tranLeDuoi;            
            this.TranLeTrong = tranLeTrong;            
            this.TranLeNgoai = tranLeNgoai;

            this.LeTren = leTren;
            this.LeDuoi = leDuoi;
            this.LeTrong = leTrong;
            this.LeNgoai = leNgoai;
            this.IdBaiIn = idBaiIn;

            this.IdMayIn = idMayIn;
            this.IdPhapIn = idPhuongPhapIn;
            this.TenPhuongPhapIn = tenPhuongPhapIn;
            this.KhoMayIn = khoMayIn;
            //vấn đề id
            _lastIdCauHinh += 1;
            IDCauHinh = _lastIdCauHinh;
        }

        
       
    }
}
