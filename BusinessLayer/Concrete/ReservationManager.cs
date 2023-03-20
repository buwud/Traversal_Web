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

        public List<Reservation> GetListAll(int id)
        {
            return _reservationDal.GetListAll(id);
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
            throw new NotImplementedException();
        }

        public List<Reservation> GetListPreviousReservations(int id)
        {
            return _reservationDal.GetListPreviousReservations(id);
        }
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
