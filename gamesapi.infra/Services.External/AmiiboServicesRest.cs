using GamesApi.Infra.Modelo;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace GamesApi.Infra.Services
{
    public class AmiiboServiceRest: IAmiiboServiceRest
    {
        private readonly IConfiguration _configuration;
        public AmiiboServiceRest(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public List<AmiiboDTO> GetFiltrado(Filter filter)
        {
            string url = _configuration.GetSection("AmiiboApiUrl").Value;
            var amiibo = new List<AmiiboDTO>();
            var client = new RestClient(url);

            var request = new RestRequest("/api/amiibo/", Method.Get);
            request.AddQueryParameter("character", filter.CharName);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<AmiiboRestDTO>(response.Content);
                amiibo.AddRange(data.Amiibo);
            }

            return amiibo.ToList();
        }
    }
}
