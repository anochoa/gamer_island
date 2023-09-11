using GamesApi.Infra.Modelo;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace GamesApi.Infra.Services
{
    public interface IAmiiboServiceRest
    {
        public List<AmiiboDTO> GetFiltrado(Filter filter);
    }
}
