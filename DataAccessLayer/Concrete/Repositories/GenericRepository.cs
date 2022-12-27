using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private Context context = new Context();
        private DbSet<T> _objet;

        public GenericRepository()
        {
            _objet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _objet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _objet.Remove(entity);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _objet.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _objet.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }
    }
}
