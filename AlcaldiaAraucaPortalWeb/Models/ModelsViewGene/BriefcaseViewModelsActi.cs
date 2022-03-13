using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class BriefcaseViewModelsActi
    {
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Titulo")]
        public string BriefcaseTitel { get; set; }

        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Foto")]
        public string BriefcaseImage { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Introduccion")]
        public string BriefcaseText { get; set; }

        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url")]
        public string BriefcaseUrl { get; set; }

        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Descripción")]
        public string BriefcaseDescrption { get; set; }

        public virtual ICollection<BriefcaseSocialNetworkViewModelsActi> BriefcaseSocialNetworks { get; set; } = new List<BriefcaseSocialNetworkViewModelsActi>();
    }
}
