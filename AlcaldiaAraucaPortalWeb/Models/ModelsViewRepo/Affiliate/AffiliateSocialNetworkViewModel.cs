using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate
{
    public class AffiliateSocialNetworkViewModel
    {
        [Display(Name = "Red social")]
        public int SocialNetworkId { get; set; }

        [Display(Name = "Red social")]
        public string SocialNetworkName { get; set; }

        public int Total { get; set; }
    }
}
