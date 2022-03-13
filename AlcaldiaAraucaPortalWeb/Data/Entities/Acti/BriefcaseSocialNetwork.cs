using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Acti
{
    [Table("BriefcaseSocialNetworks", Schema = "Acti")]

    public class BriefcaseSocialNetwork
    {
        [Key]
        public int BriefcaseSocialNetworkId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Portafolio")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int BriefcaseId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Red Social")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int SocialNetworkId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url")]
        public string URL { get; set; }

        public virtual Briefcase Briefcase { get; set; }

        public virtual SocialNetwork SocialNetwork { get; set; }

    }
}
