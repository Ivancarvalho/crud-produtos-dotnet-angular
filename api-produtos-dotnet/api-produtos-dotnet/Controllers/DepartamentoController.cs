// Caminho: api-produtos-dotnet/Controllers/DepartamentoController.cs

using Microsoft.AspNetCore.Mvc;

namespace api_produtos_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            var departamentos = new[]
            {
                new { Codigo = "010", Descricao = "BEBIDAS" },
                new { Codigo = "020", Descricao = "CONGELADOS" },
                new { Codigo = "030", Descricao = "LATICINIOS" },
                new { Codigo = "040", Descricao = "VEGETAIS" }
            };
            return Ok(departamentos);
        }
    }
}
