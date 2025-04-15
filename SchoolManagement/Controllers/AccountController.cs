
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Models.Address;

namespace SchoolManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly Appdbcontext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, Appdbcontext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ActiveTabId = 4;
            return View();
        }
        [HttpGet]
        public IActionResult RegisterNewOrganizer()
        {
            ViewBag.ActiveTabId = 4;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewOrganizer(AppUser appUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appUser.UserName = appUser.Email;
                    await RegisterOrg(appUser);
                    await _signInManager.SignInAsync(appUser, isPersistent: false).ConfigureAwait(false);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return View(appUser);
        }



        [HttpGet]
        public IActionResult Login()
        {
            // ankit@bitprosoftec.com
            // Admin@20
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.LoginName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.LoginName);
                    var role = await _userManager.GetRolesAsync(user);


                    if (role.Contains("SuperAdmin"))
                        return RedirectToAction("Dashboard", "Home", new { Area = "SuperAdmin" });

                    else if (role.Contains("Staff"))
                        return RedirectToAction("Dashboard", "Home", new { Area = "Staff" });





                }
                else { ModelState.AddModelError("", "Invalid Email Id or Password"); }
            }
            ViewBag.ActiveTabId = 4;
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            ViewBag.ActiveTabId = 1;
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> CreateMasterUser()
        {
            var resultStr = string.Empty;
            try
            {
                AppUser appUser = new AppUser()
                {
                    UserName = "admin@bpst.com",
                    Email = "admin@bpst.com",
                    Password = "Admin@20",
                    ConfirmPassword = "Admin@20",
                    PhoneNumber = "9999999999",
                };

                var result = await RegisterOrg(appUser);

                if (result.Succeeded)
                {
                    var userRoles = _context.Roles.ToList();
                    foreach (var role in userRoles)
                        await _userManager.AddToRoleAsync(appUser, role.Name).ConfigureAwait(false);
                    resultStr = "Master User Created Successfully.";
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        resultStr = "Some Error: " + error.Code;
                    }
                }

            }
            catch (Exception ex)
            {
                resultStr = "Some Error: " + ex.Message;
            }
            return RedirectToAction("AutoLogin");
        }

        public async Task<IActionResult> AutoLogin()
        {
            var result = await AutoAdminLogin();
            if (result)
            {
                return RedirectToAction("Index", "Students", new { Area = "Staff" });
            }
            else { return RedirectToAction("CreateMasterUser"); }
        }


        private async Task<bool> AutoAdminLogin()
        {
            var result = await _signInManager.PasswordSignInAsync("admin@bpst.com", "Admin@20", true, lockoutOnFailure: false);
            return result.Succeeded;
        }


        private async Task<IdentityResult> RegisterOrg(AppUser appUser)
        {
            //    appUser.UserName = appUser.Email;
            var result = await _userManager.CreateAsync(appUser, appUser.Password);
            if (result.Succeeded)
            {


                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                // Common.Static.Active.SetOrganizerForUserId(organizer, organizer.OrganizerUserId);
                var result2 = await _userManager.AddToRoleAsync(appUser, "Staff");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return result;
        }
        public async Task<List<City>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }
        public async Task<List<City>> GetCitiesByStateId(int id)
        {
            return await _context.Cities.Where(c => c.StateId == id).ToListAsync();
        }
        public async Task<City> GetCity(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

    }
}
