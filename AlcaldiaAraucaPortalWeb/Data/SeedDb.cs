using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Data
{
    public class SeedDb
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                //                context.Database.EnsureCreated();

                if (!context.Genders.Any())
                {
                    context.Genders.AddRange(
                        new Gender() { GenderName = "Hombre" },
                        new Gender() { GenderName = "Mujer" },
                        new Gender() { GenderName = "Otro" });
                    context.SaveChanges();
                }
                if (!context.DocumentTypes.Any())
                {
                    context.DocumentTypes.AddRange(
                        new DocumentType() { DocumentTypeName = "Cédula de ciudadanía" },
                        new DocumentType() { DocumentTypeName = "Cédula de extranjería" }
                    );

                    context.SaveChanges();
                }
            }

        }

        public static async Task Seed(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //Datos iniciales

            if (!context.Genders.Any())
            {
                context.Genders.AddRange(
                    new Gender() { GenderName = "Hombre" },
                    new Gender() { GenderName = "Mujer" },
                    new Gender() { GenderName = "Otro" });

                context.SaveChanges();
            }

            if (!context.DocumentTypes.Any())
            {
                context.DocumentTypes.AddRange(
                    new DocumentType() { DocumentTypeName = "Cédula de ciudadanía" },
                    new DocumentType() { DocumentTypeName = "Cédula de extranjería" });

                context.SaveChanges();
            }

            if (!context.States.Any())
            {
                context.States.AddRange(
                    new State() { StateName = "Activo", StateB = true, StateType = "G" },
                    new State() { StateName = "Inactivo", StateB = true, StateType = "G" },
                    new State() { StateName = "Suspendido", StateB = true, StateType = "G" },
                    new State() { StateName = "Eliminado", StateB = true, StateType = "G" },
                    new State() { StateName = "Previo", StateB = true, StateType = "G" },
                    new State() { StateName = "Abierto", StateB = true, StateType = "P" },
                    new State() { StateName = "En Trámite", StateB = true, StateType = "P" },
                    new State() { StateName = "Cerrado", StateB = true, StateType = "P" });

                context.SaveChanges();
            }

            if (!context.PqrsCategories.Any())
            {
                context.PqrsCategories.AddRange(
                    new PqrsCategory() { PqrsCategoryName = "Peticiones", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "Quejas", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "Reclamos", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "Sgerencias", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "Felicitaciones", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "Propuestas", StateId = 1 });

                context.SaveChanges();
            }

            if (!context.PqrsStrategicLines.Any())
            {
                context.PqrsStrategicLines.AddRange(
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Gestión del conocimiento" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Seguridad convivencia y justicia" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Buen gobierno" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Infraestructura social y productiva" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Arauca verde, ordenada y sostenible" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Crecimiento económico" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Desarrollo social incluyente" });

                context.SaveChanges();
            }

            if (!context.PqrsStrategicLineSectors.Any())
            {
                var strategicLineId = context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineName.Equals("Gestión del conocimiento")).FirstOrDefault().PqrsStrategicLineId;
                context.PqrsStrategicLineSectors.AddRange(new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId, PqrsStrategicLineSectorName = "Gestión del conocimiento" });

                context.SaveChanges();


                var strategicLineId1 = context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineName.Equals("Desarrollo social incluyente")).FirstOrDefault().PqrsStrategicLineId;
                context.PqrsStrategicLineSectors.AddRange(
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId1, PqrsStrategicLineSectorName = "Cultura" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId1, PqrsStrategicLineSectorName = "Deporte" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId1, PqrsStrategicLineSectorName = "Educación" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId1, PqrsStrategicLineSectorName = "Inclusión social" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId1, PqrsStrategicLineSectorName = "Salud y protección" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId1, PqrsStrategicLineSectorName = "Normatividad" });

                context.SaveChanges();

                var strategicLineId2 = context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineName.Equals("Crecimiento económico")).FirstOrDefault().PqrsStrategicLineId;
                context.PqrsStrategicLineSectors.AddRange(
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId2, PqrsStrategicLineSectorName = "Agricultura y desarrollo rural" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId2, PqrsStrategicLineSectorName = "Ciencia, tecnología e innovación" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId2, PqrsStrategicLineSectorName = "Trabajo" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId2, PqrsStrategicLineSectorName = "Comercio, industria y turismo" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId2, PqrsStrategicLineSectorName = "Normatividad" });

                context.SaveChanges();
                
                var strategicLineId3 = context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineName.Equals("Arauca verde, ordenada y sostenible")).FirstOrDefault().PqrsStrategicLineId;
                context.PqrsStrategicLineSectors.AddRange(
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId3, PqrsStrategicLineSectorName = "Ambiente desarrollo sostenible" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId3, PqrsStrategicLineSectorName = "Gobierno territorial - Atención a desastres" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId3, PqrsStrategicLineSectorName = "Normatividad" });

                context.SaveChanges();

                var strategicLineId4 = context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineName.Equals("Infraestructura social y productiva")).FirstOrDefault().PqrsStrategicLineId;

                context.PqrsStrategicLineSectors.AddRange(
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId4, PqrsStrategicLineSectorName = "Transporte" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId4, PqrsStrategicLineSectorName = "Minas y energía" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId4, PqrsStrategicLineSectorName = "Vivienda" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId4, PqrsStrategicLineSectorName = "Normatividad" });

                context.SaveChanges();

                var strategicLineId5 = context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineName.Equals("Buen gobierno")).FirstOrDefault().PqrsStrategicLineId;
                context.PqrsStrategicLineSectors.AddRange(
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId5, PqrsStrategicLineSectorName = "Información estadisiticas" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId5, PqrsStrategicLineSectorName = "Gobierno territorial" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId5, PqrsStrategicLineSectorName = "Tecnologioas de la información y las comunicaciones" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId5, PqrsStrategicLineSectorName = "Vivienda" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId5, PqrsStrategicLineSectorName = "Normatividad" });

                context.SaveChanges();

                var strategicLineId6 = context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineName.Equals("Seguridad convivencia y justicia")).FirstOrDefault().PqrsStrategicLineId;
                context.PqrsStrategicLineSectors.AddRange(
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId6, PqrsStrategicLineSectorName = "Justicia y derecho" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId6, PqrsStrategicLineSectorName = "Inclusion social" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId6, PqrsStrategicLineSectorName = "Gobierno territorial" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId6, PqrsStrategicLineSectorName = "Vivienda" },
                    new PqrsStrategicLineSector() { PqrsStrategicLineId = strategicLineId6, PqrsStrategicLineSectorName = "Normatividad" });

                context.SaveChanges();
            }

            if(!context.Departments.Any())
            {
                context.Departments.Add(new Department { DepartmentName = "Arauca" });
                context.SaveChanges();
            }

            if(!context.Municipalities.Any())
            {
                context.Municipalities.Add(new Municipality { DepartmentId = 1, MunicipalityName = "Arauca" });
                context.SaveChanges();
            }

            if (!context.Zones.Any())
            {
                context.Zones.Add(new Zone { ZoneName = "Urbano" });
                context.Zones.Add(new Zone { ZoneName = "Rural" });
                context.SaveChanges();
            }

            if (!context.CommuneTownships.Any())
            {
                var mpio = await context.Municipalities.Where(m => m.MunicipalityName.Equals("Arauca")).FirstOrDefaultAsync();
                if(mpio != null)
                {
                    var zone = await context.Zones.Where(z => z.ZoneName.Equals("Urbano")).FirstOrDefaultAsync();
                    if(zone !=null )
                    {

                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId=mpio.MunicipalityId,ZoneId=zone.ZoneId ,CommuneTownshipName  = "Comuna 1 raimundo cisneros olivera" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId=mpio.MunicipalityId,ZoneId=zone.ZoneId ,CommuneTownshipName  = "Comuna 2 josefa canelones" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId=mpio.MunicipalityId,ZoneId=zone.ZoneId ,CommuneTownshipName  = "Comuna 3 antonio benites" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId=mpio.MunicipalityId,ZoneId=zone.ZoneId ,CommuneTownshipName  = "Comuna 4 jose laurencio" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId=mpio.MunicipalityId,ZoneId=zone.ZoneId ,CommuneTownshipName  = "Comuna 5 juan jose rondon" });
                        context.SaveChanges();
                    }

                    var zone2 = await context.Zones.Where(z => z.ZoneName.Equals("Rural")).FirstOrDefaultAsync();

                    if (zone2 != null)
                    {
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento El Caracol" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento Maporillal" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento De Santa Barbara" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento Todos Los Santos" });
                        context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento Cañas Bravas" });
                        context.SaveChanges();                                                                                
                    }
                }
            }
            
            if (!context.NeighborhoodSidewalks.Any())
            {
                var comuna1 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 1 raimundo cisneros olivera")).FirstOrDefaultAsync();
                if (comuna1 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "20 de julio" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Cabañas del rio" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Libertadores" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Miramar" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Miramar frontera" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Primero de mayo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Siete de agosto" });
                    context.SaveChanges();
                }
                var comuna2 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 2 josefa canelones")).FirstOrDefaultAsync();
                if (comuna1 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Cordoba" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "San luis" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Santa fe" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Santafesito" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Union" });
                    context.SaveChanges();
                }
                var comuna3 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 3 antonio benites")).FirstOrDefaultAsync();
                if (comuna3 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="12 De Octubre"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Corocoras"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Cor Sec San Antonio"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Chorreras"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="El Centauro"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Guarataros"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="La Esperanza"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="La Victoria"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Paraiso"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Pedro Nel Jimenez"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Porvenir"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Primero De Enero"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Santa Teresita"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="El Triunfo"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. El Bosque"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. Flor Amarillo"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. Villa Maria"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. Villa San Juan"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Villa Celeste"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Sector El Palmar"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. Palma Real"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Bulevar De La Seiba"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. Villa Luz"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. Las Palmeras"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Urb. El Arauco"});
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName ="Altos De La Sabana" });
                    context.SaveChanges();
                }
                var comuna4 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 4 jose laurencio")).FirstOrDefaultAsync();
                if (comuna4 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Americas" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Bosque Club" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Chircal" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Cristo Rey" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Meridiano 70" });
                    context.SaveChanges();
                }

                var comuna5 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 5 Juan Jose Rondon")).FirstOrDefaultAsync();

                if (comuna5 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Buena Vista" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Brisas Del Llano" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Costa Hermosa" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Divino Niño" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Flor De Mi Llano" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Fundadores Bajo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Fundadores Alto" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "La Granja" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Mata De Venado" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Olimpico" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "San Carlos" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. El Moriche" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Santa Barbara" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Villa De Prado" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Villa Del Maestro" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. El Horcon" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Bello Horizonte" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Bello Horizonte Alto" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Manhatan" });

                    context.SaveChanges();
                }

                var corregimiento1 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento El Caracol")).FirstOrDefaultAsync();

                if (corregimiento1 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Punto Fijo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Barranca Amarilla" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Villa Nueva Caracol" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Vapor" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Bogota" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "La Panchera" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Feliciano" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Miedo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Cabuyare" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "La Maporita" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Merecure" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "La Bendicion" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Matal De Flor Amarillo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "San Pablo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Maporillal" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "San Ramon" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Las Monas" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Cinaruco" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Socorro" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Las Plumas" });

                    context.SaveChanges();
                }

                var corregimiento2 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento Maporillal")).FirstOrDefaultAsync();

                if (corregimiento2 != null)
                {

                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Merecure" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "La Bendicion" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "El Matal De Flor Amarillo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "San Pablo" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Maporillal" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "San Ramon" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Las Monas" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "El Cinaruco" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "El Socorro" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Las Plumas" });

                    context.SaveChanges();
                }

                var corregimiento3 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento De Santa Barbara")).FirstOrDefaultAsync();

                if (corregimiento3 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Barrancones" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Chaparrito" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "El Rosario" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Mata De Gallina" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "La Saya" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "El Torno" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "La Payara" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Bocas Del Arauca" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Clarinetero" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Monserrate" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Los Arrecifes" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Mata De Piña" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Los Caballos" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Penjamo" });

                    context.SaveChanges();
                }

                var corregimiento4 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento Todos Los Santos")).FirstOrDefaultAsync();

                if (corregimiento4 != null)
                {
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Corocito" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Todos Los Santos" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "La Yuca" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Altamira" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Las Nubes A" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Las Nubes B" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "El Siani" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "El Final" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "La Becerra" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "El Sol" });

                    context.SaveChanges();
                }

                var corregimiento5 = await context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento Cañas Bravas")).FirstOrDefaultAsync();

                if (corregimiento5 != null)
                {

                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "San Jose Del Lipa" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "La Pastora" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Selvas Del Lipa" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Salas" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Salto Del Lipa" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Brisas Del Salto" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Alto Primores" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Vigia" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Cañas Bravas" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Milagro" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Azul" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Colorado" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Seco" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Perocero" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "La Comunidad" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Manatiales" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Maporal" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Perocero B" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "La Conquista" });
                    context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Los Andes" });

                    context.SaveChanges();
                }

            }

            //Crear roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrador", "Publicador","Usuario","Prensa" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Create user
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var documentTypeId = context.DocumentTypes.Where(d => d.DocumentTypeName.Equals("Cédula de ciudadanía")).FirstOrDefault().DocumentTypeId;
            var genderId = context.Genders.Where(d => d.GenderName.Equals("Hombre")).FirstOrDefault().GenderId;
            var neighborhoodSidewalkId = context.NeighborhoodSidewalks.Where(n => n.NeighborhoodSidewalkName.Equals("La esperanza")).FirstOrDefault().NeighborhoodSidewalkId;

            if (userManager.FindByEmailAsync("jomabero300@gmail.com").Result==null)
            {
                
                var user = new ApplicationUser
                {
                    UserName= "jomabero300@gmail.com",
                    Email = "jomabero300@gmail.com",
                    NormalizedEmail = "JOMABERO300@GMAIL.COM",
                    NormalizedUserName = "JOMABERO300@GMAIL.COM",
                    EmailConfirmed=true,
                    LockoutEnabled=true,
                    Document = "123456789",
                    DocumentTypeId = documentTypeId,
                    FirstName = "José Manuel",
                    LastName = "Bello Romero",
                    BirdDarte = DateTime.Parse("25/10/1972"),
                    GenderId = genderId,
                    PhoneNumber = "1234567890",
                    NeighborhoodSidewalkId= neighborhoodSidewalkId,
                    Address="Calle luna calle sol"
                };

                try
                {
                    IdentityResult result = userManager.CreateAsync(user, "Mbel123.").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Administrador").Wait();
                    }

                }
                catch {}            
            }
            var emailAdmi = "admin@gmail.com";
            if (userManager.FindByEmailAsync(emailAdmi).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = emailAdmi,
                    Email = emailAdmi,
                    NormalizedEmail = emailAdmi,
                    NormalizedUserName = emailAdmi,
                    EmailConfirmed = true,
                    LockoutEnabled = true,

                    Document = "123456789",
                    DocumentTypeId = documentTypeId,
                    FirstName = "Super",
                    LastName = "Administrador",
                    BirdDarte = DateTime.Parse("25/10/1972"),
                    GenderId = genderId,
                    PhoneNumber = "1234567890",
                    NeighborhoodSidewalkId = neighborhoodSidewalkId,
                    Address = "Calle luna calle sol"

                };

                IdentityResult result = userManager.CreateAsync(user, "Admin123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrador").Wait();

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

                    userManager.ConfirmEmailAsync(user, code).Wait();
                }
            }

            var email7 = "userlinea7@gmail.com";
            if (userManager.FindByEmailAsync(email7).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = email7,
                    Email = email7,
                    Document = "7",
                    DocumentTypeId = documentTypeId,
                    FirstName = "User",
                    LastName = "Linea7",
                    BirdDarte = DateTime.Parse("25/10/1972"),
                    GenderId = genderId,
                    PhoneNumber = "1234567890",
                    NeighborhoodSidewalkId = neighborhoodSidewalkId,
                    Address = "Calle"

                };
                var result = await userManager.CreateAsync(user, "User123.");

                //IdentityResult result = userManager.CreateAsync(user, "User123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Publicador").Wait();

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    userManager.ConfirmEmailAsync(user, code).Wait();
                }
            }

        }
    }
}
