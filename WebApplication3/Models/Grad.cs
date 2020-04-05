using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Seminarski_fitness_centar_IB130116.Models
{
    public class Grad
    {
        [Key] public int GradId { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
    }
}
