using GamesApi.Infra.Modelo;

namespace GamesApi.Infra.Repository.Interfaces
{
    public interface IAmiiboooLogRepository : IRepository<Amiibooo>
    {
        public void LogInformation(Amiibooo amiiboDTO);
        public void LogInformation(List<Amiibooo> amiiboDTO);
    }
}
