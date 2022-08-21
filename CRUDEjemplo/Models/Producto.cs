using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CRUDEjemplo.Models
{
    public class Producto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
       [Required(ErrorMessage ="La categoria es obligatoria")]
       [Display(Name = "Categoria")]

        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]

        public float Precio { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creacion")]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Actualizacion")]
        public DateTime UpdateAt { get; set; }
    }
}
