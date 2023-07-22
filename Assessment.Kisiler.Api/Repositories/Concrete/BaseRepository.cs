using Assessment.Kisiler.Api.Models;
using Assessment.Kisiler.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Kisiler.Api.Repositories.Concrete
{
    public class BaseRepository<T, Context> : IDisposable, IBaseRepository<T> where T : IEntity, new() where Context : DbContext, new()
    {
        protected Context _postDbContext;


        public BaseRepository(Context postDbContext)
        {
            _postDbContext = postDbContext;
        }


        public bool Insert(T p)
        {
            var T = _postDbContext.Set<T>().Add(p);
            var result = _postDbContext.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(T p)
        {
            var T = _postDbContext.Set<T>().Update(p);
            var result = _postDbContext.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Delete(T p)
        {
            var T = _postDbContext.Set<T>().Remove(p);
            var result = _postDbContext.SaveChanges();
            return result > 0 ? true : false;
        }

        public ICollection<T> GetAll()
        {
            List<T> list = _postDbContext.Set<T>().ToList();
            return list;
        }

        public ICollection<T> GetWhere(Expression<Func<T, bool>> method)
        {
            List<T> list = _postDbContext.Set<T>().Where(method).ToList();
            return list;
        }

        public T GetSingle(Expression<Func<T, bool>> method)
        {
            T p = _postDbContext.Set<T>().Where(method).FirstOrDefault();
            return p;
        }

        public T GetById(Guid id)
        {
            T p = _postDbContext.Set<T>().Where(m => m.UUID == id).FirstOrDefault();
            return p;
        }
        public bool SaveNow()
        {
            var result = _postDbContext.SaveChanges();
            return result > 0 ? true : false;
        }

        public void Dispose()
        {
            _postDbContext.Dispose();
        }
    }
}
