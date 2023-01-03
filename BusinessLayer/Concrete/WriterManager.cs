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
    public class WriterManager : IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void Delete(Writer entity)
        {
           _writerDal.Delete(entity);
        }

        public Writer GetById(int id)
        {
            var w = _writerDal.GetById(x=>x.Id == id);
            return w;
        }

        public List<Writer> GetList()
        {
            var w = _writerDal.List();
            return w;
        }

        public void Update(Writer entity)
        {
           _writerDal.Update(entity);
        }
    }
}
