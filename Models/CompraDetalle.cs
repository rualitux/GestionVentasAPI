using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJeanPIerreAPI.Models
{
    public class CompraDetalle
    {

        public int Id { get; set; }
        public int? CantidadOrdenada { get; set; }
        public int? CantidadRecibida { get; set; }
        public int? CantidadRetornada { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Precio debe tener máximo 2 decimales")]
        public Decimal? CostoActual { get; set; }
        public Decimal? SubTotalOrdenado {
            get { return CostoActual * CantidadOrdenada; }
        }
        public Decimal? SubTotalRecibido {
            get { return CostoActual * CantidadRecibida; } }
        public Decimal? CostoRetornado {
            get { return CantidadRetornada * CostoActual; } }

        Decimal? _PrecioProducto
        { 
            get {
                if (Producto == null)
                {
                    return 0;
                }
                return Producto.CostoEstandar;
            }
            set {
                if (_PrecioProducto != null)
                    _PrecioProducto = value;   
            }
        }

        //private Decimal? PrecioProducto
        //{
        //    get => _PrecioProducto;
        //    set
        //    {
        //        if (_PrecioProducto == value)
        //        {
        //            return;
        //        }
        //        if (Producto != null)
        //        { _PrecioProducto = Producto.CostoEstandar; }
        //    }
        //}


        public Decimal? DiferenciaPrecio {
            get {
                return  CostoActual - _PrecioProducto;
            }
            set {
                if (_PrecioProducto != null)
                { return; }
                DiferenciaPrecio = value; }
        }           
    
        public int? CompraId { get; set; }
        [ForeignKey("ProductoId")]
        public int? ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
