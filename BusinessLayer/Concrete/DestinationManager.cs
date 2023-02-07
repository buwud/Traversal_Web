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
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _DestinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _DestinationDal = destinationDal;
        }

        public List<Destination> GetList()
        {
            return _DestinationDal.GetList();
        }

        public void TDelete(Destination t)
        {
            _DestinationDal.Delete(t);
        }

        public Destination TGetByID(int id)
        {
            return _DestinationDal.GetValue(id);
        }

        public void TInsert(Destination t)
        {
            _DestinationDal.Insert(t);
        }

        public void TUpdate(Destination t)
        {
            _DestinationDal.Update(t);
        }
    }
}
