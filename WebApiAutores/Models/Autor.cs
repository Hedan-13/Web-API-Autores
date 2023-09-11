using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAutores.Models
{
    [Table("Autor")]
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        #region propiedades de navegación
        public List<Libro> Libros { get; set; }
        #endregion
    }
}
