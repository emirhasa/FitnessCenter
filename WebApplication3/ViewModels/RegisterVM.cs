using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seminarski_fitness_centar_IB130116.Controllers;


namespace Seminarski_fitness_centar_IB130116.ViewModels
{
    public class RegisterVM
    {
        public enum UserType
        {
            Zaposlenik,
            Admin,
            Master
        }

        [Required]
        [Remote(nameof(RegisterController.CheckUsernameAvailability), "Register")]
        [StringLength(50, ErrorMessage = "Username moze sadrzavati minimalno 3, a maximalno 50 karaktera",
            MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password moze sadrzavati minimalno 8, a maximalno 50 karaktera",
            MinimumLength = 8)]
        public string Password { get; set; }

        /* [Required]
        [PasswordConfirmed]
        public string PasswordConfirmation { get; set; }*/

        [Required]
        [EmailAddress(ErrorMessage = "Unesi pravilnu email adresu")]
        [Remote(nameof(RegisterController.CheckEmailAvailability), "Register" )]
        public string Email { get; set; }

        public UserType TipKorisnika { get; set; }
    }
}
