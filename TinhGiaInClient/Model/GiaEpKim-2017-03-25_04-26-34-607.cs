using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaEpKim
    {
        public int SoLuong { get; set; }
        public float KhoEpRong { get; set; }
        public float KhoEpCao { get; set; }
        public EpKim EpKim { get; set; }
        public KhuonEpKim KhuonEp { get; set; }
        public NhuEpKim NhuEp { get; set; }
        public GiaEpKim(int soLuong, float khoEpRong, float khoEpCao, 
            EpKim epKim, KhuonEpKim khuonEp, NhuEpKim nhuEp)
        {
            this.SoLuong = soLuong;
            this.KhoEpRong = khoEpRong;
            this.KhoEpCao = KhoEpCao;
            this.EpKim = epKim;
            this.KhuonEp = khuonEp;
            this.NhuEp = nhuEp;
        }
        public decimal ChiPhiChay ()
        {
            decimal result = 0;
            if (this.EpKim != null)
                result = this.EpKim.ChiPhi(this.SoLuong);
            return result;
        }
        public decimal ChiPhiKhuon ()
        {

        }
        public decimal ChiPhiPhiNhuEp()
        {

        }
        public decimal TongChiPhi ()
        {
            return this.ChiPhiChay
        }
    }
}
