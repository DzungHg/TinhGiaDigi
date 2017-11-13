using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class CauHinhSanPham
    {
        private static int _lastIdCauHinh = 0;

        public float KhoCatRong
        {
            get;
            set;
        }
        public float KhoCatCao
        {
            get;
            set;
        }
      
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
                return this.KhoCatRong +
                    this.LeTrong + this.LeNgoai;
            }
        }
        public float KhoCaoGomLe
        {
            get
            {
                return this.KhoCatCao +
                    this.LeTren + this.LeDuoi;
            }
        }
        #endregion
        public int IdMayIn { get; set; }//Tờ in
        
        public PhuongPhapInS PhuongPhapIn { get; set; }
       
        public string KhoMayIn 
        {
            get
            {
                var khoMayIn = "";
                switch (this.PhuongPhapIn)
                {
                    case PhuongPhapInS.KhongIn:
                        khoMayIn = "";
                        break;
                    case PhuongPhapInS.Offset:
                        khoMayIn = OffsetGiaCong.DocTheoId(this.IdMayIn).TenKhoIn;
                        break;
                    case PhuongPhapInS.Toner:
                        khoMayIn = ToInMayDigi.DocTheoId(this.IdMayIn).Ten;
                        break;
                    default:
                        khoMayIn = "";
                        break;
                }
                return khoMayIn;
            }
            set { ;}
        }
        public float ToChayRong()
        {
            var kq = 0f;
            switch (this.PhuongPhapIn)
            {
                case PhuongPhapInS.KhongIn:
                    kq = 0;
                    break;
                case PhuongPhapInS.Offset:
                    kq = OffsetGiaCong.DocTheoId(this.IdMayIn).KhoInRongMax;
                    break;
                case PhuongPhapInS.Toner:
                    kq = ToInMayDigi.DocTheoId(this.IdMayIn).Rong;
                    break;
                default:
                    kq = 32f;
                    break;
            }
            return kq;
        }
        public float ToChayCao()
        {
            var kq = 0f;
            switch (this.PhuongPhapIn)
            {
                case PhuongPhapInS.KhongIn:
                    kq = 0;
                    break;
                case PhuongPhapInS.Offset:
                    kq = OffsetGiaCong.DocTheoId(this.IdMayIn).KhoInDaiMax;
                    break;
                case PhuongPhapInS.Toner:
                    kq = ToInMayDigi.DocTheoId(this.IdMayIn).Cao;
                    break;
                default:
                    kq = 48.5f;
                    break;
            }
            return kq;
        }
        public string TenPhuongPhapIn
        {
           
            get
            {
                var kq = "Chưa biết";
                switch (this.PhuongPhapIn)
                {
                    case PhuongPhapInS.Toner:
                        kq = "In nhanh";
                        break;
                    case PhuongPhapInS.Offset:
                        kq = "In Offset";
                        break;
                    case PhuongPhapInS.KhongIn:
                        kq = "Không in";
                        break;
                }
                return kq;
            }
        }

        public string ThongTinCauHinh
        {
            get
            {
                var str = "";
                str += string.Format("Khổ cắt: {0} x {1}cm" + '\r' + '\n', this.KhoCatRong,
                    this.KhoCatCao) ;
                str += string.Format("Tràn lề: trên {0}, dưới {1}, trong {2}, ngoài {3}" + '\r' + '\n',
                               this.TranLeTren, this.TranLeDuoi,
                               this.TranLeTrong, this.TranLeNgoai);
                str += string.Format("Lề: trên {0}, dưới {1}, trong {2}, ngoài {3}" + '\r' + '\n',
                               this.LeTren, this.LeDuoi,
                               this.LeTrong, this.LeNgoai);
                str += string.Format("Khổ SP gồm lề: {0} x {1}cm" + '\r' + '\n',
                    this.KhoRongGomLe, this.KhoCaoGomLe) ;

                switch (this.PhuongPhapIn)
                {
                    case PhuongPhapInS.Toner:
                        var toChayDigi = ToInMayDigi.DocTheoId(this.IdMayIn);
                        str += "**In Nhanh: " + '\r' + '\n';
                        str += string.Format("Khổ chạy Max: {0} x {1}cm" + '\r' + '\n',
                            toChayDigi.Rong, toChayDigi.Cao);
                        str += string.Format("Khổ giấy có thể in: {0}" + '\r' + '\n',
                            toChayDigi.KhoToChayCoTheIn);
                        break;
                    case PhuongPhapInS.Offset:
                        var mayInOffset = OffsetGiaCong.DocTheoId(this.IdMayIn);
                        str += "**In Offset: " + '\r' + '\n';
                        str += string.Format("Khổ chạy Max: {0} x {1}cm" + '\r' + '\n',
                            mayInOffset.KhoInRongMax, mayInOffset.KhoInDaiMax);
                        str += string.Format("Khổ chạy Min: {0} x {1}cm" + '\r' + '\n',
                            mayInOffset.KhoInRongMin, mayInOffset.KhoInDaiMin);
                        break;
                    case PhuongPhapInS.KhongIn:
                        str += "**Không In" + '\r' + '\n';                            
                        break;
                }

                return str;
            }
        }
        public int IdBaiIn { get; set; }
        public CauHinhSanPham(float khoCatRong, float khoCatCao, float tranLeTren, float tranLeDuoi,
                        float tranLeTrong, float tranLeNgoai, float leTren,
                        float leDuoi, float leTrong, float leNgoai, int idBaiIn,
                        PhuongPhapInS phuongPhapIn, int idMayIn, string khoMayIn)
        {
            this.KhoCatRong = khoCatRong;
            this.KhoCatCao = khoCatCao;

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
            this.PhuongPhapIn = phuongPhapIn;
            
            this.KhoMayIn = khoMayIn;
            //vấn đề id
            _lastIdCauHinh += 1;
            IDCauHinh = _lastIdCauHinh;
        }

        
       
    }
}
