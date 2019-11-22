using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TapahtumaLib.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace TapahtumaMVC.Controllers
{
    public class TiliController : Controller
    {
        
        // GET: Tapahtuma/Create
        public ActionResult Luo()
        {
            return View();
        }

        // POST: Tapahtuma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Luo(Kayttajat käyttäjä)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(JsonConvert.SerializeObject(käyttäjä), UTF8Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = client.PostAsync("https://localhost:44394/api/tili/", content).Result;
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }

        public IActionResult Validate(Kayttajat admin)
        {
            using (EventDBContext db = new EventDBContext())
            {
                var _admin = db.Kayttajat.Where(s => s.Email == admin.Email);
                if (_admin.Any())
                {
                    if (_admin.Where(s => s.Password == admin.Password).Any())
                    {

                        return Json(new { status = true, message = "Login Successful!" });
                    }
                    else
                    {
                        return Json(new { status = false, message = "Invalid Password!" });
                    }
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Email!" });
                }
            }

        }
    }
}