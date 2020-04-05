using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Seminarski_fitness_centar_IB130116.DB;
using Seminarski_fitness_centar_IB130116.Models;

namespace Seminarski_fitness_centar_IB130116.Helper
{
    public static class GetSetUser
    {
        private const string LogiraniKorisnik = "LoggedInUser";
        private const string TwoFactor = "TwoFactor";

        public static void SetLoggedUser(this HttpContext Context, User user, bool SnimiUCookie = false)
        {
            Context.Session.Set(LogiraniKorisnik, user);
        }

        public static User GetLoggedUser(this HttpContext Context)
        {
            User user = Context.Session.Get<User>(LogiraniKorisnik);
            if(user != null)
            {
                //refresh data
                //make extra function to just set necessary session data to not call the database
                MyContext db = new MyContext();
                user = db.Users.Find(user.UserId);
            }
            return user;
        }

        public static int GetTwoFactor(this HttpContext Context)
        {
            int twofactor = Context.Session.Get<int>(TwoFactor);

            return twofactor;
        }

    }
}
