using CJeanPIerreAPI.Models;

namespace CJeanPIerreAPI.Repositories
{
    public interface IProveedorRepo
    {
        public IQueryable<Proveedor> GetAll();
        public IQueryable<Proveedor> GetById(int id);
        public void Create(Proveedor proveedor);
        public void Update(Proveedor proveedor);
        public void Delete(Proveedor proveedor);
        public bool Save();
    }
}
