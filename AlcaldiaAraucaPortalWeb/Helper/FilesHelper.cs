using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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

        public static string ConvertToTextInLik(string cadena)
        {
            //            pattern = @"(http:\/\/([\w.]+\/?)\S*)";
            //string pattern = @"(https?://[^\s]+)";
            //Regex re = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //cadena = re.Replace(cadena, "<a href=\"$1\" target=\"_blank\">ver mas</a>");
            //return cadena;

            var urlregex = new Regex(@"\b\({0,1}(?<url>(www|ftp)\.[^ ,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds URLs with a protocol
            var httpurlregex = new Regex(@"\b\({0,1}(?<url>[^>](http://www\.|http://|https://|ftp://)[^,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds email addresses
            var emailregex = new Regex(@"\b(?<mail>[a-zA-Z_0-9.-]+\@[a-zA-Z_0-9.-]+\.\w+)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);


            cadena = urlregex.Replace(cadena, " <a href=\"${url}\" target=\"_blank\">ver aqui</a>");
            cadena = httpurlregex.Replace(cadena, " <a href=\"${url}\" target=\"_blank\">ver aqui</a>");
            cadena = emailregex.Replace(cadena, "<a href=\"mailto:${mail}\">ver aqui</a>");
            
            return cadena;
        }

        public static List<CarouselModelView> ImageDirectory(string foldr, string pathRoot,string search)
        {
            List<CarouselModelView> model = new List<CarouselModelView>();

            string path = Path.Combine(pathRoot, foldr);

            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var item in di.GetFiles(search))
            {
                model.Add(new CarouselModelView { ImageName = item.Name });
            }


            return model;
        }

    }
}
