using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            var AddedEntity = context.Entry(entity);
            AddedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var deleted = context.Entry(entity);
            deleted.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _objet.SingleOrDefault(filter);
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
            var ModifiedEntity = context.Entry(entity);
            ModifiedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
