using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seminarski_fitness_centar_IB130116.Controllers;
using Seminarski_fitness_centar_IB130116.DB;
using Seminarski_fitness_centar_IB130116.Models;
using Seminarski_fitness_centar_IB130116.ViewModels;

namespace Seminarski_fitness_centar_IB130116.Helper
{
    public class HelpFunctions
    {
        public static ObavjestenjaVM GetObavjestenja(int from =0, int per_page = 10)
        {
            MyContext db = new MyContext();
            ObavjestenjaVM obavjestenja = new ObavjestenjaVM();
            obavjestenja.Rows = db.Obavjestenja.OrderByDescending(o => o.ObavjestenjeId).Include(o=>o.User).Skip(from).Take(per_page).Select(
                o=> new ObavjestenjaVM.Row
                {
                    ObavjestenjeId = o.ObavjestenjeId,
                    Naslov = o.Naslov,
                    Tekst = o.Tekst,
                    Vrijeme = o.Vrijeme,
                    UserId = o.UserId,
                    User = o.User
                }
            ).ToList();
            
            return obavjestenja;
        }

        public static bool SendMail(string subject, string content, string from, string to)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(to));
            message.To.Add(new MailAddress("FITib130116@gmail.com"));
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = content;
            message.IsBodyHtml = true;

            var credential = new NetworkCredential
            {
                UserName = "FITib130116@gmail.com",
                Password = "seminarskiib130116"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = credential;
                smtp.Send(message);

            }
            return true;
        }

    }
}
