using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DOT_Net_Core.Models;
using Infestation.Repositories;

namespace DOT_Net_Core.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
       private INewsRepository _repository { get; set; }

        public NewsController (INewsRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            
                ViewData["News"] = _repository.GetAllNews();
            
            return View();
        }
        public IActionResult Show(int id)
        {

            ViewData["News"] = _repository.GetAllNews().SingleOrDefault(x => x.Id == id);

            return View();
        }

        // GET: News/Create

    }
}