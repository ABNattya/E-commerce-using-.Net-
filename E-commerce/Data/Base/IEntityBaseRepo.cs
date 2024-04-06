using E_commerce.Models;
using System.Linq.Expressions;

namespace E_commerce.Data.Base
{
    public interface IEntityBaseRepo<T>where T : class,IEntityBase, new()
    {
        Task<IEnumerable<T>> GetActorsAsync();
        Task<IEnumerable<T>> GetEntitiesAsync(params Expression<Func<T, object>>[] includeProp);
        Task<T> GetActorByIdAsync(int id);

        Task AddActorAsync(T entity);
        Task updateActorAsync(int id, T entity);
        Task deleteActor(int id);


    }
}
