using GamesApi.Infra.Modelo;
using GamesApi.Infra.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GamesApi.Infra.Repository
{
    public class AmiiboooLogRepository : EFRepositoryBase<Amiibooo>, IAmiiboooLogRepository
    {
        public AmiiboooLogRepository(AmiibooDbContext context) :base(context)
        {
        }

        public void LogInformation(Amiibooo amiibooo)
        {
            Create(amiibooo);
        }

        public void LogInformation(List<Amiibooo> amiibooo)
        {
            CreateMore(amiibooo);
        }
    }
}
