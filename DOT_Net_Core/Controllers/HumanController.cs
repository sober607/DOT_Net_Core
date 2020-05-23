using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DOT_Net_Core.Models;

namespace DOT_Net_Core.Controllers
{
    public class HumanController : Controller
    {

        public IActionResult Index()
        {
            return BadRequest();
        }

    }
}
