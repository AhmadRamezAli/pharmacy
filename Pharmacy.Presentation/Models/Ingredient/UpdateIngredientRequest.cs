using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Models.Ingredient
{
    internal class UpdateIngredientRequest
    {
        public int Id { get; set; }

        [MaxLength(70, ErrorMessage = "WTF")]

        public string Name { get; set; } = null!;

        [MaxLength(150, ErrorMessage = "WTF")]
        public string Description { get; set; } = null!;
    }
}
