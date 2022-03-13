using System;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs
{
    public class PqrsDetailsViewModel
    {
        public string PqrsStrategicLineName { get; set; }
        public string PqrsCategoryName { get; set; }
        public string PqrsSubject { get; set; }
        public string StateName { get; set; }
        public DateTime PqrsTraceabilityDate { get; set; }
        public string Answer { get; set; }
    }
}
