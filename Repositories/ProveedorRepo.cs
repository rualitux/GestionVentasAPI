using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CJeanPIerreAPI.Repositories
{
    public class ProveedorRepo : IProveedorRepo
    {
        private readonly AppDbContext _context;

        public ProveedorRepo(AppDbContext context)
        {
            _context=context;
        }
        public void Create(Proveedor proveedor)
        {
            var item = _context.Proveedors.Add(proveedor);
        }

        public void Delete(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Proveedor> GetAll()
        {
            var lista = _context.Proveedors
                         .Include(p => p.Compras)
                         .AsQueryable();
            return lista;
        }

        public IQueryable<Proveedor> GetById(int id)
        {
            var item = _context.Proveedors
                       .Include(p => p.Compras)
                       .Where(p => p.Id == id);
            return item;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(Proveedor proveedor)
        {
            var item = _context.Proveedors
                         .Update(proveedor);
        }
    }
}
