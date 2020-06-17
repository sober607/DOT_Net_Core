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
using Infestation.Repositories;
using Infestation.ViewModels;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace DOT_Net_Core.Controllers
{
    public class HumanController : Controller
    {

        private DOT_Net_CoreContext _context { get; set; }

        private IHumanActions _repository { get; set; }


        public HumanController(DOT_Net_CoreContext context, IHumanActions repository)
        {
            this._context = context;
            this._repository = repository;
        }

        public IActionResult Index(List <int?> humanIds)
        {
            // if no ID value given in url
            if (humanIds.Count == 0)
            {
                var humans = _repository.GetAllHumans();
                var viewModels = new List<HumanIndexViewModel>();
                
                foreach (var human in humans)
                {
                    var humanModel = new HumanIndexViewModel();
                    humanModel.Human = human;
                    viewModels.Add(humanModel);
                }
                return View(viewModels);
            }
            else
            {
                
                var viewModels = new List<HumanIndexViewModel>() ;
                
                foreach (int id in humanIds)
                {
                    var humanModel = new HumanIndexViewModel();
                    humanModel.Human = _repository.GetHuman(id)[0];
                    viewModels.Add(humanModel);
                }
                
                return View(viewModels);
            }

        }

        public IActionResult Authors([FromServices] INewsRepository newsRepository, [FromQuery] int humanId)
        {
            
            if (humanId == 0 )
            {

                var humans = _repository.GetAllHumans();
                var viewModels = new List<HumanAuthorsViewModel>();

                foreach (var human in humans)
                {
                    var viewModel = new HumanAuthorsViewModel();
                    viewModel.FirstName = human.FirstName;
                    viewModel.LastName = human.LastName;
                    viewModel.AuthorId = human.Id;
                    viewModel.NewsCount = newsRepository.GetAllNews().Count(news => news.AuthorId == human.Id);

                    viewModels.Add(viewModel);
                }

                return View(viewModels);
            }
            else
            {
                var human = _repository.GetHuman(humanId);
                var viewModels = new List<HumanAuthorsViewModel>();
                    var viewModel = new HumanAuthorsViewModel();
                    viewModel.FirstName = human[0].FirstName;
                    viewModel.LastName = human[0].LastName;
                    viewModel.NewsCount = newsRepository.GetAllNews().Count(news => news.AuthorId == human[0].Id);

                    viewModels.Add(viewModel);


                return View(viewModels);
            }

        }


        public IActionResult Country(string name)
        {

            StringBuilder humanIds = new StringBuilder("?humanIds=");
            foreach (int t in _context.Humans.Where(x => x.Country.Name == name).Select(x => x.Id).ToList())
            {
                if (t == (_context.Humans.Where(x => x.Country.Name == name).Select(x => x.Id).ToList()).First())
                {
                    humanIds.Append(t);
                }
                else 
                { 
                humanIds.Append("&" + "humanIds=" + t.ToString()  );
                }
            }

            return Redirect("/Human/Index" + humanIds );
           
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create(Human human)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(human);
            }

            
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult HumanModify(int humanId, string firstName, string lastName, int age, bool isSick, string gender, int countryId)
        {
            _repository.ModifyHuman(humanId, firstName, lastName, age, isSick, gender, countryId);
            var humans = _repository.GetAllHumans();
            var viewModels = new List<HumanIndexViewModel>();

            foreach (var human in humans)
            {
                var humanModel = new HumanIndexViewModel();
                humanModel.Human = human;
                viewModels.Add(humanModel);
            }
            return View(viewModels);
        }

        public IActionResult HumanDelete(int humanId)
        {
            _repository.DeleteHuman(humanId);
            var humans = _repository.GetAllHumans();
            var viewModels = new List<HumanIndexViewModel>();

            foreach (var human in humans)
            {
                var humanModel = new HumanIndexViewModel();
                humanModel.Human = human;
                viewModels.Add(humanModel);
            }
            return View(viewModels);
        }
        
              




    }
}
