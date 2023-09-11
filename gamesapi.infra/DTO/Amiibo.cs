namespace GamesApi.Infra.Modelo
{
    public class AmiiboDTO
    {
        public string AmiiboSeries { get; set; }
        public string Character { get; set; }
        public string GameSeries { get; set; }
        public string Head { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Tail { get; set; }
        public string Type { get; set; }
    }

    public class AmiiboRestDTO
    {
        public List<AmiiboDTO> Amiibo { get; set; }
    }

}
