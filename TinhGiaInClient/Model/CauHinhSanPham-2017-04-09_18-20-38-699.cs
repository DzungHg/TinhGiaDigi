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

        KhoSanPham _khoSP;
        public KhoSanPham KhoSP
        {
            get { return _khoSP; }
            set { _khoSP = value; }
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
        public int IdPhuongPhapIn { get; set; }
        public int PhuongPhapIn { get; set; }
        
       
        public string ThongTinCauHinh
        {
            get
            {
                var str = "";                
                str += string.Format("Khổ SP gồm lề: {0} x {1}cm", 
                    this.KhoRongGomLe, this.KhoCaoGomLe) + '\r' + '\n';
                switch (this.PhuongPhapIn)
                {
                    case (int)Enumss.PhuongPhapIn.Toner:
                    var toChayDigi = ToChayDigi.DocTheoId(this.IdPhuongPhapIn);
                    str += string.Format("Tờ chạy khổ: {0} x {1}cm",
                        toChayDigi.Rong, toChayDigi.Cao) + '\r' + '\n';
                    str += string.Format("Khổ giấy có thể in: {0}",
                        toChayDigi.KhoToChayCoTheIn) + '\r' + '\n';
                    break;
                }
                
                return str;
            }
        }
        public int IdBaiIn { get; set; }
        public CauHinhSanPham(KhoSanPham kho, float tranLeTren, float tranLeDuoi,
                        float tranLeTrong, float tranLeNgoai, float leTren,
                        float leDuoi, float leTrong, float leNgoai, int idBaiIn)
        {
            _khoSP = new KhoSanPham();
            _khoSP.ID = kho.ID;
            _khoSP.KhoCatRong = kho.KhoCatRong;
            _khoSP.KhoCatCao = kho.KhoCatCao;
            _khoSP.Ten = kho.Ten;
            
            this.TranLeTren = tranLeTren;            
            this.TranLeDuoi = tranLeDuoi;            
            this.TranLeTrong = tranLeTrong;            
            this.TranLeNgoai = tranLeNgoai;

            this.LeTren = leTren;
            this.LeDuoi = leDuoi;
            this.LeTrong = leTrong;
            this.LeNgoai = leNgoai;
            this.IdBaiIn = idBaiIn;
            
            //vấn đề id
            _lastIdCauHinh += 1;
            IDCauHinh = _lastIdCauHinh;
        }

        
       
    }
}
