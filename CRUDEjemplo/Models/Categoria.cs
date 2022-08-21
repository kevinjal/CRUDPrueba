using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CRUDEjemplo.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creacion")]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Actualizacion")]
        public DateTime UpdateAt { get; set; }
    }
}
