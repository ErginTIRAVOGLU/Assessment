using Assessment.Kisiler.Api.Models;
using System.Linq.Expressions;

namespace Assessment.Kisiler.Api.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<bool> InsertAsync(T p);
        Task<bool> UpdateAsync(T p);
        Task<bool> DeleteAsync(T p);


        Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(Guid id);

        Task<ICollection<T>> GetAllAsync();
    }
}
