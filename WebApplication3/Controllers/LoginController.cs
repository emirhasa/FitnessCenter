using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Seminarski_fitness_centar_IB130116.DB;
using Seminarski_fitness_centar_IB130116.Helper;
using Seminarski_fitness_centar_IB130116.Models;
using Seminarski_fitness_centar_IB130116.ViewModels;

namespace Seminarski_fitness_centar_IB130116.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index(LoginVM input)
        {
            if (HttpContext.GetLoggedUser() == null)
            {
                if (input.IsLogging == 1)
                {
                    if (ModelState.IsValid)
                    {
                        MyContext _db = new MyContext();
                        User korisnik = _db.Users.Where(x => x.Username == input.Username && x.Password == input.Password)
                            .SingleOrDefault();

                        if (korisnik != null)
                        {
                            HttpContext.Session.Set("LoggedInUser", korisnik);
                            HttpContext.Session.Set("TwoFactor", 0);
                            TempData["TekSeLogirao"] = true;
                            //provjeri two factor 
                            if (korisnik.TwoFactorAuthentication == 1)
                            {
                                //MORA verifikovati
                                SendTwoFactorCode();
                            }
                            return RedirectToAction("Index", "Index");
                        }

                        ViewData["ErrorMessage"] = "Pogrešan username ili lozinka";
                        return View("Login", input);

                    }
                    else
                    {
                        return View("Login", input);
                    }
                }
                else
                {
                    ModelState.Clear();
                    return View("Login", input);
                }
            } else
            {
                TempData["ErrorMessage"] = "Već ste logovani";
                return RedirectToAction("Index", "Index");
            }
        }

        public IActionResult TwoFactor()
        {
            if (HttpContext.GetLoggedUser() != null)
            {
                return View();
            } else
            {
                // TempData["ErrorMessage"] = "Sesija istekla";
                return View("Login");
            }
        }

        public IActionResult TwoFactorVerify(int verification_code)
        {
            //ako je korisnik cekao na promptu sesija je istekla, pa provjeri prvo
            if (HttpContext.GetLoggedUser() != null)
            {
                if (HttpContext.GetTwoFactor() == 0)
                {
                    //provjeri kod
                    MyContext _db = new MyContext();
                    TwoFactorAuthentication verifikacija = _db.Autentifikacije.OrderByDescending(k=>k.VrijemeSlanja).Take(1).Where(k => k.KonfirmacijskiKod == verification_code).SingleOrDefault();
                    if (verifikacija != null)
                    {
                        //kod je dobar, da li se odnosi na datog korisnika koji se pokusava logirati
                        if (verifikacija.UserId == HttpContext.GetLoggedUser().UserId)
                        {
                            //autentifikacija prosla
                            HttpContext.Session.Set("TwoFactor", 1);
                            TempData["ErrorMessage"] = "Uspješna autentifikacija";
                            return RedirectToAction("Index", "Index");
                        }
                    }
                    TempData["ErrorMessage"] = "Kod je istekao ili nije validan, molimo pokušajte ponovo";
                    return View("TwoFactor");
                }
                else
                {
                    TempData["ErrorMessage"] = "Već ste autorizovani";
                    return RedirectToAction("Index", "Index");
                }
            } else
            {
                TempData["ErrorMessage"] = "Logirajte se ponovo";
                return RedirectToAction("Index", "Index");
            }
        }

        public IActionResult SendTwoFactorCode()
        {
            if (HttpContext.GetLoggedUser() != null)
            {
                if (HttpContext.GetTwoFactor() == 0 && HttpContext.GetLoggedUser().TwoFactorAuthentication==1)
                {
                    User korisnik = HttpContext.GetLoggedUser();

                    //generiraj random kod
                    Random generator = new Random();
                    int verifikacijskiKod = generator.Next(100000, 1000000);

                    //zapamti u bazi
                    MyContext _db = new MyContext();
                    TwoFactorAuthentication nova = new TwoFactorAuthentication
                    {
                        KonfirmacijskiKod = verifikacijskiKod,
                        UserId = korisnik.UserId,
                        VrijemeSlanja = DateTime.Now
                    };

                    var autentifikacije = _db.Autentifikacije.Where(a => a.UserId == korisnik.UserId).ToArray();
                    _db.Autentifikacije.RemoveRange(autentifikacije);
                    _db.SaveChanges();

                    _db.Autentifikacije.Add(nova);
                    _db.SaveChanges();

                    try
                    {
                        //posalji mail
                        HelpFunctions.SendMail("Verifikacijski kod za login", "Vaš verifikacijski kod je: " + verifikacijskiKod, "FITib130116@gmail.com", korisnik.Email);
                        TempData["ErrorMessage"] = "Poslan je novi verifikacijski kod na mail";
                        return View("TwoFactor");
                    }
                    catch
                    {
                        //nema potrebe za two factor verify
                        TempData["ErrorMessage"] = "Nismo mogli poslati mail sa šifrom, vjerovatno zbog novih googleovih security postavki. Pošto je ovo testiranje, ipak ćemo vas logirati!";
                        HttpContext.Session.Set("TwoFactor", 1);
                        return RedirectToAction("Index", "Index");
                    }
                } else
                {
                    TempData["ErrorMessage"] = "Već ste autorizovani";
                    return RedirectToAction("Index", "Index");
                }
            } else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Logout()
        {
            GetSetUser.SetLoggedUser(HttpContext, null, false);
            TempData["ErrorMessage"] = "Uspješan logout";
            return RedirectToAction("Index", "Login", null);
        }

    }
}