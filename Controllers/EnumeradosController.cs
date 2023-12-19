using CJeanPIerreAPI.Models;
using CJeanPIerreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CJeanPIerreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumeradosController : ControllerBase
    {
        private readonly IEnumeradoRepo _repo;

        public EnumeradosController(IEnumeradoRepo repo)
        {
            _repo=repo;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<Enumerado>> Get()
        {
            return Ok(_repo.GetAll());
        }

    }
}
