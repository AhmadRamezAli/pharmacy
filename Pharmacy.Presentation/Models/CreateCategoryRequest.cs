using Pharmacy.SharedKernel.DTO;

namespace Pharmacy.Presentation.Models
{
    public class CreateCategoryRequest : ICreateRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}