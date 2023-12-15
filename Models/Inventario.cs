namespace CJeanPIerreAPI.Models
{
    public class Inventario
    {
       public int Id { get; set; }
       public int? Stock { get; set; }        
       public int? ProductoId{ get; set; }
       public int? AreaId { get; set; }

    }
}
