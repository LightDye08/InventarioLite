using Microsoft.AspNetCore.Mvc;
using ProductosApp.DTOs;
using ProductosApp.Services.Interfaces;

namespace ProductosApp.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _service.GetByIdAsync(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoCreateDto dto)
        {
            var producto = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductoUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
