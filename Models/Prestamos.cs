using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamo.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio"), Range(minimum: 1, maximum: 50000000, ErrorMessage = "Debe tener un minimo de 1 y máximo de 50,000,000")]
        public double Monto { get; set; }

        public double Balance { get; set; }
    }
}
