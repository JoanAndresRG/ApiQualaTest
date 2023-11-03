using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTDs
{
    public class SucursalActualizarDTO
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Maximo de caracteres superado")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Maximo de caracteres superado")]
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
