using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;
using TinhGiaInClient.Common.Enum;
using TinhGiaInClient.Common;

namespace TinhGiaInNhapLieu.Presenter
{
    
    public class BangGiaPresenter
    {
        IViewBangGia View;
        public BangGiaPresenter(IViewBangGia view)
        { 
            View = view;
            //
            if (View.TinhTrangForm == FormStateS.New)
                TrinhBayThemMoi();
            else if (View.TinhTrangForm == FormStateS.Edit)
                TrinhBayChiTietBangGia();
            else if (view.TinhTrangForm == FormStateS.View)
                TrinhBayChiTietBangGia();

        }
       
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
            View.DienGiai = "Diễn giải";
                    
                  
            View.DaySoLuong = ";";
            View.DayGiaTrang = ";";
      
            View.ThuTu = 100;
            View.DonViTinh = "trang a4";
       
            View.KhongSuDung = false;
        }
        public void TrinhBayChiTietBangGia()
        {
            if (View.ID <= 0)
                return;
            //Đọc theo từng bảng
            BangGiaBase bangGiaIn;
            switch (View.LoaiBangGia)
            {
                case Global.cBangGiaLuyTien:
                    bangGiaIn = BangGiaLuyTien.DocTheoId(View.ID);
                    break;
                case Global.cBangGiaBuoc:
                    bangGiaIn = BangGiaTheoBuoc.DocTheoId(View.ID);
                    break;
                case Global.cBangGiaGoi:
                    bangGiaIn = BangGiaTheoBuoc.DocTheoId(View.ID);
                    break;
                default:
                     bangGiaIn = BangGiaTheoBuoc.DocTheoId(View.ID);
                    break;
            }
            
            View.ID = bangGiaIn.ID;
            View.Ten = bangGiaIn.Ten;
            View.DienGiai = bangGiaIn.DienGiai;
            View.DaySoLuong = bangGiaIn.DaySoLuong;
            View.DayGiaTrang = bangGiaIn.DayGia;      
            View.ThuTu = bangGiaIn.ThuTu;          
            View.KhongSuDung = bangGiaIn.KhongCon;
            View.DonViTinh = bangGiaIn.DonViTinh;
        }


        public void Luu(ref string thongDiep)
        {
            var bangGiaLT = new BangGiaLuyTien
            {
                ID = View.ID,
                Ten = View.Ten,
                DienGiai = View.DienGiai,
                LoaiBangGia = View.LoaiBangGia,
                DaySoLuong = View.DaySoLuong,
                DayGia = View.DayGiaTrang,
                DonViTinh = View.DonViTinh,
                ThuTu = View.ThuTu,
                KhongCon = View.KhongSuDung
            };
            var bangGiaBuoc = new BangGiaTheoBuoc
            {
                ID = View.ID,
                Ten = View.Ten,
                DienGiai = View.DienGiai,
                LoaiBangGia = View.LoaiBangGia,
                DaySoLuong = View.DaySoLuong,
                DayGia = View.DayGiaTrang,
                DonViTinh = View.DonViTinh,
                ThuTu = View.ThuTu,
                KhongCon = View.KhongSuDung
            };
            // case từng bảng

            switch (View.LoaiBangGia)
            {
                case Global.cBangGiaLuyTien:
                    switch (View.TinhTrangForm)
                    {
                        case FormStateS.Edit:                            
                            thongDiep = BangGiaLuyTien.Sua(bangGiaLT);
                            break;
                        case FormStateS.New:
                            thongDiep = BangGiaLuyTien.Them(bangGiaLT);
                            break;
                    }

                    break;

                default:
                    switch (View.TinhTrangForm)
                    {
                        case FormStateS.Edit:
                            thongDiep = BangGiaTheoBuoc.Sua(bangGiaBuoc);
                            break;
                        case FormStateS.New:
                            thongDiep = BangGiaTheoBuoc.Them(bangGiaBuoc);
                            break;
                    }

                    break;
            }

        }
        public Dictionary<string, string> TrinhBayBangGia()
        {
            Dictionary<string, string> kq = null;
         
            // làm treenform là được
            kq = DanhSachBangGia.TrinhBayBangGia(View.DaySoLuong, View.DayGiaTrang,
                View.LoaiBangGia, View.DonViTinh);

            return kq;
        }
    }
}
