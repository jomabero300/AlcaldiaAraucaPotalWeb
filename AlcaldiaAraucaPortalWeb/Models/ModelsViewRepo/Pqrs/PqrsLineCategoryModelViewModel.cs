using System;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs
{
    public class PqrsLineCategoryModelViewModel
    {
        public DateTime PqrsDateStart { get; set; }
        public DateTime PqrsDateEnd { get; set; }
        public string PqrsStrategicLineName { get; set; }
        public string PqrsCategoryName { get; set; }
        public int Total { get; set; }
    }
}
