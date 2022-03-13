using System;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs
{
    public class PqrsLineCategoryViewModel
    {
        [Display(Name = "Categoría")]
        public int PqrsCategoryId { get; set; }

        [Display(Name = "Linea estratégica")]
        public int PqrsStrategicLineId { get; set; }

        [Display(Name = "Fecha desde")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime PqrsDateStart { get; set; }

        [Display(Name = "Fecha hasta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime PqrsDateEnd { get; set; }
    }
}
