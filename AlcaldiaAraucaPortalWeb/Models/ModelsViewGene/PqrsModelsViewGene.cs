using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class PqrsModelsViewGene
    {
        public int PqrsId { get; set; }
        public DateTime PqrsDate { get; set; }
        public string UserId { get; set; }
        public int StateId { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsCategoryId { get; set; }

        [MaxLength(150, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Asunto")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string PqrsSubject { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string PqrsMessage { get; set; }

        [Display(Name = "Linea Estrategica")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsStrategicLineId { get; set; }

        [Display(Name = "Achivo 1")]
        public IFormFile FileOne { get; set; }

        [Display(Name = "Achivo 3")]
        public IFormFile FileTwo { get; set; }

        [Display(Name = "Foto 1")]
        public IFormFile ImgOne { get; set; }

        [Display(Name = "Foto 2")]
        public IFormFile ImgTwo { get; set; }


        public string FileOnePath { get; set; }
        public string FileTwoPath { get; set; }

        public string ImgOnePath { get; set; }
        public string ImgTwoPath { get; set; }
    }
}
