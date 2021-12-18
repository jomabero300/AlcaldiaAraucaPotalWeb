using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("PqrsAttachments", Schema = "Gene")]
    public class PqrsAttachments
    {
        [Key]
        public int PqrsAttachmentId { get; set; }

        [Display(Name = "P.Q.R.S")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Archivo")]
        public string PqrsAttachmentsPath { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Enviado")]
        public bool PqrSend { get; set; }

        public virtual Pqrs Pqrs { get; set; }

    }
}
