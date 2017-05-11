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
        TinhGiaIn tinhGiaIn;
        public TinhGiaPresenter(IViewTinhGiaIn view)
        {
            View = view;
            tinhGiaIn = new TinhGiaIn();
        }
        #region phần Tính giá
        public void LuuTinhGia()
        {
            switch (View.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:
                    tinhGiaIn.Ngay = View.NgayTinhGia;
                    tinhGiaIn.So = View.So;
                    tinhGiaIn.TenKhachHang = View.TenKhachHang;
                    tinhGiaIn.LienHe = View.LienHe;
                    tinhGiaIn.TenNhanVien = View.TenNhanVien;
                    break;
            }
        }
        #endregion
        #region phẩn Bài in
        public void ThemBaiIn(BaiIn baiIn)
        {
            tinhGiaIn.Them_BaiIn(baiIn);
        }
        public void SuaBaiIn(BaiIn baiIn)
        {
            tinhGiaIn.Sua_BaiIn(baiIn);
        }
        public BaiIn DocBaiInTheoId(int idBaiIn)
        {
            return tinhGiaIn.DocBaiInTheoID(idBaiIn);
        }
        public void XoaBaiIn(BaiIn baiIn)
        {
            tinhGiaIn.Xoa_BaiIn(baiIn);
        }
        public void XoaTatCaBaiIn()
        {
            tinhGiaIn.XoaTatCa_BaiIn();
        }
        public Dictionary<int, List<string>> BaiInS()
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (BaiIn bIn in tinhGiaIn.DanhSachBaiIn)
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
            var baiIn = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon);
            if (baiIn != null)
                result = baiIn.TieuDe;
            return result;
        }
        #endregion

        #region Phần giá In
        public List<GiaIn> GiaInS()
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiaInS;
        }

        public void ThemGiaIn(GiaIn giaIn)
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).Them_GiaIn(giaIn);
        }
        public void XoaGiaIn(int idGiaIn)
        {
            var giaIn = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocGiaInTheoID(idGiaIn);
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).Xoa_GiaIn(giaIn);
        }
        public void XoaHetGiaIn()
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).XoaTatCa_GiaIn();
        }
        public GiaIn LayGiaInTheoId(int idGiaIn)
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocGiaInTheoID(idGiaIn);
        }
        #endregion


        #region Cấu hình sản phẩm
        public void GanCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP = cauHinhSP;
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
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP;
        }
        public void XoaCauHinhSanPham()
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP = null;
        }
        public List<string> TomTatCauHinhSP()
        {
            var lst = new List<string>();
            var cHSP=  tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP;
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
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn = giayDeIn;

        }
        public void CapNhatGiayDeIn(GiayDeIn giayDeIn)
        {
            var item = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn;
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
        public void XoaGiayDeIn()
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn = null;
        }
        public List<string> TomTatGiayDeIn()
        {
            var lst = new List<string>();
            var giayDeIn = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn;
            if (giayDeIn != null)
            {
                lst.Add(string.Format("Giấy chọn: {0} ", giayDeIn.GiayChon.TenGiay));
                lst.Add(string.Format("Giấy tên theo bài: {0}", giayDeIn.TenGiayIn));
                lst.Add(string.Format("Định lượng: {0}g/m2", giayDeIn.GiayChon.DinhLuong));
                lst.Add(string.Format("Khổ tờ chạy {0}", giayDeIn.KhoToChay));
                lst.Add(string.Format("Số con / tờ chạy: {0}", giayDeIn.SoConTrenToChay));
                lst.Add(string.Format("Số lượng tờ chạy tính: {0} tờ", giayDeIn.SoLuongToChayLyThuyet));
                lst.Add(string.Format("Số lượng tờ chạy bù hao: {0} tờ", giayDeIn.SoLuongToChayBuHao));
                lst.Add(string.Format("Số lượng tờ chạy tổng: {0} tờ", giayDeIn.SoToChayTong));
                lst.Add(string.Format("Số lượng tờ lớn: {0} tờ", giayDeIn.SoLuongToLonCan));
                lst.Add(string.Format("Tiền giấy: {0:0,0.00đ}", giayDeIn.ThanhTien));
                lst.Add(string.Format("Giấy khách đưa? {0}", giayDeIn.GiayKhachDua));
            }
            return lst;
        }
        public GiayDeIn LayGiayDeInTheoBaiIn()
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn;
        }
        #endregion

        #region Phần thành phẩm
        public List<MucThanhPham> ThanhPhamS()
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).ThanhPhamS;
        }
        public void ThemThanhPham(MucThanhPham thPham)
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).Them_ThanhPham(thPham);
        }
        public void XoaThanhPham(int idThanhPham)
        {
            var thPham = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocThanhPhamTheoID(idThanhPham);
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).Xoa_ThanhPham(thPham);
        }
        public void XoaHetThanhPham()
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).XoaTatCa_ThanhPham();
        }
        public MucThanhPham LayThanhPhamTheoId(int idThPham)
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocThanhPhamTheoID(idThPham);
        }
        #endregion



    }
}
