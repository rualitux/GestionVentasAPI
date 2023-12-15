using CJeanPIerreAPI.Models;
using CJeanPIerreAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CJeanPIerreAPI.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepo _compraRepo;
        private readonly ICompraDetalleRepo _detalleRepo;
        private readonly IProveedorRepo _proveedorRepo;
        private readonly IInventarioRepo _inventarioRepo;

        public CompraService(ICompraRepo compraRepo 
            ,ICompraDetalleRepo detalleRepo 
            ,IProveedorRepo proveedorRepo
            ,IInventarioRepo inventarioRepo)
        {
            _compraRepo=compraRepo;
            _detalleRepo=detalleRepo;
            _proveedorRepo = proveedorRepo;
            _inventarioRepo=inventarioRepo;


        }
        public void AgregarCompraDetalle(CompraDetalle detalle)
        {
            _detalleRepo.Create(detalle);
            _detalleRepo.Save();
        }

        public IDbContextTransaction CrearTransaccion()
        {
            throw new NotImplementedException();
        }

        public bool EsProveedorNuevo(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Compra> GetAllCompras()
        {
            return _compraRepo.GetAll();
        }

        public IQueryable<CompraDetalle> GetCompraDetalleById(int id)
        {

            var item = _detalleRepo.GetById(id);
                return item;
            
        }
        

        public void NuevaCompra(Compra compra)
        {
            compra.FechaCompra = DateTime.Now;
            List<CompraDetalle> listaAgregar = new List<CompraDetalle>();      
            _compraRepo.Create(compra);         
            DateTime? dateCompra = compra.FechaCompra;
            string anoCompra = dateCompra.Value.ToString("yyyMMddHHmm");            
            if (compra.ProveedorId != null)
            {
                int? proveedorIdNullable = compra.ProveedorId;
                compra.Proveedor = _compraRepo.ForzarProveedor((int)proveedorIdNullable);
                compra.NumeroReferencia = $"P{compra.Proveedor.RUC}T{anoCompra}";
            }
            _compraRepo.Save();
        }
        public void NuevoCompraDetalle(CompraDetalle compraDetalle)
        {
            _detalleRepo.Create(compraDetalle);
        }
    }
}
