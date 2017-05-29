using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Presenter
{
    public interface IThanhPhamPresenter
    {
        void KhoiTaoBanDau();


        int TyLeMarkUp();
    
        decimal ThanhTien_ThPh();

        decimal GiaTB_ThPh();
       

    }
}
