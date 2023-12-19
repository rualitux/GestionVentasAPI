namespace CJeanPIerreAPI.Models
{
    public class Inventario
    {
       public int Id { get; set; }
        public string? Estructura { get; set; } = "Unidad"; //Eg: Caja?? SixPack?? Saco 20 KG???
        public decimal? MultiplicadorUnidad { get; set; } = 1; //Caja de 6 unidades? Saco de 20.0 kg?
        public decimal? EstructuraCantidad { get; set; } //Cuantas cajas
        public Decimal? Stock 
        {
            get { return MultiplicadorUnidad * EstructuraCantidad; }
        }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public String? Lote { get; set; }
       public int? ProductoId{ get; set; }
       public int? AreaId { get; set; }

    }
}
