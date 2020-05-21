using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DOT_Net_Core.Models;

namespace DOT_Net_Core.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
       

        public IActionResult Index()
        {
            
                ViewData["News"] = NewsBase.News;
            
            return View();
        }
        public IActionResult Show()
        {

           

            return View();
        }

        // GET: News/Create

    }
}