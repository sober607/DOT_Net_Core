using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DOT_Net_Core.Models;
using Microsoft.EntityFrameworkCore;
using DOT_Net_Core.Repository;

namespace DOT_Net_Core.Controllers
{
    public class HumanController : Controller
    {

        private DOT_Net_CoreContext _context { get; set; }

        private IHumanActions _repository { get; set; }

        public HumanController(DOT_Net_CoreContext context)
        {
            this._context = context;
        }
        public IActionResult Index(int humanId)
        {
            
            
            ViewData["IndexHumanControllerData"] = (humanId == 0) ?  _context.Humans.ToList() : ViewData["IndexHumanControllerData"] = _context.Humans.Where(x => x.Id == humanId).ToList();
            
            return View();
        }

        public IActionResult Country(string name)
        {
            ViewData["human"] = _context.Humans.Where(x => x.Country.Name == name).ToList();
            return View();
        }

        public IActionResult Getallhumans()
        {
            ViewData["humanRepository"] = _repository.GetAllHumans();
            return View();
        }



    }
}
