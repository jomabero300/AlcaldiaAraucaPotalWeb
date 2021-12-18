﻿using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class AffiliateGroupCommunityViewModelsProc
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Grupo comunatario")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int GroupCommunityId { get; set; }
        public virtual GroupCommunity GroupCommunity { get; set; }

    }
}
