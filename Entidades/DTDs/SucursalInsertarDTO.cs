using System.ComponentModel.DataAnnotations;

namespace Entidades.DTDs
{
    public class SucursalInsertarDTO
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage ="Maximo de caracteres superado")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage ="Maximo de caracteres superado")]
        public string Descripcion { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Maximo de caracteres superado")]
        public string Direccion { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximo de caracteres superado")]
        public string Identificacion { get; set; }
        [Required]
        public int IdMoneda { get; set; }
    }
}
