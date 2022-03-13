using AlcaldiaAraucaPortalCommon;
using AlcaldiaAraucaPortalReport;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Reports
{
    [Authorize(Roles = "Administrador")]
    public class ReportsController : Controller
    {
        private readonly IPqrsCategoryHelper _pqrsCategoryHelper;
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLineHelper;
        private readonly IProfessionHelper _professionHelper;
        private readonly IGroupProductiveHelper _groupProductiveHelper;
        private readonly IPqrsTraceabilityHelper _traceabilityHelper;
        private readonly IAffiliateProfessionHelper _affiliateProfessionHelper;
        private readonly IAffiliateGroupProductiveHelper _affiliateGroupProductiveHelper;
        private readonly IGroupCommunityHelper _groupCommunityHelper;
        private readonly IAffiliateSocialNetworkHelper _socialNetworkHelper;
        private readonly ISocialNetworkHelper _networkHelper;
        private readonly IRoleHelper _roleHelper;
        private readonly IUserHelper _userHelper;

        public ReportsController(IPqrsCategoryHelper pqrsCategoryHelper,
                                 IPqrsStrategicLineHelper pqrsStrategicLineHelper,
                                 IProfessionHelper professionHelper,
                                 IGroupProductiveHelper groupProductiveHelper,
                                 IPqrsTraceabilityHelper traceabilityHelper,
                                 IAffiliateProfessionHelper affiliateProfessionHelper,
                                 IAffiliateGroupProductiveHelper affiliateGroupProductiveHelper,
                                 IGroupCommunityHelper groupCommunityHelper,
                                 IAffiliateSocialNetworkHelper socialNetworkHelper,
                                 ISocialNetworkHelper networkHelper,
                                 IRoleHelper roleHelper,
                                 IUserHelper userHelper)
        {
            _pqrsCategoryHelper = pqrsCategoryHelper;
            _pqrsStrategicLineHelper = pqrsStrategicLineHelper;
            _professionHelper = professionHelper;
            _groupProductiveHelper = groupProductiveHelper;
            _traceabilityHelper = traceabilityHelper;
            _affiliateProfessionHelper = affiliateProfessionHelper;
            _affiliateGroupProductiveHelper = affiliateGroupProductiveHelper;
            _groupCommunityHelper = groupCommunityHelper;
            this._socialNetworkHelper = socialNetworkHelper;
            this._networkHelper = networkHelper;
            this._roleHelper = roleHelper;
            this._userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> PqrsReportLineCategory()
        {
            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName");
            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            return View();
        }

        [HttpPost, ActionName("PqrsReportLineCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PqrsReportLineCategoryConfirmed(PqrsLineCategoryViewModel model)
        {

            List<PqrsLineCategoryModelViewModel> rpt = await _traceabilityHelper.StatisticsReportAsync(model);

            var diccionario = new Dictionary<string, object>();

            diccionario.Add("DsPqrsLineCategory", rpt.ToDataTable<PqrsLineCategoryModelViewModel>());

            ReportService rp = new ReportService();

            var path = "Reports\\Pqrs\\PqrsLineCategory.rdlc";

            var RpResult = rp.GenerateReportAsync(path, diccionario);

            var stream2 = new MemoryStream(RpResult.MainStream.ToArray());

            return new FileStreamResult(stream2, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "LineaCategoria.pdf"
            };


            //ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName");
            //ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> AffiliateProfessionsRdlc()
        {
            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ComboReportAsync(), "ProfessionId", "ProfessionName");

            return View();
        }

        [HttpPost, ActionName("AffiliateProfessionsRdlc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliateProfessionsRdlcGenerate(ProfessionViewModel model)
        {
            List<ProfessionViewModel> profe = await _affiliateProfessionHelper.StatisticsReportAsync(model);

            var diccionario = new Dictionary<string, object>();

            diccionario.Add("DsProfesion", profe.ToDataTable<ProfessionViewModel>());

            ReportService rp = new ReportService();

            var path = "Reports\\Afiliate\\AffiliateProfession.rdlc";

            var RpResult = rp.GenerateReportAsync(path, diccionario);

            var stream2 = new MemoryStream(RpResult.MainStream.ToArray());

            return new FileStreamResult(stream2, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "Profesión.pdf"
            };

        }

        [HttpGet]
        public async Task<IActionResult> AffiliatePqrsGrupoProductivoRdlc()
        {
            ViewData["GroupProductiveId"] = new SelectList(await _groupProductiveHelper.ComboReportAsync(), "GroupProductiveId", "GroupProductiveName");

            return View();
        }

        [HttpPost, ActionName("AffiliatePqrsGrupoProductivoRdlc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliatePqrsGrupoProductivoRdlcGenerate(GroupProductiveViewModel model)
        {

            List<GroupProductiveViewModel> groupProductives = await _affiliateGroupProductiveHelper.StatisticsReportAsync(model);

            var diccionario = new Dictionary<string, object>();

            diccionario.Add("DsAffiliateGroupProductive", groupProductives.ToDataTable<GroupProductiveViewModel>());

            ReportService rp = new ReportService();

            var path = "Reports\\Afiliate\\AfiliateGroupProductive.rdlc";

            var RpResult = rp.GenerateReportAsync(path, diccionario);

            var stream2 = new MemoryStream(RpResult.MainStream.ToArray());

            return new FileStreamResult(stream2, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "GrupoProductivo.pdf"
            };
        }

        [HttpGet]
        public async Task<IActionResult> AffiliateGrupoComunitarioRdlc()
        {
            ViewData["GroupCommunityId"] = new SelectList(await _groupCommunityHelper.ComboReportAsync(), "GroupCommunityId", "GroupCommunityName");

            return View();
        }
        [HttpPost, ActionName("AffiliateGrupoComunitarioRdlc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliateGrupoComunitarioRdlcGenerate(GroupCommunityViewModel model)
        { 
            List<GroupCommunityViewModel> grupoComunitario = await _groupCommunityHelper.StatisticsReportAsync(model);

            var diccionario = new Dictionary<string, object>();

            diccionario.Add("DsAffiliateGrupoComunitario", grupoComunitario.ToDataTable<GroupCommunityViewModel>());

            ReportService rp = new ReportService();

            var path = "Reports\\Afiliate\\AffiliateGrupoComunitario.rdlc";

            var RpResult = rp.GenerateReportAsync(path, diccionario);

            var stream2 = new MemoryStream(RpResult.MainStream.ToArray());

            return new FileStreamResult(stream2, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "GrupoComunitario.pdf"
            };
        }

        [HttpGet]
        public async Task<IActionResult> AffiliateSocialNetworkRdlc()
        {
            ViewData["SocialNetworkId"] = new SelectList(await _networkHelper.ComboReportAsync(), "SocialNetworkId", "SocialNetworkName");

            return View();
        }
        [HttpPost, ActionName("AffiliateSocialNetworkRdlc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliateSocialNetworkRdlcRdlcGenerate(AffiliateSocialNetworkViewModel model)
        {
            List<AffiliateSocialNetworkViewModel> rpt = await _socialNetworkHelper.StatisticsReportAsync(model);

            var diccionario = new Dictionary<string, object>();

            diccionario.Add("DsAffiliateSocialNetwork", rpt.ToDataTable<AffiliateSocialNetworkViewModel>());

            ReportService rp = new ReportService();

            var path = "Reports\\Afiliate\\AffiliateSocialNetwork.rdlc";

            var RpResult = rp.GenerateReportAsync(path, diccionario);

            var stream2 = new MemoryStream(RpResult.MainStream.ToArray());

            return new FileStreamResult(stream2, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "RedSocial.pdf"
            };
        }

        [HttpGet]
        public async Task<IActionResult> UserRdlc()
        {
            ViewData["Id"] = new SelectList(await _roleHelper.ComboAsync(), "Id", "Name");

            return View();
        }
        [HttpPost, ActionName("UserRdlc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRdlcGenerate(RoleViewModel model)
        {
            List<UsersViewModel> rpt = await _userHelper.UsersRoleComboAsync(model.Id);
            var diccionario = new Dictionary<string, object>();

            diccionario.Add("DsUsersRegister", rpt.ToDataTable<UsersViewModel>());

            ReportService rp = new ReportService();

            var path = "Reports\\Afiliate\\UsersRegister.rdlc";

            var RpResult = rp.GenerateReportAsync(path, diccionario);

            var stream2 = new MemoryStream(RpResult.MainStream.ToArray());

            return new FileStreamResult(stream2, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "UsuariosRegistrador.pdf"
            };
        }
    }
}
