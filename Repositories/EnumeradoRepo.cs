using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CJeanPIerreAPI.Repositories
{
    public class EnumeradoRepo: IEnumeradoRepo
    {
        private readonly AppDbContext _context;

        public EnumeradoRepo(AppDbContext context)
        {
            _context=context;
        }
        public IQueryable<Enumerado> GetAll()
        {
            return _context.Enumerados.AsQueryable();
        }
    }
}
