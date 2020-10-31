using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Camones.Shop.View.Controllers
{
    public class EcommerceController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }
    }
}