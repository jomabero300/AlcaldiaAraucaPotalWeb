using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("Professions", Schema = "Gene")]

    public class Profession
    {
        [Key]
        public int ProfessionId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Profesión")]
        public string ProfessionName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Estado")]
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
