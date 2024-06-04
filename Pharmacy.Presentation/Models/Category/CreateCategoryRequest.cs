using Pharmacy.SharedKernel.DTO;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Presentation.Models.Category
{
    public class CreateCategoryRequest : ICreateRequest
    {
        [Required(ErrorMessage ="please don't let this filed empty")]
        public string Name { get; set; } = string.Empty;
    }
}