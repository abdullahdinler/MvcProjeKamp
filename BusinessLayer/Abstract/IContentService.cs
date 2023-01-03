using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListById(int id);
        Content GetById(int id);
        void Add(Content entity);
        void Update(Content entity);
        void Delete(Content entity);

    }
}
