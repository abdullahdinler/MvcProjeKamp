using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDraftService
    {
        List<Draft> GetList();
        List<Draft> GetListById(int id);
        Draft GetById(int id);
        void Add(Draft entity);
        void Delete(Draft entity);
        void Update(Draft entity);
    }
}
