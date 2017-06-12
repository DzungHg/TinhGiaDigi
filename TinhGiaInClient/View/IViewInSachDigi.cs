using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewInSachDigi
    {
        int ID { get; set; }
        string TieuDe { get; set; }
        int SoTrangRuot { get; set; }
        int SoTrangBia { get; set; }
        float SachRong { get; set; }
        float SachCao { get; set; }
        float GayDay { get; set; }
        int SoCuon { get; set; }
        int IdMonDongCuonChon { get; set; }
    }
}
