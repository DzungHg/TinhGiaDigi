using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;


namespace TinhGiaInClient.Presenter
{
    public class CauHinhSanPhamPresenter
    {
        IViewCauHinhSanPham View = null;
        public CauHinhSanPhamPresenter (IViewCauHinhSanPham view, CauHinhSanPham cauHinhSP)
        {
            View = view;
            if (cauHinhSP != null)
            {
                View.IdCauHinhSP = cauHinhSP.IDCauHinh;
                View.IdBaiIn = cauHinhSP.IdBaiIn;
                View.KhoCatRong = cauHinhSP.KhoSP.KhoCatRong;
                View.KhoCatCao = cauHinhSP.KhoSP.KhoCatCao;
                View.TranLeTren = cauHinhSP.TranLeTren;
                View.TranLeDuoi = cauHinhSP.TranLeDuoi;
                View.TranLeTrong = cauHinhSP.TranLeTrong;
                View.TranLeNgoai = cauHinhSP.TranLeNgoai;
                View.LeTren = cauHinhSP.LeTren;
                View.LeDuoi = cauHinhSP.LeDuoi;
                View.LeTrong = cauHinhSP.LeTrong;
                View.LeNgoai = cauHinhSP.LeNgoai;
                View.IdPhuongPhapIn = cauHinhSP.IdPhapIn;
                View.IdToInChon = cauHinhSP.IdMayIn;
                //this.SoLuong = cauHinhSP.SoLuong;


            }
            if (View.TinhTrangForm == FormStates.New)
                this.TrinhBayMacDinh();
        }
        private void TrinhBayMacDinh()
        {
            
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
            View.IdPhuongPhapIn = (int)Enumss.PhuongPhapInS.Toner;

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
            //Cập nhật luôn
            View.KhoRongGomLe = View.KhoCatRong + View.LeTrong + View.LeNgoai;
            View.KhoCaoGomLe = View.KhoCatCao + View.LeTren + View.LeDuoi;
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
            switch (View.IdPhuongPhapIn)
            {
                case (int)Enumss.PhuongPhapInS.Toner:
                    foreach (ToInMayDigi tCh in ToInMayDigi.DocTatCa())
                    {
                        var thTinToChay = new ThongTinToChay();
                        thTinToChay.ID = tCh.ID;
                        thTinToChay.Loai = View.IdPhuongPhapIn;
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
                case (int)Enumss.PhuongPhapInS.Offset:
                    foreach (OffsetGiaCong tCh in OffsetGiaCong.DocTatCa())
                    {
                        var thTinToChay = new ThongTinToChay();
                        thTinToChay.ID = tCh.ID;
                        thTinToChay.Loai = View.IdPhuongPhapIn;
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
        public string TenPhuongPhapIn()
        {
            var result = "";
            if (View.IdToInChon <= 0)
                return result;

            var tChay = this.ToChayS().Find(x => x.ID == View.IdToInChon);
            switch (tChay.Loai)
            {
                case (int)Enumss.PhuongPhapInS.Offset:
                    result = "In Offset";
                    break;
                case (int)Enumss.PhuongPhapInS.Toner:
                    result = "In Nhanh";
                    break;
                case (int)Enumss.PhuongPhapInS.KhongIn:
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
        public CauHinhSanPham DocCauHinhSanPham()
        {
            var ketQua = new CauHinhSanPham(new KhoSanPham
            {
                ID = 0,
                KhoCatRong = View.KhoCatRong,
                KhoCatCao = View.KhoCatCao,
                Ten = "",
                ThuTu = 0
            },
                View.TranLeTren, View.TranLeDuoi, View.TranLeTrong, View.TranLeNgoai,
                View.LeTren, View.LeDuoi, View.TranLeTrong, View.LeNgoai, View.IdBaiIn,
                View.IdPhuongPhapIn, View.IdToInChon, this.TenPhuongPhapIn(),
                this.KhoMayInChon());

            if (View.TinhTrangForm == FormStates.Edit)
                ketQua.IDCauHinh = View.IdCauHinhSP; //Tránh tự tăng id khi tạo mới

            return ketQua;

        }
    }
}
