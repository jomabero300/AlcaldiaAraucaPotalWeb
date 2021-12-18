using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Proc
{
    [Table("AffiliateProfessionGalleries", Schema = "Proc")]
    public class AffiliateProfessionGallery
    {
        [Key]
        public int AffiliateEthnicGroupId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Descripción")]
        public int AffiliateProfessionId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Imagen")]
        public string AffiliateProfessionGalleryPath { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public virtual AffiliateProfession AffiliateProfession { get; set; }
    }
}
