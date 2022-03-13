using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Models;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Susc
{
    public interface ISubscriberHelper
    {
        Task<Subscriber> ByIdAsync(int id);
        Task<bool> ByEmailAsync(string email);
        Task<Response> ConfirmEmailAsync(Subscriber subscriber, string token);
    }
}
