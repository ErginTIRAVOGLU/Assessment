﻿using Assessment.Rapor.Api.Models;
using Assessment.Rapor.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Rapor.Api.Repositories.Concrete
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
        public async Task<bool> InsertRangeAsync(List<T> p)
        {
            await _appDbContext.Set<T>().AddRangeAsync(p);
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

        public async Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> method)
        {
            List<T> list = await _appDbContext.Set<T>().Where(method).ToListAsync();
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
