using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using CJeanPIerreAPI.Models;

namespace CJeanPIerreAPI.Services
{
    public interface ICompraService
    {
        public void NuevaCompra(Compra compra);
        public void AgregarCompraDetalle(CompraDetalle detalle);
        public IQueryable<Compra> GetAllCompras();
        public IDbContextTransaction CrearTransaccion();
        public IQueryable<CompraDetalle> GetCompraDetalleById(int id);
        public void NuevoCompraDetalle(CompraDetalle compraDetalle);
        public bool EsProveedorNuevo(int id);

    }
}
