using Pharmacy.SharedKernel.DTO;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Presentation.Models.Ingredient
{
    public class CreateIngredientRequest:ICreateRequest
    {
        [MaxLength(70, ErrorMessage = "WTF")]
        public string Name { get; set; } = null!;
        [MaxLength(150, ErrorMessage = "WTF")]
        public string Description { get; set; } = null!;
    }
}
