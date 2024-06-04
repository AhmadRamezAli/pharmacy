using Pharmacy.SharedKernel.DTO;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Presentation.Models.Category
{
    public class UpdateCategoryRequest : IUpdateRequest
    {
        [Required(ErrorMessage = "please don't let this filed empty")]
        public int Id { get; set; }

        [Required(ErrorMessage = "please don't let this filed empty")]
        public string Name { get; set; } = string.Empty;

    }
}