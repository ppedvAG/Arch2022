using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Data.Ef
{
    public class EfRepository : IRepository
    {
        readonly EfContext context = new();

        public void Add<T>(T entity) where T : Entity
        {
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            context.Set<T>().Update(entity);
        }
    }
}
