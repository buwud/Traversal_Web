using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactUsService:IGenericService<ContactUs>
    {
        List<ContactUs> TGetListByTrue();
        List<ContactUs> TGetListByFalse();

        void TContactUsToFalse(int id);//silme işlemi gibi
    }
}
