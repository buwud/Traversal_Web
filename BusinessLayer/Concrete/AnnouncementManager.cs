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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _AnnouncementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _AnnouncementDal = announcementDal;
        }

        public List<Announcement> GetList()
        {
            return _AnnouncementDal.GetList();
        }

        public void TDelete(Announcement t)
        {
            _AnnouncementDal.Delete(t);
        }

        public Announcement TGetByID(int id)
        {
            return _AnnouncementDal.GetValue(id);
        }

        public void TInsert(Announcement t)
        {
            _AnnouncementDal.Insert(t);
        }

        public void TUpdate(Announcement t)
        {
            _AnnouncementDal.Update(t);
        }
    }
}
