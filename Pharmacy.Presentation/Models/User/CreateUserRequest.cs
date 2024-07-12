using Microsoft.AspNetCore.Identity;
using Pharmacy.SharedKernel.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Models.User
{
    public class CreateUserRequest:User,ICreateRequest
    {
        [Required]
        public string Password { get; set; }
   
        public string ConfirmPassword { get; set; }
        public string  ReturnUrl { get; set; }
    }
}
