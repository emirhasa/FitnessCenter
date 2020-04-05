using Seminarski_fitness_centar_IB130116.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_fitness_centar_IB130116.ViewModels
{
    public class ObavjestenjaVM
    {
        public List<Row> Rows { get; set; }

        public int RowCount { get; set; }

        public class Row
        {
            public int ObavjestenjeId { get; set; }

            public string Naslov { get; set; }
            public string Tekst { get; set; }
            public DateTime Vrijeme { get; set; }

            public int UserId { get; set; }
            public User User { get; set; }
        }
    }
}
