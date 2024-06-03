using Pharmacy.SharedKernel.Entities;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public partial class Ingredient : Entity
    {
        public Ingredient()
        {
            MedicienIngredients = new HashSet<MedicienIngredient>();
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<MedicienIngredient> MedicienIngredients { get; set; }
    }
}
