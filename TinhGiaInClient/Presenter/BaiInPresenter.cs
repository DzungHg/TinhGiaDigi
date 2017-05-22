using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinhGiaInClient.Model;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Presenter
{
    public class BaiInPresenter
    {
        IViewBaiIn View;
        BaiIn baiIn;
        public BaiInPresenter(IViewBaiIn view)
        {
            View = view;
            baiIn = new BaiIn(View.DienGiai);
            
            //Để nếu sửa bài in thì lấy Id cũ
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:                   
                    break;
                case FormStateS.Edit:
                    baiIn.ID = View.ID;                   
                    break;
            }
            
        }
        
        public string TenHangKhachHang()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).Ten;

        }
      
       
        public void TrinhBayBaiIn()
        {
            switch(View.TinhTrangForm)
            {
                case FormStateS.New:
                    View.SoLuong = 10;
                    View.TieuDe = "Bài in";
                    View.DienGiai = "Diễn giải bài in";
                    View.DonViTinh = "??";
                   
                    break;
                case FormStateS.Edit:
                    //Không có trong database nên làm sau
                    
                    break;
            }
            View.ID = baiIn.ID;
        }
        public BaiIn DocBaiIn()
        {
            //Điền 1 số dữ liệu cơ bản từ form
            //baiIn.ID = View.ID; //không cần ID tự tạo
            baiIn.TieuDe = View.TieuDe;
            baiIn.DienGiai = View.DienGiai;
            baiIn.IdHangKH = View.IdHangKhachHang;
            baiIn.SoLuong = View.SoLuong;
            baiIn.DonVi = View.DonViTinh;
            

            return baiIn;
        }
      

        #region Phần giá In
        public List<MucTinGiaIn> GiaInS()
        {
            return baiIn.GiaInS;
        }
        public Dictionary<int, List<string>> TrinhBayGiaInS()
        {
            var dict = new Dictionary<int, List<string>>();
            var donViTrang = "";
            var phuongPhapIn = "";
            foreach (MucTinGiaIn giaIn in this.GiaInS())
            {
                var lst = new List<string>();
                lst.Add(giaIn.IdBaiIn.ToString());
                
                
                switch (giaIn.PhuongPhapIn)
                {
                    case PhuongPhapInS.Toner:
                        donViTrang = "A4";
                        phuongPhapIn = "KTS";
                        break;
                    case PhuongPhapInS.Offset:
                        donViTrang = "mặt";
                        phuongPhapIn = "Offset";
                        break;
                    default:
                        donViTrang = "?";
                        phuongPhapIn = "?";
                        break;
                }
                lst.Add(phuongPhapIn);
                lst.Add(giaIn.DienGiaiMayIn);
                lst.Add(string.Format("{0:0,0} {1}", giaIn.SoTrangIn, donViTrang));
                lst.Add(string.Format("{0:0,0.00}đ/{1}", giaIn.GiaTBTrang, donViTrang));
                lst.Add(string.Format("{0:0,0.00}đ", giaIn.TienIn));
                dict.Add(giaIn.ID, lst);

            }
            return dict;
        }
        public void ThemGiaIn(MucTinGiaIn giaIn)
        {
            baiIn.Them_GiaIn(giaIn);
        }
        public void SuaGiaIn(MucTinGiaIn giaIn)
        {
            baiIn.Sua_GiaIn(giaIn);
        }
        public void XoaGiaIn(int idGiaIn)
        {            
            var giaIn = baiIn.DocGiaInTheoID(idGiaIn);
            baiIn.Xoa_GiaIn(giaIn);
        }
        public void XoaHetGiaIn()
        {
            baiIn.XoaTatCa_GiaIn();
        }
        public MucTinGiaIn LayGiaInTheoId(int idGiaIn)
        {
            return baiIn.DocGiaInTheoID(idGiaIn);
        }
        #endregion


        #region Cấu hình sản phẩm
        public void GanCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            baiIn.CauHinhSP = cauHinhSP;
        }
        public void CapNhatCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            var item = baiIn.CauHinhSP;
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
                item.IdMayIn = cauHinhSP.IdMayIn;
                item.PhuongPhapIn = cauHinhSP.PhuongPhapIn;

            }

        }
        public CauHinhSanPham LayCauHinhSPTheoBaiIn()
        {
            return baiIn.CauHinhSP;
        }
        public void XoaCauHinhSanPham()
        {
            baiIn.CauHinhSP = null;
        }
        public string TomTatCauHinhSP()
        {
            var result = "";
            var cHSP = this.DocBaiIn().CauHinhSP;
            if (cHSP != null)
            {
                result = cHSP.ThongTinCauHinh;
            }
            return result;
        }
        #endregion

        #region Giấy in
        public void GanGiayDeIn(GiayDeIn giayDeIn)
        {
            baiIn.GiayDeInIn = giayDeIn;

        }
        public void CapNhatGiayDeIn(GiayDeIn giayDeIn)
        {
            baiIn.GiayDeInIn = giayDeIn;
           
        }
        public void XoaGiayDeIn()
        {
            baiIn.GiayDeInIn = null;
        }
        public List<string> TomTatGiayDeIn()
        {
            var lst = new List<string>();
            var giayDeIn = baiIn.GiayDeInIn;
            if (giayDeIn != null)
            {
                var giay = Giay.DocGiayTheoId(giayDeIn.IdGiay);
                lst.Add(string.Format("Giấy chọn: {0} ", giay.TenGiay));
                lst.Add(string.Format("Giấy tên theo bài: {0}", giayDeIn.TenGiayIn));
                lst.Add(string.Format("Định lượng: {0}g/m2", giay.DinhLuong));
                lst.Add(string.Format("Khổ tờ chạy {0}", giayDeIn.KhoToChay));
                lst.Add(string.Format("Số con / tờ chạy: {0}", giayDeIn.SoConTrenToChay));
                lst.Add(string.Format("Số lượng tờ chạy tính: {0} tờ", giayDeIn.SoToChayLyThuyet));
                lst.Add(string.Format("Số lượng tờ chạy bù hao: {0} tờ", giayDeIn.SoToChayBuHao));
                lst.Add(string.Format("Số lượng tờ chạy tổng: {0} tờ", giayDeIn.SoToChayTong));
                lst.Add(string.Format("Số lượng tờ lớn: {0} tờ", giayDeIn.SoToLonTong));
                lst.Add(string.Format("Tiền giấy: {0:0,0.00đ}", giayDeIn.ThanhTienGiay));
                var giayKhach = "";
                if (giayDeIn.GiayKhachDua)
                    giayKhach = "Giấy khách";
                else
                    giayKhach = "123in";

                lst.Add(string.Format("Giấy khách đưa? {0}", giayKhach));
            }
            return lst;
        }
        public GiayDeIn LayGiayDeInTheoBaiIn()
        {
            return baiIn.GiayDeInIn;
        }
        #endregion

        #region Phần thành phẩm
        public List<MucThanhPham> ThanhPhamS()
        {
            return baiIn.ThanhPhamS;
        }
        //Trình bày list view
        public Dictionary<int, List<string>> TrinhBayThanhPhamS()
        {
            var dict = new Dictionary<int, List<string>>();            
            foreach (MucThanhPham mucThPh in this.ThanhPhamS())
            {
                var lst = new List<string>();
                lst.Add(mucThPh.IdBaiIn.ToString());
                lst.Add(baiIn.TieuDe);
                var tenTP = "";
                switch (mucThPh.LoaiThPh)
                {
                    case LoaiThanhPhamS.CanPhu:
                        tenTP = mucThPh.TenThPhMoRong;
                        break;
                    default:
                        tenTP = mucThPh.TenThPh;
                        break;
                }
                lst.Add(tenTP);
                lst.Add(mucThPh.ThongTinHangKH);
                lst.Add(mucThPh.ThongTinTyLeMarkUp);
                lst.Add(string.Format("{0} {1}", mucThPh.SoLuong, mucThPh.DonViTinh));
                lst.Add(string.Format("{0:0,0.00}đ", mucThPh.ThanhTien));

                dict.Add(mucThPh.ID, lst);
            }
            return dict;
        }
        public void ThemThanhPham(MucThanhPham thPham)
        {
            baiIn.Them_ThanhPham(thPham);
        }
        public void XoaThanhPham(int idThanhPham)
        {
            var thPham = baiIn.DocThanhPhamTheoID(idThanhPham);
            baiIn.Xoa_ThanhPham(thPham);
        }
        public void XoaHetThanhPham()
        {
            baiIn.XoaTatCa_ThanhPham();
        }
        public MucThanhPham LayThanhPhamTheoId(int idThPham)
        {
            return baiIn.DocThanhPhamTheoID(idThPham);
        }
        #endregion

        public List<string> TomTatNoiDungBaiIn_ChaoKH()
        {
            List<string> lst = new List<string>();

            foreach (KeyValuePair<string, string> kvp in this.DocBaiIn().TomTat_ChaoKH())
            {
                lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value)); 
            }
            return lst;
        }
    }

}
