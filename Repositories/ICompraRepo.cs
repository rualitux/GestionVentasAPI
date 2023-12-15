using CJeanPIerreAPI.Models;

namespace CJeanPIerreAPI.Repositories
{
    public interface ICompraRepo
    {
        public IQueryable<Compra> GetAll();
        public IQueryable<Compra> GetById(int id);
        public void Create(Compra compra);
        public void Update(Compra compra);
        public void Delete(Compra compra);
        public Proveedor ForzarProveedor(int id);
        public bool Save();
    }
}
