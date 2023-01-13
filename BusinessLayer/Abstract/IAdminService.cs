using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        List<Admin> GetList(int id);
        Admin GetById(int id);
        void Add(Admin entity);
        void Delete(Admin entity);
        void Update(Admin entity);


    }
}
