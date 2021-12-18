using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
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

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IGenderHelper genderHelper,
            IDocumentTypeHelper documentTypeHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _genderHelper = genderHelper;
            _documentTypeHelper = documentTypeHelper;
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

            [Display(Name = "Genero")]
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
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName");
            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                {
                    Document=Input.Document,
                    DocumentTypeId=Input.DocumentTypeId,
                    FirstName=Input.FirstName,
                    LastName=Input.LastName,
                    BirdDarte=Input.BirdDarte,
                    GenderId=Input.GenderId,

                    UserName = Input.Email, 
                    Email = Input.Email 
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

                    await _emailSender.SendEmailAsync(Input.Email, "Confirme su email",
                        $"Confirme su cuenta por <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>haciendo click aqui</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName",Input.GenderId);

            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName",Input.DocumentTypeId);

            return Page();
        }
    }
}
