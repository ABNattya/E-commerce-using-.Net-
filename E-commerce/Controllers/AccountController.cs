using E_commerce.Data;
using E_commerce.Data.Static;
using E_commerce.Data.ViewModel;
using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace E_commerce.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser>_userManager;
        private readonly SignInManager<ApplicationUser>_signInManager;
        private readonly AppDbContext _Context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext Context)
        {
            _Context = Context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult LogIn()
        {
            return View(new LoginVM());
        }

         [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong Password. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        public async Task <IActionResult> Register( RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            var user = await _userManager.FindByEmailAsync(registerVM.Email);

            if(user != null)
            {
                TempData["Error"] = "The Email Address is already exist!";
            }

            var newUser = new ApplicationUser()
            {
                FullName=registerVM.FullName,
                Email = registerVM.Email,
                UserName=registerVM.Email
            };



            var response=await _userManager.CreateAsync(newUser,registerVM.Password);

            if (response.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Movies");
        } 

        public async Task<IActionResult> AllUsers()
        {
            var users =await _Context.Users.ToListAsync();
            return View(users);
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
