using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.Presenter
{
    
    public class QuanLyToInMayDigiPresenter
    {
        IViewQuanLyToInMayDigi View;
        public QuanLyToInMayDigiPresenter(IViewQuanLyToInMayDigi view)
        { 
            View = view;
            
        }
        public List<ToInMayDigi> ToInMayDigiS()
        {
            return ToInMayDigi.DocTatCa();
        }
        public List<MayInDigi> MayInDigiS()
        {
            return MayInDigi.DocTatCa();
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
            View.Rong = 1;
            View.Cao = 1;
            View.VungInRong = 1;
            View.VungInCao = 1;
            View.TocDo = 0;
         
            View.IdMayInDigi = 0;
            View.QuiSoTrangA4 = 1;
                 
            View.DaySoLuongCoBan = ";";
            View.DayLoiNhuanCoBan = ";";
            View.DaySoLuongNiemYet = ";";
            View.ThuTu = 100;
            View.HPIndigo = false;
            View.InTuTro = false;
            View.KhongSuDung = false;
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var toInMayDigi = ToInMayDigi.DocTheoId(View.ID);
            View.ID = toInMayDigi.ID;
            View.Ten = toInMayDigi.Ten;
            View.Rong = toInMayDigi.Rong;
            View.Cao = toInMayDigi.Cao;
            View.VungInRong = toInMayDigi.VungInRong;
            View.VungInCao = toInMayDigi.VungInCao;
            View.TocDo = toInMayDigi.TocDo;
          
            View.IdMayInDigi = toInMayDigi.IdMayIn;
            View.KhoToChayCoTheIn = toInMayDigi.KhoToChayCoTheIn;
         
            View.QuiSoTrangA4 = toInMayDigi.QuiA4;
            View.DaySoLuongCoBan = toInMayDigi.DaySoLuong;
            View.DayLoiNhuanCoBan = toInMayDigi.DayLoiNhuan;
            View.DaySoLuongNiemYet = toInMayDigi.DaySoLuongNiemYet;
            View.ThuTu = toInMayDigi.ThuTu;
            View.HPIndigo = toInMayDigi.LaHPIndigo;
            View.InTuTro = toInMayDigi.InTuTro;
            View.KhongSuDung = toInMayDigi.KhongSuDung;
            
        }
        public bool KiemTraDaySoLuongVaLoiNhuan()
        {
            var kq = true;
            if (View.DaySoLuongCoBan.Split(';').Count() !=
                View.DayLoiNhuanCoBan.Split(';').Count())
                kq = false;
            return kq;
        }
        public void Luu(ref string thongDiep)
        {
            ToInMayDigi toInMayDigi = new ToInMayDigi();
            toInMayDigi.ID = View.ID; 
            toInMayDigi.Ten = View.Ten;
            toInMayDigi.Rong = View.Rong;
            toInMayDigi.Cao = View.Cao;
            toInMayDigi.VungInRong = View.VungInRong;
            toInMayDigi.VungInCao = View.VungInCao;
            toInMayDigi.TocDo = View.TocDo;
           
            toInMayDigi.IdMayIn = View.IdMayInDigi;
            toInMayDigi.KhoToChayCoTheIn = View.KhoToChayCoTheIn;
         
            toInMayDigi.QuiA4 = View.QuiSoTrangA4;
            toInMayDigi.DaySoLuong = View.DaySoLuongCoBan;
            toInMayDigi.DayLoiNhuan = View.DayLoiNhuanCoBan;
            toInMayDigi.DaySoLuongNiemYet = View.DaySoLuongNiemYet;            
            toInMayDigi.LaHPIndigo = View.HPIndigo;
            toInMayDigi.InTuTro = View.InTuTro;
            toInMayDigi.ThuTu = View.ThuTu;
            toInMayDigi.KhongSuDung = View.KhongSuDung;
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:                                     
                    ToInMayDigi.Sua(ref thongDiep, toInMayDigi);
                    break;
                case FormStateS.New:
                    ToInMayDigi.Them(ref thongDiep, toInMayDigi);
                    break;

            }
        }
    }
}
