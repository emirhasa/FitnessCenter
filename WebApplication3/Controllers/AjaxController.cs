using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seminarski_fitness_centar_IB130116.ViewModels;

namespace Seminarski_fitness_centar_IB130116.Controllers
{
    public class AjaxController : Controller
    {

        public IActionResult Index()
        {
            return View("Index", "Index");
        }

        public IActionResult GetObavjestenja(int from, int per_page)
        {
            //uzmi obavjestenja Od- Do
            return View("Index", "Index");
        }

    }
}