using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Tipo Documento")]
        public int DocumentTypeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime BirdDarte { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Genero")]
        public int GenderId { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public virtual Gender Gender { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
