﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("Pqrs", Schema = "Gene")]
    public class Pqrs
    {
        [Key]
        public int PqrsId { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsCategoryId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [MaxLength(450, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Usuario")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PqrsDate { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Nota")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string PqrsMessage { get; set; }

        [Display(Name = "Estado")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int StateId { get; set; }


        public virtual PqrsCategory PqrsCategory { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<PqrsAttachments> PqrsAttachments { get; set; }
    }
}
