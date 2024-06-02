using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            MedicienIngredients = new HashSet<MedicienIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<MedicienIngredient> MedicienIngredients { get; set; }
    }
}
