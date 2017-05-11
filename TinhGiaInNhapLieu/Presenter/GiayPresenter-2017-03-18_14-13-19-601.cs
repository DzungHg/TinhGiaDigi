using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInNhapLieu.View;
using TinhGiaInClient.Model;

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
                case (int)Ennums.FormState.New:
                    View.DinhLuong = 0;
                    View.KhoGiay = "Khổ";
                    View.GiaMua = 250;
                    View.ChieuNgan = 32;
                    View.ChieuDai = 47;
                    View.ThuThu = 0;
                    View.GiaMua = 0;
                    View.KhongCon = false;
                    View.TonKho = false;
                    break;

                case (int)Ennums.FormState.Edit:
                    var giay = Giay.LayGiayTheoId(View.IdDanhMucGiay);
                    View.TenGiay = giay.TenGiay;
                    View.DinhLuong = giay.DinhLuong;
                    View.KhoGiay = giay.KhoGiay;
                    View.DienGiai = giay.DienDienGiai;
                    View.ThuThu = giay.ThuTu;
                    View.GiaMua = giay.GiaMua;
                    View.ChieuNgan = giay.ChieuNgan;
                    View.ChieuDai = giay.ChieuDai;
                    View.TonKho = giay.TonKho;
                    View.KhongCon = giay.KhongCon;
                    View.IdDanhMucGiay = giay.IdDanhMucGiay;
                    View.TenDanhMucGiay = DanhMucGiay.DocTheoId(View.IdDanhMucGiay).Ten;
                    break;
            }
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
        public void SaveEditingPaper()
        {
        
        }
    }
}
