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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _dal;

        public TestimonialManager(ITestimonialDal dal)
        {
            _dal = dal;
        }

        public List<Testimonial> GetList()
        {
            return _dal.GetList();
        }

        public void TDelete(Testimonial t)
        {
            _dal.Delete(t);
        }

        public Testimonial TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Testimonial t)
        {
            _dal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _dal.Update(t);
        }
    }
}
