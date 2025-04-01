using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Packaging.Signing;
using SchoolManagement.Data;
using SchoolManagement.Models;
using System;

namespace SchoolManagement.Controllers
{
    [AllowAnonymous]

    [Authorize(Roles = "Staff")]

    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly Appdbcontext _context;

        public AccountController(UserManager<AppUser> userManager,
          SignInManager<AppUser> signInManager, Appdbcontext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUser model)
        {
            // First check if ModelState is valid
            if (ModelState.IsValid)
            {
                model.UserName = model.Email;  // Set the UserName to the Email 
                model.LockoutEnabled = false;
                var result = await _userManager.CreateAsync(model);
                if (result.Succeeded)
                {
                    
                    //await _userManager.AddToRoleAsync(model, "Staff");
                    ViewBag.successmsg = "Congratulations, you have successfully registered!";
                    // return RedirectToAction("login");
                    // Redirect to the login action
                    return View(model);
                }
                else
                {
                    // If there were errors, add them to the ModelState
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If ModelState is not valid, return the view with the model (showing validation errors)
            return View(model);
        }


         [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.LoginName, model.Password, true, lockoutOnFailure: false);

                if (result.Succeeded)
                    return View(result);
                else { ModelState.AddModelError("", "Invalid Email Id or Password"); }
            }
            return View(model);
        }
    }

}


