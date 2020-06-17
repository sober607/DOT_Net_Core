using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DOT_Net_Core.Models;
using Infestation.Repositories;
using Infestation.ViewModels;

namespace DOT_Net_Core.Controllers
{
    public class NewsController : Controller
    {

        private INewsRepository _repository { get; set; }

        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }

        
        public IActionResult Index(int newsId, int authorId)
        {
            if (newsId == 0 )
            {
                var allNews = (authorId == 0)?_repository.GetAllNews(): _repository.GetAuthorNews(authorId);
                var modelViews = new List<NewsViewModel>();

                foreach (var t in allNews)
                {
                    var modelView = new NewsViewModel();
                    modelView.News = t;
                    modelViews.Add(modelView);
                }
                return View(modelViews);
            }
            else
            {
                var news = _repository.GetNews(newsId);
                var viewModels = new List<NewsViewModel>();
                var newsModel = new NewsViewModel();
                newsModel.News = news[0];
                viewModels.Add(newsModel);
                return View(viewModels);
            }

        }

        [HttpPost]
        public IActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(news);

            }
                return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



    }
}