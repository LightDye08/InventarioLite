using ProductosApp.DTOs;
using ProductosApp.Repositories.Interfaces;
using ProductosApp.Services.Interfaces;
using ProductosApp.Models;

namespace ProductosApp.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductoResponseDto>> GetAllAsync()
        {
            var productos = await _repo.GetAllAsync();
            return productos.Select(p => new ProductoResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                FechaCreacion = p.FechaCreacion
            });
        }

        public async Task<ProductoResponseDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new ProductoResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                FechaCreacion = p.FechaCreacion
            };
        }

        public async Task<ProductoResponseDto> CreateAsync(ProductoCreateDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio
            };
            var created = await _repo.CreateAsync(producto);
            return new ProductoResponseDto
            {
                Id = created.Id,
                Nombre = created.Nombre,
                Precio = created.Precio,
                FechaCreacion = created.FechaCreacion
            };
        }

        public async Task<bool> UpdateAsync(int id, ProductoUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            existing.Nombre = dto.Nombre;
            existing.Precio = dto.Precio;
            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.DeleteAsync(existing);
            return true;
        }
    }
}
