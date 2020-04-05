using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seminarski_fitness_centar_IB130116.DB;
using Seminarski_fitness_centar_IB130116.Helper;
using Seminarski_fitness_centar_IB130116.Models;
using Seminarski_fitness_centar_IB130116.ViewModels;

namespace Seminarski_fitness_centar_IB130116.Controllers
{
    [Autorizacija(guest: false, zaposlenik: true, admin: true, master: true)]
    public class ObavjestenjaController : Controller
    {


        MyContext db = new MyContext();


        public IActionResult Index(int from = 0, int per_page = 5) 
        {
            ObavjestenjaVM model = HelpFunctions.GetObavjestenja(from, per_page);
            ViewData["from"] = from + per_page;
            ViewData["per_page"] = per_page;
            ViewData["load_more"] = false;
            ObavjestenjaVM check = HelpFunctions.GetObavjestenja(from + per_page, per_page);
            if (check.Rows.Count > 0)
            {
                ViewData["load_more"] = true;
            }
            return View(model);
        }

        public IActionResult Dodaj()
        {
            Obavjestenje model = new Obavjestenje();
            return View(model);
        }

        public IActionResult Snimi(Obavjestenje input)
        {
            if (ModelState.IsValid)
            {
                User autor = HttpContext.GetLoggedUser();
                Obavjestenje novo = new Obavjestenje
                {
                    Naslov = input.Naslov,
                    Tekst = input.Tekst,
                    UserId = autor.UserId,
                    Vrijeme = DateTime.Now
                };
                if (input.ObavjestenjeId == 0) //novo
                {
                    {
                        db.Obavjestenja.Add(novo);
                        db.SaveChanges();
                        TempData["ErrorMessage"] = "Obavjestenje dodano!";
                        return RedirectToAction("Index", "Obavjestenja");
                    }
                }
                else //update postojece
                {
                    Obavjestenje zaUpdate = db.Obavjestenja.Where(O => O.ObavjestenjeId == input.ObavjestenjeId).Single();
                    if (zaUpdate != null)
                    {
                        novo.ObavjestenjeId = input.ObavjestenjeId;
                        db.Entry(zaUpdate).CurrentValues.SetValues(novo);
                        db.SaveChanges();
                        TempData["ErrorMessage"] = "Obavjestenje uredjeno!";
                        return RedirectToAction("Index", "Obavjestenja");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Pogresni podaci";
                        int ObavjestenjeId = input.ObavjestenjeId;
                        return RedirectToAction("Uredi", "Obavjestenja", ObavjestenjeId = input.ObavjestenjeId);
                    }
                }
            }

            TempData["ErrorMessage"] = "Uneseni podaci nisu validni";
            return RedirectToAction("Dodaj");
        }

        public IActionResult Uredi(int obavjestenjeId)
        {
            Obavjestenje model = db.Obavjestenja.Where(O => O.ObavjestenjeId == obavjestenjeId).Single();
            if (model.ObavjestenjeId == 0)
            {
                model = new Obavjestenje();
            }
            return View(model);
        }

        public IActionResult Obrisi(int obavjestenjeId)
        {
            Obavjestenje zaBrisati = db.Obavjestenja.Where(O => O.ObavjestenjeId == obavjestenjeId).Single();
            if (zaBrisati.ObavjestenjeId != 0)
            {
                db.Obavjestenja.Remove(zaBrisati);
                db.SaveChanges();
                TempData["ErrorMessage"] = "Obavjestenje uspjesno obrisano! ";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Greska u brisanu obavjestenja... ";
            return RedirectToAction("Index");
        }

    }
}