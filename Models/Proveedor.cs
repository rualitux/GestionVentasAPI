using System.ComponentModel.DataAnnotations;

namespace CJeanPIerreAPI.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        [StringLength(11, ErrorMessage ="RUC debe tener 11 dígitos")]
        public string? RUC { get; set; }
        public string? NombreProveedor { get; set; }
        [Phone]
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public List<Compra> Compras { get; set; }

    }
}
