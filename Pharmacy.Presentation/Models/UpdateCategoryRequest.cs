using Pharmacy.SharedKernel.DTO;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Presentation.Models
{
    public class UpdateCategoryRequest : IUpdateRequest
    {
        public int Id { get; set; }

        [MaxLength(70,ErrorMessage ="WTF")]
        public string Name { get; set; } = string.Empty;

    }
}