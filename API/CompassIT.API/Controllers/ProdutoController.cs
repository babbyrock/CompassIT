using CompassIT.Application.DTOs;
using CompassIT.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompassIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var produtos = await _produtoService.GetAllProdutosAsync(cancellationToken);
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id, CancellationToken cancellationToken)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id, cancellationToken);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Produto inválido.");

            var produtoCriado = _produtoService.AddProduto(produtoDto);

            return StatusCode(201, produtoCriado); 
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoDTO produtoDto)
        {
            var atualizado = _produtoService.UpdateProduto(id, produtoDto);
            if (!atualizado) return NotFound();

            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var removido = _produtoService.DeleteProduto(id);
            if (!removido) return NotFound();
            return Ok(removido);
        }
    }
}
