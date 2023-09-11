using GamesApi.Infra.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GamesApi.Infra.Repository
{
    public class AmiiboRepository : EFRepositoryBase<Amiibo>, IAmiiboRepository
    {
        
        public AmiiboRepository(AmiibooDbContext context) : base(context)
        { }
    }
}