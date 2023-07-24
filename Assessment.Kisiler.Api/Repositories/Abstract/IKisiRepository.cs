using Assessment.Kisiler.Api.Models;
using System.Linq.Expressions;

namespace Assessment.Kisiler.Api.Repositories.Abstract
{
    public interface IKisiRepository : IBaseRepository<Kisi>
    {

        Task<ICollection<Kisi>> GetAllIncAsync();
        ICollection<Kisi> GetWhereInc(Expression<Func<Kisi, bool>> method);
        Task<ICollection<Kisi>> GetWhereIncAsync(Expression<Func<Kisi, bool>> method);
        Task<Kisi> GetSingleIncAsync(Expression<Func<Kisi, bool>> method);
        Task<Kisi> GetByIdIncAsync(Guid id);
        Task<IEnumerable<Kisi>> GetRandomKisiler(int count);
       
    }
}
