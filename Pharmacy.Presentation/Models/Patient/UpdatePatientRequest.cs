using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Models.Patient
{
    internal class UpdatePatientRequest
    {
        public int Id { get; set; }
        [MaxLength(70, ErrorMessage = "WTF")]
        public string FirstName { get; set; } = null!;
        [MaxLength(70, ErrorMessage = "WTF")]
        public string LastName { get; set; } = null!;
    }
}
