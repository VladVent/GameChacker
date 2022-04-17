using AutoMapper;
using GameChacker.Dtos;
using GameChacker.Entites;
using Microsoft.Extensions.Configuration;

namespace GameChacker.Helpers
{
    public class GameUrlResolver : IValueResolver<Game, GameToReturnDto, string>
    {
        public GameUrlResolver(IConfiguration config)
        {
            Config = config;
        }

        public readonly IConfiguration Config;

        public string Resolve(Game source, GameToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl))
            {
                return Config["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}
