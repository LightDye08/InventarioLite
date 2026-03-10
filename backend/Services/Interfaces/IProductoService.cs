using ProductosApp.DTOs;

namespace ProductosApp.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoResponseDto>> GetAllAsync();

        Task<ProductoResponseDto?> GetByIdAsync(int id);

        Task<ProductoResponseDto> CreateAsync(ProductoCreateDto dto);

        Task<bool> UpdateAsync(int id, ProductoUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
