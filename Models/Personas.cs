using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamo.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombres { get; set; }

        [RegularExpression(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$",ErrorMessage ="Cédula no válida")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio")]
        public double Balance { get; set; }
    }
}
