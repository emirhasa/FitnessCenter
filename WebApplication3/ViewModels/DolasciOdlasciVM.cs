using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seminarski_fitness_centar_IB130116.Controllers;
using Seminarski_fitness_centar_IB130116.Models;


namespace Seminarski_fitness_centar_IB130116.ViewModels
{
    public class DolasciOdlasciVM
    {

        public List<Row> Rows { get; set; }

        public class Row
        {
            public int DolazakOdlazakId { get; set; }

            public DateTime VrijemeDolaska { get; set; }
            public DateTime VrijemeOdlaska { get; set; }

            public int UserId { get; set; }
            public User User { get; set; }
        }

    }
}
