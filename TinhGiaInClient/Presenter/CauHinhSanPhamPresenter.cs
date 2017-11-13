using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInClient.Presenter
{
    public class CauHinhSanPhamPresenter
    {
        IViewCauHinhSanPham View = null;
        CauHinhSanPham CauHinh = null;
        public CauHinhSanPhamPresenter (IViewCauHinhSanPham view, CauHinhSanPham cauHinhSP)
        {
            View = view;
            this.CauHinh = cauHinhSP;
            
                View.IdCauHinhSP = this.CauHinh.IDCauHinh;
                View.IdBaiIn = this.CauHinh.IdBaiIn;
                View.KhoCatRong = this.CauHinh.KhoCatRong;
                View.KhoCatCao = this.CauHinh.KhoCatCao;
                View.TranLeTren = this.CauHinh.TranLeTren;
                View.TranLeDuoi = this.CauHinh.TranLeDuoi;
                View.TranLeTrong = this.CauHinh.TranLeTrong;
                View.TranLeNgoai = this.CauHinh.TranLeNgoai;
                View.LeTren = this.CauHinh.LeTren;
                View.LeDuoi = this.CauHinh.LeDuoi;
                View.LeTrong = this.CauHinh.LeTrong;
                View.LeNgoai = this.CauHinh.LeNgoai;
                View.PhuongPhapIn = this.CauHinh.PhuongPhapIn;
                View.IdToInChon = this.CauHinh.IdMayIn;
               
                //this.SoLuong = cauHinhSP.SoLuong;


            
        }
        private void TrinhBayMacDinh()
        {
            /*
            View.KhoCatCao = 0;
            View.KhoCatRong = 0;
            View.TranLeTren = 0.2f;
            View.TranLeDuoi = 0.2f;
            View.TranLeTrong = 0.2f;
            View.TranLeNgoai = 0.2f;
            View.LeTren = 0.2f;
            View.LeDuoi = 0.2f;
            View.LeTrong = 0.2f;
            View.LeNgoai = 0.2f;
            View.SoLuong = 1;
            View.PhuongPhapIn = PhuongPhapInS.Toner;
             */

        }
        public void KiemTraTranLe_vs_Le()
        {
            
            if (View.LeTren < View.TranLeTren )
            {
                View.LeTren = View.TranLeTren;
            }
            if (View.LeDuoi < View.TranLeDuoi)
            {
                View.LeDuoi = View.TranLeDuoi;
            }
            if (View.LeTrong < View.TranLeTrong)
            {
                View.LeTrong = View.TranLeTrong;
            }
            if (View.LeNgoai < View.TranLeNgoai)
            {
                View.LeNgoai = View.TranLeNgoai;
            }
            
        }
        public void DatLeBangTranLe()
        {
            View.LeTren = View.TranLeTren;
            View.LeDuoi = View.TranLeDuoi;
            View.LeTrong = View.TranLeTrong;
            View.LeNgoai = View.TranLeNgoai;
        }
        public List<ThongTinToChay> ToChayS()
        {
            var lst = new List<ThongTinToChay>();
            switch (View.PhuongPhapIn)
            {
                case PhuongPhapInS.Toner:
                    foreach (ToInMayDigi tCh in ToInMayDigi.DocTatCa())
                    {
                        var thTinToChay = new ThongTinToChay();
                        thTinToChay.ID = tCh.ID;
                        thTinToChay.PhuongPhapIn = View.PhuongPhapIn;
                        thTinToChay.Ten = tCh.Ten;
                        thTinToChay.Rong = tCh.Rong;
                        thTinToChay.Dai = tCh.Cao;
                        thTinToChay.VungInRongMax = tCh.VungInRong;
                        thTinToChay.VungInDaiMax = tCh.VungInCao;
                        thTinToChay.CacKhoToChayCoTheIn = tCh.KhoToChayCoTheIn;
                        thTinToChay.ThuTu = tCh.ThuTu;
                        lst.Add(thTinToChay);
                    }
                    break;
                case PhuongPhapInS.Offset:
                    foreach (OffsetGiaCong tCh in OffsetGiaCong.DocTatCa())
                    {
                        var thTinToChay = new ThongTinToChay();
                        thTinToChay.ID = tCh.ID;
                        thTinToChay.PhuongPhapIn = View.PhuongPhapIn;
                        thTinToChay.Ten = string.Format("[{0}] {1}", tCh.TenNhaCungCap, tCh.Ten);
                        thTinToChay.Rong = tCh.KhoInRongMax;
                        thTinToChay.Dai = tCh.KhoInDaiMax;
                        thTinToChay.VungInRongMax = tCh.KhoInRongMax;
                        thTinToChay.VungInDaiMax = tCh.KhoInDaiMax;
                        thTinToChay.VungInRongMin = tCh.KhoInRongMin;
                        thTinToChay.VungInDaiMin = tCh.KhoInDaiMin;
                        thTinToChay.CacKhoToChayCoTheIn = "Giữa Min Max";
                        thTinToChay.ThuTu = tCh.ThuTu;
                        lst.Add(thTinToChay);
                    }
                    break;
                    /*
                case (int)Enumss.LoaiToIn.HPIndigo:
                case (int)Enumss.LoaiToIn.KhoLon: */
            }
            return lst.OrderBy(x => x.ThuTu).ToList(); ;
        }
        public Dictionary<int, List<string>> TrinhBayToChayDiGiS()
        {
            var dict = new Dictionary<int, List<string>>();
            foreach (ThongTinToChay to in this.ToChayS())
            {
                var lst = new List<string>();
                lst.Add(to.Ten);
                lst.Add(string.Format("{0} x {1}cm", to.Rong, to.Dai));

                dict.Add(to.ID, lst);
            }
            return dict;
        }
        public Dictionary<int, List<string>> TrinhBayToChayOffsetS()
        {
            var dict = new Dictionary<int, List<string>>();
            foreach (ThongTinToChay to in this.ToChayS())
            {
                var lst = new List<string>();
                lst.Add(to.Ten);
                lst.Add(string.Format("Max: {0} x {1}cm", to.Rong, to.Dai));
                lst.Add(string.Format("Min: {0} x {1}cm", to.VungInRongMin, to.VungInDaiMin));
                dict.Add(to.ID, lst);
            }
            return dict;
        }
        public string TrinhBayToChayChon()
        {
            var result = "";
            if (View.IdToInChon <= 0)
                return result;

            var tChay = this.ToChayS().Find(x => x.ID == View.IdToInChon);
            result = "Tên: " + tChay.Ten + '\r' + '\n';
            result += string.Format(" Khổ Tờ chạy: {0} x {1}cm", tChay.Rong, tChay.Dai) + '\r' + '\n';
            result += string.Format(" Khổ vùng in max: {0} x {1}cm", tChay.VungInRongMax, tChay.VungInDaiMax) + '\r' + '\n';
            result += "Khổ tờ chạy có thể in: " + tChay.CacKhoToChayCoTheIn + '\r' + '\n'; 

            return result;
        }
        public float KhoRongGomLe()
        {
            return this.CauHinh.KhoRongGomLe;
        }
        public float KhoCaoGomLe()
        {
            return this.CauHinh.KhoCaoGomLe;
        }
        public string TenPhuongPhapIn()
        {
            var result = "";
            if (View.IdToInChon <= 0)
                return result;

            var tChay = this.ToChayS().Find(x => x.ID == View.IdToInChon);
            switch (tChay.PhuongPhapIn)
            {
                case PhuongPhapInS.Offset:
                    result = "In Offset";
                    break;
                case PhuongPhapInS.Toner:
                    result = "In Nhanh";
                    break;
                case PhuongPhapInS.KhongIn:
                    result = "Không in";
                    break;
            }            
            return result;
        }
        public string KhoMayInChon()
        {
            var result = "";
            if (View.IdToInChon <= 0)
                return result;

            var tChay = this.ToChayS().Find(x => x.ID == View.IdToInChon);

            result = string.Format("{0} x {1}cm", tChay.Rong, tChay.Dai);
            return result;

        }
        private void CapNhatCauHinhSanPham()
        {
            if (this.CauHinh != null)
            {
                this.CauHinh.IDCauHinh = View.IdCauHinhSP;
                this.CauHinh.IdBaiIn = View.IdBaiIn;
                this.CauHinh.KhoCatRong = View.KhoCatRong;
                this.CauHinh.KhoCatCao = View.KhoCatCao;
                this.CauHinh.TranLeTren = View.TranLeTren;
                this.CauHinh.TranLeDuoi = View.TranLeDuoi;
                this.CauHinh.TranLeTrong = View.TranLeTrong;
                this.CauHinh.TranLeNgoai = View.TranLeNgoai;
                this.CauHinh.LeTren = View.LeTren;
                this.CauHinh.LeDuoi = View.LeDuoi;
                this.CauHinh.LeTrong = View.LeTrong;
                this.CauHinh.LeNgoai = View.LeNgoai;
                this.CauHinh.IdMayIn = View.IdToInChon;
                this.CauHinh.PhuongPhapIn = View.PhuongPhapIn;
                this.CauHinh.KhoMayIn = View.KhoInChon;
            }
        }
        public CauHinhSanPham DocCauHinhSanPham()
        {
            CapNhatCauHinhSanPham();//Cập nhật trước
            return this.CauHinh;
        }
    }
}
