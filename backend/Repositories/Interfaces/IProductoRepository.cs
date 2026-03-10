using ProductosApp.Models;
using ProductosApp.DTOs;

namespace ProductosApp.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();

        Task<Producto?> GetByIdAsync(int id);

        Task<Producto> CreateAsync(Producto producto);

        Task UpdateAsync(Producto producto);

        Task DeleteAsync(Producto producto);
    }
}
