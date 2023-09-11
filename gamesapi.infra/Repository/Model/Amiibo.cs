namespace GamesApi.Infra.Repository
{
    public class Amiibo:ModelBase
    {
        public string AmiiboSeries { get; set; }
        public string Thecharacter { get; set; }
        public string GameSeries { get; set; }
        public string Head { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Tail { get; set; }
        public string Type { get; set; }
    }
}