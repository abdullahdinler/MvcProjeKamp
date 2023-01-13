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
    public class DraftManager:IDraftService
    {
        private IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public List<Draft> GetList()
        {
            return _draftDal.List();
        }

        public List<Draft> GetListById(int id)
        {
            return _draftDal.List(x => x.Id == id);
        }

        public Draft GetById(int id)
        {
            return _draftDal.GetById(x=>x.Id == id);
        }

        public void Add(Draft entity)
        {
            _draftDal.Add(entity);
        }

        public void Delete(Draft entity)
        {
           _draftDal.Delete(entity);
        }

        public void Update(Draft entity)
        {
            _draftDal.Update(entity);
        }
    }
}
