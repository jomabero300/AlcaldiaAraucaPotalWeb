using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace AlcaldiaAraucaPortalWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IGenderHelper _genderHelper;
        private readonly IDocumentTypeHelper _documentTypeHelper;
        private readonly IZoneHelper _zoneHelper;
        private readonly ICommuneTownshipHelper _communeTownship;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalk;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _mailHelper;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
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
            _logger = logger;
            _emailSender = emailSender;
            _genderHelper = genderHelper;
            _documentTypeHelper = documentTypeHelper;
            _zoneHelper = zoneHelper;
            _communeTownship = communeTownship;
            _neighborhoodSidewalk = neighborhoodSidewalk;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

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
            [EmailAddress]
            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de  {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }

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

            [Display(Name = "Longitud")]
            public string Length { get; set; }

            [Display(Name = "Latitud")]
            public string Latitude { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName");
            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName");
            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "ZoneId", "ZoneName");            
            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownship.ComboAsync(0), "CommuneTownshipId", "CommuneTownshipName");
            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalk.ComboAsync(0), "NeighborhoodSidewalkId", "NeighborhoodSidewalkName");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var firstName = lLowr( Input.FirstName.ToLower());

                var user = new ApplicationUser 
                {
                    Document=Input.Document,
                    DocumentTypeId=Input.DocumentTypeId,
                    FirstName= lLowr(Input.FirstName.ToLower()),
                    LastName= lLowr(Input.LastName.ToLower()),
                    BirdDarte=Input.BirdDarte,
                    GenderId=Input.GenderId,
                    UserName = Input.Email, 
                    Email = Input.Email,
                    NeighborhoodSidewalkId=Input.NeighborhoodSidewalkId,
                    Length=Input.Length,
                    Latitude=Input.Latitude,
                    Address= lLowr(Input.Address.ToLower())
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var lre = await _userManager.AddToRoleAsync(user, "Usuario");
                    _logger.LogInformation("El usuario creó una nueva cuenta con contraseña.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);



                    var response = _mailHelper.SendMail(
                                        user.Email,
                                        "Araucactiva - Confirmación de cuenta",
                                        $"<h1>Araucactiva - Confirmación de cuenta</h1>" +
                                        $"Para habilitar el usuario, " +
                                        $"por favor hacer clic en el siguiente enlace: <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Confirmar Email</a>.");

                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });


                    //await _emailSender.SendEmailAsync(
                    //                    Input.Email,
                    //                    "Confirme su email",
                    //                    $"Confirme su cuenta en este enlace <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>haciendo click aqui</a>.");


                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    string lMensaje=string.Empty;

                    if (error.Description.Contains("alphanumeric character"))
                    {
                        lMensaje="Las contraseñas deben contener al menos un caracter numérico.";
                    }
                    else if (error.Description.Contains("lowercase ('a'-'z')"))
                    {
                        lMensaje="Las contraseñas deben contener al menos una letra minúscula ('a'-'z').";
                    }
                    else if (error.Description.Contains("uppercase ('A'-'Z')"))
                    {
                        lMensaje="Las contraseñas deben contener al menos una letra mayúsculas ('A'-'Z').";
                    }
                    else
                    {
                        lMensaje="revise la conformación de las contraseñas";
                    }



                    ModelState.AddModelError(string.Empty, lMensaje);
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName",Input.GenderId);

            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName",Input.DocumentTypeId);

            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "ZoneId", "ZoneName",Input.ZoneId);

            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownship.ComboAsync(Input.ZoneId), "CommuneTownshipId", "CommuneTownshipName",Input.CommuneTownshipId);

            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalk.ComboAsync(Input.CommuneTownshipId), "NeighborhoodSidewalkId", "NeighborhoodSidewalkName",Input.NeighborhoodSidewalkId);

            return Page();
        }

        private string lLowr(string cadena)
        {
            if(cadena.Length>0)
            {
                var letra = cadena.Substring(0,1).ToUpper();

                cadena = letra + cadena.Substring(1, cadena.Length-1);
            }

            return cadena;
        }
    }
}
