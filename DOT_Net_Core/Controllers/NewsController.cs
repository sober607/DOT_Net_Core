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
        public static int newsQty;

        public IActionResult Index()
        {
            foreach (var tmp in NewsBase.News)
            {
                ViewData[Convert.ToString(tmp.Id)] = NewsBase.News.SingleOrDefault(t => t.Id == tmp.Id);
                newsQty++;
            }
            //ViewData["somekey"] = NewsBase.News.SingleOrDefault(t => t.Id == 1);




            return View();
        }
        public IActionResult Show()
        {

           

            return View();
        }

        // GET: News/Create

    }
}