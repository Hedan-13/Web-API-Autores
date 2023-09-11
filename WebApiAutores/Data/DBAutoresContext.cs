using Microsoft.EntityFrameworkCore;
using WebApiAutores.Models;

namespace WebApiAutores.Data
{
    public class DBAutoresContext:DbContext
    {
        public DBAutoresContext(DbContextOptions<DBAutoresContext> options) : base(options) { }

        public DbSet<Autor> Autores { get; set; }
    }
}
