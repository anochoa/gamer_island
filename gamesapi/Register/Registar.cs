using AutoMapper;
using GamesApi.Infra;
using GamesApi.Infra.Repository;
using GamesApi.Infra.Repository.Interfaces;
using GamesApi.Infra.Services;

namespace GamesApi
{
    public static class Registar
    {
        public static void Amiiboo(this IServiceCollection services)
        {
            services.Repositorio();
            services.Servicos();
            services.AutoMapperConfig();

        }
        private static void Repositorio(this IServiceCollection services)
        {
            services.AddTransient<IAmiiboRepository, AmiiboRepository>();
            services.AddTransient<IAmiiboooLogRepository, AmiiboooLogRepository>();
        }
        private static void Servicos(this IServiceCollection services)
        {
            services.AddTransient<IAmiiboServices, AmiiboServices>();
            services.AddTransient<IAmiiboooLogServices, AmiiboooLogServices>();


            //Servicos externos
            services.AddSingleton<IAmiiboServiceRest, AmiiboServiceRest>();
        }

        private static void AutoMapperConfig(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
