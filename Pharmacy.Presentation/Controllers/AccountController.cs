
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Pharmacy.Presentation.Models.User;

namespace Pharmacy.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<User> userManager;

        private SignInManager<User> _signInManager;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            ViewBag.returnUrl = ReturnUrl;
            return View();
        }
        [FromQuery]
        public string? ReturnUrl { get; set; }

        [HttpPost]
        public async Task<IActionResult> AsyncLogIn(CreateUserRequest loguser)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(loguser.Email);
            }
            catch (Exception e)
            {
                TempData["error"] = "Invalid email try again";
                return RedirectToAction("Index");
            }

            var result = await _signInManager.PasswordSignInAsync(loguser.Email, loguser.Password, false, lockoutOnFailure: false);

            //  var result = await userManager.CheckPasswordAsync( user,loguser.Password);
            switch (result.Succeeded)
            {
                case true:
                    TempData["message"] = "loged in successfully";
                    try
                    {
                        return Redirect(loguser.ReturnUrl);
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                case false:
                    TempData["error"] = "Invalid password or email try again";
                    return RedirectToAction("Login");
                default:
                    throw new Exception("nothing baby");

            }
        }





        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.returnUrl = ReturnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyRegister(CreateUserRequest createUser)
        {
            try
            {
                var exist = await userManager.FindByEmailAsync(createUser.Email);


                if (exist is null)
                {
                    var user = new User
                    {
                        FirstName = createUser.FirstName,
                        LastName = createUser.LastName,
                        UserName = createUser.Email,
                        Email = createUser.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true



                    };
                    var result = await userManager.CreateAsync(user, createUser.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        try
                        {
                            return Redirect(createUser.ReturnUrl);
                        }
                        catch (Exception e)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }
                return View("LogIn");
            }
            catch (Exception e)
            {
                TempData["error"] = "Invalid informations try again";

                return View("LogIn");
            }
        }


    }

}


