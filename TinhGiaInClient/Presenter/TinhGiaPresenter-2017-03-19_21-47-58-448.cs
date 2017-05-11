using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Presenter
{
    public class TinhGiaPresenter
    {
        IViewTinhGiaIn View;
        ChaoGiaIn chaoGiaIn;
        public TinhGiaPresenter(IViewTinhGiaIn view)
        {
            View = view;
            chaoGiaIn = new ChaoGiaIn(View.NgayTinhGia, View.SoTinhGia, View.TenKhachHang);
        }
        #region phẩn Bài in
        public void ThemBaiIn(BaiIn baiIn)
        {
            chaoGiaIn.Them_BaiIn(baiIn);
        }
        public void SuaBaiIn(BaiIn baiIn)
        {
            chaoGiaIn.Sua_BaiIn(baiIn);
        }
        public BaiIn DocBaiInTheoId(int idBaiIn)
        {
            return chaoGiaIn.DocBaiInTheoID(idBaiIn);
        }
        public void XoaBaiIn(BaiIn baiIn)
        {
            chaoGiaIn.Xoa_BaiIn(baiIn);
        }
        public void XoaTatCaBaiIn()
        {
            chaoGiaIn.XoaTatCa_BaiIn();
        }
        public Dictionary<int, List<string>> BaiInS()
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (BaiIn bIn in chaoGiaIn.DanhSachBaiIn)
            {
                var lst = new List<string>();
                lst.Add(bIn.TieuDe);
                lst.Add(bIn.DienGiai);
                lst.Add(bIn.SoLuong.ToString());
                lst.Add(bIn.DonVi);
                if (bIn.CoCauHinh)
                    lst.Add("Có");
                else lst.Add("Chưa");
                if (bIn.CoGiayIn)
                    lst.Add("Có");
                else lst.Add("Chưa");
                lst.Add(bIn.SoLuongGiaInKemTheo().ToString());
                lst.Add(bIn.SoLuongThanhPhamKem().ToString());

                dict.Add(bIn.ID, lst);//hoàn tất tại đây
            }
            return dict;
        }
        public string TieuDeBaInChon()
        {
            var result = "";
            var baiIn = chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon);
            if (baiIn != null)
                result = baiIn.TieuDe;
            return result;
        }
        #endregion

        #region Phần giá In
        public List<GiaIn> GiaInS()
        {
            return chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiaInS;
        }

        public void ThemGiaIn(GiaIn giaIn)
        {
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).Them_GiaIn(giaIn);
        }
        public void XoaGiaIn(int idGiaIn)
        {
            var giaIn = chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocGiaInTheoID(idGiaIn);
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).Xoa_GiaIn(giaIn);
        }
        public void XoaHetGiaIn()
        {
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).XoaTatCa_GiaIn();
        }
        #endregion


        #region Cấu hình sản phẩm
        public void GanCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP = cauHinhSP;
        }
        public void CapNhatCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            var item = this.DocBaiInTheoId(View.IdBaiInChon).CauHinhSP;
            if (item != null)
            {
                item.IDCauHinh = cauHinhSP.IDCauHinh;
                item.KhoSP.KhoCatRong = cauHinhSP.KhoSP.KhoCatRong;
                item.KhoSP.KhoCatCao = cauHinhSP.KhoSP.KhoCatCao;
                item.TranLeTren = cauHinhSP.TranLeTren;
                item.TranLeDuoi = cauHinhSP.TranLeDuoi;
                item.TranLeTrong = cauHinhSP.TranLeTrong;
                item.TranLeNgoai = cauHinhSP.TranLeNgoai;
                item.LeTren = cauHinhSP.LeTren;
                item.LeDuoi = cauHinhSP.LeDuoi;
                item.LeTrong = cauHinhSP.LeTrong;
                item.LeNgoai = cauHinhSP.LeNgoai;
                item.IdBaiIn = cauHinhSP.IdBaiIn;

            }

        }
        public CauHinhSanPham LayCauHinhSPTheoBaiIn()
        {
            return chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP;
        }
        public void XoaCauHinhSanPham()
        {
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP = null;
        }
        public List<string> TomTatCauHinhSP()
        {
            var lst = new List<string>();
            var cHSP=  chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP;
            if (cHSP != null)
            {                
                
                lst.Add(string.Format("Cắt Rộng: {0}cm", cHSP.KhoSP.KhoCatRong));
                lst.Add(string.Format("Cắt Cao: {0}cm", cHSP.KhoSP.KhoCatCao));
                lst.Add(string.Format("Tràn lề, trên {0}, dưới {1}, trong {2}, ngoài {3}",
                               cHSP.TranLeTren, cHSP.TranLeDuoi, cHSP.TranLeTrong, cHSP.TranLeNgoai));
                lst.Add(string.Format("Lề, trên {0}, dưới {1}, trong {2}, ngoài {3}",
                               cHSP.LeTren, cHSP.LeDuoi, cHSP.LeTrong, cHSP.LeNgoai));
                lst.Add(string.Format("Khổ gồm lề: {0} x {1}cm", cHSP.KhoRongGomLe, cHSP.KhoCaoGomLe));
            }
            return lst;
        }
        #endregion

        #region Giấy in
        public void GanGiayDeIn(GiayDeIn giayDeIn)
        {
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn = giayDeIn;

        }
        public void CapNhatGiayDeIn(GiayDeIn giayDeIn)
        {
            var item = chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn;
            if (item != null)
            {
                item.ID = giayDeIn.ID;
                item.GiayChon = giayDeIn.GiayChon;
                item.GiayKhachDua = giayDeIn.GiayKhachDua;
                item.KhoToChay = giayDeIn.KhoToChay;
                item.SoConTrenToChay = giayDeIn.SoConTrenToChay;
                item.SoLuongToChayLyThuyet = giayDeIn.SoLuongToChayLyThuyet;
                item.SoLuongToChayBuHao = giayDeIn.SoLuongToChayBuHao;
                item.SoLuongToLonCan = giayDeIn.SoLuongToLonCan;
                item.TenGiayIn = giayDeIn.TenGiayIn;
                item.IdBaiIn = giayDeIn.IdBaiIn;

            }
        }
        #endregion

        #region Phần thành phẩm
        public List<MucThanhPham> ThanhPhamS()
        {
            return chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).ThanhPhamS;
        }
        public void ThemThanhPham(MucThanhPham thPham)
        {
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).Them_ThanhPham(thPham);
        }
        public void XoaThanhPham(int idThanhPham)
        {
            var thPham = chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocThanhPhamTheoID(idThanhPham);
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).Xoa_ThanhPham(thPham);
        }
        public void XoaHetThanhPham()
        {
            chaoGiaIn.DocBaiInTheoID(View.IdBaiInChon).XoaTatCa_ThanhPham();
        }
        #endregion


    }
}
