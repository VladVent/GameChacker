using AutoMapper;
using GameChacker.Dtos;
using GameChacker.Entites;

namespace GameChacker.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameToReturnDto>()
                .ForMember(d=> d.CompletedGames, o=>o.MapFrom(s=>s.CompletedGames.IsGameCompleted))
                .ForMember(d => d.Platform, o => o.MapFrom(s => s.Platform.PlatformName))
                .ForMember(d=>d.ImageUrl, o=>o.MapFrom<GameUrlResolver>());
            
        }
    }
}
