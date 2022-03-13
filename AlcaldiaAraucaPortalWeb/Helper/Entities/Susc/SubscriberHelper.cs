using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Susc
{
    public class SubscriberHelper: ISubscriberHelper
    {
        private readonly ApplicationDbContext _context;

        public SubscriberHelper(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<bool> ByEmailAsync(string email)
        {
            Subscriber model = await _context.Subscribers.Where(x => x.email==email).FirstOrDefaultAsync();
            if(model!=null)
            {
                return false;
            }
            return true;
        }

        public async Task<Subscriber> ByIdAsync(int id)
        {
            return await _context.Subscribers.Where(x => x.SubscriberId==id).FirstOrDefaultAsync();
        }

        public async Task<Response> ConfirmEmailAsync(Subscriber subscriber, string token)
        {
            subscriber.EmailConfirmed=true;

            _context.Subscribers.Update(subscriber);

            await _context.SaveChangesAsync();

            return new Response() {Succeeded=true };
        }
    }
}
