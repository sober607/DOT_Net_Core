using Infestation.Infrastructure.Services.Interfaces;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<IdentityUser> _signInManager { get;  }
        public UserManager<IdentityUser> _userManager {get; set;}
       
        private IMessageService _messageServices { get; }
        
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMessageService messageService) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messageServices = messageService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel viewModel)
        {
            var user = new IdentityUser() { Email = viewModel.Email, UserName = viewModel.Email };
            var createTask = _userManager.CreateAsync(user, viewModel.Password);
            
            if (createTask.Result.Succeeded)
            {
                _signInManager.SignInAsync(user, false);
                _messageServices.SendMessage();
                return RedirectToAction("Index", "Human");
            }

            foreach(var error in createTask.Result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ViewData["errors"] = createTask.Result.Errors;
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel loginViewModel, [FromQuery] string returnUrl)
        {
            if (ModelState.IsValid)
            {

            
            var signInTask = _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);
            if(signInTask.Result.Succeeded)
            {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                return RedirectToAction("Index", "Human");
            }
                ModelState.AddModelError("","incorrect username or password");
            }


            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "News");
        }
    }
}
