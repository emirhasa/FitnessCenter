using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_fitness_centar_IB130116.Models
{
    public class DolazakOdlazak
    {
        [Key]
        public int DolazakOdlazakId { get; set; }

        [Required]
        public DateTime VrijemeDolaska { get; set; } //obavezan unijeti, vrijeme odlaska nije obavezno u trenutku kreiranja ovog unosa u tabelu jer se ono naknadno ažurira

        public DateTime VrijemeOdlaska { get; set; } 

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
