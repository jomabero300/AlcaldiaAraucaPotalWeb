﻿using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewSusc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Susc
{
    public class SubscribersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsStrategicLineSectorHelper _sectorHelper;
        private readonly IStateHelper _stateHelper;
        private readonly IMailHelper _mailHelper;
        private readonly ISubscriberHelper _subscriber;


        public SubscribersController(ApplicationDbContext context,
                                     IPqrsStrategicLineSectorHelper sectorHelper,
                                     IStateHelper stateHelper,
                                     IMailHelper mailHelper, ISubscriberHelper subscriber)
        {
            _context=context;
            _sectorHelper=sectorHelper;
            _stateHelper=stateHelper;
            this._mailHelper=mailHelper;
            _subscriber=subscriber;
        }
        public async Task<IActionResult> Index()
        {
            List<PqrsStrategicLineSector> modelSect = await _sectorHelper.ListAsync();

            SubscriberDetaModelView model = new SubscriberDetaModelView();

            model.Subscribers=modelSect.Select(x => new SubscriberModelsView
            {
                check=false,
                PqrsStrategicLineName=x.PqrsStrategicLine.PqrsStrategicLineName,
                PqrsStrategicLineSectorId=x.PqrsStrategicLineSectorId,
                PqrsStrategicLineSectorName=x.PqrsStrategicLineSectorName
            }).ToList();



            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> Index([FromBody] DatosSector model)
        {
            int stateId = await _stateHelper.StateIdAsync("G", "Activo");
            Subscriber subscribete = new Subscriber
            {
                email=model.email,
                EmailConfirmed=false,
                StateId=stateId,
                SubscriberSectors=model.TempChecks.Select(x => new SubscriberSector
                {
                    PqrsStrategicLineSectorId= int.Parse(x.ToString()),
                    StateId=stateId,
                    Url= SelectUrl(x)
                }).ToList(),
            };

            try
            {
                _context.Subscribers.Add(subscribete);
                await _context.SaveChangesAsync();

                string myToken = "2510";
                string tokenLink = Url.Action("ConfirmSubscriber", "Home", new
                {
                    userid = subscribete.SubscriberId.ToString(),
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendMail(model.email, "Araucactiva - Confirmación de subscripción", $"<h1>Araucactiva - Confirmación de subscripción</h1>" +
                    $"Para habilitar la subscripción, " +
                    $"por favor hacer clic en el siguiente enlace: </br></br><a href = \"{tokenLink}\">Confirmar Email</a>");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }

            return Json(true);
        }

        private string SelectUrl(int sectorId)
        {
            PqrsStrategicLineSector model = _sectorHelper.ById(sectorId);
            string url = string.Empty;

            
            if(model.PqrsStrategicLine.PqrsStrategicLineName.Contains("Desarrollo social"))
            {
                if (model.PqrsStrategicLineSectorName == "Cultura")
                {
                    url = "11";
                }
                else if (model.PqrsStrategicLineSectorName == "Deporte")
                {
                    url = "12";
                }
                else if (model.PqrsStrategicLineSectorName == "Educación")
                {
                    url = "13";
                }
                else if (model.PqrsStrategicLineSectorName == "Inclusión social")
                {
                    url = "14";
                }
                else if (model.PqrsStrategicLineSectorName == "Salud y protección")
                {
                    url = "15";
                }
            }
            else if (model.PqrsStrategicLine.PqrsStrategicLineName.Contains("Crecimiento econ"))
            { 
                if (model.PqrsStrategicLineSectorName == "Agricultura y desarrollo rural")
                {
                    url = "21";
                }
                else if (model.PqrsStrategicLineSectorName == "Ciencia, tecnología e innovación")
                {
                    url = "22";
                }
                else if (model.PqrsStrategicLineSectorName == "Trabajo")
                {
                    url = "23";
                }
                else if (model.PqrsStrategicLineSectorName == "Comercio, industria y turismo")
                {
                    url = "24";
                }
                else if (model.PqrsStrategicLineSectorName == "CrecimientoEconomicoNormatividad")
                {
                    url = "25";
                }
            }
            else if (model.PqrsStrategicLine.PqrsStrategicLineName.Contains("Arauca verde, ordenada"))
            {
                if (model.PqrsStrategicLineSectorName == "Ambiente desarrollo sostenible")
                {
                    url = "31";
                }
                else if (model.PqrsStrategicLineSectorName == "Gobierno territorial - Atención a desastres")
                {
                    url = "32";
                }
            }
            else if (model.PqrsStrategicLine.PqrsStrategicLineName.Contains("Infraestructura social y productiva"))
            {
                if (model.PqrsStrategicLineSectorName == "Transporte")
                {
                    url = "41";
                }
                else if (model.PqrsStrategicLineSectorName == "Minas y energía")
                {
                    url = "42";
                }
                else if (model.PqrsStrategicLineSectorName == "Vivienda")
                {
                    url = "43";
                }
            }
            else if (model.PqrsStrategicLine.PqrsStrategicLineName.Contains("Buen gobierno"))
            {
                if (model.PqrsStrategicLineSectorName == "Gobierno territorial")
                {
                    url = "51";
                }
                else if (model.PqrsStrategicLineSectorName == "Información estadisiticas")
                {
                    url = "52";
                }
                else if (model.PqrsStrategicLineSectorName == "Tecnologioas de la información y las comunicaciones")
                {
                    url = "53";
                }
                else if (model.PqrsStrategicLineSectorName == "Vivienda")
                {
                    url = "54";
                }
            }
            else if (model.PqrsStrategicLine.PqrsStrategicLineName.Contains("Seguridad convivencia y justicia"))
            {
                if (model.PqrsStrategicLineSectorName == "Gobierno territorial")
                {
                    url = "61";
                }
                else if (model.PqrsStrategicLineSectorName == "Inclusion social")
                {
                    url = "62";
                }
                else if (model.PqrsStrategicLineSectorName == "Justicia y derecho")
                {
                    url = "63";
                }
                else if (model.PqrsStrategicLineSectorName == "Vivienda")
                {
                    url = "64";
                }
            }
            else if (model.PqrsStrategicLine.PqrsStrategicLineName.Contains("Gestión del conocimiento"))
            {
                if (model.PqrsStrategicLineSectorName == "GestionConocimiento")
                {
                    url = "71";
                }
                else if (model.PqrsStrategicLineSectorName == "GestionConocimientoNormatividad")
                {
                    url = "72";
                }
            }


            return url;
        }

        public async Task<JsonResult> getSubscriber(string email)
        {
            bool exist=await _subscriber.ByEmailAsync(email);

            return Json(exist);
        }
        
    }

    public class DatosSector
    {
        public string email { get; set; }
        public virtual List<int> TempChecks { get; set; }
    }
}
