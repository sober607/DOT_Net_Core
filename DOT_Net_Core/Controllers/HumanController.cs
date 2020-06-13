﻿using System;
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

        public IActionResult Index(int humanId)
        {

            //использование метода из DI для ДЗ 5.5
             if (humanId == 0)
            {
                ViewData["IndexHumanControllerData"] = _repository.GetAllHumans();
                            }
            else
            {
                ViewData["IndexHumanControllerData"] = _repository.GetHuman(humanId);

            }

            return View();
        }

        public IActionResult Authors([FromServices] INewsRepository newsRepository)
        {
            var humans = _repository.GetAllHumans();
            var viewModels = new List<HumanAuthorsViewModel>();

            foreach (var human in humans)
            {
                var viewModel = new HumanAuthorsViewModel();
                viewModel.FirstName = human.FirstName;
                viewModel.LastName = human.LastName;
                viewModel.NewsCount = newsRepository.GetAllNews().Count(news => news.AuthorId == human.Id);

                viewModels.Add(viewModel);
            }

            return View(viewModels);

        }


        public IActionResult Country(string name)
        {
            ViewBag.Country = _context.Humans.Where(x => x.Country.Name == name).ToList();
            return View();
        }

        public IActionResult HumanCreate(string firstName, string lastName, int age, bool isSick, string gender, int countryId)
        {
            _repository.CreateHuman(firstName, lastName, age, isSick, gender, countryId);
            ViewData["IndexHumanControllerData"] = _repository.GetAllHumans();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human human)
        {
            _repository.CreateHuman(human);
            return View();
        }

        public IActionResult HumanModify(int humanId, string firstName, string lastName, int age, bool isSick, string gender, int countryId)
        {
            _repository.ModifyHuman(humanId, firstName, lastName, age, isSick, gender, countryId);
            ViewData["IndexHumanControllerData"] = _repository.GetAllHumans();
            return View();
        }

        public IActionResult HumanDelete(int humanId)
        {
            _repository.DeleteHuman(humanId);
            ViewData["IndexHumanControllerData"] = _repository.GetAllHumans();
            return View();
        }
        
                public IActionResult Create()
        {
            
            return View();
        }




    }
}
