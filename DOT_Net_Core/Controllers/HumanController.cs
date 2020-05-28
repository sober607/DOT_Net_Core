using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DOT_Net_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DOT_Net_Core.Controllers
{
    public class HumanController : Controller
    {

        private DOT_Net_CoreContext _context { get; set; }
        public HumanController(DOT_Net_CoreContext context)
        {
            this._context = context;
        }
        public IActionResult Index(int id)
        {
            
            return View();
        }

        public IActionResult Country(string name)
        {
            ViewData["human"] = _context.Humans.Where(x => x.Country.Name == name).ToList();
            return View();
        }

    }
}
