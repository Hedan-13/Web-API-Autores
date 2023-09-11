using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiAutores.Data;
using WebApiAutores.Models;
using System.Linq;

namespace WebApiAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly DBAutoresContext context;

        public AutorController(DBAutoresContext context)
        {
            this.context = context;
        }

        // GET api/Autor
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return context.Autores.ToList();
        }

        //Get api/Autor/1
        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {
            return context.Autores.Find(id);
        }

        // POST api/Autor
        //Modelo "Autor"  POST-->cuerpo del http
        [HttpPost]
        public ActionResult Post(Autor Autor)
        {
            //agregar la Autor en memoria
            context.Autores.Add(Autor);

            //guardo DB
            context.SaveChanges();// conectarse DB, insert into..., desconecta

            return Ok();
        }

        //PUT api/Autor/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, Autor Autor)
        {
            if (id != Autor.Id)
            {
                return BadRequest();
            }

            //EF modificar memoria
            context.Entry(Autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return NoContent();

        }

        //DELETE api/Autor/id
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var Autor = context.Autores.Find(id);

            if (Autor == null)
            {
                return NotFound();
            }

            // EF en memoria marcar el objeto para eliminar 
            context.Autores.Remove(Autor);
            //aplicar los cambios en la DB
            context.SaveChanges();
            return Autor;

        }

    }
}
