using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("PqrsProjectActivities", Schema = "Gene")]
    public class PqrsProjectActivitie
    {
        [Key]
        public int PqrsProjectActivitieId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Proyecto")]
        public int PqrsProjectId { get; set; }

        [Column(TypeName = "varchar(90)")]
        [MaxLength(90, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Presupuesto")]
        public double Budget { get; set; }

        [Display(Name = "Fecha Inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Fecha Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }

        public string TiewmpoEjecucion => $"{DateEnd.Subtract(DateStart)}";

        public virtual PqrsProject PqrsProject { get; set; }
    }
}
