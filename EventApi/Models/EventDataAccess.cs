using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class EventDataAccess
    {
        List<Event> eventList = new List<Event>();
        Event eve = new Event();


        public List<Event> GetAllEvents()
        {
            using (var ctx = new EventDBContext())
            {
                eventList = ctx.Events.ToList();
            }

            return eventList;
        }

        public Event GetAllEventsById(int eid)
        {
            Event eventslist = new Event();
            using (var ctx = new EventDBContext())
            {
                eventslist = ctx.Events.Where(s => s.EventId == eid).Single();
            }
            return eventslist;
        }

        public int UpdateEvent(Event s1)
        {
            int retValue = 0;
            try
            {
                using (var ctx = new EventDBContext())
                {
                    Event ev = ctx.Events.Where(s => s.EventId == s1.EventId).Single();
                    if (ev != null)
                    {
                        ev.EventName = s1.EventName;
                        ev.Description = s1.Description;
                        ev.Duration = s1.Duration;
                        ev.EventDate = s1.EventDate;
                        ev.UpdatedOn = DateTime.Now;
                        //ev.EventTime = s1.EventTime;
                        ctx.Entry(ev).State = System.Data.Entity.EntityState.Modified;

                        retValue = ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retValue;
        }

        public int AddEvent(Event ev)
        {
            int recordsAdded = 0;
            if (ev != null)
            {
                try
                {
                    using (var ctx = new EventDBContext())
                    {
                        ctx.Events.Add(ev);
                        ev.CreatedOn = DateTime.Now;
                        ev.UpdatedOn = DateTime.Now;
                        recordsAdded = ctx.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return recordsAdded;
        }

        public int DeleteAllEvent(int id)
        {
            int recordsAddd = 0;
            using (var ctx = new EventDBContext())
            {
                Event j = ctx.Events.Find(id);

                //if (j != null)
                //{
                ctx.Entry(j).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                //}
            }
            return recordsAddd;
        }

    }
}