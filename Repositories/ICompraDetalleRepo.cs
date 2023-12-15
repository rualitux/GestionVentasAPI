using CJeanPIerreAPI.Models;

namespace CJeanPIerreAPI.Repositories
{
    public interface ICompraDetalleRepo
    {
        public IQueryable<CompraDetalle> GetAll();
        public IQueryable<CompraDetalle> GetById(int id);
        public void Create(CompraDetalle compraDetalle);
        public void Update(CompraDetalle compraDetalle);
        public void Delete(CompraDetalle compraDetalle);
        public bool Save();
    }
}
