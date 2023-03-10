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
    public class GuideManager : IGuideService
    {
        IGuideDal _GuideDal;
        public GuideManager(IGuideDal guideDal)
        {
            _GuideDal = guideDal;
        }

        public List<Guide> GetList()
        {
            return _GuideDal.GetList();
        }

        public void TDelete(Guide t)
        {
            _GuideDal.Delete(t);
        }

        public Guide TGetByID(int id)
        {
            return _GuideDal.GetValue(id);
        }

        public void TInsert(Guide t)
        {
            _GuideDal.Insert(t);
        }

        public void TUpdate(Guide t)
        {
            _GuideDal.Update(t);
        }
    }
}
