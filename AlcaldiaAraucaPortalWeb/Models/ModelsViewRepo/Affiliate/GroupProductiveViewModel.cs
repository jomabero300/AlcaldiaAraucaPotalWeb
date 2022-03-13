using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate
{
    public class GroupProductiveViewModel
    {
        [Display(Name = "Grupo Productivo")]
        public int GroupProductiveId { get; set; }

        [Display(Name = "Grupo Productivo")]
        public string GroupProductiveName { get; set; }

        public int Total { get; set; }
    }
}
