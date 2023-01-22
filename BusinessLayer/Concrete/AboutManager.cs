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
	public class AboutManager : IAboutService
	{
		IAboutDal _aboutDal;
		public AboutManager(IAboutDal a)
		{
			_aboutDal = a;
		}//DEPENDENCY INJECTION
		public List<About> GetList()
		{
			return _aboutDal.GetList();
		}

		public void TDelete(About t)
		{
			_aboutDal.Delete(t);
		}

		public About TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public void TInsert(About t)
		{
			_aboutDal.Insert(t);
		}

		public void TUpdate(About t)
		{
			_aboutDal.Update(t);
	}
}
