using AlcaldiaAraucaPortalWeb.Models;
using System.IO;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Admi
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body, MemoryStream attachment = null);

        //string EnviarEmail(string emailTo, MemoryStream attachment = null);

    }
}
