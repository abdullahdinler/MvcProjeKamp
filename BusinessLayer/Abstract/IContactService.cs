using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetsList();
        Contact GetById(int id);
        void Add(Contact entity);
        void Update(Contact entity);
        void Delete(Contact entity);
    }
}
