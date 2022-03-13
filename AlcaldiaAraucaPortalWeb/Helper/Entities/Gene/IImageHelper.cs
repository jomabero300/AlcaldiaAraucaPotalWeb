using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile ProFile, string Folder);
        Task<string> UploadImageMenulAsync(IFormFile ProFile, string Folder);
        Task<string> UploadFileAsync(IFormFile ProFile, string Folder);
        Task<string> DeleteImageAsync(string File,string Folder);
        string DeleteImageAsync(string File);
    }
}
