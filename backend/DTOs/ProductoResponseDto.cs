namespace ProductosApp.DTOs
{
    public class ProductoResponseDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
