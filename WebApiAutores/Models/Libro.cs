using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Helper;

namespace WebApiAutores.Models
{
    [Table("Libro")]
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [TituloLibroValidation]
        public string Titulo { get; set; }
        [Required]
        [Column(TypeName = "money")]
        [PrecioLibroValidation]
        public decimal Precio { get; set; }

        public int AutorId { get; set; }

        #region propiedades de navegación
        public Autor Autor { get; set; }
        #endregion

    }
}
