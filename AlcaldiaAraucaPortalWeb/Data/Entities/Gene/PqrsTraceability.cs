using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("PqrsTraceabilities", Schema = "Gene")]
    public class PqrsTraceability
    {
        [Key]
        public int PqrsTraceabilityId { get; set; }

        [Display(Name = "Pqrs")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsId { get; set; }

        [Display(Name = "Delegado")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsUserStrategicLineId { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PqrsTraceabilityDate { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Respuesta")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Answer { get; set; }
        public virtual Pqrs Pqrs { get; set; }
        public virtual PqrsUserStrategicLine PqrsUserStrategicLine { get; set; }

    }
}
