using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void CatagoryAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(x=>x.Id==id);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
