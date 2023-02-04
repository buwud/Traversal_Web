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
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            this._subAboutDal = subAboutDal;
        }

        public List<SubAbout> GetList()
        {
            return _subAboutDal.GetList();
        }

        public void TDelete(SubAbout t)
        {
            _subAboutDal.Delete(t);
        }

        public SubAbout TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(SubAbout t)
        {
            _subAboutDal.Insert(t);
        }

        public void TUpdate(SubAbout t)
        {
            _subAboutDal.Update(t);
        }
    }
}
