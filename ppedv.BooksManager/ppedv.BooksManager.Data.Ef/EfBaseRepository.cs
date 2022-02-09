using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Data.Ef
{

    public class EfBaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected EfContext _context;

        public EfBaseRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
