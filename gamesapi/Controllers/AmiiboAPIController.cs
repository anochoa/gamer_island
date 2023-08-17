using gamesapi.infra;
using gamesapi.infra.modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gamesapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AmiiboAPIController : ControllerBase
    {
        private repositorio_de_logs Ilogger;

        public AmiiboAPIController()
        {
            Ilogger = new repositorio_de_logs();
        }

        [HttpGet]
        public IActionResult Get(string search,
            string connectionstring = "Host=localhost;Port=3366;user=root;database=games;password=my-secret-pw;")
        {
            var repositorio = new repositorio_de_dados(connectionstring);

            var items = repositorio.GetFiltrado(new filter() { charname = search });

            Ilogger.LogInformation(items);

            return Ok(items);
        }

        [HttpGet]
        public IActionResult GetData(string search,
            string connectionstring = "Host=localhost;Port=3366;user=root;database=amiiboo;password=my-secret-pw;")
        {
            var repositorio = new repositorio_de_dados(connectionstring);
            var retorno = new List<Amiibo>();
            var items = repositorio.GetFiltered(search);

            repositorio.TranslateFromAmiiboooList(items.ToList(), out retorno);

            Ilogger.LogInformation(retorno.ToArray());

            if (ValidateReturn(retorno, search, connectionstring))
            {
                return Ok(retorno.ToArray());
            }
            else
            {
                return Ok("Ocorreu um problema de validação de itens");
            }
        }

        private bool ValidateReturn(List<Amiibo> items, string search, string conn)
        {
            var repositorio = new repositorio_de_dados(conn);
            var itensFiltrados = from ga in repositorio.GetAll()
                where ga.name.Contains(search) || ga.thecharacter.Contains(search) || ga.gameSeries.Contains(search)
                select ga;

            var itensReais = new List<Amiibo>();

            repositorio.TranslateFromAmiiboooList(itensFiltrados.ToList(), out itensReais);

            if (itensReais.Count <= items.Count)
                return true;
            else
            {
                return false;
            }
        }
    }
}