using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CJeanPIerreAPI.Repositories
{
    public class CompraDetalleRepo : ICompraDetalleRepo
    {
        private readonly AppDbContext _context;

        public CompraDetalleRepo(AppDbContext context)
        {
            _context=context;
        }
        public void Create(CompraDetalle compraDetalle)
        {
            var item = _context.CompraDetalles.Add(compraDetalle);
        }

        public void Delete(CompraDetalle compraDetalle)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CompraDetalle> GetAll()
        {
            var lista = _context.CompraDetalles
                .Include(p=>p.Producto)
                           .AsQueryable();
            return lista;
        }

        public IQueryable<CompraDetalle> GetById(int id)
        {
            
            var item = _context.CompraDetalles
                //.Include(p=>p.Producto)
                        .Where(p => p.Id == id);
            return item;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(CompraDetalle compraDetalle)
        {
            var item = _context.CompraDetalles
                       .Update(compraDetalle);
        }
    }
}
