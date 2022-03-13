using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewCont;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Estrategias
{
    public class LineStrategicController : Controller
    {
        private readonly IPqrsStrategicLineSectorHelper _lineSectorHelper;
        private readonly IContentHelper _contentHelper;
        private readonly IContentOdsHelper _contentOdsHelper;
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLine;

        public LineStrategicController(IPqrsStrategicLineSectorHelper lineSectorHelper,
            IContentHelper contentHelper, 
            IContentOdsHelper contentOdsHelper,
            IPqrsStrategicLineHelper pqrsStrategicLine)
        {
            _lineSectorHelper = lineSectorHelper;
            _contentHelper = contentHelper;
            this._contentOdsHelper = contentOdsHelper;
            this._pqrsStrategicLine = pqrsStrategicLine;
        }

        #region Desarrollo social
        public async Task<IActionResult> Cultura()
        {
            var strategicLineId = await PqrsStrategicLineId("Desarrollo social incluyente");

            var OdsText = "Accesso de la población colombiana a espacios culturales. \n Bienes Y manifestaciones del patrimonio cultural reconocidos y protegidos";
            var OdsImag = "~/Image/Menu/ODS/11ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-11-sustainable-cities-and-communities.html";

            return RedirectToAction("GeneViewHorizontal", new { lTipo = "Cultura", PqrsStrategicLineId= strategicLineId, OdsText=OdsText, OdsImag=OdsImag, ODSUrl= OdsUrl});
        }
        public async Task<IActionResult> Deporte()
        {
            var OdsText = "poblacion que raliza actividad física en su tiempo libre";
            var OdsImag = "~/Image/Menu/ODS/5ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-5-gender-equality.html";

            var strategicLineId =await PqrsStrategicLineId("Desarrollo social incluyente");

            return RedirectToAction("GeneView", new { lTipo="Deporte", tituloHead ="Sección de Deporte", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> Educacion()
        {
            var OdsText = "Cobertura bruta en la educación inicial preescolar, basica y media";
            var OdsImag = "~/Image/Menu/ODS/4ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-4-quality-education.html";

            var strategicLineId =await PqrsStrategicLineId("Desarrollo social incluyente");

            return RedirectToAction("GeneView",new { lTipo = "Educación", tituloHead = "Seccion de Educacion",PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> InclusionSocial()
        {
            var OdsText = "Indicador de pobreza multidimensional (IPM)";
            var OdsImag = "~/Image/Menu/ODS/5ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-5-gender-equality.html";

            var strategicLineId =await PqrsStrategicLineId("Desarrollo social incluyente");

            return RedirectToAction("GeneViewHorizontal", new { lTipo = "Inclusión social", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> SaludyProteccion()
        {
            var OdsText = "Tasa de mortalidad prematura por enfermedades no transmisibles (por 100.000 habitantes de 30 a 70 años)";
            var OdsImag = "~/Image/Menu/ODS/2ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-2-zero-hunger.html";

            var strategicLineId =await PqrsStrategicLineId("Desarrollo social incluyente");

            return RedirectToAction("GeneView", new { lTipo = "Salud y protección", tituloHead = "Salud y protección", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> DesarrolloSocialNormatividad()
        {
            var OdsText = "Tasa de mortalidad prematura por enfermedades no transmisibles (por 100.000 habitantes de 30 a 70 años)";
            var OdsImag = "~/Image/Menu/ODS/2ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-2-zero-hunger.html";

            var strategicLineId =await PqrsStrategicLineId("Desarrollo social incluyente");

            return RedirectToAction("GeneViewHorizontal", new { lTipo = "Normatividad", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        #endregion

        #region Crecimiento economico

        public async Task<IActionResult> AgriculturaDesarrolloRural()
        {
            var OdsText = "Porcentaje de unidades de producción agropecuaria (UPAS) que recibieron asistencia técnica";
            var OdsImag = "~/Image/Menu/ODS/8ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-8-decent-work-and-economic-growth.html";

            var strategicLineId = await PqrsStrategicLineId("Crecimiento económico");

            return RedirectToAction("GeneView", new { lTipo = "Agricultura y desarrollo rural", tituloHead = "Agricultura y Desarrollo Rural", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> CienciaTecnologiaInnovacion()
        {
            var OdsText = "Personas que desarrollan actividades de ciencia tecnología e innovación";
            var OdsImag = "~/Image/Menu/ODS/9ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-9-industry-innovation-and-infrastructure.html";

            var strategicLineId = await PqrsStrategicLineId("Crecimiento económico");

            return RedirectToAction("GeneView", new { lTipo = "Ciencia, tecnología e innovación", tituloHead = "Ciencia y Tecnología Innovacion", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> Trabajo()
        {
            var OdsText = "Tasa de desempleo";
            var OdsImag = "~/Image/Menu/ODS/12ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-12-responsible-consumption-and-production.html";

            var strategicLineId = await PqrsStrategicLineId("Crecimiento económico");

            return RedirectToAction("GeneView", new { lTipo = "Trabajo", tituloHead = "Trabajo", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl });
        }
        public async Task<IActionResult> ComercionIndustriaTurismo()
        {
            var OdsText = "Valor agregado por sectores económicos (Medido en miles de millones de pesos corrientes)";
            var OdsImag = "~/Image/Menu/ODS/12ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-12-responsible-consumption-and-production.html";

            var strategicLineId = await PqrsStrategicLineId("Crecimiento económico");

            return RedirectToAction("GeneView", new { lTipo = "Comercio, industria y turismo", tituloHead = "Comercio Industria y Turismo", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> CrecimientoEconomicoNormatividad()
        {
            var strategicLineId = await PqrsStrategicLineId("Crecimiento económico");
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = "Normatividad", PqrsStrategicLineId = strategicLineId });
        }
        #endregion

        #region Arauca Verde, Ordenaday Sostenible

        public async Task<IActionResult> AmbienteyDesarrolloSostenible()
        {
            var OdsText = "Área deforestada en la entidad territorial";
            var OdsImag = "~/Image/Menu/ODS/13ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-13-climate-action.html";

            var strategicLineId = await PqrsStrategicLineId("Arauca verde, ordenada y sostenible");

            return RedirectToAction("GeneView", new { lTipo = "Ambiente desarrollo sostenible", tituloHead = "Ambiente y desarrollo sostenible", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl});
        }
        public async Task<IActionResult> AtencionDesastre()
        {
            var OdsText = "Evento de riesgos de desastres";
            var OdsImag = "~/Image/Menu/ODS/11ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-11-sustainable-cities-and-communities.html";

            var strategicLineId = await PqrsStrategicLineId("Arauca verde, ordenada y sostenible");

            return RedirectToAction("GeneView", new { lTipo = "Gobierno territorial - Atención a desastres", tituloHead = "Gobierno territorial - Atención a desastres" , PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl });
        }

        public async Task<IActionResult> AraucaVedeOrdenadaSostenibleNormatividad()
        {
            var strategicLineId = await PqrsStrategicLineId("Arauca verde, ordenada y sostenible");
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = "Normatividad", PqrsStrategicLineId = strategicLineId });
        }

        #endregion

        #region Infraestrutura Social y Productiva
        public async Task<IActionResult> Transporte()
        {
            var OdsText = "Personas lesionadas con incapacidad permanentes por siniestros viales)";
            var OdsImag = "~/Image/Menu/ODS/9ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-9-industry-innovation-and-infrastructure.html";

            var strategicLineId = await PqrsStrategicLineId("Infraestructura social y productiva");

            return RedirectToAction("GeneView", new { lTipo = "Transporte", tituloHead = "Transporte", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl });
        }      
        public async Task<IActionResult> MinasyEnergia()
        {
            var OdsText = "Intensidad de energía eléctrica";
            var OdsImag = "~/Image/Menu/ODS/7ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-7-affordable-and-clean-energy.html";

            var strategicLineId = await PqrsStrategicLineId("Infraestructura social y productiva");

            return RedirectToAction("GeneView", new { lTipo = "Minas y energía", tituloHead = "Minas y energía", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl });
        }
        public async Task<IActionResult> ViviendaInfra()
        {
            var OdsText = "Intensidad de energía eléctrica";
            var OdsImag = "~/Image/Menu/ODS/6ODS.png";
            var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-6-clean-water-and-sanitation.html";

            var strategicLineId = await PqrsStrategicLineId("Infraestructura social y productiva");

            return RedirectToAction("GeneView", new { lTipo = "Vivienda", tituloHead = "Vivienda", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl });
        }
        public async Task<IActionResult> InfraestructuraSocialProductivaNormatividad()
        {
            var strategicLineId = await PqrsStrategicLineId("Infraestructura social y productiva");
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = "Normatividad", PqrsStrategicLineId = strategicLineId });
        }
        #endregion

        #region Buen gobierno

        public async Task<IActionResult> InformacionEstadistica()
        {
            var strategicLineId = await PqrsStrategicLineId("Buen gobierno");

            return RedirectToAction("GeneView", new { lTipo = "Información estadisiticas", tituloHead = "Información estadisiticas", PqrsStrategicLineId = strategicLineId});
        }
        public async Task<IActionResult> BuenGobiernoTerritorial()
        {
            var strategicLineId = await PqrsStrategicLineId("Buen gobierno");
            return RedirectToAction("GeneView", new { lTipo = "Gobierno territorial", tituloHead = "Gobierno territorial", PqrsStrategicLineId = strategicLineId });
        }
        public async Task<IActionResult> Tecnologia()
        {
            var strategicLineId = await PqrsStrategicLineId("Buen gobierno");
            return RedirectToAction("GeneView", new { lTipo = "Tecnologioas de la información y las comunicaciones", tituloHead = "Tecnologioas de la información y las comunicaciones", PqrsStrategicLineId = strategicLineId });
        }
        public async Task<IActionResult> ViviendaBuen()
        {
            var strategicLineId = await PqrsStrategicLineId("Buen gobierno");
            return RedirectToAction("GeneView", new { lTipo = "Vivienda", tituloHead = "Vivienda", PqrsStrategicLineId = strategicLineId });
        }
        public async Task<IActionResult> BuenGobiernoNormatividad()
        {
            var strategicLineId = await PqrsStrategicLineId("Buen gobierno");
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = "Normatividad", PqrsStrategicLineId = strategicLineId });
        }
        #endregion

        #region Seguridad, Convivencia y Justicia

        public async Task<IActionResult> JusticiaDerecho()
        {
            var strategicLineId = await PqrsStrategicLineId("Seguridad convivencia y justicia");

            return RedirectToAction("GeneView", new { lTipo = "Justicia y derecho", tituloHead = "Justicia y derecho", PqrsStrategicLineId = strategicLineId });
        }
        public async Task< IActionResult> InclusionSocial2()
        {
            var strategicLineId = await PqrsStrategicLineId("Seguridad convivencia y justicia");
            return RedirectToAction("GeneView", new { lTipo = "Inclusion social", tituloHead = "Inclusion social", PqrsStrategicLineId = strategicLineId });
        }
        public async Task< IActionResult> GobiernoTerritorial()
        {
            var strategicLineId = await PqrsStrategicLineId("Seguridad convivencia y justicia");
            return RedirectToAction("GeneView", new { lTipo = "Gobierno territorial", tituloHead = "Gobierno territorial", PqrsStrategicLineId = strategicLineId });
        }
        public async Task< IActionResult> ViviendaSeguridad()
        {
            var strategicLineId = await PqrsStrategicLineId("Seguridad convivencia y justicia");
            return RedirectToAction("GeneView", new { lTipo = "Vivienda", tituloHead = "Vivienda", PqrsStrategicLineId = strategicLineId });
        }
        public async Task<IActionResult> SeguridadConvivenciaJusticiaNormatividad()
        {
            var strategicLineId = await PqrsStrategicLineId("Seguridad convivencia y justicia");
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = "Normatividad", PqrsStrategicLineId = strategicLineId });
        }
        #endregion

        #region Gestion del conocimiento
        public async Task<IActionResult> GestionConocimiento()
        {
            List<Models.ContentModelView> model = new List<Models.ContentModelView>();

            //var OdsText = "Porcentaje de unidades de producción agropecuaria (UPAS) que recibieron asistencia técnica";
            //var OdsImag = "~/Image/Menu/ODS/8ODS.png";
            //var OdsUrl = "https://www1.undp.org/content/undp/es/home/sustainable-development-goals/goal-8-decent-work-and-economic-growth.html";

            //var strategicLineId = await PqrsStrategicLineId("Gestión del conocimiento");

            //return RedirectToAction("GeneView", new { lTipo = "Agricultura y desarrollo rural", tituloHead = "Agricultura y Desarrollo Rural", PqrsStrategicLineId = strategicLineId, OdsText = OdsText, OdsImag = OdsImag, ODSUrl = OdsUrl });
            int codigo =await PqrsStrategicLineId("Gestión del conocimiento");

            var sectorId = await _lineSectorHelper.ByNameAsync("Gestión del conocimiento",codigo);

            if (sectorId != null)
            {

                var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);
                model = Contenido.Select(x => new Models.ContentModelView { title = x.ContentTitle, text = x.ContentText, img = x.ContentUrlImg, url = x.ContentId.ToString()}).ToList();
                //foreach (var item in Contenido)
                //{
                //    model.Contents.Add(new Models.Content() { title = item.ContentTitle.ToUpper(), text = item.ContentText, img = item.ContentUrlImg, url = item.ContentId.ToString() });
                //}
            }

            return View(model);
        }
        public IActionResult GestionConocimientoNormatividad()
        {
            return RedirectToAction("GeneView1", new { lTipo = "11", tituloHead = "Normatividad", subTituloHead = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" });
        }
        #endregion

        #region P.Q.R.S
        public IActionResult Pqrs()
        {
            return RedirectToAction("Index", "Pqrs");
        }
        public IActionResult PropuestaDetallada()
        {
            return RedirectToAction("Index", "PqrsProjects");
        }
        public IActionResult PqrsNormatividad()
        {
            return RedirectToAction("GeneView1", new { lTipo = "11", tituloHead = "Normatividad", subTituloHead = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" });
        }

        #endregion

        #region Ingresar / Registrarse
        public IActionResult Ingresar()
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }
        public IActionResult Registrarse()
        {
            return RedirectToPage("/Account/Register",new { area="Identity"});
        }
        public IActionResult ForgoPassword()
        {
            return RedirectToPage("/Account/ForgotPassword", new { area = "Identity" });
        }

        #endregion

        //Imagen completa horizontal Cultura
        public async Task<IActionResult> GeneViewHorizontal(string lTipo,int PqrsStrategicLineId,string OdsText,string OdsImag, string ODSUrl)
        {
            var model = new ContentGeneViewModels();

            var sectorId = await _lineSectorHelper.ByNameAsync(lTipo, PqrsStrategicLineId);
            if(sectorId != null)
            {
                var ods = await _contentOdsHelper.ByIdAsync(sectorId.PqrsStrategicLineSectorId);
                if(ods !=null)
                {
                    foreach (var item in ods)
                    {
                        model.ContentOds.Add(new ContentOds { ContentOdsText = item.ContentOdsText, ContentOdsImg = item.ContentOdsImg, ContentOdsUrl = item.ContentOdsUrl });
                    }
                }
                var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);

                if (Contenido != null)
                {
                    int lnCont = 0;

                    foreach (var item in Contenido)
                    {
                        if (lnCont == 0)
                        {
                            ViewBag.TituloHead = item.ContentTitle.ToUpper();
                            ViewBag.SubTituloHead = getLinks( item.ContentText);
                            ViewBag.RulImagen = item.ContentUrlImg;
                            ViewBag.Url = item.ContentId;
                        }
                        else
                        {
                            model.Contents.Add(new Models.ContentModelView() { title = item.ContentTitle.ToUpper(), text = item.ContentText, img = item.ContentUrlImg,url=item.ContentId.ToString() });
                        }
                        lnCont++;
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> GeneViewHorizontalDetails(int id)
        {
            var model = await _contentHelper.ListDetailsAsync(id);

            return View(model);
        }
        //Carrucel image lado derecho carrucel deporte
        public IActionResult GeneViewVertical(string lTipo, string tituloHead)
        {
            //List<Models.Content> model = ltLista(lTipo);
            ViewBag.TituloHead = tituloHead;

            return View();
        }

        //Columna Educacion
        public async Task<IActionResult> GeneView(string lTipo,string tituloHead,string subTituloHead,int PqrsStrategicLineId, string OdsText, string OdsImag,string ODSUrl)
        {
            var model = new ContentGeneViewModels();

            ViewBag.TituloHead = tituloHead.ToUpper();
            
            ViewBag.SubTituloHead = subTituloHead;

            var sectorId = await _lineSectorHelper.ByNameAsync(lTipo, PqrsStrategicLineId);
            
            if(sectorId !=null)
            {
                var ods = await _contentOdsHelper.ByIdAsync(sectorId.PqrsStrategicLineSectorId);
                if (ods != null)
                {
                    foreach (var item in ods)
                    {
                        model.ContentOds.Add(new ContentOds { ContentOdsText = item.ContentOdsText, ContentOdsImg = item.ContentOdsImg, ContentOdsUrl = item.ContentOdsUrl });
                    }
                }

                var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);

                foreach (var item in Contenido)
                {
                    model.Contents.Add(new Models.ContentModelView() { title = item.ContentTitle.ToUpper(), text = item.ContentText, img = item.ContentUrlImg,url=item.ContentId.ToString() });
                }
            }

            return View(model);
        }

        private async Task<int> PqrsStrategicLineId(string name)
        {
            var model = await _pqrsStrategicLine.ByNameAsync(name);

            return model.PqrsStrategicLineId;
        }
        public String getLinks(String text)
        {
            String pattern;
            pattern = @"(http:\/\/([\w.]+\/?)\S*)";
            Regex re = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            text = re.Replace(text, "<a href=\"$1\" target=\"_blank\">$1</a>");
            return text;
        }




        public IActionResult GeneViewHorizontal1(string lTipo,string tituloHead,string subTituloHead,string rulImagen)
        {
            List<Models.ContentModelView> model = ltLista(lTipo);

            ViewBag.TituloHead = tituloHead;
            ViewBag.SubTituloHead = subTituloHead;
            ViewBag.RulImagen = rulImagen;

            //var sectorId =await _lineSectorHelper.ByNameAsync(lTipo);
            //var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);


            //foreach (var item in Contenido)
            //{
            //    model.Add(new Models.Content() { title = item.ContentTitle, text = item.ContentText, img = item.ContentUrlImg });
            //}

            return View(model);
        }

        //Carrucel image lado derecho carrucel deporte
        public IActionResult GeneViewVertical1(string lTipo, string tituloHead)
        {
            //List<Models.Content> model = ltLista(lTipo);
            ViewBag.TituloHead = tituloHead;

            return View();
        }

        //Columna Educacion
        public IActionResult GeneView1(string lTipo,string tituloHead,string subTituloHead)
        {
            List<Models.ContentModelView> model = ltLista(lTipo);
            ViewBag.TituloHead = tituloHead;
            ViewBag.SubTituloHead = subTituloHead;


            //var sectorId = await _lineSectorHelper.ByNameAsync(lTipo);
            //var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);


            //foreach (var item in Contenido)
            //{
            //    model.Add(new Models.Content() { title = item.ContentTitle, text = item.ContentText, img = item.ContentUrlImg });
            //}


            return View(model);
        }

        private List<Models.ContentModelView> ltLista(string tTipo)
        {
            if (tTipo == "11")
            {
                return new List<Models.ContentModelView>()
                {
                    new Models.ContentModelView
                    {
                        title = "Card Layout 1",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://image.shutterstock.com/image-vector/breaking-news-background-tv-channel-260nw-731436349.jpg"
                    },
                    new Models.ContentModelView
                    {
                        title = "Card Layout 2",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://t4.ftcdn.net/jpg/03/31/19/05/360_F_331190574_qlCiuR5fWBaQuC7jMFGasykUP1TAnTqT.jpg"
                    },
                    new Models.ContentModelView
                    {
                        title = "Card Layout 3",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://media.gettyimages.com/vectors/live-breaking-news-headline-with-blue-and-red-color-background-vector-id1221950506?s=612x612"
                    },
                    new Models.ContentModelView
                    {
                        title = "Card Layout 4",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://media.gettyimages.com/vectors/breaking-news-background-stock-illustration-vector-id1219181572?s=612x612"
                    }
                };
            }
            else if (tTipo == "12")
            {
                return new List<Models.ContentModelView>()
                {
                    new Models.ContentModelView
                    {
                        title = "Card Layout 1",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://image.shutterstock.com/image-vector/breaking-news-background-tv-channel-260nw-731436349.jpg"
                    },
                    new Models.ContentModelView
                    {
                        title = "Card Layout 2",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://t4.ftcdn.net/jpg/03/31/19/05/360_F_331190574_qlCiuR5fWBaQuC7jMFGasykUP1TAnTqT.jpg"
                    },
                    new Models.ContentModelView
                    {
                        title = "Card Layout 3",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://media.gettyimages.com/vectors/live-breaking-news-headline-with-blue-and-red-color-background-vector-id1221950506?s=612x612"
                    },
                    new Models.ContentModelView
                    {
                        title = "Card Layout 4",
                        text = "Hello every this video I want to show how to use cardbootstrap 4 with data binding sourcer.",
                        img = "https://media.gettyimages.com/vectors/breaking-news-background-stock-illustration-vector-id1219181572?s=612x612"
                    }
                };
            }
            throw new NotImplementedException();
        }

        
    }
}
