using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        private GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetALL()
        {
            return repo.List();
        }

        public void Add(Category entity)
        {
            if (entity.Name == "" || entity.Description == "" || entity.Name.Length <= 3 ||entity.Name.Length >= 10)
            {
                //Hata mesajı gönder
            }
            else
            {
                repo.Add(entity);
            }
        }
    }
}
