using GamesApi.Infra.Modelo;
using GamesApi.Infra.Repository;

namespace GamesApi.Infra.Services
{
    public interface IAmiiboooLogServices
    {
        public void LogInformation(AmiiboDTO item);
        public void LogInformation(List<AmiiboDTO> item);
    }
}
