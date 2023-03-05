using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        List<Reservation> GetListPending(int id);
        List<Reservation> GetListApproved(int id);
        List<Reservation> GetListNotApproved(int id);
    }
}