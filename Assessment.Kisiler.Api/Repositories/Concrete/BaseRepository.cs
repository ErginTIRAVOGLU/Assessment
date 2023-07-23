using Assessment.Kisiler.Api.Models;
using Assessment.Kisiler.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Kisiler.Api.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IEntity
    {
        protected AppDbContext _appDbContext;


        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<bool> InsertAsync(T p)
        {
            await _appDbContext.Set<T>().AddAsync(p);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(T p)
        {
            _appDbContext.Set<T>().Update(p);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(T p)
        {
            _appDbContext.Set<T>().Remove(p);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            List<T> list = await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
            return list;
        }
        public ICollection<T> GetAll()
        {
            List<T> list = _appDbContext.Set<T>().AsNoTracking().ToList();
            return list;
        }
        public async Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> method)
        {
            List<T> list = await _appDbContext.Set<T>().Where(method).ToListAsync();
            return list;
        }
        public ICollection<T> GetWhere(Expression<Func<T, bool>> method)
        {
            List<T> list = _appDbContext.Set<T>().Where(method).ToList();
            return list;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            T p = await _appDbContext.Set<T>().Where(method).FirstOrDefaultAsync();
            return p;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            T p = await  _appDbContext.Set<T>().Where(m => m.UUID == id).FirstOrDefaultAsync();
            return p;
        }

         

     
    }
}
