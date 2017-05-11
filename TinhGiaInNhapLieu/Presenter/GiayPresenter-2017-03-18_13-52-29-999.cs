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
        public void TrinhBayGiay(int idGiay)
        {
            switch (View.TinhTrangForm)
            {
                case (int)Ennums.FormState.New:
                    View.DinhLuong = 0;
                    View.GiaMua = 250;
                    View.ChieuNgan = 32;
                    View.ChieuDai = 47;
                    break;

                case (int)Ennums.FormState.Edit:
                    var giay = Giay.LayGiayTheoId(idGiay);
                    View.TenGiay = giay.TenGiay;
                    View.DinhLuong = giay.DinhLuong;
                    View.DienGiai = giay.DienDienGiai;
                    View.ThuThu = giay.ThuTu;
                    View.GiaMua = giay.GiaMua;
                    View.ChieuNgan = giay.ChieuNgan;
                    View.ChieuDai = giay.ChieuDai;
                    View.TonKho = giay.TonKho;
                    
                   
                    View.IdDanhMucGiay = ppM.CategoryId;
                   
                    break;
            }
        }
        public string TenDanhMucGiay(int idDanhMucgiay)
        {
            return DanhMucGiay.DocTheoId(idDanhMucgiay).Ten;
        }
        private void HoanDoiChieuNganDai()
        {
            if (this.ChieuNgan > this.ChieuDai)
            {
                float tmp = this.ChieuNgan;
                this.ChieuNgan = this.ChieuDai;
                this.ChieuDai = tmp;
            }

        }
        public void SaveEditingPaper()
        {
        
        }
    }
}
