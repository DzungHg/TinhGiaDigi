﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;



namespace TinhGiaInClient.Presenter
{
    public class GiaInOffsetPresenter
    {
        IViewGiaInOffset View;
        
        public GiaInOffsetPresenter(IViewGiaInOffset view, MucGiaIn giaIn = null)
        {
            View = view;//Một số giá trị ban đầu
            View.PhiVanChuyen = 200000;
            View.PhiCanhBai = 100000;
            if (giaIn != null)
            {
                this.DocGiaIn = giaIn;
            }
            else
                _giaIn = new MucGiaIn(0, 0, 0, 0, 0, "", 0,0, 2);
            //Xem vấn đề mới và sửa
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:
                    break;
                case FormStateS.Edit:
                    giaIn.ID = View.ID;
                    break;
            }
        }

        public string TenHangKH (int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).LoiNhuanOffsetGiaCong;
        }
        
        
        public string TenMayInOffsetChon()
        {
            return OffsetGiaCong.DocTheoId(View.IdMayIn).Ten;
        }
        public int SoMatIn()
        {
            
            int result = 0;
            switch (View.KieuInOffset)
            {
                case (int)EnumsS.KieuInOffset.AB:
                case (int)EnumsS.KieuInOffset.TuTro:
                case (int)EnumsS.KieuInOffset.TuTroNhip:
                    result = View.SoToChay * 2;
                    break;
                case (int)EnumsS.KieuInOffset.MotMat:                
                    result = View.SoToChay * 1;
                    break;
            }
            return result;
        }
    
       
        public decimal GiaInOffset()
        {  
           
            var mayInOffset = OffsetGiaCong.DocTheoId(View.IdMayIn);

            var giaInOffset = new GiaInOffsetGiaCong(mayInOffset, SoMatIn(), this.TyLeLoiNhuanTheoHangKH(),
                            View.KieuInOffset, View.PhiVanChuyen, View.PhiCanhBai);
                                
            return giaInOffset.ThanhTien_In();
        }

        MucGiaIn _giaIn;
        public MucGiaIn DocGiaIn
        {
            get
            {
                //Điền thêm dữ liệu         
               
                _giaIn.IdBaiIn = View.IdBaiIn;
                _giaIn.PhuongPhapIn = View.PhuongPhapIn;
                _giaIn.IdMayIn = View.IdMayIn;
                _giaIn.SoTrangIn = View.SoTrangIn;
                _giaIn.TienIn = this.GiaInOffset();
                if (View.TinhTrangForm == FormStateS.Edit)
                    _giaIn.ID = View.ID;//Phòng tạo mới

                return _giaIn;
            }
            set { _giaIn = value; }
          
        }
    }
}
