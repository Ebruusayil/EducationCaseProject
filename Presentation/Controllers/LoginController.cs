using Dto;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
               
                var user = await _userManager.FindByNameAsync(loginDto.Username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                     
                        if (await _userManager.IsInRoleAsync(user, "Student"))
                        {
                            return RedirectToAction("Index", "Home"); 
                        }
                        else if (await _userManager.IsInRoleAsync(user, "Teacher"))
                        {
                            return RedirectToAction("Index", "Home"); 
                        }
                        else if (await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToAction("Dashboard", "Admin"); 
                        }
                    }
                }

                
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }

            return View(loginDto);
        }
    }
}
