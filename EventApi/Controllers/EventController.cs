using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using api.Models;

namespace api.Controllers
{
    public class EventController : ApiController
    {
        EventDataAccess eda = new EventDataAccess();
        List<Event> eventL = new List<Event>();

        //Get all events

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllEvents()
        {

                eventL = eda.GetAllEvents();
                return Ok(eventL);

        }

        //Add An Event

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddEvent(Event s1)
        {

            if (ModelState.IsValid)
            {
                int iresult;

                iresult = eda.AddEvent(s1);

                return Ok(iresult);
            }
            return Ok();
        }


        //Get method of Edit Event

        [System.Web.Http.HttpGet]
        public IHttpActionResult EditEvent(int eeid)
        {

            Event e1 = new Event();
            e1=eda.GetAllEventsById(eeid);
            return Ok(e1);
        }



        //Post Method of Edit Event

        [System.Web.Http.HttpPut]
        public IHttpActionResult EditEvent(Event s1)
        {
            if (ModelState.IsValid)
            {

                int iresult = eda.UpdateEvent(s1);
                return Ok(iresult);
            }
            return Ok();
        }


        //Get method of Delete Event 

        [System.Web.Http.HttpGet]
        public IHttpActionResult DeleteEvent(int eid)
        {

            Event e1 = new Event();
            e1=eda.GetAllEventsById(eid);
            return Ok(e1);
        }


        //Post MEthod of Delete Event

        [System.Web.Http.HttpDelete]
 
        public IHttpActionResult DeleteEventss(int eid)
        {
            int iresult = eda.DeleteAllEvent(eid);
            return Ok(iresult);
        }
    }
}