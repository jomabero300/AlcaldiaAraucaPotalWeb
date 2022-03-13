using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs
{
    public class ProfessionViewModel
    {
        [Display(Name = "Profesión")]
        public int ProfessionId { get; set; }
        
        [Display(Name = "Profesión")]
        public string ProfessionName { get; set; }

        public int Total { get; set; }

    }
}
