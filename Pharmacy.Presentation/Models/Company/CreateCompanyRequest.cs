using Pharmacy.SharedKernel.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Models.Company
{
    public class CreateCompanyRequest:ICreateRequest
    {
        [MaxLength(70, ErrorMessage = "WTF")]
        public string Name { get; set; } = string.Empty;

    }
}
