﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebUI.Controllers
{
    public class CitiesJsonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
