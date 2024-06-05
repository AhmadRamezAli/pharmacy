using Pharmacy.SharedKernel.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Models.Medicine
{
    public class CreateMedicineRequest:ICreateRequest
    {
        [MaxLength(70, ErrorMessage = "WTF")]

        public string Name { get; set; } = null!;

        [MaxLength(70, ErrorMessage = "WTF")]

        public string Description { get; set; } = null!;

        [MaxLength(70, ErrorMessage = "WTF")]

        public int Category { get; set; }

        [MaxLength(70, ErrorMessage = "WTF")]

        public decimal Dosage { get; set; }

        [MaxLength(70, ErrorMessage = "WTF")]

        public int Company { get; set; }
        public string ScientificName { get; set; } = null!;
    }
}
