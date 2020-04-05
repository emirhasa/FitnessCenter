using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Seminarski_fitness_centar_IB130116.Models
{
    public class Opstina
    {
        [Key] public int OpstinaId { get; set; }
        public string Naziv { get; set; }
        
        [ForeignKey("Grad")]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}
