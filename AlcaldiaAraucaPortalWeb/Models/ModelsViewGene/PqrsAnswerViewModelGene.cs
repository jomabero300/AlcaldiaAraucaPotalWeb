using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class PqrsAnswerViewModelGene
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int PqrsId { get; set; }

        [Display(Name = "Usuario")]
        public string FullName { get; set; }

        [Display(Name = "Categoria")]
        public string PqrsCategoryName { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PqrsDate { get; set; }

        [Display(Name = "Asunto")]
        public string PqrsSubject { get; set; }

        [Display(Name = "Mensaje")]
        public string PqrsMessage { get; set; }

        [Display(Name = "Respuesta")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string PqrsAnswer { get; set; }

        public List<PqrsAnswerFileViewModelGene> Files { get; set; }
    }

    public class PqrsAnswerFileViewModelGene
    {
        public int PqrsId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Archivo")]
        public string PqrsAttachmentsPath { get; set; }

        public virtual PqrsAnswerViewModelGene Pqrs { get; set; }

    }
}
