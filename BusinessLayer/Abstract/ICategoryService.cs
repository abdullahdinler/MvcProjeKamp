using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CatagoryAdd(Category entity);
        Category GetById(int id);
        void Delete(Category entity);
        void Update(Category entity);
    }
}
