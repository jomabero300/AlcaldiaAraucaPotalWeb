using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class BriefcaseSocialNetworkViewModelsActi
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Red Social")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int SocialNetworkId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url")]
        public string URL { get; set; }
    }
}
