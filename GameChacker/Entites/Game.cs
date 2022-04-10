namespace GameChacker.Entites
{
    public class Game : BaseEntity
    {
        public string GameName { get; set; }

        public string ImageUrl { get; set; }
        public CompletedGame CompletedGames { get; set; }

        public int CompletedGameId { get; set; }

        public GamePlatform Platform { get; set; }

        public int PlatformID { get; set; }
    }
}
