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
        IViewTinhGia View;
        public TinhGiaPresenter(IViewTinhGia view)
        {
            View = view;
        }
        #region Bài in
        public void ThemBaiIn(BaiIn baiIn)
        {
            var tmpBaiIn = View.BaiInS.Where(x => x.ID == baiIn.ID).SingleOrDefault();
            if (tmpBaiIn == null)
                View.BaiInS.Add(baiIn);

        }
        public void CapNhatBaiIn(BaiIn baiIn)
        {
            var item = View.BaiInS.Find(x => x.ID == baiIn.ID);
            if (item != null)
            {
                item.ID = baiIn.ID;
                item.TieuDe = baiIn.TieuDe;
                item.DienGiai = baiIn.DienGiai;
                item.SoLuong = baiIn.SoLuong;
                item.DonVi = baiIn.DonVi;                

            }

        }
        public void XoaBaiIn(int idBaiIn)
        {
            if (View.BaiInS.Count > 0)
            {
                var tmp = View.BaiInS.Find(x => x.ID == idBaiIn);
                if (tmp != null)
                    View.BaiInS.Remove(tmp);
            }


        }
        #endregion
        #region Cấu hình SP
        public void ThemCauHinhSanPham(CauHinhSanPham cauHinhSP)
        {
            var tmpCauHinh = View.CauHinhSanPhamS.Where(x => x.IDCauHinh == cauHinhSP.IDCauHinh).SingleOrDefault();
            if (tmpCauHinh == null)
            {
                View.CauHinhSanPhamS.Add(cauHinhSP);
                //Trỏ tham chiếu đến 
                View.BaiInS.Find(x => x.ID == cauHinhSP.IdBaiIn).CauHinhSP = cauHinhSP;
            }

        }
        public void CapNhatCauHinhSanPham(CauHinhSanPham cauHinhSP)
        {
            var item = View.CauHinhSanPhamS.Find(x => x.IDCauHinh == cauHinhSP.IDCauHinh);
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
        public void XoaCauHinhSanPham(int idCauHinhSP)
        {
            if (View.CauHinhSanPhamS.Count > 0)
            {
                //Xóa cấu hình trên bài in luôn
                var baIn = View.BaiInS.Find(x => x.ID == idCauHinhSP);
                baIn.CauHinhSP = null; //Ngắt referen
                //Xóa thiệt
                var tmp = View.CauHinhSanPhamS.Find(x => x.IDCauHinh == idCauHinhSP);
                if (tmp != null)
                    View.CauHinhSanPhamS.Remove(tmp);
            }


        }
        #endregion
        #region Giấy in
         public void ThemGiayIn(GiayDeIn giayDeIn)
        {
            var tmpCauHinh = View.GiayDeInS.Where(x => x.ID == giayDeIn.ID).SingleOrDefault();
            if (tmpCauHinh == null)
            {
                View.GiayDeInS.Add(giayDeIn);
                //Trỏ tham chiếu đến 
                View.BaiInS.Find(x => x.ID == giayDeIn.IdBaiIn).GiayDeInIn = giayDeIn;
            }

        }
         public void CapNhatGiayDeIn(GiayDeIn giayDeIn)
         {
             var item = View.GiayDeInS.Find(x => x.ID == giayDeIn.ID);
             if (item != null)
             {
                 item.ID = giayDeIn.ID;
                 item.GiayChon = giayDeIn.GiayChon;
                 item.KhoToChay = giayDeIn.KhoToChay;
                 item.SoLuongToChayLyThuyet = giayDeIn.SoLuongToChayLyThuyet;
                 item.SoLuongToChayBuHao = giayDeIn.SoLuongToChayBuHao;
                 item.SoLuongToLonCan = giayDeIn.SoLuongToLonCan;                 
                 item.TenGiayIn = giayDeIn.TenGiayIn;
                 item.IdBaiIn = giayDeIn.IdBaiIn;

             }
         }
        #endregion
        #region Giá In
         public void ThemGiaIn(GiaIn giaIn)
         {
             var tmpCauHinh = View.GiaInS.Where(x => x.ID == giaIn.ID).SingleOrDefault();
             if (tmpCauHinh == null)
             {
                 View.GiaInS.Add(giaIn);                 
             }

         }
         public void CapNhatGiaIn(GiaIn giaIn)
         {
             var item = View.GiaInS.Find(x => x.ID == giaIn.ID);
             if (item != null)
             {
                 item.ID = giaIn.ID;
                 item.IdBangGiaChon = giaIn.IdBangGiaChon;
                 item.KieuIn = giaIn.KieuIn;
                 item.LoaiBangGia = giaIn.LoaiBangGia;
                 item.SoTrangA4 = giaIn.SoTrangA4;
                 item.TienIn = giaIn.TienIn;                 
                 item.IdBaiIn = giaIn.IdBaiIn;

             }
         }
        #endregion
    }
}
