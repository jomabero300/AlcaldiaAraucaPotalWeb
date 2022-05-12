﻿using AlcaldiaAraucaPortalWeb.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class FolderStrategicLineasHelper : IFolderStrategicLineasHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsUserStrategicLineHelper _userStrategicLineHelper;
        private readonly IPqrsStrategicLineSectorHelper _strategicLineSectorHelper;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public FolderStrategicLineasHelper(ApplicationDbContext context,
            IPqrsUserStrategicLineHelper userStrategicLineHelper,
            IPqrsStrategicLineSectorHelper strategicLineSectorHelper,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _context=context;
            _userStrategicLineHelper=userStrategicLineHelper;
            _strategicLineSectorHelper=strategicLineSectorHelper;
            _env=env;
            _configuration=configuration;
        }

        public string FileMove(string sourceFileName, string destFileName)
        {
            var Folder = destFileName.Replace("\\", "/");

            var pathFolder = _configuration["MyFolders:Content"];

            var url = _configuration["MyDomain:Url"];

            int star = sourceFileName.LastIndexOf("/") + 1;

            var file = sourceFileName.Substring(star, sourceFileName.Length - star);

            sourceFileName = Path.Combine(_env.WebRootPath, pathFolder, file);

            destFileName = destFileName.Replace('/', '\\');

            destFileName = Path.Combine(_env.WebRootPath, destFileName, file);

            System.IO.File.Move(sourceFileName, destFileName);

            return $"{url}{Folder}/{file}";
        }

        public async Task<string> FolderPath(int pqrsStrategicLineSectorId, string userName)
        {

            string lineName = await lpineName(userName);

            var nomSector = await _strategicLineSectorHelper.ByIdAsync(pqrsStrategicLineSectorId);

            string folderPath = FolderPath(lineName,nomSector.PqrsStrategicLineSectorName);

            return folderPath;
        }

        public string FolderPath(string lineName, string SectorName)
        {
            string folderPath = "Image\\Menu\\";

            if (lineName == "Arauca verde, ordenada y sostenible")
            {
                folderPath = folderPath + "Arauca\\";
                if (SectorName == "Ambiente desarrollo sostenible")
                {
                    folderPath = folderPath + "Ambiente";
                }
                else if (SectorName == "Gobierno territorial - Atención a desastres")
                {
                    folderPath = folderPath + "Gobierno";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }

            }
            else if (lineName == "Buen gobierno")
            {
                folderPath = folderPath + "BuenGobierno\\";
                if (SectorName == "Gobierno territorial")
                {
                    folderPath = folderPath + "Gobierno";
                }
                else if (SectorName == "Información estadisiticas")
                {
                    folderPath = folderPath + "Informacion";
                }
                else if (SectorName == "Tecnologioas de la información y las comunicaciones")
                {
                    folderPath = folderPath + "Tecnologia";
                }
                else if (SectorName == "Vivienda")
                {
                    folderPath = folderPath + "Vivienda";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Crecimiento económico")
            {
                folderPath = folderPath + "Crecimiento\\";
                if (SectorName == "Agricultura y desarrollo rural")
                {
                    folderPath = folderPath + "Agricultura";
                }
                else if (SectorName == "Ciencia, tecnología e innovación")
                {
                    folderPath = folderPath + "Ciencia";
                }
                else if (SectorName == "Comercio, industria y turismo")
                {
                    folderPath = folderPath + "Comercio";
                }
                else if (SectorName == "Trabajo")
                {
                    folderPath = folderPath + "Trabajo";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Desarrollo social incluyente")
            {
                folderPath = folderPath + "Desarrollo\\";

                if (SectorName == "Cultura")
                {
                    folderPath = folderPath + "Cultura";
                }
                else if (SectorName == "Deporte")
                {
                    folderPath = folderPath + "Deporte";
                }
                else if (SectorName == "Educación")
                {
                    folderPath = folderPath + "Educacion";
                }
                else if (SectorName == "Inclusión social")
                {
                    folderPath = folderPath + "Inclusion";
                }
                else if (SectorName == "Salud y protección")
                {
                    folderPath = folderPath + "Salud";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Gestión del conocimiento")
            {
                folderPath = folderPath + "Gestion";
            }
            else if (lineName == "Infraestructura social y productiva")
            {
                folderPath = folderPath + "Infraestructura\\";

                if (SectorName == "Minas y energía")
                {
                    folderPath = folderPath + "Mina";
                }
                else if (SectorName == "Transporte")
                {
                    folderPath = folderPath + "Transporte";
                }
                else if (SectorName == "Vivienda")
                {
                    folderPath = folderPath + "Vivienda";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Seguridad convivencia y justicia")
            {
                folderPath = folderPath + "Seguridad\\";

                if (SectorName == "Gobierno territorial")
                {
                    folderPath = folderPath + "Gobierno";
                }
                else if (SectorName == "Inclusion social")
                {
                    folderPath = folderPath + "Inclusion";
                }
                else if (SectorName == "Justicia y derecho")
                {
                    folderPath = folderPath + "Justicia";
                }
                else if (SectorName == "Vivienda")
                {
                    folderPath = folderPath + "Vivienda";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }

            return folderPath;
        }

        public async Task<string> FolderPath(int LineaId, int SectorId)
        {
            var strategiaLinea = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(LineaId);

            var nomSector = await _strategicLineSectorHelper.ByIdAsync(SectorId);

            string folderPath = FolderPath(strategiaLinea.PqrsStrategicLineName, nomSector.PqrsStrategicLineSectorName);

            return folderPath;

        }

        public async Task<string> lpineName(string userName)
        {
            var userId = await _context.ApplicationUsers.Where(c => c.Email == userName).FirstOrDefaultAsync();

            var strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(userId.Id);

            return strategiaLineaId.PqrsStrategicLineName;
        }

    }
}
