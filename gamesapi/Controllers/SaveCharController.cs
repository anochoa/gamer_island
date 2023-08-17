using gamesapi.infra;
using gamesapi.infra.modelo;
using Microsoft.AspNetCore.Mvc;

namespace gamesapi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SaveCharController : ControllerBase
{
    
    [HttpPost]
    public IActionResult Save([FromBody] Amiibo saver,string connectionstring = "Host=localhost;Port=3366;user=root;database=amiiboo;password=my-secret-pw;")
    {
        var repo = new repositorio_de_dados("Host=localhost;Port=3366;user=root;database=games;password=my-secret-pw;");
        var enviar = new Amiibooo();
        repo.TranslateToAmiibooo(saver, out enviar);
        
        return Ok(new repositorio_de_dados("Host=localhost;Port=3366;user=root;database=amiiboo;password=my-secret-pw;").Save(enviar));
    }
    
}