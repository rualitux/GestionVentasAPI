using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CJeanPIerreAPI.Repositories
{
    public class InventarioRepo: IInventarioRepo
    {
        private readonly AppDbContext _context;

        public InventarioRepo(AppDbContext context)
        {
            _context=context;
            
        }

        public void Create(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
        }

        public void Delete(Inventario inventario)
        {
            throw new NotImplementedException();
        }

        public Area ForzarArea(int id)
        {
            throw new NotImplementedException();
        }

        public Producto ForzarProducto(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Inventario> GetAll()
        {
            var lista = _context.Inventarios
                        .AsQueryable();
            return lista;
        }

        public IQueryable<Inventario> GetById(int id)
        {
            var item = _context.Inventarios
                        .Where(p => p.Id == id);
            return item;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(Inventario inventario)
        {
            var item = _context.Inventarios
                         .Update(inventario);
        }
    }
}
