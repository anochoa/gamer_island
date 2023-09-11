using GamesApi.Infra.Modelo;
using GamesApi.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamesapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AmiiboController : ControllerBase
    {
        private readonly IAmiiboServices _amiiboServices;
        private readonly IAmiiboooLogServices _amiiboooLog;
        public AmiiboController(IAmiiboServices amiiboServices, IAmiiboooLogServices amiiboooLog)
        {
            _amiiboServices = amiiboServices;
            _amiiboooLog=amiiboooLog;
        }

        [HttpGet]
        public IActionResult GetAmibooExterno(string search)
        {
            var items = _amiiboServices.GetFiltrado(new Filter() { CharName = search });

            _amiiboooLog.LogInformation(items);
            
            return Ok(items);
        }

        [HttpGet]
        public IActionResult GetData(string search)
        {
            var items = _amiiboServices.GetFiltered(search);
            _amiiboooLog.LogInformation(items);
            
            if (_amiiboServices.ValidateReturn(items, search))
            {
                return Ok(items);
            }
            else
            {
                return Ok("Ocorreu um problema de validação de itens");
            }
        }

        [HttpPost]
        public IActionResult Save([FromBody] AmiiboDTO data)
        {
            try
            {
                _amiiboServices.Adicionar(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Saves([FromBody] List<AmiiboDTO> data)
        {
            try
            {
                _amiiboServices.AdicionarVarios(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}