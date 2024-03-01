using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {   
        private readonly EventManagementDbContext dbContext;
        public EventRepository(EventManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Event> CreateAsync(Event events)
        {
            await dbContext.Events.AddAsync(events);
            await dbContext.SaveChangesAsync();
            return events;
        }

        public async Task<Event?> DeleteAsync(Guid id)
        {
            var existingEvent = await dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEvent == null)
            {
                return null;
            }

            dbContext.Events.Remove(existingEvent);
            await dbContext.SaveChangesAsync();
            return existingEvent;
        }
       

        public async Task<List<Event>> GetAllAsync()
        {   

            return  await dbContext.Events.ToListAsync();
        }
        
        public async Task<List<Event>> GetEventOfThisWeek()
        {
            DateTime currentDate = DateTime.Now;

            // Si on est samedi ou dimanche, ajuster la date de début à la semaine suivante
            if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                currentDate = currentDate.AddDays(7 - (int)currentDate.DayOfWeek); // ajuster à la semaine suivante
            }

            DateTime startOfWeek = currentDate.Date.AddDays((int)DayOfWeek.Monday - (int)currentDate.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            return await dbContext.Events
                .Where(e => e.DateStart >= startOfWeek && e.DateEnd <= endOfWeek)
                .ToListAsync();
        }


      
        public async Task<List<Event>> FiltrerParDate(DateTime? trierPar = null)
        {
            // Filtrage
            var evenements = dbContext.Events.AsQueryable();
            var filtreSur = "DateStart";

            if (!string.IsNullOrWhiteSpace(filtreSur))
            {
                if (filtreSur.Equals("DateStart", StringComparison.OrdinalIgnoreCase))
                {
                    if (trierPar.HasValue)
                    {
                        // Filtre pour tous les événements dans le mois donné
                        var moisDebut = trierPar.Value.Month;
                        var anneeDebut = trierPar.Value.Year;

                        var moisSuivant = moisDebut == 12 ? 1 : moisDebut + 1;
                        var anneeSuivante = moisDebut == 12 ? anneeDebut + 1 : anneeDebut;

                        var dateDebutMois = new DateTime(anneeDebut, moisDebut, 1);
                        var dateFinMoisSuivant = new DateTime(anneeSuivante, moisSuivant, 1).AddDays(-1);

                        evenements = evenements.Where(x => x.DateStart >= dateDebutMois && x.DateStart <= dateFinMoisSuivant);
                    }
                    else
                    {
                        // Gérer le cas où trierPar est null (si nécessaire)
                    }
                }
                else
                {
                    // Gérer d'autres filtres si nécessaire
                }
            }

            return await evenements.ToListAsync();
        }


        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return  await dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
           
        }
        public async Task<bool> UpdateAsync(Event events)
        {
            if (events != null)
            {
                dbContext.Set<Event>().Update(events);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IQueryable<Event> IncludeSessions()
        {
            return dbContext.Events.Include(e => e.Sessions);
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

       
    }
}
