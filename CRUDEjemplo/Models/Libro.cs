using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEjemplo.Models
{
    public class Libro
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="La descripcion es obligatoria")]

        public string Descripcion { get; set; }
        [Required(ErrorMessage ="El autor es obligatorio")]

        public string Autor { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage ="El precio es obligatorio")]
        
        public double Precio { get; set; }
    }
}
