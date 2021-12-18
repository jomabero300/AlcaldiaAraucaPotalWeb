using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("PqrsCategories", Schema = "Gene")]
    public class PqrsCategory
    {
        [Key]
        public int PqrsCategoryId { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Descripción")]
        public string PqrsCategoryName { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
