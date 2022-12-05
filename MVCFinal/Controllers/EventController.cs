using MVCFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVCFinal.Controllers
{


    public class EventController : Controller
    {
        // GET: Event
        [HttpGet]
        public ActionResult GetEventList()
        {
            List<Event> TD = new List<Event>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.GetAsync("event/getallevents");
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back student object
                    var readTask = response.Content.ReadAsAsync<List<Event>>();
                    readTask.Wait();
                    TD = readTask.Result;
                }
            }
            return View(TD);
        }



        [HttpGet]
        public ActionResult AddEvent()
        {
            Event ev = new Event();
            ev.EventDate= DateTime.Now;
            ev.Duration = 1;
            return View(ev);
        }



        [HttpPost]
        public ActionResult AddEvent(Event ev)
        {
            using (var client = new HttpClient())
            {
                if (ModelState.IsValid)
                {
                    client.BaseAddress = new Uri("http://localhost:8044/api/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var responseTask = client.PostAsJsonAsync(String.Format("event/AddEvent"), ev);
                    responseTask.Wait();

                    HttpResponseMessage response = responseTask.Result;
                    return RedirectToAction("GetEventList");
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditEvent(int eid)
        {
            Event TD = new Event();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.GetAsync(String.Format("event/EditEvent/?eid=")+eid);
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back event object
                    var readTask = response.Content.ReadAsAsync<Event>();
                    readTask.Wait();
                    TD = readTask.Result;
                }
            }
            return View(TD);
        }

        [HttpPost]
        public ActionResult EditEvent(Event ev)
        {
            List<Event> TD = new List<Event>();

            using (var client = new HttpClient())
            {
                if (ModelState.IsValid) 
                { 
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.PutAsJsonAsync(String.Format("event/EditEvent"), ev);
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                   
                    return RedirectToAction("GetEventList");
                }
                return View();
            }
            
        }
        
        [HttpGet]
        public ActionResult DeleteEvent(int eid)
        {
            Event TD = new Event();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.GetAsync("event/DeleteEvent/?eid="+eid);
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back Event object
                    var readTask = response.Content.ReadAsAsync<Event>();
                    readTask.Wait();
                    TD = readTask.Result;
                }
            }
            return View(TD);
        }

        [HttpPost,ActionName("DeleteEvent")]
        public ActionResult DeleteEvents(int eid)
        {
            List<Event> TD = new List<Event>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.DeleteAsync(String.Format("event/DeleteEventss/?eid="+eid));
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
               
            }
            return RedirectToAction("GetEventList");
        }
    }
}