using Assessment.Rapor.Api.Models;
using Assessment.Rapor.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Rapor.Api.Repositories.Concrete
{
    public class RaporRepository : BaseRepository<Raporlar>, IRaporRepository
    {
        private AppDbContext _appDbContext;

        public RaporRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ICollection<Raporlar>> GetAllIncAsync()
        {
            List<Raporlar> list = await _appDbContext.Set<Raporlar>().Include(m => m.RaporIcerigi).AsNoTracking().OrderByDescending(m=>m.TalepTarihi).ToListAsync();
            return list;
        }

        public ICollection<Raporlar> GetWhereInc(Expression<Func<Raporlar, bool>> method)
        {
            List<Raporlar> list = _appDbContext.Set<Raporlar>().Include(m => m.RaporIcerigi).Where(method).ToList();
            return list;
        }

        public async Task<ICollection<Raporlar>> GetWhereIncAsync(Expression<Func<Raporlar, bool>> method)
        {
            List<Raporlar> list = await _appDbContext.Set<Raporlar>().Include(m => m.RaporIcerigi).Where(method).ToListAsync();
            return list;
        }

        public async Task<Raporlar> GetSingleIncAsync(Expression<Func<Raporlar, bool>> method)
        {
            Raporlar p = await _appDbContext.Set<Raporlar>().Include(m => m.RaporIcerigi).Where(method).FirstOrDefaultAsync();
            return p;
        }

        public async Task<Raporlar> GetByIdIncAsync(Guid id)
        {
            Raporlar p = await _appDbContext.Set<Raporlar>().Include(m => m.RaporIcerigi).Where(m => m.UUID == id).FirstOrDefaultAsync();
            return p;
        }
    }
}
