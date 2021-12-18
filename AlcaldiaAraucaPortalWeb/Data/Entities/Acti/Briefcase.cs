using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Acti
{
    [Table("Briefcases", Schema = "Acti")]
    public class Briefcase
    {
        [Key]
        public int BriefcaseId { get; set; }

        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Titulo")]
        public string BriefcaseTitel { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Foto")]
        public string BriefcaseImage { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Introduccion")]
        public string BriefcaseText { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url")]
        public string BriefcaseUrl { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Introduccion")]
        public string BriefcaseDescrption { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Facebbok")]
        public string BriefcaseFacebook { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Twitter")]
        public string BriefcaseTwitter { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Skype")]
        public string BriefcaseSkype { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Google")]
        public string BriefcaseGoogle { get; set; }
    }
}
