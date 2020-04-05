using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_fitness_centar_IB130116.Models
{
    public class Obavjestenje
    {
        [Key]
        public int ObavjestenjeId { get; set; }

        [Required]
        public string Naslov { get; set; }
        [Required]
        public string Tekst { get; set; }

        public DateTime Vrijeme { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
