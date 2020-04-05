using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Seminarski_fitness_centar_IB130116.DB;
using Seminarski_fitness_centar_IB130116.Helper;
using Seminarski_fitness_centar_IB130116.Models;


namespace Seminarski_fitness_centar_IB130116.Controllers
{
    [Autorizacija(guest: false, zaposlenik: true, admin: true, master: true)]
    public class IndexController : Controller

    {

        MyContext db = new MyContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogAsAdmin()
        {
            User admin = db.Users.Where(u => u.UserId == 1).Single();
            HttpContext.SetLoggedUser(admin);

            return View("Index");
        }

        public IActionResult LogAsZaposlenik()
        {
            User zaposlenik = db.Users.Where(u => u.UserId == 4).Single();
            HttpContext.SetLoggedUser(zaposlenik);
            return View("Index");
        }

        public IActionResult TwoFactorChange(int Value)
        {
            //0 - nema konfirmed mail, ne moze se upaliti
            //1 - iskljucena
            //2 - ukljucena
            if (HttpContext.GetLoggedUser().EmailConfirm == 1)
            {
                User korisnik = HttpContext.GetLoggedUser();
                int returnvalue = 0;
                if (Value == 0)
                {
                    korisnik.TwoFactorAuthentication = 0;
                    returnvalue = 1;
                }
                else
                {
                    korisnik.TwoFactorAuthentication = 1;
                    returnvalue = 2;
                }
                db.Update(korisnik);
                db.SaveChanges();
                HttpContext.SetLoggedUser(korisnik);
                return Json(returnvalue);
            } else
            {
                return Json(0);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
