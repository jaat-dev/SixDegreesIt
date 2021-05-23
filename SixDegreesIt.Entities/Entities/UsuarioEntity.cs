using System.ComponentModel.DataAnnotations;

namespace SixDegreesIt.Entities.Entities
{
    public class UsuarioEntity
    {
        [Key]
        public int UsuId { get; set; }

        [StringLength(100, ErrorMessage = "Longitud del campo {0}, no puede ser mayor a {1}")]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "Longitud del campo {0}, no puede ser mayor a {1}")]
        public string Apellido { get; set; }
    }
}
