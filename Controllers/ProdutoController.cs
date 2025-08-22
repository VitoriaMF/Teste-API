using Microsoft.AspNetCore.Mvc;
using Teste.API.Models;
using Teste.API.Services.Interfaces;

namespace Teste.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll()
            => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            try
            {
                return Ok(_service.GetProduct(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Produto> Create(Produto produto)
        {
            try
            {
                _service.AddProduct(produto);
                return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/quantity")]
        public IActionResult UpdateQuantity(int id, [FromBody] int newQuantity)
        {
            try
            {
                _service.UpdateQuantity(id, newQuantity);
                return NoContent();
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.RemoveProduct(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{id}/sell")]
        public IActionResult Sell(int id, [FromBody] int amount)
        {
            try
            {
                _service.SellProduct(id, amount);
                return NoContent();
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException || ex is InvalidOperationException)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}