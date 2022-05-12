using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IFolderStrategicLineasHelper
    {
        Task<string> FolderPath(int pqrsStrategicLineSectorId, string userName);
        string FolderPath(string lineName, string SectorName);
        Task<string> FolderPath(int LineaId, int SectorId);
        Task<string> lpineName(string userName);
        string FileMove(string sourceFileName, string destFileName);
    }
}
