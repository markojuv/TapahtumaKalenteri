using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TapahtumaLib.Models;

namespace TapahtumaMVC.Controllers
{
    public class TiliController : Controller
    {
        public IActionResult Login()
        {
            using (EventDBContext db = new EventDBContext())
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