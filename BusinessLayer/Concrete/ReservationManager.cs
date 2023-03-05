using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetList()
        {
            return _reservationDal.GetList();
        }

        public List<Reservation> GetListApproved(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetListNotApproved(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetListPending(int id)
        {
            return _reservationDal.GetListPending(id);
        }

        /*public List<Reservation> GetListPendings(int id)
        {
            return _reservationDal.GetListByFilter(x => x.AppUserId == id && x.Status== "Waiting for approval");
        }*/

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetByID(int id)
        {
            return _reservationDal.GetValue(id);
        }

        public void TInsert(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
