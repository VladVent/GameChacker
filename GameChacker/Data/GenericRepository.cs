using GameChacker.Core.Interfaces;
using GameChacker.Core.Specifications;
using GameChacker.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameChacker.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly GameLibraryContext context;

        public GenericRepository(GameLibraryContext context)
        {
            this.context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

       

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpesification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpesification<T> spec)
        {
           return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpesification<T> spec)
        {
            return SpesificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
        }
    }
}
