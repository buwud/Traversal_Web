using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListAll(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x =>x.AppUserId == id && x.ReservationTime > DateTime.Now).ToList();
            }
        }
        /*public List<Reservation> GetListApproved(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Approved" && x.AppUserId == id && x.ReservationTime > DateTime.Now).ToList();
            }
        }

        public List<Reservation> GetListNotApproved(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Not approved" && x.AppUserId == id && x.ReservationTime > DateTime.Now).ToList();
            }
        }

        public List<Reservation> GetListPending(int id)
        {
            using (var context=new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Waiting for approval" && x.AppUserId == id && x.ReservationTime > DateTime.Now).ToList();
            }
        }*/
        public List<Reservation> GetListPreviousReservations(int id)
        {
            using(var context=new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.ReservationTime < DateTime.Now && x.AppUserId == id).ToList();
            }
        }
    }
}