using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class EventDBInitializer : DropCreateDatabaseIfModelChanges<EventDBContext>
    {
        protected override void Seed(EventDBContext context)
        {
            var events = new List<Event> {
                new Event{EventId=1,EventName="Meeting",Description="All Group meeting",EventDate=DateTime.Now,Duration=10},
                new Event{EventId=2,EventName="Class",Description=".net",EventDate=DateTime.Now,Duration=12},
                new Event{EventId=3,EventName="Games",Description="Cricket,Football",EventDate=DateTime.Now,Duration=5},
                new Event{EventId=4,EventName="Birthday",Description="Nilesh Birthday",EventDate=DateTime.Now,Duration=2}

            };

            events.ForEach(g => context.Events.Add(g));
            context.SaveChanges();

        }
    }
}