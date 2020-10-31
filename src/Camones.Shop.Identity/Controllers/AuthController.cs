using Camones.Shop.Identity.Domain;
using Camones.Shop.Identity.ViewModel;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Camones.Shop.Identity.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interactionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {            
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl                
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {

            var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect(vm.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();

            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);

            if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}