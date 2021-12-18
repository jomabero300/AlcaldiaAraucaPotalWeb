using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AlcaldiaAraucaPortalWeb.Helper
{
    public class FilesHelper
    {
        public static string GetUploadedFileName(IFormFile ProFile, string Folder, string name, IWebHostEnvironment webHost)
        {
            string uniqueFileName = null;

            if (ProFile != null)
            {
                string uploadsFolder = Path.Combine(webHost.WebRootPath, Folder);

                //uniqueFileName=Guid.NewGuid() + "_" + ProFile.FileName;
                uniqueFileName = name;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProFile.CopyTo(fileStream);
                }
            }

            Folder = Folder.Replace('\\', '/');

            uniqueFileName = $"~/{Folder}/{uniqueFileName}";

            return uniqueFileName;
        }
    }
}
