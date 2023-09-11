using AutoMapper;
using GamesApi.Infra;

namespace Amiiboo.Tests.Configure
{
    internal class ConfigureMapper
    {
        public static IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }
    }
}
