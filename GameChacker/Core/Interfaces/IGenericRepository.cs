using GameChacker.Core.Specifications;
using GameChacker.Entites;

namespace GameChacker.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpesification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpesification<T> spec);
    }
}
