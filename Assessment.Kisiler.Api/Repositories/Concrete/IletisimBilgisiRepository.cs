using Assessment.Kisiler.Api.Models;
using Assessment.Kisiler.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Kisiler.Api.Repositories.Concrete
{
    public class IletisimBilgisiRepository : BaseRepository<IletisimBilgisi>, IIletisimBilgisiRepository
    {
        private AppDbContext _appDbContext;

        public IletisimBilgisiRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        
    }
}
