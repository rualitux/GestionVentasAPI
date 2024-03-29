﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJeanPIerreAPI.Models
{
    public class CompraDetalle
    {

        public int Id { get; set; }
        public string? Estructura { get; set; } = "Unidad"; //Eg: Caja?? SixPack?? Saco 20 KG???
        public decimal? MultiplicadorUnidad { get; set; } = 1; //Caja de 6 unidades? Saco de 20.0 kg?
        public Decimal? CantidadOrdenada { get; set; }
        public Decimal? CantidadRecibida { get; set; }
        public Decimal? CantidadRetornada { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Precio debe tener máximo 2 decimales")]
        public Decimal? CostoActual { get; set; }
        public Decimal? SubTotalOrdenado {
            get { return CostoActual*(MultiplicadorUnidad * CantidadOrdenada); }
        }
        public Decimal? SubTotalDiferencia {
            get { return DiferenciaPrecio * (MultiplicadorUnidad * CantidadRecibida); }
        }
        public Decimal? SubTotalRecibido {
            get { return CostoActual * (MultiplicadorUnidad * CantidadRecibida); } }
        public Decimal? CostoRetornado {
            get { return CostoActual * (MultiplicadorUnidad * CantidadRetornada); } }

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
        public string? ProductoString {
            get
            {
                if (Producto == null)
                {
                    return null;
                }
                return Producto.Nombre;
            }
            set
            {
                if (ProductoString != null)
                    ProductoString = value;
            }
        }

        public string? EstadoAhorroItem
        {
            get
            {
                if (SubTotalDiferencia != null)
                {
                    if (SubTotalDiferencia >= 0)
                        return "Gasto";
                    return "Ahorro";
                }
                return null;
            }
        }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public String? Lote { get; set; }
        public int? CompraId { get; set; }
        [ForeignKey("ProductoId")]
        public int? ProductoId { get; set; }
        [JsonIgnore]
        public Producto? Producto { get; set; }
    }
}
