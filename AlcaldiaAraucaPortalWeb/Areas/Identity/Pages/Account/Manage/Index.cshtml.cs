using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlcaldiaAraucaPortalWeb.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IGenderHelper _genderHelper;
        private readonly IDocumentTypeHelper _documentTypeHelper;
        private readonly IZoneHelper _zoneHelper;
        private readonly ICommuneTownshipHelper _communeTownship;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalk;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _mailHelper;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            IGenderHelper genderHelper,
            IDocumentTypeHelper documentTypeHelper,
            IZoneHelper zoneHelper,
            ICommuneTownshipHelper communeTownship,
            INeighborhoodSidewalkHelper neighborhoodSidewalk,
            IUserHelper userHelper,
            IMailHelper mailHelper)


        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _genderHelper = genderHelper;
            _documentTypeHelper = documentTypeHelper;
            _zoneHelper = zoneHelper;
            _communeTownship = communeTownship;
            _neighborhoodSidewalk = neighborhoodSidewalk;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Número de teléfono")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Documento")]
            [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            public string Document { get; set; }

            [Display(Name = "Tipo Documento")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int DocumentTypeId { get; set; }

            [Display(Name = "Nombres")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
            public string FirstName { get; set; }

            [Display(Name = "Apellidos")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
            public string LastName { get; set; }

            [Display(Name = "Fecha Nacimiento")]
            [Required(ErrorMessage = "El campo {0} es requerido")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
            public DateTime BirdDarte { get; set; }

            [Display(Name = "Género")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int GenderId { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Display(Name = "Dirección")]
            public string Address { get; set; }


            [Display(Name = "Zona")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int ZoneId { get; set; }

            [Display(Name = "Comuna/Corregimiento")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int CommuneTownshipId { get; set; }

            [Display(Name = "Barrio/Vereda")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int NeighborhoodSidewalkId { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Address=user.Address,
                BirdDarte=user.BirdDarte,
                DocumentTypeId=user.DocumentTypeId,
                Document=user.Document,
                FirstName=user.FirstName,
                GenderId=user.GenderId,
                LastName=user.LastName,         
                NeighborhoodSidewalkId=user.NeighborhoodSidewalkId,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
            }

            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName");
            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName");
            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "ZoneId", "ZoneName");
            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownship.ComboAsync(0), "CommuneTownshipId", "CommuneTownshipName");
            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalk.ComboAsync(0), "NeighborhoodSidewalkId", "NeighborhoodSidewalkName");

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Error inesperado al intentar configurar el número de teléfono.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Tu perfil ha sido actualizado";
            return RedirectToPage();
        }
    }
}
