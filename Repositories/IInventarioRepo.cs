using CJeanPIerreAPI.Models;

namespace CJeanPIerreAPI.Repositories
{
    public interface IInventarioRepo
    {
        public IQueryable<Inventario> GetAll();
        public IQueryable<Inventario> GetById(int id);
        public void Create(Inventario inventario);
        public void Update(Inventario inventario);
        public void Delete(Inventario inventario);
        public Area ForzarArea(int id);
        public Producto ForzarProducto(int id);
        public bool Save();
    }
}
