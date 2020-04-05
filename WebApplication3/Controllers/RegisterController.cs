using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seminarski_fitness_centar_IB130116.DB;
using Seminarski_fitness_centar_IB130116.Models;
using Seminarski_fitness_centar_IB130116.ViewModels;
using System.Net;
using System.Net.Mail;
using Seminarski_fitness_centar_IB130116.Helper;

namespace Seminarski_fitness_centar_IB130116.Controllers
{
    public class RegisterController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(RegisterVM input)
        {
                    
            if (ModelState.IsValid)
            {
                if (CheckEmail(input.Email)) //dodatna back-end provjera za zauzetost maila jer ModelState.IsValid ne provjerava REMOTE
                {
                    ModelState.AddModelError("Email", $"Email {input.Email} je zauzet!");
                    //TempData["ErrorMessage"] = "Check the fields";
                }
                if (CheckEmail(input.Username)) //dodatna back-end provjera za zauzetost username jer ModelState.IsValid ne provjerava REMOTE
                {
                    ModelState.AddModelError("Username", $"Username {input.Username} je zauzet!");
                    //TempData["ErrorMessage"] = "Check the fields";
                }

                if(CheckEmail(input.Username) || CheckEmail(input.Email)) return PartialView("Register", input);
                TempData["ErrorMessage"] = "Uspjesna registracija!"; //obavijesti korisnika o uspjesnoj registraciji
                //dodaj korisnika u bazu

                User novi = new User
                {
                    Username = input.Username,
                    Password = input.Password,
                    Email = input.Email,
                    Role = 0
                };
                db.Users.Add(novi);

                Zaposlenik novi_zaposlenik = new Zaposlenik
                {
                    User = novi,
                    UserId = novi.UserId
                };
                db.Zaposlenici.Add(novi_zaposlenik);

                //slanje konfirmacijskog maila za registraciju

                var message = new MailMessage();
                Guid guid = Guid.NewGuid();
                string link = "https:fitnessc.brodev.info/Register/PotvrdiMail?email=" + input.Email + "&guid=" + guid;
                MailPotvrda potvrda = new MailPotvrda
                {
                    Email = input.Email,
                    KonfirmacijskiKod = guid.ToString()
                };
                db.MailPotvrde.Add(potvrda);


                try
                {
                    HelpFunctions.SendMail("Potvrda o registraciji za " + novi.Username, "<p><b>Verifikacija maila</b></p><p>Molimo vas da potvrdite vaš mail klikom na sljedeći link: " + link + "</p>", "FITib130116@gmail.com", novi.Email);
                }
                catch
                {
                    //staviti u funkciju
                    TempData["ErrorMessage"] = "Nazalost problem u komunikaciji sa SMTP serverom, vjerovatno zbog novih googleovih security postavki. Nismo mogli poslati mail za potvrdu registracije!";
                }
                db.SaveChanges();

                HttpContext.SetLoggedUser(novi); //po registraciji automatski uloguj korisnika
                //dodaj zaposlenika u tabelu zaposlenici, default korisnik je zaposlenik
                return RedirectToAction("Index", "Index");

            }
            else
            {
                //TempData["ErrorMessage"] = "Check the fields";
                return PartialView("Register", input);
            }

        }

        public IActionResult PotvrdiMail(string email, string guid)
        {

            if(db.Users.Any(u => u.Email == email && u.EmailConfirm == 1)) //provjeri da li je dati mail vec potvrdjen
            {
                TempData["ErrorMessage"] = "Email već potvrđen";
                return RedirectToAction("Index", "Index");
            }
            //potrazi da li je Guid za konfirmaciju validan za dati mail
            MailPotvrda potvrda = db.MailPotvrde.Where(p => p.Email == email && p.KonfirmacijskiKod == guid).SingleOrDefault();

            if (potvrda != null )
            {

                User potvrdi_mail_user = db.Users.Where(u => u.Email == email).SingleOrDefault();
                potvrdi_mail_user.EmailConfirm = 1;
                db.Entry(potvrdi_mail_user).CurrentValues.SetValues(potvrdi_mail_user);
                db.SaveChanges();
                TempData["Potvrdjen"] = 1;
                TempData["Email"] = email;
                return RedirectToAction("MailPotvrdjen", "Register");
                
            }

            TempData["ErrorMessage"] = "Greska u potvrdi";
            return RedirectToAction("Index", "Index");

        }

        public IActionResult MailPotvrdjen()
        {
            return View();
        }

        public IActionResult PosaljiKonfirmacijskiMail()  //slanje konfirmacijskog maila za registraciju putem pozivanja akcije preko frontenda
        {
           User korisnik = HttpContext.GetLoggedUser();
           if (korisnik.EmailConfirm == 0)
            {  
                
                Guid guid = Guid.NewGuid();
                string link = "https://fitnessc.brodev.info/Register/PotvrdiMail?email=" + korisnik.Email + "&guid=" + guid;
                MailPotvrda potvrda = new MailPotvrda
                {
                    Email = korisnik.Email,
                    KonfirmacijskiKod = guid.ToString()
                };
                db.MailPotvrde.Add(potvrda);

                db.SaveChanges();

                try
                {
                    HelpFunctions.SendMail("Potvrda o registraciji za " + korisnik.Username, "<p><b>Verifikacija maila</b></p><p>Molimo vas da potvrdite vaš mail klikom na sljedeći link: " + link + "</p>", "FITib130116@gmail.com", korisnik.Email);
                    TempData["ErrorMessage"] = "Novi mail poslan";
                }
                catch
                {
                    //staviti u funkciju
                    TempData["ErrorMessage"] = "Greška u komunikaciji sa SMTP serverom, vjerovatno zbog novih google security postavki. Nismo mogli poslati mail :/";
                }
                return RedirectToAction("Index", "Index");
            }
            TempData["ErrorMessage"] = "Već ste verifikovani!";
            return RedirectToAction("Index", "Index");
        }

        public bool CheckEmail(string email)
        {
            if (db.Users.Any(u => u.Email == email))
            {
                return true;
            }
            return false;
        }

        public bool CheckUsername(string username)
        {
            if (db.Users.Any(u => u.Username == username))
            {
                return true;
            }
            return false;
        }

        public IActionResult CheckEmailAvailability(string email)
        {
            if (db.Users.Any(u => u.Email == email))
            {
                return Json($"Email {email} je zauzet!");
            }
            return Json(true);
        }

        public IActionResult CheckUsernameAvailability(string username)
        {
            if (db.Users.Any(u => u.Username == username))
            {
                return Json($"Username {username} je zauzet!");
            }
            return Json(true);
        }

    }
      
    
}