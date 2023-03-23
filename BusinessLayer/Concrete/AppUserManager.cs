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
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _AppUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _AppUserDal = appUserDal;
        }

        public List<AppUser> GetList()
        {
            return _AppUserDal.GetList();
        }

        public void TDelete(AppUser t)
        {
            _AppUserDal.Delete(t);
        }

        public AppUser TGetByID(int id)
        {
            return _AppUserDal.GetValue(id);
        }

        public void TInsert(AppUser t)
        {
            _AppUserDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _AppUserDal.Update(t);
        }
    }
}