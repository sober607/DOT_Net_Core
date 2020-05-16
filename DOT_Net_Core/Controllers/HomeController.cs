using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace DOT_Net_Core.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            return "Test info from class " + this.GetType();
        }

    }
}
