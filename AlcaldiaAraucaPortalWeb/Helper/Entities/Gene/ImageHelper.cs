using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public ImageHelper(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        public async Task<string> DeleteImageAsync(string File, string folder)
        {
            int start = File.LastIndexOf("/") + 1;

            var file2 = File.Substring(start, File.Length - start);

            file2 = Path.Combine(_env.WebRootPath, folder, file2);

            if (System.IO.File.Exists(file2))
            {
                FileInfo fi = new FileInfo(file2);

                if (fi != null)
                {
                    System.IO.File.Delete(file2);
                    fi.Delete();
                }
            }

            return await Task.FromResult("Ok");
        }

        public string DeleteImageAsync(string File)
        {
            string file2 = Path.Combine(_env.WebRootPath, "Image" ,File);

            if (System.IO.File.Exists(file2))
            {
                FileInfo fi = new FileInfo(file2);

                if (fi != null)
                {
                    System.IO.File.Delete(file2);
                    fi.Delete();
                }
            }

            return "Ok";
        }

        public async Task<string> UploadFileAsync(IFormFile ProFile, string Folder)
        {
            var filePath = String.Empty;
            var FileName = string.Empty;
            var url = _configuration["MyDomain:Url"];
            if (ProFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, Folder);
                Folder = Folder.Replace('\\', '/');

                FileName = Guid.NewGuid().ToString() + ".pdf";

                filePath = Path.Combine(uploadsFolder, FileName);

                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProFile.CopyToAsync(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    filePath = ex.Message;
                }
            }

            return $"{url}{Folder}/{FileName}";
        }

        public async Task<string> UploadImageAsync(IFormFile ProFile, string Folder)
        {
            string fileName = await UploadImage(ProFile, Folder);

            return fileName;
            //string filePath = String.Empty;
            //string FileName = string.Empty;
            //string url = _configuration["MyDomain:Url"];

            //string[] exten = { ".png", ".jpg", ".jpeg", ".gif",".bpm" };

            //if (ProFile != null)
            //{
            //    string uploadsFolder = Path.Combine(_env.WebRootPath, Folder);
            //    Folder = Folder.Replace('\\','/');

            //    string FileExt = Path.GetExtension(ProFile.FileName);
            //    int respue = Array.IndexOf(exten, FileExt);

            //    if (respue>-1)
            //    {
            //        FileExt = ".png";
            //    }
            //    else
            //    {
            //        FileExt = ".pdf";
            //    }

            //    FileName = Guid.NewGuid().ToString()+ FileExt;

            //    filePath = Path.Combine(uploadsFolder, FileName);

            //    try
            //    {
            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await ProFile.CopyToAsync(fileStream);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        filePath = ex.Message;
            //    }            
            //}

            //return $"{url}{Folder}/{FileName}"; 
        }

        public async Task<string> UploadImageMenulAsync(IFormFile ProFile, string Folder)
        {
            string fileName = "Imagen01";
            List <CarouselModelView> file = FilesHelper.ImageDirectory(Folder, _env.WebRootPath, "Imagen0*");
            if(file.Count()>0)
            {
                fileName = file.Last().ImageName;
                int start = fileName.LastIndexOf(".")-2;
                var file2 = fileName.Substring(start, 2);
                start = int.Parse(file2)+1;
                file2 = start.ToString("00");
                fileName = $"Imagen{file2}.png";
            }

            string FileName = await UploadImage(ProFile, Folder, fileName);

            return FileName;
        }

        private async Task<string> UploadImage(IFormFile ProFile, string Folder, string fileName="")
        {
            string FileName = string.Empty;
            string url = _configuration["MyDomain:Url"];

            string[] exten = { ".png", ".jpg", ".jpeg", ".gif", ".bpm" };

            if (ProFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, Folder);
                Folder = Folder.Replace('\\', '/');

                string FileExt = Path.GetExtension(ProFile.FileName);
                int respue = Array.IndexOf(exten, FileExt);

                if (respue > -1)
                {
                    FileExt = ".png";
                }
                else
                {
                    FileExt = ".pdf";
                }

                FileName = fileName.Trim()==""? (Guid.NewGuid().ToString() + FileExt): fileName.Trim();

                string filePath = Path.Combine(uploadsFolder, FileName);

                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProFile.CopyToAsync(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    filePath = ex.Message;
                }
            }

            return $"{url}{Folder}/{FileName}";
        }
    }
}
