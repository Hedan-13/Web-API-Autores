using Microsoft.EntityFrameworkCore;
using WebApiAutores.Models;

namespace WebApiAutores.Data
{
    public class DBLibrosContext : DbContext
    {
        public DBLibrosContext(DbContextOptions<DBLibrosContext> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
