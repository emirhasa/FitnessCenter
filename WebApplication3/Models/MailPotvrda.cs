using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Seminarski_fitness_centar_IB130116.Models
{
    public class MailPotvrda
    {
        [Key] public int PotvrdaId { get; set; }

        public string Email { get; set; }
        public string KonfirmacijskiKod { get; set; }
    }
}
