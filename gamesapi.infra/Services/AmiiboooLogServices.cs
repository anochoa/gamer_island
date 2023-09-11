using AutoMapper;
using GamesApi.Infra.Modelo;
using GamesApi.Infra.Repository;
using GamesApi.Infra.Repository.Interfaces;

namespace GamesApi.Infra.Services
{
    public class AmiiboooLogServices : IAmiiboooLogServices
    {
        private readonly IAmiiboooLogRepository _amiiboooLogRepository;
        private readonly IMapper _mapper;

        public AmiiboooLogServices(IAmiiboooLogRepository logRepository, IMapper map)
        {
            _amiiboooLogRepository = logRepository;
            _mapper = map;
        }
        public void LogInformation(AmiiboDTO item)
        {
            var amiibo = _mapper.Map<Amiibooo>(item);
            _amiiboooLogRepository.Create(amiibo);
        }

        public void LogInformation(List<AmiiboDTO> item)
        {
            var amiibo = _mapper.Map<List<Amiibooo>>(item);
            _amiiboooLogRepository.CreateMore(amiibo);
        }
    }
}