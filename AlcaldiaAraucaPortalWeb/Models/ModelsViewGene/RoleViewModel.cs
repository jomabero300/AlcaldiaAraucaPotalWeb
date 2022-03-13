using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewGene
{
    public class RoleViewModel
    {
        [Display(Name = "Rol")]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
