using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInNhapLieu.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.Presenter
{
    public class GiayPresenter
    {
        IViewGiay View;
        
       
        public GiayPresenter(IViewGiay view)
        {
            View = view;
        }
        public void AddNewPaper()
        {
            
            
            
        }
        public void TrinhBayGiay()
        {
            switch (View.TinhTrangForm)
            {
                case (int)FormStateS.New:
                    View.DinhLuong = 0;
                    View.KhoGiay = "Khổ";
                    View.DienGiai = "Diễn giải";
                    View.TenGiay = "giấy";
                    View.MaGiayNhaCungCap = "Mã NCC";
                    View.MaTuDat = "";
                    View.GiaMua = 250;
                    View.ChieuNgan = 32;
                    View.ChieuDai = 47;
                    View.TenGiayMoRong = "";
                    View.ThuTu = 0;
                    View.GiaMua = 0;
                    View.KhongCon = false;
                    View.TonKho = false;
                    //View.TenDanhMucGiayChon = DanhMucGiay.DocTheoId(View.IdDanhMucGiay).Ten;
                    break;

                case (int)FormStateS.Edit:
                    var giay = Giay.DocGiayTheoId(View.IdGiay);
                    View.MaGiayNhaCungCap = giay.MaGiayNCC;
                    View.MaTuDat = giay.MaGiayTuDat;
                    View.TenGiay = giay.TenGiay;
                    View.DienGiai = giay.DienGiai;
                    View.DinhLuong = giay.DinhLuong;
                    View.KhoGiay = giay.KhoGiay;
                    View.TenGiayMoRong = giay.TenGiayMoRong;
                    View.ThuTu = giay.ThuTu;
                    View.GiaMua = giay.GiaMua;
                    View.ChieuNgan = giay.ChieuNgan;
                    View.ChieuDai = giay.ChieuDai;
                    View.TonKho = giay.TonKho;
                    View.KhongCon = giay.KhongCon;                    
                    //View.TenDanhMucGiay = DanhMucGiay.DocTheoId(View.IdDanhMucGiay).Ten;
                    break;
            }
        }
        public Dictionary<int, string>DanhMucGiaySTheoNCC()
        {
            var dict = new Dictionary<int, string>();
            foreach (DanhMucGiay dm in DanhMucGiay.LayTheoNhaCungCap(View.TenNhaCungCap))
            {
                dict.Add(dm.ID, dm.Ten);
            }
            return dict;
        }
        public string TenDanhMucGiay(int idDanhMucgiay)
        {
            return DanhMucGiay.DocTheoId(idDanhMucgiay).Ten;
        }
        public void HoanDoiChieuNganDai()
        {
            if (View.ChieuNgan > View.ChieuDai)
            {
                var tmp = View.ChieuNgan;
                View.ChieuNgan = View.ChieuDai;
                View.ChieuDai = tmp;
            }

        }
        public int IdDanhMucGiayChon()
        {
            return this.DanhMucGiaySTheoNCC().FirstOrDefault(x => x.Value == View.TenDanhMucGiayChon).Key;
        }
        public string LuuGiay()
        {
            var giay = new Giay();
            giay.ID = View.IdGiay;
            giay.MaGiayNCC = View.MaGiayNhaCungCap;
            giay.MaGiayTuDat = View.MaTuDat;
            giay.TenGiay = View.TenGiay;
            giay.DinhLuong = View.DinhLuong;
            giay.KhoGiay = View.KhoGiay;
            giay.DienGiai = View.DienGiai;
            giay.ThuTu = View.ThuTu;
            giay.GiaMua = View.GiaMua;
            giay.ChieuNgan = View.ChieuNgan;
            giay.ChieuDai = View.ChieuDai;
            giay.TenGiayMoRong = View.TenGiayMoRong;
            giay.TonKho = View.TonKho;
            giay.KhongCon = View.KhongCon;
            giay.IdDanhMucGiay = this.IdDanhMucGiayChon();
            string thongDiep = "";
            switch (View.TinhTrangForm)
            {
                case (int)FormStateS.New:
                    thongDiep = Giay.Them(giay);
                    break;
                case (int)FormStateS.Edit:
                    thongDiep = Giay.Sua(giay);
                    break;
            }
            return thongDiep;
        }
    }
}
