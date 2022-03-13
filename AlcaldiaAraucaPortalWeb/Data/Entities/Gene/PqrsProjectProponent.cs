using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("PqrsProjectProponents", Schema = "Gene")]
    public class PqrsProjectProponent
    {
        [Key]
        public int PqrsProponentId { get; set; }

        [Display(Name = "Proyecto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int PqrsProjectId { get; set; }

        [Column(TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(13)")]
        [MaxLength(13, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        public virtual PqrsProject PqrsProject { get; set; }
    }
}
