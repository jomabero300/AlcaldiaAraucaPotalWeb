using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class PqrsModelsViewGene
    {
        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsCategoryId { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string PqrsMessage { get; set; }

        [Display(Name = "Linea Estrategica")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsStrategicLineId { get; set; }

        [Display(Name = "Achivo 1")]
        public IFormFile FileOne { get; set; }

        [Display(Name = "Achivo 2")]
        public IFormFile FileTwo { get; set; }

        [Display(Name = "Achivo 3")]
        public IFormFile ImgOne { get; set; }

        [Display(Name = "Achivo 4")]
        public IFormFile ImgTwo { get; set; }
    }
}
