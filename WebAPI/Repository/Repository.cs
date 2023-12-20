using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data;

namespace WebAPI.Repository
{
    public class Repository<T> //operations only needed for this version of CarPool's use cases implemented
        where T : class
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public Repository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        /// <summary>
        ///  Add a new entity to the Table.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbSet.Add(entity);

        }
        /// <summary>
        ///  Find a set of entities that match a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate);
        }
        /// <summary>
        ///  Find the first entity that match a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }
        public IEnumerable<T> Find(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.Where(predicate);
        }
        public T FirstOrDefault(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.FirstOrDefault(predicate);
        }
    }
}
