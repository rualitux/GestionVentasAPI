namespace CJeanPIerreAPI.Models
{
    public class Inventario
    {
       public int Id { get; set; }
       public int? Stock { get; set; }
       public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public String? Lote { get; set; }
       //public Enumerado? UnidadMedidad { get; set; }
       public int? ProductoId{ get; set; }
       public int? AreaId { get; set; }

    }
}
