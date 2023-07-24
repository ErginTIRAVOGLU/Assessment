using Assessment.Kisiler.Api.Models;
using Assessment.Kisiler.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Kisiler.Api.Repositories.Concrete
{
    public class KisiRepository : BaseRepository<Kisi>, IKisiRepository
    {
        private AppDbContext _appDbContext;

        public KisiRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        

        public async Task<ICollection<Kisi>> GetAllIncAsync()
        {
            List<Kisi> list = await _appDbContext.Set<Kisi>().Include(m=>m.IletisimBilgileri).AsNoTracking().ToListAsync();
            return list;
        }

        public ICollection<Kisi> GetWhereInc(Expression<Func<Kisi, bool>> method)
        {
            List<Kisi> list = _appDbContext.Set<Kisi>().Include(m => m.IletisimBilgileri).Where(method).ToList();
            return list;
        }

        public async Task<ICollection<Kisi>> GetWhereIncAsync(Expression<Func<Kisi, bool>> method)
        {
            List<Kisi> list = await _appDbContext.Set<Kisi>().Include(m => m.IletisimBilgileri).Where(method).ToListAsync();
            return list;
        }

        public async Task<Kisi> GetSingleIncAsync(Expression<Func<Kisi, bool>> method)
        {
            Kisi p = await _appDbContext.Set<Kisi>().Include(m => m.IletisimBilgileri).Where(method).FirstOrDefaultAsync();
            return p;
        }

        public async Task<Kisi> GetByIdIncAsync(Guid id)
        {
            Kisi p = await _appDbContext.Set<Kisi>().Include(m => m.IletisimBilgileri).Where(m => m.UUID == id).FirstOrDefaultAsync();
            return p;
        }
        public async Task<IEnumerable<Kisi>> GetRandomKisiler(int count)
        {
            List<Kisi> list = await _appDbContext.Set<Kisi>().Take(count).ToListAsync();
            return list;
        }
    }
}
