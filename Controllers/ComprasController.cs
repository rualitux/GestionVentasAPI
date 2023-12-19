using CJeanPIerreAPI.Models;
using CJeanPIerreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace CJeanPIerreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _service;

        public ComprasController(ICompraService service)
        {
            _service = service;
        }
        [EnableQuery]
        [HttpGet]
        public ActionResult<IQueryable<Compra>> GetCompras()
        {
            return Ok(_service.GetAllCompras());
        }
        //[EnableQuery]
        //[HttpGet("{key}")]
        //public ActionResult<Producto> GetCompraDetalleById([FromODataUri] int key)
        //{
        //    var item = _service.GetCompraDetalleById(key);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}

        [EnableQuery]
        [HttpGet("{key}")]
        public ActionResult<Producto> GetCompraById([FromODataUri] int key)
        {
            var item = _service.GetCompraById(key);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Compra item)
        
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (item.Proveedor == null && item.ProveedorId == null)
            {
                return BadRequest("Debe tener Proveedor");
            }
            _service.NuevaCompra(item);
            Console.WriteLine($"Creado compra: {item.NumeroReferencia} con Id {item.Id}");
            return Created("compras", item);
            //return CreatedAtAction(nameof(GetCompraDetalleById), "Compras", new { key = item.Id }, item);
            //return Ok();

        }
    }
}
