using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiAutores.Data;
using WebApiAutores.Helper;
using WebApiAutores.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AccionPersonalizadoFilterAttibute))]
    public class LibroController : ControllerBase
    {
        private readonly DBLibrosContext context;

        public LibroController(DBLibrosContext context)
        {
            this.context = context;
        }

        // GET api/Libro
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            return context.Libros.ToList();
        }

        //Get api/Libro/1
        [HttpGet("{id}")]
        public ActionResult<Libro> GetById(int id)
        {
            return context.Libros.Find(id);
        }

        //Get api/Libro/Title
        [HttpGet("GetByTitle/{title}")]
        public ActionResult<Libro> GetByTitle(string title)
        {
            var libro = (from l in context.Libros where l.Titulo == title select l).FirstOrDefault();
            return libro;
        }

        // POST api/Libro
        //Modelo "Libro"  POST-->cuerpo del http
        [HttpPost]
        public ActionResult Post(Libro Libro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //agregar la Libro en memoria
            context.Libros.Add(Libro);

            //guardo DB
            context.SaveChanges();// conectarse DB, insert into..., desconecta

            return Ok();
        }

        //PUT api/Libro/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, Libro Libro)
        {
            if (id != Libro.Id)
            {
                return BadRequest();
            }

            //EF modificar memoria
            context.Entry(Libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return NoContent();

        }

        //DELETE api/Libro/id
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var Libro = context.Libros.Find(id);

            if (Libro == null)
            {
                return NotFound();
            }

            // EF en memoria marcar el objeto para eliminar 
            context.Libros.Remove(Libro);
            //aplicar los cambios en la DB
            context.SaveChanges();
            return Libro;

        }
    }
}
