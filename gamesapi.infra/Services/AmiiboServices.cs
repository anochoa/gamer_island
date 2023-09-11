using AutoMapper;
using GamesApi.Infra.Modelo;
using GamesApi.Infra.Repository;
using GamesApi.Infra.Repository.Interfaces;

namespace GamesApi.Infra.Services
{
    public class AmiiboServices: IAmiiboServices
    {
        private readonly IAmiiboRepository _amiiboooRepository;
        private readonly IMapper _mapper;
        private readonly IAmiiboServiceRest _amiiboServiceRest;

        public AmiiboServices(IAmiiboRepository amiiboooRepository, IAmiiboServiceRest amiiboServiceRest, IMapper map)
        {
            _amiiboooRepository = amiiboooRepository;
            _amiiboServiceRest=amiiboServiceRest;
            _mapper = map;
        }

        public void Adicionar(AmiiboDTO item)
        {
            //TranslateToAmiibooo
            var amiibo = _mapper.Map<Amiibo>(item);
            _amiiboooRepository.Create(amiibo);
        }

        public void AdicionarVarios(List<AmiiboDTO> item)
        {
            //TranslateToAmiibooo
            var amiibo = _mapper.Map<List<Amiibo>>(item);
            _amiiboooRepository.CreateMore(amiibo);
        }

        public List<AmiiboDTO> GetFiltered(string text)
        {
           var amiibooo = _amiiboooRepository.FindAll(x => 
           x.Thecharacter.Contains(text) 
           || x.GameSeries.Contains(text) 
           || x.Name.Contains(text)).ToList();

            return _mapper.Map<List<AmiiboDTO>>(amiibooo);
        }

        public List<AmiiboDTO> GetFiltrado(Filter filter)
        {
            var resultado = _amiiboServiceRest.GetFiltrado(filter);
            return resultado;
        }

        public bool ValidateReturn(List<AmiiboDTO> items, string search)
        {
            var itensFiltrados = _amiiboooRepository.FindAll(x => x.Name.Contains(search) || x.Thecharacter.Contains(search) || x.GameSeries.Contains(search)).ToList();
            //var itensReais = _mapper.Map<List<AmiiboDTO>>(itensFiltrados);
            //return itensReais.Count <= items.Count;
            return itensFiltrados.Count <= items.Count;
        }
    }
}

