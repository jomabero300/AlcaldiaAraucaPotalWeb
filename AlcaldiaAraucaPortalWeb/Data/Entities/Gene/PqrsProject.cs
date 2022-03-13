using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("PqrsProjects", Schema = "Gene")]
    public class PqrsProject
    {
        [Key]
        public int PqrsProjectId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [MaxLength(450, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Usuario")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Column(TypeName = "datetime2")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date, ErrorMessage = "Invalido el formato de la fecha")]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Objeto")]
        public string Object { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Radicado No")]
        public string PqrsProjectLocated { get; set; }

        [Display(Name = "Estado")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int StateId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual State State { get; set; }
        public virtual List<PqrsProjectActivitie> PqrsProjectActivities { get; set; } = new List<PqrsProjectActivitie>();
        public virtual List<PqrsProjectProponent> PqrsProjectProponents { get; set; } = new List<PqrsProjectProponent>();
    }
}
