using CJeanPIerreAPI.Data;
using CJeanPIerreAPI.Models;
using CJeanPIerreAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CJeanPIerreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IProductosRepo _repo;

        public ProductosController(IProductosRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<Producto>> Get()
        {
            return Ok(_repo.GetAll());
        }
        [HttpGet("{id}")]
        [EnableQuery]
        public ActionResult<Producto> GetById([FromRoute] int id)
        {
            var item = _repo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Producto item)
        {
            Console.WriteLine($"Creando producto: {item.Nombre}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Create(item);
            _repo.Save();
            Console.WriteLine($"Creado producto: {item.Nombre} con Id {item.Id}");
            return Created("productos", item);

        }   
        [HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromODataUri] int id, [FromBody] Producto item)
        
        {
            //var producto = _repo.GetById(id).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id!= item.Id)
            {
                return BadRequest();
            }
            _repo.Update(item);
            _repo.Save();
            return Ok(item);
        }


        [HttpPatch("{id}")]
        public IActionResult Patch([FromODataUri] int id, [FromBody] JsonPatchDocument<Producto> item)
        {
            if (item != null)
            {
                var producto = _repo.GetById(id).FirstOrDefault();                
                item.ApplyTo(producto, ModelState);
                _repo.Update(producto);
                _repo.Save();
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
