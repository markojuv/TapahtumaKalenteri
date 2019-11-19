using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TapahtumaLib;
using TapahtumaLib.Models;

namespace TapahtumaMVC.Controllers
{
    public class TapahtumaController : Controller
    {
        // GET: Tapahtuma
        public ActionResult Index()
        {
            string json;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"https://localhost:44394/api/tapahtuma").Result;
                json = response.Content.ReadAsStringAsync().Result;
            }
            List<Tapahtumat> tapahtumat = JsonConvert.DeserializeObject<List<Tapahtumat>>(json);
            return View(tapahtumat);
        }

        // GET: Tapahtuma/Details/5
        public ActionResult Details(int id)
        {
            string json;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"https://localhost:44394/api/tapahtuma/{id}").Result;
                json = response.Content.ReadAsStringAsync().Result;
            }
            Tapahtumat t = JsonConvert.DeserializeObject<Tapahtumat>(json);
            return View(t);
        }

        // GET: Tapahtuma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tapahtuma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tapahtuma/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tapahtuma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tapahtuma/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tapahtuma/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}