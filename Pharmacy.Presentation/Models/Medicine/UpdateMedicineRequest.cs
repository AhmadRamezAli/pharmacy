using Pharmacy.SharedKernel.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Models.Medicine
{
    public class UpdateMedicineRequest:IUpdateRequest
    {
        public int Id { get; set;}
        [MaxLength(70, ErrorMessage = "WTF")]
        public string Name { get; set; } = null!;
        [MaxLength(70, ErrorMessage = "WTF")]
        public string Description { get; set; } = null!;
        public decimal Dosage { get; set; }
        [MaxLength(70, ErrorMessage = "WTF")]
        public string? ScientificName { get; set; } = null;
    }
}
