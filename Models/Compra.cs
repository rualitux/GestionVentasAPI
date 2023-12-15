﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CJeanPIerreAPI.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string? NumeroReferencia { get; set; }
        public DateTime? FechaCompra { get; set; }
        public Decimal? TotalCompra {

            get {
                decimal? SumaTotal = 0;
                foreach (CompraDetalle compraDetalle in CompraDetalles)
                {
                    SumaTotal += compraDetalle.SubTotalOrdenado;                    
                }
                return SumaTotal;
            } }
        [ForeignKey("ProveedorId")]
        public int? ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }
        public List<CompraDetalle>? CompraDetalles { get; set; } = new List<CompraDetalle>();

    }
}
