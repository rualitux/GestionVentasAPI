using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CJeanPIerreAPI.Repositories
{
    public class CompraRepo : ICompraRepo
    {
        private readonly AppDbContext _context;

        public CompraRepo(AppDbContext context)
        {
            _context=context;
        }
        public void Create(Compra compra)
        {
           _context.Compras.Add(compra);

        }

        public void Delete(Compra compra)
        {
            throw new NotImplementedException();
        }


        public Proveedor ForzarProveedor(int id)
        {
            Proveedor? proveedor = _context.Compras.Include(p => p.Proveedor)
                 .Single(f => f.ProveedorId == id)
                 .Proveedor;
            return proveedor;
        }



        public IQueryable<Compra> GetAll()
        {

            var lista = _context.Compras
                .Include(p => p.CompraDetalles)
                .AsQueryable();
            return lista;
        }

        public IQueryable<Compra> GetById(int id)
        {
            var item = _context.Compras
                    .Include(p => p.CompraDetalles)
                    .Where(p => p.Id == id);
            return item;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(Compra compra)
        {
            var item = _context.Compras
                .Update(compra);
        }
    }
}
