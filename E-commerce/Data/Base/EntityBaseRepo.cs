
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace E_commerce.Data.Base
{
    public class EntityBaseRepo<T> : IEntityBaseRepo<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext _context;

        public EntityBaseRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddActorAsync(T entity) { 
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

        }


        public async Task deleteActor(int id)
        {
            var entity= await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetActorsAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetActorByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);


        public async Task updateActorAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetEntitiesAsync(params Expression<Func<T, object>>[] includeProp)
        {
            IQueryable<T> query =_context.Set<T>();
            query=includeProp.Aggregate(query,(current,includeProp)=> current.Include(includeProp));
             return await query.ToListAsync();
        }
    }

}
