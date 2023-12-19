using CJeanPIerreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CJeanPIerreAPI.Repositories
{
    public interface IEnumeradoRepo
    {
        IQueryable<Enumerado> GetAll();
    }
}
