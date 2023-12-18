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

            IQueryable<CompraDetalle> item = _detalleRepo.GetById(id);                           
            return item;
            
        }
        

        public void NuevaCompra(Compra compra)        
        
        {
            compra.FechaRegistro = DateTime.Now;
            compra.FechaModificacion = DateTime.Now;
            _compraRepo.Create(compra);
            List<Inventario> inventariosAgregados = new List<Inventario>();
            foreach (var item in compra.CompraDetalles)
            {
                item.FechaRegistro = DateTime.Now;
                item.FechaModificacion = DateTime.Now;                 
                Inventario nuevoInventario = new Inventario() {
                Lote = item.Lote,
                FechaRegistro = item.FechaRegistro,
                FechaModificacion = item.FechaModificacion,
                FechaExpiracion = item.FechaExpiracion,
                Stock = item.CantidadRecibida,
                ProductoId = item.ProductoId,
                //Manda a almacen directamente
                AreaId = 1
                };
                _inventarioRepo.Create(nuevoInventario);
            }
            DateTime? dateCompra = compra.FechaRegistro;
            string anoCompra = dateCompra.Value.ToString("yyyMMddHHmm");
            //Explicit/Eager loading de NavP: Compra.Proveedor
            if (compra.Proveedor == null)
            {
                int? proveedorIdNullable = compra.ProveedorId;
                //compra.Proveedor = _compraRepo.ForzarProveedor((int)proveedorIdNullable);
                compra.Proveedor = ForzarProveedor((int)proveedorIdNullable);
            }
            compra.NumeroReferencia = $"P{compra.Proveedor.RUC}F{anoCompra}";
            _compraRepo.Save();            
        }  

        public void NuevoCompraDetalle(CompraDetalle compraDetalle)
        {
            _detalleRepo.Create(compraDetalle);
        }

        public void NuevoInventario(Inventario inventario)
        {
            _inventarioRepo.Create(inventario);
        }
          public Proveedor ForzarProveedor(int id)
        {
            var proveedor = _proveedorRepo.GetById(id);
            var proveedorSalida = proveedor.Single();
            return proveedorSalida;
        }
    }
}
