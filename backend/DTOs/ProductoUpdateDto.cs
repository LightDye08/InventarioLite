using System.ComponentModel.DataAnnotations;

namespace ProductosApp.DTOs
{
    public class ProductoUpdateDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }
    }
}
