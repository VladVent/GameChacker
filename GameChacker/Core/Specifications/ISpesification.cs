using System.Linq.Expressions;

namespace GameChacker.Core.Specifications
{
    public interface ISpesification<T> 
    {
       Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

    }
}
