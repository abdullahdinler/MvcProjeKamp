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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading entity)
        {
            _headingDal.Add(entity);
        }

        public void Delete(Heading entity)
        {
            _headingDal.Update(entity);
        }

        public Heading GetById(int id)
        {
            var h = _headingDal.GetById(x => x.Id == id);
            return h;
        }

        public List<Heading> GetList()
        {
            var h = _headingDal.List();
            return h;
        }

        public List<Heading> GetList(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public void Update(Heading entity)
        {
            _headingDal.Update(entity);
        }
    }
}
