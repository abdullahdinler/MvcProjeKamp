using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void Add(Writer entity);
        void Update(Writer entity);
        void Delete(Writer entity);
        Writer GetById(int id);
    }
}
