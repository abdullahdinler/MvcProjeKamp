using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager:IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin entity)
        {
            _adminDal.Add(entity);
        }

        public void Delete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public Admin GetById(int id)
        {
            var result = _adminDal.GetById(x => x.Id == id);
            return result;
        }

        public List<Admin> GetList()
        {
            var result = _adminDal.List();
            return result;
        }

        public List<Admin> GetList(int id)
        {
            var result = _adminDal.List(x => x.Id == id);
            return result;
        }


        public void Update(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
