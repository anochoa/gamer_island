namespace GamesApi.Infra.Modelo
{
    public class Filter
    {
        internal string charname;

        public Filter() { FiltroLimit = 100; }
      
        public Filter(float _limit)
        {
            int result  = 0;
            if(_limit < 0 && int.TryParse(_limit.ToString(), out result))
                FiltroLimit = int.Parse(_limit.ToString());
        }
        public int FiltroLimit { get; set; }
        public string CharName { get; set; }
        public int PageAtual { get; set; }
    }
    
}
