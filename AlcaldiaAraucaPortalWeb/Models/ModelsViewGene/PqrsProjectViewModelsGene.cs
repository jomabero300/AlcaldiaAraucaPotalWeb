using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class PqrsProjectViewModelsGene : PqrsProject
    {
        [Display(Name = "Linea Estrategica")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsStrategicLineId { get; set; }
    }
}
