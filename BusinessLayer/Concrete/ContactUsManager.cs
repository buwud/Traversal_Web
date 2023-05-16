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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;
        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public List<ContactUs> GetList()
        {
            return _contactUsDal.GetList();
        }

        public void TContactUsToFalse(int id)
        {
            _contactUsDal.ContactUsToFalse(id);
        }

        public void TDelete(ContactUs t)
        {
            _contactUsDal.Delete(t);
        }

        public ContactUs TGetByID(int id)
        {
            return _contactUsDal.GetValue(id);
        }

        public List<ContactUs> TGetListByFalse()
        {
            return _contactUsDal.GetListByFalse();
        }

        public List<ContactUs> TGetListByTrue()
        {
            return _contactUsDal.GetListByTrue();
        }

        public void TInsert(ContactUs t)
        {
            _contactUsDal.Insert(t);
        }

        public void TUpdate(ContactUs t)
        {
            _contactUsDal.Update(t);
        }
    }
}
