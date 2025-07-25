// Caminho: api-produtos-dotnet/Controllers/ProdutoController.cs

using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApiProdutos.Services;
using ApiProdutos.Models;
using System.Collections.Generic;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;
        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _service.GetProdutosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(Guid id)
        {
            var produto = await _service.GetProdutoByIdAsync(id);
            if (produto == null) return NotFound();
            return produto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            await _service.AddProdutoAsync(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Produto produto)
        {
            produto.Id = id;
            await _service.UpdateProdutoAsync(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.ExcluirProdutoAsync(id);
            return NoContent();
        }

        [HttpGet("/api/departamentos")]
        public ActionResult<IEnumerable<Departamento>> GetDepartamentos()
        {
            return Ok(_service.GetDepartamentos());
        }
    }
}
