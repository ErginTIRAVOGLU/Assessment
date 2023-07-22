using Assessment.Kisiler.Api.Models;
using System.Linq.Expressions;

namespace Assessment.Kisiler.Api.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : IEntity
    {
        bool Insert(T p);
        bool Update(T p);
        bool Delete(T p);


        ICollection<T> GetWhere(Expression<Func<T, bool>> method);
        T GetSingle(Expression<Func<T, bool>> method);
        T GetById(Guid id);

        ICollection<T> GetAll();
    }
}
