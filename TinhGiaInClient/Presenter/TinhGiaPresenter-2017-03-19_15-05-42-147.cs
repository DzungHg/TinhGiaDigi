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
        #region Thêm, sửa xóa phần Chào giá
        public void ThemBaiIn (BaiIn baiIn)
        {
            chaoGiaIn.Them_BaiIn(baiIn);
        }
        public void SuaBaiIn (BaiIn baiIn)
        {
            chaoGiaIn.Sua_BaiIn(baiIn);
        }
        public void DocBaiInTheoId (int idBaiIn)
        {
            chaoGiaIn.DocBaiInTheoID(idBaiIn);
        }
        public void XoaBaiIn (BaiIn baiIn)
        {
            chaoGiaIn.Xoa_BaiIn(baiIn);
        }
        public void XoaTatCaBaiIn()
        {
            chaoGiaIn.XoaTatCa_BaiIn();
        }
        public Dictionary<int,List<string>> BaiInS()
        {
            lvwBaiIn.Columns.Add("Id");
            lvwBaiIn.Columns.Add("Tiêu đề");
            lvwBaiIn.Columns.Add("Diễn giải");
            lvwBaiIn.Columns.Add("Số lượng");
            lvwBaiIn.Columns.Add("Đơn vị");
            lvwBaiIn.Columns.Add("Cấu hình SP");
            lvwBaiIn.Columns.Add("Giấy In");
            lvwBaiIn.Columns.Add("SL In");
            lvwBaiIn.Columns.Add("SL Th. Phẩm");
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (BaiIn baiIn in chaoGiaIn.DanhSachBaiIn)
            {
                var lst 
            }
        }
        #endregion
        List<CauHinhSanPham> CauHinhSanPhamS { get; set; }
        List<GiayDeIn> GiayDeInS { get; set; }
        List<GiaIn> GiaInS { get; set; }
        List<MucThanhPham> ThanhPhamS { get; set; }
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
                item.IdHangKH = baiIn.IdHangKH;
                item.TenHangKH = baiIn.TenHangKH;

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
        #region Giá In nhanh
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
                 item.TenBangGiaChon = giaIn.TenBangGiaChon;
                 item.KieuIn = giaIn.KieuIn;
                 item.LoaiBangGia = giaIn.LoaiBangGia;
                 item.SoTrangA4 = giaIn.SoTrangA4;
                 item.TienIn = giaIn.TienIn;                 
                 item.IdBaiIn = giaIn.IdBaiIn;

             }
         }
         public void XoaGiaIn(int giaInID)
         {
             var item = View.GiaInS.Find(x => x.ID == giaInID);
             if (item != null)
             {
                 View.GiaInS.Remove(item);
             }
         }
        #endregion
        #region Thanh pham
         public void ThemThanhPham(MucThanhPham mucTP)
         {
             var tmpCauHinh = View.ThanhPhamS.Where(x => x.ID == mucTP.ID).SingleOrDefault();
             if (tmpCauHinh == null)
             {
                 View.ThanhPhamS.Add(mucTP);
             }

         }
         public void CapNhatThanhPham(MucThanhPham mucTP)
         {
             
         }
         public void XoaThanhPham(int giaInID)
         {
             var item = View.ThanhPhamS.Find(x => x.ID == giaInID);
             if (item != null)
             {
                 View.ThanhPhamS.Remove(item);
             }
         }
#endregion
    }
}
