﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyCanGap: IViewMayThanhPham
    {

      //thêm riêng
        float ThoiGianTangKhiThemMotDungCan { get; set; }
      
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
      
        FormStateS TinhTrangForm { get; set; }
        bool DuLieuDaThayDoi { get; set; }
    }
}
