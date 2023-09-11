using GamesApi.Infra.Modelo;
using GamesApi.Infra.Repository;

namespace GamesApi.Infra.Services
{
    public interface IAmiiboServices
    {
        public void Adicionar(AmiiboDTO item);
        public void AdicionarVarios(List<AmiiboDTO> item);
        List<AmiiboDTO> GetFiltered(string text);
        List<AmiiboDTO> GetFiltrado(Filter filter);
        bool ValidateReturn(List<AmiiboDTO> items, string search);
    }
}
