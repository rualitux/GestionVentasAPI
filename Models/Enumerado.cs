namespace CJeanPIerreAPI.Models
{
    public class Enumerado
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Valor { get; set; }
        public int? Padre { get; set; }
        //public List<Proveedor> Proveedors { get; set; }
        //public List<Producto> Productos { get; set; }
    }
}
