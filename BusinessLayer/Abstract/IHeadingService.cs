using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        Heading GetById(int id);
        void Add(Heading entity);
        void Update(Heading entity);
        void Delete(Heading entity);

    }
}
