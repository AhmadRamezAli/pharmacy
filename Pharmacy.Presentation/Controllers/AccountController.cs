using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Presentation.Models.User;

namespace Pharmacy.Presentation.Controllers
{
    public class AccountController: Controller
    {
        public UserManager<User> userManager;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AsyncLogIn()
        {
            return View();
        }




        [HttpGet]
        public IActionResult Register() {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyRegister(User user)
        {
            var exist=await userManager.FindByEmailAsync(user.Email);
            if (exist is null)
            {
             var result  =   await userManager.CreateAsync(user, user.Password);

                if (result.Succeeded)
                    return View();
            }
            return View();
            
        }

    }
}
