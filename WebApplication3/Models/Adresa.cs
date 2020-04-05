using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Seminarski_fitness_centar_IB130116.Models
{
    public class Adresa
    {
        [Key] public int AdresaId { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }

        [ForeignKey("Opstina")]
        public int OpstinaId { get; set; }
        public Opstina Opstina { get; set; }

        [ForeignKey("Kontakt")]
        public int KontaktId { get; set; }
        public Kontakt Kontakt { get; set; }

    }
}
