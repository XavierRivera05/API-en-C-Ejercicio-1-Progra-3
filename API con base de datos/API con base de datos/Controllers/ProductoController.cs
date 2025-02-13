using Microsoft.AspNetCore.Mvc;
using API_con_base_de_datos.Models;
using API_con_base_de_datos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;


namespace API_con_base_de_datos.Controllers
{
    [Route("api/productos")]
    [ApiController]

    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _repository;

        public ProductoController(IProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _repository.GetbyIdAsync(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _repository.AddAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id) return BadRequest("El ID del producto no coincide.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingProducto = await _repository.GetbyIdAsync(id);
            if (existingProducto == null) return NotFound();

            await _repository.UpdateAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProducto = await _repository.GetbyIdAsync(id);
            if (existingProducto == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
