using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Cont
{
    public interface IContentOdsHelper
    {
        Task<List<ContentOds>> ByIdAsync(int SectorId);
    }
}
