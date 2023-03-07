using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
        List<Reservation> GetListPending(int id);
        List<Reservation> GetListApproved(int id);
        List<Reservation> GetListNotApproved(int id);
        List<Reservation> GetListPreviousReservations(int id);
        List<Reservation> GetListAll(int id);

    }
}