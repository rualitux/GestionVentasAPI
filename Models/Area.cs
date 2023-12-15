namespace CJeanPIerreAPI.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string? NombreArea { get; set; }
        public string? Sucursal { get; set; }
        public List<Inventario> Inventarios { get; set; } = new List<Inventario>();
    }
}
