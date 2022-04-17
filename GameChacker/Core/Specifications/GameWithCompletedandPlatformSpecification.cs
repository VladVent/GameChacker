using GameChacker.Entites;
using System.Linq.Expressions;

namespace GameChacker.Core.Specifications
{
    public class GameWithCompletedandPlatformSpecification : BaseSpecification<Game>
    {
        public GameWithCompletedandPlatformSpecification()
        {
            AddInclude(x => x.CompletedGames);
            AddInclude(x => x.Platform);
        }

        public GameWithCompletedandPlatformSpecification(int id) : 
            base(x=>x.Id == id)
        {
            AddInclude(x => x.CompletedGames);
            AddInclude(x => x.Platform);
        }
    }
}
