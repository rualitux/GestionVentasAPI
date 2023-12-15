using CJeanPIerreAPI.Models;

namespace CJeanPIerreAPI.Repositories
{
    public interface IProductosRepo
    {
        public IQueryable<Producto> GetAll();
        public IQueryable<Producto> GetById(int id);
        public void Create(Producto producto);
        public void Update(Producto producto);
        public void Delete(Producto producto);
        public bool Save();
    }
}
