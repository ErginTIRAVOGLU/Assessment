using Assessment.Rapor.Api.Models;
using Assessment.Rapor.Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Rapor.Api.Repositories.Concrete
{
    public class RaporIcerikRepository : BaseRepository<RaporIcerik>, IRaporIcerikRepository
    {
        private AppDbContext _appDbContext;

        public RaporIcerikRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        
    }
}
