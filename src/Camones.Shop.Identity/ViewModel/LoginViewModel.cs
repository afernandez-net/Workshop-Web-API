using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camones.Shop.Identity.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
