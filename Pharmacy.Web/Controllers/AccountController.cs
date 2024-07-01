
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Presentation.Models.User;
using Microsoft.EntityFrameworkCore;
using global::Pharmacy.Infrastracture.DataContext;
using global::Pharmacy.Presentation.Models.User;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Pharmacy.Web.Controllers
{
        public class AccountController : Controller
        {
            public UserManager<User> userManager;

            protected PharmacyContext _context;
        private SignInManager<User> _signInManager;
        public string _url;
        public AccountController(Microsoft.AspNetCore.Identity.UserManager<User> userManager,

            SignInManager<User> signInManager, PharmacyContext context)
            {
                _context = context;
            _signInManager = signInManager;
                this.userManager = userManager;
          
            }

            [HttpGet]
            public IActionResult LogIn()
            {
                return View();
            }
        [HttpPost]
        public async Task<IActionResult> AsyncLogIn(CreateUserRequest loguser)
        {
            var user = this._context.Users.FirstOrDefault(account => account.Email == loguser.Email);


            var result = await userManager.CheckPasswordAsync( user,loguser.Password);
            switch (result)
            {
                case true:
                    return LocalRedirect("home");
                case false:
                    throw new Exception("invlaid user");
                default:
                    throw new Exception("nothing baby");
                   
            }
        }
    




            [HttpGet]
            public IActionResult Register()
            {


                return View();
            }

            [HttpPost]
            public async Task<IActionResult> ApplyRegister(CreateUserRequest createUser)
            {
                var exist = await userManager.FindByEmailAsync(createUser.Email);
                if (exist is null)
                {
                    var user = new User
                    {
                        FirstName = createUser.FirstName,
                        LastName = createUser.LastName,
                        UserName=createUser.Email,
                        Email=createUser.Email,
                        EmailConfirmed=true,
                        PhoneNumberConfirmed=true
                        


                    };
                    var result = await userManager.CreateAsync(user, createUser.Password);

                    if (result.Succeeded)
                    {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("/home");
                    //    _context.SaveChanges();
                    //Console.WriteLine(user);
                    return View("LogIn");
                    }
                }
                return View("LogIN");


            }

        }
    }

