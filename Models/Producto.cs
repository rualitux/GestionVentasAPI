using System.ComponentModel.DataAnnotations;

namespace CJeanPIerreAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage ="Precio debe tener máximo 2 decimales")]
        public decimal? CostoEstandar { get; set; }
        public List<Inventario>? Inventarios { get; set; }
        public List<CompraDetalle>? CompraDetalles { get; set; }

    }
}
