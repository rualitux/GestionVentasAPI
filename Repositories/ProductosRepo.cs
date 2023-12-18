using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CJeanPIerreAPI.Repositories
{
    public class ProductosRepo : IProductosRepo
    {
        private readonly AppDbContext _context;

        public ProductosRepo(AppDbContext context)
        {
            _context= context;
        }

        public void Create(Producto producto)
        {
          
            var item = _context.Productos.Add(producto);
        }

        public void Delete(Producto producto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Producto> GetAll()
        {

            var lista = _context.Productos
                .Include(p => p.Inventarios)
                .Include(p => p.CompraDetalles)
                .AsQueryable();
            return lista;
        }

        public IQueryable<Producto> GetById(int id)
        {
            var item = _context.Productos
                .Include(p => p.Inventarios)
                .Include(p => p.CompraDetalles)
                .Where(p => p.Id == id);
            return item;
        }

        public void Update(Producto producto)
        {
            var item = _context.Productos
                .Update(producto);
        }
        public bool Save()
        {
            return _context.SaveChanges() >= 0;

        }
    }
}
