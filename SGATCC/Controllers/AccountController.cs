using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGATCC.Models;
using System.Threading.Tasks;

namespace SGATCC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    var role = await _userManager.GetRolesAsync(user);

                    if (role.Contains("Coordenador"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Coordenador" });

                    }
                    return RedirectToAction("Grade", "Relatorio", new { area = "Coordenador" });
                }
                else
                {
                    ViewBag.Erro = "Usuário ou Senha Inválidos";
                }
            }
            else
            {
                ViewBag.Erro = "Usuário não Encontrado";
            }

            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
