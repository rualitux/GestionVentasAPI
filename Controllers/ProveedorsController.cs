using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using CJeanPIerreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace CJeanPIerreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorsController : ControllerBase
    {
        private readonly IProveedorRepo _proveedorRepo;

        public ProveedorsController(IProveedorRepo proveedorRepo)
        {
            _proveedorRepo = proveedorRepo;
        }
        [HttpGet]
        [EnableQuery(MaxExpansionDepth =3)]
        public ActionResult<IQueryable<Proveedor>> Get()
        {
            return Ok(_proveedorRepo.GetAll());
        }
        [HttpGet("{id}")]
        [EnableQuery(MaxExpansionDepth =3)]
        public ActionResult<Proveedor> GetById([FromRoute] int id)
        {
            var item = _proveedorRepo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Proveedor item)
        {
            Console.WriteLine($"Creando proveedor: {item.RUC}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            item.FechaRegistro = DateTime.Now;
            item.FechaModificacion = DateTime.Now;
            _proveedorRepo.Create(item);
            _proveedorRepo.Save();
            Console.WriteLine($"Creado proveedor: {item.RUC} con Id {item.Id}");
            return Created("proveedors", item);

        }
        [HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromODataUri] int id, [FromBody] Proveedor item)

        {
            //var producto = _repo.GetById(id).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != item.Id)
            {
                return BadRequest();
            }
            item.FechaModificacion = DateTime.Now;
            _proveedorRepo.Update(item);
            _proveedorRepo.Save();
            return Ok(item);
        }


        [HttpPatch("{id}")]
        public IActionResult Patch([FromODataUri] int id, [FromBody] JsonPatchDocument<Proveedor> item)
        {
            if (item != null)
            {
                var itemOriginal = _proveedorRepo.GetById(id).FirstOrDefault();               
                item.ApplyTo(itemOriginal, ModelState);
                itemOriginal.FechaModificacion = DateTime.Now;
                _proveedorRepo.Update(itemOriginal);
                _proveedorRepo.Save();
                return Ok(item);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);


        }

    }
}
